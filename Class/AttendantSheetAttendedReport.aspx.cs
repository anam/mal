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

                    STD_Class sc = STD_ClassManager.GetSTD_BasicInfoForStudentsAttentdant(classID, subjectID, employeeID);
                    if (sc != null)
                    {
                        lblCourse.Text = sc.CourseName != null ? sc.CourseName : "";
                        lblBatchNo.Text = sc.ClassName != null ? sc.ClassName : "";
                        lblDate.Text = DateTime.Now.ToString("dd MMM yyyy");
                        lblLecturer.Text = sc.EmployeeName != null ? sc.EmployeeName : "";
                        lblPaper.Text = sc.SubjectName != null ? sc.SubjectName : "";
                    }

                    DataSet dsStudentAttendence = STD_StudentManager.GetSTD_StudentsAttentdant(classID, subjectID, employeeID);
                    //dsStudentAttendence.Tables[0].Rows.Add(
                    dsStudentAttendence.Tables[0].Columns.Add("IsAttended", typeof(bool));
                    dsStudentAttendence.Tables[0].Columns.Add("IsAbsent", typeof(bool));

                    List<STD_ClassSubjectEmployeeStudent> classSubjectEmployeeStudent = new List<STD_ClassSubjectEmployeeStudent>();
                    classSubjectEmployeeStudent = STD_ClassSubjectEmployeeStudentManager.GetSTD_StudentsAttentdantAlreadyAttendedAllTime(classID, subjectID, employeeID);

                    string uniqueDates = ";";

                    foreach (STD_ClassSubjectEmployeeStudent item in classSubjectEmployeeStudent)
                    {
                        string time = item.ExtraField1;
                        item.StartTime = DateTime.Parse((DateTime.Parse(time.Split('(')[0].Trim()).ToString().Split(' ')[0] + time.Split('(')[1].Split('-')[1]));
                        item.EndTime = DateTime.Parse((DateTime.Parse(time.Split('(')[0].Trim()).ToString().Split(' ')[0] + time.Split('(')[1].Split('-')[2]));

                    }

                    classSubjectEmployeeStudent.Sort(delegate(STD_ClassSubjectEmployeeStudent p1, STD_ClassSubjectEmployeeStudent p2) { return p1.StartTime.CompareTo(p2.StartTime); });

                    foreach (STD_ClassSubjectEmployeeStudent item in classSubjectEmployeeStudent)
                    {
                        if (!uniqueDates.Contains(";" + item.ExtraField1.Trim() + ";"))
                        {
                            uniqueDates += item.ExtraField1.Trim() + ";";
                        }
                    }

                    string table = "<table border='1'><tr><td>Name</td><td>ID</td>";
                    foreach (string item in uniqueDates.Split(';'))
                    {
                        if (item.Contains(':'))
                        {
                            table += "<td  style='width:50px;'>" + item + "</td>";
                        }
                    }

                    table += "</tr>";

                    foreach (DataRow dr in dsStudentAttendence.Tables[0].Rows)
                    {
                        //if (dr["PaymentDueAmount"].ToString() == "0.00")
                        //{
                        //    dr["ExtraField1"] = false; ;
                        //}
                        //else
                        //{
                        //    dr["ExtraField1"] = true;
                        //}

                        //dr["ExtraField2"] = !(bool)dr["ExtraField1"];

                        table += "<tr><td style='width:160px;text-align:left;'>" + dr["StudentName"].ToString() + "</td><td>" + dr["StudentCode"].ToString() + "</td>";

                        

                        foreach (string date in uniqueDates.Split(';'))
                        {
                            if (date.Contains(':'))
                            {
                                bool isAttended = false;
                                foreach (STD_ClassSubjectEmployeeStudent item in classSubjectEmployeeStudent)
                                {
                                    if (date == item.ExtraField1 && dr["StudentID"].ToString().ToLower() == item.StudentID.ToLower())
                                    {
                                        table += "<td style='background-color:green;width:50px;text-align:center;'>P</td>";
                                        isAttended = true;
                                    }
                                }

                                if (!isAttended)
                                {
                                    table += "<td style='background-color:red;width:50px;text-align:center;'>A</td>";
                                }
                            }
                        }

                        table += "</tr>";
                    }
                    table += "</table>";
                    //gvAttentdant.DataSource = dsStudentAttendence;
                    //gvAttentdant.DataBind();
                    lblStudentAttendence.Text = table;


                }
            }
            catch (Exception ex)
            { }
        }
    }
}