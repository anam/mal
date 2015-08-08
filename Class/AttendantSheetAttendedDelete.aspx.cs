using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Student_AttendantSheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                int classID = 0, subjectID = 0;
                string employeeID = "";
                if (Request.QueryString["classID"] != null && Request.QueryString["subjectID"] != null && Request.QueryString["employeeID"] != null)
                {
                    classID = Convert.ToInt32(Request.QueryString["classID"]);
                    subjectID = Convert.ToInt32(Request.QueryString["subjectID"]);
                    employeeID = Request.QueryString["employeeID"];

                    DataSet dsStudentAttendenceAlreadyAttended = STD_StudentManager.DeleteSTD_StudentsAttentdantAlreadyAttended(classID, subjectID, employeeID, Request.QueryString["DateRoutineTime"]);


                    //STD_Class sc = STD_ClassManager.GetSTD_BasicInfoForStudentsAttentdant(classID, subjectID, employeeID);
                    //if (sc != null)
                    //{
                    //    lblCourse.Text = sc.CourseName != null ? sc.CourseName : "";
                    //    lblBatchNo.Text = sc.ClassName != null ? sc.ClassName : "";
                    //    lblDate.Text = DateTime.Now.ToString("dd MMM yyyy");
                    //    lblLecturer.Text = sc.EmployeeName != null ? sc.EmployeeName : "";
                    //    lblPaper.Text = sc.SubjectName != null ? sc.SubjectName : "";
                    //}

                    //DataSet dsStudentAttendence = STD_StudentManager.GetSTD_StudentsAttentdant(classID, subjectID, employeeID);
                    
                    //DataSet dsStudentAttendenceAlreadyAttended = STD_StudentManager.GetSTD_StudentsAttentdantAlreadyAttended(classID, subjectID, employeeID, Request.QueryString["DateRoutineTime"]);
                    ////dsStudentAttendence.Tables[0].Rows.Add(
                    //dsStudentAttendence.Tables[0].Columns.Add("IsAttended", typeof(bool));
                    //dsStudentAttendence.Tables[0].Columns.Add("IsAbsent", typeof(bool));
                    
                    //foreach (DataRow dr in dsStudentAttendence.Tables[0].Rows)
                    //{
                    //    bool isAttended = false;
                    //    foreach (DataRow drAttended in dsStudentAttendenceAlreadyAttended.Tables[0].Rows)
                    //    {
                    //        if (drAttended["StudentID"].ToString().ToLower() == dr["StudentID"].ToString().ToLower())
                    //        {
                    //            isAttended = true;
                    //        }
                    //    }

                    //    dr["IsAttended"] = isAttended;
                    //    dr["IsAbsent"] = !isAttended;


                    //    if (dr["PaymentDueAmount"].ToString() == "0.00")
                    //    {
                    //        dr["ExtraField1"] = false; ;
                    //    }
                    //    else
                    //    {
                    //        dr["ExtraField1"] = true;
                    //    }

                    //    dr["ExtraField2"] = !(bool)dr["ExtraField1"];
                    //}

                    //gvAttentdant.DataSource = dsStudentAttendence;
                    //gvAttentdant.DataBind();
                }
            }
            catch (Exception ex)
            { }
        }
    }
}