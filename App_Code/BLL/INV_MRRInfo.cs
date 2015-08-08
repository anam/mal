using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class INV_MRRInfo
{
    public INV_MRRInfo()
    {
    }


    public INV_MRRInfo
        (
int  mRRInfoID,
int  campusID,
int  mRRInfoMasterID,
string  mRRCode,
int  iteamID,
string  tagID,
decimal  quantity,
decimal  mRRAmount,
decimal  saleAmount,
DateTime  mRRDate,
int  storeID

        )

    {
this.MRRInfoID = mRRInfoID;
this.CampusID = campusID;
this.MRRInfoMasterID = mRRInfoMasterID;
this.MRRCode = mRRCode;
this.IteamID = iteamID;
this.TagID = tagID;
this.Quantity = quantity;
this.MRRAmount = mRRAmount;
this.SaleAmount = saleAmount;
this.MRRDate = mRRDate;
this.StoreID = storeID;

    }

    public int  MRRInfoID
    {
        get ; 
        set  ;
    }

    public int  CampusID
    {
        get ; 
        set  ;
    }

    public int  MRRInfoMasterID
    {
        get ; 
        set  ;
    }

    public string  MRRCode
    {
        get ; 
        set  ;
    }

    public int  IteamID
    {
        get ; 
        set  ;
    }

    public string  TagID
    {
        get ; 
        set  ;
    }

    public decimal  Quantity
    {
        get ; 
        set  ;
    }

    public decimal  MRRAmount
    {
        get ; 
        set  ;
    }

    public decimal  SaleAmount
    {
        get ; 
        set  ;
    }

    public DateTime  MRRDate
    {
        get ; 
        set  ;
    }

    public int  StoreID
    {
        get ; 
        set  ;
    }

}

