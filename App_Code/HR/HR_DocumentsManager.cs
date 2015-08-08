using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_DocumentsManager
{
	public HR_DocumentsManager()
	{
	}

    public static DataSet  GetAllHR_Documentss()
    {
       DataSet hR_Documentss = new DataSet();
        SqlHR_DocumentsProvider sqlHR_DocumentsProvider = new SqlHR_DocumentsProvider();
        hR_Documentss = sqlHR_DocumentsProvider.GetAllHR_Documentss();
        return hR_Documentss;
    }

	public static void hR_DocumentssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_DocumentsPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_DocumentsProvider sqlHR_DocumentsProvider = new SqlHR_DocumentsProvider();
		DataSet ds =  sqlHR_DocumentsProvider.GetHR_DocumentsPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_DocumentssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Documents()
    {
       DataSet hR_Documentss = new DataSet();
        SqlHR_DocumentsProvider sqlHR_DocumentsProvider = new SqlHR_DocumentsProvider();
        hR_Documentss = sqlHR_DocumentsProvider.GetDropDownLisAllHR_Documents();
        return hR_Documentss;
    }

    public static DataSet   GetAllHR_DocumentssWithRelation()
    {
       DataSet hR_Documentss = new DataSet();
        SqlHR_DocumentsProvider sqlHR_DocumentsProvider = new SqlHR_DocumentsProvider();
        hR_Documentss = sqlHR_DocumentsProvider.GetAllHR_Documentss();
        return hR_Documentss;
    }


    public static  DataSet   GetHR_DocumentsByEmployeeID(string EmployeeID)
    {
        DataSet hR_Documents = new DataSet();
        SqlHR_DocumentsProvider sqlHR_DocumentsProvider = new SqlHR_DocumentsProvider();
        hR_Documents = sqlHR_DocumentsProvider.GetHR_DocumentsByEmployeeID(EmployeeID);
        return hR_Documents;
    }


    public static HR_Documents GetHR_DocumentsByDocumentsID(int DocumentsID)
    {
        HR_Documents hR_Documents = new HR_Documents();
        SqlHR_DocumentsProvider sqlHR_DocumentsProvider = new SqlHR_DocumentsProvider();
        hR_Documents = sqlHR_DocumentsProvider.GetHR_DocumentsByDocumentsID(DocumentsID);
        return hR_Documents;
    }


    public static int InsertHR_Documents(HR_Documents hR_Documents)
    {
        SqlHR_DocumentsProvider sqlHR_DocumentsProvider = new SqlHR_DocumentsProvider();
        return sqlHR_DocumentsProvider.InsertHR_Documents(hR_Documents);
    }


    public static bool UpdateHR_Documents(HR_Documents hR_Documents)
    {
        SqlHR_DocumentsProvider sqlHR_DocumentsProvider = new SqlHR_DocumentsProvider();
        return sqlHR_DocumentsProvider.UpdateHR_Documents(hR_Documents);
    }

    public static bool DeleteHR_Documents(int hR_DocumentsID)
    {
        SqlHR_DocumentsProvider sqlHR_DocumentsProvider = new SqlHR_DocumentsProvider();
        return sqlHR_DocumentsProvider.DeleteHR_Documents(hR_DocumentsID);
    }
}

