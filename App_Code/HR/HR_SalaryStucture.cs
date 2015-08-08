using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryStucture
{
    public HR_SalaryStucture()
    {
    }


    public HR_SalaryStucture
        (
int  salaryStructureID,
string  salaryStuctureName,
decimal  basic,
decimal  houseRent,
decimal  others,
decimal  total,
string  employeeID,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.SalaryStructureID = salaryStructureID;
this.SalaryStuctureName = salaryStuctureName;
this.Basic = basic;
this.HouseRent = houseRent;
this.Others = others;
this.Total = total;
this.EmployeeID = employeeID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  SalaryStructureID
    {
        get ; 
        set  ;
    }

    public string  SalaryStuctureName
    {
        get ; 
        set  ;
    }

    public decimal  Basic
    {
        get ; 
        set  ;
    }

    public decimal  HouseRent
    {
        get ; 
        set  ;
    }

    public decimal  Others
    {
        get ; 
        set  ;
    }

    public decimal  Total
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
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

