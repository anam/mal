using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class INV_IteamManager
{
	public INV_IteamManager()
	{
	}

    public static DataSet  GetAllINV_Iteams()
    {
       DataSet iNV_Iteams = new DataSet();
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        iNV_Iteams = sqlINV_IteamProvider.GetAllINV_Iteams();
        return iNV_Iteams;
    }

	public static void iNV_IteamsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadINV_IteamPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
		DataSet ds =  sqlINV_IteamProvider.GetINV_IteamPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 iNV_IteamsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static DataSet GetINV_IteamBySearchSQLString(string searchSQLString)
    {
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        DataSet ds = sqlINV_IteamProvider.GetINV_IteamBySearchSQLString(searchSQLString);
        return ds;
    }

    public static void LoadINV_IteamStockPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        DataSet ds = sqlINV_IteamProvider.GetINV_IteamStockPageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        iNV_IteamsPaggination(rptPager, recordCount, pageIndex, PageSize);
    }
    //LoadINV_IteamStockPage
    public static DataSet  GetDropDownListAllINV_Iteam()
    {
       DataSet iNV_Iteams = new DataSet();
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        iNV_Iteams = sqlINV_IteamProvider.GetDropDownListAllINV_Iteam();
        return iNV_Iteams;
    }

    public static DataSet   GetAllINV_IteamsWithRelation()
    {
       DataSet iNV_Iteams = new DataSet();
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        iNV_Iteams = sqlINV_IteamProvider.GetAllINV_Iteams();
        return iNV_Iteams;
    }


    public static INV_Iteam GetSTD_CampusByCampusID(int CampusID)
    {
        INV_Iteam iNV_Iteam = new INV_Iteam();
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        iNV_Iteam = sqlINV_IteamProvider.GetINV_IteamByCampusID(CampusID);
        return iNV_Iteam;
    }


    public static INV_Iteam GetINV_IteamByIteamID(int IteamID)
    {
        INV_Iteam iNV_Iteam = new INV_Iteam();
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        iNV_Iteam = sqlINV_IteamProvider.GetINV_IteamByIteamID(IteamID);
        return iNV_Iteam;
    }


    public static int InsertINV_Iteam(INV_Iteam iNV_Iteam)
    {
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        return sqlINV_IteamProvider.InsertINV_Iteam(iNV_Iteam);
    }


    public static bool UpdateINV_Iteam(INV_Iteam iNV_Iteam)
    {
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        return sqlINV_IteamProvider.UpdateINV_Iteam(iNV_Iteam);
    }

    public static bool DeleteINV_Iteam(int iNV_IteamID)
    {
        SqlINV_IteamProvider sqlINV_IteamProvider = new SqlINV_IteamProvider();
        return sqlINV_IteamProvider.DeleteINV_Iteam(iNV_IteamID);
    }
}

