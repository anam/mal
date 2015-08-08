using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Campus
{
    public STD_Campus()
    {
    }


    public STD_Campus
        (
int  campusID,
string  campusName,
string  address,
string  description,
int  cityID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.CampusID = campusID;
this.CampusName = campusName;
this.Address = address;
this.Description = description;
this.CityID = cityID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  CampusID
    {
        get ; 
        set  ;
    }

    public string  CampusName
    {
        get ; 
        set  ;
    }

    public string  Address
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    public int  CityID
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

