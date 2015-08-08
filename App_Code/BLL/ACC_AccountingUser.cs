using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_AccountingUser
{
    public ACC_AccountingUser()
    {
    }


    public ACC_AccountingUser
        (
int  accountingUserID,
string  accountingUserName,
int  userTypeID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.AccountingUserID = accountingUserID;
this.AccountingUserName = accountingUserName;
this.UserTypeID = userTypeID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  AccountingUserID
    {
        get ; 
        set  ;
    }

    public string  AccountingUserName
    {
        get ; 
        set  ;
    }

    public int  UserTypeID
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

