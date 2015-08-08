using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_PersonalDocumentsManager
{
	public HR_PersonalDocumentsManager()
	{
	}

    public static DataSet  GetAllHR_PersonalDocumentss()
    {
       DataSet hR_PersonalDocumentss = new DataSet();
        SqlHR_PersonalDocumentsProvider sqlHR_PersonalDocumentsProvider = new SqlHR_PersonalDocumentsProvider();
        hR_PersonalDocumentss = sqlHR_PersonalDocumentsProvider.GetAllHR_PersonalDocumentss();
        return hR_PersonalDocumentss;
    }

	public static void hR_PersonalDocumentssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_PersonalDocumentsPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_PersonalDocumentsProvider sqlHR_PersonalDocumentsProvider = new SqlHR_PersonalDocumentsProvider();
		DataSet ds =  sqlHR_PersonalDocumentsProvider.GetHR_PersonalDocumentsPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_PersonalDocumentssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_PersonalDocuments()
    {
       DataSet hR_PersonalDocumentss = new DataSet();
        SqlHR_PersonalDocumentsProvider sqlHR_PersonalDocumentsProvider = new SqlHR_PersonalDocumentsProvider();
        hR_PersonalDocumentss = sqlHR_PersonalDocumentsProvider.GetDropDownListAllHR_PersonalDocuments();
        return hR_PersonalDocumentss;
    }

    public static DataSet   GetAllHR_PersonalDocumentssWithRelation()
    {
       DataSet hR_PersonalDocumentss = new DataSet();
        SqlHR_PersonalDocumentsProvider sqlHR_PersonalDocumentsProvider = new SqlHR_PersonalDocumentsProvider();
        hR_PersonalDocumentss = sqlHR_PersonalDocumentsProvider.GetAllHR_PersonalDocumentss();
        return hR_PersonalDocumentss;
    }


    public static HR_PersonalDocuments GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_PersonalDocuments hR_PersonalDocuments = new HR_PersonalDocuments();
        SqlHR_PersonalDocumentsProvider sqlHR_PersonalDocumentsProvider = new SqlHR_PersonalDocumentsProvider();
        hR_PersonalDocuments = sqlHR_PersonalDocumentsProvider.GetHR_PersonalDocumentsByEmployeeID(EmployeeID);
        return hR_PersonalDocuments;
    }


    public static HR_PersonalDocuments GetHR_PersonalDocumentsByPersonalDocumentsID(int PersonalDocumentsID)
    {
        HR_PersonalDocuments hR_PersonalDocuments = new HR_PersonalDocuments();
        SqlHR_PersonalDocumentsProvider sqlHR_PersonalDocumentsProvider = new SqlHR_PersonalDocumentsProvider();
        hR_PersonalDocuments = sqlHR_PersonalDocumentsProvider.GetHR_PersonalDocumentsByPersonalDocumentsID(PersonalDocumentsID);
        return hR_PersonalDocuments;
    }


    public static int InsertHR_PersonalDocuments(HR_PersonalDocuments hR_PersonalDocuments)
    {
        SqlHR_PersonalDocumentsProvider sqlHR_PersonalDocumentsProvider = new SqlHR_PersonalDocumentsProvider();
        return sqlHR_PersonalDocumentsProvider.InsertHR_PersonalDocuments(hR_PersonalDocuments);
    }


    public static bool UpdateHR_PersonalDocuments(HR_PersonalDocuments hR_PersonalDocuments)
    {
        SqlHR_PersonalDocumentsProvider sqlHR_PersonalDocumentsProvider = new SqlHR_PersonalDocumentsProvider();
        return sqlHR_PersonalDocumentsProvider.UpdateHR_PersonalDocuments(hR_PersonalDocuments);
    }

    public static bool DeleteHR_PersonalDocuments(int hR_PersonalDocumentsID)
    {
        SqlHR_PersonalDocumentsProvider sqlHR_PersonalDocumentsProvider = new SqlHR_PersonalDocumentsProvider();
        return sqlHR_PersonalDocumentsProvider.DeleteHR_PersonalDocuments(hR_PersonalDocumentsID);
    }
}

