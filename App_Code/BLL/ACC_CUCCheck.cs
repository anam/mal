using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_CUCCheck
{
    public ACC_CUCCheck()
    {
    }


    public ACC_CUCCheck
        (
int  cUCCheckID,
string  cUCCheckName,
string  cUCCheckNo,
int  bankAccountID,
DateTime  checkDate,
int  paytoHeadID,
int  journalID,
decimal  amount,
string  extraField1,
string  extraField2,
string  extraField3,
string  extraField4,
string  extraField5,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate,
int  rowStatusID

        )

    {
this.CUCCheckID = cUCCheckID;
this.CUCCheckName = cUCCheckName;
this.CUCCheckNo = cUCCheckNo;
this.BankAccountID = bankAccountID;
this.CheckDate = checkDate;
this.PaytoHeadID = paytoHeadID;
this.JournalID = journalID;
this.Amount = amount;
this.ExtraField1 = extraField1;
this.ExtraField2 = extraField2;
this.ExtraField3 = extraField3;
this.ExtraField4 = extraField4;
this.ExtraField5 = extraField5;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;
this.RowStatusID = rowStatusID;

    }

    public int  CUCCheckID
    {
        get ; 
        set  ;
    }

    public string  CUCCheckName
    {
        get ; 
        set  ;
    }

    public string  CUCCheckNo
    {
        get ; 
        set  ;
    }

    public int  BankAccountID
    {
        get ; 
        set  ;
    }

    public DateTime  CheckDate
    {
        get ; 
        set  ;
    }

    public int  PaytoHeadID
    {
        get ; 
        set  ;
    }

    public int  JournalID
    {
        get ; 
        set  ;
    }

    public decimal  Amount
    {
        get ; 
        set  ;
    }

    public string  ExtraField1
    {
        get ; 
        set  ;
    }

    public string  ExtraField2
    {
        get ; 
        set  ;
    }

    public string  ExtraField3
    {
        get ; 
        set  ;
    }

    public string  ExtraField4
    {
        get ; 
        set  ;
    }

    public string  ExtraField5
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

