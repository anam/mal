using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_BankAccountManager
{
	public HR_BankAccountManager()
	{
	}

    public static DataSet  GetAllHR_BankAccounts()
    {
       DataSet hR_BankAccounts = new DataSet();
        SqlHR_BankAccountProvider sqlHR_BankAccountProvider = new SqlHR_BankAccountProvider();
        hR_BankAccounts = sqlHR_BankAccountProvider.GetAllHR_BankAccounts();
        return hR_BankAccounts;
    }

	public static void hR_BankAccountsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_BankAccountPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_BankAccountProvider sqlHR_BankAccountProvider = new SqlHR_BankAccountProvider();
		DataSet ds =  sqlHR_BankAccountProvider.GetHR_BankAccountPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_BankAccountsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_BankAccount()
    {
       DataSet hR_BankAccounts = new DataSet();
        SqlHR_BankAccountProvider sqlHR_BankAccountProvider = new SqlHR_BankAccountProvider();
        hR_BankAccounts = sqlHR_BankAccountProvider.GetDropDownListAllHR_BankAccount();
        return hR_BankAccounts;
    }

    public static DataSet   GetAllHR_BankAccountsWithRelation()
    {
       DataSet hR_BankAccounts = new DataSet();
        SqlHR_BankAccountProvider sqlHR_BankAccountProvider = new SqlHR_BankAccountProvider();
        hR_BankAccounts = sqlHR_BankAccountProvider.GetAllHR_BankAccounts();
        return hR_BankAccounts;
    }


    public static HR_BankAccount GetHR_BankAccountByEmployeeID(string EmployeeID)
    {
        HR_BankAccount hR_BankAccount = new HR_BankAccount();
        SqlHR_BankAccountProvider sqlHR_BankAccountProvider = new SqlHR_BankAccountProvider();
        hR_BankAccount = sqlHR_BankAccountProvider.GetHR_BankAccountByEmployeeID(EmployeeID);
        return hR_BankAccount;
    }


    public static HR_BankAccount GetHR_BankAccountByBankAccountNoID(int BankAccountNoID)
    {
        HR_BankAccount hR_BankAccount = new HR_BankAccount();
        SqlHR_BankAccountProvider sqlHR_BankAccountProvider = new SqlHR_BankAccountProvider();
        hR_BankAccount = sqlHR_BankAccountProvider.GetHR_BankAccountByBankAccountNoID(BankAccountNoID);
        return hR_BankAccount;
    }


    public static int InsertHR_BankAccount(HR_BankAccount hR_BankAccount)
    {
        SqlHR_BankAccountProvider sqlHR_BankAccountProvider = new SqlHR_BankAccountProvider();
        return sqlHR_BankAccountProvider.InsertHR_BankAccount(hR_BankAccount);
    }


    public static bool UpdateHR_BankAccount(HR_BankAccount hR_BankAccount)
    {
        SqlHR_BankAccountProvider sqlHR_BankAccountProvider = new SqlHR_BankAccountProvider();
        return sqlHR_BankAccountProvider.UpdateHR_BankAccount(hR_BankAccount);
    }

    public static bool DeleteHR_BankAccount(int hR_BankAccountID)
    {
        SqlHR_BankAccountProvider sqlHR_BankAccountProvider = new SqlHR_BankAccountProvider();
        return sqlHR_BankAccountProvider.DeleteHR_BankAccount(hR_BankAccountID);
    }
}

