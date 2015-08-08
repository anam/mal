using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_CalenderHolidaysManager
{
	public HR_CalenderHolidaysManager()
	{
	}

    public static DataSet  GetAllHR_CalenderHolidayss()
    {
       DataSet hR_CalenderHolidayss = new DataSet();
        SqlHR_CalenderHolidaysProvider sqlHR_CalenderHolidaysProvider = new SqlHR_CalenderHolidaysProvider();
        hR_CalenderHolidayss = sqlHR_CalenderHolidaysProvider.GetAllHR_CalenderHolidayss();
        return hR_CalenderHolidayss;
    }

	public static void hR_CalenderHolidayssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_CalenderHolidaysPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_CalenderHolidaysProvider sqlHR_CalenderHolidaysProvider = new SqlHR_CalenderHolidaysProvider();
		DataSet ds =  sqlHR_CalenderHolidaysProvider.GetHR_CalenderHolidaysPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_CalenderHolidayssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_CalenderHolidays()
    {
       DataSet hR_CalenderHolidayss = new DataSet();
        SqlHR_CalenderHolidaysProvider sqlHR_CalenderHolidaysProvider = new SqlHR_CalenderHolidaysProvider();
        hR_CalenderHolidayss = sqlHR_CalenderHolidaysProvider.GetDropDownListAllHR_CalenderHolidays();
        return hR_CalenderHolidayss;
    }


    public static HR_CalenderHolidays GetHR_CalenderHolidaysByHolyDayID(int HolyDayID)
    {
        HR_CalenderHolidays hR_CalenderHolidays = new HR_CalenderHolidays();
        SqlHR_CalenderHolidaysProvider sqlHR_CalenderHolidaysProvider = new SqlHR_CalenderHolidaysProvider();
        hR_CalenderHolidays = sqlHR_CalenderHolidaysProvider.GetHR_CalenderHolidaysByHolyDayID(HolyDayID);
        return hR_CalenderHolidays;
    }


    public static int InsertHR_CalenderHolidays(HR_CalenderHolidays hR_CalenderHolidays)
    {
        SqlHR_CalenderHolidaysProvider sqlHR_CalenderHolidaysProvider = new SqlHR_CalenderHolidaysProvider();
        return sqlHR_CalenderHolidaysProvider.InsertHR_CalenderHolidays(hR_CalenderHolidays);
    }


    public static bool UpdateHR_CalenderHolidays(HR_CalenderHolidays hR_CalenderHolidays)
    {
        SqlHR_CalenderHolidaysProvider sqlHR_CalenderHolidaysProvider = new SqlHR_CalenderHolidaysProvider();
        return sqlHR_CalenderHolidaysProvider.UpdateHR_CalenderHolidays(hR_CalenderHolidays);
    }

    public static bool DeleteHR_CalenderHolidays(int hR_CalenderHolidaysID)
    {
        SqlHR_CalenderHolidaysProvider sqlHR_CalenderHolidaysProvider = new SqlHR_CalenderHolidaysProvider();
        return sqlHR_CalenderHolidaysProvider.DeleteHR_CalenderHolidays(hR_CalenderHolidaysID);
    }
}

