using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ContactType
{
    public STD_ContactType()
    {
    }


    public STD_ContactType
        (
int  contactTypeID,
string  contactTypeName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ContactTypeID = contactTypeID;
this.ContactTypeName = contactTypeName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ContactTypeID
    {
        get ; 
        set  ;
    }

    public string  ContactTypeName
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

