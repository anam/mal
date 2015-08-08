using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_BasicAccountManager
{
	public ACC_BasicAccountManager()
	{
	}

    public static DataSet  GetAllACC_BasicAccounts()
    {
       DataSet aCC_BasicAccounts = new DataSet();
        SqlACC_BasicAccountProvider sqlACC_BasicAccountProvider = new SqlACC_BasicAccountProvider();
        aCC_BasicAccounts = sqlACC_BasicAccountProvider.GetAllACC_BasicAccounts();
        return aCC_BasicAccounts;
    }

	public static void aCC_BasicAccountsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_BasicAccountPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_BasicAccountProvider sqlACC_BasicAccountProvider = new SqlACC_BasicAccountProvider();
		DataSet ds =  sqlACC_BasicAccountProvider.GetACC_BasicAccountPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_BasicAccountsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_BasicAccount()
    {
       DataSet aCC_BasicAccounts = new DataSet();
        SqlACC_BasicAccountProvider sqlACC_BasicAccountProvider = new SqlACC_BasicAccountProvider();
        aCC_BasicAccounts = sqlACC_BasicAccountProvider.GetDropDownLisAllACC_BasicAccount();
        return aCC_BasicAccounts;
    }


    public static ACC_BasicAccount GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_BasicAccount aCC_BasicAccount = new ACC_BasicAccount();
        SqlACC_BasicAccountProvider sqlACC_BasicAccountProvider = new SqlACC_BasicAccountProvider();
        aCC_BasicAccount = sqlACC_BasicAccountProvider.GetACC_BasicAccountByRowStatusID(RowStatusID);
        return aCC_BasicAccount;
    }


    public static ACC_BasicAccount GetACC_BasicAccountByBasicAccountID(int BasicAccountID)
    {
        ACC_BasicAccount aCC_BasicAccount = new ACC_BasicAccount();
        SqlACC_BasicAccountProvider sqlACC_BasicAccountProvider = new SqlACC_BasicAccountProvider();
        aCC_BasicAccount = sqlACC_BasicAccountProvider.GetACC_BasicAccountByBasicAccountID(BasicAccountID);
        return aCC_BasicAccount;
    }


    public static int InsertACC_BasicAccount(ACC_BasicAccount aCC_BasicAccount)
    {
        SqlACC_BasicAccountProvider sqlACC_BasicAccountProvider = new SqlACC_BasicAccountProvider();
        return sqlACC_BasicAccountProvider.InsertACC_BasicAccount(aCC_BasicAccount);
    }


    public static bool UpdateACC_BasicAccount(ACC_BasicAccount aCC_BasicAccount)
    {
        SqlACC_BasicAccountProvider sqlACC_BasicAccountProvider = new SqlACC_BasicAccountProvider();
        return sqlACC_BasicAccountProvider.UpdateACC_BasicAccount(aCC_BasicAccount);
    }

    public static bool DeleteACC_BasicAccount(int aCC_BasicAccountID)
    {
        SqlACC_BasicAccountProvider sqlACC_BasicAccountProvider = new SqlACC_BasicAccountProvider();
        return sqlACC_BasicAccountProvider.DeleteACC_BasicAccount(aCC_BasicAccountID);
    }
}

