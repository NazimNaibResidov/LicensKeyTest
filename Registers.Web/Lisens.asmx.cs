using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

namespace Registers.Web
{
    /// <summary>
    /// Summary description for Lisens
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Lisens : System.Web.Services.WebService
    {
        public Lisens()
        {
            
        }

        [WebMethod]
        public LisansCavab LisansDogrulama(LisansTaleb taleb)
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            string hs = Hash(taleb.Key + taleb.HDD, Text);
            if (hs != taleb.Hash)
            {
                return new LisansCavab { Key = taleb.Key, HDD = taleb.HDD, Tarix = DateTime.Now, CheckedCode = 0 };
            }
            LisansCavab cavab = new LisansCavab();
            cavab.Key = taleb.Key;
            cavab.HDD = taleb.HDD;
            cavab.CheckedCode = 1;

            return cavab;
        }
        public static string Text
        {
            get
            {
                return "22ef5081a6ed60eee3d7c5182fed35f9";
            }
        }
        public static string Hash(string mentin, string key)
        {
            HMACMD5 md = new HMACMD5(Encoding.UTF8.GetBytes(key));
            byte[] buffer = Encoding.UTF8.GetBytes(mentin);
            byte[] hash = md.ComputeHash(buffer);
            string res = string.Empty;
            foreach (byte item in hash)
            {
                res += item.ToString("x2");
            }
            return res;

        }
        public class LisansTaleb
        {
            public LisansTaleb()
            {
                Tarix = new DateTime();
            }

            public string Key { get; set; }
            public string HDD { get; set; }
            public string Hash { get; set; }
            public DateTime Tarix { get; set; }
        }
        }
        public class LisansCavab
        {
            public LisansCavab()
            {
                Tarix = new DateTime();
            }
            public int CheckedCode { get; set; }
            public string Key { get; set; }
            public string HDD { get; set; }
            public DateTime Tarix { get; set; }
            public string Hash { get; set; } 

        
    }
}
