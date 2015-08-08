using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Contact
{
    public HR_Contact()
    {
    }


    public HR_Contact
        (
int  contactID,
string  employeeID,
string  currentAddress,
string  permanentAddress,
string  telephone,
string  mobile,
string  email,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ContactID = contactID;
this.EmployeeID = employeeID;
this.CurrentAddress = currentAddress;
this.PermanentAddress = permanentAddress;
this.Telephone = telephone;
this.Mobile = mobile;
this.Email = email;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ContactID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public string  CurrentAddress
    {
        get ; 
        set  ;
    }

    public string  PermanentAddress
    {
        get ; 
        set  ;
    }

    public string  Telephone
    {
        get ; 
        set  ;
    }

    public string  Mobile
    {
        get ; 
        set  ;
    }

    public string  Email
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

