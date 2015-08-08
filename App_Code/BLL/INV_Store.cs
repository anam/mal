using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class INV_Store
{
    public INV_Store()
    {
    }


    public INV_Store
        (
int  storeID,
string  storeName,
int  campusID,
string  description,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate

        )

    {
this.StoreID = storeID;
this.StoreName = storeName;
this.CampusID = campusID;
this.Description = description;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;

    }

    public int  StoreID
    {
        get ; 
        set  ;
    }

    public string  StoreName
    {
        get ; 
        set  ;
    }

    public int  CampusID
    {
        get ; 
        set  ;
    }

    public string  Description
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

