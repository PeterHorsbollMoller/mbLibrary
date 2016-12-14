using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.Win32;

namespace SystemLib
{
    public class MIVersionDetect
    {
        public static string GetProductInfo(String strKey, int optionalMIVersion =0)
        {
            //Returns the value that belongs to the given keyname

            string registryKey = @"SOFTWARE\MapInfo\MapInfo\Professional";
            using (Microsoft.Win32.RegistryKey prokey = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                string result = "";

                var versions = from a in prokey.GetSubKeyNames()
                               let r = prokey.OpenSubKey(a)
                               let name = r.Name
                               let slashindex = name.LastIndexOf(@"\")
                               select new
                               {
                                   MapinfoVersion = Convert.ToInt32(name.Substring(slashindex + 1, name.Length - slashindex - 1))
                               };
                foreach (var item in versions)
                {
                    if (optionalMIVersion==0 || optionalMIVersion == item.MapinfoVersion)
                    {
                        string registryResultKey = registryKey + "\\" + Convert.ToString(item.MapinfoVersion);
                        Microsoft.Win32.RegistryKey provkey = Registry.LocalMachine.OpenSubKey(registryResultKey);
                        result = provkey.GetValue(strKey).ToString();
                    }
                }
                return result;
            }            
        }
    }

    public class MIClipboard
    {
             //<summary>
         /// This is called from MapBasic code
         /// to copy the text to the Windows clipboard
         /// </summary>
         /// <param name="text">The text value to copy to the clipboard</param>
         /// <returns>void</returns>
         public static void CopyTextToClipboard(string text)
         {
             Clipboard.SetData(System.Windows.Forms.DataFormats.StringFormat, text);

             //IDataObject iData = Clipboard.GetDataObject();
             //MessageBox.Show(string.Format("Read from clipboard: {0}",  (String)iData.GetData(DataFormats.Text))); 
         }

         /// This is called from MapBasic code
         /// to get the text from the Windows clipboard
         /// </summary>
         /// <returns>void</returns>
         public static string GetTextFromClipboard()
         {
             IDataObject iData = Clipboard.GetDataObject();
             return (String)iData.GetData(DataFormats.Text); 
         }

 
         //<summary>
         /// This is called from MapBasic code
         /// to copy the image to the Windows clipboard
         /// </summary>
         /// <param name="text">The file to copy to the clipboard</param>
         /// <returns>void</returns>
         public static void CopyImageToClipboard(string fileName)
         {
             Clipboard.SetImage(System.Drawing.Image.FromFile(fileName));
         }
    }

    public class MISystemInfo
    {
        //<summary>
        /// Get screen size pixels for the primary screen
        /// </summary>
        /// <returns>string: width x height in pixels, fx. 1920x1200</returns>
        public static string GetPrimaryScreenSize()
        {
            string size = "";
            size = string.Format("{0}x{1}", SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
            return size;
        }
    }
}
