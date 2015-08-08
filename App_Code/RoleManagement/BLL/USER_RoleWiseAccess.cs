using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class USER_RoleWiseAccess
{
    public USER_RoleWiseAccess()
    {
    }


    public USER_RoleWiseAccess
        (
int  iD,
int  pageID,
string  roleID,
int  operationID,
bool  access,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate,
int  rowStatusID

        )

    {
this.ID = iD;
this.PageID = pageID;
this.RoleID = roleID;
this.OperationID = operationID;
this.Access = access;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;
this.RowStatusID = rowStatusID;

    }

    public int  ID
    {
        get ; 
        set  ;
    }

    public int  PageID
    {
        get ; 
        set  ;
    }

    public string  RoleID
    {
        get ; 
        set  ;
    }

    public int  OperationID
    {
        get ; 
        set  ;
    }

    public bool  Access
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

    public DateTime  UpdatedDate
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

