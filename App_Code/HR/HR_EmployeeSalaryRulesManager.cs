using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_EmployeeSalaryRulesManager
{
	public HR_EmployeeSalaryRulesManager()
	{
	}

    public static DataSet  GetAllHR_EmployeeSalaryRuless()
    {
       DataSet hR_EmployeeSalaryRuless = new DataSet();
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        hR_EmployeeSalaryRuless = sqlHR_EmployeeSalaryRulesProvider.GetAllHR_EmployeeSalaryRuless();
        return hR_EmployeeSalaryRuless;
    }

    public static DataSet GetAllHR_EmployeeSalaryRulessByEmployeeID(string employeeID)
    {
        DataSet hR_EmployeeSalaryRuless = new DataSet();
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        hR_EmployeeSalaryRuless = sqlHR_EmployeeSalaryRulesProvider.GetAllHR_EmployeeSalaryRuless();
        return hR_EmployeeSalaryRuless;
    }

	public static void hR_EmployeeSalaryRulessPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_EmployeeSalaryRulesPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
		DataSet ds =  sqlHR_EmployeeSalaryRulesProvider.GetHR_EmployeeSalaryRulesPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_EmployeeSalaryRulessPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_EmployeeSalaryRules()
    {
       DataSet hR_EmployeeSalaryRuless = new DataSet();
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        hR_EmployeeSalaryRuless = sqlHR_EmployeeSalaryRulesProvider.GetDropDownLisAllHR_EmployeeSalaryRules();
        return hR_EmployeeSalaryRuless;
    }

    public static DataSet   GetAllHR_EmployeeSalaryRulessWithRelation()
    {
       DataSet hR_EmployeeSalaryRuless = new DataSet();
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        hR_EmployeeSalaryRuless = sqlHR_EmployeeSalaryRulesProvider.GetAllHR_EmployeeSalaryRuless();
        return hR_EmployeeSalaryRuless;
    }


    //public static IList<HR_EmployeeSalaryRules> GetHR_EmployeeSalaryRulesByEmployeeID(string EmployeeID)
    //{
    //    IList<HR_EmployeeSalaryRules> hR_EmployeeSalaryRulesColl = new IList<HR_EmployeeSalaryRules>();
    //    SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
    //    hR_EmployeeSalaryRulesColl = sqlHR_EmployeeSalaryRulesProvider.GetHR_EmployeeSalaryRulesByEmployeeID(EmployeeID);
    //    return hR_EmployeeSalaryRulesColl;
    //}

    public static HR_EmployeeSalaryRules GetHR_EmployeeSalaryRulesObjectByEmployeeID(string EmployeeID)
    {
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        HR_EmployeeSalaryRules hR_EmployeeSalaryRules = sqlHR_EmployeeSalaryRulesProvider.GetHR_EmployeeSalaryRulesObjectByEmployeeID(EmployeeID);
        return hR_EmployeeSalaryRules;
    }

    public static DataSet GetHR_EmployeeSalaryRulesByEmployeeID(string EmployeeID)
    {
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        DataSet hR_EmployeeSalaryRulesDataSet = sqlHR_EmployeeSalaryRulesProvider.GetHR_EmployeeSalaryRulesByEmployeeID(EmployeeID);
        return hR_EmployeeSalaryRulesDataSet;
    }

    public static HR_EmployeeSalaryRules GetHR_PackageRulesByPackageRulesID(int PackageRulesID)
    {
        HR_EmployeeSalaryRules hR_EmployeeSalaryRules = new HR_EmployeeSalaryRules();
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        hR_EmployeeSalaryRules = sqlHR_EmployeeSalaryRulesProvider.GetHR_EmployeeSalaryRulesByPackageRulesID(PackageRulesID);
        return hR_EmployeeSalaryRules;
    }


    public static HR_EmployeeSalaryRules GetHR_EmployeeSalaryRulesByEmployeeSalaryPackageRulesID(int EmployeeSalaryPackageRulesID)
    {
        HR_EmployeeSalaryRules hR_EmployeeSalaryRules = new HR_EmployeeSalaryRules();
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        hR_EmployeeSalaryRules = sqlHR_EmployeeSalaryRulesProvider.GetHR_EmployeeSalaryRulesByEmployeeSalaryPackageRulesID(EmployeeSalaryPackageRulesID);
        return hR_EmployeeSalaryRules;
    }

    public static bool IsEmployeeExist(string employeeID)
    {
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        return sqlHR_EmployeeSalaryRulesProvider.IsEmployeeExist(employeeID);
    }

    public static int InsertHR_EmployeeSalaryRules(HR_EmployeeSalaryRules hR_EmployeeSalaryRules)
    {
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        return sqlHR_EmployeeSalaryRulesProvider.InsertHR_EmployeeSalaryRules(hR_EmployeeSalaryRules);
    }


    public static bool UpdateHR_EmployeeSalaryRules(HR_EmployeeSalaryRules hR_EmployeeSalaryRules)
    {
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        return sqlHR_EmployeeSalaryRulesProvider.UpdateHR_EmployeeSalaryRules(hR_EmployeeSalaryRules);
    }

    public static bool DeleteHR_EmployeeSalaryRules(int hR_EmployeeSalaryRulesID)
    {
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        return sqlHR_EmployeeSalaryRulesProvider.DeleteHR_EmployeeSalaryRules(hR_EmployeeSalaryRulesID);
    }

    public static bool DeleteHR_EmployeeSalaryRulesByEmployeeID(string employeeID)
    {
        SqlHR_EmployeeSalaryRulesProvider sqlHR_EmployeeSalaryRulesProvider = new SqlHR_EmployeeSalaryRulesProvider();
        return sqlHR_EmployeeSalaryRulesProvider.DeleteHR_EmployeeSalaryRulesByEmployeeID(employeeID);
    }
}

