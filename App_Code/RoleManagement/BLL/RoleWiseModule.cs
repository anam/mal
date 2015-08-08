using System;
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

public class RoleWiseModule
{
    public RoleWiseModule()
    {
    }

    public RoleWiseModule
        (
        int roleWiseModuleID, 
        int moduleID, 
        string roleID, 
        string addedBy, 
        DateTime addedDate, 
        string updatedBy, 
        DateTime updatedDate, 
        int rowStatusID
        )
    {
        this.RoleWiseModuleID = roleWiseModuleID;
        this.ModuleID = moduleID;
        this.RoleID = roleID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
        this.RowStatusID = rowStatusID;
    }


    private int _roleWiseModuleID;
    public int RoleWiseModuleID
    {
        get { return _roleWiseModuleID; }
        set { _roleWiseModuleID = value; }
    }

    private int _moduleID;
    public int ModuleID
    {
        get { return _moduleID; }
        set { _moduleID = value; }
    }

    private string _roleID;
    public string RoleID
    {
        get { return _roleID; }
        set { _roleID = value; }
    }

    private string _addedBy;
    public string AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private string _updatedBy;
    public string UpdatedBy
    {
        get { return _updatedBy; }
        set { _updatedBy = value; }
    }

    private DateTime _updatedDate;
    public DateTime UpdatedDate
    {
        get { return _updatedDate; }
        set { _updatedDate = value; }
    }

    private int _rowStatusID;
    public int RowStatusID
    {
        get { return _rowStatusID; }
        set { _rowStatusID = value; }
    }

    #region Custom Property
    public USER_Module Module
    {
        get
        {
            USER_Module module = USER_ModuleManager.GetUSER_ModuleByModuleID(ModuleID);
            return module;
        }
    }
    public string ModuleName
    {
        get
        {
            
            if (this.Module != null)
                return this.Module.ModuleName;
            return string.Empty;

        }
    }
    public string DefaultURL
    {
        get
        {
            if (this.Module != null)
                return this.Module.DefaultURL;
            return string.Empty;
        }
    }
    #endregion
}
