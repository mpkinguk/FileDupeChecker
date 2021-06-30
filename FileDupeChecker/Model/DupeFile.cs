using System.Collections.Generic;
using System.IO;
using System;

namespace FileDupeChecker.Model
{
    /// <summary>
    /// Dupe File Model class
    /// </summary>
    public class DupeFile
    {
        /// <summary>
        /// The file name
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// The file path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// The full file path
        /// </summary>
        public string FullFilePath => Path.Combine(FilePath, FileName);

        /// <summary>
        /// The file size in bytes
        /// </summary>
        public decimal FileSize { get; set; }

        /// <summary>
        /// The file size in kilobytes
        /// </summary>
        public decimal FileSizeKB => Math.Round(FileSize / 1000, 2);

        /// <summary>
        /// The file size in Megabytes
        /// </summary>
        public decimal FileSizeMB => Math.Round(FileSizeKB / 1000, 2);

        /// <summary>
        /// The file size in Gigabytes
        /// </summary>
        public decimal FileSizeGB => Math.Round(FileSizeMB / 1000, 2);

        /// <summary>
        /// List of files that match this one
        /// </summary>
        public List<DupeFile> DupeMatches { get; set; }
    }
}
