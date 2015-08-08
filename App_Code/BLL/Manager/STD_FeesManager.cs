using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_FeesManager
{
	public STD_FeesManager()
	{
	}

    public static DataSet  GetAllSTD_Feess()
    {
       DataSet sTD_Feess = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Feess = sqlSTD_FeesProvider.GetAllSTD_Feess();
        return sTD_Feess;
    }

	public static void sTD_FeessPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_FeesPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
		DataSet ds =  sqlSTD_FeesProvider.GetSTD_FeesPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_FeessPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static void LoadSTD_FeesPageByStudentID(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize,string StudentID)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        DataSet ds = sqlSTD_FeesProvider.GetSTD_FeesPageWiseByStudentID(pageIndex, PageSize, out recordCount,StudentID);
        gv.DataSource = ds;
        gv.DataBind();
        sTD_FeessPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static void LoadSTD_FeesPageByStudentIDisPaid(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize, string StudentID,bool ispaid)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        DataSet ds = sqlSTD_FeesProvider.GetSTD_FeesPageWiseByStudentIDisPaid(pageIndex, PageSize, out recordCount, StudentID, ispaid);
        gv.DataSource = ds;
        gv.DataBind();
        sTD_FeessPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static DataSet  GetDropDownListAllSTD_Fees()
    {
       DataSet sTD_Feess = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Feess = sqlSTD_FeesProvider.GetDropDownLisAllSTD_Fees();
        return sTD_Feess;
    }

    public static DataSet   GetAllSTD_FeessWithRelation()
    {
       DataSet sTD_Feess = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Feess = sqlSTD_FeesProvider.GetAllSTD_Feess();
        return sTD_Feess;
    }


    public static STD_Fees GetSTD_FeesTypeByFeesTypeID(int FeesTypeID)
    {
        STD_Fees sTD_Fees = new STD_Fees();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesByFeesTypeID(FeesTypeID);
        return sTD_Fees;
    }


    public static STD_Fees GetSTD_FeesStudentByStudentID(string StudentID)
    {
        STD_Fees sTD_Fees = new STD_Fees();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesByStudentID(StudentID);
        return sTD_Fees;
    }

    public static DataSet GetSTD_FeesStudentByStudentID(string StudentID,bool isDataset)
    {
        DataSet sTD_Fees = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesByStudentID(StudentID,isDataset);
        return sTD_Fees;
    }



    public static DataSet GetSTD_StudentByStudentID(string StudentID, int courseID)
    {
        DataSet sTD_Fees = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesByStudentID(StudentID,courseID);
        return sTD_Fees;
    }


    public static DataSet GetSTD_FeesListByStudentID(string StudentID)
    {
        DataSet sTD_Fees = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesListByStudentID(StudentID);
        return sTD_Fees;
    }

    public static DataSet GetSTD_FeesListByFeesMasterID(string feesMasterID)
    {
        DataSet sTD_Fees = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesListByFeesMasterID(feesMasterID);
        return sTD_Fees;
    }

    public static DataSet GetSTD_FeesListByStudentCode(string studentCode)
    {
        DataSet sTD_Fees = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesListByStudentCode(studentCode);
        return sTD_Fees;
    }

    public static DataSet GetAllSTD_FeesList()
    {
        DataSet sTD_Fees = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetAllSTD_FeesList();
        return sTD_Fees;
    }

    public static void GetAllSTD_FeesList_NotPaid(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_FeesProvider sqlSTD_ProgramProvider = new SqlSTD_FeesProvider();
        DataSet ds = sqlSTD_ProgramProvider.GetAllSTD_FeesList_NotPaid(pageIndex, PageSize, out recordCount);
        gv.DataSource = processDataSet(ds);
        gv.DataBind();

        COMN_CommonManager.Paggination(rptPager, recordCount, pageIndex, PageSize);
    }


    public static void sTD_FeesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
    {
        double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("First", "1", currentPage > 1));
            pages.Add(new ListItem("Previous", (currentPage - 1).ToString(), currentPage > 1));

            var page_show = 6;
            var both_side_page_show = page_show / 2;


            var show_bellow_limit = currentPage - both_side_page_show;
            var show_top_side_limit = pageCount - both_side_page_show;


            var show_bellow_lower_limit = currentPage - both_side_page_show;

            if (show_bellow_lower_limit <= 0)
                show_bellow_lower_limit = both_side_page_show;



            var show_bellow_top_upper_limit = show_bellow_lower_limit + both_side_page_show;

            var show_top_upper_limit = pageCount - both_side_page_show;
            var show_top_lower_limit = show_top_upper_limit - both_side_page_show;


            var do_no = 0;
            for (int i = 1; i <= pageCount; i++)
            {



                if (
                    ((i >= show_bellow_lower_limit) && (i <= show_bellow_top_upper_limit))
                    ||
                    ((i <= show_top_upper_limit) && (i >= show_top_lower_limit))
                    )
                {

                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                    if ((do_no == 0) && (i >= show_bellow_top_upper_limit))
                    {
                        pages.Add(new ListItem("...", i.ToString(), i != currentPage));
                        do_no++;
                    }

                }
            }
            pages.Add(new ListItem("Next", (currentPage + 1).ToString(), currentPage < pageCount));
            pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    public static DataSet processDataSet(DataSet ds)
    {
        if (ds.Tables[0].Rows.Count == 0) return ds;

        string lastStudentID = "";
        string lastFeesMasterID = "";

        decimal due = 0;
        decimal unpaid = 0;

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (lastFeesMasterID != dr["FeesMasterID"].ToString())
            {
                lastFeesMasterID = dr["FeesMasterID"].ToString();

                if (DateTime.Parse((dr["FeesSubmissionDate"].ToString())) > DateTime.Today)
                    unpaid = decimal.Parse(dr["FeesUnpaidAmount"].ToString());
                else
                    due = decimal.Parse(dr["FeesUnpaidAmount"].ToString());


                if (lastStudentID == dr["StudentID"].ToString())
                {
                    dr["StudentName"] = "";
                    dr["StudentCode"] = "";
                    dr["Mobile"] = "";
                    dr["PPSizePhoto"] = "~/App_Themes/CoffeyGreen/images/onePix.gif";
                }
                else
                {
                    lastStudentID = dr["StudentID"].ToString();
                }
            }
            else
            {

                if (DateTime.Parse((dr["FeesSubmissionDate"].ToString())) > DateTime.Today)
                    unpaid += decimal.Parse(dr["FeesUnpaidAmount"].ToString());
                else
                    due += decimal.Parse(dr["FeesUnpaidAmount"].ToString());

                dr["IsDeleted"] = 1;
            }

            dr["FeesMasterDueAmount"] = due;
            dr["FeesMasterUnpaidAmount"] = unpaid;
        }


        //delete the deleted rows
        int last0 = 0;
        for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["IsDeleted"].ToString() == "1")
            {
                if (i + 1 < ds.Tables[0].Rows.Count)
                {
                    if (ds.Tables[0].Rows[i]["FeesMasterID"].ToString() != ds.Tables[0].Rows[i + 1]["FeesMasterID"].ToString())
                    {
                        ds.Tables[0].Rows[last0]["FeesMasterDueAmount"] = decimal.Parse(ds.Tables[0].Rows[i]["FeesMasterDueAmount"].ToString());
                        ds.Tables[0].Rows[last0]["FeesMasterUnpaidAmount"] = decimal.Parse(ds.Tables[0].Rows[i]["FeesMasterUnpaidAmount"].ToString());
                    }
                }
                else
                {
                    ds.Tables[0].Rows[last0]["FeesMasterDueAmount"] = decimal.Parse(ds.Tables[0].Rows[i]["FeesMasterDueAmount"].ToString());
                    ds.Tables[0].Rows[last0]["FeesMasterUnpaidAmount"] = decimal.Parse(ds.Tables[0].Rows[i]["FeesMasterUnpaidAmount"].ToString());
                }
                ds.Tables[0].Rows[i].Delete();
            }
            else
            {
                last0 = i;
            }
        }
        return ds;
    }

    //public static void sTD_FeesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
    //{
    //    double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
    //    int pageCount = (int)Math.Ceiling(dblPageCount);
    //    List<ListItem> pages = new List<ListItem>();
    //    if (pageCount > 0)
    //    {
    //        pages.Add(new ListItem("First", "1", currentPage > 1));
    //        for (int i = 1; i <= pageCount; i++)
    //        {
    //            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
    //        }
    //        pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
    //    }
    //    rptPager.DataSource = pages;
    //    rptPager.DataBind();
    //}

    //public static DataSet GetAllSTD_FeesList_NotPaid()
    //{
    //    DataSet sTD_Fees = new DataSet();
    //    SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
    //    sTD_Fees = sqlSTD_FeesProvider.GetAllSTD_FeesList_NotPaid();
    //    return sTD_Fees;
    //}

    public static STD_Fees GetSTD_CourseByCourseID(int CourseID)
    {
        STD_Fees sTD_Fees = new STD_Fees();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesByCourseID(CourseID);
        return sTD_Fees;
    }


    public static STD_Fees GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_Fees sTD_Fees = new STD_Fees();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesByRowStatusID(RowStatusID);
        return sTD_Fees;
    }


    public static STD_Fees GetSTD_FeesByFeesID(int FeesID)
    {
        STD_Fees sTD_Fees = new STD_Fees();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Fees = sqlSTD_FeesProvider.GetSTD_FeesByFeesID(FeesID);
        return sTD_Fees;
    }

    public static int GetStdCalculateSemesterFee()
    {
        int rowExecuted = 0;
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        rowExecuted = sqlSTD_FeesProvider.GetStdCalculateSemesterFee();
        return rowExecuted;
    }

    public static int InsertSTD_Fees(STD_Fees sTD_Fees)
    {
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        return sqlSTD_FeesProvider.InsertSTD_Fees(sTD_Fees);
    }


    public static bool UpdateSTD_Fees(STD_Fees sTD_Fees)
    {
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        return sqlSTD_FeesProvider.UpdateSTD_Fees(sTD_Fees);
    }

    public static bool DeleteSTD_Fees(int sTD_FeesID)
    {
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        return sqlSTD_FeesProvider.DeleteSTD_Fees(sTD_FeesID);
    }

    public static bool DeleteSTD_FeesByFeesMasterID(int sTD_FeesID)
    {
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        return sqlSTD_FeesProvider.DeleteSTD_FeesFeesMasterID(sTD_FeesID);
    }

    public static DataSet GetSTD_SemesterFeeByStudentID(string studentID)
    {
        DataSet sTD_Feess = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Feess = sqlSTD_FeesProvider.GetSTD_SemesterFeeByStudentID(studentID);
        return sTD_Feess;
    }

    public static DataSet GetSTD_FeesInstallmentByFeesMasterID(string feesmasterID)
    {
        DataSet sTD_Feess = new DataSet();
        SqlSTD_FeesProvider sqlSTD_FeesProvider = new SqlSTD_FeesProvider();
        sTD_Feess = sqlSTD_FeesProvider.GetSTD_FeesInstallmentByFeesMasterID(feesmasterID);
        return sTD_Feess;
    }
}

