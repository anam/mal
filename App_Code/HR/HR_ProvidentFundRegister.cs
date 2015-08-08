using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_ProvidentFundRegister
{
    public HR_ProvidentFundRegister()
    {
    }


    public HR_ProvidentFundRegister
        (
int  providentFundRegisterID,
string  employeeID,
DateTime  payrollMonthDate,
decimal  ePF,
decimal  cPF,
decimal  totalPFAmount,
decimal  withdrawAmount,
DateTime  withdrawLastDate,
string  extraField1,
string  extraField2,
string  extraField3,
string  extraField4,
string  extraField5,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate,
int  rowStatusID

        )

    {
this.ProvidentFundRegisterID = providentFundRegisterID;
this.EmployeeID = employeeID;
this.PayrollMonthDate = payrollMonthDate;
this.EPF = ePF;
this.CPF = cPF;
this.TotalPFAmount = totalPFAmount;
this.WithdrawAmount = withdrawAmount;
this.WithdrawLastDate = withdrawLastDate;
this.ExtraField1 = extraField1;
this.ExtraField2 = extraField2;
this.ExtraField3 = extraField3;
this.ExtraField4 = extraField4;
this.ExtraField5 = extraField5;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;
this.RowStatusID = rowStatusID;

    }

    public int  ProvidentFundRegisterID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public DateTime  PayrollMonthDate
    {
        get ; 
        set  ;
    }

    public decimal  EPF
    {
        get ; 
        set  ;
    }

    public decimal  CPF
    {
        get ; 
        set  ;
    }

    public decimal  TotalPFAmount
    {
        get ; 
        set  ;
    }

    public decimal  WithdrawAmount
    {
        get ; 
        set  ;
    }

    public DateTime  WithdrawLastDate
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// ACC_EmployPayRoleSalary   ID
    /// </summary>
    public string  ExtraField1
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// Security Amount
    /// </summary>
    public string  ExtraField2
    {
        get ; 
        set  ;
    }

    public string  ExtraField3
    {
        get ; 
        set  ;
    }

    public string  ExtraField4
    {
        get ; 
        set  ;
    }

    public string  ExtraField5
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

    public int  RowStatusID
    {
        get ; 
        set  ;
    }

}

