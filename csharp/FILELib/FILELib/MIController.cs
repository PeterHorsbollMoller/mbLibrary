using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace FILELib
{
    public class MIController
    {
        // Use a static var to store the list of selected filenames
        static string[] mselectedFiles;

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
    }
}
