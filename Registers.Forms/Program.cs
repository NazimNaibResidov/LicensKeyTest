using Registers.Forms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registers.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyIni.SetValue("salam", "hebele");
            var k = MyIni.GetValue("salam");
            Guid g;
            bool gDurum = Guid.TryParse(k, out g);
            string ss = Lisance.HDDNuber();
            string ms = Lisance.Hash("NaibNazim", "main");
            if(string.IsNullOrEmpty(k)||!gDurum)
            {
                LisansForm lisansForm = new LisansForm();
                if (lisansForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
           
            Application.Run(new Form1());
        }
    }
}
