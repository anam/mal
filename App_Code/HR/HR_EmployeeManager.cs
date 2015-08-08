using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_EmployeeManager
{
	public HR_EmployeeManager()
	{
	}

    public static DataSet  GetAllHR_Employees()
    {
       DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetAllHR_Employees();
        return hR_Employees;
    }

    public static DataSet getAllEmployeeListDepartmentWise()
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.getAllEmployeeListDepartmentWise();
        return hR_Employees;
    }

    public static DataSet GetAllHR_EmployeesByIDs(string ids)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetAllHR_EmployeesByIDs(ids);
        return hR_Employees;
    }

    public static DataSet GetAllHR_EmployeesNotForThisSubject(int subjectID)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetAllHR_EmployeesNotForThisSubject(subjectID);
        return hR_Employees;
    }

    /// <summary>
    /// Get Active and Rowstatus =1 employees and who employees salary is not process for selected month. 
    /// </summary>
    /// <param name="salaryOfDate">Process Month</param>
    /// <returns>DataSet</returns>
    public static DataSet GetAllHR_EmployeeMinuesPayrollSalaryEmp(string salaryOfDate)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetAllHR_EmployeeMinuesPayrollSalaryEmp(salaryOfDate);
        return hR_Employees;
    }

    /// <summary>
    /// Get Active and Rowstatus =1 employees and who employees salary is not process for selected month. 
    /// </summary>
    /// <param name="salaryOfDate">Process Month</param>
    /// <returns>DataSet</returns>
    public static DataSet GetAllHR_EmployeeMinuesPayrollSalaryEmpByEmployeeID(string employeeID)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetAllHR_EmployeeMinuesPayrollSalaryEmpByEmployeeID(employeeID);
        return hR_Employees;
    }

    public static DataSet GetHR_EmployeeInfoByEmployeeID(string employeeID)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetHR_EmployeeInfoByEmployeeID(employeeID);
        return hR_Employees;
    }

    public static DataSet GetHR_EmployeeInfoByEmployeeNo(string employeeNo)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetHR_EmployeeInfoByEmployeeNo(employeeNo);
        return hR_Employees;
    }


    public static void hR_EmployeesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
    {
        double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("First", "1", currentPage > 1));
            for (int i = 1; i <= pageCount; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }
            pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    
    public static DataSet GetHR_EmployeeStatisticDepartWise(int departmentID)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetHR_EmployeeStatisticDepartWise(departmentID);
        return hR_Employees;
    }

    public static DataSet GetAllHR_EmployeesBySearch(string sqlSearchString)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetAllHR_EmployeesBySearch(sqlSearchString);
        return hR_Employees;
    }
    
    public static DataSet GetAllHR_EmployeeIDInfoBySearch(string sqlSearchString)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetAllHR_EmployeeIDInfoBySearch(sqlSearchString);
        return hR_Employees;
    }

    /// <summary>
    /// Get EmployeeNo, Name and JoiningDate from employee table on condition: not null joning date and active employee 
    /// </summary>
    /// <returns>DataSet</returns>
    public static DataSet GetAllHR_EmpNoNameJoiningDate()
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetAllHR_EmpNoNameJoiningDate();
        return hR_Employees;
    }

 	public static void LoadHR_EmployeePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        DataSet ds = sqlHR_EmployeeProvider.GetHR_EmployeePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_EmployeesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static void LoadHR_EmployeePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize, bool isActive)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        DataSet ds = sqlHR_EmployeeProvider.GetHR_EmployeePageWise(pageIndex, PageSize, out recordCount, isActive);
        gv.DataSource = ds;
        gv.DataBind();
        hR_EmployeesPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static DataSet  GetDropDownListAllHR_Employee()
    {
       DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetDropDownLisAllHR_Employee();
        return hR_Employees;
    }

    public static DataSet GetDropDownListAllHR_EmployeeFromSubjectEmployee()
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetDropDownLisAllHR_EmployeeFromSubjectEmployee();
        return hR_Employees;
    }

    public static DataSet   GetAllHR_EmployeesWithRelation()
    {
       DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetAllHR_Employees();
        return hR_Employees;
    }

    public static HR_Employee GetHR_EmployeeByEmployeeNo(string employeeNo)
    {
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        return sqlHR_EmployeeProvider.GetHR_EmployeeByEmployeeNo(employeeNo);
    }

    public static HR_Employee GetHR_BloodGroupByBloodGroupID(string BloodGroupID)
    {
        HR_Employee hR_Employee = new HR_Employee();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employee = sqlHR_EmployeeProvider.GetHR_EmployeeByBloodGroupID(BloodGroupID);
        return hR_Employee;
    }


    public static HR_Employee GetHR_GenderByGenderID(string GenderID)
    {
        HR_Employee hR_Employee = new HR_Employee();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employee = sqlHR_EmployeeProvider.GetHR_EmployeeByGenderID(GenderID);
        return hR_Employee;
    }


    public static HR_Employee GetHR_ReligionByReligionID(int ReligionID)
    {
        HR_Employee hR_Employee = new HR_Employee();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employee = sqlHR_EmployeeProvider.GetHR_EmployeeByReligionID(ReligionID);
        return hR_Employee;
    }


    public static HR_Employee GetHR_MaritualStatusByMaritualStatusID(int MaritualStatusID)
    {
        HR_Employee hR_Employee = new HR_Employee();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employee = sqlHR_EmployeeProvider.GetHR_EmployeeByMaritualStatusID(MaritualStatusID);
        return hR_Employee;
    }


    public static HR_Employee GetHR_NationalityByNationalityID(int NationalityID)
    {
        HR_Employee hR_Employee = new HR_Employee();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employee = sqlHR_EmployeeProvider.GetHR_EmployeeByNationalityID(NationalityID);
        return hR_Employee;
    }


    public static HR_Employee GetHR_DesignationByDesignationID(int DesignationID)
    {
        HR_Employee hR_Employee = new HR_Employee();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employee = sqlHR_EmployeeProvider.GetHR_EmployeeByDesignationID(DesignationID);
        return hR_Employee;
    }


    public static HR_Employee GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_Employee hR_Employee = new HR_Employee();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employee = sqlHR_EmployeeProvider.GetHR_EmployeeByEmployeeID(EmployeeID);
        return hR_Employee;
    }

    public static string GetEmployeeNo()
    {
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        return sqlHR_EmployeeProvider.GetEmployeeNo();
    }


    public static DataSet GetDropDownListAllHR_EmployeClassID(int ClassID, int SubjectID)
    {
        DataSet hR_Employees = new DataSet();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employees = sqlHR_EmployeeProvider.GetDropDownLisAllHR_EmployeeByClassID(ClassID, SubjectID);
        return hR_Employees;
    }

    public static int InsertHR_Employee(HR_Employee hR_Employee)
    {
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        return sqlHR_EmployeeProvider.InsertHR_Employee(hR_Employee);
    }


    public static bool UpdateHR_Employee(HR_Employee hR_Employee)
    {
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        return sqlHR_EmployeeProvider.UpdateHR_Employee(hR_Employee);
    }

    public static bool UpdateHR_EmployeeName(HR_Employee hR_Employee)
    {
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        return sqlHR_EmployeeProvider.UpdateHR_EmployeeName(hR_Employee);
    }

    public static bool UpdateHR_EmployeeResignInfo(HR_Employee hR_Employee)
    {
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        return sqlHR_EmployeeProvider.UpdateHR_EmployeeResignInfo(hR_Employee);
    }

    public static bool DeleteHR_Employee(string hR_EmployeeID)
    {
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        return sqlHR_EmployeeProvider.DeleteHR_Employee(hR_EmployeeID);
    }

    public static bool DeleteHR_EmployeePermanently(string hR_EmployeeID)
    {
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        return sqlHR_EmployeeProvider.DeleteHR_EmployeePermanently(hR_EmployeeID);
    }

    public static bool DeleteHR_EmployeeChnageRowStatusID(string hR_EmployeeID)
    {
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        return sqlHR_EmployeeProvider.DeleteHR_EmployeeChnageRowStatusID(hR_EmployeeID);
    }


    public static HR_Employee ViewTeacherMoneyReceipt(string employeeID)
    {
        HR_Employee hR_Employee = new HR_Employee();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        hR_Employee = sqlHR_EmployeeProvider.ViewTeacherMoneyReceipt(employeeID);
        return hR_Employee;
    }

    public static DataTable GetEmployeeAdvanceSalaryInfo()
    {
        DataTable advanceSalary = new DataTable();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        advanceSalary = sqlHR_EmployeeProvider.GetEmployeeAdvanceSalaryInfo();
        return advanceSalary;

    }


    public static DataTable GetEmployeeSecurityAmountInfo()
    {
        DataTable advanceSalary = new DataTable();
        SqlHR_EmployeeProvider sqlHR_EmployeeProvider = new SqlHR_EmployeeProvider();
        advanceSalary = sqlHR_EmployeeProvider.GetEmployeeSecurityAmountInfo();
        return advanceSalary;

    }
}

