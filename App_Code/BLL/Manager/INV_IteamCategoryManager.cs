using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class INV_IteamCategoryManager
{
	public INV_IteamCategoryManager()
	{
	}

    public static DataSet  GetAllINV_IteamCategories()
    {
       DataSet iNV_IteamCategories = new DataSet();
        SqlINV_IteamCategoryProvider sqlINV_IteamCategoryProvider = new SqlINV_IteamCategoryProvider();
        iNV_IteamCategories = sqlINV_IteamCategoryProvider.GetAllINV_IteamCategories();
        return iNV_IteamCategories;
    }

	public static void iNV_IteamCategoriesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadINV_IteamCategoryPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlINV_IteamCategoryProvider sqlINV_IteamCategoryProvider = new SqlINV_IteamCategoryProvider();
		DataSet ds =  sqlINV_IteamCategoryProvider.GetINV_IteamCategoryPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 iNV_IteamCategoriesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllINV_IteamCategory()
    {
       DataSet iNV_IteamCategories = new DataSet();
        SqlINV_IteamCategoryProvider sqlINV_IteamCategoryProvider = new SqlINV_IteamCategoryProvider();
        iNV_IteamCategories = sqlINV_IteamCategoryProvider.GetDropDownListAllINV_IteamCategory();
        return iNV_IteamCategories;
    }


    public static INV_IteamCategory GetINV_IteamCategoryByIteamCategoryID(int IteamCategoryID)
    {
        INV_IteamCategory iNV_IteamCategory = new INV_IteamCategory();
        SqlINV_IteamCategoryProvider sqlINV_IteamCategoryProvider = new SqlINV_IteamCategoryProvider();
        iNV_IteamCategory = sqlINV_IteamCategoryProvider.GetINV_IteamCategoryByIteamCategoryID(IteamCategoryID);
        return iNV_IteamCategory;
    }


    public static int InsertINV_IteamCategory(INV_IteamCategory iNV_IteamCategory)
    {
        SqlINV_IteamCategoryProvider sqlINV_IteamCategoryProvider = new SqlINV_IteamCategoryProvider();
        return sqlINV_IteamCategoryProvider.InsertINV_IteamCategory(iNV_IteamCategory);
    }


    public static bool UpdateINV_IteamCategory(INV_IteamCategory iNV_IteamCategory)
    {
        SqlINV_IteamCategoryProvider sqlINV_IteamCategoryProvider = new SqlINV_IteamCategoryProvider();
        return sqlINV_IteamCategoryProvider.UpdateINV_IteamCategory(iNV_IteamCategory);
    }

    public static bool DeleteINV_IteamCategory(int iNV_IteamCategoryID)
    {
        SqlINV_IteamCategoryProvider sqlINV_IteamCategoryProvider = new SqlINV_IteamCategoryProvider();
        return sqlINV_IteamCategoryProvider.DeleteINV_IteamCategory(iNV_IteamCategoryID);
    }
}

