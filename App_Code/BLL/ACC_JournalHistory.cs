using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_JournalHistory
{
    public ACC_JournalHistory()
    {
    }


    public ACC_JournalHistory
        (
int  journalID,
int  headID,
decimal  debit,
decimal  credit,
int  journalMasterID,
string  journalVoucherNo,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID,
DateTime  historyDate,
string  historyBy

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
this.HistoryDate = historyDate;
this.HistoryBy = historyBy;

    }

    public int  JournalID
    {
        get ; 
        set  ;
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

    public int  JournalMasterID
    {
        get ; 
        set  ;
    }

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

    public DateTime  HistoryDate
    {
        get ; 
        set  ;
    }

    public string  HistoryBy
    {
        get ; 
        set  ;
    }

}

