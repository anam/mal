using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class INV_IteamSubCategory
{
    public INV_IteamSubCategory()
    {
    }


    public INV_IteamSubCategory
        (
int  iteamSubCategoryID,
string  iteamSubCategoryName,
int  iteamCategoryID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate

        )

    {
this.IteamSubCategoryID = iteamSubCategoryID;
this.IteamSubCategoryName = iteamSubCategoryName;
this.IteamCategoryID = iteamCategoryID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;

    }

    public int  IteamSubCategoryID
    {
        get ; 
        set  ;
    }

    public string  IteamSubCategoryName
    {
        get ; 
        set  ;
    }

    public int  IteamCategoryID
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

