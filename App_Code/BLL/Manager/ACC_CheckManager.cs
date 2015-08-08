using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_CheckManager
{
	public ACC_CheckManager()
	{
	}

    public static DataSet  GetAllACC_Checks()
    {
       DataSet aCC_Checks = new DataSet();
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        aCC_Checks = sqlACC_CheckProvider.GetAllACC_Checks();
        return aCC_Checks;
    }

	public static void aCC_ChecksPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_CheckPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
		DataSet ds =  sqlACC_CheckProvider.GetACC_CheckPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_ChecksPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static void LoadACC_CheckPageByRowStatusID(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize,int RowStatusID)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        DataSet ds = sqlACC_CheckProvider.GetACC_CheckPageWiseByRowStatus(pageIndex, PageSize, out recordCount, RowStatusID);
        
        gv.DataSource = ds;
        gv.DataBind();
        aCC_ChecksPaggination(rptPager, recordCount, pageIndex, PageSize);
    }
    public static DataSet  GetDropDownListAllACC_Check()
    {
       DataSet aCC_Checks = new DataSet();
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        aCC_Checks = sqlACC_CheckProvider.GetDropDownLisAllACC_Check();
        return aCC_Checks;
    }

    public static DataSet   GetAllACC_ChecksWithRelation()
    {
       DataSet aCC_Checks = new DataSet();
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        aCC_Checks = sqlACC_CheckProvider.GetAllACC_Checks();
        return aCC_Checks;
    }


    public static ACC_Check GetACC_BankByBankID(int BankID)
    {
        ACC_Check aCC_Check = new ACC_Check();
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        aCC_Check = sqlACC_CheckProvider.GetACC_CheckByBankID(BankID);
        return aCC_Check;
    }


    public static ACC_Check GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_Check aCC_Check = new ACC_Check();
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        aCC_Check = sqlACC_CheckProvider.GetACC_CheckByRowStatusID(RowStatusID);
        return aCC_Check;
    }


    public static ACC_Check GetACC_CheckByCheckID(int CheckID)
    {
        ACC_Check aCC_Check = new ACC_Check();
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        aCC_Check = sqlACC_CheckProvider.GetACC_CheckByCheckID(CheckID);
        return aCC_Check;
    }


    public static DataSet GetACC_CheckByCheckID(int CheckID,bool isDataset)
    {
        DataSet aCC_Check = new DataSet();
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        aCC_Check = sqlACC_CheckProvider.GetACC_CheckByCheckID(CheckID,true);
        return aCC_Check;
    }

    public static int InsertACC_Check(ACC_Check aCC_Check)
    {
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        return sqlACC_CheckProvider.InsertACC_Check(aCC_Check);
    }


    public static int CheckBounchByCheckID(ACC_Check aCC_Check)
    {
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        return sqlACC_CheckProvider.CheckBounchByCheckID(aCC_Check);
    }

    public static int CheckTransactinoCompletedByCheckID(ACC_Check aCC_Check)
    {
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        return sqlACC_CheckProvider.CheckTransactinoCompletedByCheckID(aCC_Check);
    }


    public static bool UpdateACC_Check(ACC_Check aCC_Check)
    {
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        return sqlACC_CheckProvider.UpdateACC_Check(aCC_Check);
    }

    public static bool DeleteACC_Check(int aCC_CheckID)
    {
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        return sqlACC_CheckProvider.DeleteACC_Check(aCC_CheckID);
    }

    public static DataSet SearchACC_Checks(string whomUserID, string whoUserID, string checkNo, int bankID, string checkDate,int RowStatusID)
    {
        DataSet aCC_Checks = new DataSet();
        SqlACC_CheckProvider sqlACC_CheckProvider = new SqlACC_CheckProvider();
        aCC_Checks = sqlACC_CheckProvider.SearchACC_Checks(whomUserID, whoUserID, checkNo, bankID, checkDate, RowStatusID);
        return aCC_Checks;
    }
}

