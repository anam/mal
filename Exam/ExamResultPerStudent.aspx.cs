using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Exam_ExamResultPerStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Profile.IsStudent)
            {
                tblSudentCode.Visible = false;
                btnOk_OnClick(this, new EventArgs());
            }
            else
            {
                tblSudentCode.Visible = true;
            }
        }
    }
    protected void btnOk_OnClick(object sender, EventArgs e)
    {
        STD_Student student = new STD_Student();

        if (Profile.IsStudent)
        {
            student.StudentID = Profile.card_id;
        }
        else
        {
            student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text);
        }
        List<STD_ExamDetailsStudent> results = new List<STD_ExamDetailsStudent>();

        DataSet tblResults = STD_ExamDetailsStudentManager.GetSTD_ExamResultByStudentID(student.StudentID);

        foreach (DataTable tblResult in tblResults.Tables)
        {
            foreach (DataRow dr in tblResult.Rows)
            {
                STD_ExamDetailsStudent result = new STD_ExamDetailsStudent();

                result.TotalMark = dr["TotalMarks"].ToString();
                result.ObtainedMark = decimal.Parse(dr["ObtainedMark"].ToString());

                result.ExamName = dr["ExamName"].ToString();
                result.ExamID = int.Parse(dr["ExamID"].ToString());
                result.StudentID = student.StudentID;
                results.Add(result);
            }
        }

        gvSTD_ExamDetails.DataSource = results;
        gvSTD_ExamDetails.DataBind();
    }
}