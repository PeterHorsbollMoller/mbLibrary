using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
}
