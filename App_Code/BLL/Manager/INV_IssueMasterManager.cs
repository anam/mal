using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class INV_IssueMasterManager
{
	public INV_IssueMasterManager()
	{
	}

    public static DataSet  GetAllINV_IssueMasters()
    {
       DataSet iNV_IssueMasters = new DataSet();
        SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
        iNV_IssueMasters = sqlINV_IssueMasterProvider.GetAllINV_IssueMasters();
        return iNV_IssueMasters;
    }

	public static void iNV_IssueMastersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadINV_IssueMasterPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
		DataSet ds =  sqlINV_IssueMasterProvider.GetINV_IssueMasterPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 iNV_IssueMastersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllINV_IssueMaster()
    {
       DataSet iNV_IssueMasters = new DataSet();
        SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
        iNV_IssueMasters = sqlINV_IssueMasterProvider.GetDropDownListAllINV_IssueMaster();
        return iNV_IssueMasters;
    }

    public static DataSet   GetAllINV_IssueMastersWithRelation()
    {
       DataSet iNV_IssueMasters = new DataSet();
        SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
        iNV_IssueMasters = sqlINV_IssueMasterProvider.GetAllINV_IssueMasters();
        return iNV_IssueMasters;
    }


    public static INV_IssueMaster GetSTD_CampusByCampusID(int CampusID)
    {
        INV_IssueMaster iNV_IssueMaster = new INV_IssueMaster();
        SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
        iNV_IssueMaster = sqlINV_IssueMasterProvider.GetINV_IssueMasterByCampusID(CampusID);
        return iNV_IssueMaster;
    }


    public static INV_IssueMaster GetINV_StoreByStoreID(int StoreID)
    {
        INV_IssueMaster iNV_IssueMaster = new INV_IssueMaster();
        SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
        iNV_IssueMaster = sqlINV_IssueMasterProvider.GetINV_IssueMasterByStoreID(StoreID);
        return iNV_IssueMaster;
    }


    public static INV_IssueMaster GetINV_IssueMasterByIssueMasterID(int IssueMasterID)
    {
        INV_IssueMaster iNV_IssueMaster = new INV_IssueMaster();
        SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
        iNV_IssueMaster = sqlINV_IssueMasterProvider.GetINV_IssueMasterByIssueMasterID(IssueMasterID);
        return iNV_IssueMaster;
    }


    public static int InsertINV_IssueMaster(INV_IssueMaster iNV_IssueMaster)
    {
        SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
        return sqlINV_IssueMasterProvider.InsertINV_IssueMaster(iNV_IssueMaster);
    }


    public static bool UpdateINV_IssueMaster(INV_IssueMaster iNV_IssueMaster)
    {
        SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
        return sqlINV_IssueMasterProvider.UpdateINV_IssueMaster(iNV_IssueMaster);
    }

    public static bool DeleteINV_IssueMaster(int iNV_IssueMasterID)
    {
        SqlINV_IssueMasterProvider sqlINV_IssueMasterProvider = new SqlINV_IssueMasterProvider();
        return sqlINV_IssueMasterProvider.DeleteINV_IssueMaster(iNV_IssueMasterID);
    }
}

