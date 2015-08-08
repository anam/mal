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

public class Attendence
{
    public Attendence()
    {
    }

    public Attendence
        (
        int attendenceID, 
        string userID, 
        DateTime inOutTime
        )
    {
        this.AttendenceID = attendenceID;
        this.UserID = userID;
        this.InOutTime = inOutTime;
    }


    private int _attendenceID;
    public int AttendenceID
    {
        get { return _attendenceID; }
        set { _attendenceID = value; }
    }

    private string _userID;
    public string UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }

    private DateTime _inOutTime;
    public DateTime InOutTime
    {
        get { return _inOutTime; }
        set { _inOutTime = value; }
    }


    public DateTime InTime
    {
        get;
        set;
    }

    public DateTime OutTime
    {
        get;
        set;
    }

    public DateTime StarttingOfficeTime
    {
        get;
        set;
    }

    public DateTime EndOfficeTime
    {
        get;
        set;
    }

    public string StarttingOfficeTimeDisplay
    {
        get;
        set;
    }

    public string EndOfficeTimeDisplay
    {
        get;
        set;
    }

    public string DateDisplay
    {
        get;
        set;
    }

    public string UserName
    {
        get;
        set;
    }

    /// <summary>
    /// UniqueIdentifier
    /// </summary>
    public string ID
    {
        get;
        set;
    }

    public string UserNameDisplay
    {
        get;
        set;
    }

    public string UserIDDisplay
    {
        get;
        set;
    }
    

    public string TotalDuratinDisplay
    {
        get;
        set;
    }

    public int Duration
    {
        get;
        set;
    }

    public string DurationDisplay
    {
        get;
        set;
    }

    public int EarlyLeaveInMin
    {
        get;
        set;
    }

    public string EarlyLeaveDisplay
    {
        get;
        set;
    }


    public int LateComeInMin
    {
        get;
        set;
    }

    public string LateComeDisplay
    {
        get;
        set;
    }

    public bool DefaultTimeLabelVisible
    {
        get;
        set;
    }

    public bool DefaultTimeTextBoxVisible
    {
        get;
        set;
    }


    public int TotalWorkingDay
    {
        get;
        set;
    }

    public int TotalWorked
    {
        get;
        set;
    }

    public int TotalLeaveDay
    {
        get;
        set;
    }

    public int TotalLeaveDayWorkingDay
    {
        get;
        set;
    }

    public int TotalOffDay
    {
        get;
        set;
    }

    public int TotalOffDayWorkingDay
    {
        get;
        set;
    }

    public int TotalWorkingTime
    {
        get;
        set;
    }

    public string TotalWorkingTimeDisplay
    {
        get;
        set;
    }
    
    public int  AbsentDay
    {
        get;
        set;
    }

    public int TotalOfficeTime
    {
        get;
        set;
    }

    public string TotalOfficeTimeDisplay
    {
        get;
        set;
    }

    public string OverTimeDisplay
    {
        get;
        set;
    }

    public bool IsLeaveDay
    {
        get;
        set;
    }

    public bool IsOffDay
    {
        get;
        set;
    }

    public bool IsPresent
    {
        get;
        set;
    }

    public DateTime Day
    {
        get;
        set;
    }

    public decimal Amount
    {
        get;
        set;
    }
}
