using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class INV_StoreManager
{
    public INV_StoreManager()
    {
    }

    public static DataSet GetAllINV_Stores()
    {
        DataSet iNV_Stores = new DataSet();
        SqlINV_StoreProvider sqlINV_StoreProvider = new SqlINV_StoreProvider();
        iNV_Stores = sqlINV_StoreProvider.GetAllINV_Stores();
        return iNV_Stores;
    }

    public static void iNV_StoresPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static void LoadINV_StorePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlINV_StoreProvider sqlINV_StoreProvider = new SqlINV_StoreProvider();
        DataSet ds = sqlINV_StoreProvider.GetINV_StorePageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        iNV_StoresPaggination(rptPager, recordCount, pageIndex, PageSize);
    }
    public static DataSet GetDropDownListAllINV_Store()
    {
        DataSet iNV_Stores = new DataSet();
        SqlINV_StoreProvider sqlINV_StoreProvider = new SqlINV_StoreProvider();
        iNV_Stores = sqlINV_StoreProvider.GetDropDownListAllINV_Store();
        return iNV_Stores;
    }

    public static DataSet GetAllINV_StoresWithRelation()
    {
        DataSet iNV_Stores = new DataSet();
        SqlINV_StoreProvider sqlINV_StoreProvider = new SqlINV_StoreProvider();
        iNV_Stores = sqlINV_StoreProvider.GetAllINV_Stores();
        return iNV_Stores;
    }


    public static INV_Store GetSTD_CampusByCampusID(int CampusID)
    {
        INV_Store iNV_Store = new INV_Store();
        SqlINV_StoreProvider sqlINV_StoreProvider = new SqlINV_StoreProvider();
        iNV_Store = sqlINV_StoreProvider.GetINV_StoreByCampusID(CampusID);
        return iNV_Store;
    }


    public static INV_Store GetINV_StoreByStoreID(int StoreID)
    {
        INV_Store iNV_Store = new INV_Store();
        SqlINV_StoreProvider sqlINV_StoreProvider = new SqlINV_StoreProvider();
        iNV_Store = sqlINV_StoreProvider.GetINV_StoreByStoreID(StoreID);
        return iNV_Store;
    }


    public static int InsertINV_Store(INV_Store iNV_Store)
    {
        SqlINV_StoreProvider sqlINV_StoreProvider = new SqlINV_StoreProvider();
        return sqlINV_StoreProvider.InsertINV_Store(iNV_Store);
    }


    public static bool UpdateINV_Store(INV_Store iNV_Store)
    {
        SqlINV_StoreProvider sqlINV_StoreProvider = new SqlINV_StoreProvider();
        return sqlINV_StoreProvider.UpdateINV_Store(iNV_Store);
    }

    public static bool DeleteINV_Store(int iNV_StoreID)
    {
        SqlINV_StoreProvider sqlINV_StoreProvider = new SqlINV_StoreProvider();
        return sqlINV_StoreProvider.DeleteINV_Store(iNV_StoreID);
    }
}

