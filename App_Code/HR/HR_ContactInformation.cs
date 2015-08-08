using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_ContactInformation
{
    public HR_ContactInformation()
    {
    }


    public HR_ContactInformation
        (
int  contactInformationID,
string  employeeID,
string  currentAddress,
string  parmanentAddress,
string  email,
string  telephone,
string  mobile,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ContactInformationID = contactInformationID;
this.EmployeeID = employeeID;
this.CurrentAddress = currentAddress;
this.ParmanentAddress = parmanentAddress;
this.Email = email;
this.Telephone = telephone;
this.Mobile = mobile;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ContactInformationID
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

    public string  ParmanentAddress
    {
        get ; 
        set  ;
    }

    public string  Email
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

