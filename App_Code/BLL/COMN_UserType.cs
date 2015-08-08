using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_UserType
{
    public COMN_UserType()
    {
    }


    public COMN_UserType
        (
int  userTypeID,
string  userTypeName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.UserTypeID = userTypeID;
this.UserTypeName = userTypeName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  UserTypeID
    {
        get ; 
        set  ;
    }

    public string  UserTypeName
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

