using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Tax
{
    public HR_Tax()
    {
    }


    public HR_Tax
        (
int  taxID,
string  taxName,
decimal  ratio,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate,
string  employeeID

        )

    {
this.TaxID = taxID;
this.TaxName = taxName;
this.Ratio = ratio;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;
this.EmployeeID = employeeID;

    }

    public int  TaxID
    {
        get ; 
        set  ;
    }

    public string  TaxName
    {
        get ; 
        set  ;
    }

    public decimal  Ratio
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

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

}

