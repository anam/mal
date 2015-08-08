using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Site2ColumnQuiz2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.User.Identity.IsAuthenticated)
                _loadFooterMenu();
        }
    }

    private void _loadFooterMenu()
    {
        try
        {
            string[] roles = Roles.GetRolesForUser();
            string[] slicedURL = Request.RawUrl.ToString().Split('/');
            string thisModule = slicedURL[2];
            string headerMenu = string.Empty;
            string footerMenu = string.Empty;

            List<RoleWiseModule> r_modules = RoleWiseModuleManager.GETRoleWiseModulesByRoleID(roles[0]);

            r_modules = r_modules.FindAll(X => X.RowStatusID == (int)Enums.RowStatus.Active);

            headerMenu = "<ul class=\"sf-menu\">";
            foreach (RoleWiseModule r_module in r_modules)
            {
                if (r_module.DefaultURL.ToLower().Contains(thisModule.ToLower()))
                {
                    headerMenu += "<li class=\"current\"><a href=\"../" + r_module.DefaultURL + "\"><span>" + r_module.ModuleName + "</span></a></li>";
                    _loadSideMenu(r_module, roles[0]);
                }
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
                sideMenu += "<li style=\"background: #e5e5e5;\"><a href=\"" + rm.PageURL + "\">" + rm.MenuTitle + "</a>";
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
        }
    }

    //private void _loadFooterMenu()
    //{
    //    try
    //    {
    //        string[] roles = Roles.GetRolesForUser();
    //        string[] slicedURL = Request.RawUrl.ToString().Split('/');
    //        string thisModule = slicedURL[2];
    //        string headerMenu = string.Empty;
    //        string footerMenu = string.Empty;

    //        if (Session["header" + roles[0]] == null || Session["footer" + roles[0]] == null)
    //        {
    //            List<RoleWiseModule> r_modules = new List<RoleWiseModule>();

    //            r_modules = RoleWiseModuleManager.GETRoleWiseModulesByRoleID(roles[0]);
    //            r_modules = r_modules.FindAll(X => X.RowStatusID == (int)Enums.RowStatus.Active);

    //            headerMenu = "<ul class=\"sf-menu\">";
    //            foreach (RoleWiseModule r_module in r_modules)
    //            {
    //                if (r_module.DefaultURL.ToLower().Contains(thisModule.ToLower()))
    //                {
    //                    headerMenu += "<li class=\"current\"><a href=\"../" + r_module.DefaultURL + "\"><span>" + r_module.ModuleName + "</span></a></li>";
    //                    Session["r_module"] = r_module;
    //                    _loadSideMenu(r_module, roles[0]);
    //                }
    //                else
    //                    headerMenu += "<li><a href=\"../" + r_module.DefaultURL + "\"><span>" + r_module.ModuleName + "</span></a></li>";
    //            }
    //            headerMenu += "</ul>";

    //            footerMenu = "<ul>";

    //            foreach (RoleWiseModule r_module in r_modules)
    //            {
    //                footerMenu += "<li><a href=\"../" + r_module.DefaultURL + "\">" + r_module.ModuleName + "</a></li>";
    //            }

    //            footerMenu += "</ul>";
    //            Session["header" + roles[0]] = headerMenu;
    //            Session["footer" + roles[0]] = footerMenu;
    //        }
    //        else
    //        {
    //            headerMenu = Session["header" + roles[0]].ToString();
    //            footerMenu = Session["footer" + roles[0]].ToString();
    //            _loadSideMenu((RoleWiseModule)Session["r_module"], roles[0]);
    //        }
    //        litHeaderMenu.Text = headerMenu;
    //        litFooterMenu.Text = footerMenu;
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //private void _loadSideMenu(RoleWiseModule r_module, string roleID)
    //{
    //    try
    //    {
    //        string sideMenu = string.Empty;
    //        if (Session["side" + roleID] == null)
    //        {
    //            List<DisplayMenu> displayMenus = DisplayMenuManager.GetDisplayMenuByModuleNRole(r_module.ModuleID, roleID);
    //            List<DisplayMenu> rootMenus = new List<DisplayMenu>();
    //            rootMenus = displayMenus.FindAll(X => X.ParentMenuID == 0);
    //            displayMenus.RemoveAll(X => X.ParentMenuID == 0);

    //            sideMenu = "<h3 class=\"sidebarHead\">" + r_module.ModuleName + "</h3>";
    //            sideMenu += "<div class=\"sideBarInner\">";
    //            sideMenu += "<ul><li><ul class=\"innernav\">";
    //            foreach (DisplayMenu rm in rootMenus)
    //            {
    //                sideMenu += "<li style=\"background: #e5e5e5;\"><a href=\"" + rm.PageURL + "\">" + rm.MenuTitle + "</a>";
    //                sideMenu += "<ul>";
    //                List<DisplayMenu> childMenus = displayMenus.FindAll(X => X.ParentMenuID == rm.MenuID);
    //                displayMenus.RemoveAll(X => X.ParentMenuID == rm.MenuID);
    //                foreach (DisplayMenu cm in childMenus)
    //                {
    //                    sideMenu += "<li style=\"background: #e5e5e5;\"><a href=\"../" + cm.PageURL + "\">" + cm.MenuTitle + "</a></li>";
    //                }
    //                sideMenu += "</ul></li>";
    //            }

    //            foreach (DisplayMenu dm in displayMenus)
    //            {
    //                sideMenu += "<li style=\"background: #e5e5e5;\"><a href=\"../" + dm.PageURL + "\">" + dm.MenuTitle + "</a></li>";
    //            }
    //            sideMenu += "</ul><li></ul></div>";

    //            Session["side" + roleID] = sideMenu;
    //        }
    //        else
    //            sideMenu = Session["side" + roleID].ToString();

    //        litSideMenu.Text = sideMenu;
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
}
