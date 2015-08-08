using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_BankAccountManager
{
	public ACC_BankAccountManager()
	{
	}

    public static DataSet  GetAllACC_BankAccounts()
    {
       DataSet aCC_BankAccounts = new DataSet();
        SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
        aCC_BankAccounts = sqlACC_BankAccountProvider.GetAllACC_BankAccounts();
        return aCC_BankAccounts;
    }

	public static void aCC_BankAccountsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_BankAccountPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
		DataSet ds =  sqlACC_BankAccountProvider.GetACC_BankAccountPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_BankAccountsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_BankAccount()
    {
       DataSet aCC_BankAccounts = new DataSet();
        SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
        aCC_BankAccounts = sqlACC_BankAccountProvider.GetDropDownLisAllACC_BankAccount();
        return aCC_BankAccounts;
    }

    public static DataSet   GetAllACC_BankAccountsWithRelation()
    {
       DataSet aCC_BankAccounts = new DataSet();
        SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
        aCC_BankAccounts = sqlACC_BankAccountProvider.GetAllACC_BankAccounts();
        return aCC_BankAccounts;
    }


    public static ACC_BankAccount GetACC_BankByBankID(int BankID)
    {
        ACC_BankAccount aCC_BankAccount = new ACC_BankAccount();
        SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
        aCC_BankAccount = sqlACC_BankAccountProvider.GetACC_BankAccountByBankID(BankID);
        return aCC_BankAccount;
    }


    public static ACC_BankAccount GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_BankAccount aCC_BankAccount = new ACC_BankAccount();
        SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
        aCC_BankAccount = sqlACC_BankAccountProvider.GetACC_BankAccountByRowStatusID(RowStatusID);
        return aCC_BankAccount;
    }


    public static ACC_BankAccount GetACC_BankAccountByBankAcountID(int BankAcountID)
    {
        ACC_BankAccount aCC_BankAccount = new ACC_BankAccount();
        SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
        aCC_BankAccount = sqlACC_BankAccountProvider.GetACC_BankAccountByBankAcountID(BankAcountID);
        return aCC_BankAccount;
    }


    public static int InsertACC_BankAccount(ACC_BankAccount aCC_BankAccount)
    {
        SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
        return sqlACC_BankAccountProvider.InsertACC_BankAccount(aCC_BankAccount);
    }


    public static bool UpdateACC_BankAccount(ACC_BankAccount aCC_BankAccount)
    {
        SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
        return sqlACC_BankAccountProvider.UpdateACC_BankAccount(aCC_BankAccount);
    }

    public static bool DeleteACC_BankAccount(int aCC_BankAccountID)
    {
        SqlACC_BankAccountProvider sqlACC_BankAccountProvider = new SqlACC_BankAccountProvider();
        return sqlACC_BankAccountProvider.DeleteACC_BankAccount(aCC_BankAccountID);
    }
}

