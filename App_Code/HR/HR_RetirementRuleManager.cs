using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_RetirementRuleManager
{
	public HR_RetirementRuleManager()
	{
	}

    public static DataSet  GetAllHR_RetirementRules()
    {
       DataSet hR_RetirementRules = new DataSet();
        SqlHR_RetirementRuleProvider sqlHR_RetirementRuleProvider = new SqlHR_RetirementRuleProvider();
        hR_RetirementRules = sqlHR_RetirementRuleProvider.GetAllHR_RetirementRules();
        return hR_RetirementRules;
    }

	public static void hR_RetirementRulesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_RetirementRulePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_RetirementRuleProvider sqlHR_RetirementRuleProvider = new SqlHR_RetirementRuleProvider();
		DataSet ds =  sqlHR_RetirementRuleProvider.GetHR_RetirementRulePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_RetirementRulesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_RetirementRule()
    {
       DataSet hR_RetirementRules = new DataSet();
        SqlHR_RetirementRuleProvider sqlHR_RetirementRuleProvider = new SqlHR_RetirementRuleProvider();
        hR_RetirementRules = sqlHR_RetirementRuleProvider.GetDropDownListAllHR_RetirementRule();
        return hR_RetirementRules;
    }


    public static HR_RetirementRule GetHR_RetirementRuleByRetirementRuleID(int RetirementRuleID)
    {
        HR_RetirementRule hR_RetirementRule = new HR_RetirementRule();
        SqlHR_RetirementRuleProvider sqlHR_RetirementRuleProvider = new SqlHR_RetirementRuleProvider();
        hR_RetirementRule = sqlHR_RetirementRuleProvider.GetHR_RetirementRuleByRetirementRuleID(RetirementRuleID);
        return hR_RetirementRule;
    }


    public static int InsertHR_RetirementRule(HR_RetirementRule hR_RetirementRule)
    {
        SqlHR_RetirementRuleProvider sqlHR_RetirementRuleProvider = new SqlHR_RetirementRuleProvider();
        return sqlHR_RetirementRuleProvider.InsertHR_RetirementRule(hR_RetirementRule);
    }


    public static bool UpdateHR_RetirementRule(HR_RetirementRule hR_RetirementRule)
    {
        SqlHR_RetirementRuleProvider sqlHR_RetirementRuleProvider = new SqlHR_RetirementRuleProvider();
        return sqlHR_RetirementRuleProvider.UpdateHR_RetirementRule(hR_RetirementRule);
    }

    public static bool DeleteHR_RetirementRule(int hR_RetirementRuleID)
    {
        SqlHR_RetirementRuleProvider sqlHR_RetirementRuleProvider = new SqlHR_RetirementRuleProvider();
        return sqlHR_RetirementRuleProvider.DeleteHR_RetirementRule(hR_RetirementRuleID);
    }
}

