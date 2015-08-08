using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_HeadUser
{
    public ACC_HeadUser()
    {
    }


    public ACC_HeadUser
        (
int  headUserID,
string  headUserName,
int  headID,
string  userID,
int  userTypeID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.HeadUserID = headUserID;
this.HeadUserName = headUserName;
this.HeadID = headID;
this.UserID = userID;
this.UserTypeID = userTypeID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  HeadUserID
    {
        get ; 
        set  ;
    }

    public string  HeadUserName
    {
        get ; 
        set  ;
    }

    public int  HeadID
    {
        get ; 
        set  ;
    }

    public string  UserID
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

    public string HeadName
    {
        get;
        set;
    }

   
    public string RowStatusName
    {
        get;
        set;
    }

    public string UserTypeName
    {
        get;
        set;
    }
}

