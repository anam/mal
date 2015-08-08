using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class INV_MRRInfoMasterManager
{
	public INV_MRRInfoMasterManager()
	{
	}

    public static DataSet  GetAllINV_MRRInfoMasters()
    {
       DataSet iNV_MRRInfoMasters = new DataSet();
        SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
        iNV_MRRInfoMasters = sqlINV_MRRInfoMasterProvider.GetAllINV_MRRInfoMasters();
        return iNV_MRRInfoMasters;
    }

	public static void iNV_MRRInfoMastersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadINV_MRRInfoMasterPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
		DataSet ds =  sqlINV_MRRInfoMasterProvider.GetINV_MRRInfoMasterPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 iNV_MRRInfoMastersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllINV_MRRInfoMaster()
    {
       DataSet iNV_MRRInfoMasters = new DataSet();
        SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
        iNV_MRRInfoMasters = sqlINV_MRRInfoMasterProvider.GetDropDownListAllINV_MRRInfoMaster();
        return iNV_MRRInfoMasters;
    }

    public static DataSet   GetAllINV_MRRInfoMastersWithRelation()
    {
       DataSet iNV_MRRInfoMasters = new DataSet();
        SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
        iNV_MRRInfoMasters = sqlINV_MRRInfoMasterProvider.GetAllINV_MRRInfoMasters();
        return iNV_MRRInfoMasters;
    }


    public static INV_MRRInfoMaster GetSTD_CampusByCampusID(int CampusID)
    {
        INV_MRRInfoMaster iNV_MRRInfoMaster = new INV_MRRInfoMaster();
        SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
        iNV_MRRInfoMaster = sqlINV_MRRInfoMasterProvider.GetINV_MRRInfoMasterByCampusID(CampusID);
        return iNV_MRRInfoMaster;
    }


    public static INV_MRRInfoMaster GetINV_StoreByStoreID(int StoreID)
    {
        INV_MRRInfoMaster iNV_MRRInfoMaster = new INV_MRRInfoMaster();
        SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
        iNV_MRRInfoMaster = sqlINV_MRRInfoMasterProvider.GetINV_MRRInfoMasterByStoreID(StoreID);
        return iNV_MRRInfoMaster;
    }


    public static INV_MRRInfoMaster GetINV_MRRInfoMasterByMRRInfoMasterID(int MRRInfoMasterID)
    {
        INV_MRRInfoMaster iNV_MRRInfoMaster = new INV_MRRInfoMaster();
        SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
        iNV_MRRInfoMaster = sqlINV_MRRInfoMasterProvider.GetINV_MRRInfoMasterByMRRInfoMasterID(MRRInfoMasterID);
        return iNV_MRRInfoMaster;
    }


    public static int InsertINV_MRRInfoMaster(INV_MRRInfoMaster iNV_MRRInfoMaster)
    {
        SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
        return sqlINV_MRRInfoMasterProvider.InsertINV_MRRInfoMaster(iNV_MRRInfoMaster);
    }


    public static bool UpdateINV_MRRInfoMaster(INV_MRRInfoMaster iNV_MRRInfoMaster)
    {
        SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
        return sqlINV_MRRInfoMasterProvider.UpdateINV_MRRInfoMaster(iNV_MRRInfoMaster);
    }

    public static bool DeleteINV_MRRInfoMaster(int iNV_MRRInfoMasterID)
    {
        SqlINV_MRRInfoMasterProvider sqlINV_MRRInfoMasterProvider = new SqlINV_MRRInfoMasterProvider();
        return sqlINV_MRRInfoMasterProvider.DeleteINV_MRRInfoMaster(iNV_MRRInfoMasterID);
    }
}

