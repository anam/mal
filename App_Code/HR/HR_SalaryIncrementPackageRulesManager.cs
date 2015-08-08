using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryIncrementPackageRulesManager
{
	public HR_SalaryIncrementPackageRulesManager()
	{
	}

    public static DataSet  GetAllHR_SalaryIncrementPackageRuless()
    {
       DataSet hR_SalaryIncrementPackageRuless = new DataSet();
        SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
        hR_SalaryIncrementPackageRuless = sqlHR_SalaryIncrementPackageRulesProvider.GetAllHR_SalaryIncrementPackageRuless();
        return hR_SalaryIncrementPackageRuless;
    }

	public static void hR_SalaryIncrementPackageRulessPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_SalaryIncrementPackageRulesPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
		DataSet ds =  sqlHR_SalaryIncrementPackageRulesProvider.GetHR_SalaryIncrementPackageRulesPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_SalaryIncrementPackageRulessPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_SalaryIncrementPackageRules()
    {
       DataSet hR_SalaryIncrementPackageRuless = new DataSet();
        SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
        hR_SalaryIncrementPackageRuless = sqlHR_SalaryIncrementPackageRulesProvider.GetDropDownLisAllHR_SalaryIncrementPackageRules();
        return hR_SalaryIncrementPackageRuless;
    }


    public static HR_SalaryIncrementPackageRules GetHR_SalaryIncrementPackageRulesByEmployeeID(string EmployeeID)
    {
        HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules = new HR_SalaryIncrementPackageRules();
        SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
        hR_SalaryIncrementPackageRules = sqlHR_SalaryIncrementPackageRulesProvider.GetHR_SalaryIncrementPackageRulesByEmployeeID(EmployeeID);
        return hR_SalaryIncrementPackageRules;
    }


    public static HR_SalaryIncrementPackageRules GetHR_SalaryIncrementPackageBySalaryIncrementPackageID(int SalaryIncrementPackageID)
    {
        HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules = new HR_SalaryIncrementPackageRules();
        SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
        hR_SalaryIncrementPackageRules = sqlHR_SalaryIncrementPackageRulesProvider.GetHR_SalaryIncrementPackageRulesBySalaryIncrementPackageID(SalaryIncrementPackageID);
        return hR_SalaryIncrementPackageRules;
    }


    public static HR_SalaryIncrementPackageRules GetHR_SalaryIncrementPackageRulesBySalaryIncrementPackageRulesID(int SalaryIncrementPackageRulesID)
    {
        HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules = new HR_SalaryIncrementPackageRules();
        SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
        hR_SalaryIncrementPackageRules = sqlHR_SalaryIncrementPackageRulesProvider.GetHR_SalaryIncrementPackageRulesBySalaryIncrementPackageRulesID(SalaryIncrementPackageRulesID);
        return hR_SalaryIncrementPackageRules;
    }

    public static bool IsEmployeeExist(string employeeID)
    {
        SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
        return sqlHR_SalaryIncrementPackageRulesProvider.IsEmployeeExist(employeeID);
    }

    public static int InsertHR_SalaryIncrementPackageRules(HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules)
    {
        SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
        return sqlHR_SalaryIncrementPackageRulesProvider.InsertHR_SalaryIncrementPackageRules(hR_SalaryIncrementPackageRules);
    }


    public static bool UpdateHR_SalaryIncrementPackageRules(HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules)
    {
        SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
        return sqlHR_SalaryIncrementPackageRulesProvider.UpdateHR_SalaryIncrementPackageRules(hR_SalaryIncrementPackageRules);
    }

    public static bool DeleteHR_SalaryIncrementPackageRules(int hR_SalaryIncrementPackageRulesID)
    {
        SqlHR_SalaryIncrementPackageRulesProvider sqlHR_SalaryIncrementPackageRulesProvider = new SqlHR_SalaryIncrementPackageRulesProvider();
        return sqlHR_SalaryIncrementPackageRulesProvider.DeleteHR_SalaryIncrementPackageRules(hR_SalaryIncrementPackageRulesID);
    }
}

