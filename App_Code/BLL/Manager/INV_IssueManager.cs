using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class INV_IssueManager
{
	public INV_IssueManager()
	{
	}

    public static DataSet  GetAllINV_Issues()
    {
       DataSet iNV_Issues = new DataSet();
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        iNV_Issues = sqlINV_IssueProvider.GetAllINV_Issues();
        return iNV_Issues;
    }

	public static void iNV_IssuesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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

 	public static void LoadINV_IssuePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
		DataSet ds =  sqlINV_IssueProvider.GetINV_IssuePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 iNV_IssuesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static DataSet GetINV_IssueBySerachString(string searchSQLString)
    {
        DataSet iNV_Issues = new DataSet();
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        iNV_Issues = sqlINV_IssueProvider.GetINV_IssueBySerachString(searchSQLString);
        return iNV_Issues;
    }

    public static DataSet  GetDropDownListAllINV_Issue()
    {
       DataSet iNV_Issues = new DataSet();
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        iNV_Issues = sqlINV_IssueProvider.GetDropDownListAllINV_Issue();
        return iNV_Issues;
    }

    public static DataSet   GetAllINV_IssuesWithRelation()
    {
       DataSet iNV_Issues = new DataSet();
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        iNV_Issues = sqlINV_IssueProvider.GetAllINV_Issues();
        return iNV_Issues;
    }
    /// <summary>
    /// GetAllINV_IssuesCheckAvlqty
    /// </summary>
    /// <returns></returns>
    public static DataSet GetAllINV_IssuesCheckAvlqty(int ItemID,int CampusID,int StoreID)
    {
        DataSet iNV_Issues = new DataSet();
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        iNV_Issues = sqlINV_IssueProvider.GetAllINV_IssuesCheckAvlqty(ItemID, CampusID, StoreID);
        return iNV_Issues;
    }


    public static INV_Issue GetSTD_CampusByCampusID(int CampusID)
    {
        INV_Issue iNV_Issue = new INV_Issue();
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        iNV_Issue = sqlINV_IssueProvider.GetINV_IssueByCampusID(CampusID);
        return iNV_Issue;
    }


    public static INV_Issue GetINV_IssueMasterByIssueMasterID(int IssueMasterID)
    {
        INV_Issue iNV_Issue = new INV_Issue();
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        iNV_Issue = sqlINV_IssueProvider.GetINV_IssueByIssueMasterID(IssueMasterID);
        return iNV_Issue;
    }


    public static INV_Issue GetINV_StoreByStoreID(int StoreID)
    {
        INV_Issue iNV_Issue = new INV_Issue();
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        iNV_Issue = sqlINV_IssueProvider.GetINV_IssueByStoreID(StoreID);
        return iNV_Issue;
    }


    public static INV_Issue GetINV_IssueByIssueID(int IssueID)
    {
        INV_Issue iNV_Issue = new INV_Issue();
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        iNV_Issue = sqlINV_IssueProvider.GetINV_IssueByIssueID(IssueID);
        return iNV_Issue;
    }


    public static int InsertINV_Issue(INV_Issue iNV_Issue)
    {
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        return sqlINV_IssueProvider.InsertINV_Issue(iNV_Issue);
    }


    public static bool UpdateINV_Issue(INV_Issue iNV_Issue)
    {
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        return sqlINV_IssueProvider.UpdateINV_Issue(iNV_Issue);
    }

    public static bool DeleteINV_Issue(int iNV_IssueID)
    {
        SqlINV_IssueProvider sqlINV_IssueProvider = new SqlINV_IssueProvider();
        return sqlINV_IssueProvider.DeleteINV_Issue(iNV_IssueID);
    }
}

