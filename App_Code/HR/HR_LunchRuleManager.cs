using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_LunchRuleManager
{
	public HR_LunchRuleManager()
	{
	}

    public static DataSet  GetAllHR_LunchRules()
    {
       DataSet hR_LunchRules = new DataSet();
        SqlHR_LunchRuleProvider sqlHR_LunchRuleProvider = new SqlHR_LunchRuleProvider();
        hR_LunchRules = sqlHR_LunchRuleProvider.GetAllHR_LunchRules();
        return hR_LunchRules;
    }

	public static void hR_LunchRulesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_LunchRulePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_LunchRuleProvider sqlHR_LunchRuleProvider = new SqlHR_LunchRuleProvider();
		DataSet ds =  sqlHR_LunchRuleProvider.GetHR_LunchRulePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_LunchRulesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_LunchRule()
    {
       DataSet hR_LunchRules = new DataSet();
        SqlHR_LunchRuleProvider sqlHR_LunchRuleProvider = new SqlHR_LunchRuleProvider();
        hR_LunchRules = sqlHR_LunchRuleProvider.GetDropDownLisAllHR_LunchRule();
        return hR_LunchRules;
    }

    public static DataSet   GetAllHR_LunchRulesWithRelation()
    {
       DataSet hR_LunchRules = new DataSet();
        SqlHR_LunchRuleProvider sqlHR_LunchRuleProvider = new SqlHR_LunchRuleProvider();
        hR_LunchRules = sqlHR_LunchRuleProvider.GetAllHR_LunchRules();
        return hR_LunchRules;
    }


    public static HR_LunchRule GetHR_LunchRuleByEmployeeID(string EmployeeID)
    {
        HR_LunchRule hR_LunchRules = new HR_LunchRule();
        SqlHR_LunchRuleProvider sqlHR_LunchRuleProvider = new SqlHR_LunchRuleProvider();
        hR_LunchRules = sqlHR_LunchRuleProvider.GetHR_LunchRuleByEmployeeID(EmployeeID);
        return hR_LunchRules;
    }


    public static HR_LunchRule GetHR_LunchRuleByLunchRuleID(int LunchRuleID)
    {
        HR_LunchRule hR_LunchRule = new HR_LunchRule();
        SqlHR_LunchRuleProvider sqlHR_LunchRuleProvider = new SqlHR_LunchRuleProvider();
        hR_LunchRule = sqlHR_LunchRuleProvider.GetHR_LunchRuleByLunchRuleID(LunchRuleID);
        return hR_LunchRule;
    }


    public static int InsertHR_LunchRule(HR_LunchRule hR_LunchRule)
    {
        SqlHR_LunchRuleProvider sqlHR_LunchRuleProvider = new SqlHR_LunchRuleProvider();
        return sqlHR_LunchRuleProvider.InsertHR_LunchRule(hR_LunchRule);
    }


    public static bool UpdateHR_LunchRule(HR_LunchRule hR_LunchRule)
    {
        SqlHR_LunchRuleProvider sqlHR_LunchRuleProvider = new SqlHR_LunchRuleProvider();
        return sqlHR_LunchRuleProvider.UpdateHR_LunchRule(hR_LunchRule);
    }

    public static bool DeleteHR_LunchRule(int hR_LunchRuleID)
    {
        SqlHR_LunchRuleProvider sqlHR_LunchRuleProvider = new SqlHR_LunchRuleProvider();
        return sqlHR_LunchRuleProvider.DeleteHR_LunchRule(hR_LunchRuleID);
    }
}

