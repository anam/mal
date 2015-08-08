using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

public partial class ForgetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser(txtUserName.Text);
        try
        {
            lblPassword.Text = "Your password has sent to the Dr. Anisur Rahman Khan. Please contact with him to get your password.";
            MembershipUser requestedUser = Membership.GetUser(txtUserName.Text);


            MailSend.send("Requested person(" + requestedUser.UserName + ") email: " + requestedUser.Email + "<br/>Password:" + Membership.Provider.GetPassword(txtUserName.Text, txtAnswer.Text), Membership.GetUser("02120079").Email, "Password Recovery of CUC");
            panForgetPassword.Visible = false;
            panPassword.Visible = true;
            panError.Visible = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            panError.Visible = true;
        }
    }

    
}