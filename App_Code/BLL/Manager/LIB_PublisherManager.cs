using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class LIB_PublisherManager
{
	public LIB_PublisherManager()
	{
	}

    public static DataSet  GetAllLIB_Publishers()
    {
       DataSet lIB_Publishers = new DataSet();
        SqlLIB_PublisherProvider sqlLIB_PublisherProvider = new SqlLIB_PublisherProvider();
        lIB_Publishers = sqlLIB_PublisherProvider.GetAllLIB_Publishers();
        return lIB_Publishers;
    }

	public static void lIB_PublishersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadLIB_PublisherPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlLIB_PublisherProvider sqlLIB_PublisherProvider = new SqlLIB_PublisherProvider();
		DataSet ds =  sqlLIB_PublisherProvider.GetLIB_PublisherPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 lIB_PublishersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllLIB_Publisher()
    {
       DataSet lIB_Publishers = new DataSet();
        SqlLIB_PublisherProvider sqlLIB_PublisherProvider = new SqlLIB_PublisherProvider();
        lIB_Publishers = sqlLIB_PublisherProvider.GetDropDownListAllLIB_Publisher();
        return lIB_Publishers;
    }


    public static LIB_Publisher GetLIB_PublisherByPublisherID(int PublisherID)
    {
        LIB_Publisher lIB_Publisher = new LIB_Publisher();
        SqlLIB_PublisherProvider sqlLIB_PublisherProvider = new SqlLIB_PublisherProvider();
        lIB_Publisher = sqlLIB_PublisherProvider.GetLIB_PublisherByPublisherID(PublisherID);
        return lIB_Publisher;
    }


    public static int InsertLIB_Publisher(LIB_Publisher lIB_Publisher)
    {
        SqlLIB_PublisherProvider sqlLIB_PublisherProvider = new SqlLIB_PublisherProvider();
        return sqlLIB_PublisherProvider.InsertLIB_Publisher(lIB_Publisher);
    }


    public static bool UpdateLIB_Publisher(LIB_Publisher lIB_Publisher)
    {
        SqlLIB_PublisherProvider sqlLIB_PublisherProvider = new SqlLIB_PublisherProvider();
        return sqlLIB_PublisherProvider.UpdateLIB_Publisher(lIB_Publisher);
    }

    public static bool DeleteLIB_Publisher(int lIB_PublisherID)
    {
        SqlLIB_PublisherProvider sqlLIB_PublisherProvider = new SqlLIB_PublisherProvider();
        return sqlLIB_PublisherProvider.DeleteLIB_Publisher(lIB_PublisherID);
    }
}

