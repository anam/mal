using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
 

public partial class AdminDisplaySTD_ClassTeacher: System.Web.UI.Page
{
	
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_ClassSubjectData();
            ClassIDLoad();
            TeacherIDLoad();


            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                //btnAdd.Visible = false;
                //btnUpdate.Visible = true;
                ddlClassID.SelectedValue = Request.QueryString["ID"];
                showSTD_ClassSubjectData();
            }
            else
            {
                ddlClassID_SelectedIndexChanged(this, e);
            }
            loadGrid();
        }
    }
    protected void chkClosedClasses_CheckedChanged(object sender, EventArgs e)
    {
        ClassIDLoad();
    }
    #region ClassSubject

    protected void gvSubject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            gvSubject.Visible = true;

            HiddenField hfSubjectID = (HiddenField)e.Row.FindControl("hfSubjectID");
            HiddenField hfClassSubjectID = (HiddenField)e.Row.FindControl("hfClassSubjectID");

            DropDownList ddlTeacherID = (DropDownList)e.Row.FindControl("ddlTeacherID");

            ddlTeacherID.Items.Add(new ListItem("Select Teacher >> ", "0"));
            ddlTeacherID.ValidationGroup = hfSubjectID.Value;

            ddlTeacherID.DataBind();
            
            string teacherID = "0";
            if (hfClassSubjectID.Value != "0")
            {
                DataSet ds = STD_ClassSubjectEmployeeManager.GetSTD_ClassSubjectByClassSubjectID(int.Parse(hfClassSubjectID.Value), true);
                if (ds != null)
                {
                    if (ds.Tables.Count != 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["ClassSubjectID"].ToString() == hfClassSubjectID.Value)
                            {
                                teacherID = dr["EmployeeID"].ToString();
                                if (dr["RowStatusID"].ToString() == "14")
                                {
                                    ddlTeacherID.Enabled = false;
                                }

                                break;
                            }
                        }
                    }
                }
            }

            foreach (ListItem li in ddlTeacher.Items)
            {
                if (li.Value == hfSubjectID.Value)
                {
                    ddlTeacherID.Items.Add(new ListItem(li.Text.Split(';')[1], li.Text.Split(';')[0]));
                    if (li.Text.Split(';')[0].ToLower() == teacherID.ToLower()) 
                    {
                        ddlTeacherID.SelectedIndex = ddlTeacherID.Items.Count-1;
                        ddlTeacherID.ToolTip = teacherID;
                        ddlTeacherID.CssClass = ddlTeacherID.SelectedItem.Text;
                    }
                }
            }

            //gvSubjects.DataSource = STD_ClassManager.GetSTD_ClassByClassID(int.Parse(lblClassID.Text), true);
            //gvSubjects.DataBind();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //delete all the rows for the
            //STD_ClassSubjectEmployeeManager.DeleteSTD_ClassSubjectEmployeeByClassID(int.Parse(ddlClassID.SelectedValue));

            string ids = getSubjectID();
            if (ids != "")
            {
                string[] words = ids.Split(',');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        string[] id = word.Split(' ');
                        
                        STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee();
                        //	sTD_ClassSubjectEmployee.ClassSubjectEmployeeID=  int.Parse(ddlClassSubjectEmployeeID.SelectedValue);
                        sTD_ClassSubjectEmployee.ClassSubjectEmployeeName = "Need to fix later";
                        sTD_ClassSubjectEmployee.EmployeeID =  id[0];
                        sTD_ClassSubjectEmployee.ClassSubjectID = int.Parse(id[1]);
                        sTD_ClassSubjectEmployee.AddedBy = Profile.card_id;
                        sTD_ClassSubjectEmployee.AddedDate = DateTime.Now;
                        sTD_ClassSubjectEmployee.UpdatedBy = Profile.card_id;
                        sTD_ClassSubjectEmployee.UpdateDate = DateTime.Now;
                        int resutl = STD_ClassSubjectEmployeeManager.InsertSTD_ClassSubjectEmployee(sTD_ClassSubjectEmployee);
                    }
                }
            }


        }
        catch (Exception ex) { }

        Response.Redirect("ClassStudentAdd.aspx?ID=" + ddlClassID.SelectedValue); //loadGrid();
    }

    private string getSubjectID()
    {
        string subjectIDs = "";

        foreach (GridViewRow gr in gvSubject.Rows)
        {
            CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");

            HiddenField hfSubjectID = (HiddenField)gr.FindControl("hfSubjectID");
            HiddenField hfClassSubjectID = (HiddenField)gr.FindControl("hfClassSubjectID");
            DropDownList ddlTeacherID = (DropDownList)gr.FindControl("ddlTeacherID");
            if (ddlTeacherID.Items.Count > 0)
            {
                if (chkSelect.Checked && ddlTeacherID.SelectedValue != "0")
                {
                    if (subjectIDs == "") subjectIDs = ddlTeacherID.SelectedValue + " " + hfClassSubjectID.Value;
                    else subjectIDs += "," + ddlTeacherID.SelectedValue + " " + hfClassSubjectID.Value;
                }
            }
        }

        return subjectIDs;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //delete all the rows for the
            STD_ClassSubjectEmployeeManager.DeleteSTD_ClassSubjectEmployeeByClassID(int.Parse(ddlClassID.SelectedValue));

            string ids = getSubjectID();
            if (ids != "")
            {
                string[] words = ids.Split(',');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        string[] id = word.Split(' ');

                        STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee();
                        //	sTD_ClassSubjectEmployee.ClassSubjectEmployeeID=  int.Parse(ddlClassSubjectEmployeeID.SelectedValue);
                        sTD_ClassSubjectEmployee.ClassSubjectEmployeeName = "Need to fix later";
                        sTD_ClassSubjectEmployee.EmployeeID = id[0];
                        sTD_ClassSubjectEmployee.ClassSubjectID = int.Parse(id[1]);
                        sTD_ClassSubjectEmployee.AddedBy = Profile.card_id;
                        sTD_ClassSubjectEmployee.AddedDate = DateTime.Now;
                        sTD_ClassSubjectEmployee.UpdatedBy = Profile.card_id;
                        sTD_ClassSubjectEmployee.UpdateDate = DateTime.Now;
                        int resutl = STD_ClassSubjectEmployeeManager.InsertSTD_ClassSubjectEmployee(sTD_ClassSubjectEmployee);
                    }
                }
            }
        }
        catch (Exception ex) { }
        Response.Redirect("ClassStudentAdd.aspx?ID=" + ddlClassID.SelectedValue); //loadGrid();
        btnUpdate.Visible = false;
    }
    private void showSTD_ClassSubjectData()
    {
        //STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject();
        //sTD_ClassSubject = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassSubjectID(Int32.Parse(Request.QueryString["ID"]));
        //ddlSubjectID.SelectedValue = sTD_ClassSubject.SubjectID.ToString();
        ddlClassID.SelectedValue = Request.QueryString["ID"];
        SubjectIDLoad();
    }

    private void SubjectIDLoad()
    {
        try
        {
            DataSet ds = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassIDTeacherAdd(int.Parse(ddlClassID.SelectedValue),true);
            //ds.Tables[0].Columns.Add("ClassSubjectID", typeof(int));
            ds.Tables[0].Columns.Add("IsChecked", typeof(bool));
            if(ds==null)return;

            if (ds.Tables[0].Rows.Count == 0)
            {
                a_AddSubjectToAddCourse.Visible = true;
                a_AddSubjectToAddCourse.HRef += ddlClassID.SelectedValue;
                gvSubject.Visible = false;
                return;
            }

            List<STD_ClassSubject> sTD_ClassSubject = new List<STD_ClassSubject>();

            sTD_ClassSubject = STD_ClassSubjectManager.GetSTD_ClassByClassID(int.Parse(ddlClassID.SelectedItem.Value));
            
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                dr["IsChecked"] = false;
                dr["ClassSubjectID"] = 0;
                
                foreach(STD_ClassSubject classSubuject in sTD_ClassSubject)
                {
                    if (classSubuject.SubjectID.ToString() == dr["SubjectID"].ToString())
                    {
                        dr["IsChecked"] = true;
                        dr["ClassSubjectID"] = classSubuject.ClassSubjectID;
                        break;
                    }
                }
            }

            gvSubject.DataSource = ds.Tables[0];
            gvSubject.DataBind();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void ClassIDLoad()
    {
        try
        {
            DataSet ds = chkClosedClasses.Checked ? STD_ClassManager.GetDropDownListAllSTD_ClassWithHistory() : STD_ClassManager.GetDropDownListAllSTD_Class();
            ddlClassID.DataValueField = "ClassID";
            ddlClassID.DataTextField = "ClassName";
            ddlClassID.DataSource = ds.Tables[0];
            ddlClassID.DataBind();
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void TeacherIDLoad()
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_EmployeeFromSubjectEmployee();
            ddlTeacher.DataValueField = "SubjectID";
            ddlTeacher.DataTextField = "EmployeeNameNoID";
            ddlTeacher.DataSource = ds.Tables[0];
            ddlTeacher.DataBind();
            ddlTeacher.Items.Insert(0, new ListItem("Select Employee >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void productsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblClassID = (Label)e.Row.FindControl("lblClassID");

            GridView gvSubjects = (GridView)e.Row.FindControl("gvSubjects");
            gvSubjects.DataSource = STD_ClassSubjectManager.GetSTD_ClassSubjectEmployeeByClassID(int.Parse(lblClassID.Text), true);
            gvSubjects.DataBind();
        }
    }

    protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedIndex != 0)
        {
            //gvSubject.Visible = false;
            SubjectIDLoad();
        }
        else
        {
            gvSubject.Visible = false;
        }
    }

    protected void ddlTeacherID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlTeacherID = new DropDownList();
        ddlTeacherID = (DropDownList)sender;

        if (ddlTeacherID.SelectedIndex != 0)
        {
            if (ddlTeacherID.SelectedValue.ToUpper() != ddlTeacherID.ToolTip.ToUpper())
            {
                //string scriptText = "alert('(Old Teacher : " + ddlTeacherID.ToolTip + ") (Subject : " + ddlTeacherID.ValidationGroup +") (New teacher"+ddlTeacherID.SelectedValue+ "');";
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Summary", scriptText, true);
                varifyRoutine(ddlTeacherID.ValidationGroup, ddlTeacherID.ToolTip, ddlTeacherID.SelectedValue);
                if (lblConfilictMessage.Text != "")
                {
                    lblConfilictMessage.Text += " of [" + ddlTeacherID.CssClass.Split('-')[1].Trim() +"] and [" + ddlTeacherID.SelectedItem.Text.Split('-')[1].Trim() + "]";
                    lblConfilictMessage.Text += "<br/>Your can delete the red maked class from the routine then again select [" + ddlTeacherID.SelectedItem.Text.Split('-')[1] + "] from the list and then save";
                    ddlTeacherID.SelectedValue = ddlTeacherID.ToolTip.ToUpper();
                }
            }
            else
            {
                lblConfilictMessage.Text = "";
                lblVerifyRoutine.Text = "";
            }
        }
        else
        {
            lblConfilictMessage.Text = "";
            lblVerifyRoutine.Text = "";
        }
        
    }

    private void varifyRoutine(string subjectID, string oldTeacher, string newTeacher)
    {
        lblConfilictMessage.Text = "";
        lblVerifyRoutine.Text = getRoutineText(int.Parse(subjectID), oldTeacher, newTeacher);
    }


    public String getRoutineText(int subjectID, string oldTeacher, string newTeacher)
    {
        try
        {

            STD_RoutineTime routineTime = new STD_RoutineTime();
            routineTime.RoomID = 0;
            routineTime.ClassID = int.Parse(ddlClassID.SelectedValue);
            routineTime.SubjectID = subjectID;
            routineTime.EmployeeID = oldTeacher;
            string StudentID = "";
            DataSet dsRoutineTimeByClassnSubject = STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);

            routineTime = new STD_RoutineTime();
            routineTime.RoomID = 0;
            routineTime.ClassID = 0;
            routineTime.SubjectID = 0;
            routineTime.EmployeeID = newTeacher;
            StudentID = "";// hfStudentID.Value == "0" ? "" : hfStudentID.Value;
            DataSet dsRoutineTimeByStudent = STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);


            DataSet dsClassTime = STD_ClassTimeManager.GetAllSTD_ClassTimes();
            DataSet dsClassDay = STD_ClassDayManager.GetAllSTD_ClassDaies();
            int width = 120;
            int widthDay = 70;
            string routine = "<table id='tblRoutineDisplay'  style='font-size:10px;width:" + ((dsClassTime.Tables[0].Rows.Count * width) + widthDay).ToString() + "px'>";
            string classTimeGroupID = dsClassTime.Tables[0].Rows[0]["ClassTimeGroupID"].ToString();
            for (int row = 0; row < dsClassTime.Tables[0].Rows.Count; row++)
            {
                if (classTimeGroupID != dsClassTime.Tables[0].Rows[row]["ClassTimeGroupID"].ToString())
                {
                    routine += "<tr><td colspan='" + (dsClassDay.Tables[0].Rows.Count + 1) + "'>&nbsp;</br></br></br></td></tr>";
                    //routine += "<tr><td colspan='" + (dsClassDay.Tables[0].Rows.Count + 1) + "'>&nbsp;</td></tr>";
                    classTimeGroupID = dsClassTime.Tables[0].Rows[row]["ClassTimeGroupID"].ToString();
                }

                if (row == 0)
                {
                    routine += "<tr style='border-top:1px solid Black;'><td></td>";

                    for (int col = 0; col < dsClassDay.Tables[0].Rows.Count; col++)
                    {
                        routine += "<td>";
                        routine += dsClassDay.Tables[0].Rows[col]["ClassDayName"].ToString();
                        routine += "</td>";
                    }

                    routine += "</tr>";
                }

                routine += "<tr>";
                for (int col = 0; col < dsClassDay.Tables[0].Rows.Count; col++)
                {
                    if (col == 0)
                    {
                        routine += "<td style='min-width:" + widthDay + "px'>";
                        routine += dsClassTime.Tables[0].Rows[row]["ClassTimeName"].ToString();
                        routine += "</td>";
                    }

                    routine += "<td style='min-width:" + width + "px;'>";
                    routine += GetClassName(dsRoutineTimeByClassnSubject, dsRoutineTimeByStudent, dsClassTime.Tables[0].Rows[row]["ClassTimeID"].ToString(), dsClassDay.Tables[0].Rows[col]["ClassDayID"].ToString());
                    routine += "</td>";
                }
                routine += "</tr>";
            }
            routine += "</table>";

            routine += STD_RoutineTimeManager.GetTeacherName(dsRoutineTimeByClassnSubject);

            return routine;

        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public string GetClassName(DataSet dsRoutineTimeByClassnSubject, DataSet dsRoutineTimeByStudent, string ClassTimeID, string ClassDayID)
    {
        //btnEnrollment.Visible = true;
        //lblConfilictMessage.Text = "";
        string className = "";
        string byStudentRoutineIDs = "";
        foreach (DataRow drByStudent in dsRoutineTimeByStudent.Tables[0].Rows)
        {
            if (drByStudent["ClassTimeID"].ToString() == ClassTimeID && drByStudent["ClassDayID"].ToString() == ClassDayID)
            {
                if (className != "") className += "</br>";
                byStudentRoutineIDs += " " + drByStudent["RoutineTimeID"].ToString() + " ";
                //className += "(" + drByStudent["SubjectName"].ToString() + ") (" + drByStudent["ClassName"].ToString() + ") (" + drByStudent["EmployeeName"].ToString() + ")  (" + drByStudent["RoomName"].ToString() + ")";
                className += "(" + drByStudent["ClassName"].ToString() + ") (" + drByStudent["SubjectName"].ToString() + ") (" + drByStudent["EmployeeSortName"].ToString() + ")  (" + drByStudent["RoomName"].ToString() + ")";
            }
        }

        foreach (DataRow drByClassnSubject in dsRoutineTimeByClassnSubject.Tables[0].Rows)
        {
            if (drByClassnSubject["ClassTimeID"].ToString() == ClassTimeID && drByClassnSubject["ClassDayID"].ToString() == ClassDayID)
            {
                //if (className != "") className += "</br>";
                //if (byStudentRoutineIDs.Contains(" " + drByClassnSubject["RoutineTimeID"].ToString() + " "))
                if (className != "")
                {
                    className += "</br>";
                    className += "<span style='color:Red;'>(" + drByClassnSubject["ClassName"].ToString() + ") (" + drByClassnSubject["SubjectName"].ToString() + ") (" + drByClassnSubject["EmployeeSortName"].ToString() + ")  (" + drByClassnSubject["RoomName"].ToString() + ")</span>";
                    className += "<a target='_blank'  href='Class_Display_RoutineTime_ByValues.aspx?IsDelete=1&CampusID=" + drByClassnSubject["CampusID"].ToString() + "&RoutineID=" + drByClassnSubject["RoutineID"].ToString() + "&ClassID=" + ddlClassID.SelectedValue + "&SubjectID=" + drByClassnSubject["SubjectID"].ToString() + "&EmployeeID=" + drByClassnSubject["EmployeeID"].ToString() + "&RoutineTimeID=" + drByClassnSubject["RoutineTimeID"].ToString() + "'><img src='../App_Themes/CoffeyGreen/images/icon-delete.png' /></a>";
                    //btnEnrollment.Visible = false;
                    if (lblConfilictMessage.Text == "")
                    {
                        lblConfilictMessage.Text = "Routine Conflict";
                    }
                    
                }
                else
                {
                    className += "<span style='color:Green;'>(" + drByClassnSubject["ClassName"].ToString() + ") (" + drByClassnSubject["SubjectName"].ToString() + ") (" + drByClassnSubject["EmployeeSortName"].ToString() + ")  (" + drByClassnSubject["RoomName"].ToString() + ")</span>";
                }
            }
        }



        return className;
    }

    #endregion

    #region Class
    private void loadGrid()
    {
        STD_ClassManager.LoadSTD_ClassPageByClassTeacher(gvSTD_Class, rptPager, 1, ddlPageSize);
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_ClassManager.LoadSTD_ClassPageByClassTeacher(gvSTD_Class, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_ClassManager.LoadSTD_ClassPageByClassTeacher(gvSTD_Class, rptPager, pageIndex, ddlPageSize);
    }

    protected void lbSelectClass_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("ClassSubjetAdd.aspx?ID=" + id);
    }
    protected void lbDeleteClass_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = STD_ClassManager.DeleteSTD_Class(Convert.ToInt32(linkButton.CommandArgument));
        //STD_ClassManager.LoadSTD_ClassPage(gvSTD_Class, rptPager, 1, ddlPageSize);
    }
    #endregion
}

