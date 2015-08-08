using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_SubBasicAccount
{
    public ACC_SubBasicAccount()
    {
    }


    public ACC_SubBasicAccount
        (
            int  subBasicAccountID,
            string  subBasicAccountCode,
            string  subBasicAccountName,
            string  description,
            int  basicAccountID,
            string  addedBy,
            DateTime  addedDate,
            string  updatedBy,
            DateTime  updateDate,
            int  rowStatusID

        )

    {
            this.SubBasicAccountID = subBasicAccountID;
            this.SubBasicAccountCode = subBasicAccountCode;
            this.SubBasicAccountName = subBasicAccountName;
            this.Description = description;
            this.BasicAccountID = basicAccountID;
            this.AddedBy = addedBy;
            this.AddedDate = addedDate;
            this.UpdatedBy = updatedBy;
            this.UpdateDate = updateDate;
            this.RowStatusID = rowStatusID;

    }

    public ACC_SubBasicAccount
       (
           int subBasicAccountID
          
       )
    {
        this.SubBasicAccountID = subBasicAccountID;
    }

    public ACC_SubBasicAccount
      (
          int subBasicAccountID,
        int basicAccountID

      )
    {
        this.SubBasicAccountID = subBasicAccountID;
        this.BasicAccountID = basicAccountID;
    }

    public int  SubBasicAccountID
    {
        get ; 
        set  ;
    }

    public string  SubBasicAccountCode
    {
        get ; 
        set  ;
    }

    public string  SubBasicAccountName
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    public int  BasicAccountID
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

    public string HeadName
    {
        get;
        set;
    }

    public string BasicAccountName
    {
        get;
        set;
    }

    public string RowStatusName
    {
        get;
        set;
    }

    public string IncomeAccountName
    {
        get;
        set;
    }

    public string ExpenseAccountName
    {
        get;
        set;
    }

    public decimal Income
    {
        get;
        set;
    }
    public decimal Expense
    {
        get;
        set;
    }

    public decimal SumIncome
    {
        get;
        set;
    }
    public decimal SumExpense
    {
        get;
        set;
    }


    public string AssetAccountName
    {
        get;
        set;
    }

    public string LiabilityAccountName
    {
        get;
        set;
    }

    public string CapitalAccountName
    {
        get;
        set;
    }

    public decimal Asset
    {
        get;
        set;
    }
    public decimal Liability
    {
        get;
        set;
    }

    public decimal Capital
    {
        get;
        set;
    }

    public decimal SumAsset
    {
        get;
        set;
    }
    public decimal SumLiability
    {
        get;
        set;
    }

    public decimal SumCapital
    {
        get;
        set;
    }
    public decimal NetIncome
    {
        get;
        set;
    }

    public string CreatedDate
    {
        get;
        set;
    }
}

