using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_BankManager
{
	public HR_BankManager()
	{
	}

    public static DataSet GetAllHR_BankAccounts()
    {
       DataSet hR_Banks = new DataSet();
       SqlHR_BankAccountProvider sqlHR_BankProvider = new SqlHR_BankAccountProvider();
       hR_Banks = sqlHR_BankProvider.GetAllHR_BankAccounts();
        return hR_Banks;
    }

	public static void hR_BanksPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_BankPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
        SqlHR_BankAccountProvider sqlHR_BankProvider = new SqlHR_BankAccountProvider();
        DataSet ds = sqlHR_BankProvider.GetHR_BankAccountPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_BanksPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet GetDropDownListAllHR_BankAccount()
    {
       DataSet hR_Banks = new DataSet();
       SqlHR_BankAccountProvider sqlHR_BankProvider = new SqlHR_BankAccountProvider();
       hR_Banks = sqlHR_BankProvider.GetDropDownListAllHR_BankAccount();
        return hR_Banks;
    }

    public static DataSet GetAllHR_BankAccountsWithRelation()
    {
       DataSet hR_Banks = new DataSet();
       SqlHR_BankAccountProvider sqlHR_BankProvider = new SqlHR_BankAccountProvider();
       hR_Banks = sqlHR_BankProvider.GetAllHR_BankAccountsWithRelation();
        return hR_Banks;
    }


    public static HR_BankAccount GetHR_BankAccountByEmployeeID(string EmployeeID)
    {
        HR_BankAccount hR_Bank = new HR_BankAccount();
        SqlHR_BankAccountProvider sqlHR_BankProvider = new SqlHR_BankAccountProvider();
        hR_Bank = sqlHR_BankProvider.GetHR_BankAccountByEmployeeID(EmployeeID);
        return hR_Bank;
    }


    public static HR_BankAccount GetHR_BankAccountByBankAccountNoID(int BankAccountNoID)
    {
        HR_BankAccount hR_Bank = new HR_BankAccount();
        SqlHR_BankAccountProvider sqlHR_BankProvider = new SqlHR_BankAccountProvider();
        hR_Bank = sqlHR_BankProvider.GetHR_BankAccountByBankAccountNoID(BankAccountNoID);
        return hR_Bank;
    }


    public static int InsertHR_BankAccount(HR_BankAccount hR_Bank)
    {
        SqlHR_BankAccountProvider sqlHR_BankProvider = new SqlHR_BankAccountProvider();
        return sqlHR_BankProvider.InsertHR_BankAccount(hR_Bank);
    }


    public static bool UpdateHR_BankAccount(HR_BankAccount hR_Bank)
    {
        SqlHR_BankAccountProvider sqlHR_BankProvider = new SqlHR_BankAccountProvider();
        return sqlHR_BankProvider.UpdateHR_BankAccount(hR_Bank);
    }

    public static bool DeleteHR_BankAccount(int bankAccountNoID)
    {
        SqlHR_BankAccountProvider sqlHR_BankProvider = new SqlHR_BankAccountProvider();
        return sqlHR_BankProvider.DeleteHR_BankAccount(bankAccountNoID);
    }
}

