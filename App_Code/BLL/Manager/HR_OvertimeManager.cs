using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_OvertimeManager
{
	public HR_OvertimeManager()
	{
	}

    public static DataSet  GetAllHR_Overtimes()
    {
       DataSet hR_Overtimes = new DataSet();
        SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
        hR_Overtimes = sqlHR_OvertimeProvider.GetAllHR_Overtimes();
        return hR_Overtimes;
    }

	public static void hR_OvertimesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_OvertimePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
		DataSet ds =  sqlHR_OvertimeProvider.GetHR_OvertimePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_OvertimesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Overtime()
    {
       DataSet hR_Overtimes = new DataSet();
        SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
        hR_Overtimes = sqlHR_OvertimeProvider.GetDropDownLisAllHR_Overtime();
        return hR_Overtimes;
    }

    public static DataSet   GetAllHR_OvertimesWithRelation()
    {
       DataSet hR_Overtimes = new DataSet();
        SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
        hR_Overtimes = sqlHR_OvertimeProvider.GetAllHR_Overtimes();
        return hR_Overtimes;
    }


    public static HR_Overtime GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_Overtime hR_Overtime = new HR_Overtime();
        SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
        hR_Overtime = sqlHR_OvertimeProvider.GetHR_OvertimeByEmployeeID(EmployeeID);
        return hR_Overtime;
    }


    public static HR_Overtime GetHR_RowStatusByRowStatusID(int RowStatusID)
    {
        HR_Overtime hR_Overtime = new HR_Overtime();
        SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
        hR_Overtime = sqlHR_OvertimeProvider.GetHR_OvertimeByRowStatusID(RowStatusID);
        return hR_Overtime;
    }


    public static HR_Overtime GetHR_OvertimeByOverTimeID(int OverTimeID)
    {
        HR_Overtime hR_Overtime = new HR_Overtime();
        SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
        hR_Overtime = sqlHR_OvertimeProvider.GetHR_OvertimeByOverTimeID(OverTimeID);
        return hR_Overtime;
    }


    public static int InsertHR_Overtime(HR_Overtime hR_Overtime)
    {
        SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
        return sqlHR_OvertimeProvider.InsertHR_Overtime(hR_Overtime);
    }


    public static bool UpdateHR_Overtime(HR_Overtime hR_Overtime)
    {
        SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
        return sqlHR_OvertimeProvider.UpdateHR_Overtime(hR_Overtime);
    }

    public static bool DeleteHR_Overtime(int hR_OvertimeID)
    {
        SqlHR_OvertimeProvider sqlHR_OvertimeProvider = new SqlHR_OvertimeProvider();
        return sqlHR_OvertimeProvider.DeleteHR_Overtime(hR_OvertimeID);
    }
}

