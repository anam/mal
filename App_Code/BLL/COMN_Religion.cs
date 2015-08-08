using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_Religion
{
    public COMN_Religion()
    {
    }


    public COMN_Religion
        (
int  religionID,
string  religionName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ReligionID = religionID;
this.ReligionName = religionName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ReligionID
    {
        get ; 
        set  ;
    }

    public string  ReligionName
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

