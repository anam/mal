using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_AccountManager
{
	public ACC_AccountManager()
	{
	}

    public static DataSet  GetAllACC_Accounts()
    {
       DataSet aCC_Accounts = new DataSet();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Accounts = sqlACC_AccountProvider.GetAllACC_Accounts();
        return aCC_Accounts;
    }

    public static DataSet GetAllTypesACC_Accounts()
    {
        DataSet aCC_Accounts = new DataSet();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Accounts = sqlACC_AccountProvider.GetAllTypesACC_Accounts();
        return aCC_Accounts;
    }


	public static void aCC_AccountsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_AccountPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
		DataSet ds =  sqlACC_AccountProvider.GetACC_AccountPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_AccountsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_Account()
    {
       DataSet aCC_Accounts = new DataSet();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Accounts = sqlACC_AccountProvider.GetDropDownLisAllACC_Account();
        return aCC_Accounts;
    }

    public static DataSet   GetAllACC_AccountsWithRelation()
    {
       DataSet aCC_Accounts = new DataSet();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Accounts = sqlACC_AccountProvider.GetAllACC_Accounts();
        return aCC_Accounts;
    }


    public static ACC_Account GetACC_SubBasicAccountBySubBasicAccountID(int SubBasicAccountID)
    {
        ACC_Account aCC_Account = new ACC_Account();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Account = sqlACC_AccountProvider.GetACC_AccountBySubBasicAccountID(SubBasicAccountID);
        return aCC_Account;
    }


    public static DataSet GetACC_AccountBySubBasicAccountID(int SubBasicAccountID,bool isDataset)
    {
        DataSet aCC_Account = new DataSet();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Account = sqlACC_AccountProvider.GetACC_AccountBySubBasicAccountID(SubBasicAccountID,isDataset);
        return aCC_Account;
    }

    public static DataSet GetACC_AccountByBasicAccountID(int BasicAccountID, bool isDataset)
    {
        DataSet aCC_Account = new DataSet();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Account = sqlACC_AccountProvider.GetACC_AccountByBasicAccountID(BasicAccountID, isDataset);
        return aCC_Account;
    }

    public static ACC_Account GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_Account aCC_Account = new ACC_Account();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Account = sqlACC_AccountProvider.GetACC_AccountByRowStatusID(RowStatusID);
        return aCC_Account;
    }


    public static ACC_Account GetACC_AccountByAccountID(int AccountID)
    {
        ACC_Account aCC_Account = new ACC_Account();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Account = sqlACC_AccountProvider.GetACC_AccountByAccountID(AccountID);
        return aCC_Account;
    }


    public static int InsertACC_Account(ACC_Account aCC_Account)
    {
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        return sqlACC_AccountProvider.InsertACC_Account(aCC_Account);
    }


    public static bool UpdateACC_Account(ACC_Account aCC_Account)
    {
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        return sqlACC_AccountProvider.UpdateACC_Account(aCC_Account);
    }

    public static bool DeleteACC_Account(int aCC_AccountID)
    {
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        return sqlACC_AccountProvider.DeleteACC_Account(aCC_AccountID);
    }

    public static List<ACC_Account> ViewAllACC_JournalsByAccountID(DateTime startDate, DateTime endDate)
    {
        List<ACC_Account> aCC_Accounts = new List<ACC_Account>();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Accounts = sqlACC_AccountProvider.ViewAllACC_JournalsByDateRange(startDate, endDate);
        return aCC_Accounts;
    }

    public static List<ACC_Account> GetAllAccountBySubBasicAccountID(int subBasicAccountID)
    {
        List<ACC_Account> aCC_Accounts = new List<ACC_Account>();
        SqlACC_AccountProvider sqlACC_AccountProvider = new SqlACC_AccountProvider();
        aCC_Accounts = sqlACC_AccountProvider.GetAllAccountBySubBasicAccountID(subBasicAccountID);
        return aCC_Accounts;
    }
}

