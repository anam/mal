using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_RetirementsRuleEmployeeManager
{
	public HR_RetirementsRuleEmployeeManager()
	{
	}

    public static DataSet  GetAllHR_RetirementsRuleEmployees()
    {
       DataSet hR_RetirementsRuleEmployees = new DataSet();
        SqlHR_RetirementsRuleEmployeeProvider sqlHR_RetirementsRuleEmployeeProvider = new SqlHR_RetirementsRuleEmployeeProvider();
        hR_RetirementsRuleEmployees = sqlHR_RetirementsRuleEmployeeProvider.GetAllHR_RetirementsRuleEmployees();
        return hR_RetirementsRuleEmployees;
    }

	public static void hR_RetirementsRuleEmployeesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_RetirementsRuleEmployeePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_RetirementsRuleEmployeeProvider sqlHR_RetirementsRuleEmployeeProvider = new SqlHR_RetirementsRuleEmployeeProvider();
		DataSet ds =  sqlHR_RetirementsRuleEmployeeProvider.GetHR_RetirementsRuleEmployeePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_RetirementsRuleEmployeesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_RetirementsRuleEmployee()
    {
       DataSet hR_RetirementsRuleEmployees = new DataSet();
        SqlHR_RetirementsRuleEmployeeProvider sqlHR_RetirementsRuleEmployeeProvider = new SqlHR_RetirementsRuleEmployeeProvider();
        hR_RetirementsRuleEmployees = sqlHR_RetirementsRuleEmployeeProvider.GetDropDownListAllHR_RetirementsRuleEmployee();
        return hR_RetirementsRuleEmployees;
    }

    public static DataSet   GetAllHR_RetirementsRuleEmployeesWithRelation()
    {
       DataSet hR_RetirementsRuleEmployees = new DataSet();
        SqlHR_RetirementsRuleEmployeeProvider sqlHR_RetirementsRuleEmployeeProvider = new SqlHR_RetirementsRuleEmployeeProvider();
        hR_RetirementsRuleEmployees = sqlHR_RetirementsRuleEmployeeProvider.GetAllHR_RetirementsRuleEmployees();
        return hR_RetirementsRuleEmployees;
    }


    public static HR_RetirementsRuleEmployee GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_RetirementsRuleEmployee hR_RetirementsRuleEmployee = new HR_RetirementsRuleEmployee();
        SqlHR_RetirementsRuleEmployeeProvider sqlHR_RetirementsRuleEmployeeProvider = new SqlHR_RetirementsRuleEmployeeProvider();
        hR_RetirementsRuleEmployee = sqlHR_RetirementsRuleEmployeeProvider.GetHR_RetirementsRuleEmployeeByEmployeeID(EmployeeID);
        return hR_RetirementsRuleEmployee;
    }


    public static HR_RetirementsRuleEmployee GetHR_RetirementsRuleEmployeeByRetirementRulesID(int RetirementRulesID)
    {
        HR_RetirementsRuleEmployee hR_RetirementsRuleEmployee = new HR_RetirementsRuleEmployee();
        SqlHR_RetirementsRuleEmployeeProvider sqlHR_RetirementsRuleEmployeeProvider = new SqlHR_RetirementsRuleEmployeeProvider();
        hR_RetirementsRuleEmployee = sqlHR_RetirementsRuleEmployeeProvider.GetHR_RetirementsRuleEmployeeByRetirementRulesID(RetirementRulesID);
        return hR_RetirementsRuleEmployee;
    }


    public static int InsertHR_RetirementsRuleEmployee(HR_RetirementsRuleEmployee hR_RetirementsRuleEmployee)
    {
        SqlHR_RetirementsRuleEmployeeProvider sqlHR_RetirementsRuleEmployeeProvider = new SqlHR_RetirementsRuleEmployeeProvider();
        return sqlHR_RetirementsRuleEmployeeProvider.InsertHR_RetirementsRuleEmployee(hR_RetirementsRuleEmployee);
    }


    public static bool UpdateHR_RetirementsRuleEmployee(HR_RetirementsRuleEmployee hR_RetirementsRuleEmployee)
    {
        SqlHR_RetirementsRuleEmployeeProvider sqlHR_RetirementsRuleEmployeeProvider = new SqlHR_RetirementsRuleEmployeeProvider();
        return sqlHR_RetirementsRuleEmployeeProvider.UpdateHR_RetirementsRuleEmployee(hR_RetirementsRuleEmployee);
    }

    public static bool DeleteHR_RetirementsRuleEmployee(int hR_RetirementsRuleEmployeeID)
    {
        SqlHR_RetirementsRuleEmployeeProvider sqlHR_RetirementsRuleEmployeeProvider = new SqlHR_RetirementsRuleEmployeeProvider();
        return sqlHR_RetirementsRuleEmployeeProvider.DeleteHR_RetirementsRuleEmployee(hR_RetirementsRuleEmployeeID);
    }
}

