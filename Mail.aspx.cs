using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

public partial class Mail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMailSend.Text = sendMail().ToString();
        //Response.Redirect("http://ifbdsoftware.islamicfinanceltd.com");
    }

    private bool sendMail()
    {
        try
        {
            System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();


            objMailMessage.IsBodyHtml = false;



            objMailMessage.From = new MailAddress("management@islamicfinancebd.com");


            objMailMessage.To.Add("anamuliut@mavrickit.com");
            objMailMessage.Subject = "Testing "+DateTime.Now.AddHours(+13);



            objMailMessage.Body = "Testing " + DateTime.Now.AddHours(+13);


            System.Net.Mail.SmtpClient objSMTPClient = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net", 25);

            objSMTPClient.Credentials = CredentialCache.DefaultNetworkCredentials;
            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            objSMTPClient.Send(objMailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}