using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class LIB_AuthorManager
{
	public LIB_AuthorManager()
	{
	}

    public static DataSet  GetAllLIB_Authors()
    {
       DataSet lIB_Authors = new DataSet();
        SqlLIB_AuthorProvider sqlLIB_AuthorProvider = new SqlLIB_AuthorProvider();
        lIB_Authors = sqlLIB_AuthorProvider.GetAllLIB_Authors();
        return lIB_Authors;
    }

	public static void lIB_AuthorsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadLIB_AuthorPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlLIB_AuthorProvider sqlLIB_AuthorProvider = new SqlLIB_AuthorProvider();
		DataSet ds =  sqlLIB_AuthorProvider.GetLIB_AuthorPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 lIB_AuthorsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}//SubCategory
    public static DataSet  GetDropDownListAllLIB_Author()
    {
       DataSet lIB_Authors = new DataSet();
        SqlLIB_AuthorProvider sqlLIB_AuthorProvider = new SqlLIB_AuthorProvider();
        lIB_Authors = sqlLIB_AuthorProvider.GetDropDownListAllLIB_Author();
        return lIB_Authors;
    }


    public static LIB_Author GetLIB_AuthorByAuthorID(int AuthorID)
    {
        LIB_Author lIB_Author = new LIB_Author();
        SqlLIB_AuthorProvider sqlLIB_AuthorProvider = new SqlLIB_AuthorProvider();
        lIB_Author = sqlLIB_AuthorProvider.GetLIB_AuthorByAuthorID(AuthorID);
        return lIB_Author;
    }


    public static int InsertLIB_Author(LIB_Author lIB_Author)
    {
        SqlLIB_AuthorProvider sqlLIB_AuthorProvider = new SqlLIB_AuthorProvider();
        return sqlLIB_AuthorProvider.InsertLIB_Author(lIB_Author);
    }


    public static bool UpdateLIB_Author(LIB_Author lIB_Author)
    {
        SqlLIB_AuthorProvider sqlLIB_AuthorProvider = new SqlLIB_AuthorProvider();
        return sqlLIB_AuthorProvider.UpdateLIB_Author(lIB_Author);
    }

    public static bool DeleteLIB_Author(int lIB_AuthorID)
    {
        SqlLIB_AuthorProvider sqlLIB_AuthorProvider = new SqlLIB_AuthorProvider();
        return sqlLIB_AuthorProvider.DeleteLIB_Author(lIB_AuthorID);
    }
}

