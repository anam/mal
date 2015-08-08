using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_JobResponsibilityManager
{
	public HR_JobResponsibilityManager()
	{
	}

    public static DataSet  GetAllHR_JobResponsibilities()
    {
       DataSet hR_JobResponsibilities = new DataSet();
        SqlHR_JobResponsibilityProvider sqlHR_JobResponsibilityProvider = new SqlHR_JobResponsibilityProvider();
        hR_JobResponsibilities = sqlHR_JobResponsibilityProvider.GetAllHR_JobResponsibilities();
        return hR_JobResponsibilities;
    }

	public static void hR_JobResponsibilitiesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_JobResponsibilityPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_JobResponsibilityProvider sqlHR_JobResponsibilityProvider = new SqlHR_JobResponsibilityProvider();
		DataSet ds =  sqlHR_JobResponsibilityProvider.GetHR_JobResponsibilityPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_JobResponsibilitiesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_JobResponsibility()
    {
       DataSet hR_JobResponsibilities = new DataSet();
        SqlHR_JobResponsibilityProvider sqlHR_JobResponsibilityProvider = new SqlHR_JobResponsibilityProvider();
        hR_JobResponsibilities = sqlHR_JobResponsibilityProvider.GetDropDownListAllHR_JobResponsibility();
        return hR_JobResponsibilities;
    }


    public static HR_JobResponsibility GetHR_JobResponsibilityByJobResponsibilityID(int JobResponsibilityID)
    {
        HR_JobResponsibility hR_JobResponsibility = new HR_JobResponsibility();
        SqlHR_JobResponsibilityProvider sqlHR_JobResponsibilityProvider = new SqlHR_JobResponsibilityProvider();
        hR_JobResponsibility = sqlHR_JobResponsibilityProvider.GetHR_JobResponsibilityByJobResponsibilityID(JobResponsibilityID);
        return hR_JobResponsibility;
    }


    public static int InsertHR_JobResponsibility(HR_JobResponsibility hR_JobResponsibility)
    {
        SqlHR_JobResponsibilityProvider sqlHR_JobResponsibilityProvider = new SqlHR_JobResponsibilityProvider();
        return sqlHR_JobResponsibilityProvider.InsertHR_JobResponsibility(hR_JobResponsibility);
    }


    public static bool UpdateHR_JobResponsibility(HR_JobResponsibility hR_JobResponsibility)
    {
        SqlHR_JobResponsibilityProvider sqlHR_JobResponsibilityProvider = new SqlHR_JobResponsibilityProvider();
        return sqlHR_JobResponsibilityProvider.UpdateHR_JobResponsibility(hR_JobResponsibility);
    }

    public static bool DeleteHR_JobResponsibility(int hR_JobResponsibilityID)
    {
        SqlHR_JobResponsibilityProvider sqlHR_JobResponsibilityProvider = new SqlHR_JobResponsibilityProvider();
        return sqlHR_JobResponsibilityProvider.DeleteHR_JobResponsibility(hR_JobResponsibilityID);
    }
}

