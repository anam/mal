using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class INV_Iteam
{
    public INV_Iteam()
    {
    }


    public INV_Iteam
        (
int  iteamID,
int  campusID,
string  iteamCode,
string  description,
int  iteamSubCategoryID,
decimal  price,
decimal  quantity,
string  unit,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate

        )

    {
this.IteamID = iteamID;
this.CampusID = campusID;
this.IteamCode = iteamCode;
this.Description = description;
this.IteamSubCategoryID = iteamSubCategoryID;
this.Price = price;
this.Quantity = quantity;
this.Unit = unit;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;

    }

    public int  IteamID
    {
        get ; 
        set  ;
    }

    public int  CampusID
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// Status:In Store, Issued, Sold
    /// </summary>
    public string  IteamCode
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    public int  IteamSubCategoryID
    {
        get ; 
        set  ;
    }
    public int IteamCategoryID
    {
        get;
        set;
    }

    public decimal  Price
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// Sale Price
    /// </summary>
    public decimal  Quantity
    {
        get ; 
        set  ;
    }

    public string  Unit
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

