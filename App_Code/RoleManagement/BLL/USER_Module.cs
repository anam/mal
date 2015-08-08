using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class USER_Module
{
    public USER_Module()
    {
    }


    public USER_Module
        (
        int moduleID,
        string moduleName,
        string defaultURL,
        string addedBy,
        DateTime addedDate,
        string updatedBy,
        DateTime updatedDate,
        int rowStatusID

        )
    {
        this.ModuleID = moduleID;
        this.ModuleName = moduleName;
        this.DefaultURL = defaultURL;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
        this.RowStatusID = rowStatusID;

    }

    public int ModuleID
    {
        get;
        set;
    }

    public string ModuleName
    {
        get;
        set;
    }

    public string DefaultURL
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
}

