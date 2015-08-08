using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class INV_IssueMaster
{
    public INV_IssueMaster()
    {
    }


    public INV_IssueMaster
        (
int  issueMasterID,
string  issueMasterName,
int  campusID,
int  storeID,
string  productionCode,
decimal  quantity,
DateTime  issueDate,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate

        )

    {
this.IssueMasterID = issueMasterID;
this.IssueMasterName = issueMasterName;
this.CampusID = campusID;
this.StoreID = storeID;
this.ProductionCode = productionCode;
this.Quantity = quantity;
this.IssueDate = issueDate;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;

    }

    public int  IssueMasterID
    {
        get ; 
        set  ;
    }

    public string  IssueMasterName
    {
        get ; 
        set  ;
    }

    public int  CampusID
    {
        get ; 
        set  ;
    }

    public int  StoreID
    {
        get ; 
        set  ;
    }

    public string  ProductionCode
    {
        get ; 
        set  ;
    }

    public decimal  Quantity
    {
        get ; 
        set  ;
    }

    public DateTime  IssueDate
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

