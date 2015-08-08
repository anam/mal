using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Bank
{
    public HR_Bank()
    {
    }


    public HR_Bank
        (
int  bankID,
string  employeeID,
string  accountName,
string  bankName,
string  bankAddress,
string  bankTelephone,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.BankID = bankID;
this.EmployeeID = employeeID;
this.AccountName = AccountName;
this.BankName = bankName;
this.BankAddress = bankAddress;
this.BankTelephone = bankTelephone;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  BankID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public string  AccountName
    {
        get ; 
        set  ;
    }

    public string  BankName
    {
        get ; 
        set  ;
    }

    public string  BankAddress
    {
        get ; 
        set  ;
    }

    public string  BankTelephone
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

