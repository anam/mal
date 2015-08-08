using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_LeaveRuleManager
{
	public HR_LeaveRuleManager()
	{
	}

    public static DataSet  GetAllHR_LeaveRules()
    {
       DataSet hR_LeaveRules = new DataSet();
        SqlHR_LeaveRuleProvider sqlHR_LeaveRuleProvider = new SqlHR_LeaveRuleProvider();
        hR_LeaveRules = sqlHR_LeaveRuleProvider.GetAllHR_LeaveRules();
        return hR_LeaveRules;
    }

	public static void hR_LeaveRulesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_LeaveRulePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_LeaveRuleProvider sqlHR_LeaveRuleProvider = new SqlHR_LeaveRuleProvider();
		DataSet ds =  sqlHR_LeaveRuleProvider.GetHR_LeaveRulePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_LeaveRulesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_LeaveRule()
    {
       DataSet hR_LeaveRules = new DataSet();
        SqlHR_LeaveRuleProvider sqlHR_LeaveRuleProvider = new SqlHR_LeaveRuleProvider();
        hR_LeaveRules = sqlHR_LeaveRuleProvider.GetDropDownListAllHR_LeaveRule();
        return hR_LeaveRules;
    }

    public static DataSet   GetAllHR_LeaveRulesWithRelation()
    {
       DataSet hR_LeaveRules = new DataSet();
        SqlHR_LeaveRuleProvider sqlHR_LeaveRuleProvider = new SqlHR_LeaveRuleProvider();
        hR_LeaveRules = sqlHR_LeaveRuleProvider.GetAllHR_LeaveRules();
        return hR_LeaveRules;
    }


    public static HR_LeaveRule GetHR_LeaveRuleByLeaveRuleID(int LeaveRuleID)
    {
        HR_LeaveRule hR_LeaveRule = new HR_LeaveRule();
        SqlHR_LeaveRuleProvider sqlHR_LeaveRuleProvider = new SqlHR_LeaveRuleProvider();
        hR_LeaveRule = sqlHR_LeaveRuleProvider.GetHR_LeaveRuleByLeaveRuleID(LeaveRuleID);
        return hR_LeaveRule;
    }


    public static int InsertHR_LeaveRule(HR_LeaveRule hR_LeaveRule)
    {
        SqlHR_LeaveRuleProvider sqlHR_LeaveRuleProvider = new SqlHR_LeaveRuleProvider();
        return sqlHR_LeaveRuleProvider.InsertHR_LeaveRule(hR_LeaveRule);
    }


    public static bool UpdateHR_LeaveRule(HR_LeaveRule hR_LeaveRule)
    {
        SqlHR_LeaveRuleProvider sqlHR_LeaveRuleProvider = new SqlHR_LeaveRuleProvider();
        return sqlHR_LeaveRuleProvider.UpdateHR_LeaveRule(hR_LeaveRule);
    }

    public static bool DeleteHR_LeaveRule(int hR_LeaveRuleID)
    {
        SqlHR_LeaveRuleProvider sqlHR_LeaveRuleProvider = new SqlHR_LeaveRuleProvider();
        return sqlHR_LeaveRuleProvider.DeleteHR_LeaveRule(hR_LeaveRuleID);
    }
}

