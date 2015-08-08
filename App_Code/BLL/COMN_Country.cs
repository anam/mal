using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_Country
{
    public COMN_Country()
    {
    }


    public COMN_Country
        (
int  countryID,
string  countryName,
string  description,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.CountryID = countryID;
this.CountryName = countryName;
this.Description = description;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  CountryID
    {
        get ; 
        set  ;
    }

    public string  CountryName
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

}

