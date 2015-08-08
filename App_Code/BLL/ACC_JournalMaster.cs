using System;
using System.Data;
using System.Configuration;


public class ACC_JournalMaster
{
    public ACC_JournalMaster()
    {
    }


    public ACC_JournalMaster
        (
int  journalMasterID,
string  journalMasterName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.JournalMasterID = journalMasterID;
this.JournalMasterName = journalMasterName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  JournalMasterID
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// Journal Type
    /// Dr
    /// Cr
    /// </summary>
    public string  JournalMasterName
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
    public string RowStatusName
    {
        get;
        set;
    }
}

