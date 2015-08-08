using System;
using System.Collections.Generic;
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

public class EmployeeScheduleManager
{
	public EmployeeScheduleManager()
	{
	}

    public static List<EmployeeSchedule> GetAllEmployeeSchedules()
    {
        List<EmployeeSchedule> employeeSchedules = new List<EmployeeSchedule>();
        SqlEmployeeScheduleProvider sqlEmployeeScheduleProvider = new SqlEmployeeScheduleProvider();
        employeeSchedules = sqlEmployeeScheduleProvider.GetAllEmployeeSchedules();
        return employeeSchedules;
    }


    public static List<EmployeeSchedule> GetAllEmployeeSchedulesWithHistory()
    {
        List<EmployeeSchedule> employeeSchedules = new List<EmployeeSchedule>();
        SqlEmployeeScheduleProvider sqlEmployeeScheduleProvider = new SqlEmployeeScheduleProvider();
        employeeSchedules = sqlEmployeeScheduleProvider.GetAllEmployeeSchedulesWithHistory();
        return employeeSchedules;
    }

    public static List<EmployeeSchedule> GetAllEmployeeSchedulesByEmployeeID(string EmployeeID)
    {
        List<EmployeeSchedule> employeeSchedules = new List<EmployeeSchedule>();
        SqlEmployeeScheduleProvider sqlEmployeeScheduleProvider = new SqlEmployeeScheduleProvider();
        employeeSchedules = sqlEmployeeScheduleProvider.GetAllEmployeeSchedulesByEmployeeID(EmployeeID);
        return employeeSchedules;
    }

    public static List<EmployeeSchedule> GetAllEmployeeSchedulesByEmployeeIDWithHistory(string EmployeeID)
    {
        List<EmployeeSchedule> employeeSchedules = new List<EmployeeSchedule>();
        SqlEmployeeScheduleProvider sqlEmployeeScheduleProvider = new SqlEmployeeScheduleProvider();
        employeeSchedules = sqlEmployeeScheduleProvider.GetAllEmployeeSchedulesByEmployeeIDWithHistory(EmployeeID);
        return employeeSchedules;
    }

    public static EmployeeSchedule GetEmployeeScheduleByID(int id)
    {
        EmployeeSchedule employeeSchedule = new EmployeeSchedule();
        SqlEmployeeScheduleProvider sqlEmployeeScheduleProvider = new SqlEmployeeScheduleProvider();
        employeeSchedule = sqlEmployeeScheduleProvider.GetEmployeeScheduleByID(id);
        return employeeSchedule;
    }


    public static int InsertEmployeeSchedule(EmployeeSchedule employeeSchedule)
    {
        SqlEmployeeScheduleProvider sqlEmployeeScheduleProvider = new SqlEmployeeScheduleProvider();
        return sqlEmployeeScheduleProvider.InsertEmployeeSchedule(employeeSchedule);
    }


    public static bool UpdateEmployeeSchedule(EmployeeSchedule employeeSchedule)
    {
        SqlEmployeeScheduleProvider sqlEmployeeScheduleProvider = new SqlEmployeeScheduleProvider();
        return sqlEmployeeScheduleProvider.UpdateEmployeeSchedule(employeeSchedule);
    }

    public static bool DeleteEmployeeSchedule(int employeeScheduleID)
    {
        SqlEmployeeScheduleProvider sqlEmployeeScheduleProvider = new SqlEmployeeScheduleProvider();
        return sqlEmployeeScheduleProvider.DeleteEmployeeSchedule(employeeScheduleID);
    }
}
