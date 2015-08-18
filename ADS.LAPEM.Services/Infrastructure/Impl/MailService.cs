using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities;
using System.Net.Mail;
using System.Web.Configuration;

namespace ADS.LAPEM.Services.Infrastructure.Impl
{
    public class MailService 
    {
        private string FromAddress;
        private string strSmtpClient;
        private string UserID;
        private string Password;
        private string ReplyTo;
        private string SMTPPort;
        private Boolean bEnableSSL;

        //private void InitMail()
        //{
        //    FromAddress = WebConfigurationManager.AppSettings["FromAddress"].ToString();
        //    //strSmtpClient = System.Configuration.ConfigurationManager.AppSettings.Get("SmtpClient");
        //    strSmtpClient = WebConfigurationManager.AppSettings["SmtpClient"].ToString();
        //    UserID = WebConfigurationManager.AppSettings["User"];
        //    Password = WebConfigurationManager.AppSettings["Password"];
        //    SMTPPort = WebConfigurationManager.AppSettings["SMTPPort"];
        //    if (WebConfigurationManager.AppSettings["EnableSSL"].ToUpper() == "YES")
        //    {
        //        bEnableSSL = true;
        //    }
        //    else
        //    {
        //        bEnableSSL = false;
        //    }
        //}

        //public void SendMail(string messageId, string toAddress, string[] param)
        //{
        //    string subject = "";
        //    string body = "";
        //    XmlNode mailNode = default(XmlNode);
        //    int n = 0;

        //    if ((System.IO.File.Exists(mailFormatxml)))
        //    {
        //        xdoc.Load(mailFormatxml);
        //        mailNode = xdoc.SelectSingleNode("MailFormats/MailFormat[@Id='" + messageId + "']");
        //        subject = mailNode.SelectSingleNode("Subject").InnerText;
        //        body = mailNode.SelectSingleNode("Body").InnerText;
        //        if ((param == null))
        //        {
        //            throw new Exception("Mail format file not found.");
        //        }
        //        else
        //        {
        //            for (n = 0; n <= param.length - 1;n++) 
        //            { 
        //                body="body.Replace(n.ToString()" + "?", param[n]); 
        //                subject="subject.Replace(n.ToString()" + "?", param[n]); } } 
        //                initmail(); dynamic 
        //                mailmessage="new" mailmessage(); 
        //                mailmessage.from="new" 
        //                mailaddress(fromaddress);="" 
        //                mailmessage.to.add(strtoaddress);="" 
        //                mailmessage.subject="subject;" 
        //                mailmessage.isbodyhtml="true;" 
        //                mailmessage.body="body;" 
        //                mailmessage.replyto="new" 
        //                mailaddress(fromaddress);="" 
        //                smtpclient="" 
        //                smtpclient="new" smtpclient();="" 
        //                smtpclient.host="strSmtpClient;" 
        //                smtpclient.enablessl="bEnableSSL;" 
        //                smtpclient.port="Convert.ToInt32(SMTPPort);" 
        //                smtpclient.credentials="new" system.net.networkcredential(userid,="" password);="" 
        //                try 
        //                {
        //                    smtpclient.send(mailmessage);
        //                }
        //                catch(smtpfailedrecipientsexception ex)
        //                {

        //                }
        //    }
                            


        //public bool EnviarCorreo(Calibracion calibracion, List<string> correos)
        //{
        //    MailMessage email = new MailMessage();

            
        //}

    }

}
