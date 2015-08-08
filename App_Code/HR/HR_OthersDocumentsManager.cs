using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_OthersDocumentsManager
{
	public HR_OthersDocumentsManager()
	{
	}

    public static DataSet  GetAllHR_OthersDocumentss()
    {
       DataSet hR_OthersDocumentss = new DataSet();
        SqlHR_OthersDocumentsProvider sqlHR_OthersDocumentsProvider = new SqlHR_OthersDocumentsProvider();
        hR_OthersDocumentss = sqlHR_OthersDocumentsProvider.GetAllHR_OthersDocumentss();
        return hR_OthersDocumentss;
    }

	public static void hR_OthersDocumentssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_OthersDocumentsPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_OthersDocumentsProvider sqlHR_OthersDocumentsProvider = new SqlHR_OthersDocumentsProvider();
		DataSet ds =  sqlHR_OthersDocumentsProvider.GetHR_OthersDocumentsPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_OthersDocumentssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_OthersDocuments()
    {
       DataSet hR_OthersDocumentss = new DataSet();
        SqlHR_OthersDocumentsProvider sqlHR_OthersDocumentsProvider = new SqlHR_OthersDocumentsProvider();
        hR_OthersDocumentss = sqlHR_OthersDocumentsProvider.GetDropDownLisAllHR_OthersDocuments();
        return hR_OthersDocumentss;
    }

    public static DataSet   GetAllHR_OthersDocumentssWithRelation()
    {
       DataSet hR_OthersDocumentss = new DataSet();
        SqlHR_OthersDocumentsProvider sqlHR_OthersDocumentsProvider = new SqlHR_OthersDocumentsProvider();
        hR_OthersDocumentss = sqlHR_OthersDocumentsProvider.GetAllHR_OthersDocumentss();
        return hR_OthersDocumentss;
    }


    public static DataSet GetHR_OthersDocumentsByEmployeeID(string EmployeeID)
    {
        DataSet hR_OthersDocumentss = new DataSet();

        SqlHR_OthersDocumentsProvider sqlHR_OthersDocumentsProvider = new SqlHR_OthersDocumentsProvider();
        hR_OthersDocumentss = sqlHR_OthersDocumentsProvider.GetHR_OthersDocumentsByEmployeeID(EmployeeID);
        return hR_OthersDocumentss;
    }


    public static HR_OthersDocuments GetHR_OthersDocumentsByOthersDocumentsID(int OthersDocumentsID)
    {
        HR_OthersDocuments hR_OthersDocuments = new HR_OthersDocuments();
        SqlHR_OthersDocumentsProvider sqlHR_OthersDocumentsProvider = new SqlHR_OthersDocumentsProvider();
        hR_OthersDocuments = sqlHR_OthersDocumentsProvider.GetHR_OthersDocumentsByOthersDocumentsID(OthersDocumentsID);
        return hR_OthersDocuments;
    }


    public static int InsertHR_OthersDocuments(HR_OthersDocuments hR_OthersDocuments)
    {
        SqlHR_OthersDocumentsProvider sqlHR_OthersDocumentsProvider = new SqlHR_OthersDocumentsProvider();
        return sqlHR_OthersDocumentsProvider.InsertHR_OthersDocuments(hR_OthersDocuments);
    }


    public static bool UpdateHR_OthersDocuments(HR_OthersDocuments hR_OthersDocuments)
    {
        SqlHR_OthersDocumentsProvider sqlHR_OthersDocumentsProvider = new SqlHR_OthersDocumentsProvider();
        return sqlHR_OthersDocumentsProvider.UpdateHR_OthersDocuments(hR_OthersDocuments);
    }

    public static bool DeleteHR_OthersDocuments(int hR_OthersDocumentsID)
    {
        SqlHR_OthersDocumentsProvider sqlHR_OthersDocumentsProvider = new SqlHR_OthersDocumentsProvider();
        return sqlHR_OthersDocumentsProvider.DeleteHR_OthersDocuments(hR_OthersDocumentsID);
    }
}

