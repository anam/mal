using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_PackageRulesManager
{
	public HR_PackageRulesManager()
	{
	}

    public static DataSet  GetAllHR_PackageRuless()
    {
       DataSet hR_PackageRuless = new DataSet();
        SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
        hR_PackageRuless = sqlHR_PackageRulesProvider.GetAllHR_PackageRuless();
        return hR_PackageRuless;
    }
    public static DataSet GetAllHR_PackageRulessByPackageID(int PackageID)
    {
        DataSet hR_PackageRuless = new DataSet();
        SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
        hR_PackageRuless = sqlHR_PackageRulesProvider.GetAllHR_PackageRulessByPackageID(PackageID);
        return hR_PackageRuless;
    }

    //GetAllHR_PackageAndPackageRuless
    public static DataSet GetAllHR_PackageAndPackageRuless()
    {
        DataSet hR_PackageAndPackageRuless = new DataSet("HR_PackageAndPackageRuless");
        SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
        hR_PackageAndPackageRuless = sqlHR_PackageRulesProvider.GetAllHR_PackageAndPackageRuless();
        return hR_PackageAndPackageRuless;
    }

	public static void hR_PackageRulessPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_PackageRulesPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
		DataSet ds =  sqlHR_PackageRulesProvider.GetHR_PackageRulesPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_PackageRulessPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_PackageRules()
    {
       DataSet hR_PackageRuless = new DataSet();
        SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
        hR_PackageRuless = sqlHR_PackageRulesProvider.GetDropDownLisAllHR_PackageRules();
        return hR_PackageRuless;
    }


    public static HR_PackageRules GetHR_PackageByPackageID(int PackageID)
    {
        HR_PackageRules hR_PackageRules = new HR_PackageRules();
        SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
        hR_PackageRules = sqlHR_PackageRulesProvider.GetHR_PackageRulesByPackageID(PackageID);
        return hR_PackageRules;
    }


    public static HR_PackageRules GetHR_PackageRulesByPackageRulesID(int PackageRulesID)
    {
        HR_PackageRules hR_PackageRules = new HR_PackageRules();
        SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
        hR_PackageRules = sqlHR_PackageRulesProvider.GetHR_PackageRulesByPackageRulesID(PackageRulesID);
        return hR_PackageRules;
    }


    public static int InsertHR_PackageRules(HR_PackageRules hR_PackageRules)
    {
        SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
        return sqlHR_PackageRulesProvider.InsertHR_PackageRules(hR_PackageRules);
    }


    public static bool UpdateHR_PackageRules(HR_PackageRules hR_PackageRules)
    {
        SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
        return sqlHR_PackageRulesProvider.UpdateHR_PackageRules(hR_PackageRules);
    }

    public static bool DeleteHR_PackageRules(int hR_PackageRulesID)
    {
        SqlHR_PackageRulesProvider sqlHR_PackageRulesProvider = new SqlHR_PackageRulesProvider();
        return sqlHR_PackageRulesProvider.DeleteHR_PackageRules(hR_PackageRulesID);
    }
}

