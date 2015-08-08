using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class USER_Page
{
    public USER_Page()
    {
    }


    public USER_Page
        (
int  pageID,
string  pageTitle,
string  pageURL,
int  moduleID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate,
int  rowStatusID

        )

    {
this.PageID = pageID;
this.PageTitle = pageTitle;
this.PageURL = pageURL;
this.ModuleID = moduleID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;
this.RowStatusID = rowStatusID;

    }

    public int  PageID
    {
        get ; 
        set  ;
    }

    public string  PageTitle
    {
        get ; 
        set  ;
    }

    public string  PageURL
    {
        get ; 
        set  ;
    }

    public int  ModuleID
    {
        get ; 
        set  ;
    }

    public string  AddedBy
    {
        get ; 
        set  ;
    }

    public DateTime  AddedDate
    {
        get ; 
        set  ;
    }

    public string  UpdatedBy
    {
        get ; 
        set  ;
    }

    public DateTime  UpdatedDate
    {
        get ; 
        set  ;
    }

    public int  RowStatusID
    {
        get ; 
        set  ;
    }

}

