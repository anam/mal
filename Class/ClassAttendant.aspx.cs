using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Class_ClassAttendant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                int classID = 0, subjectID = 0;
                string employeeID = "";

                if (Request.QueryString["classID"] != null && Request.QueryString["subjectID"] != null && Request.QueryString["employeeID"] != null && Request.QueryString["Date"] != null)
                {
                    DateTime date = DateTime.Parse(Request.QueryString["Date"]);

                    classID = Convert.ToInt32(Request.QueryString["classID"]);
                    subjectID = Convert.ToInt32(Request.QueryString["subjectID"]);
                    employeeID = Request.QueryString["employeeID"];

                    STD_Class sc = STD_ClassManager.GetSTD_BasicInfoForStudentsAttentdant(classID, subjectID, employeeID);
                    if (sc != null)
                    {
                        lblCourse.Text = sc.CourseName != null ? sc.CourseName : "";
                        lblBatchNo.Text = sc.ClassName != null ? sc.ClassName : "";
                        lblDate.Text = date.ToString("dd MMM yyyy, HH:mm");
                        lblLecturer.Text = sc.EmployeeName != null ? sc.EmployeeName : "";
                        lblPaper.Text = sc.SubjectName != null ? sc.SubjectName : "";
                    }



                    DataSet dsStudentAttendence = STD_StudentManager.GetSTD_ClassStudentsAttentdant(employeeID, date);

                    foreach (DataRow dr in dsStudentAttendence.Tables[0].Rows)
                    {
                        if (dr["PaymentDueAmount"].ToString() == "0.00")
                        {
                            dr["ExtraField1"] = false; ;
                        }
                        else
                        {
                            dr["ExtraField1"] = true;
                        }

                        dr["ExtraField2"] = !(bool)dr["ExtraField1"];
                    }

                    gvAttentdant.DataSource = dsStudentAttendence;
                    gvAttentdant.DataBind();

                }


            }
        }

        catch (Exception ex)
        {
        }
    }
}