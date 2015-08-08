using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_EmployeeRankManager
{
	public HR_EmployeeRankManager()
	{
	}

    public static DataSet  GetAllHR_EmployeeRanks()
    {
       DataSet hR_EmployeeRanks = new DataSet();
        SqlHR_EmployeeRankProvider sqlHR_EmployeeRankProvider = new SqlHR_EmployeeRankProvider();
        hR_EmployeeRanks = sqlHR_EmployeeRankProvider.GetAllHR_EmployeeRanks();
        return hR_EmployeeRanks;
    }

	public static void hR_EmployeeRanksPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_EmployeeRankPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_EmployeeRankProvider sqlHR_EmployeeRankProvider = new SqlHR_EmployeeRankProvider();
		DataSet ds =  sqlHR_EmployeeRankProvider.GetHR_EmployeeRankPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_EmployeeRanksPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_EmployeeRank()
    {
       DataSet hR_EmployeeRanks = new DataSet();
        SqlHR_EmployeeRankProvider sqlHR_EmployeeRankProvider = new SqlHR_EmployeeRankProvider();
        hR_EmployeeRanks = sqlHR_EmployeeRankProvider.GetDropDownListAllHR_EmployeeRank();
        return hR_EmployeeRanks;
    }


    public static HR_EmployeeRank GetHR_EmployeeRankByEmployeeRankID(int EmployeeRankID)
    {
        HR_EmployeeRank hR_EmployeeRank = new HR_EmployeeRank();
        SqlHR_EmployeeRankProvider sqlHR_EmployeeRankProvider = new SqlHR_EmployeeRankProvider();
        hR_EmployeeRank = sqlHR_EmployeeRankProvider.GetHR_EmployeeRankByEmployeeRankID(EmployeeRankID);
        return hR_EmployeeRank;
    }


    public static int InsertHR_EmployeeRank(HR_EmployeeRank hR_EmployeeRank)
    {
        SqlHR_EmployeeRankProvider sqlHR_EmployeeRankProvider = new SqlHR_EmployeeRankProvider();
        return sqlHR_EmployeeRankProvider.InsertHR_EmployeeRank(hR_EmployeeRank);
    }


    public static bool UpdateHR_EmployeeRank(HR_EmployeeRank hR_EmployeeRank)
    {
        SqlHR_EmployeeRankProvider sqlHR_EmployeeRankProvider = new SqlHR_EmployeeRankProvider();
        return sqlHR_EmployeeRankProvider.UpdateHR_EmployeeRank(hR_EmployeeRank);
    }

    public static bool DeleteHR_EmployeeRank(int hR_EmployeeRankID)
    {
        SqlHR_EmployeeRankProvider sqlHR_EmployeeRankProvider = new SqlHR_EmployeeRankProvider();
        return sqlHR_EmployeeRankProvider.DeleteHR_EmployeeRank(hR_EmployeeRankID);
    }
}

