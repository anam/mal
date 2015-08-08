using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_LeavesRuleEmployeeManager
{
	public HR_LeavesRuleEmployeeManager()
	{
	}

    public static DataSet  GetAllHR_LeavesRuleEmployees()
    {
       DataSet hR_LeavesRuleEmployees = new DataSet();
        SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
        hR_LeavesRuleEmployees = sqlHR_LeavesRuleEmployeeProvider.GetAllHR_LeavesRuleEmployees();
        return hR_LeavesRuleEmployees;
    }

	public static void hR_LeavesRuleEmployeesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_LeavesRuleEmployeePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
		DataSet ds =  sqlHR_LeavesRuleEmployeeProvider.GetHR_LeavesRuleEmployeePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_LeavesRuleEmployeesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_LeavesRuleEmployee()
    {
       DataSet hR_LeavesRuleEmployees = new DataSet();
        SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
        hR_LeavesRuleEmployees = sqlHR_LeavesRuleEmployeeProvider.GetDropDownListAllHR_LeavesRuleEmployee();
        return hR_LeavesRuleEmployees;
    }

    public static DataSet   GetAllHR_LeavesRuleEmployeesWithRelation()
    {
       DataSet hR_LeavesRuleEmployees = new DataSet();
        SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
        hR_LeavesRuleEmployees = sqlHR_LeavesRuleEmployeeProvider.GetAllHR_LeavesRuleEmployees();
        return hR_LeavesRuleEmployees;
    }


    public static HR_LeavesRuleEmployee GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_LeavesRuleEmployee hR_LeavesRuleEmployee = new HR_LeavesRuleEmployee();
        SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
        hR_LeavesRuleEmployee = sqlHR_LeavesRuleEmployeeProvider.GetHR_LeavesRuleEmployeeByEmployeeID(EmployeeID);
        return hR_LeavesRuleEmployee;
    }


    public static HR_LeavesRuleEmployee GetHR_LeaveRuleByLeaveRuleID(int LeaveRuleID)
    {
        HR_LeavesRuleEmployee hR_LeavesRuleEmployee = new HR_LeavesRuleEmployee();
        SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
        hR_LeavesRuleEmployee = sqlHR_LeavesRuleEmployeeProvider.GetHR_LeavesRuleEmployeeByLeaveRuleID(LeaveRuleID);
        return hR_LeavesRuleEmployee;
    }


    public static HR_LeavesRuleEmployee GetHR_LeavesRuleEmployeeByLeavesRuleEmployeeID(int LeavesRuleEmployeeID)
    {
        HR_LeavesRuleEmployee hR_LeavesRuleEmployee = new HR_LeavesRuleEmployee();
        SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
        hR_LeavesRuleEmployee = sqlHR_LeavesRuleEmployeeProvider.GetHR_LeavesRuleEmployeeByLeavesRuleEmployeeID(LeavesRuleEmployeeID);
        return hR_LeavesRuleEmployee;
    }


    public static int InsertHR_LeavesRuleEmployee(HR_LeavesRuleEmployee hR_LeavesRuleEmployee)
    {
        SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
        return sqlHR_LeavesRuleEmployeeProvider.InsertHR_LeavesRuleEmployee(hR_LeavesRuleEmployee);
    }


    public static bool UpdateHR_LeavesRuleEmployee(HR_LeavesRuleEmployee hR_LeavesRuleEmployee)
    {
        SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
        return sqlHR_LeavesRuleEmployeeProvider.UpdateHR_LeavesRuleEmployee(hR_LeavesRuleEmployee);
    }

    public static bool DeleteHR_LeavesRuleEmployee(int hR_LeavesRuleEmployeeID)
    {
        SqlHR_LeavesRuleEmployeeProvider sqlHR_LeavesRuleEmployeeProvider = new SqlHR_LeavesRuleEmployeeProvider();
        return sqlHR_LeavesRuleEmployeeProvider.DeleteHR_LeavesRuleEmployee(hR_LeavesRuleEmployeeID);
    }
}

