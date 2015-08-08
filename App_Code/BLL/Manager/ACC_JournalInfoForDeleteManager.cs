using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_JournalInfoForDeleteManager
{
	public ACC_JournalInfoForDeleteManager()
	{
	}

    public static DataSet  GetAllACC_JournalInfoForDeletes()
    {
       DataSet aCC_JournalInfoForDeletes = new DataSet();
        SqlACC_JournalInfoForDeleteProvider sqlACC_JournalInfoForDeleteProvider = new SqlACC_JournalInfoForDeleteProvider();
        aCC_JournalInfoForDeletes = sqlACC_JournalInfoForDeleteProvider.GetAllACC_JournalInfoForDeletes();
        return aCC_JournalInfoForDeletes;
    }

    public static DataSet GetAllACC_JournalInfoForDeleteByJournalMasterID(int journalMasterID)
    {
        DataSet aCC_JournalInfoForDeletes = new DataSet();
        SqlACC_JournalInfoForDeleteProvider sqlACC_JournalInfoForDeleteProvider = new SqlACC_JournalInfoForDeleteProvider();
        aCC_JournalInfoForDeletes = sqlACC_JournalInfoForDeleteProvider.GetACC_JournalInfoForDeleteByJournalMasterID(journalMasterID);
        return aCC_JournalInfoForDeletes;
    }

	public static void aCC_JournalInfoForDeletesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_JournalInfoForDeletePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_JournalInfoForDeleteProvider sqlACC_JournalInfoForDeleteProvider = new SqlACC_JournalInfoForDeleteProvider();
		DataSet ds =  sqlACC_JournalInfoForDeleteProvider.GetACC_JournalInfoForDeletePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_JournalInfoForDeletesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_JournalInfoForDelete()
    {
       DataSet aCC_JournalInfoForDeletes = new DataSet();
        SqlACC_JournalInfoForDeleteProvider sqlACC_JournalInfoForDeleteProvider = new SqlACC_JournalInfoForDeleteProvider();
        aCC_JournalInfoForDeletes = sqlACC_JournalInfoForDeleteProvider.GetDropDownLisAllACC_JournalInfoForDelete();
        return aCC_JournalInfoForDeletes;
    }


    public static ACC_JournalInfoForDelete GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_JournalInfoForDelete aCC_JournalInfoForDelete = new ACC_JournalInfoForDelete();
        SqlACC_JournalInfoForDeleteProvider sqlACC_JournalInfoForDeleteProvider = new SqlACC_JournalInfoForDeleteProvider();
        aCC_JournalInfoForDelete = sqlACC_JournalInfoForDeleteProvider.GetACC_JournalInfoForDeleteByRowStatusID(RowStatusID);
        return aCC_JournalInfoForDelete;
    }


    public static ACC_JournalInfoForDelete GetACC_JournalInfoForDeleteByJournalID(int JournalID)
    {
        ACC_JournalInfoForDelete aCC_JournalInfoForDelete = new ACC_JournalInfoForDelete();
        SqlACC_JournalInfoForDeleteProvider sqlACC_JournalInfoForDeleteProvider = new SqlACC_JournalInfoForDeleteProvider();
        aCC_JournalInfoForDelete = sqlACC_JournalInfoForDeleteProvider.GetACC_JournalInfoForDeleteByJournalID(JournalID);
        return aCC_JournalInfoForDelete;
    }


    public static int InsertACC_JournalInfoForDelete(ACC_JournalInfoForDelete aCC_JournalInfoForDelete)
    {
        SqlACC_JournalInfoForDeleteProvider sqlACC_JournalInfoForDeleteProvider = new SqlACC_JournalInfoForDeleteProvider();
        return sqlACC_JournalInfoForDeleteProvider.InsertACC_JournalInfoForDelete(aCC_JournalInfoForDelete);
    }


    public static bool UpdateACC_JournalInfoForDelete(ACC_JournalInfoForDelete aCC_JournalInfoForDelete)
    {
        SqlACC_JournalInfoForDeleteProvider sqlACC_JournalInfoForDeleteProvider = new SqlACC_JournalInfoForDeleteProvider();
        return sqlACC_JournalInfoForDeleteProvider.UpdateACC_JournalInfoForDelete(aCC_JournalInfoForDelete);
    }

    public static bool DeleteACC_JournalInfoForDelete(int aCC_JournalInfoForDeleteID)
    {
        SqlACC_JournalInfoForDeleteProvider sqlACC_JournalInfoForDeleteProvider = new SqlACC_JournalInfoForDeleteProvider();
        return sqlACC_JournalInfoForDeleteProvider.DeleteACC_JournalInfoForDelete(aCC_JournalInfoForDeleteID);
    }
}

