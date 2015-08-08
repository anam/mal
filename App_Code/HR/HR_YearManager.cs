using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_YearManager
{
	public HR_YearManager()
	{
	}

    public static DataSet  GetAllHR_Years()
    {
       DataSet hR_Years = new DataSet();
        SqlHR_YearProvider sqlHR_YearProvider = new SqlHR_YearProvider();
        hR_Years = sqlHR_YearProvider.GetAllHR_Years();
        return hR_Years;
    }

	public static void hR_YearsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_YearPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_YearProvider sqlHR_YearProvider = new SqlHR_YearProvider();
		DataSet ds =  sqlHR_YearProvider.GetHR_YearPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_YearsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Year()
    {
       DataSet hR_Years = new DataSet();
        SqlHR_YearProvider sqlHR_YearProvider = new SqlHR_YearProvider();
        hR_Years = sqlHR_YearProvider.GetDropDownListAllHR_Year();
        return hR_Years;
    }


    public static HR_Year GetHR_YearByYearID(int YearID)
    {
        HR_Year hR_Year = new HR_Year();
        SqlHR_YearProvider sqlHR_YearProvider = new SqlHR_YearProvider();
        hR_Year = sqlHR_YearProvider.GetHR_YearByYearID(YearID);
        return hR_Year;
    }


    public static int InsertHR_Year(HR_Year hR_Year)
    {
        SqlHR_YearProvider sqlHR_YearProvider = new SqlHR_YearProvider();
        return sqlHR_YearProvider.InsertHR_Year(hR_Year);
    }


    public static bool UpdateHR_Year(HR_Year hR_Year)
    {
        SqlHR_YearProvider sqlHR_YearProvider = new SqlHR_YearProvider();
        return sqlHR_YearProvider.UpdateHR_Year(hR_Year);
    }

    public static bool DeleteHR_Year(int hR_YearID)
    {
        SqlHR_YearProvider sqlHR_YearProvider = new SqlHR_YearProvider();
        return sqlHR_YearProvider.DeleteHR_Year(hR_YearID);
    }
}

