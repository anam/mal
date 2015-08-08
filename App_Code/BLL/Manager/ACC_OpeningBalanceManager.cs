using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_OpeningBalanceManager
{
	public ACC_OpeningBalanceManager()
	{
	}

    public static DataSet  GetAllACC_OpeningBalances()
    {
       DataSet aCC_OpeningBalances = new DataSet();
        SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
        aCC_OpeningBalances = sqlACC_OpeningBalanceProvider.GetAllACC_OpeningBalances();
        return aCC_OpeningBalances;
    }

	public static void aCC_OpeningBalancesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_OpeningBalancePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
		DataSet ds =  sqlACC_OpeningBalanceProvider.GetACC_OpeningBalancePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_OpeningBalancesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_OpeningBalance()
    {
       DataSet aCC_OpeningBalances = new DataSet();
        SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
        aCC_OpeningBalances = sqlACC_OpeningBalanceProvider.GetDropDownLisAllACC_OpeningBalance();
        return aCC_OpeningBalances;
    }

    public static DataSet   GetAllACC_OpeningBalancesWithRelation()
    {
       DataSet aCC_OpeningBalances = new DataSet();
        SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
        aCC_OpeningBalances = sqlACC_OpeningBalanceProvider.GetAllACC_OpeningBalances();
        return aCC_OpeningBalances;
    }


    public static ACC_OpeningBalance GetACC_HeadByHeadID(int HeadID)
    {
        ACC_OpeningBalance aCC_OpeningBalance = new ACC_OpeningBalance();
        SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
        aCC_OpeningBalance = sqlACC_OpeningBalanceProvider.GetACC_OpeningBalanceByHeadID(HeadID);
        return aCC_OpeningBalance;
    }


    public static ACC_OpeningBalance GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_OpeningBalance aCC_OpeningBalance = new ACC_OpeningBalance();
        SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
        aCC_OpeningBalance = sqlACC_OpeningBalanceProvider.GetACC_OpeningBalanceByRowStatusID(RowStatusID);
        return aCC_OpeningBalance;
    }


    public static ACC_OpeningBalance GetACC_OpeningBalanceByOpeningBalanceID(int OpeningBalanceID)
    {
        ACC_OpeningBalance aCC_OpeningBalance = new ACC_OpeningBalance();
        SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
        aCC_OpeningBalance = sqlACC_OpeningBalanceProvider.GetACC_OpeningBalanceByOpeningBalanceID(OpeningBalanceID);
        return aCC_OpeningBalance;
    }


    public static int InsertACC_OpeningBalance(ACC_OpeningBalance aCC_OpeningBalance)
    {
        SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
        return sqlACC_OpeningBalanceProvider.InsertACC_OpeningBalance(aCC_OpeningBalance);
    }


    public static bool UpdateACC_OpeningBalance(ACC_OpeningBalance aCC_OpeningBalance)
    {
        SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
        return sqlACC_OpeningBalanceProvider.UpdateACC_OpeningBalance(aCC_OpeningBalance);
    }

    public static bool DeleteACC_OpeningBalance(int aCC_OpeningBalanceID)
    {
        SqlACC_OpeningBalanceProvider sqlACC_OpeningBalanceProvider = new SqlACC_OpeningBalanceProvider();
        return sqlACC_OpeningBalanceProvider.DeleteACC_OpeningBalance(aCC_OpeningBalanceID);
    }
}

