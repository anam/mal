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

public class EmployeeSchedule
{
    public EmployeeSchedule()
    {
    }

    public EmployeeSchedule
        (
        int employeeScheduleID, 
        string employeeID, 
        int classDayID, 
        string startTime, 
        string endTime, 
        int rowStatusID, 
        string addedBy, 
        DateTime addedDate, 
        string updatedBy, 
        DateTime updateDate
        )
    {
        this.EmployeeScheduleID = employeeScheduleID;
        this.EmployeeID = employeeID;
        this.ClassDayID = classDayID;
        this.StartTime = startTime;
        this.EndTime = endTime;
        this.RowStatusID = rowStatusID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdateDate = updateDate;
    }


    private int _employeeScheduleID;
    public int EmployeeScheduleID
    {
        get { return _employeeScheduleID; }
        set { _employeeScheduleID = value; }
    }

    private string _employeeID;
    public string EmployeeID
    {
        get { return _employeeID; }
        set { _employeeID = value; }
    }

    private int _classDayID;
    public int ClassDayID
    {
        get { return _classDayID; }
        set { _classDayID = value; }
    }

    private string _classDay;
    public string ClassDay
    {
        get { return _classDay; }
        set { _classDay = value; }
    }


    private string _startTime;
    public string StartTime
    {
        get { return _startTime; }
        set { _startTime = value; }
    }

    private string _endTime;
    public string EndTime
    {
        get { return _endTime; }
        set { _endTime = value; }
    }

    private int _rowStatusID;
    public int RowStatusID
    {
        get { return _rowStatusID; }
        set { _rowStatusID = value; }
    }

    public string AddedBy
    {
        get;
        set;
    }

    public DateTime AddedDate
    {
        get;
        set;
    }

    public string UpdatedBy
    {
        get;
        set;
    }

    public DateTime UpdateDate
    {
        get;
        set;
    }
}
