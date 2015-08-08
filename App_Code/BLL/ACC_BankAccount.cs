using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_BankAccount
{
    public ACC_BankAccount()
    {
    }


    public ACC_BankAccount
        (
int  bankAcountID,
string  bankAccountName,
string  accountNo,
int  bankID,
string  branchNOtherDetails,
string  extraField1,
string  extraField2,
string  extraField3,
string  extraField4,
string  extraField5,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.BankAcountID = bankAcountID;
this.BankAccountName = bankAccountName;
this.AccountNo = accountNo;
this.BankID = bankID;
this.BranchNOtherDetails = branchNOtherDetails;
this.ExtraField1 = extraField1;
this.ExtraField2 = extraField2;
this.ExtraField3 = extraField3;
this.ExtraField4 = extraField4;
this.ExtraField5 = extraField5;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  BankAcountID
    {
        get ; 
        set  ;
    }

    public string  BankAccountName
    {
        get ; 
        set  ;
    }

    public string  AccountNo
    {
        get ; 
        set  ;
    }

    public int  BankID
    {
        get ; 
        set  ;
    }

    public string  BranchNOtherDetails
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

    public string AccountingUserName
    {
        get;
        set;
    }

    public string RowStatusName
    {
        get;
        set;
    }
}

