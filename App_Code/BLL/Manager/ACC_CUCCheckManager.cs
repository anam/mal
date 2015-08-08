using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_CUCCheckManager
{
	public ACC_CUCCheckManager()
	{
	}

    public static DataSet  GetAllACC_CUCChecks()
    {
       DataSet aCC_CUCChecks = new DataSet();
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        aCC_CUCChecks = sqlACC_CUCCheckProvider.GetAllACC_CUCChecks();
        return aCC_CUCChecks;
    }

	public static void aCC_CUCChecksPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_CUCCheckPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
		DataSet ds =  sqlACC_CUCCheckProvider.GetACC_CUCCheckPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_CUCChecksPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_CUCCheck()
    {
       DataSet aCC_CUCChecks = new DataSet();
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        aCC_CUCChecks = sqlACC_CUCCheckProvider.GetDropDownLisAllACC_CUCCheck();
        return aCC_CUCChecks;
    }


    public static ACC_CUCCheck GetACC_BankAccountByBankAccountID(int BankAccountID)
    {
        ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck();
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        aCC_CUCCheck = sqlACC_CUCCheckProvider.GetACC_CUCCheckByBankAccountID(BankAccountID);
        return aCC_CUCCheck;
    }


    public static ACC_CUCCheck GetACC_PaytoHeadByPaytoHeadID(int PaytoHeadID)
    {
        ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck();
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        aCC_CUCCheck = sqlACC_CUCCheckProvider.GetACC_CUCCheckByPaytoHeadID(PaytoHeadID);
        return aCC_CUCCheck;
    }


    public static ACC_CUCCheck GetACC_JournalByJournalID(int JournalID)
    {
        ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck();
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        aCC_CUCCheck = sqlACC_CUCCheckProvider.GetACC_CUCCheckByJournalID(JournalID);
        return aCC_CUCCheck;
    }


    public static ACC_CUCCheck GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck();
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        aCC_CUCCheck = sqlACC_CUCCheckProvider.GetACC_CUCCheckByRowStatusID(RowStatusID);
        return aCC_CUCCheck;
    }


    public static ACC_CUCCheck GetACC_CUCCheckByCUCCheckID(int CUCCheckID)
    {
        ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck();
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        aCC_CUCCheck = sqlACC_CUCCheckProvider.GetACC_CUCCheckByCUCCheckID(CUCCheckID);
        return aCC_CUCCheck;
    }


    public static int InsertACC_CUCCheck(ACC_CUCCheck aCC_CUCCheck)
    {
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        return sqlACC_CUCCheckProvider.InsertACC_CUCCheck(aCC_CUCCheck);
    }


    public static bool UpdateACC_CUCCheck(ACC_CUCCheck aCC_CUCCheck)
    {
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        return sqlACC_CUCCheckProvider.UpdateACC_CUCCheck(aCC_CUCCheck);
    }

    public static bool DeleteACC_CUCCheck(int aCC_CUCCheckID)
    {
        SqlACC_CUCCheckProvider sqlACC_CUCCheckProvider = new SqlACC_CUCCheckProvider();
        return sqlACC_CUCCheckProvider.DeleteACC_CUCCheck(aCC_CUCCheckID);
    }
}

