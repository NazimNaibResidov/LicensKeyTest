using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Registers.Forms.Core
{
   public class MyIni
    {
        private static string fileName = "";
        private static string path = "";
        public MyIni()
        {

            
            path = Path.GetDirectoryName(Path.Combine(Assembly.GetExecutingAssembly().Location, fileName));
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
        [DllImport("kernel32")]
        static extern long GetPrivateProfileString(string section, string key, string Default, StringBuilder retVal, int size, string FilePath);
        [DllImport("kernel32")]
        static extern long WritePrivateProfileString(string section, string key, string value, string filePath);
        public static string GetValue(string key)
        {
            StringBuilder @string = new StringBuilder();
            GetPrivateProfileString("", key, "", @string, 255, path);
            return @string.ToString();
        }
        public static void SetValue(string key,string value)
        {
            WritePrivateProfileString("",key, value,path);
           // return "";
        }

    }
}
