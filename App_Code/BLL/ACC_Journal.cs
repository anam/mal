using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_Journal
{
    public ACC_Journal()
    {
    }


    public ACC_Journal
        (


            int  journalID,
            int  headID,
            decimal  debit,
            decimal  credit,
            int journalMasterID,
            string  journalVoucherNo,
            string  addedBy,
            DateTime  addedDate,
            string  updatedBy,
            DateTime  updateDate,
            int  rowStatusID


        )


        {
            this.JournalID = journalID;
            this.HeadID = headID;
            this.Debit = debit;
            this.Credit = credit;
            this.JournalMasterID = journalMasterID;
            this.JournalVoucherNo = journalVoucherNo;
            this.AddedBy = addedBy;
            this.AddedDate = addedDate;
            this.UpdatedBy = updatedBy;
            this.UpdateDate = updateDate;
            this.RowStatusID = rowStatusID;


        }

   

    public int  JournalID
    {
        get ; 
        set  ;
    }

    public int AccountID
    {
        get;
        set;
    }


    public int SubBasicAccountID
    {
        get;
        set;
    }


    public int EmployPayRoleSalaryID
    {
        get;
        set;
    }

    public string HeadName
    {
        get;
        set;
    }

    public int  HeadID
    {
        get ; 
        set  ;
    }

    public decimal  Debit
    {
        get ; 
        set  ;
    }

    public decimal  Credit
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// Balance = Debit - Credit
    /// </summary>
    public decimal Balance
    {
        get;
        set;
    }
    public int JournalMasterID

    {
        get ; 
        set  ;
    }

    public int UserTypeID
    { 
        get; 
        set;
    }

    public string UserID
    {
        get;
        set;
    }

    /// <summary>
    /// for the admission fees indicator 0=Installation fee 1=admission and installation fee
    /// also use for the Provident fund liability indector when 2=Need to show in Expence
    /// for the check receive the checkID 
    /// </summary>
    public string  JournalVoucherNo
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

    public string AccountName
    {
        get;
        set;
    }

    public string Description
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


    public string CreatedDate
    {
        get;
        set;
    }

    public bool IsNotCheck
    {
        get;
        set;
    }

    public string SalaryOfDate
    {
        get;
        set;
    }
}

