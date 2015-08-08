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


public partial class AdminDisplaySTD_ClassStudent : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_ClassStudentData();
            ClassIDLoad();
            loadAllEmployee(0);
            ddlSubjectID_SelectedIndexChanged(this, e);
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                //btnAdd.Visible = false;
                //btnUpdate.Visible = true;
                showSTD_ClassStudentData();
            }
            loadGrid();
        }
    }

    private void loadAllEmployee(int subjectID)
    {
        if (subjectID == 0)
        {
            DataSet ds = new DataSet();
            ds = HR_EmployeeManager.GetAllHR_Employees();
            gvAllEmployeeList.DataSource = ds;
            gvAllEmployeeList.DataBind();
        }
        else
        {
            DataSet ds = new DataSet();
            ds = HR_EmployeeManager.GetAllHR_EmployeesNotForThisSubject(subjectID);
            gvAllEmployeeList.DataSource = ds;
            gvAllEmployeeList.DataBind();
        }
    }
    protected void ddlSubjectIDTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadAllEmployee(int.Parse(ddlSubjectID.SelectedValue));
    }

    #region ClassStudent

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            string ids = getStudentIDs(gvStudent);
            if (ids != "")
            {
                STD_SubjectEmployee sTD_ClassStudent = new STD_SubjectEmployee();
                sTD_ClassStudent.SubjectEmployeeName = "";
                sTD_ClassStudent.EmployeeID = ids;
                sTD_ClassStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                sTD_ClassStudent.CampusID = 1;
                sTD_ClassStudent.AddedBy = Profile.card_id;
                sTD_ClassStudent.AddedDate = DateTime.Now;
                sTD_ClassStudent.UpdatedBy = Profile.card_id;
                sTD_ClassStudent.UpdateDate = DateTime.Now;
                sTD_ClassStudent.RowStatusID = 1;
                int resutl = STD_SubjectManager.InsertSTD_SubjectEmployee_List(sTD_ClassStudent);

                string message = resutl + " New Entry Created";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + message + "');", true);

                txtStudentIDs.Text = "";

                loadGrid();
            }


        }
        catch (Exception ex) { }

        //loadGrid();
    }

    private string getStudentID()
    {
        string StudentIDs = "";

        foreach (GridViewRow gr in gvStudent.Rows)
        {
            CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");

            HiddenField hfStudentID = (HiddenField)gr.FindControl("hfStudentID");

            if (chkSelect.Checked)
            {
                if (StudentIDs == "") StudentIDs = hfStudentID.Value;
                else StudentIDs += "," + hfStudentID.Value;
            }
        }

        return StudentIDs;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            string ids = getStudentID();
            if (ids != "")
            {
                string[] words = ids.Split(',');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
                        sTD_ClassStudent.ClassStudentName = ddlSubjectID.SelectedItem.Text;
                        sTD_ClassStudent.StudentID = word;
                        sTD_ClassStudent.ClassID = int.Parse(ddlSubjectID.SelectedValue);
                        sTD_ClassStudent.AddedBy = Profile.card_id;
                        sTD_ClassStudent.AddedDate = DateTime.Now;
                        sTD_ClassStudent.UpdatedBy = Profile.card_id;
                        sTD_ClassStudent.UpdateDate = DateTime.Now;
                        int resutl = STD_ClassStudentManager.InsertSTD_ClassStudent(sTD_ClassStudent);
                    }
                }
            }
        }
        catch (Exception ex) { }
        Response.Redirect("ClassSubjectAddStudent.aspx?ID=" + ddlSubjectID.SelectedValue); //loadGrid();
        //btnUpdate.Visible = false;
    }
    private void showSTD_ClassStudentData()
    {
        ddlSubjectID.SelectedValue = Request.QueryString["ID"];
        ddlClassesToDisplay.SelectedValue = Request.QueryString["ID"];
        
        //STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
        //sTD_ClassStudent = STD_ClassStudentManager.GetSTD_ClassStudentByClassStudentID(Int32.Parse(Request.QueryString["ID"]));
        ////ddlStudentID.SelectedValue = sTD_ClassStudent.StudentID.ToString();
        //ddlSubjectID.SelectedValue = sTD_ClassStudent.ClassID.ToString();
        StudentIDLoad(STD_ClassManager.GetSTD_ClassByClassID(int.Parse(ddlSubjectID.SelectedItem.Value)).CourseID);
        ddlClassesToDisplay_SelectedIndexChanged(this, new EventArgs());
    }
    private void StudentIDLoadNotInthisClass()
    {
        try
        {
            DataSet ds = STD_ClassStudentManager.GetAllSTD_ClassStudentsNotAnyClass();
            gvStudent.DataSource = ds.Tables[0];
            gvStudent.DataBind();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void StudentIDLoad(int subjectID)
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetSTD_SubjectEmployeeBySubjectID(subjectID);

            gvStudent.DataSource = ds.Tables[0];
            gvStudent.DataBind();
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
            DataSet ds = STD_SubjectManager.GetAllSTD_Subjects();
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "CourseSubject";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));


            ds = STD_SubjectManager.GetDropDownListAllSTD_SubjectEmployee();
            ddlSubjectIDSearch.DataValueField = "SubjectID";
            ddlSubjectIDSearch.DataTextField = "CourseSubject";
            ddlSubjectIDSearch.DataSource = ds.Tables[0];
            ddlSubjectIDSearch.DataBind();
            ddlSubjectIDSearch.Items.Insert(0, new ListItem("Select Subject >>", "0"));


            ddlClassesToDisplay.DataValueField = "SubjectID";
            ddlClassesToDisplay.DataTextField = "CourseSubject";
            ddlClassesToDisplay.DataSource = ds.Tables[0];
            ddlClassesToDisplay.DataBind();
            ddlClassesToDisplay.Items.Insert(0, new ListItem("Select Subject >>", "0"));
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
            Label lblSubjectID = (Label)e.Row.FindControl("lblSubjectID");

            GridView gvStudents = (GridView)e.Row.FindControl("gvStudents");
            gvStudents.DataSource = STD_SubjectManager.GetSTD_SubjectEmployeeBySubjectID(int.Parse(lblSubjectID.Text));
            gvStudents.DataBind();
        }

    }

    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubjectIDSearch.SelectedValue == "0")
            {
                //StudentIDLoadNotInthisClass();
                gvStudent.DataSource = new List<STD_Student>();
                gvStudent.DataBind();
            }
            else
                if (ddlSubjectIDSearch.SelectedIndex != 0)
                {
                    gvStudent.Visible = true;
                    StudentIDLoad(int.Parse(ddlSubjectIDSearch.SelectedValue));
                }
            if (ddlSubjectIDSearch.SelectedValue == ddlSubjectID.SelectedValue)
            {
                //StudentIDLoadNotInthisClass();
                gvStudent.DataSource = new List<STD_Student>();
                gvStudent.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    #region Class
    private void loadGrid()
    {
        ClassIDLoad();
        panPager.Visible = true;    
        STD_SubjectManager.LoadSTD_SubjectEmployeePageWiseBySubject(gvSTD_Class, rptPager, 1, ddlPageSize);
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_SubjectManager.LoadSTD_SubjectEmployeePageWiseBySubject(gvSTD_Class, rptPager, 1, ddlPageSize);
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_SubjectManager.LoadSTD_SubjectEmployeePageWiseBySubject(gvSTD_Class, rptPager, pageIndex, ddlPageSize);
    }

    protected void lbSelectClass_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("ClassStudentAdd.aspx?ID=" + id);
    }

    protected void lbDeleteClass_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = STD_SubjectManager.DeleteSTD_SubjectEmployee(Convert.ToInt32(linkButton.CommandArgument));
        //STD_ClassManager.LoadSTD_ClassPage(gvSTD_Class, rptPager, 1, ddlPageSize);
        loadGrid();
        ddlSubjectID_SelectedIndexChanged(this, e);
    }

    protected void ddlClassesToDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClassesToDisplay.SelectedIndex > 0)
            {
                List<STD_Subject> subjects = new List<STD_Subject>();
                //subjects.Add(STD_ClassManager.GetSTD_ClassByClassID(Convert.ToInt32(ddlClassesToDisplay.SelectedValue)));
                subjects.Add(STD_SubjectManager.GetSTD_SubjectFromSubjectEmployeeBySubjectID(Convert.ToInt32(ddlClassesToDisplay.SelectedValue)));
                gvSTD_Class.DataSource = subjects;
                gvSTD_Class.DataBind();
                panPager.Visible = false;
            }
            else
            {
                loadGrid();
                panPager.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
    
    #endregion
    protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
    {
        ddlSubjectID_SelectedIndexChanged(this, e);
    }

    #region

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            string[] ids = txtStudentIDs.Text.Split(',');
            List<HR_Employee> teachers = new List<HR_Employee>();
            foreach (string id in ids)
            {
                HR_Employee teacher = HR_EmployeeManager.GetHR_EmployeeByEmployeeNo(id.Trim());
                if (teacher != null)
                    teachers.Add(teacher);
            }

            gvStudents.DataSource = teachers;
            gvStudents.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        try
        {
            //string ids = getStudentID();
            string ids = getStudentIDs(gvStudents);
            if (ids != "")
            {
                STD_SubjectEmployee sTD_ClassStudent = new STD_SubjectEmployee();
                sTD_ClassStudent.SubjectEmployeeName = "";
                sTD_ClassStudent.EmployeeID = ids;
                sTD_ClassStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                sTD_ClassStudent.CampusID = 1;
                sTD_ClassStudent.AddedBy = Profile.card_id;
                sTD_ClassStudent.AddedDate = DateTime.Now;
                sTD_ClassStudent.UpdatedBy = Profile.card_id;
                sTD_ClassStudent.UpdateDate = DateTime.Now;
                sTD_ClassStudent.RowStatusID = 1;
                int resutl = STD_SubjectManager.InsertSTD_SubjectEmployee_List(sTD_ClassStudent);

                string message = resutl + " New Teacher has added";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + message + "');", true);

                txtStudentIDs.Text = "";
                loadGrid();
                //Response.Redirect("ClassSubjectAddStudent.aspx?ID=" + ddlSubjectID.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + ex.Message.ToString() + "');", true);
        }
    }
    protected void btnAdd3_Click(object sender, EventArgs e)
    {
        try
        {
            //string ids = getStudentID();
            string ids = getStudentIDs(gvAllEmployeeList);
            if (ids != "")
            {
                STD_SubjectEmployee sTD_ClassStudent = new STD_SubjectEmployee();
                sTD_ClassStudent.SubjectEmployeeName = "";
                sTD_ClassStudent.EmployeeID = ids;
                sTD_ClassStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                sTD_ClassStudent.CampusID = 1;
                sTD_ClassStudent.AddedBy = Profile.card_id;
                sTD_ClassStudent.AddedDate = DateTime.Now;
                sTD_ClassStudent.UpdatedBy = Profile.card_id;
                sTD_ClassStudent.UpdateDate = DateTime.Now;
                sTD_ClassStudent.RowStatusID = 1;
                int resutl = STD_SubjectManager.InsertSTD_SubjectEmployee_List(sTD_ClassStudent);

                string message = resutl + " New Teacher has added";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + message + "');", true);

                txtStudentIDs.Text = "";
                loadGrid();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + ex.Message.ToString() + "');", true);
        }
    }
    private string getStudentIDs(GridView gv)
    {
        string ids = string.Empty;
        try
        {
            foreach (GridViewRow row in gv.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    HiddenField hfStudentID = (HiddenField)row.FindControl("hfStudentID");
                    ids += hfStudentID.Value + ", ";
                }
            }
            if (ids.Length > 0)
                ids = ids.Substring(0, ids.Length - 2);
        }
        catch (Exception ex)
        {
        }
        return ids;
    }
    #endregion
    protected void btnLoadAllClass_Click(object sender, EventArgs e)
    {
        loadGrid();
    }
}