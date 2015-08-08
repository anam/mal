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

public class EmployeeLeaveManager
{
	public EmployeeLeaveManager()
	{
	}

    public static List<EmployeeLeave> GetAllEmployeeLeaves()
    {
        List<EmployeeLeave> employeeLeaves = new List<EmployeeLeave>();
        SqlEmployeeLeaveProvider sqlEmployeeLeaveProvider = new SqlEmployeeLeaveProvider();
        employeeLeaves = sqlEmployeeLeaveProvider.GetAllEmployeeLeaves();
        return employeeLeaves;
    }

    public static List<EmployeeLeave> GetAllEmployeeLeavesByEmployeeID(string EmployeeID, string fromDate, string toDate)
    {
        List<EmployeeLeave> employeeLeaves = new List<EmployeeLeave>();
        SqlEmployeeLeaveProvider sqlEmployeeLeaveProvider = new SqlEmployeeLeaveProvider();
        employeeLeaves = sqlEmployeeLeaveProvider.GetAllEmployeeLeavesByEmployeeID(EmployeeID, fromDate,toDate);
        return employeeLeaves;
    }

    public static EmployeeLeave GetEmployeeLeaveByID(int id)
    {
        EmployeeLeave employeeLeave = new EmployeeLeave();
        SqlEmployeeLeaveProvider sqlEmployeeLeaveProvider = new SqlEmployeeLeaveProvider();
        employeeLeave = sqlEmployeeLeaveProvider.GetEmployeeLeaveByID(id);
        return employeeLeave;
    }


    public static int InsertEmployeeLeave(EmployeeLeave employeeLeave)
    {
        SqlEmployeeLeaveProvider sqlEmployeeLeaveProvider = new SqlEmployeeLeaveProvider();
        return sqlEmployeeLeaveProvider.InsertEmployeeLeave(employeeLeave);
    }


    public static bool UpdateEmployeeLeave(EmployeeLeave employeeLeave)
    {
        SqlEmployeeLeaveProvider sqlEmployeeLeaveProvider = new SqlEmployeeLeaveProvider();
        return sqlEmployeeLeaveProvider.UpdateEmployeeLeave(employeeLeave);
    }

    public static bool DeleteEmployeeLeave(int employeeLeaveID)
    {
        SqlEmployeeLeaveProvider sqlEmployeeLeaveProvider = new SqlEmployeeLeaveProvider();
        return sqlEmployeeLeaveProvider.DeleteEmployeeLeave(employeeLeaveID);
    }
}
