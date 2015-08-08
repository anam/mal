using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class LIB_SubCategoryManager
{
	public LIB_SubCategoryManager()
	{
	}

    public static DataSet  GetAllLIB_SubCategories()
    {
       DataSet lIB_SubCategories = new DataSet();
        SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
        lIB_SubCategories = sqlLIB_SubCategoryProvider.GetAllLIB_SubCategories();
        return lIB_SubCategories;
    }

	public static void lIB_SubCategoriesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadLIB_SubCategoryPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
		DataSet ds =  sqlLIB_SubCategoryProvider.GetLIB_SubCategoryPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
        lIB_SubCategoriesPaggination(rptPager, recordCount, pageIndex, PageSize);//
	}
    public static DataSet  GetDropDownListAllLIB_SubCategory()
    {
       DataSet lIB_SubCategories = new DataSet();
        SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
        lIB_SubCategories = sqlLIB_SubCategoryProvider.GetDropDownLisAllLIB_SubCategory();
        return lIB_SubCategories;
    }
    public static DataSet GetDropDownListAllLIB_SubCategory(int CategoryID)
    {
        DataSet lIB_SubCategories = new DataSet();
        SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
        lIB_SubCategories = sqlLIB_SubCategoryProvider.GetDropDownLisAllLIB_SubCategory(CategoryID);
        return lIB_SubCategories;
    }

    public static DataSet   GetAllLIB_SubCategoriesWithRelation()
    {
       DataSet lIB_SubCategories = new DataSet();
        SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
        lIB_SubCategories = sqlLIB_SubCategoryProvider.GetAllLIB_SubCategories();
        return lIB_SubCategories;
    }


    public static LIB_SubCategory GetLIB_CategoryByCategoryID(int CategoryID)
    {
        LIB_SubCategory lIB_SubCategory = new LIB_SubCategory();
        SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
        lIB_SubCategory = sqlLIB_SubCategoryProvider.GetLIB_SubCategoryByCategoryID(CategoryID);
        return lIB_SubCategory;
    }


    public static LIB_SubCategory GetLIB_SubCategoryBySubCategoryID(int SubCategoryID)
    {
        LIB_SubCategory lIB_SubCategory = new LIB_SubCategory();
        SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
        lIB_SubCategory = sqlLIB_SubCategoryProvider.GetLIB_SubCategoryBySubCategoryID(SubCategoryID);
        return lIB_SubCategory;
    }


    public static int InsertLIB_SubCategory(LIB_SubCategory lIB_SubCategory)
    {
        SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
        return sqlLIB_SubCategoryProvider.InsertLIB_SubCategory(lIB_SubCategory);
    }


    public static bool UpdateLIB_SubCategory(LIB_SubCategory lIB_SubCategory)
    {
        SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
        return sqlLIB_SubCategoryProvider.UpdateLIB_SubCategory(lIB_SubCategory);
    }

    public static bool DeleteLIB_SubCategory(int lIB_SubCategoryID)
    {
        SqlLIB_SubCategoryProvider sqlLIB_SubCategoryProvider = new SqlLIB_SubCategoryProvider();
        return sqlLIB_SubCategoryProvider.DeleteLIB_SubCategory(lIB_SubCategoryID);
    }
}

