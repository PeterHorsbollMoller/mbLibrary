using System;

namespace ConfigFile
{
    public class Configuration
    {
        public static string ReadKey(string fileName, string section, string key)
        {
            ReadWriteIniFile rwi = new ReadWriteIniFile(fileName);
            return rwi.ReadIniStr(section, key);
        }

        public static int ReadKeyInt(string fileName, string section, string key)
        {
            ReadWriteIniFile rwi = new ReadWriteIniFile(fileName);
            return rwi.ReadIniInt(section, key);
        }

        public static void WriteKey(string fileName, string section, string key, string value)
        {
            ReadWriteIniFile rwi = new ReadWriteIniFile(fileName);
            rwi.WriteIni(section, key, value);
        }

        public static void DeleteKey(string fileName, string section, string key)
        {
            ReadWriteIniFile rwi = new ReadWriteIniFile(fileName);
            rwi.DeleteData(section, key);
        }

        public static void DeleteSection(string fileName, string section)
        {
            ReadWriteIniFile rwi = new ReadWriteIniFile(fileName);
            rwi.DeleteData(section);
        }

    }
}
