using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class LIB_BookIssueManager
{
	public LIB_BookIssueManager()
	{
	}

    public static DataSet  GetAllLIB_BookIssues()
    {
       DataSet lIB_BookIssues = new DataSet();
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        lIB_BookIssues = sqlLIB_BookIssueProvider.GetAllLIB_BookIssues();
        return lIB_BookIssues;
    }

	public static void lIB_BookIssuesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadLIB_BookIssuePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
		DataSet ds =  sqlLIB_BookIssueProvider.GetLIB_BookIssuePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		lIB_BookIssuesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static DataSet GetLIB_IssueBooksBySearchString(string searchSQLString)
    {
        DataSet lIB_BookIssues = new DataSet();
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        lIB_BookIssues = sqlLIB_BookIssueProvider.GetLIB_IssueBooksBySearchString(searchSQLString);
        return lIB_BookIssues;
    }
    public static DataSet  GetDropDownListAllLIB_BookIssue()
    {
       DataSet lIB_BookIssues = new DataSet();
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        lIB_BookIssues = sqlLIB_BookIssueProvider.GetDropDownListAllLIB_BookIssue();
        return lIB_BookIssues;
    }

    public static DataSet   GetAllLIB_BookIssuesWithRelation()
    {
       DataSet lIB_BookIssues = new DataSet();
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        lIB_BookIssues = sqlLIB_BookIssueProvider.GetAllLIB_BookIssues();
        return lIB_BookIssues;
    }


    public static LIB_BookIssue GetLIB_BookByBookID(int BookID)
    {
        LIB_BookIssue lIB_BookIssue = new LIB_BookIssue();
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        lIB_BookIssue = sqlLIB_BookIssueProvider.GetLIB_BookIssueByBookID(BookID);
        return lIB_BookIssue;
    }


    public static LIB_BookIssue GetLIB_IssedToByIssedToID(string IssedToID)
    {
        LIB_BookIssue lIB_BookIssue = new LIB_BookIssue();
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        lIB_BookIssue = sqlLIB_BookIssueProvider.GetLIB_BookIssueByIssedToID(IssedToID);
        return lIB_BookIssue;
    }


    public static LIB_BookIssue GetLIB_BookIssueByBookIssueID(int BookIssueID)
    {
        LIB_BookIssue lIB_BookIssue = new LIB_BookIssue();
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        lIB_BookIssue = sqlLIB_BookIssueProvider.GetLIB_BookIssueByBookIssueID(BookIssueID);
        return lIB_BookIssue;
    }
    //InsertLIB_BookReceive

    public static int InsertLIB_BookIssue(LIB_BookIssue lIB_BookIssue)
    {
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        return sqlLIB_BookIssueProvider.InsertLIB_BookIssue(lIB_BookIssue);
    }

    public static int InsertLIB_BookReceive(LIB_BookIssue lIB_BookIssue)
    {
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        return sqlLIB_BookIssueProvider.InsertLIB_BookReceive(lIB_BookIssue);
    }


    public static bool UpdateLIB_BookIssue(LIB_BookIssue lIB_BookIssue)
    {
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        return sqlLIB_BookIssueProvider.UpdateLIB_BookIssue(lIB_BookIssue);
    }

    public static bool DeleteLIB_BookIssue(int lIB_BookIssueID)
    {
        SqlLIB_BookIssueProvider sqlLIB_BookIssueProvider = new SqlLIB_BookIssueProvider();
        return sqlLIB_BookIssueProvider.DeleteLIB_BookIssue(lIB_BookIssueID);
    }
}

