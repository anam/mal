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
            ClassIDLoad();
            Session["msg"] = null;
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                //btnAdd.Visible = false;
                //btnUpdate.Visible = true;
                ddlClassID.SelectedValue = Request.QueryString["ID"];
                ddlClassID_SelectedIndexChanged(this, e);
                showSTD_ClassSubjectData();
            }
            else
            {
                ddlClassID_SelectedIndexChanged(this, e);
            }
        }
    }
    #region ClassSubject

   
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        process();
        
        //try
        //{
        //    //delete all the rows for the
        //    //STD_ClassSubjectStudentManager.DeleteSTD_ClassSubjectStudentByClassID(int.Parse(ddlClassID.SelectedValue));

        //    DataSet dsClassSubjectStudentByClass = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByClassID(int.Parse(ddlClassID.SelectedValue));
        //    Session["ClassSubjectStudentByClass"] = dsClassSubjectStudentByClass;

        //    foreach (DataRow dr in dsClassSubjectStudentByClass.Tables[0].Rows)
        //    {
        //        STD_ClassSubjectStudent subject = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByClassSubjectStudentID(int.Parse(dr["ClassSubjectStudentID"].ToString()));
        //        subject.RowStatusID = 3;
        //        STD_ClassSubjectStudentManager.UpdateSTD_ClassSubjectStudent(subject);
        //    }

        //    string ids = getSubjectID();
        //    if (ids != "")
        //    {
        //        string[] words = ids.Split(',');
        //        foreach (string word in words)
        //        {
        //            if (word != "")
        //            {
        //                string[] id = word.Split(' ');

        //                STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
        //                //	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
        //                sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
        //                sTD_ClassSubjectStudent.StudentID = id[0];
        //                sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(id[1]);
        //                sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
        //                sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
        //                sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
        //                sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
        //                sTD_ClassSubjectStudent.RowStatusID = 1;
        //                int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);

        //            }
        //        }
        //    }


        //}
        //catch (Exception ex) { }
        ddlClassID_SelectedIndexChanged(this, e);
    }

    private string getSubjectID()
    {
        string subjectIDs = "";

        foreach (GridViewRow gr in gvStudentSubject.Rows)
        {
            
            HiddenField hfStudentID = (HiddenField)gr.FindControl("hfStudentID");
            GridView gvSubjects = (GridView)gr.FindControl("gvSubjects");

            foreach (GridViewRow grSubjects in gvSubjects.Rows)
            {
                HiddenField hfClassSubjectID = (HiddenField)grSubjects.FindControl("hfClassSubjectID");
                CheckBox chkSelect = (CheckBox)grSubjects.FindControl("chkSelect");

                if (chkSelect.Checked)
                {
                    if (subjectIDs == "") subjectIDs = hfStudentID.Value + " " + hfClassSubjectID.Value;
                    else subjectIDs += "," + hfStudentID.Value + " " + hfClassSubjectID.Value;
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
            STD_ClassSubjectStudentManager.DeleteSTD_ClassSubjectStudentByClassID(int.Parse(ddlClassID.SelectedValue));

            string ids = getSubjectID();
            if (ids != "")
            {
                string[] words = ids.Split(',');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        string[] id = word.Split(' ');
                        STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                        //	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
                        sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                        sTD_ClassSubjectStudent.StudentID = id[0];
                        sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(id[1]);
                        sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                        sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                        sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                        sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                        int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
                    }
                }
            }
        }
        catch (Exception ex) { }
        ddlClassID_SelectedIndexChanged(this, e);
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
            DataSet ds = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassID(int.Parse(ddlClassID.SelectedValue),true);
            
            if(ds==null)return;
            if (ds.Tables[0].Rows[0]["ClassRowStatusID"].ToString() != "1")
            {
                btnAdd.Enabled = false;
                btnAdd.Text = "This Class is Completed, you can not save";
            }
            else
            {
                btnAdd.Enabled = true;
                btnAdd.Text = "Save";
            }

            gvSubject.Visible = true;
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
    

    protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedIndex != 0)
        {
            gvSubject.Visible = true;
            gvStudentSubject.Visible = true;

            SubjectIDLoad();
            SubjectStudentLoad();
        }
        else
        {
            gvSubject.Visible = false;
            gvStudentSubject.Visible = false;
        }
    }

    private void SubjectStudentLoad()
    {
        try
        {
            hfClassSubjectStudentID.Value = "";
            List<STD_Student> students = new List<STD_Student>();
            DataSet dsStudentsByClassID =STD_ClassStudentManager.GetSTD_StudentByClassIDWithHistory(int.Parse(ddlClassID.SelectedValue));
            DataSet dsClassSubjectStudentByClass = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByClassID(int.Parse(ddlClassID.SelectedValue));
            Session["ClassSubjectStudentByClass"] = dsClassSubjectStudentByClass;
            string studentIDs = ";";

            foreach (DataRow dr in dsStudentsByClassID.Tables[0].Rows)
            {
                if (!studentIDs.Contains(";" + dr["StudentID"].ToString() + ";"))
                {
                    studentIDs += dr["StudentID"].ToString() + ";";

                    STD_Student student = new STD_Student();
                    student.StudentID = dr["StudentID"].ToString();
                    student.StudentName = dr["StudentName"].ToString();
                    student.StudentCode = dr["StudentCode"].ToString();
                    student.PPSizePhoto = dr["PPSizePhoto"].ToString();
                    student.IsActive = true;
                    student.IsHistory = false;
                    students.Add(student);
                }

            }

            foreach (DataRow dr in dsStudentsByClassID.Tables[1].Rows)
            {
                if (!studentIDs.Contains(";" + dr["StudentID"].ToString() + ";"))
                {
                    studentIDs += dr["StudentID"].ToString() + ";";

                    STD_Student student = new STD_Student();
                    student.StudentID = dr["StudentID"].ToString();
                    student.StudentName = dr["StudentName"].ToString();
                    student.StudentCode = dr["StudentCode"].ToString();
                    student.PPSizePhoto = dr["PPSizePhoto"].ToString();
                    student.IsActive = false;
                    student.IsHistory = true;
                    students.Add(student);
                }
            }

            if (dsStudentsByClassID != null)
            {

                if (dsStudentsByClassID == null) return;
                if (dsStudentsByClassID.Tables[0].Rows.Count == 0)
                {
                    gvStudentSubject.Visible = false;
                    btnAdd.Visible = false;
                    return;
                }
                btnAdd.Visible = true;
                gvStudentSubject.Visible = true;
            }
                       
            gvStudentSubject.DataSource = students;
            gvStudentSubject.DataBind();
        }
        catch (Exception ex)
        { 
        
        }
    
    }


    protected void gvStudentSubject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataSet dsClassSubjectStudentByClass = new DataSet();

            if (Session["ClassSubjectStudentByClass"] != null)
                dsClassSubjectStudentByClass = (DataSet)Session["ClassSubjectStudentByClass"];

            gvSubject.Visible = true;

            HiddenField hfIsActive = (HiddenField)e.Row.FindControl("hfIsActive");
            HiddenField hfStudentID = (HiddenField)e.Row.FindControl("hfStudentID");
            //HiddenField hfClassStudentID = (HiddenField)e.Row.FindControl("hfClassStudentID");

            GridView gvSubjects = (GridView)e.Row.FindControl("gvSubjects");
            GridView gvSubjectsPassed = (GridView)e.Row.FindControl("gvSubjectsPassed");

            DataTable dtSubjects = new DataTable();
            dtSubjects.Columns.Add("SubjectID", typeof(int));
            dtSubjects.Columns.Add("StudentID", typeof(string));
            dtSubjects.Columns.Add("ClassSubjectID", typeof(int));
            dtSubjects.Columns.Add("ClassSubjectStudentID", typeof(int));
            dtSubjects.Columns.Add("SubjectName", typeof(string));
            dtSubjects.Columns.Add("IsChecked", typeof(bool));
            dtSubjects.Columns.Add("IsEnabled", typeof(bool));


            DataTable dtSubjectsPassed = new DataTable();
            dtSubjectsPassed.Columns.Add("SubjectID", typeof(int));
            dtSubjectsPassed.Columns.Add("StudentID", typeof(string));
            dtSubjectsPassed.Columns.Add("ClassSubjectID", typeof(int));
            dtSubjectsPassed.Columns.Add("ClassSubjectStudentID", typeof(int));
            dtSubjectsPassed.Columns.Add("SubjectName", typeof(string));
            dtSubjectsPassed.Columns.Add("IsChecked", typeof(bool));
            dtSubjectsPassed.Columns.Add("IsEnabled", typeof(bool));

            foreach (GridViewRow gvRow in gvSubject.Rows)
            {
                HiddenField hfSubjectID = (HiddenField)gvRow.FindControl("hfSubjectID");
                HiddenField hfClassSubjectID = (HiddenField)gvRow.FindControl("hfClassSubjectID");
                Label lblSubjectName = (Label)gvRow.FindControl("lblSubjectName");

                DataRow drSubject = dtSubjects.NewRow();
                drSubject["SubjectID"]=int.Parse(hfSubjectID.Value);
                drSubject["StudentID"]=hfStudentID.Value;
                drSubject["ClassSubjectID"] = int.Parse(hfClassSubjectID.Value);
                drSubject["ClassSubjectStudentID"] = 0;
                drSubject["SubjectName"]=lblSubjectName.Text;
                drSubject["IsChecked"] = false;
                drSubject["IsEnabled"] = true;

                DataRow drSubjectPassed = dtSubjectsPassed.NewRow();
                drSubjectPassed["SubjectID"] = int.Parse(hfSubjectID.Value);
                drSubjectPassed["StudentID"] = hfStudentID.Value;
                drSubjectPassed["ClassSubjectID"] = int.Parse(hfClassSubjectID.Value);
                drSubjectPassed["ClassSubjectStudentID"] = 0;
                drSubjectPassed["SubjectName"] = lblSubjectName.Text;
                drSubjectPassed["IsChecked"] = false;
                drSubjectPassed["IsEnabled"] = true;

                bool needtoDelete = false;

                if (dsClassSubjectStudentByClass != null)
                {
                    if (dsClassSubjectStudentByClass.Tables.Count != 0)
                    {
                        foreach (DataRow dr in dsClassSubjectStudentByClass.Tables[0].Rows)
                        {
                            if (bool.Parse(hfIsActive.Value))
                            {
                                drSubject["IsEnabled"] = true;
                                drSubjectPassed["IsEnabled"] = true;
                            }
                            else
                            {
                                drSubject["IsEnabled"] = false;
                                drSubjectPassed["IsEnabled"] = false;
                            }

                            if (dr["SubjectID"].ToString() == hfSubjectID.Value && dr["StudentID"].ToString() == hfStudentID.Value)
                            {
                                drSubject["ClassSubjectStudentID"] = dr["ClassSubjectStudentID"];
                                drSubjectPassed["ClassSubjectStudentID"] = dr["ClassSubjectStudentID"];
                                hfClassSubjectStudentID.Value += "-" + dr["ClassSubjectStudentID"].ToString()+"-";
                                drSubject["IsChecked"] = true;
                                drSubjectPassed["IsChecked"] = true;
                                needtoDelete = true;
                                break;
                            }

                            
                        }
                    }
                }

                dtSubjects.Rows.Add(drSubject);
                if (needtoDelete)
                {
                    dtSubjectsPassed.Rows.Add(drSubjectPassed);
                }
            }

            if (bool.Parse(hfIsActive.Value))
            {
                gvSubjects.Enabled = true;
                gvSubjectsPassed.Enabled = true;
            }
            else
            {
                gvSubjects.Enabled = false;
                gvSubjectsPassed.Enabled = false;
                //gvSubjects.Visible = false;
            }

            gvSubjects.DataSource = dtSubjects;
            gvSubjects.DataBind();

            gvSubjectsPassed.DataSource = dtSubjectsPassed;
            gvSubjectsPassed.DataBind();
        }
    }
    #endregion


    protected void OnCheckedChanged_chkSelect(object sender, EventArgs e)
    {
        string mesg = "";
        CheckBox chkSubject = new CheckBox();
        chkSubject = (CheckBox)sender;

        string subject = chkSubject.ToolTip;
        string studentID = chkSubject.ValidationGroup.ToString();
        
        
        DataSet subjects = STD_ClassSubjectStudentManager.GetSTD_StudentSubjectByStudentID(studentID.ToString());
        foreach (DataRow dr in subjects.Tables[0].Rows)
        {
            if (subject == dr["SubjectName"].ToString() && dr["ClassName"].ToString() != ddlClassID.SelectedItem.Text)
            {
                chkSubject.Checked = false;
                pnCheck.Visible = true;
                mesg = dr["StudentName"].ToString() + " " + " has" + " " + subject + " " + "with" + " " + dr["ClassName"].ToString() + " " +
                    "<a herf='ClassSubjectAddStudent.aspx?batchID=" + dr["ClassID"].ToString() + "' target='_blank'>Click here</a> to Change that batch" + "<br />" + "\n";

                if (Session["msg"] != null)
                {
                    string[] spMsg = Session["msg"].ToString().Split('\n');
                    for (int i = 0; i < spMsg.Length; i++)
                    {
                        if (mesg == (spMsg[i] + "\n"))
                        {
                            mesg = "";
                        }
                    }
                    Session["msg"] = Session["msg"] + mesg;
                }
                else
                {
                    Session["msg"] = Session["msg"] + mesg;
                }

                lblCheck.Text = Session["msg"].ToString();
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('" + dr["StudentName"].ToString() + " has " + subject + " in Class " + dr["ClassName"].ToString() + "')", true);
            }
            else
            { 
                //we can save this
            }
        }
    }

    protected void chkClosedClasses_CheckedChanged(object sender, EventArgs e)
    {
        ClassIDLoad();
    }

    protected void process()
    {
        //delete all the info 1st then we will process
         STD_ClassSubjectStudentManager.DeleteSTD_ClassSubjectStudentByClassID(int.Parse(ddlClassID.SelectedValue));
        //Session["ClassSubjectStudentByClass"] = dsClassSubjectStudentByClass;

        //foreach (DataRow dr in dsClassSubjectStudentByClass.Tables[0].Rows)
        //{
        //    try
        //    {
        //        //if (hfClassSubjectStudentID.Value.Contains("-" + dr["ClassSubjectStudentID"].ToString() + "-"))
        //        //{
        //            STD_ClassSubjectStudent subject = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByClassSubjectStudentID(int.Parse(dr["ClassSubjectStudentID"].ToString()));
        //            subject.RowStatusID = 3;
        //            STD_ClassSubjectStudentManager.UpdateSTD_ClassSubjectStudent(subject);
        //        //}
        //    }
        //    catch (Exception ex)
        //    { }
        //}


        string mesg = "";
        foreach (GridViewRow gr in gvStudentSubject.Rows)
        {

            HiddenField hfStudentID = (HiddenField)gr.FindControl("hfStudentID");
            GridView gvSubjects = (GridView)gr.FindControl("gvSubjects");
            GridView gvSubjectsPassed = (GridView)gr.FindControl("gvSubjectsPassed");

            foreach (GridViewRow grSubjects in gvSubjects.Rows)
            {
                HiddenField hfClassSubjectID = (HiddenField)grSubjects.FindControl("hfClassSubjectID");
                CheckBox chkSubject = (CheckBox)grSubjects.FindControl("chkSelect");

                if (chkSubject.Checked)
                {
                    string subject = chkSubject.ToolTip;
                    string studentID = chkSubject.ValidationGroup.ToString();

                    try
                    {
                        DataSet subjects = STD_ClassSubjectStudentManager.GetSTD_StudentSubjectByStudentID(studentID.ToString());
                        foreach (DataRow dr in subjects.Tables[0].Rows)
                        {
                            if ((subject == dr["SubjectName"].ToString()) && (dr["ClassName"].ToString() != ddlClassID.SelectedItem.Text))
                            {
                                chkSubject.Checked = false;
                                pnCheck.Visible = true;
                                mesg = dr["StudentName"].ToString() + " " + " has" + " " + subject + " " + "with" + " " + dr["ClassName"].ToString() + " " +
                                    "<a herf='ClassSubjectAddStudent.aspx?batchID=" + dr["ClassID"].ToString() + "' target='_blank'>Click here</a> to Change that batch" + "<br />" + "\n";

                                if (Session["msg"] != null)
                                {
                                    string[] spMsg = Session["msg"].ToString().Split('\n');
                                    for (int i = 0; i < spMsg.Length; i++)
                                    {
                                        if (mesg == (spMsg[i] + "\n"))
                                        {
                                            mesg = "";
                                        }
                                    }
                                    Session["msg"] = Session["msg"] + mesg;
                                }
                                else
                                {
                                    Session["msg"] = Session["msg"] + mesg;
                                }

                                lblCheck.Text = Session["msg"].ToString();
                                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('" + dr["StudentName"].ToString() + " has " + subject + " in Class " + dr["ClassName"].ToString() + "')", true);

                                return;
                            }
                            else
                            {

                            }
                        }
                    }
                    catch (Exception ex)
                    { }


                    try
                    {
                        //we can save this
                        STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                        //	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
                        sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                        sTD_ClassSubjectStudent.StudentID = studentID;
                        sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(hfClassSubjectID.Value);
                        sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                        sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                        sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                        sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                        sTD_ClassSubjectStudent.RowStatusID = 1;
                        int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
                    }
                    catch (Exception ex)
                    { }
                }
            }

            foreach (GridViewRow grSubjects in gvSubjectsPassed.Rows)
            {
                HiddenField hfClassSubjectID = (HiddenField)grSubjects.FindControl("hfClassSubjectID");
                CheckBox chkSubject = (CheckBox)grSubjects.FindControl("chkSelect");

                if (chkSubject.Checked)
                {
                    string subject = chkSubject.ToolTip;
                    string studentID = chkSubject.ValidationGroup.ToString();


                    //DataSet subjects = STD_ClassSubjectStudentManager.GetSTD_StudentSubjectByStudentID(studentID.ToString());
                    //foreach (DataRow dr in subjects.Tables[0].Rows)
                    //{
                    //    if ((subject == dr["SubjectName"].ToString()) && (dr["ClassName"].ToString() != ddlClassID.SelectedItem.Text))
                    //    {
                    //        chkSubject.Checked = false;
                    //        pnCheck.Visible = true;
                    //        mesg = dr["StudentName"].ToString() + " " + " has" + " " + subject + " " + "with" + " " + dr["ClassName"].ToString() + " " +
                    //            "<a herf='ClassSubjectAddStudent.aspx?batchID=" + dr["ClassID"].ToString() + "' target='_blank'>Click here</a> to Change that batch" + "<br />" + "\n";

                    //        if (Session["msg"] != null)
                    //        {
                    //            string[] spMsg = Session["msg"].ToString().Split('\n');
                    //            for (int i = 0; i < spMsg.Length; i++)
                    //            {
                    //                if (mesg == (spMsg[i] + "\n"))
                    //                {
                    //                    mesg = "";
                    //                }
                    //            }
                    //            Session["msg"] = Session["msg"] + mesg;
                    //        }
                    //        else
                    //        {
                    //            Session["msg"] = Session["msg"] + mesg;
                    //        }

                    //        lblCheck.Text = Session["msg"].ToString();
                    //        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('" + dr["StudentName"].ToString() + " has " + subject + " in Class " + dr["ClassName"].ToString() + "')", true);

                    //        return;
                    //    }
                    //    else
                    //    {

                    //    }
                    //}
                    try
                    {
                        bool result = STD_ClassSubjectStudentManager.HistorySTD_ClassSubjectStudentByClassSubjectIDnStudentID(int.Parse(hfClassSubjectID.Value),studentID);

                        //we can save this
                        //STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                        ////	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
                        //sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                        //sTD_ClassSubjectStudent.StudentID = studentID;
                        //sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(hfClassSubjectID.Value);
                        //sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                        //sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                        //sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                        //sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                        //sTD_ClassSubjectStudent.RowStatusID = 14;
                        //int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
                    }
                    catch (Exception ex)
                    { }
                }
            }

        }
    }
}

