using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_LunchTimeRuleManager
{
	public HR_LunchTimeRuleManager()
	{
	}

    public static DataSet  GetAllHR_LunchTimeRules()
    {
       DataSet hR_LunchTimeRules = new DataSet();
        SqlHR_LunchTimeRuleProvider sqlHR_LunchTimeRuleProvider = new SqlHR_LunchTimeRuleProvider();
        hR_LunchTimeRules = sqlHR_LunchTimeRuleProvider.GetAllHR_LunchTimeRules();
        return hR_LunchTimeRules;
    }

	public static void hR_LunchTimeRulesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_LunchTimeRulePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_LunchTimeRuleProvider sqlHR_LunchTimeRuleProvider = new SqlHR_LunchTimeRuleProvider();
		DataSet ds =  sqlHR_LunchTimeRuleProvider.GetHR_LunchTimeRulePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_LunchTimeRulesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_LunchTimeRule()
    {
       DataSet hR_LunchTimeRules = new DataSet();
        SqlHR_LunchTimeRuleProvider sqlHR_LunchTimeRuleProvider = new SqlHR_LunchTimeRuleProvider();
        hR_LunchTimeRules = sqlHR_LunchTimeRuleProvider.GetDropDownListAllHR_LunchTimeRule();
        return hR_LunchTimeRules;
    }


    public static HR_LunchTimeRule GetHR_LunchTimeRuleByLunchTimeRuleID(int LunchTimeRuleID)
    {
        HR_LunchTimeRule hR_LunchTimeRule = new HR_LunchTimeRule();
        SqlHR_LunchTimeRuleProvider sqlHR_LunchTimeRuleProvider = new SqlHR_LunchTimeRuleProvider();
        hR_LunchTimeRule = sqlHR_LunchTimeRuleProvider.GetHR_LunchTimeRuleByLunchTimeRuleID(LunchTimeRuleID);
        return hR_LunchTimeRule;
    }


    public static int InsertHR_LunchTimeRule(HR_LunchTimeRule hR_LunchTimeRule)
    {
        SqlHR_LunchTimeRuleProvider sqlHR_LunchTimeRuleProvider = new SqlHR_LunchTimeRuleProvider();
        return sqlHR_LunchTimeRuleProvider.InsertHR_LunchTimeRule(hR_LunchTimeRule);
    }


    public static bool UpdateHR_LunchTimeRule(HR_LunchTimeRule hR_LunchTimeRule)
    {
        SqlHR_LunchTimeRuleProvider sqlHR_LunchTimeRuleProvider = new SqlHR_LunchTimeRuleProvider();
        return sqlHR_LunchTimeRuleProvider.UpdateHR_LunchTimeRule(hR_LunchTimeRule);
    }

    public static bool DeleteHR_LunchTimeRule(int hR_LunchTimeRuleID)
    {
        SqlHR_LunchTimeRuleProvider sqlHR_LunchTimeRuleProvider = new SqlHR_LunchTimeRuleProvider();
        return sqlHR_LunchTimeRuleProvider.DeleteHR_LunchTimeRule(hR_LunchTimeRuleID);
    }
}

