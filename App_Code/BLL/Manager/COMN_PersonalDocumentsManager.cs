using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_PersonalDocumentsManager
{
	public COMN_PersonalDocumentsManager()
	{
	}

    public static DataSet  GetAllCOMN_PersonalDocumentss()
    {
       DataSet cOMN_PersonalDocumentss = new DataSet();
        SqlCOMN_PersonalDocumentsProvider sqlCOMN_PersonalDocumentsProvider = new SqlCOMN_PersonalDocumentsProvider();
        cOMN_PersonalDocumentss = sqlCOMN_PersonalDocumentsProvider.GetAllCOMN_PersonalDocumentss();
        return cOMN_PersonalDocumentss;
    }

	public static void cOMN_PersonalDocumentssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_PersonalDocumentsPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_PersonalDocumentsProvider sqlCOMN_PersonalDocumentsProvider = new SqlCOMN_PersonalDocumentsProvider();
		DataSet ds =  sqlCOMN_PersonalDocumentsProvider.GetCOMN_PersonalDocumentsPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_PersonalDocumentssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_PersonalDocuments()
    {
       DataSet cOMN_PersonalDocumentss = new DataSet();
        SqlCOMN_PersonalDocumentsProvider sqlCOMN_PersonalDocumentsProvider = new SqlCOMN_PersonalDocumentsProvider();
        cOMN_PersonalDocumentss = sqlCOMN_PersonalDocumentsProvider.GetDropDownListAllCOMN_PersonalDocuments();
        return cOMN_PersonalDocumentss;
    }


    public static COMN_PersonalDocuments GetCOMN_UserByUserID(string UserID)
    {
        COMN_PersonalDocuments cOMN_PersonalDocuments = new COMN_PersonalDocuments();
        SqlCOMN_PersonalDocumentsProvider sqlCOMN_PersonalDocumentsProvider = new SqlCOMN_PersonalDocumentsProvider();
        cOMN_PersonalDocuments = sqlCOMN_PersonalDocumentsProvider.GetCOMN_PersonalDocumentsByUserID(UserID);
        return cOMN_PersonalDocuments;
    }


    public static COMN_PersonalDocuments GetCOMN_PersonalDocumentsByPersonalDocumentsID(int PersonalDocumentsID)
    {
        COMN_PersonalDocuments cOMN_PersonalDocuments = new COMN_PersonalDocuments();
        SqlCOMN_PersonalDocumentsProvider sqlCOMN_PersonalDocumentsProvider = new SqlCOMN_PersonalDocumentsProvider();
        cOMN_PersonalDocuments = sqlCOMN_PersonalDocumentsProvider.GetCOMN_PersonalDocumentsByPersonalDocumentsID(PersonalDocumentsID);
        return cOMN_PersonalDocuments;
    }


    public static int InsertCOMN_PersonalDocuments(COMN_PersonalDocuments cOMN_PersonalDocuments)
    {
        SqlCOMN_PersonalDocumentsProvider sqlCOMN_PersonalDocumentsProvider = new SqlCOMN_PersonalDocumentsProvider();
        return sqlCOMN_PersonalDocumentsProvider.InsertCOMN_PersonalDocuments(cOMN_PersonalDocuments);
    }


    public static bool UpdateCOMN_PersonalDocuments(COMN_PersonalDocuments cOMN_PersonalDocuments)
    {
        SqlCOMN_PersonalDocumentsProvider sqlCOMN_PersonalDocumentsProvider = new SqlCOMN_PersonalDocumentsProvider();
        return sqlCOMN_PersonalDocumentsProvider.UpdateCOMN_PersonalDocuments(cOMN_PersonalDocuments);
    }

    public static bool DeleteCOMN_PersonalDocuments(int cOMN_PersonalDocumentsID)
    {
        SqlCOMN_PersonalDocumentsProvider sqlCOMN_PersonalDocumentsProvider = new SqlCOMN_PersonalDocumentsProvider();
        return sqlCOMN_PersonalDocumentsProvider.DeleteCOMN_PersonalDocuments(cOMN_PersonalDocumentsID);
    }
}

