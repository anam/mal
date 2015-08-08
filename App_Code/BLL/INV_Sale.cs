using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class INV_Sale
{
    public INV_Sale()
    {
    }


    public INV_Sale
        (
int  saleID,
int  campusID,
string  invoiceNo,
int  iteamID,
decimal  quantity,
int  warrenty,
decimal  unitPrice,
DateTime  saleDate,
string  remark,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate

        )

    {
this.SaleID = saleID;
this.CampusID = campusID;
this.InvoiceNo = invoiceNo;
this.IteamID = iteamID;
this.Quantity = quantity;
this.Warrenty = warrenty;
this.UnitPrice = unitPrice;
this.SaleDate = saleDate;
this.Remark = remark;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;

    }

    public int  SaleID
    {
        get ; 
        set  ;
    }

    public int  CampusID
    {
        get ; 
        set  ;
    }

    public string  InvoiceNo
    {
        get ; 
        set  ;
    }

    public int  IteamID
    {
        get ; 
        set  ;
    }

    public decimal  Quantity
    {
        get ; 
        set  ;
    }

    public int  Warrenty
    {
        get ; 
        set  ;
    }

    public decimal  UnitPrice
    {
        get ; 
        set  ;
    }

    public DateTime  SaleDate
    {
        get ; 
        set  ;
    }

    public string  Remark
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

