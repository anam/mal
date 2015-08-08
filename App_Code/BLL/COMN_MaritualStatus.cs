using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_MaritualStatus
{
    public COMN_MaritualStatus()
    {
    }


    public COMN_MaritualStatus
        (
int  maritualStatusID,
string  maritualStatusName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.MaritualStatusID = maritualStatusID;
this.MaritualStatusName = maritualStatusName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  MaritualStatusID
    {
        get ; 
        set  ;
    }

    public string  MaritualStatusName
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

    public string  ModifiedBy
    {
        get ; 
        set  ;
    }

    public DateTime  ModifiedDate
    {
        get ; 
        set  ;
    }

    public int RowStatusID
    {
        get;
        set;
    }

}

