using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_OpeningBalance
{
    public ACC_OpeningBalance()
    {
    }


    public ACC_OpeningBalance
        (
int  openingBalanceID,
string  openingBalanceName,
decimal  amount,
bool  isUsed,
int  headID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.OpeningBalanceID = openingBalanceID;
this.OpeningBalanceName = openingBalanceName;
this.Amount = amount;
this.IsUsed = isUsed;
this.HeadID = headID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  OpeningBalanceID
    {
        get ; 
        set  ;
    }

    public string  OpeningBalanceName
    {
        get ; 
        set  ;
    }

    public decimal  Amount
    {
        get ; 
        set  ;
    }

    public bool  IsUsed
    {
        get ; 
        set  ;
    }

    public int  HeadID
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

}

