using FileDupeChecker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FileDupeChecker
{
    public delegate void ProcessChangedHandler(int value);
    public delegate void FilesRetrievedHandler(int value);

    public class FileDupeChecker
    {
        public const int MAX_PATH = 260;
        public const int MAX_ALTERNATE = 14;

        [StructLayout(LayoutKind.Sequential)]
        public struct FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WIN32_FIND_DATA
        {
            public FileAttributes dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ALTERNATE)]
            public string cAlternate;
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        public List<DupeFile> DupeFiles { get; set; }

        public event ProcessChangedHandler ProcessChanged;
        public event FilesRetrievedHandler FilesRetrieved;

        private readonly string _path;
        private readonly string _wildcard;
        private readonly bool _includeSubDirectories;

        private bool _cancelled;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="wildcard">The wildcard (default "*.*")</param>
        /// <param name="includeSubDirectories">Includ subdirectories in search (default true)</param>
        public FileDupeChecker(string path, string wildcard = "*.*", bool includeSubDirectories = true)
        {
            _path = path;
            _wildcard = wildcard;
            _includeSubDirectories = includeSubDirectories;
            _cancelled = false;

            DupeFiles = new List<DupeFile>();
        }

        /// <summary>
        /// Get the dupes and add them to DupFiles
        /// </summary>
        /// <param name="cancel">Cancel search?</param>
        public async Task<bool> GetDupes(bool cancel = false)
        {
            try
            {

                _cancelled = cancel;
               
                if (cancel)
                {
                    return false;
                }

                var files = Enumerable.Empty<string>();

                var wildCardSplit = _wildcard.Split(';');

                foreach (var wildCard in wildCardSplit)
                {
                    var result = await Task.Run(() => SafeFileEnumerator.EnumerateFiles(_path, wildCard, _includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)).ConfigureAwait(false);

                    files = files.Concat(result);
                }

                OnFilesRetrieved(files.ToList().Count);

                var output = new List<DupeFile>();

                int processed = 0;

                await Task.Run(() =>
                {
                    foreach (var file in files)
                    {
                        // Try to catch this as soon as possible
                        if (_cancelled)
                        {
                            return;
                        }

                        var info = new FileInfo(file);

                        long fileSize = 0;

                        if (info.Exists)
                        {
                            fileSize = info.Length;
                        }
                        else
                        {
                            // This will handle long paths
                            FieldInfo fld = typeof(FileSystemInfo).GetField("FullPath", BindingFlags.Instance |
                                BindingFlags.NonPublic);
                            string fullPath = fld.GetValue(info).ToString();
                            WIN32_FIND_DATA findData;
                            fileSize = GetFileSize(fullPath, out findData);
                        }

                        var dupeFile = new DupeFile()
                        {

                            FileName = info.Name,
                            FilePath = info.DirectoryName,
                            FileSize = fileSize,
                            DupeMatches = new List<DupeFile>()
                        };

                        // Try to catch this as soon as possible
                        if (_cancelled)
                        {
                            return;
                        }

                        var foundItem = (from item in output where item.FileName == dupeFile.FileName && item.FileSize == dupeFile.FileSize select item).FirstOrDefault();

                        // Try to catch this as soon as possible
                        if (_cancelled)
                        {
                            return;
                        }

                        if (foundItem != null)
                        {
                            foundItem.DupeMatches.Add(dupeFile);
                        }
                        else
                        {
                            output.Add(dupeFile);
                        }

                        processed++;
                        if (processed % 10 == 0)
                        {
                            OnProcessChanged(processed);
                        }
                    }

                }).ConfigureAwait(false);

                OnProcessChanged(processed);

                DupeFiles = (from item in output
                             where item.DupeMatches.Count > 0
                             select item).ToList();

                return true;
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                return false;
            }
        }

        /// <summary>
        /// Return the value being passed in to the calling thread
        /// </summary>
        /// <param name="value">The value</param>
        private void OnProcessChanged(int value)
        {
            ProcessChanged?.Invoke(value);
        }

        /// <summary>
        /// Let the calling thread know that the fies have been retrieved
        /// </summary>
        private void OnFilesRetrieved(int value)
        {
            FilesRetrieved?.Invoke(value);
        }

        /// <summary>
        /// Get the file size for a file
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="findData">WIN32_FIND_DATA</param>
        /// <returns>long</returns>
        private long GetFileSize(string fileName, out WIN32_FIND_DATA findData)
        {
            long size = 0;
            IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
            IntPtr findHandle;

            findHandle = FindFirstFile(@"\\?\" + fileName, out findData);
            
            if (findHandle != INVALID_HANDLE_VALUE)
            {
                if ((findData.dwFileAttributes & FileAttributes.Directory) == 0)
                {
                    size = findData.nFileSizeLow + findData.nFileSizeHigh * 4294967296;
                }
            }

            return size;
        }
    }
}
