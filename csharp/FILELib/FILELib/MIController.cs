using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace FILELib
{
    public class Files
    {
        // Use a static var to store the list of selected filenames
        static string[] mselectedFiles;
        static List<string> _mfoundFiles = new List<string>();

        //<summary>
        /// This is called from MapBasic code
        /// to show a Browse for Folders dialog
        /// </summary>
        /// <param name="startFolder">The initial folder selected</param>
        /// <returns>string</returns>
        public static string BrowseForFolder(string description, string folder)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = description;
            dlg.SelectedPath = folder;
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
                return dlg.SelectedPath;
            else
                return "";
        }

        //<summary>
        /// Call this method to let the user choose multiple files.
        /// </summary>
        /// <param name="startFolder">The initial folder selected</param>
        /// <param name="fileTypes">Filetype filter, available in the filetype list of the dialog
        /// Should be in this form 
        /// "Text Files (*.txt)|*.txt" 
        /// or "Tables (*.tab)|*.tab|Workspaces (*.wor)|*.wor" 
        /// for multiple filters
        /// or MapInfo files (*.tab,*.wor)|*.tab;*.wor"
        /// for seing multiple filetypes at a time</param>
        /// <returns>integer, number of files selected -- might be zero</returns>
        public static int OpenFilesDlg(string title, string startFolder, string fileTypes)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Title = title;

            if (startFolder != null && startFolder.Length > 0)
            {
                dlg.InitialDirectory = startFolder;
            }
            if (fileTypes != null && fileTypes.Length > 0)
            {
                dlg.Filter = fileTypes;
            }

            DialogResult dr = dlg.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return 0;
            }
            mselectedFiles = dlg.FileNames;
            if (mselectedFiles == null || mselectedFiles.Length == 0)
            {
                return 0;
            }

            return mselectedFiles.Length;
        }

        //<summary>
        /// Call this method AFTER calling OpenFilesDlg,
        /// to retrieve one of the filenames the user selected.
        /// </summary>
        /// <param name="file">File number asking for</param>
        /// <returns>sting, the file that was asked for -- might be ""</returns>
        public static string GetOpenFilesDlgFileName(int file)
        {
            if (mselectedFiles == null || mselectedFiles.Length == 0)
            {
                return "";
            }
            if (mselectedFiles.Length < (file - 1))
            {
                //asking for a file that not was selected
                return "";
            }

            return mselectedFiles[(file - 1)];
        }

        //<summary>
        /// Call this method AFTER calling OpenFilesDlg,
        /// to retrieve ALL of the filenames the user selected.
        /// </summary>
        /// <param name="files">Array to copy all the file names to</param>
        /// <returns>int, the length of the array</returns>
        public static int GetOpenFilesDlgFileNames(string[] files)
        {
            if (mselectedFiles == null || mselectedFiles.Length == 0)
            {
                return 0;
            }

            int count = 0;
            foreach (string text in mselectedFiles)
            {
                files[count] = text;
                count++;
            }
            return files.Length;
        }

        //<summary>
        /// </summary>
        /// <param name="filePath">File to copy</param>
        /// <returns>nthing</returns>
        public static void CopyFile(string srcFilePath, string dstFilePath)
        {
            System.IO.File.Copy(srcFilePath, dstFilePath, true);
        }

        //<summary>
        /// </summary>
        /// <param name="filePath">File to delete</param>
        /// <returns>nthing</returns>
        public static void DeleteFile(string filePath)
        {
            System.IO.File.Delete(filePath);
        }

        //<summary>
        /// </summary>
        /// <param name="filePath">Folder to create</param>
        /// <returns>nthing</returns>
        public static void CreateFolder(string folderPath)
        {
            System.IO.Directory.CreateDirectory(folderPath);
        }

        //<summary>
        /// </summary>
        /// <param name="filePath">Folder to delete</param>
        /// <returns>nthing</returns>
        public static void DeleteFolder(string folderPath)
        {
            System.IO.Directory.Delete(folderPath, true);
        }


        /// <summary>This will search the folder passed (but not the sub folders) for the files matching the mask</summary>
        /// <param name="folderPath">Folder to search</param>
        /// <param name="mask">Files to search for, use *.* to find all, *.tab to find tab files only</param>
        /// <returns>Int, the number of files found</returns>
        public static int FindFilesInFolder(string folderPath, string mask)
        {
            _mfoundFiles.Clear();

            if (string.IsNullOrWhiteSpace(mask))
                mask = "*.*";

            foreach (string file in Directory.EnumerateFiles(folderPath, mask, SearchOption.TopDirectoryOnly))
            {
                _mfoundFiles.Add(file);
            }

            return _mfoundFiles.Count;
        }

        /// <summary>This will search the folder passed and all sub folders for the files matching the mask</summary>
        /// <param name="folderPath">Folder to search</param>
        /// <param name="mask">Files to search for, use *.* to find all, *.tab to find tab files only</param>
        /// <returns>Int, the number of files found</returns>
        public static int FindFilesInFolders(string folderPath, string mask)
        {
            _mfoundFiles.Clear();

            if (string.IsNullOrWhiteSpace(mask))
                mask = "*.*";

            foreach (string file in Directory.EnumerateFiles(folderPath, mask, SearchOption.AllDirectories))
            {
                _mfoundFiles.Add(file);
            }

            return _mfoundFiles.Count;
        }


        /// <summary>Call this method AFTER calling OpenFilesDlg, to retrieve one of the filenames the user selected.</summary>
        /// <param name="file">File number asking for, 1 is the first file in the list</param>
        /// <returns>string, the file that was asked for -- might be ""</returns>
        public static string GetFindFilesFileName(int file)
        {
            if (_mfoundFiles == null || _mfoundFiles.Count == 0)
            {
                return "";
            }
            if (_mfoundFiles.Count < (file - 1))
            {
                //asking for a file that not was selected
                return "";
            }

            return _mfoundFiles[(file - 1)];
        }

        //<summary>
        /// Call this method AFTER calling FindFilesInFolder,
        /// to retrieve ALL of the filenames the user selected.
        /// </summary>
        /// <param name="files">Array to copy all the file names to</param>
        /// <returns>int, the length of the array</returns>
        public static int GetFindFilesFileNames(string[] files)
        {
            if (_mfoundFiles == null || _mfoundFiles.Count == 0)
            {
                return 0;
            }

            int count = 0;
            foreach (string file in _mfoundFiles)
            {
                files[count] = file;
                count++;
            }
            return files.Length;
        }

        //<summary>
        /// Call this method to write a (long) string to a file
        /// </summary>
        /// <param name="file">string, the file (full path) to write the content to</param>
        /// <param name="content">string, the content/text to write to the file</param>
        /// <returns>void</returns>
        public static void WriteAllTextToFile(string file, string content)
        {
            File.WriteAllText(file, content);
        }

        //<summary>
        /// Call this method to write a (long) string to a file
        /// </summary>
        /// <param name="file">string, the file (full path) to write the content to</param>
        /// <param name="content">string, the content/text to write to the file</param>
        /// <returns>void</returns>
        public static void AppendAllTextToFile(string file, string content)
        {
            File.AppendAllText(file, content);
        }
  
    }

    //Old, only left for backwards compatability
    public class MIController
    {
         //<summary>
        /// This is called from MapBasic code
        /// to show a Browse for Folders dialog
        /// </summary>
        /// <param name="startFolder">The initial folder selected</param>
        /// <returns>string</returns>
        public static string BrowseForFolder(string description, string folder)
        {
            return Files.BrowseForFolder(description, folder);
        }

        //<summary>
        /// Call this method to let the user choose multiple files.
        /// </summary>
        /// <param name="startFolder">The initial folder selected</param>
        /// <param name="fileTypes">Filetype filter, available in the filetype list of the dialog
        /// Should be in this form 
        /// "Text Files (*.txt)|*.txt" 
        /// or "Tables (*.tab)|*.tab|Workspaces (*.wor)|*.wor" 
        /// for multiple filters
        /// or MapInfo files (*.tab,*.wor)|*.tab;*.wor"
        /// for seing multiple filetypes at a time</param>
        /// <returns>integer, number of files selected -- might be zero</returns>
        public static int OpenFilesDlg(string title, string startFolder, string fileTypes)
        {
            return Files.OpenFilesDlg(title, startFolder, fileTypes);
        }

        //<summary>
        /// Call this method AFTER calling OpenFilesDlg,
        /// to retrieve one of the filenames the user selected.
        /// </summary>
        /// <param name="file">File number asking for</param>
        /// <returns>sting, the file that was asked for -- might be ""</returns>
        public static string GetOpenFilesDlgFileName(int file)
        {
            return Files.GetOpenFilesDlgFileName(file);
        }

        //<summary>
        /// Call this method AFTER calling OpenFilesDlg,
        /// to retrieve ALL of the filenames the user selected.
        /// </summary>
        /// <param name="files">Array to copy all the file names to</param>
        /// <returns>int, the length of the array</returns>
        public static int GetOpenFilesDlgFileNames(string[] files)
        {
            return Files.GetOpenFilesDlgFileNames(files);
        }

        //<summary>
        /// </summary>
        /// <param name="filePath">File to copy</param>
        /// <returns>nthing</returns>
        public static void CopyFile(string srcFilePath, string dstFilePath)
        {
            Files.CopyFile(srcFilePath, dstFilePath);
        }

        //<summary>
        /// </summary>
        /// <param name="filePath">File to delete</param>
        /// <returns>nthing</returns>
        public static void DeleteFile(string filePath)
        {
            Files.DeleteFile(filePath);
        }

        //<summary>
        /// </summary>
        /// <param name="filePath">Folder to create</param>
        /// <returns>nthing</returns>
        public static void CreateFolder(string folderPath)
        {
            Files.CreateFolder(folderPath);
        }

        //<summary>
        /// </summary>
        /// <param name="filePath">Folder to delete</param>
        /// <returns>nthing</returns>
        public static void DeleteFolder(string folderPath)
        {
            Files.DeleteFolder(folderPath);
        }


        /// <summary>This will search the folder passed (but not the sub folders) for the files matching the mask</summary>
        /// <param name="folderPath">Folder to search</param>
        /// <param name="mask">Files to search for, use *.* to find all, *.tab to find tab files only</param>
        /// <returns>Int, the number of files found</returns>
        public static int FindFilesInFolder(string folderPath, string mask)
        {
            return FindFilesInFolder(folderPath, mask);
        }

        /// <summary>This will search the folder passed and all sub folders for the files matching the mask</summary>
        /// <param name="folderPath">Folder to search</param>
        /// <param name="mask">Files to search for, use *.* to find all, *.tab to find tab files only</param>
        /// <returns>Int, the number of files found</returns>
        public static int FindFilesInFolders(string folderPath, string mask)
        {
            return Files.FindFilesInFolders(folderPath, mask);
        }


        /// <summary>Call this method AFTER calling OpenFilesDlg, to retrieve one of the filenames the user selected.</summary>
        /// <param name="file">File number asking for, 1 is the first file in the list</param>
        /// <returns>string, the file that was asked for -- might be ""</returns>
        public static string GetFindFilesFileName(int file)
        {
            return Files.GetFindFilesFileName(file);
        }

        //<summary>
        /// Call this method AFTER calling FindFilesInFolder,
        /// to retrieve ALL of the filenames the user selected.
        /// </summary>
        /// <param name="files">Array to copy all the file names to</param>
        /// <returns>int, the length of the array</returns>
        public static int GetFindFilesFileNames(string[] files)
        {
            return Files.GetFindFilesFileNames(files);
        }

    }
    }
