using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private string dosyayaYaz(string ip1)
        {
            //Siteye giriş yapanın ip adresini uzantısını belirttiğimiz txt dosyasına yazıyor.
            string dosya_yolu = @"C:\'''''DosyaUzantısı''''\metinbelgesi.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(ip1);
            sw.Flush();
            sw.Close();
            fs.Close();
            return ip1 ;
        }
        protected string ipNedir()
        {
            //İp Adresini öğreniyoruz.
            string ipaddress;
            ipaddress = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
            {
                ipaddress = Context.Request.ServerVariables["REMOTE_ADDR"];

            }
            return ipaddress;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            label2.Text = ipNedir();
            dosyayaYaz(ipNedir());
        }
    }
}