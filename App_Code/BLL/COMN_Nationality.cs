using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_Nationality
{
    public COMN_Nationality()
    {
    }


    public COMN_Nationality
        (
int  nationalityID,
string  nationalityName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.NationalityID = nationalityID;
this.NationalityName = nationalityName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  NationalityID
    {
        get ; 
        set  ;
    }

    public string  NationalityName
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

