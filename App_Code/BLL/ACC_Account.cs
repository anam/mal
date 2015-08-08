using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_Account
{
    public ACC_Account()
    {
    }


    public ACC_Account
        (
            int  accountID,
            string  accountName,
            string  description,
            int  subBasicAccountID,
            string  accountCode,
            string  addedBy,
            DateTime  addedDate,
            string  updatedBy,
            DateTime  updateDate,
            int  rowStatusID

        )

    {
        this.AccountID = accountID;
        this.AccountName = accountName;
        this.Description = description;
        this.SubBasicAccountID = subBasicAccountID;
        this.AccountCode = accountCode;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdateDate = updateDate;
        this.RowStatusID = rowStatusID;

    }

    public ACC_Account
       (
           int accountID
          
       )
    {
        this.AccountID = accountID;
       
    }

    public int  AccountID
    {
        get ; 
        set  ;
    }

    public string  AccountName
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    public int  SubBasicAccountID
    {
        get ; 
        set  ;
    }

    public int BasicAccountID
    {
        get;
        set;
    }

    public string  AccountCode
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

    public decimal Credit
    {
        get;
        set;
    }
    public decimal Debit
    {
        get;
        set;
    }

    public string StartDate
    {
        get;
        set;
    }

    public string EndDate
    {
        get;
        set;
    }

    public string CreditAccountName
    {
        get;
        set;
    }

    public string DebitAccountName
    {
        get;
        set;
    }

    public decimal SumCredit
    {
        get;
        set;
    }
    public decimal SumDebit
    {
        get;
        set;
    }

    public string SubBasicAccountName
    {
        get;
        set;
    }

    public string CreatedDate
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

