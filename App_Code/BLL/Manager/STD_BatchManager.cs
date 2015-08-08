using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_BatchManager
{
	public STD_BatchManager()
	{
	}

    public static DataSet  GetAllSTD_Batchs()
    {
       DataSet sTD_Batchs = new DataSet();
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        sTD_Batchs = sqlSTD_BatchProvider.GetAllSTD_Batchs();
        return sTD_Batchs;
    }

	public static void sTD_BatchsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_BatchPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
		DataSet ds =  sqlSTD_BatchProvider.GetSTD_BatchPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_BatchsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Batch()
    {
       DataSet sTD_Batchs = new DataSet();
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        sTD_Batchs = sqlSTD_BatchProvider.GetDropDownLisAllSTD_Batch();
        return sTD_Batchs;
    }


    public static STD_Batch GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_Batch sTD_Batch = new STD_Batch();
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        sTD_Batch = sqlSTD_BatchProvider.GetSTD_BatchByRowStatusID(RowStatusID);
        return sTD_Batch;
    }


    public static STD_Batch GetSTD_BatchByBatchID(int BatchID)
    {
        STD_Batch sTD_Batch = new STD_Batch();
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        sTD_Batch = sqlSTD_BatchProvider.GetSTD_BatchByBatchID(BatchID);
        return sTD_Batch;
    }


    public static int InsertSTD_Batch(STD_Batch sTD_Batch)
    {
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        return sqlSTD_BatchProvider.InsertSTD_Batch(sTD_Batch);
    }


    public static bool UpdateSTD_Batch(STD_Batch sTD_Batch)
    {
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        return sqlSTD_BatchProvider.UpdateSTD_Batch(sTD_Batch);
    }

    public static bool DeleteSTD_Batch(int sTD_BatchID)
    {
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        return sqlSTD_BatchProvider.DeleteSTD_Batch(sTD_BatchID);
    }

    public static DataSet GetAllSTD_BatchMaxIDByYear(int year)
    {
        DataSet sTD_Batch = new DataSet();
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        sTD_Batch = sqlSTD_BatchProvider.GetAllSTD_BatchMaxIDByYear(year);
        return sTD_Batch;
    }

    public static DataSet GetAllSTD_BatchMaxIDByYearnID(int year,int batchID)
    {
        DataSet sTD_Batch = new DataSet();
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        sTD_Batch = sqlSTD_BatchProvider.GetAllSTD_BatchMaxIDByYearnID(year,batchID);
        return sTD_Batch;
    }
    public static STD_Batch GetSTD_BatchMaxIDByYear(int year)
    {
        STD_Batch sTD_Batch = new STD_Batch();
        SqlSTD_BatchProvider sqlSTD_BatchProvider = new SqlSTD_BatchProvider();
        sTD_Batch = sqlSTD_BatchProvider.GetSTD_BatchMaxIDByYear(year);
        return sTD_Batch;
    }
}

