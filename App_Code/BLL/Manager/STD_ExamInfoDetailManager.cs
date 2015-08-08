using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ExamInfoDetailManager
{
	public STD_ExamInfoDetailManager()
	{
	}

    public static DataSet  GetAllSTD_ExamInfoDetails()
    {
       DataSet sTD_ExamInfoDetails = new DataSet();
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        sTD_ExamInfoDetails = sqlSTD_ExamInfoDetailProvider.GetAllSTD_ExamInfoDetails();
        return sTD_ExamInfoDetails;
    }

	public static void sTD_ExamInfoDetailsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ExamInfoDetailPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
		DataSet ds =  sqlSTD_ExamInfoDetailProvider.GetSTD_ExamInfoDetailPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ExamInfoDetailsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ExamInfoDetail()
    {
       DataSet sTD_ExamInfoDetails = new DataSet();
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        sTD_ExamInfoDetails = sqlSTD_ExamInfoDetailProvider.GetDropDownLisAllSTD_ExamInfoDetail();
        return sTD_ExamInfoDetails;
    }

    public static DataSet   GetAllSTD_ExamInfoDetailsWithRelation()
    {
       DataSet sTD_ExamInfoDetails = new DataSet();
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        sTD_ExamInfoDetails = sqlSTD_ExamInfoDetailProvider.GetAllSTD_ExamInfoDetails();
        return sTD_ExamInfoDetails;
    }


    public static STD_ExamInfoDetail GetSTD_ExamInfoByExamInfoID(int ExamInfoID)
    {
        STD_ExamInfoDetail sTD_ExamInfoDetail = new STD_ExamInfoDetail();
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        sTD_ExamInfoDetail = sqlSTD_ExamInfoDetailProvider.GetSTD_ExamInfoDetailByExamInfoID(ExamInfoID);
        return sTD_ExamInfoDetail;
    }


    public static STD_ExamInfoDetail GetSTD_StudentByStudentID(string StudentID)
    {
        STD_ExamInfoDetail sTD_ExamInfoDetail = new STD_ExamInfoDetail();
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        sTD_ExamInfoDetail = sqlSTD_ExamInfoDetailProvider.GetSTD_ExamInfoDetailByStudentID(StudentID);
        return sTD_ExamInfoDetail;
    }


    public static STD_ExamInfoDetail GetSTD_SubjectBySubjectID(int SubjectID)
    {
        STD_ExamInfoDetail sTD_ExamInfoDetail = new STD_ExamInfoDetail();
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        sTD_ExamInfoDetail = sqlSTD_ExamInfoDetailProvider.GetSTD_ExamInfoDetailBySubjectID(SubjectID);
        return sTD_ExamInfoDetail;
    }


    public static STD_ExamInfoDetail GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_ExamInfoDetail sTD_ExamInfoDetail = new STD_ExamInfoDetail();
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        sTD_ExamInfoDetail = sqlSTD_ExamInfoDetailProvider.GetSTD_ExamInfoDetailByRowStatusID(RowStatusID);
        return sTD_ExamInfoDetail;
    }


    public static STD_ExamInfoDetail GetSTD_ExamInfoDetailByExamInfoDetailID(int ExamInfoDetailID)
    {
        STD_ExamInfoDetail sTD_ExamInfoDetail = new STD_ExamInfoDetail();
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        sTD_ExamInfoDetail = sqlSTD_ExamInfoDetailProvider.GetSTD_ExamInfoDetailByExamInfoDetailID(ExamInfoDetailID);
        return sTD_ExamInfoDetail;
    }


    public static int InsertSTD_ExamInfoDetail(STD_ExamInfoDetail sTD_ExamInfoDetail)
    {
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        return sqlSTD_ExamInfoDetailProvider.InsertSTD_ExamInfoDetail(sTD_ExamInfoDetail);
    }


    public static bool UpdateSTD_ExamInfoDetail(STD_ExamInfoDetail sTD_ExamInfoDetail)
    {
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        return sqlSTD_ExamInfoDetailProvider.UpdateSTD_ExamInfoDetail(sTD_ExamInfoDetail);
    }

    public static bool DeleteSTD_ExamInfoDetail(int sTD_ExamInfoDetailID)
    {
        SqlSTD_ExamInfoDetailProvider sqlSTD_ExamInfoDetailProvider = new SqlSTD_ExamInfoDetailProvider();
        return sqlSTD_ExamInfoDetailProvider.DeleteSTD_ExamInfoDetail(sTD_ExamInfoDetailID);
    }
}

