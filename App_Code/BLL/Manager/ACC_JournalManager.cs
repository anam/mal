using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_JournalManager
{
	public ACC_JournalManager()
	{
	}

    public static DataSet  GetAllACC_Journals()
    {
       DataSet aCC_Journals = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journals = sqlACC_JournalProvider.GetAllACC_Journals();
        return aCC_Journals;
    }

	public static void aCC_JournalsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_JournalPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
		DataSet ds =  sqlACC_JournalProvider.GetACC_JournalPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_JournalsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_Journal()
    {
       DataSet aCC_Journals = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journals = sqlACC_JournalProvider.GetDropDownLisAllACC_Journal();
        return aCC_Journals;
    }

    public static DataSet   GetAllACC_JournalsWithRelation()
    {
       DataSet aCC_Journals = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journals = sqlACC_JournalProvider.GetAllACC_Journals();
        return aCC_Journals;
    }


    public static ACC_Journal GetACC_HeadByHeadID(int HeadID)
    {
        ACC_Journal aCC_Journal = new ACC_Journal();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalByHeadID(HeadID);
        return aCC_Journal;
    }


    public static DataSet GetACC_JournalByHeadID(int HeadID, string dateFrom, string dateTo)
    {
        DataSet aCC_Journal = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalByHeadIDDataset(HeadID, dateFrom, dateTo);
        return aCC_Journal;
    }

    public static DataSet GetACC_JournalByHeadIDByAll(int basicAccountID, int subBasicAccountID, int accountID, int headID, string dateFrom, string dateTo)
    {
        DataSet aCC_Journal = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalByHeadIDDatasetByAll(basicAccountID,subBasicAccountID,accountID, headID, dateFrom, dateTo);
        return aCC_Journal;
    }


    public static DataSet GetACC_JournalByHeadIDByAllByUserID(int basicAccountID, int subBasicAccountID, int accountID, string userID, int userTypeID, string dateFrom, string dateTo)
    {
        DataSet aCC_Journal = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalByHeadIDDatasetByAllByUserID(basicAccountID, subBasicAccountID, accountID, userID,userTypeID, dateFrom, dateTo);
        return aCC_Journal;
    }



    public static DataSet GetACC_JournalByHeadIDByAllByUserIDStudentFees(int basicAccountID, int subBasicAccountID, int accountID, string userID, int userTypeID, string dateFrom, string dateTo)
    {
        DataSet aCC_Journal = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalByHeadIDDatasetByAllByUserIDStudentFees(basicAccountID, subBasicAccountID, accountID, userID, userTypeID, dateFrom, dateTo);
        return aCC_Journal;
    }

    public static ACC_Journal GetACC_JournalMasterByJournalMasterID(int JournalMasterID)
    {
        ACC_Journal aCC_Journal = new ACC_Journal();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalByJournalMasterID(JournalMasterID);
        return aCC_Journal;
    }


    public static ACC_Journal GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_Journal aCC_Journal = new ACC_Journal();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalByRowStatusID(RowStatusID);
        return aCC_Journal;
    }


    public static ACC_Journal GetACC_JournalByJournalID(int JournalID)
    {
        ACC_Journal aCC_Journal = new ACC_Journal();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalByJournalID(JournalID);
        return aCC_Journal;
    }


    public static int InsertACC_Journal(ACC_Journal aCC_Journal)
    {
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        return sqlACC_JournalProvider.InsertACC_Journal(aCC_Journal);
    }


    public static bool UpdateACC_Journal(ACC_Journal aCC_Journal)
    {
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        return sqlACC_JournalProvider.UpdateACC_Journal(aCC_Journal);
    }

    public static bool DeleteACC_Journal(int aCC_JournalID)
    {
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        return sqlACC_JournalProvider.DeleteACC_Journal(aCC_JournalID);
    }

    
    public static List<ACC_Journal> ViewAllACC_JournalsByAccountID(int accountID, DateTime startDate, DateTime endDate)
    {
        List<ACC_Journal> aCC_Journals = new List<ACC_Journal>();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journals = sqlACC_JournalProvider.ViewAllACC_JournalsByAccountID(accountID, startDate, endDate);
        return aCC_Journals;
    }

    public static DataSet GetACC_JournalsByJournalMasterID(int journalMasterID)
    {
        DataSet aCC_Journal = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalsByJournalMasterID(journalMasterID);
        return aCC_Journal;
    }

    public static DataSet GetACC_VoucherByJournalMasterID(int journalMasterID)
    {
        DataSet aCC_Journal = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_VoucherByJournalMasterID(journalMasterID);
        return aCC_Journal;
    }

    public static DataSet GetACC_JournalForTransactionByDateRange(DateTime  startDate, DateTime endDate,string addedBy)
    {
        DataSet aCC_Journal = new DataSet();
        SqlACC_JournalProvider sqlACC_JournalProvider = new SqlACC_JournalProvider();
        aCC_Journal = sqlACC_JournalProvider.GetACC_JournalForTransactionByDateRange(startDate, endDate, addedBy);
        return aCC_Journal;
    }
}

