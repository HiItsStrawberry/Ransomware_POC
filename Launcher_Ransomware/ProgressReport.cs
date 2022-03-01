namespace Launcher_Ransomware
{
    public class ProgressReport
    {
        public int RemainFiles { get; set; }
        public int TotalFiles { get; set; } = 0;  
        public int PercentageComplete { get; set; } = 0;
        public string CurrentFilesProcessed { get; set; }

        public string GetCurrentProcessedFile()
        {
            return $"Name: {this.CurrentFilesProcessed}";
        }

        public string GetTotalEnRemainFiles()
        {
            return $"Total Encrypted: {this.RemainFiles}";
        }

        public string GetTotalDeRemainFiles()
        {
            return $"Total Decrypted: {this.RemainFiles}";
        }

        public string GetTotalPercentageComplete()
        {
            return $"{this.PercentageComplete}% complete";
        }
    }
}
