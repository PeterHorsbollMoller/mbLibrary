using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ConfigFile
{
        // INIRead/Write
        public class ReadWriteIniFile
        {
            #region Private fields

            private int _len = 2048;
            private string _fileIni;
            
            #endregion

            #region Constructor
            public ReadWriteIniFile(string path)
            {
                _fileIni = path;
            }
            #endregion

            #region Importing WinAPI functions

            // INI WritePrivateProfileString
            [DllImport("KERNEL32.DLL")]
            private static extern uint WritePrivateProfileString(
                string lpAppName,
                string lpKeyName,
                string lpString,
                string lpFileName
            );

            // INI GetPrivateProfileString
            [DllImport("KERNEL32.DLL")]
            private static extern uint GetPrivateProfileString(
                string lpAppName,
                string lpKeyName,
                string lpDefault,
                StringBuilder lpReturnedString,
                uint nSize,
                string lpFileName
            );

            // INI GetPrivateProfileInt
            [DllImport("KERNEL32.DLL")]
            private static extern uint GetPrivateProfileInt(
                string lpAppName,
                string lpKeyName,
                int nDefault,
                string lpFileName
            );

            // GetPrivateProfileStringA
            [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringA")]
            private static extern uint GetPrivateProfileStringByByteArray(
                string lpAppName,
                string lpKeyName,
                string lpDefault,
                byte[] lpReturnedString,
                uint nSize,
                string lpFileName
            );

            #endregion

            #region Public Methods
            // INI WriteIni
            public void WriteIni(string section, string key, string val)
            {
                WritePrivateProfileString(
                    section,
                    key,
                    val,
                    _fileIni
                );
            }

            // INI ReadIniStr
            public string ReadIniStr(string section, string key)
            {
                StringBuilder sb = new StringBuilder(_len);

                GetPrivateProfileString(
                    section,
                    key,
                    null,
                    sb,
                    //(uint)sb.Length,
                    (uint)_len,
                    _fileIni
                );
                return sb.ToString();
            }

            // INI ReadIniInt
            //public string ReadIniInt(string section, string key)
            public int ReadIniInt(string section, string key)
            {
                uint resultValue =
                GetPrivateProfileInt(
                    section,
                    key,
                    0,
                    _fileIni
                );
                return (int)resultValue;
            }

            // 
            public string[] GetKeyNameArray(string section)
            {
                byte[] ary = new byte[_len];
                uint size =
                    GetPrivateProfileStringByByteArray(
                        section,
                        null,
                        "NULL",
                        ary,
                        (uint)ary.Length,
                        //_len,
                        _fileIni
                    );
                string result = Encoding.Default.GetString(ary, 0, (int)size - 1);
                return result.Split('\0');
            }

            // 
            public string[] AllGetSectionNameArray()
            {
                byte[] ary = new byte[_len];
                uint size =
                    GetPrivateProfileStringByByteArray(
                        null,
                        null,
                        "default",
                        ary,
                        (uint)ary.Length,
                        //_len,
                        _fileIni
                    );
                string result = Encoding.Default.GetString(ary, 0, (int)size - 1);
                return result.Split('\0');
            }

            // 
            public void DeleteData(string section, string key)
            {
                WritePrivateProfileString(section, key, null, _fileIni);
            }
            // 
            public void DeleteData(string section)
            {
                WritePrivateProfileString(section, null, null, _fileIni);
            }

            #endregion
        }
}
