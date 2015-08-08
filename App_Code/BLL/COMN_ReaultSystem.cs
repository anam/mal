using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_ReaultSystem
{
    public COMN_ReaultSystem()
    {
    }


    public COMN_ReaultSystem
        (
int  reaultSystemID,
string  reaultSystemName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ReaultSystemID = reaultSystemID;
this.ReaultSystemName = reaultSystemName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ReaultSystemID
    {
        get ; 
        set  ;
    }

    public string  ReaultSystemName
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

}

