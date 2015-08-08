using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class AbsendSalaryDiduction
{
    public AbsendSalaryDiduction()
    {
    }

    public AbsendSalaryDiduction
        (
        int absendSalaryDiductionID, 
        string employeeID, 
        string salaryOfMonth, 
        int noOfDays, 
        decimal totalSalary, 
        decimal salaryDeduction, 
        string addedBy, 
        DateTime addedDate, 
        string updatedBy, 
        DateTime updateDate, 
        int rowStatusID
        )
    {
        this.AbsendSalaryDiductionID = absendSalaryDiductionID;
        this.EmployeeID = employeeID;
        this.SalaryOfMonth = salaryOfMonth;
        this.NoOfDays = noOfDays;
        this.TotalSalary = totalSalary;
        this.SalaryDeduction = salaryDeduction;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdateDate = updateDate;
        this.RowStatusID = rowStatusID;
    }


    private int _absendSalaryDiductionID;
    public int AbsendSalaryDiductionID
    {
        get { return _absendSalaryDiductionID; }
        set { _absendSalaryDiductionID = value; }
    }

    private string _employeeID;
    public string EmployeeID
    {
        get { return _employeeID; }
        set { _employeeID = value; }
    }

    private string _salaryOfMonth;
    public string SalaryOfMonth
    {
        get { return _salaryOfMonth; }
        set { _salaryOfMonth = value; }
    }

    private int _noOfDays;
    public int NoOfDays
    {
        get { return _noOfDays; }
        set { _noOfDays = value; }
    }

    private decimal _totalSalary;
    public decimal TotalSalary
    {
        get { return _totalSalary; }
        set { _totalSalary = value; }
    }

    private decimal _salaryDeduction;
    public decimal SalaryDeduction
    {
        get { return _salaryDeduction; }
        set { _salaryDeduction = value; }
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

    private DateTime _updateDate;
    public DateTime UpdateDate
    {
        get { return _updateDate; }
        set { _updateDate = value; }
    }

    private int _rowStatusID;
    public int RowStatusID
    {
        get { return _rowStatusID; }
        set { _rowStatusID = value; }
    }

    public string EmployeeNo
    {
        get;
        set;
    }

    public string EmployeeName
    {
        get;
        set;
    }
}
