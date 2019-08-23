using Registers.Forms.LisanceService;
using System.Security.Cryptography;
using System;
using System.Management;
using System.ServiceModel;
using System.Text;

namespace Registers.Forms.Core
{
    public class Lisance
    {
        static BasicHttpBinding Bindig
        {
            get {
                return new BasicHttpBinding();
            }
        }
        static EndpointAddress Endpoint
        {
            get
            {
                return new EndpointAddress("http://localhost:60873/Lisens.asmx");

            }
        }
        static LisensSoapClient Client
        {
            get
            {
                return new LisensSoapClient(Bindig, Endpoint);
            }
        }
        public static bool LisenceContoll(string key)
        {
            LisansTaleb taleb = new LisansTaleb();
            taleb.Key = key;
            taleb.HDD = "";
            taleb.Tarix = DateTime.Now;
            var data = Client.LisansDogrulama(taleb);
            return data.DogurlulamaKodu == 1;


        }
        public static string HDDNuber()
        {
            ManagementObjectSearcher man = new ManagementObjectSearcher("SELECT * FROM win32_physicalmedia");
            var re = man.Get();
            string sn = "";
            foreach (var  item in re)
            {
               sn= item["SerialNumber"].ToString();
                break;
            }
            return sn;
        }
        public static string Text
        {
            get
            {
                return "22ef5081a6ed60eee3d7c5182fed35f9";
            }
        }
        public static string Hash(string mentin,string key)
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
    }
    
}
