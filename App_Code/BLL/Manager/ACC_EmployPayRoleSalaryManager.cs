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

/// <summary>
/// Summary description for ACC_EmployPayRoleSalaryManager
/// </summary>
public class ACC_EmployPayRoleSalaryManager
{
	public ACC_EmployPayRoleSalaryManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalaries()
    {
        List<ACC_EmployPayRoleSalary> employPayRoleSalaries = new List<ACC_EmployPayRoleSalary>();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalaries = sqlEmployPayRoleSalaryProvider.GetAllEmployPayRoleSalaries();
        return employPayRoleSalaries;
    }

    public static List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalariesHistory()
    {
        List<ACC_EmployPayRoleSalary> employPayRoleSalaries = new List<ACC_EmployPayRoleSalary>();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalaries = sqlEmployPayRoleSalaryProvider.GetAllEmployPayRoleSalariesHistory();
        return employPayRoleSalaries;
    }



    public static List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalaries(string SalaryOfDate)
    {
        List<ACC_EmployPayRoleSalary> employPayRoleSalaries = new List<ACC_EmployPayRoleSalary>();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalaries = sqlEmployPayRoleSalaryProvider.GetAllEmployPayRoleSalaries(SalaryOfDate);
        return employPayRoleSalaries;
    }


    public static ACC_EmployPayRoleSalary GetEmployPayRoleSalaryByID(int id)
    {
        ACC_EmployPayRoleSalary employPayRoleSalary = new ACC_EmployPayRoleSalary();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalary = sqlEmployPayRoleSalaryProvider.GetEmployPayRoleSalaryByID(id);
        return employPayRoleSalary;
    }

    public static ACC_EmployPayRoleSalary GetEmployPayRoleSalaryByEmployeeIDnSalaryOfDate(string SalaryOfDate, string EmployeeID)
    {
        ACC_EmployPayRoleSalary employPayRoleSalary = new ACC_EmployPayRoleSalary();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalary = sqlEmployPayRoleSalaryProvider.GetEmployPayRoleSalaryByEmployeeIDnSalaryOfDate(SalaryOfDate, EmployeeID);
        return employPayRoleSalary;
    }


    public static int InsertEmployPayRoleSalary(ACC_EmployPayRoleSalary employPayRoleSalary)
    {
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        return sqlEmployPayRoleSalaryProvider.InsertEmployPayRoleSalary(employPayRoleSalary);
    }


    public static bool UpdateEmployPayRoleSalary(ACC_EmployPayRoleSalary employPayRoleSalary)
    {
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        return sqlEmployPayRoleSalaryProvider.UpdateEmployPayRoleSalary(employPayRoleSalary);
    }

    public static bool DeleteEmployPayRoleSalary(int employPayRoleSalaryID)
    {
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        return sqlEmployPayRoleSalaryProvider.DeleteEmployPayRoleSalary(employPayRoleSalaryID);
    }

    public static List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalariesByID(int employPayRoleSalaryID)
    {
        List<ACC_EmployPayRoleSalary> employPayRoleSalaries = new List<ACC_EmployPayRoleSalary>();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalaries = sqlEmployPayRoleSalaryProvider.GetAllEmployPayRoleSalariesByID(employPayRoleSalaryID);
        return employPayRoleSalaries;
    }

    public static List<ACC_EmployPayRoleSalary> GetAllEmployeeByID(string employeeID)
    {
        List<ACC_EmployPayRoleSalary> employPayRoleSalaries = new List<ACC_EmployPayRoleSalary>();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalaries = sqlEmployPayRoleSalaryProvider.GetAllEmployeeByID(employeeID);
        return employPayRoleSalaries;
    }


    public static List<ACC_EmployPayRoleSalary> GetAllEmployPayRoleSalariesByNameAndStatus(string employeeName, int status)
    {
        List<ACC_EmployPayRoleSalary> employPayRoleSalaries = new List<ACC_EmployPayRoleSalary>();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalaries = sqlEmployPayRoleSalaryProvider.GetAllEmployPayRoleSalariesByNameAndStatus(employeeName, status);
        return employPayRoleSalaries;
    }

    public static DataSet GetACC_EmployPayRoleSalaryBySalaryDate(string salaryOfDate)
    {
        DataSet employPayRoleSalaryBySalaryDate = new DataSet();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalaryBySalaryDate = sqlEmployPayRoleSalaryProvider.GetACC_EmployPayRoleSalaryBySalaryDate(salaryOfDate);
        return employPayRoleSalaryBySalaryDate;
    }

    public static DataSet GetACC_AllSalaryDate()
    {
        DataSet employPayRoleSalaryBySalaryDate = new DataSet();
        ACC_EmployPayRoleSalaryProvider sqlEmployPayRoleSalaryProvider = new ACC_EmployPayRoleSalaryProvider();
        employPayRoleSalaryBySalaryDate = sqlEmployPayRoleSalaryProvider.GetACC_AllSalaryDate();
        return employPayRoleSalaryBySalaryDate;
    }
}