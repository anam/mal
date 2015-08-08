using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_JournalMasterManager
{
	public ACC_JournalMasterManager()
	{
	}

    public static DataSet  GetAllACC_JournalMasters()
    {
       DataSet aCC_JournalMasters = new DataSet();
        SqlACC_JournalMasterProvider sqlACC_JournalMasterProvider = new SqlACC_JournalMasterProvider();
        aCC_JournalMasters = sqlACC_JournalMasterProvider.GetAllACC_JournalMasters();
        return aCC_JournalMasters;
    }

	public static void aCC_JournalMastersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_JournalMasterPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_JournalMasterProvider sqlACC_JournalMasterProvider = new SqlACC_JournalMasterProvider();
		DataSet ds =  sqlACC_JournalMasterProvider.GetACC_JournalMasterPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_JournalMastersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_JournalMaster()
    {
       DataSet aCC_JournalMasters = new DataSet();
        SqlACC_JournalMasterProvider sqlACC_JournalMasterProvider = new SqlACC_JournalMasterProvider();
        aCC_JournalMasters = sqlACC_JournalMasterProvider.GetDropDownLisAllACC_JournalMaster();
        return aCC_JournalMasters;
    }


    public static ACC_JournalMaster GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_JournalMaster aCC_JournalMaster = new ACC_JournalMaster();
        SqlACC_JournalMasterProvider sqlACC_JournalMasterProvider = new SqlACC_JournalMasterProvider();
        aCC_JournalMaster = sqlACC_JournalMasterProvider.GetACC_JournalMasterByRowStatusID(RowStatusID);
        return aCC_JournalMaster;
    }


    public static ACC_JournalMaster GetACC_JournalMasterByJournalMasterID(int JournalMasterID)
    {
        ACC_JournalMaster aCC_JournalMaster = new ACC_JournalMaster();
        SqlACC_JournalMasterProvider sqlACC_JournalMasterProvider = new SqlACC_JournalMasterProvider();
        aCC_JournalMaster = sqlACC_JournalMasterProvider.GetACC_JournalMasterByJournalMasterID(JournalMasterID);
        return aCC_JournalMaster;
    }


    public static int InsertACC_JournalMaster(ACC_JournalMaster aCC_JournalMaster)
    {
        SqlACC_JournalMasterProvider sqlACC_JournalMasterProvider = new SqlACC_JournalMasterProvider();
        return sqlACC_JournalMasterProvider.InsertACC_JournalMaster(aCC_JournalMaster);
    }


    public static bool UpdateACC_JournalMaster(ACC_JournalMaster aCC_JournalMaster)
    {
        SqlACC_JournalMasterProvider sqlACC_JournalMasterProvider = new SqlACC_JournalMasterProvider();
        return sqlACC_JournalMasterProvider.UpdateACC_JournalMaster(aCC_JournalMaster);
    }

    public static bool DeleteACC_JournalMaster(int aCC_JournalMasterID)
    {
        SqlACC_JournalMasterProvider sqlACC_JournalMasterProvider = new SqlACC_JournalMasterProvider();
        return sqlACC_JournalMasterProvider.DeleteACC_JournalMaster(aCC_JournalMasterID);
    }

    public static DataSet SearchACC_AccountJournalMaster(int journalMasterID, DateTime startTime, DateTime endTime)
    {
        DataSet aCC_JournalMasters = new DataSet();
        SqlACC_JournalMasterProvider sqlACC_JournalMasterProvider = new SqlACC_JournalMasterProvider();
        aCC_JournalMasters = sqlACC_JournalMasterProvider.SearchACC_AccountJournalMaster(journalMasterID, startTime, endTime);
        return aCC_JournalMasters;
    }
}

