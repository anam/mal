using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class INV_IteamCategory
{
    public INV_IteamCategory()
    {
    }


    public INV_IteamCategory
        (
int  iteamCategoryID,
string  iteamCategoryName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate

        )

    {
this.IteamCategoryID = iteamCategoryID;
this.IteamCategoryName = iteamCategoryName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;

    }

    public int  IteamCategoryID
    {
        get ; 
        set  ;
    }

    public string  IteamCategoryName
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

}

