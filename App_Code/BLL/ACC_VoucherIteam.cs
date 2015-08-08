using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_VoucherIteam
{
    public ACC_VoucherIteam()
    {
    }


    public ACC_VoucherIteam
        (
int  voucherIteamID,
string  voucherIteamName,
int  voucherID,
string  iteamCode,
string  description,
decimal  unitPrice,
decimal  quantity,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.VoucherIteamID = voucherIteamID;
this.VoucherIteamName = voucherIteamName;
this.VoucherID = voucherID;
this.IteamCode = iteamCode;
this.Description = description;
this.UnitPrice = unitPrice;
this.Quantity = quantity;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  VoucherIteamID
    {
        get ; 
        set  ;
    }

    public string  VoucherIteamName
    {
        get ; 
        set  ;
    }

    public int  VoucherID
    {
        get ; 
        set  ;
    }

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

    public decimal  UnitPrice
    {
        get ; 
        set  ;
    }

    public decimal  Quantity
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

    public DateTime  UpdateDate
    {
        get ; 
        set  ;
    }

    public int  RowStatusID
    {
        get ; 
        set  ;
    }

    public string RowStatus
    {
        get;
        set;
    }

}

