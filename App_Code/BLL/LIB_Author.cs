using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class LIB_Author
{
    public LIB_Author()
    {
    }


    public LIB_Author
        (
int  authorID,
string  authorName,
string  address,
string  email,
string  phone,
string  mobile,
string  country,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.AuthorID = authorID;
this.AuthorName = authorName;
this.Address = address;
this.Email = email;
this.Phone = phone;
this.Mobile = mobile;
this.Country = country;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  AuthorID
    {
        get ; 
        set  ;
    }

    public string  AuthorName
    {
        get ; 
        set  ;
    }

    public string  Address
    {
        get ; 
        set  ;
    }

    public string  Email
    {
        get ; 
        set  ;
    }

    public string  Phone
    {
        get ; 
        set  ;
    }

    public string  Mobile
    {
        get ; 
        set  ;
    }

    public string  Country
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

