using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ComprehensionManager
{
	public STD_ComprehensionManager()
	{
	}

    public static DataSet  GetAllSTD_Comprehensions()
    {
       DataSet sTD_Comprehensions = new DataSet();
        SqlSTD_ComprehensionProvider sqlSTD_ComprehensionProvider = new SqlSTD_ComprehensionProvider();
        sTD_Comprehensions = sqlSTD_ComprehensionProvider.GetAllSTD_Comprehensions();
        return sTD_Comprehensions;
    }

	public static void sTD_ComprehensionsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ComprehensionPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ComprehensionProvider sqlSTD_ComprehensionProvider = new SqlSTD_ComprehensionProvider();
		DataSet ds =  sqlSTD_ComprehensionProvider.GetSTD_ComprehensionPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ComprehensionsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Comprehension()
    {
       DataSet sTD_Comprehensions = new DataSet();
        SqlSTD_ComprehensionProvider sqlSTD_ComprehensionProvider = new SqlSTD_ComprehensionProvider();
        sTD_Comprehensions = sqlSTD_ComprehensionProvider.GetDropDownListAllSTD_Comprehension();
        return sTD_Comprehensions;
    }


    public static STD_Comprehension GetSTD_ComprehensionByComprehensionID(int ComprehensionID)
    {
        STD_Comprehension sTD_Comprehension = new STD_Comprehension();
        SqlSTD_ComprehensionProvider sqlSTD_ComprehensionProvider = new SqlSTD_ComprehensionProvider();
        sTD_Comprehension = sqlSTD_ComprehensionProvider.GetSTD_ComprehensionByComprehensionID(ComprehensionID);
        return sTD_Comprehension;
    }


    public static int InsertSTD_Comprehension(STD_Comprehension sTD_Comprehension)
    {
        SqlSTD_ComprehensionProvider sqlSTD_ComprehensionProvider = new SqlSTD_ComprehensionProvider();
        return sqlSTD_ComprehensionProvider.InsertSTD_Comprehension(sTD_Comprehension);
    }


    public static bool UpdateSTD_Comprehension(STD_Comprehension sTD_Comprehension)
    {
        SqlSTD_ComprehensionProvider sqlSTD_ComprehensionProvider = new SqlSTD_ComprehensionProvider();
        return sqlSTD_ComprehensionProvider.UpdateSTD_Comprehension(sTD_Comprehension);
    }

    public static bool DeleteSTD_Comprehension(int sTD_ComprehensionID)
    {
        SqlSTD_ComprehensionProvider sqlSTD_ComprehensionProvider = new SqlSTD_ComprehensionProvider();
        return sqlSTD_ComprehensionProvider.DeleteSTD_Comprehension(sTD_ComprehensionID);
    }
}

