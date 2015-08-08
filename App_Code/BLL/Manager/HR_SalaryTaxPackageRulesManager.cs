using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryTaxPackageRulesManager
{
	public HR_SalaryTaxPackageRulesManager()
	{
	}

    public static DataSet  GetAllHR_SalaryTaxPackageRuless()
    {
       DataSet hR_SalaryTaxPackageRuless = new DataSet();
        SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
        hR_SalaryTaxPackageRuless = sqlHR_SalaryTaxPackageRulesProvider.GetAllHR_SalaryTaxPackageRuless();
        return hR_SalaryTaxPackageRuless;
    }

	public static void hR_SalaryTaxPackageRulessPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_SalaryTaxPackageRulesPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
		DataSet ds =  sqlHR_SalaryTaxPackageRulesProvider.GetHR_SalaryTaxPackageRulesPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_SalaryTaxPackageRulessPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_SalaryTaxPackageRules()
    {
       DataSet hR_SalaryTaxPackageRuless = new DataSet();
        SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
        hR_SalaryTaxPackageRuless = sqlHR_SalaryTaxPackageRulesProvider.GetDropDownLisAllHR_SalaryTaxPackageRules();
        return hR_SalaryTaxPackageRuless;
    }


    public static HR_SalaryTaxPackageRules GetHR_SalaryTaxPackageRulesByEmployeeID(string EmployeeID)
    {
        HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules = new HR_SalaryTaxPackageRules();
        SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
        hR_SalaryTaxPackageRules = sqlHR_SalaryTaxPackageRulesProvider.GetHR_SalaryTaxPackageRulesByEmployeeID(EmployeeID);
        return hR_SalaryTaxPackageRules;
    }


    public static HR_SalaryTaxPackageRules GetHR_SalaryTaxPackageBySalaryTaxPackageID(int SalaryTaxPackageID)
    {
        HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules = new HR_SalaryTaxPackageRules();
        SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
        hR_SalaryTaxPackageRules = sqlHR_SalaryTaxPackageRulesProvider.GetHR_SalaryTaxPackageRulesBySalaryTaxPackageID(SalaryTaxPackageID);
        return hR_SalaryTaxPackageRules;
    }


    public static HR_SalaryTaxPackageRules GetHR_SalaryTaxPackageRulesBySalaryTaxPackageRulesID(int SalaryTaxPackageRulesID)
    {
        HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules = new HR_SalaryTaxPackageRules();
        SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
        hR_SalaryTaxPackageRules = sqlHR_SalaryTaxPackageRulesProvider.GetHR_SalaryTaxPackageRulesBySalaryTaxPackageRulesID(SalaryTaxPackageRulesID);
        return hR_SalaryTaxPackageRules;
    }

    public static bool IsEmployeeExist(string employeeID)
    {
        SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
        return sqlHR_SalaryTaxPackageRulesProvider.IsEmployeeExist(employeeID);
    }

    public static int InsertHR_SalaryTaxPackageRules(HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules)
    {
        SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
        return sqlHR_SalaryTaxPackageRulesProvider.InsertHR_SalaryTaxPackageRules(hR_SalaryTaxPackageRules);
    }


    public static bool UpdateHR_SalaryTaxPackageRules(HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules)
    {
        SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
        return sqlHR_SalaryTaxPackageRulesProvider.UpdateHR_SalaryTaxPackageRules(hR_SalaryTaxPackageRules);
    }

    public static bool DeleteHR_SalaryTaxPackageRules(int hR_SalaryTaxPackageRulesID)
    {
        SqlHR_SalaryTaxPackageRulesProvider sqlHR_SalaryTaxPackageRulesProvider = new SqlHR_SalaryTaxPackageRulesProvider();
        return sqlHR_SalaryTaxPackageRulesProvider.DeleteHR_SalaryTaxPackageRules(hR_SalaryTaxPackageRulesID);
    }
}

