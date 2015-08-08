using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_Head
{
    public ACC_Head()
    {
    }


    public ACC_Head
        (
int  headID,
string  headName,
string  headCode,
int  accountID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.HeadID = headID;
this.HeadName = headName;
this.HeadCode = headCode;
this.AccountID = accountID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  HeadID
    {
        get ; 
        set  ;
    }

    public string  HeadName
    {
        get ; 
        set  ;
    }

    public string  HeadCode
    {
        get ; 
        set  ;
    }

    public int  AccountID
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

    public string AccountName
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

