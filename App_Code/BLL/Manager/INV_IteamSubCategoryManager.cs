using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class INV_IteamSubCategoryManager
{
	public INV_IteamSubCategoryManager()
	{
	}

    public static DataSet  GetAllINV_IteamSubCategories()
    {
       DataSet iNV_IteamSubCategories = new DataSet();
        SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
        iNV_IteamSubCategories = sqlINV_IteamSubCategoryProvider.GetAllINV_IteamSubCategories();
        return iNV_IteamSubCategories;
    }

	public static void iNV_IteamSubCategoriesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadINV_IteamSubCategoryPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
		DataSet ds =  sqlINV_IteamSubCategoryProvider.GetINV_IteamSubCategoryPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 iNV_IteamSubCategoriesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllINV_IteamSubCategory()
    {
       DataSet iNV_IteamSubCategories = new DataSet();
        SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
        iNV_IteamSubCategories = sqlINV_IteamSubCategoryProvider.GetDropDownListAllINV_IteamSubCategory();
        return iNV_IteamSubCategories;
    }

    public static DataSet   GetAllINV_IteamSubCategoriesWithRelation()
    {
       DataSet iNV_IteamSubCategories = new DataSet();
        SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
        iNV_IteamSubCategories = sqlINV_IteamSubCategoryProvider.GetAllINV_IteamSubCategories();
        return iNV_IteamSubCategories;
    }


    public static INV_IteamSubCategory GetINV_IteamCategoryByIteamCategoryID(int IteamCategoryID)
    {
        INV_IteamSubCategory iNV_IteamSubCategory = new INV_IteamSubCategory();
        SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
        iNV_IteamSubCategory = sqlINV_IteamSubCategoryProvider.GetINV_IteamSubCategoryByIteamCategoryID(IteamCategoryID);
        return iNV_IteamSubCategory;
    }


    public static DataSet GetINV_IteamCategoryByIteamCategoryID(int IteamCategoryID,bool isDataset)
    {
        DataSet iNV_IteamSubCategory = new DataSet();
        SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
        iNV_IteamSubCategory = sqlINV_IteamSubCategoryProvider.GetINV_IteamSubCategoryByIteamCategoryID(IteamCategoryID, isDataset);
        return iNV_IteamSubCategory;
    }



    public static INV_IteamSubCategory GetINV_IteamSubCategoryByIteamSubCategoryID(int IteamSubCategoryID)
    {
        INV_IteamSubCategory iNV_IteamSubCategory = new INV_IteamSubCategory();
        SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
        iNV_IteamSubCategory = sqlINV_IteamSubCategoryProvider.GetINV_IteamSubCategoryByIteamSubCategoryID(IteamSubCategoryID);
        return iNV_IteamSubCategory;
    }


    public static int InsertINV_IteamSubCategory(INV_IteamSubCategory iNV_IteamSubCategory)
    {
        SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
        return sqlINV_IteamSubCategoryProvider.InsertINV_IteamSubCategory(iNV_IteamSubCategory);
    }


    public static bool UpdateINV_IteamSubCategory(INV_IteamSubCategory iNV_IteamSubCategory)
    {
        SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
        return sqlINV_IteamSubCategoryProvider.UpdateINV_IteamSubCategory(iNV_IteamSubCategory);
    }

    public static bool DeleteINV_IteamSubCategory(int iNV_IteamSubCategoryID)
    {
        SqlINV_IteamSubCategoryProvider sqlINV_IteamSubCategoryProvider = new SqlINV_IteamSubCategoryProvider();
        return sqlINV_IteamSubCategoryProvider.DeleteINV_IteamSubCategory(iNV_IteamSubCategoryID);
    }
}

