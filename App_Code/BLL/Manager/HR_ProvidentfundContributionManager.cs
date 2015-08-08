using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ProvidentfundContributionManager
{
	public HR_ProvidentfundContributionManager()
	{
	}

    public static DataSet  GetAllHR_ProvidentfundContributions()
    {
       DataSet hR_ProvidentfundContributions = new DataSet();
        SqlHR_ProvidentfundContributionProvider sqlHR_ProvidentfundContributionProvider = new SqlHR_ProvidentfundContributionProvider();
        hR_ProvidentfundContributions = sqlHR_ProvidentfundContributionProvider.GetAllHR_ProvidentfundContributions();
        return hR_ProvidentfundContributions;
    }

	public static void hR_ProvidentfundContributionsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_ProvidentfundContributionPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_ProvidentfundContributionProvider sqlHR_ProvidentfundContributionProvider = new SqlHR_ProvidentfundContributionProvider();
		DataSet ds =  sqlHR_ProvidentfundContributionProvider.GetHR_ProvidentfundContributionPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_ProvidentfundContributionsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_ProvidentfundContribution()
    {
       DataSet hR_ProvidentfundContributions = new DataSet();
        SqlHR_ProvidentfundContributionProvider sqlHR_ProvidentfundContributionProvider = new SqlHR_ProvidentfundContributionProvider();
        hR_ProvidentfundContributions = sqlHR_ProvidentfundContributionProvider.GetDropDownLisAllHR_ProvidentfundContribution();
        return hR_ProvidentfundContributions;
    }


    public static HR_ProvidentfundContribution GetHR_ProvidentfundContributionByEmployeeID(string EmployeeID)
    {
        HR_ProvidentfundContribution hR_ProvidentfundContribution = new HR_ProvidentfundContribution();
        SqlHR_ProvidentfundContributionProvider sqlHR_ProvidentfundContributionProvider = new SqlHR_ProvidentfundContributionProvider();
        hR_ProvidentfundContribution = sqlHR_ProvidentfundContributionProvider.GetHR_ProvidentfundContributionByEmployeeID(EmployeeID);
        return hR_ProvidentfundContribution;
    }


    public static HR_ProvidentfundContribution GetHR_ProvidentfundContributionByProvidentfundContributionID(int ProvidentfundContributionID)
    {
        HR_ProvidentfundContribution hR_ProvidentfundContribution = new HR_ProvidentfundContribution();
        SqlHR_ProvidentfundContributionProvider sqlHR_ProvidentfundContributionProvider = new SqlHR_ProvidentfundContributionProvider();
        hR_ProvidentfundContribution = sqlHR_ProvidentfundContributionProvider.GetHR_ProvidentfundContributionByProvidentfundContributionID(ProvidentfundContributionID);
        return hR_ProvidentfundContribution;
    }

    public static bool IsEmployeeExist(string employeeID)
    {
        SqlHR_ProvidentfundContributionProvider sqlHR_ProvidentfundContributionProvider = new SqlHR_ProvidentfundContributionProvider();
        return sqlHR_ProvidentfundContributionProvider.IsEmployeeExist(employeeID);
    }

    public static int InsertHR_ProvidentfundContribution(HR_ProvidentfundContribution hR_ProvidentfundContribution)
    {
        SqlHR_ProvidentfundContributionProvider sqlHR_ProvidentfundContributionProvider = new SqlHR_ProvidentfundContributionProvider();
        return sqlHR_ProvidentfundContributionProvider.InsertHR_ProvidentfundContribution(hR_ProvidentfundContribution);
    }


    public static bool UpdateHR_ProvidentfundContribution(HR_ProvidentfundContribution hR_ProvidentfundContribution)
    {
        SqlHR_ProvidentfundContributionProvider sqlHR_ProvidentfundContributionProvider = new SqlHR_ProvidentfundContributionProvider();
        return sqlHR_ProvidentfundContributionProvider.UpdateHR_ProvidentfundContribution(hR_ProvidentfundContribution);
    }

    public static bool DeleteHR_ProvidentfundContribution(int hR_ProvidentfundContributionID)
    {
        SqlHR_ProvidentfundContributionProvider sqlHR_ProvidentfundContributionProvider = new SqlHR_ProvidentfundContributionProvider();
        return sqlHR_ProvidentfundContributionProvider.DeleteHR_ProvidentfundContribution(hR_ProvidentfundContributionID);
    }
}

