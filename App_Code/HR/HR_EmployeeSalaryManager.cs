using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_EmployeeSalaryManager
{
	public HR_EmployeeSalaryManager()
	{
	}

    public static DataSet  GetAllHR_EmployeeSalaries()
    {
       DataSet hR_EmployeeSalaries = new DataSet();
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        hR_EmployeeSalaries = sqlHR_EmployeeSalaryProvider.GetAllHR_EmployeeSalaries();
        return hR_EmployeeSalaries;
    }

	public static void hR_EmployeeSalariesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_EmployeeSalaryPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
		DataSet ds =  sqlHR_EmployeeSalaryProvider.GetHR_EmployeeSalaryPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_EmployeeSalariesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_EmployeeSalary()
    {
       DataSet hR_EmployeeSalaries = new DataSet();
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        hR_EmployeeSalaries = sqlHR_EmployeeSalaryProvider.GetDropDownLisAllHR_EmployeeSalary();
        return hR_EmployeeSalaries;
    }

    public static DataSet   GetAllHR_EmployeeSalariesWithRelation()
    {
       DataSet hR_EmployeeSalaries = new DataSet();
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        hR_EmployeeSalaries = sqlHR_EmployeeSalaryProvider.GetAllHR_EmployeeSalaries();
        return hR_EmployeeSalaries;
    }


    public static HR_EmployeeSalary GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary();
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        hR_EmployeeSalary = sqlHR_EmployeeSalaryProvider.GetHR_EmployeeSalaryByEmployeeID(EmployeeID);
        return hR_EmployeeSalary;
    }


    public static HR_EmployeeSalary GetHR_EmployeeSalaryByEmployeeSalaryID(int EmployeeSalaryID)
    {
        HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary();
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        hR_EmployeeSalary = sqlHR_EmployeeSalaryProvider.GetHR_EmployeeSalaryByEmployeeSalaryID(EmployeeSalaryID);
        return hR_EmployeeSalary;
    }

    public static HR_EmployeeSalary GetHR_EmployeeSalaryByEmployeeID(string EmployeeID)
    {
        HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary();
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        hR_EmployeeSalary = sqlHR_EmployeeSalaryProvider.GetHR_EmployeeSalaryByEmployeeID(EmployeeID);
        return hR_EmployeeSalary;
    }

    public static DataSet GetHR_EmployeeBounusAll(int percentage)
    {
        DataSet hR_EmployeeSalary = new DataSet();
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        hR_EmployeeSalary = sqlHR_EmployeeSalaryProvider.GetHR_EmployeeBounusAll(percentage);
        return hR_EmployeeSalary;
    }


    public static bool IsEmployeeExist(string employeeID)
    {
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        return sqlHR_EmployeeSalaryProvider.IsEmployeeExist(employeeID);
    }

    public static int InsertHR_EmployeeSalary(HR_EmployeeSalary hR_EmployeeSalary)
    {
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        return sqlHR_EmployeeSalaryProvider.InsertHR_EmployeeSalary(hR_EmployeeSalary);
    }


    public static bool UpdateHR_EmployeeSalary(HR_EmployeeSalary hR_EmployeeSalary)
    {
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        return sqlHR_EmployeeSalaryProvider.UpdateHR_EmployeeSalary(hR_EmployeeSalary);
    }

    public static bool DeleteHR_EmployeeSalary(int hR_EmployeeSalaryID)
    {
        SqlHR_EmployeeSalaryProvider sqlHR_EmployeeSalaryProvider = new SqlHR_EmployeeSalaryProvider();
        return sqlHR_EmployeeSalaryProvider.DeleteHR_EmployeeSalary(hR_EmployeeSalaryID);
    }
}

