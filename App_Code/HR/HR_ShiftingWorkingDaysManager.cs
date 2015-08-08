using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ShiftingWorkingDaysManager
{
	public HR_ShiftingWorkingDaysManager()
	{
	}

    public static DataSet  GetAllHR_ShiftingWorkingDayss()
    {
       DataSet hR_ShiftingWorkingDayss = new DataSet();
        SqlHR_ShiftingWorkingDaysProvider sqlHR_ShiftingWorkingDaysProvider = new SqlHR_ShiftingWorkingDaysProvider();
        hR_ShiftingWorkingDayss = sqlHR_ShiftingWorkingDaysProvider.GetAllHR_ShiftingWorkingDayss();
        return hR_ShiftingWorkingDayss;
    }

	public static void hR_ShiftingWorkingDayssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_ShiftingWorkingDaysPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_ShiftingWorkingDaysProvider sqlHR_ShiftingWorkingDaysProvider = new SqlHR_ShiftingWorkingDaysProvider();
		DataSet ds =  sqlHR_ShiftingWorkingDaysProvider.GetHR_ShiftingWorkingDaysPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_ShiftingWorkingDayssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_ShiftingWorkingDays()
    {
       DataSet hR_ShiftingWorkingDayss = new DataSet();
        SqlHR_ShiftingWorkingDaysProvider sqlHR_ShiftingWorkingDaysProvider = new SqlHR_ShiftingWorkingDaysProvider();
        hR_ShiftingWorkingDayss = sqlHR_ShiftingWorkingDaysProvider.GetDropDownListAllHR_ShiftingWorkingDays();
        return hR_ShiftingWorkingDayss;
    }


    public static HR_ShiftingWorkingDays GetHR_ShiftingWorkingDaysByShiftingWorkingDaysID(int ShiftingWorkingDaysID)
    {
        HR_ShiftingWorkingDays hR_ShiftingWorkingDays = new HR_ShiftingWorkingDays();
        SqlHR_ShiftingWorkingDaysProvider sqlHR_ShiftingWorkingDaysProvider = new SqlHR_ShiftingWorkingDaysProvider();
        hR_ShiftingWorkingDays = sqlHR_ShiftingWorkingDaysProvider.GetHR_ShiftingWorkingDaysByShiftingWorkingDaysID(ShiftingWorkingDaysID);
        return hR_ShiftingWorkingDays;
    }


    public static int InsertHR_ShiftingWorkingDays(HR_ShiftingWorkingDays hR_ShiftingWorkingDays)
    {
        SqlHR_ShiftingWorkingDaysProvider sqlHR_ShiftingWorkingDaysProvider = new SqlHR_ShiftingWorkingDaysProvider();
        return sqlHR_ShiftingWorkingDaysProvider.InsertHR_ShiftingWorkingDays(hR_ShiftingWorkingDays);
    }


    public static bool UpdateHR_ShiftingWorkingDays(HR_ShiftingWorkingDays hR_ShiftingWorkingDays)
    {
        SqlHR_ShiftingWorkingDaysProvider sqlHR_ShiftingWorkingDaysProvider = new SqlHR_ShiftingWorkingDaysProvider();
        return sqlHR_ShiftingWorkingDaysProvider.UpdateHR_ShiftingWorkingDays(hR_ShiftingWorkingDays);
    }

    public static bool DeleteHR_ShiftingWorkingDays(int hR_ShiftingWorkingDaysID)
    {
        SqlHR_ShiftingWorkingDaysProvider sqlHR_ShiftingWorkingDaysProvider = new SqlHR_ShiftingWorkingDaysProvider();
        return sqlHR_ShiftingWorkingDaysProvider.DeleteHR_ShiftingWorkingDays(hR_ShiftingWorkingDaysID);
    }
}

