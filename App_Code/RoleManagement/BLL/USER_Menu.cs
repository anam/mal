using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class USER_Menu
{
    public USER_Menu()
    {
    }


    public USER_Menu
        (
        int menuID,
        int ModuleID,
        int pageID,
        string menuTitle,
        int ParentMenuID,
        string addedBy,
        DateTime addedDate,
        string updatedBy,
        DateTime updatedDate,
        int rowStatusID

        )
    {
        this.MenuID = menuID;
        this.ModuleID = ModuleID;
        this.PageID = pageID;
        this.MenuTitle = menuTitle;
        this.ParentMenuID = ParentMenuID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
        this.RowStatusID = rowStatusID;

    }

    public int MenuID
    {
        get;
        set;
    }

    public int ModuleID
    {
        get;
        set;
    }

    public int PageID
    {
        get;
        set;
    }

    public string MenuTitle
    {
        get;
        set;
    }

    public int ParentMenuID
    {
        get;
        set;
    }

    public string AddedBy
    {
        get;
        set;
    }

    public DateTime AddedDate
    {
        get;
        set;
    }

    public string UpdatedBy
    {
        get;
        set;
    }

    public DateTime UpdatedDate
    {
        get;
        set;
    }

    public int RowStatusID
    {
        get;
        set;
    }

    #region Custom Property
    public string ParentMenuTitle
    {
        get
        {
            USER_Menu userMenu = USER_MenuManager.GetUSER_MenuByMenuID(MenuID);
            if (userMenu != null)
                return userMenu.MenuTitle;
            return "NA";
        }
    }

    public string RowStatus
    {
        get
        {
            if (RowStatusID > 0)
            {
                return RowStatusID == 1 ? "Active" : "Deleted";
            }
            return "NA";
        }
    }
    #endregion
}

public class DisplayMenu
{
    public DisplayMenu()
    {
    }

    public DisplayMenu(int menuID,int parentMenuID, string menuTitle, string pageTitle, string pageURL, int moduleID)
    {
        this.MenuID = menuID;
        this.ParentMenuID = parentMenuID;
        this.MenuTitle = menuTitle;
        this.PageTitle = pageTitle;
        this.PageURL = pageURL;
        this.ModuleID = moduleID;
    }

    public int MenuID { get; set; }
    public string MenuTitle { get; set; }
    public string PageTitle { get; set; }
    public string PageURL { get; set; }
    public int ModuleID { get; set; }
    public int ParentMenuID { get; set; }
}

