using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_FeesMasterManager
{
	public STD_FeesMasterManager()
	{
	}

    public static DataSet  GetAllSTD_FeesMasters()
    {
       DataSet sTD_FeesMasters = new DataSet();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMasters = sqlSTD_FeesMasterProvider.GetAllSTD_FeesMasters();
        return sTD_FeesMasters;
    }

    public static DataSet GetAllSTD_FeesMastersByFeesTypeID()
    {
        DataSet sTD_FeesMasters = new DataSet();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMasters = sqlSTD_FeesMasterProvider.GetAllSTD_FeesMastersByFeesTypeID();
        return sTD_FeesMasters;
    }

	public static void sTD_FeesMastersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_FeesMasterPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
		DataSet ds =  sqlSTD_FeesMasterProvider.GetSTD_FeesMasterPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_FeesMastersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_FeesMaster()
    {
       DataSet sTD_FeesMasters = new DataSet();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMasters = sqlSTD_FeesMasterProvider.GetDropDownLisAllSTD_FeesMaster();
        return sTD_FeesMasters;
    }

    public static DataSet   GetAllSTD_FeesMastersWithRelation()
    {
       DataSet sTD_FeesMasters = new DataSet();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMasters = sqlSTD_FeesMasterProvider.GetAllSTD_FeesMasters();
        return sTD_FeesMasters;
    }


    public static STD_FeesMaster GetSTD_FeesTypeByFeesTypeID(int FeesTypeID)
    {
        STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMaster = sqlSTD_FeesMasterProvider.GetSTD_FeesMasterByFeesTypeID(FeesTypeID);
        return sTD_FeesMaster;
    }


    public static STD_FeesMaster GetSTD_StudentByStudentID(string StudentID)
    {
        STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMaster = sqlSTD_FeesMasterProvider.GetSTD_FeesMasterByStudentID(StudentID);
        return sTD_FeesMaster;
    }

    public static DataSet GetSTD_FeesMasterByStudentID(string StudentID)
    {
        DataSet sTD_FeesMaster = new DataSet();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMaster = sqlSTD_FeesMasterProvider.GetSTD_FeesMasterByStudentID(StudentID,true);
        return sTD_FeesMaster;
    }

    public static DataSet GetSTD_FeesMasterByStudentIDnCourseIDnFeesTypeID(string StudentID,int courseID,int feesTypeID)
    {
        DataSet sTD_FeesMaster = new DataSet();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMaster = sqlSTD_FeesMasterProvider.GetSTD_FeesMasterByStudentIDnCourseIDnFeesTypeID(StudentID, courseID,feesTypeID);
        return sTD_FeesMaster;
    }


    public static STD_FeesMaster GetSTD_CourseByCourseID(int CourseID)
    {
        STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMaster = sqlSTD_FeesMasterProvider.GetSTD_FeesMasterByCourseID(CourseID);
        return sTD_FeesMaster;
    }


    public static STD_FeesMaster GetSTD_PaymentStatusByPaymentStatusID(int PaymentStatusID)
    {
        STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMaster = sqlSTD_FeesMasterProvider.GetSTD_FeesMasterByPaymentStatusID(PaymentStatusID);
        return sTD_FeesMaster;
    }


    public static STD_FeesMaster GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMaster = sqlSTD_FeesMasterProvider.GetSTD_FeesMasterByRowStatusID(RowStatusID);
        return sTD_FeesMaster;
    }


    public static STD_FeesMaster GetSTD_FeesMasterByFeesMasterID(int FeesMasterID)
    {
        STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMaster = sqlSTD_FeesMasterProvider.GetSTD_FeesMasterByFeesMasterID(FeesMasterID);
        return sTD_FeesMaster;
    }


    public static int InsertSTD_FeesMaster(STD_FeesMaster sTD_FeesMaster)
    {
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        return sqlSTD_FeesMasterProvider.InsertSTD_FeesMaster(sTD_FeesMaster);
    }


    public static bool UpdateSTD_FeesMaster(STD_FeesMaster sTD_FeesMaster)
    {
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        return sqlSTD_FeesMasterProvider.UpdateSTD_FeesMaster(sTD_FeesMaster);
    }

    public static bool UpdateSTD_FeesMasterFeesAdjustment(STD_FeesMaster sTD_FeesMaster)
    {
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        return sqlSTD_FeesMasterProvider.UpdateSTD_FeesMasterFeesAdjustment(sTD_FeesMaster);
    }

    public static bool UpdateSTD_FeesMasterForJournalDelete(STD_FeesMaster sTD_FeesMaster)
    {
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        return sqlSTD_FeesMasterProvider.UpdateSTD_FeesMasterForJournalDelete(sTD_FeesMaster);
    }

    public static bool DeleteSTD_FeesMaster(int sTD_FeesMasterID)
    {
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        return sqlSTD_FeesMasterProvider.DeleteSTD_FeesMaster(sTD_FeesMasterID);

    }

    public static bool RefundSTD_FeesMaster(string studentID)
    {
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        return sqlSTD_FeesMasterProvider.RefundSTD_FeesMaster(studentID);

    }


    public static DataSet GetSTD_SemesterFeeByStudentID(string studentID)
    {
        DataSet sTD_Feess = new DataSet();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_Feess = sqlSTD_FeesMasterProvider.GetSTD_SemesterFeeByStudentID(studentID);
        return sTD_Feess;

    }

    public static DataSet GetSTD_FeesAmountByFeesMasterID(string feesMasterID)
    {
        DataSet sTD_FeesMasters = new DataSet();
        SqlSTD_FeesMasterProvider sqlSTD_FeesMasterProvider = new SqlSTD_FeesMasterProvider();
        sTD_FeesMasters = sqlSTD_FeesMasterProvider.GetSTD_FeesAmountByFeesMasterID(feesMasterID);
        return sTD_FeesMasters;

    }

    
}

