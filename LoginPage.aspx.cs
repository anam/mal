using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Url.AbsoluteUri.Contains("mavrickit"))
        {
            Response.Redirect("http://www.cucbd.net/");
        }
        loadSession();
        if (!IsPostBack)
        {
            
            _userLogin();
        }
    }

    private void loadSession()
    {
        if (Request["UserName"] != null)
        {
            myLogin_Authenticate(this, new AuthenticateEventArgs());
        }
    }


    private void _userLogin()
    {
        /*if (Page.User.Identity.IsAuthenticated)
            Response.Redirect("~/default.aspx", false);
        else */ if ((Request.Browser.Cookies) && (Request.Cookies["userName"] != null))
        {
            HttpCookie MyCookie = Request.Cookies["userName"];

            MembershipUser user = Membership.GetUser(MyCookie.Value.ToString());
            if (user != null)
            {
                myLogin.UserName = user.UserName;
            }            
        }
    }

    protected void myLogin_Authenticate(object sender, AuthenticateEventArgs e)
    {   
        try
        {
            //lblLoginSession.Text = Session["Password"] != null ? Session["Password"].ToString()+"-":"";

            string UserName = (Request.QueryString["UserName"] != null ? (Request.QueryString["UserName"] != "" ? Request.QueryString["UserName"] : myLogin.UserName) : myLogin.UserName);
            string Password = (Request.QueryString["Password"] != null ? (Request.QueryString["Password"] != "" ? Request.QueryString["Password"] : myLogin.Password) : myLogin.Password);

            if (Membership.ValidateUser(UserName, Password))
            {
                e.Authenticated = true;
                Session["userID"] = Membership.GetUser(myLogin.UserName).ProviderUserKey.ToString();
                Session["Password"] = Password;
                Session["UserName"] = UserName;
                CheckBox RememberMe = (CheckBox)myLogin.FindControl("RememberMe");
                if (RememberMe.Checked)
                {
                    HttpCookie MyCookie = new HttpCookie("userName");
                    MyCookie.Value = myLogin.UserName;
                    MyCookie.Expires = DateTime.Now.AddDays(100);
                    Response.Cookies.Add(MyCookie);
                }
                else
                {
                    Request.Cookies.Clear();
                }

                //if (Session["LastPage"] == null  )
                //{
                //    FormsAuthentication.RedirectFromLoginPage(myLogin.UserName, RememberMe.Checked);
                //}
                //else if (Session["LastPage"].ToString().ToLower().Contains("loginpage.aspx"))
                //{
                //    FormsAuthentication.RedirectFromLoginPage(myLogin.UserName, RememberMe.Checked);
                //}
                //else
                //{
                //    try
                //    {
                //        Response.Redirect("http://software.cucwings.com" + Request.QueryString["LastPage"]);
                //    }
                //    catch (Exception ex)
                //    {
                        
                //    }
                //}
                FormsAuthentication.RedirectFromLoginPage(Session["UserName"].ToString(), RememberMe.Checked);
                //Response.Redirect("http://software.cucwings.com/cuc_webapplication/Default.aspx");
            }
            else
            {
                e.Authenticated = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void myLogin_LoginError(object sender, EventArgs e)
    {
        // Determine why the user could not login...        
        myLogin.FailureText = "Your login attempt was not successful. Please try again.";

        // Does there exist a User account for this user?
        MembershipUser usrInfo = Membership.GetUser(myLogin.UserName);
        if (usrInfo != null)
        {
            // Is this user locked out?
            if (usrInfo.IsLockedOut)
            {
                myLogin.FailureText = "Your account has been locked out because of too many invalid login attempts. Please contact with the Authority to have your account unlocked.";
            }
            else if (!usrInfo.IsApproved)
            {
                //myLogin.FailureText = "Your account has not yet been approved. You cannot login until an administrator has approved your account.";
                myLogin.FailureText = "You are not authorized person.";
            }
        }
    }
}