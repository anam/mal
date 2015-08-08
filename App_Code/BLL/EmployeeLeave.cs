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

public class EmployeeLeave
{
    public EmployeeLeave()
    {
    }

    public EmployeeLeave
        (
        int employeeLeaveID, 
        string employeeID, 
        DateTime leaveDate, 
        int leaveTypeID, 
        string addedBy, 
        DateTime addedDate, 
        string updatedBy, 
        DateTime updateDate, 
        int rowStatusID
        )
    {
        this.EmployeeLeaveID = employeeLeaveID;
        this.EmployeeID = employeeID;
        this.LeaveDate = leaveDate;
        this.LeaveTypeID = leaveTypeID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdateDate = updateDate;
        this.RowStatusID = rowStatusID;
    }


    private int _employeeLeaveID;
    public int EmployeeLeaveID
    {
        get { return _employeeLeaveID; }
        set { _employeeLeaveID = value; }
    }

    private string _employeeID;
    public string EmployeeID
    {
        get { return _employeeID; }
        set { _employeeID = value; }
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

    private DateTime _leaveDate;
    public DateTime LeaveDate
    {
        get { return _leaveDate; }
        set { _leaveDate = value; }
    }

    private int _leaveTypeID;
    public int LeaveTypeID
    {
        get { return _leaveTypeID; }
        set { _leaveTypeID = value; }
    }

    public string LeaveName
    {
        get;
        set;
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


}
