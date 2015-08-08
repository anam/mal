using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_SubBasicAccountManager
{
	public ACC_SubBasicAccountManager()
	{
	}

    public static DataSet  GetAllACC_SubBasicAccounts()
    {
       DataSet aCC_SubBasicAccounts = new DataSet();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccounts = sqlACC_SubBasicAccountProvider.GetAllACC_SubBasicAccounts();
        return aCC_SubBasicAccounts;
    }

	public static void aCC_SubBasicAccountsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_SubBasicAccountPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
		DataSet ds =  sqlACC_SubBasicAccountProvider.GetACC_SubBasicAccountPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_SubBasicAccountsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_SubBasicAccount()
    {
       DataSet aCC_SubBasicAccounts = new DataSet();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccounts = sqlACC_SubBasicAccountProvider.GetDropDownLisAllACC_SubBasicAccount();
        return aCC_SubBasicAccounts;
    }

    public static DataSet   GetAllACC_SubBasicAccountsWithRelation()
    {
       DataSet aCC_SubBasicAccounts = new DataSet();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccounts = sqlACC_SubBasicAccountProvider.GetAllACC_SubBasicAccounts();
        return aCC_SubBasicAccounts;
    }


    public static ACC_SubBasicAccount GetACC_BasicAccountByBasicAccountID(int BasicAccountID)
    {
        ACC_SubBasicAccount aCC_SubBasicAccount = new ACC_SubBasicAccount();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccount = sqlACC_SubBasicAccountProvider.GetACC_SubBasicAccountByBasicAccountID(BasicAccountID);
        return aCC_SubBasicAccount;
    }

    public static DataSet GetACC_SubBasicAccountByBasicAccountIDDataset(int BasicAccountID)
    {
        DataSet aCC_SubBasicAccount = new DataSet();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccount = sqlACC_SubBasicAccountProvider.GetACC_SubBasicAccountByBasicAccountIDDataset(BasicAccountID);
        return aCC_SubBasicAccount;
    }

    public static ACC_SubBasicAccount GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_SubBasicAccount aCC_SubBasicAccount = new ACC_SubBasicAccount();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccount = sqlACC_SubBasicAccountProvider.GetACC_SubBasicAccountByRowStatusID(RowStatusID);
        return aCC_SubBasicAccount;
    }


    public static ACC_SubBasicAccount GetACC_SubBasicAccountBySubBasicAccountID(int SubBasicAccountID)
    {
        ACC_SubBasicAccount aCC_SubBasicAccount = new ACC_SubBasicAccount();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccount = sqlACC_SubBasicAccountProvider.GetACC_SubBasicAccountBySubBasicAccountID(SubBasicAccountID);
        return aCC_SubBasicAccount;
    }


    public static int InsertACC_SubBasicAccount(ACC_SubBasicAccount aCC_SubBasicAccount)
    {
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        return sqlACC_SubBasicAccountProvider.InsertACC_SubBasicAccount(aCC_SubBasicAccount);
    }


    public static bool UpdateACC_SubBasicAccount(ACC_SubBasicAccount aCC_SubBasicAccount)
    {
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        return sqlACC_SubBasicAccountProvider.UpdateACC_SubBasicAccount(aCC_SubBasicAccount);
    }

    public static bool DeleteACC_SubBasicAccount(int aCC_SubBasicAccountID)
    {
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        return sqlACC_SubBasicAccountProvider.DeleteACC_SubBasicAccount(aCC_SubBasicAccountID);
    }

    public static List<ACC_SubBasicAccount> ViewACC_BasicAccountStatementsByDateRange(DateTime startDate, DateTime endDate)
    {
        List<ACC_SubBasicAccount> aCC_SubBasicAccount = new List<ACC_SubBasicAccount>();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccount = sqlACC_SubBasicAccountProvider.ViewACC_BasicAccountStatementsByDateRange(startDate, endDate);
        return aCC_SubBasicAccount;
    }

    public static List<ACC_SubBasicAccount> ViewACC_IncomeStatementsByDateRange(DateTime startDate, DateTime endDate)
    {
        List<ACC_SubBasicAccount> aCC_SubBasicAccount = new List<ACC_SubBasicAccount>();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccount = sqlACC_SubBasicAccountProvider.ViewACC_IncomeStatementsByDateRange(startDate, endDate);
        return aCC_SubBasicAccount;
    }

    public static List<ACC_SubBasicAccount> ViewACC_BalanceSheetByDateRange(DateTime startDate, DateTime endDate)
    {
        List<ACC_SubBasicAccount> aCC_SubBasicAccount = new List<ACC_SubBasicAccount>();
        SqlACC_SubBasicAccountProvider sqlACC_SubBasicAccountProvider = new SqlACC_SubBasicAccountProvider();
        aCC_SubBasicAccount = sqlACC_SubBasicAccountProvider.ViewACC_BalanceSheetByDateRange(startDate, endDate);
        return aCC_SubBasicAccount;
    }
}

