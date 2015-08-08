using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class USER_Operation
{
    public USER_Operation()
    {
    }


    public USER_Operation
        (
int  operationID,
string  operationName,
string  description,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate,
int  rowStatusID

        )

    {
this.OperationID = operationID;
this.OperationName = operationName;
this.Description = description;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;
this.RowStatusID = rowStatusID;

    }

    public int  OperationID
    {
        get ; 
        set  ;
    }

    public string  OperationName
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

