using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Site2Column : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Url.AbsoluteUri.Contains("mavrickit"))
        {
            Response.Redirect("http://www.cucbd.net/");
        }


        if (!IsPostBack)
        {
            


            if (Page.User.Identity.IsAuthenticated)
            {
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
                        memberLoginName.FormatString = employee.EmployeeName.Length<=20?employee.EmployeeName:employee.EmployeeName.Substring(0,17)+"...";
                        Profile.card_id = employee.EmployeeID;
                        Profile.Name = employee.EmployeeName;
                        Profile.No = employee.EmployeeNo;
                        Profile.IsStudent = false;
                    }
                    else
                        memberLoginName.FormatString = Profile.UserName;
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
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
            string thisModule = slicedURL[noOfTotalSlash-2];
            string thisPage = slicedURL[noOfTotalSlash-1];
            if (thisPage.Contains('?'))
                thisPage = thisPage.Substring(0, thisPage.IndexOf('?'));
            USER_Page u_page = USER_PageManager.GetUSER_PageByPageTitle(thisPage);
            string headerMenu = string.Empty;
            string footerMenu = string.Empty;

            List<RoleWiseModule> r_modules = RoleWiseModuleManager.GETRoleWiseModulesByRoleID(roles[0]);

            r_modules = r_modules.FindAll(X => X.RowStatusID == (int)Enums.RowStatus.Active);

            headerMenu = "<ul class=\"sf-menu\">";
            foreach (RoleWiseModule r_module in r_modules)
            {
                if (r_module.DefaultURL.ToLower().Contains(thisModule.ToLower()) || (thisModule.Equals("Class") && r_module.ModuleID == 8) || (thisModule.Equals("Fees") && r_module.ModuleID == 1) || (thisModule.Equals("Common") && r_module.ModuleID == 2))
                //if (r_module.ModuleID == u_page.ModuleID || r_module.DefaultURL.ToLower().Contains(thisModule.ToLower()))
                {
                    headerMenu += "<li class=\"current\"><a href=\"../" + r_module.DefaultURL + "\"><span>" + r_module.ModuleName + "</span></a></li>";
                    _loadSideMenu(r_module, roles[0]);
                }
                //else if (thisModule.Equals("Class") && r_module.ModuleID==8)
                //{
                //    _loadSideMenu(r_module, roles[0]);
                //    headerMenu += "<li><a href=\"../" + r_module.DefaultURL + "\"><span>" + r_module.ModuleName + "</span></a></li>";
                //}
                else
                    headerMenu += "<li><a href=\"../" + r_module.DefaultURL + "\"><span>" + r_module.ModuleName + "</span></a></li>";
            }
            headerMenu += "</ul>";

            footerMenu = "<ul>";

            foreach (RoleWiseModule r_module in r_modules)
            {
                footerMenu += "<li><a href=\"../" + r_module.DefaultURL + "\">" + r_module.ModuleName + "</a></li>";
            }

            footerMenu += "</ul>";

            litHeaderMenu.Text = headerMenu;
            litFooterMenu.Text = footerMenu;
        }
        catch (Exception ex)
        {
            //litHeaderMenu.Text = ex.Message;
        }
    }

    private void _loadSideMenu(RoleWiseModule r_module, string roleID)
    {
        try
        {
            List<DisplayMenu> displayMenus = DisplayMenuManager.GetDisplayMenuByModuleNRole(r_module.ModuleID, roleID);
            List<DisplayMenu> rootMenus = new List<DisplayMenu>();
            rootMenus = displayMenus.FindAll(X => X.ParentMenuID == 0);
            displayMenus.RemoveAll(X => X.ParentMenuID == 0);

            string sideMenu = string.Empty;
            sideMenu = "<h3 class=\"sidebarHead\">" + r_module.ModuleName + "</h3>";
            sideMenu += "<div class=\"sideBarInner\">";
            sideMenu += "<ul><li><ul class=\"innernav\">";
            foreach (DisplayMenu rm in rootMenus)
            {
                if (rm.PageURL == null || rm.PageURL == "")
                {
                    sideMenu += "<li style=\"background: #e5e5e5;\"><a href=\"javascript:void(0);\">" + rm.MenuTitle + "</a>";
                }
                else
                {
                    sideMenu += "<li style=\"background: #e5e5e5;\"><a href=\"../" + rm.PageURL + "\">" + rm.MenuTitle + "</a>";
                }
                
                sideMenu += "<ul>";
                List<DisplayMenu> childMenus = displayMenus.FindAll(X => X.ParentMenuID == rm.MenuID);
                displayMenus.RemoveAll(X => X.ParentMenuID == rm.MenuID);
                foreach (DisplayMenu cm in childMenus)
                {
                    sideMenu += "<li style=\"background: #e5e5e5;\"><a href=\"../" + cm.PageURL + "\">" + cm.MenuTitle + "</a></li>";
                }
                sideMenu += "</ul></li>";
            }

            foreach (DisplayMenu dm in displayMenus)
            {
                sideMenu += "<li style=\"background: #e5e5e5;\"><a href=\"../" + dm.PageURL + "\">" + dm.MenuTitle + "</a></li>";
            }
            sideMenu += "</ul><li></ul></div>";
            litSideMenu.Text = sideMenu;
        }
        catch (Exception ex)
        {
            //litSideMenu.Text = ex.Message;
        }
    }
}
