using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class RoleWiseModuleManager
{
	public RoleWiseModuleManager()
	{
	}

    public static List<RoleWiseModule> GetAllRoleWiseModules()
    {
        List<RoleWiseModule> roleWiseModules = new List<RoleWiseModule>();
        SqlRoleWiseModuleProvider sqlRoleWiseModuleProvider = new SqlRoleWiseModuleProvider();
        roleWiseModules = sqlRoleWiseModuleProvider.GetAllRoleWiseModules();
        return roleWiseModules;
    }

    public static List<RoleWiseModule> GETRoleWiseModulesByRoleID(string roleID)
    {
        SqlRoleWiseModuleProvider sqlRoleWiseModuleProvider = new SqlRoleWiseModuleProvider();
        return sqlRoleWiseModuleProvider.GETRoleWiseModulesByRoleID(roleID);
    }

    public static RoleWiseModule GetRoleWiseModuleByID(int id)
    {
        RoleWiseModule roleWiseModule = new RoleWiseModule();
        SqlRoleWiseModuleProvider sqlRoleWiseModuleProvider = new SqlRoleWiseModuleProvider();
        roleWiseModule = sqlRoleWiseModuleProvider.GetRoleWiseModuleByID(id);
        return roleWiseModule;
    }


    public static int InsertRoleWiseModule(RoleWiseModule roleWiseModule)
    {
        SqlRoleWiseModuleProvider sqlRoleWiseModuleProvider = new SqlRoleWiseModuleProvider();
        return sqlRoleWiseModuleProvider.InsertRoleWiseModule(roleWiseModule);
    }


    public static bool UpdateRoleWiseModule(RoleWiseModule roleWiseModule)
    {
        SqlRoleWiseModuleProvider sqlRoleWiseModuleProvider = new SqlRoleWiseModuleProvider();
        return sqlRoleWiseModuleProvider.UpdateRoleWiseModule(roleWiseModule);
    }

    public static bool DeleteRoleWiseModule(int roleWiseModuleID)
    {
        SqlRoleWiseModuleProvider sqlRoleWiseModuleProvider = new SqlRoleWiseModuleProvider();
        return sqlRoleWiseModuleProvider.DeleteRoleWiseModule(roleWiseModuleID);
    }
}
