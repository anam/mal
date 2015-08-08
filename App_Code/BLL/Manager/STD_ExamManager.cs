using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ExamManager
{
	public STD_ExamManager()
	{
	}

    public static DataSet  GetAllSTD_Exams()
    {
       DataSet sTD_Exams = new DataSet();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exams = sqlSTD_ExamProvider.GetAllSTD_Exams();
        return sTD_Exams;
    }

	public static void sTD_ExamsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ExamPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
		DataSet ds =  sqlSTD_ExamProvider.GetSTD_ExamPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ExamsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Exam()
    {
       DataSet sTD_Exams = new DataSet();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exams = sqlSTD_ExamProvider.GetDropDownLisAllSTD_Exam();
        return sTD_Exams;
    }

    public static DataSet   GetAllSTD_ExamsWithRelation()
    {
       DataSet sTD_Exams = new DataSet();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exams = sqlSTD_ExamProvider.GetAllSTD_Exams();
        return sTD_Exams;
    }


    public static STD_Exam GetSTD_ClassSubjectByClassSubjectID(int ClassSubjectID)
    {
        STD_Exam sTD_Exam = new STD_Exam();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exam = sqlSTD_ExamProvider.GetSTD_ExamByClassSubjectID(ClassSubjectID);
        return sTD_Exam;
    }


    public static DataSet GetSTD_ClassSubjectByClassSubjectID(int ClassSubjectID,bool isDataset)
    {
        DataSet sTD_Exam = new DataSet();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exam = sqlSTD_ExamProvider.GetSTD_ExamByClassSubjectID(ClassSubjectID,true);
        return sTD_Exam;
    }

    public static DataSet GetQuiz_ClassSubjectByClassSubjectID(int ClassSubjectID, bool isDataset)
    {
        DataSet sTD_Exam = new DataSet();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exam = sqlSTD_ExamProvider.GetQuiz_ExamByClassSubjectID(ClassSubjectID, true);
        return sTD_Exam;
    }


    public static STD_Exam GetSTD_ExamTypeByExamTypeID(int ExamTypeID)
    {
        STD_Exam sTD_Exam = new STD_Exam();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exam = sqlSTD_ExamProvider.GetSTD_ExamByExamTypeID(ExamTypeID);
        return sTD_Exam;
    }


    public static STD_Exam GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_Exam sTD_Exam = new STD_Exam();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exam = sqlSTD_ExamProvider.GetSTD_ExamByRowStatusID(RowStatusID);
        return sTD_Exam;
    }


    public static STD_Exam GetSTD_ExamByExamID(int ExamID)
    {
        STD_Exam sTD_Exam = new STD_Exam();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exam = sqlSTD_ExamProvider.GetSTD_ExamByExamID(ExamID);
        return sTD_Exam;
    }


    public static int InsertSTD_Exam(STD_Exam sTD_Exam)
    {
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        return sqlSTD_ExamProvider.InsertSTD_Exam(sTD_Exam);
    }


    public static bool UpdateSTD_Exam(STD_Exam sTD_Exam)
    {
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        return sqlSTD_ExamProvider.UpdateSTD_Exam(sTD_Exam);
    }

    public static bool DeleteSTD_Exam(int sTD_ExamID)
    {
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        return sqlSTD_ExamProvider.DeleteSTD_Exam(sTD_ExamID);
    }

    public static DataSet GetSTD_ExamTeacherByExamID(int examID)
    {
        DataSet sTD_Exams = new DataSet();
        SqlSTD_ExamProvider sqlSTD_ExamProvider = new SqlSTD_ExamProvider();
        sTD_Exams = sqlSTD_ExamProvider.GetSTD_ExamTeacherByExamID(examID);
        return sTD_Exams;
    }
}

