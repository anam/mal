using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ACC_EmployPayRoleSalary
/// </summary>
public class ACC_EmployPayRoleSalary
{
    public ACC_EmployPayRoleSalary()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ACC_EmployPayRoleSalary
    (
    int employPayRoleSalaryID,
    string addedBy,
    DateTime addedDate,
    string updatedBy,
    DateTime updatedDate,
    string employeeID,
    decimal salaryAmount,
    decimal paidSalaryAmount,
    decimal unpaidSalaryAmount,
    int status
    )
    {
        this.EmployPayRoleSalaryID = employPayRoleSalaryID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
        this.EmployeeID = employeeID;
        this.SalaryAmount = salaryAmount;
        this.PaidSalaryAmount = paidSalaryAmount;
        this.UnpaidSalaryAmount = unpaidSalaryAmount;
        this.Status = status;
    }


    private int _employPayRoleSalaryID;
    public int EmployPayRoleSalaryID
    {
        get { return _employPayRoleSalaryID; }
        set { _employPayRoleSalaryID = value; }
    }

    private string _addedBy;
    public string AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private string _updatedBy;
    public string UpdatedBy
    {
        get { return _updatedBy; }
        set { _updatedBy = value; }
    }

    private DateTime _updatedDate;
    public DateTime UpdatedDate
    {
        get { return _updatedDate; }
        set { _updatedDate = value; }
    }

    private string _employeeID;

    public string EmployeeID
    {
        get { return _employeeID; }
        set { _employeeID = value; }
    }
    /// <summary>
    /// pay able amount
    /// </summary>
    private decimal _salaryAmount;
    public decimal SalaryAmount
    {
        get { return _salaryAmount; }
        set { _salaryAmount = value; }
    }

    private decimal _paidSalaryAmount;
    public decimal PaidSalaryAmount
    {
        get { return _paidSalaryAmount; }
        set { _paidSalaryAmount = value; }
    }

    private decimal _unpaidSalaryAmount;
    public decimal UnpaidSalaryAmount
    {
        get { return _unpaidSalaryAmount; }
        set { _unpaidSalaryAmount = value; }
    }

    private int _status;
    public int Status
    {
        get { return _status; }
        set { _status = value; }
    }

    private int _rowStatusID;
    public int RowStatusID
    {
        get { return _rowStatusID; }
        set { _rowStatusID = value; }
    }

    private string _salaryOfDate;

    public string SalaryOfDate
    {
        get { return _salaryOfDate; }
        set { _salaryOfDate = value; }
    }

    public string salaryStatus
    {
        get
        {
            if (Status == (int)Enums.SalaryStatus.Paid)
                return "paid";
            else if (Status == (int)Enums.SalaryStatus.PartiallyPaid)
                return "PartiallyPaid";
            else
                return "Unpaid";
        }

    }

    public string EmployeeName
    {
        get
        {
            if (EmployeeID != null)
                return HR_EmployeeManager.GetHR_EmployeeByEmployeeID(EmployeeID).EmployeeName;
            return string.Empty;
        }
    }
   
    /// <summary>
    /// Salary breakdown history
    /// </summary>
    public string ExtraField1
    {
        get;
        set;
    }

    /// <summary>
    /// Total Salary With provident fund
    /// </summary>
    public string ExtraField2
    {
        get;
        set;
    }
   
    /// <summary>
    /// HR_ProvidentFundRegister   ID
    /// </summary>
    public string ExtraField3
    {
        get;
        set;
    }
    
    /// <summary>
    /// Journal MasterID for the Provident fund process
    /// </summary>
    public string ExtraField4
    {
        get;
        set;
    }


    /// <summary>
    /// Journal MasterID for the advanceSalary Process
    /// </summary>
    public string ExtraField5
    {
        get;
        set;
    }


    /// <summary>
    /// Journal Master  ID of the Expence Fultime Salary
    /// </summary>
    public string ExtraField6
    {
        get;
        set;
    }


    /// <summary>
    /// JournalID of the Expence Fultime Salary
    /// </summary>
    public string ExtraField7
    {
        get;
        set;
    }


    /// <summary>
    /// Security Amount
    /// </summary>
    public string ExtraField8
    {
        get;
        set;
    }

    /// <summary>
    /// Journal MasterID for the securityMoney Process
    /// </summary>
    public string ExtraField9
    {
        get;
        set;
    }

    public string ExtraField10
    {
        get;
        set;
    }
}
