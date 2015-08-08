using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ExamInfoManager
{
	public STD_ExamInfoManager()
	{
	}

    public static DataSet  GetAllSTD_ExamInfos()
    {
       DataSet sTD_ExamInfos = new DataSet();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfos = sqlSTD_ExamInfoProvider.GetAllSTD_ExamInfos();
        return sTD_ExamInfos;
    }

	public static void sTD_ExamInfosPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ExamInfoPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
		DataSet ds =  sqlSTD_ExamInfoProvider.GetSTD_ExamInfoPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ExamInfosPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ExamInfo()
    {
       DataSet sTD_ExamInfos = new DataSet();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfos = sqlSTD_ExamInfoProvider.GetDropDownLisAllSTD_ExamInfo();
        return sTD_ExamInfos;
    }

    public static DataSet   GetAllSTD_ExamInfosWithRelation()
    {
       DataSet sTD_ExamInfos = new DataSet();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfos = sqlSTD_ExamInfoProvider.GetAllSTD_ExamInfos();
        return sTD_ExamInfos;
    }


    public static STD_ExamInfo GetSTD_CampusByCampusID(int CampusID)
    {
        STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfo = sqlSTD_ExamInfoProvider.GetSTD_ExamInfoByCampusID(CampusID);
        return sTD_ExamInfo;
    }


    public static STD_ExamInfo GetSTD_BatchByBatchID(int BatchID)
    {
        STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfo = sqlSTD_ExamInfoProvider.GetSTD_ExamInfoByBatchID(BatchID);
        return sTD_ExamInfo;
    }


    public static STD_ExamInfo GetSTD_SemesterBySemesterID(int SemesterID)
    {
        STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfo = sqlSTD_ExamInfoProvider.GetSTD_ExamInfoBySemesterID(SemesterID);
        return sTD_ExamInfo;
    }


    public static STD_ExamInfo GetSTD_SubjectTeacherBySubjectTeacherID(string SubjectTeacherID)
    {
        STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfo = sqlSTD_ExamInfoProvider.GetSTD_ExamInfoBySubjectTeacherID(SubjectTeacherID);
        return sTD_ExamInfo;
    }


    public static STD_ExamInfo GetSTD_ExamTypeByExamTypeID(int ExamTypeID)
    {
        STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfo = sqlSTD_ExamInfoProvider.GetSTD_ExamInfoByExamTypeID(ExamTypeID);
        return sTD_ExamInfo;
    }


    public static STD_ExamInfo GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfo = sqlSTD_ExamInfoProvider.GetSTD_ExamInfoByRowStatusID(RowStatusID);
        return sTD_ExamInfo;
    }


    public static STD_ExamInfo GetSTD_ExamInfoByExamInfoID(int ExamInfoID)
    {
        STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo();
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        sTD_ExamInfo = sqlSTD_ExamInfoProvider.GetSTD_ExamInfoByExamInfoID(ExamInfoID);
        return sTD_ExamInfo;
    }


    public static int InsertSTD_ExamInfo(STD_ExamInfo sTD_ExamInfo)
    {
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        return sqlSTD_ExamInfoProvider.InsertSTD_ExamInfo(sTD_ExamInfo);
    }


    public static bool UpdateSTD_ExamInfo(STD_ExamInfo sTD_ExamInfo)
    {
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        return sqlSTD_ExamInfoProvider.UpdateSTD_ExamInfo(sTD_ExamInfo);
    }

    public static bool DeleteSTD_ExamInfo(int sTD_ExamInfoID)
    {
        SqlSTD_ExamInfoProvider sqlSTD_ExamInfoProvider = new SqlSTD_ExamInfoProvider();
        return sqlSTD_ExamInfoProvider.DeleteSTD_ExamInfo(sTD_ExamInfoID);
    }
}

