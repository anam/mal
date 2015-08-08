using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_JournalHistoryManager
{
	public ACC_JournalHistoryManager()
	{
	}

    public static DataSet  GetAllACC_JournalHistories()
    {
       DataSet aCC_JournalHistories = new DataSet();
        SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
        aCC_JournalHistories = sqlACC_JournalHistoryProvider.GetAllACC_JournalHistories();
        return aCC_JournalHistories;
    }

	public static void aCC_JournalHistoriesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_JournalHistoryPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
		DataSet ds =  sqlACC_JournalHistoryProvider.GetACC_JournalHistoryPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_JournalHistoriesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_JournalHistory()
    {
       DataSet aCC_JournalHistories = new DataSet();
        SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
        aCC_JournalHistories = sqlACC_JournalHistoryProvider.GetDropDownLisAllACC_JournalHistory();
        return aCC_JournalHistories;
    }


    public static ACC_JournalHistory GetACC_HeadByHeadID(int HeadID)
    {
        ACC_JournalHistory aCC_JournalHistory = new ACC_JournalHistory();
        SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
        aCC_JournalHistory = sqlACC_JournalHistoryProvider.GetACC_JournalHistoryByHeadID(HeadID);
        return aCC_JournalHistory;
    }


    public static ACC_JournalHistory GetACC_JournalMasterByJournalMasterID(int JournalMasterID)
    {
        ACC_JournalHistory aCC_JournalHistory = new ACC_JournalHistory();
        SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
        aCC_JournalHistory = sqlACC_JournalHistoryProvider.GetACC_JournalHistoryByJournalMasterID(JournalMasterID);
        return aCC_JournalHistory;
    }


    public static ACC_JournalHistory GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_JournalHistory aCC_JournalHistory = new ACC_JournalHistory();
        SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
        aCC_JournalHistory = sqlACC_JournalHistoryProvider.GetACC_JournalHistoryByRowStatusID(RowStatusID);
        return aCC_JournalHistory;
    }


    public static ACC_JournalHistory GetACC_JournalHistoryByJournalID(int JournalID)
    {
        ACC_JournalHistory aCC_JournalHistory = new ACC_JournalHistory();
        SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
        aCC_JournalHistory = sqlACC_JournalHistoryProvider.GetACC_JournalHistoryByJournalID(JournalID);
        return aCC_JournalHistory;
    }


    public static int InsertACC_JournalHistory(ACC_JournalHistory aCC_JournalHistory)
    {
        SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
        return sqlACC_JournalHistoryProvider.InsertACC_JournalHistory(aCC_JournalHistory);
    }


    public static bool UpdateACC_JournalHistory(ACC_JournalHistory aCC_JournalHistory)
    {
        SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
        return sqlACC_JournalHistoryProvider.UpdateACC_JournalHistory(aCC_JournalHistory);
    }

    public static bool DeleteACC_JournalHistory(int aCC_JournalHistoryID)
    {
        SqlACC_JournalHistoryProvider sqlACC_JournalHistoryProvider = new SqlACC_JournalHistoryProvider();
        return sqlACC_JournalHistoryProvider.DeleteACC_JournalHistory(aCC_JournalHistoryID);
    }
}

