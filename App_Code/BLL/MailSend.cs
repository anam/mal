using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for SendMail
/// </summary>
public class MailSend
{
    public MailSend()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static public void send(string msg, string mailTo, string subject)
    {

        try
        {

            System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();
            objMailMessage.From = new MailAddress("anamuliut@gmail.com", "anamuliut@gmail.com");

            objMailMessage.To.Add(mailTo);

            objMailMessage.CC.Add(new MailAddress("anamuliut@gmail.com","Password Recovary"));
            

            objMailMessage.Subject = subject;

            objMailMessage.Body = msg;
            objMailMessage.IsBodyHtml = true;
            System.Net.Mail.SmtpClient objSMTPClient = new System.Net.Mail.SmtpClient("sg2nlvphout-v01.shr.prod.sin2.secureserver.net", 25);

            objSMTPClient.Credentials = CredentialCache.DefaultNetworkCredentials;
            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            objSMTPClient.Send(objMailMessage);

            
        }
        catch (Exception ex)
        {
            
        }

        
    }
}