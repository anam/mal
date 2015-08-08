using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_City
{
    public COMN_City()
    {
    }


    public COMN_City
        (
int  cityID,
string  cityName,
string  description,
int  countryID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.CityID = cityID;
this.CityName = cityName;
this.Description = description;
this.CountryID = countryID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  CityID
    {
        get ; 
        set  ;
    }

    public string  CityName
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    public int  CountryID
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

