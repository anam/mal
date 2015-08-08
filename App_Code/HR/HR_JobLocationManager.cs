using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_JobLocationManager
{
	public HR_JobLocationManager()
	{
	}

    public static DataSet  GetAllHR_JobLocations()
    {
       DataSet hR_JobLocations = new DataSet();
        SqlHR_JobLocationProvider sqlHR_JobLocationProvider = new SqlHR_JobLocationProvider();
        hR_JobLocations = sqlHR_JobLocationProvider.GetAllHR_JobLocations();
        return hR_JobLocations;
    }

	public static void hR_JobLocationsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_JobLocationPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_JobLocationProvider sqlHR_JobLocationProvider = new SqlHR_JobLocationProvider();
		DataSet ds =  sqlHR_JobLocationProvider.GetHR_JobLocationPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_JobLocationsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_JobLocation()
    {
       DataSet hR_JobLocations = new DataSet();
        SqlHR_JobLocationProvider sqlHR_JobLocationProvider = new SqlHR_JobLocationProvider();
        hR_JobLocations = sqlHR_JobLocationProvider.GetDropDownListAllHR_JobLocation();
        return hR_JobLocations;
    }


    public static HR_JobLocation GetHR_JobLocationByJobLocationID(int JobLocationID)
    {
        HR_JobLocation hR_JobLocation = new HR_JobLocation();
        SqlHR_JobLocationProvider sqlHR_JobLocationProvider = new SqlHR_JobLocationProvider();
        hR_JobLocation = sqlHR_JobLocationProvider.GetHR_JobLocationByJobLocationID(JobLocationID);
        return hR_JobLocation;
    }


    public static int InsertHR_JobLocation(HR_JobLocation hR_JobLocation)
    {
        SqlHR_JobLocationProvider sqlHR_JobLocationProvider = new SqlHR_JobLocationProvider();
        return sqlHR_JobLocationProvider.InsertHR_JobLocation(hR_JobLocation);
    }


    public static bool UpdateHR_JobLocation(HR_JobLocation hR_JobLocation)
    {
        SqlHR_JobLocationProvider sqlHR_JobLocationProvider = new SqlHR_JobLocationProvider();
        return sqlHR_JobLocationProvider.UpdateHR_JobLocation(hR_JobLocation);
    }

    public static bool DeleteHR_JobLocation(int hR_JobLocationID)
    {
        SqlHR_JobLocationProvider sqlHR_JobLocationProvider = new SqlHR_JobLocationProvider();
        return sqlHR_JobLocationProvider.DeleteHR_JobLocation(hR_JobLocationID);
    }
}

