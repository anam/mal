using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class LIB_CategoryManager
{
	public LIB_CategoryManager()
	{
	}

    public static DataSet  GetAllLIB_Categories()
    {
       DataSet lIB_Categories = new DataSet();
        SqlLIB_CategoryProvider sqlLIB_CategoryProvider = new SqlLIB_CategoryProvider();
        lIB_Categories = sqlLIB_CategoryProvider.GetAllLIB_Categories();
        return lIB_Categories;
    }

	public static void lIB_CategoriesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadLIB_CategoryPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlLIB_CategoryProvider sqlLIB_CategoryProvider = new SqlLIB_CategoryProvider();
		DataSet ds =  sqlLIB_CategoryProvider.GetLIB_CategoryPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 lIB_CategoriesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllLIB_Category()
    {
       DataSet lIB_Categories = new DataSet();
        SqlLIB_CategoryProvider sqlLIB_CategoryProvider = new SqlLIB_CategoryProvider();
        lIB_Categories = sqlLIB_CategoryProvider.GetDropDownLisAllLIB_Category();
        return lIB_Categories;
    }


    public static LIB_Category GetLIB_CategoryByCategoryID(int CategoryID)
    {
        LIB_Category lIB_Category = new LIB_Category();
        SqlLIB_CategoryProvider sqlLIB_CategoryProvider = new SqlLIB_CategoryProvider();
        lIB_Category = sqlLIB_CategoryProvider.GetLIB_CategoryByCategoryID(CategoryID);
        return lIB_Category;
    }


    public static int InsertLIB_Category(LIB_Category lIB_Category)
    {
        SqlLIB_CategoryProvider sqlLIB_CategoryProvider = new SqlLIB_CategoryProvider();
        return sqlLIB_CategoryProvider.InsertLIB_Category(lIB_Category);
    }


    public static bool UpdateLIB_Category(LIB_Category lIB_Category)
    {
        SqlLIB_CategoryProvider sqlLIB_CategoryProvider = new SqlLIB_CategoryProvider();
        return sqlLIB_CategoryProvider.UpdateLIB_Category(lIB_Category);
    }

    public static bool DeleteLIB_Category(int lIB_CategoryID)
    {
        SqlLIB_CategoryProvider sqlLIB_CategoryProvider = new SqlLIB_CategoryProvider();
        return sqlLIB_CategoryProvider.DeleteLIB_Category(lIB_CategoryID);
    }
}

