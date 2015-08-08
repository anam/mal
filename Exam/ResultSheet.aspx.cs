using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Exam_ResultSheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["examID"] != null)
            {
                DataSet ds = STD_ExamManager.GetSTD_ExamTeacherByExamID(Convert.ToInt32(Request.QueryString["examID"].ToString()));

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lblClass.Text = row["ClassName"].ToString();
                    lblCourse.Text = row["CourseName"].ToString();
                    lblMonth.Text = DateTime.Now.ToString("MMM-yy");
                    lblTeacher.Text = row["EmployeeName"].ToString();
                    lblExamName.Text = row["ExamName"].ToString();
                    ltExamSheet.Text = getExamSheet();
                }
            }
        }
    }

    private string getExamSheet()
    {
        try
        {
            DataSet dsStudentUnderThatClassSubject = STD_StudentManager.GetSTD_StudentsByExamIDnStudentID(Convert.ToInt32(Request.QueryString["examID"].ToString()), Request.QueryString["StudentID"] == null ? "" : Request.QueryString["StudentID"]);
            DataSet dsAllStudentObtainMark = STD_ExamDetailsStudentManager.GetSTD_StudentsObtainMarkByExamID(Convert.ToInt32(Request.QueryString["examID"].ToString()));
            decimal sumOfMark = 0;
            string html = "<table border='1' cellspacing='0' style='width:98%; float:left; margin:10px'>";
            html += "<tr style='border:none'>";
            html += "<td></td><td colspan='2'>Test Total Marks >>>>>>>>>>>>>></td>";
            decimal TotalMark = 0;
            int percent = 0;
            
                foreach (DataTable tblCol in dsAllStudentObtainMark.Tables)
                {
                    if (tblCol.Rows.Count > 0)
                    {
                        html += "<td>";
                        string TotalDetailsMarks = "";

                        foreach (DataRow drCol in tblCol.Rows)
                        {
                            TotalDetailsMarks = drCol["TotalMarks"].ToString();
                            //TotalMark =decimal.Parse(drCol["totalMark"].ToString());
                            break;
                        }
                        html += TotalDetailsMarks.ToString() + "</td>";

                        TotalMark = TotalMark + Convert.ToDecimal(TotalDetailsMarks);
                    }

                }

                html += "<td></td><td></td><td></td>" + "<td>" + TotalMark.ToString() + "</td>" + "<td></td>";


                html += "</tr>";


                html += "<tr bgcolor='#cccccc'>";
                html += "<td>SL.N</td><td>St.Name</td><td>St.Code</td>";

                foreach (DataTable tblCol in dsAllStudentObtainMark.Tables)
                {
                    if (tblCol.Rows.Count > 0)
                    {
                        html += "<td>";
                        string examDetailsName = "";
                        foreach (DataRow drCol in tblCol.Rows)
                        {
                            examDetailsName = drCol["ExamDetailsName"].ToString();
                            break;
                        }
                        html += examDetailsName.ToString() + "</td>";
                    }

                }
                html += "<td>T M G</td><td>Total %</td><td>N C A</td><td>Class %</td><td>Status</td>";

                html += "</tr>";

                int i = 1;
                foreach (DataRow drRow in dsStudentUnderThatClassSubject.Tables[0].Rows)
                {

                    html += "<tr style='border:solid 1px #ccc'>" + "<td>" + i.ToString() + "</td>" + "<td>" + drRow["StudentName"].ToString() + "</td>";

                    html += "<td>" + drRow["StudentCode"].ToString() + "</td>";

                    foreach (DataTable tblCol in dsAllStudentObtainMark.Tables)
                    {
                        if (tblCol.Rows.Count > 0)
                        {
                            html += "<td>";
                            decimal obtainedMark = 0;
                            foreach (DataRow drCol in tblCol.Rows)
                            {
                                if (drRow["StudentID"].ToString() == drCol["StudentID"].ToString())
                                {
                                    percent = Convert.ToInt32(drCol["percentange"].ToString());
                                    string mark = drCol["ObtainedMark"].ToString();
                                    obtainedMark = Convert.ToDecimal(mark);
                                    break;
                                }
                            }
                            html += obtainedMark.ToString() + "</td>";


                            sumOfMark += obtainedMark;
                        }


                    }



                    decimal percentTotal = 0;
                    if (sumOfMark != 0 && TotalMark != 0)
                    {
                        percentTotal = (sumOfMark / TotalMark) * 100;
                    }
                    html += "<td>" + sumOfMark.ToString() + "</td>";
                    html += "<td>" + percentTotal.ToString("00.00") + "</td><td></td><td></td>";

                    if (percentTotal >= percent)
                    {
                        html += "<td>" + "Pass" + "</td>";
                    }
                    else
                    {
                        html += "<td>" + "Fail" + "</td>";
                    }
                    html += "</tr>";
                    sumOfMark = 0;
                    i++;
                }

                html += "<tr style='border:none'>";
                html += "<td colspan='3'  style='text-align:center; text-decoration:underline'>Admin signature</td>";

                foreach (DataTable tblCol in dsAllStudentObtainMark.Tables)
                {
                    html += "<td></td>";
                }

                html += "<td colspan='4' style='text-align:center; text-decoration:underline'>Lecturer signature</td><td></td>";


                html += "</tr>";
                html += "<tr style='border:none'>";
                html += "<td colspan='3'  style='text-align:center; text-decoration:underline'>&nbsp;</td>";

                foreach (DataTable tblCol in dsAllStudentObtainMark.Tables)
                {
                    html += "<td></td>";
                }

                html += "<td colspan='4' style='text-align:center; text-decoration:underline'>&nbsp;</td><td></td>";


                html += "</tr>";
                html += "<tr style='border:none'>";
                html += "<td colspan='3'  style='text-align:center; text-decoration:underline'>&nbsp;</td>";

                foreach (DataTable tblCol in dsAllStudentObtainMark.Tables)
                {
                    html += "<td></td>";
                }

                html += "<td colspan='4' style='text-align:center; text-decoration:underline'>&nbsp;</td><td></td>";


                html += "</tr>";

                html += "</table>";
                return html;
            }
                

            catch (Exception ex)
            {
                return "";
            }
    }
}