using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_HeadManager
{
	public ACC_HeadManager()
	{
	}

    public static DataSet  GetAllACC_Heads()
    {
       DataSet aCC_Heads = new DataSet();
        SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
        aCC_Heads = sqlACC_HeadProvider.GetAllACC_Heads();
        return aCC_Heads;
    }

	public static void aCC_HeadsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_HeadPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
		DataSet ds =  sqlACC_HeadProvider.GetACC_HeadPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_HeadsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_Head()
    {
       DataSet aCC_Heads = new DataSet();
        SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
        aCC_Heads = sqlACC_HeadProvider.GetDropDownLisAllACC_Head();
        return aCC_Heads;
    }

    public static DataSet   GetAllACC_HeadsWithRelation()
    {
       DataSet aCC_Heads = new DataSet();
        SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
        aCC_Heads = sqlACC_HeadProvider.GetAllACC_Heads();
        return aCC_Heads;
    }


    public static ACC_Head GetACC_AccountByAccountID(int AccountID)
    {
        ACC_Head aCC_Head = new ACC_Head();
        SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
        aCC_Head = sqlACC_HeadProvider.GetACC_HeadByAccountID(AccountID);
        return aCC_Head;
    }


    public static ACC_Head GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_Head aCC_Head = new ACC_Head();
        SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
        aCC_Head = sqlACC_HeadProvider.GetACC_HeadByRowStatusID(RowStatusID);
        return aCC_Head;
    }


    public static ACC_Head GetACC_HeadByHeadID(int HeadID)
    {
        ACC_Head aCC_Head = new ACC_Head();
        SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
        aCC_Head = sqlACC_HeadProvider.GetACC_HeadByHeadID(HeadID);
        return aCC_Head;
    }


    public static int InsertACC_Head(ACC_Head aCC_Head)
    {
        SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
        return sqlACC_HeadProvider.InsertACC_Head(aCC_Head);
    }


    public static bool UpdateACC_Head(ACC_Head aCC_Head)
    {
        SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
        return sqlACC_HeadProvider.UpdateACC_Head(aCC_Head);
    }

    public static bool DeleteACC_Head(int aCC_HeadID)
    {
        SqlACC_HeadProvider sqlACC_HeadProvider = new SqlACC_HeadProvider();
        return sqlACC_HeadProvider.DeleteACC_Head(aCC_HeadID);
    }
}

