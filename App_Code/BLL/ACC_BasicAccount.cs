using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_BasicAccount
{
    public ACC_BasicAccount()
    {
    }


    public ACC_BasicAccount
        (
int  basicAccountID,
string  basicAccountCode,
string  basicAccountName,
string  description,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.BasicAccountID = basicAccountID;
this.BasicAccountCode = basicAccountCode;
this.BasicAccountName = basicAccountName;
this.Description = description;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  BasicAccountID
    {
        get ; 
        set  ;
    }

    public string  BasicAccountCode
    {
        get ; 
        set  ;
    }

    public string  BasicAccountName
    {
        get ; 
        set  ;
    }

    public string  Description
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

