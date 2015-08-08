using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ExamDetailsManager
{
	public STD_ExamDetailsManager()
	{
	}

    public static DataSet  GetAllSTD_ExamDetailss()
    {
       DataSet sTD_ExamDetailss = new DataSet();
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        sTD_ExamDetailss = sqlSTD_ExamDetailsProvider.GetAllSTD_ExamDetailss();
        return sTD_ExamDetailss;
    }

	public static void sTD_ExamDetailssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ExamDetailsPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
		DataSet ds =  sqlSTD_ExamDetailsProvider.GetSTD_ExamDetailsPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ExamDetailssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ExamDetails()
    {
       DataSet sTD_ExamDetailss = new DataSet();
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        sTD_ExamDetailss = sqlSTD_ExamDetailsProvider.GetDropDownLisAllSTD_ExamDetails();
        return sTD_ExamDetailss;
    }

    public static DataSet   GetAllSTD_ExamDetailssWithRelation()
    {
       DataSet sTD_ExamDetailss = new DataSet();
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        sTD_ExamDetailss = sqlSTD_ExamDetailsProvider.GetAllSTD_ExamDetailss();
        return sTD_ExamDetailss;
    }


    public static STD_ExamDetails GetSTD_ExamByExamID(int ExamID)
    {
        STD_ExamDetails sTD_ExamDetails = new STD_ExamDetails();
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        sTD_ExamDetails = sqlSTD_ExamDetailsProvider.GetSTD_ExamDetailsByExamID(ExamID);
        return sTD_ExamDetails;
    }


    public static STD_ExamDetails GetSTD_ExamTypeByExamTypeID(int ExamTypeID)
    {
        STD_ExamDetails sTD_ExamDetails = new STD_ExamDetails();
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        sTD_ExamDetails = sqlSTD_ExamDetailsProvider.GetSTD_ExamDetailsByExamTypeID(ExamTypeID);
        return sTD_ExamDetails;
    }


    public static STD_ExamDetails GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_ExamDetails sTD_ExamDetails = new STD_ExamDetails();
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        sTD_ExamDetails = sqlSTD_ExamDetailsProvider.GetSTD_ExamDetailsByRowStatusID(RowStatusID);
        return sTD_ExamDetails;
    }


    public static STD_ExamDetails GetSTD_ExamDetailsByExamDetailsID(int ExamDetailsID)
    {
        STD_ExamDetails sTD_ExamDetails = new STD_ExamDetails();
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        sTD_ExamDetails = sqlSTD_ExamDetailsProvider.GetSTD_ExamDetailsByExamDetailsID(ExamDetailsID);
        return sTD_ExamDetails;
    }


    public static int InsertSTD_ExamDetails(STD_ExamDetails sTD_ExamDetails)
    {
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        return sqlSTD_ExamDetailsProvider.InsertSTD_ExamDetails(sTD_ExamDetails);
    }


    public static bool UpdateSTD_ExamDetails(STD_ExamDetails sTD_ExamDetails)
    {
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        return sqlSTD_ExamDetailsProvider.UpdateSTD_ExamDetails(sTD_ExamDetails);
    }

    public static bool DeleteSTD_ExamDetails(int sTD_ExamDetailsID)
    {
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        return sqlSTD_ExamDetailsProvider.DeleteSTD_ExamDetails(sTD_ExamDetailsID);
    }

    public static DataSet GetSTD_ExamDetailsMarksByExamID(int examID)
    {
        DataSet sTD_ExamDetailss = new DataSet();
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        sTD_ExamDetailss = sqlSTD_ExamDetailsProvider.GetSTD_ExamDetailsMarksByExamID(examID);
        return sTD_ExamDetailss;
    }

    public static DataSet GetSTD_ExamDetailByExamID(int examID)
    {
        DataSet sTD_ExamDetailss = new DataSet();
        SqlSTD_ExamDetailsProvider sqlSTD_ExamDetailsProvider = new SqlSTD_ExamDetailsProvider();
        sTD_ExamDetailss = sqlSTD_ExamDetailsProvider.GetSTD_ExamDetailByExamID(examID);
        return sTD_ExamDetailss;
    }
}

