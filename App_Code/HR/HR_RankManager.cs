using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_RankManager
{
	public HR_RankManager()
	{
	}

    public static DataSet  GetAllHR_Ranks()
    {
       DataSet hR_Ranks = new DataSet();
        SqlHR_RankProvider sqlHR_RankProvider = new SqlHR_RankProvider();
        hR_Ranks = sqlHR_RankProvider.GetAllHR_Ranks();
        return hR_Ranks;
    }

	public static void hR_RanksPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_RankPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_RankProvider sqlHR_RankProvider = new SqlHR_RankProvider();
		DataSet ds =  sqlHR_RankProvider.GetHR_RankPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_RanksPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Rank()
    {
       DataSet hR_Ranks = new DataSet();
        SqlHR_RankProvider sqlHR_RankProvider = new SqlHR_RankProvider();
        hR_Ranks = sqlHR_RankProvider.GetDropDownLisAllHR_Rank();
        return hR_Ranks;
    }


    public static HR_Rank GetHR_RankByRankID(int RankID)
    {
        HR_Rank hR_Rank = new HR_Rank();
        SqlHR_RankProvider sqlHR_RankProvider = new SqlHR_RankProvider();
        hR_Rank = sqlHR_RankProvider.GetHR_RankByRankID(RankID);
        return hR_Rank;
    }


    public static int InsertHR_Rank(HR_Rank hR_Rank)
    {
        SqlHR_RankProvider sqlHR_RankProvider = new SqlHR_RankProvider();
        return sqlHR_RankProvider.InsertHR_Rank(hR_Rank);
    }


    public static bool UpdateHR_Rank(HR_Rank hR_Rank)
    {
        SqlHR_RankProvider sqlHR_RankProvider = new SqlHR_RankProvider();
        return sqlHR_RankProvider.UpdateHR_Rank(hR_Rank);
    }

    public static bool DeleteHR_Rank(int hR_RankID)
    {
        SqlHR_RankProvider sqlHR_RankProvider = new SqlHR_RankProvider();
        return sqlHR_RankProvider.DeleteHR_Rank(hR_RankID);
    }
}

