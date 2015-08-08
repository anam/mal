using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ProvidentfundRulesManager
{
	public HR_ProvidentfundRulesManager()
	{
	}

    public static DataSet  GetAllHR_ProvidentfundRuless()
    {
       DataSet hR_ProvidentfundRuless = new DataSet();
        SqlHR_ProvidentfundRulesProvider sqlHR_ProvidentfundRulesProvider = new SqlHR_ProvidentfundRulesProvider();
        hR_ProvidentfundRuless = sqlHR_ProvidentfundRulesProvider.GetAllHR_ProvidentfundRuless();
        return hR_ProvidentfundRuless;
    }

	public static void hR_ProvidentfundRulessPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_ProvidentfundRulesPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_ProvidentfundRulesProvider sqlHR_ProvidentfundRulesProvider = new SqlHR_ProvidentfundRulesProvider();
		DataSet ds =  sqlHR_ProvidentfundRulesProvider.GetHR_ProvidentfundRulesPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_ProvidentfundRulessPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_ProvidentfundRules()
    {
       DataSet hR_ProvidentfundRuless = new DataSet();
        SqlHR_ProvidentfundRulesProvider sqlHR_ProvidentfundRulesProvider = new SqlHR_ProvidentfundRulesProvider();
        hR_ProvidentfundRuless = sqlHR_ProvidentfundRulesProvider.GetDropDownLisAllHR_ProvidentfundRules();
        return hR_ProvidentfundRuless;
    }


    public static HR_ProvidentfundRules GetHR_ProvidentfundRulesByProvidentfundRulesID(int ProvidentfundRulesID)
    {
        HR_ProvidentfundRules hR_ProvidentfundRules = new HR_ProvidentfundRules();
        SqlHR_ProvidentfundRulesProvider sqlHR_ProvidentfundRulesProvider = new SqlHR_ProvidentfundRulesProvider();
        hR_ProvidentfundRules = sqlHR_ProvidentfundRulesProvider.GetHR_ProvidentfundRulesByProvidentfundRulesID(ProvidentfundRulesID);
        return hR_ProvidentfundRules;
    }


    public static int InsertHR_ProvidentfundRules(HR_ProvidentfundRules hR_ProvidentfundRules)
    {
        SqlHR_ProvidentfundRulesProvider sqlHR_ProvidentfundRulesProvider = new SqlHR_ProvidentfundRulesProvider();
        return sqlHR_ProvidentfundRulesProvider.InsertHR_ProvidentfundRules(hR_ProvidentfundRules);
    }


    public static bool UpdateHR_ProvidentfundRules(HR_ProvidentfundRules hR_ProvidentfundRules)
    {
        SqlHR_ProvidentfundRulesProvider sqlHR_ProvidentfundRulesProvider = new SqlHR_ProvidentfundRulesProvider();
        return sqlHR_ProvidentfundRulesProvider.UpdateHR_ProvidentfundRules(hR_ProvidentfundRules);
    }

    public static bool DeleteHR_ProvidentfundRules(int hR_ProvidentfundRulesID)
    {
        SqlHR_ProvidentfundRulesProvider sqlHR_ProvidentfundRulesProvider = new SqlHR_ProvidentfundRulesProvider();
        return sqlHR_ProvidentfundRulesProvider.DeleteHR_ProvidentfundRules(hR_ProvidentfundRulesID);
    }
}

