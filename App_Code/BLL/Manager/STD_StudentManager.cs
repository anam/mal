using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_StudentManager
{
    public STD_StudentManager()
    {
    }

    public static DataSet GetAllSTD_Students()
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetAllSTD_Students();
        return sTD_Students;
    }


    public static DataSet GetSTD_StudentClassSummery(string studentCode, DateTime fromDate, DateTime toDate)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_StudentClassSummery(studentCode, fromDate, toDate);
        return sTD_Students;
    }

    public static DataSet GetSTD_StudentByIDs(string IDs)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_StudentByIDs(IDs);
        return sTD_Students;
    }


    public static void sTD_StudentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
    {
        double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("First", "1", currentPage > 1));
            pages.Add(new ListItem("Previous", (currentPage -1).ToString(), currentPage > 1));

            var page_show =6;
            var both_side_page_show = page_show / 2;

           
            var show_bellow_limit = currentPage - both_side_page_show;
            var show_top_side_limit = pageCount - both_side_page_show;

        
            var show_bellow_lower_limit = currentPage - both_side_page_show;

            if (show_bellow_lower_limit <= 0)
                show_bellow_lower_limit = both_side_page_show;



            var show_bellow_top_upper_limit = show_bellow_lower_limit + both_side_page_show;

            var show_top_upper_limit =pageCount - both_side_page_show;
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
    public static void LoadSTD_StudentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        DataSet ds = sqlSTD_StudentProvider.GetSTD_StudentPageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        //COMN_CommonManager common = new COMN_CommonManager();
        COMN_CommonManager.Paggination(rptPager, recordCount, pageIndex, PageSize);
    }
    public static DataSet GetDropDownListAllSTD_Student()
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetDropDownListAllSTD_Student();
        return sTD_Students;
    }

    public static DataSet GetAllSTD_StudentsWithRelation()
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetAllSTD_Students();
        return sTD_Students;
    }


    public static STD_Student GetHR_MaritualStatusByMaritualStatusID(int MaritualStatusID)
    {
        STD_Student sTD_Student = new STD_Student();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Student = sqlSTD_StudentProvider.GetSTD_StudentByMaritualStatusID(MaritualStatusID);
        return sTD_Student;
    }


    public static STD_Student GetHR_ReligionByReligionID(int ReligionID)
    {
        STD_Student sTD_Student = new STD_Student();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Student = sqlSTD_StudentProvider.GetSTD_StudentByReligionID(ReligionID);
        return sTD_Student;
    }


    public static STD_Student GetHR_StudnetByStudentCode(string studentCode)
    {
        STD_Student sTD_Student = new STD_Student();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Student = sqlSTD_StudentProvider.GetSTD_StudentByStudentCode(studentCode);
        return sTD_Student;
    }

    public static STD_Student GetSTD_StudentByStudentCodeRefund(string studentCode)
    {
        STD_Student sTD_Student = new STD_Student();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Student = sqlSTD_StudentProvider.GetSTD_StudentByStudentCodeRefund(studentCode);
        return sTD_Student;
    }

    public static STD_Student GetSTD_StudentByStudentID(string StudentID)
    {
        STD_Student sTD_Student = new STD_Student();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Student = sqlSTD_StudentProvider.GetSTD_StudentByStudentID(StudentID);
        return sTD_Student;
    }


    public static DataSet InsertSTD_Student(STD_Student sTD_Student)
    {
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        return sqlSTD_StudentProvider.InsertSTD_Student(sTD_Student);
    }


    public static bool UpdateSTD_Student(STD_Student sTD_Student)
    {
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        return sqlSTD_StudentProvider.UpdateSTD_Student(sTD_Student);
    }

    public static bool DeleteSTD_Student(string  sTD_StudentID)
    {
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        return sqlSTD_StudentProvider.DeleteSTD_Student(sTD_StudentID);
    }


    public static bool DeleteSTD_StudentAccordingToRowStatusID(string sTD_StudentID, int rowStatusID)
    {
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        return sqlSTD_StudentProvider.DeleteSTD_StudentAccordingToRowStatusID(sTD_StudentID, rowStatusID);
    }


    public static STD_Student GetAllSTD_StudentsByBatchNo(int batchNo)
    {
        STD_Student sTD_Student = new STD_Student();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Student = sqlSTD_StudentProvider.GetAllSTD_StudentsByBatchNo(batchNo);
        return sTD_Student;
    }
    public static List<STD_Student> SearchAllSTD_Students(string studentName, string studentCode, int batchNo, string phone, DateTime startDate, DateTime endDate)
    {
        List<STD_Student> sTD_Student = new List<STD_Student>();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Student = sqlSTD_StudentProvider.SearchAllSTD_Students(studentName, studentCode, batchNo, phone, startDate, endDate);
        return sTD_Student;
    }

    public static STD_Student GetSTD_StudentMoneyReceitByStudentID(string StudentID)
    {
        STD_Student sTD_Student = new STD_Student();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Student = sqlSTD_StudentProvider.GetSTD_StudentMoneyReceitByStudentID(StudentID);
        return sTD_Student;
    }

    public static DataSet GetSTD_StudentsAttentdant(int classID, int subjectID, string employeeID)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_StudentsAttentdant(classID, subjectID, employeeID);
        return sTD_Students;
    }

    public static DataSet GetSTD_StudentsAttentdantAlreadyAttended(int classID, int subjectID, string employeeID,string time)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_StudentsAttentdantAlreadyAttended(classID, subjectID, employeeID,time);
        return sTD_Students;
    }


    public static DataSet DeleteSTD_StudentsAttentdantAlreadyAttended(int classID, int subjectID, string employeeID, string time)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.DeleteSTD_StudentsAttentdantAlreadyAttended(classID, subjectID, employeeID, time);
        return sTD_Students;
    }



    public static DataSet GetSTD_ClassStudentsAttentdant(string employeeID, DateTime date)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_ClassStudentsAttentdant(employeeID, date);
        return sTD_Students;
    }


    public static DataSet GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDForRepeating(string employeeID, DateTime date)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDForRepeating(employeeID, date);
        return sTD_Students;
    }

    public static DataSet GetSTD_ExamStudentsByExamDetailsID(int examDetailsID)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_ExamStudentsByExamDetailsID(examDetailsID);
        return sTD_Students;
    }

    public static DataSet GetSTD_ExamDetailsStudentsByExamDetailsStudentID(int examDetailsStudentID)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_ExamDetailsStudentsByExamDetailsStudentID(examDetailsStudentID);
        return sTD_Students;
    }

    public static DataSet GetSTD_ExamDetailsStudentsByExamDetailsID(int examDetails)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_ExamDetailsStudentsByExamDetailsID(examDetails);
        return sTD_Students;
    }

    public static DataSet GetSTD_StudentsByExamID(int examID)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_StudentsByExamID(examID);
        return sTD_Students;
    }

    public static DataSet GetSTD_StudentsByExamIDnStudentID(int examID,string studentID)
    {
        DataSet sTD_Students = new DataSet();
        SqlSTD_StudentProvider sqlSTD_StudentProvider = new SqlSTD_StudentProvider();
        sTD_Students = sqlSTD_StudentProvider.GetSTD_StudentsByExamIDnStudentID(examID, studentID);
        return sTD_Students;
    }
}

