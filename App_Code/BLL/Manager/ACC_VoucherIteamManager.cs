using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_VoucherIteamManager
{
	public ACC_VoucherIteamManager()
	{
	}

    public static DataSet  GetAllACC_VoucherIteams()
    {
       DataSet aCC_VoucherIteams = new DataSet();
        SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
        aCC_VoucherIteams = sqlACC_VoucherIteamProvider.GetAllACC_VoucherIteams();
        return aCC_VoucherIteams;
    }

	public static void aCC_VoucherIteamsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_VoucherIteamPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
		DataSet ds =  sqlACC_VoucherIteamProvider.GetACC_VoucherIteamPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_VoucherIteamsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_VoucherIteam()
    {
       DataSet aCC_VoucherIteams = new DataSet();
        SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
        aCC_VoucherIteams = sqlACC_VoucherIteamProvider.GetDropDownLisAllACC_VoucherIteam();
        return aCC_VoucherIteams;
    }

    public static DataSet   GetAllACC_VoucherIteamsWithRelation()
    {
       DataSet aCC_VoucherIteams = new DataSet();
        SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
        aCC_VoucherIteams = sqlACC_VoucherIteamProvider.GetAllACC_VoucherIteams();
        return aCC_VoucherIteams;
    }


    public static ACC_VoucherIteam GetACC_VoucherByVoucherID(int VoucherID)
    {
        ACC_VoucherIteam aCC_VoucherIteam = new ACC_VoucherIteam();
        SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
        aCC_VoucherIteam = sqlACC_VoucherIteamProvider.GetACC_VoucherIteamByVoucherID(VoucherID);
        return aCC_VoucherIteam;
    }


    public static ACC_VoucherIteam GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_VoucherIteam aCC_VoucherIteam = new ACC_VoucherIteam();
        SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
        aCC_VoucherIteam = sqlACC_VoucherIteamProvider.GetACC_VoucherIteamByRowStatusID(RowStatusID);
        return aCC_VoucherIteam;
    }


    public static ACC_VoucherIteam GetACC_VoucherIteamByVoucherIteamID(int VoucherIteamID)
    {
        ACC_VoucherIteam aCC_VoucherIteam = new ACC_VoucherIteam();
        SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
        aCC_VoucherIteam = sqlACC_VoucherIteamProvider.GetACC_VoucherIteamByVoucherIteamID(VoucherIteamID);
        return aCC_VoucherIteam;
    }


    public static int InsertACC_VoucherIteam(ACC_VoucherIteam aCC_VoucherIteam)
    {
        SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
        return sqlACC_VoucherIteamProvider.InsertACC_VoucherIteam(aCC_VoucherIteam);
    }


    public static bool UpdateACC_VoucherIteam(ACC_VoucherIteam aCC_VoucherIteam)
    {
        SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
        return sqlACC_VoucherIteamProvider.UpdateACC_VoucherIteam(aCC_VoucherIteam);
    }

    public static bool DeleteACC_VoucherIteam(int aCC_VoucherIteamID)
    {
        SqlACC_VoucherIteamProvider sqlACC_VoucherIteamProvider = new SqlACC_VoucherIteamProvider();
        return sqlACC_VoucherIteamProvider.DeleteACC_VoucherIteam(aCC_VoucherIteamID);
    }
}

