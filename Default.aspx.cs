using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                string name = Page.User.Identity.Name;
                _loadFooterMenu();
                LoginName memberLoginName = (LoginName)loginView.FindControl("memberLoginName");
                if (this.Page.User.IsInRole("Student"))
                {
                    STD_Student student = STD_StudentManager.GetHR_StudnetByStudentCode(Profile.UserName);
                    if (student != null)
                    {
                        memberLoginName.FormatString = student.StudentName.Length <= 20 ? student.StudentName : student.StudentName.Substring(0, 17) + "...";
                        Profile.card_id = student.StudentID;
                        Profile.Name = student.StudentName;
                        Profile.No = student.StudentCode;
                        
                        Profile.IsStudent = true;
                    }
                    else
                        memberLoginName.FormatString = Profile.UserName;
                }
                else
                {
                    HR_Employee employee = HR_EmployeeManager.GetHR_EmployeeByEmployeeNo(Profile.UserName);
                    if (employee != null)
                    {
                        memberLoginName.FormatString = employee.EmployeeName.Length <= 20 ? employee.EmployeeName : employee.EmployeeName.Substring(0, 17) + "...";
                        Profile.card_id = employee.EmployeeID;
                        Profile.Name = employee.EmployeeName;
                        Profile.No = employee.EmployeeNo;
                        Profile.IsStudent = false;
                    }
                    else
                        memberLoginName.FormatString = Profile.UserName;
                }

                

                try
                {

                    hfPassword.Value = Session["Password"].ToString();
                    hfUserName.Value = Session["UserName"].ToString();
                    

                    if (Request.QueryString["Redirected"] == null)
                    {
                        if (Session["LastPage"] != null)
                        {
                            string lastLoginPage = Session["LastPage"].ToString();
                            Session.Remove("LastPage");

                            if (!Session["LastPage"].ToString().Contains('?'))
                            {
                                Response.Redirect("http://software.cucwings.com" + lastLoginPage + "?Redirected=1");
                            }
                            else
                            {
                                Response.Redirect("http://software.cucwings.com" + lastLoginPage.Split('?')[0] + "?" + lastLoginPage.Split('?')[1] + "&Redirected=1");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Session["LastPage"] = Request.RawUrl;//.Split('/')[Request.RawUrl.Split('/').Length - 1];
                Response.Redirect("~/LoginPage.aspx?" + (hfPassword.Value != "" ? ("Password=" + hfPassword.Value) : "") + (hfUserName.Value != "" ? ("&UserName=" + hfUserName.Value) : "") + "&LastPage=" + Session["LastPage"].ToString());
            }
        }
    }

    private void _loadFooterMenu()
    {
        try
        {
            string[] roles = Roles.GetRolesForUser();
            int noOfTotalSlash = Request.RawUrl.ToString().Split('/').Length;


            string[] slicedURL = Request.RawUrl.ToString().Split('/');
            string thisModule = slicedURL[noOfTotalSlash-1];
            string headerMenu = string.Empty;
            //string footerMenu = string.Empty;

            List<RoleWiseModule> r_modules = RoleWiseModuleManager.GETRoleWiseModulesByRoleID(roles[0]);

            r_modules = r_modules.FindAll(X => X.RowStatusID == (int)Enums.RowStatus.Active);

            headerMenu = "<ul class=\"sf-menu\">";
            foreach (RoleWiseModule r_module in r_modules)
            {
                //if (r_module.DefaultURL.ToLower().Contains(thisModule.ToLower()) || (thisModule.Equals("Class") && r_module.ModuleID == 8) || (thisModule.Equals("Fees") && r_module.ModuleID == 1))
                //{
                //    headerMenu += "<li class=\"current\"><a href=\"../" + r_module.DefaultURL + "\"><span>" + r_module.ModuleName + "</span></a></li>";
                //    _loadSideMenu(r_module, roles[0]);
                //}
                ////else if (thisModule.Equals("Class") && r_module.ModuleID==8)
                ////{
                ////    _loadSideMenu(r_module, roles[0]);
                ////    headerMenu += "<li><a href=\"../" + r_module.DefaultURL + "\"><span>" + r_module.ModuleName + "</span></a></li>";
                ////}
                //else
                    headerMenu += "<li><a href=\"" + r_module.DefaultURL + "\"><span>" + r_module.ModuleName + "</span></a></li>";
            }
            headerMenu += "</ul>";

            //footerMenu = "<ul>";

            //foreach (RoleWiseModule r_module in r_modules)
            //{
            //    footerMenu += "<li><a href=\"" + r_module.DefaultURL + "\">" + r_module.ModuleName + "</a></li>";
            //}

            //footerMenu += "</ul>";

            litModules.Text = headerMenu;
            //litFooterMenu.Text = footerMenu;
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnChnagePassword_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipUser u = Membership.GetUser(Profile.UserName);

            if (u.ChangePassword(txtOldPassword.Text, txtNewPassword.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "message", "successMessage();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "message", "errorMessage();", true);
            }
        }
        catch (Exception ex)
        {
        }
    }
}
