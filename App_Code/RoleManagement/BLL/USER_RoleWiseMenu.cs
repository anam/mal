using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class USER_RoleWiseMenu
{
    public USER_RoleWiseMenu()
    {
    }


    public USER_RoleWiseMenu
        (
int  iD,
int  menuID,
string  roleID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate,
int  rowStatusID

        )

    {
this.ID = iD;
this.MenuID = menuID;
this.RoleID = roleID;
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

    public int  MenuID
    {
        get ; 
        set  ;
    }

    public string  RoleID
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

