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
            ddlClassID_SelectedIndexChanged(this, e);
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
    #region ClassStudent

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            string ids = getStudentIDs(gvStudent);
            if (ids != "")
            {
                STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
                sTD_ClassStudent.ClassStudentName = "";
                sTD_ClassStudent.StudentID = ids;
                sTD_ClassStudent.ClassID = int.Parse(ddlClassID.SelectedValue);
                sTD_ClassStudent.AddedBy = Profile.card_id;
                sTD_ClassStudent.AddedDate = DateTime.Now;
                sTD_ClassStudent.UpdatedBy = Profile.card_id;
                sTD_ClassStudent.UpdateDate = DateTime.Now;
                sTD_ClassStudent.RowStatusID = 1;
                int resutl = STD_ClassStudentManager.InsertSTD_ClassStudent_List(sTD_ClassStudent);

                string message = resutl + " New Entry Created";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + message + "');", true);

                txtStudentIDs.Text = "";

                Response.Redirect("ClassSubjectAddStudent.aspx?ID="+ddlClassID.SelectedValue);
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
                        sTD_ClassStudent.ClassStudentName = ddlClassID.SelectedItem.Text;
                        sTD_ClassStudent.StudentID = word;
                        sTD_ClassStudent.ClassID = int.Parse(ddlClassID.SelectedValue);
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
        Response.Redirect("ClassSubjectAddStudent.aspx?ID=" + ddlClassID.SelectedValue); //loadGrid();
        //btnUpdate.Visible = false;
    }
    private void showSTD_ClassStudentData()
    {
        ddlClassID.SelectedValue = Request.QueryString["ID"];
        ddlClassesToDisplay.SelectedValue = Request.QueryString["ID"];
        
        //STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
        //sTD_ClassStudent = STD_ClassStudentManager.GetSTD_ClassStudentByClassStudentID(Int32.Parse(Request.QueryString["ID"]));
        ////ddlStudentID.SelectedValue = sTD_ClassStudent.StudentID.ToString();
        //ddlClassID.SelectedValue = sTD_ClassStudent.ClassID.ToString();
        StudentIDLoad(STD_ClassManager.GetSTD_ClassByClassID(int.Parse(ddlClassID.SelectedItem.Value)).CourseID);
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

    private void StudentIDLoad(int classID)
    {
        try
        {
            DataSet ds = STD_ClassStudentManager.GetSTD_ClassStudentByClassIDWithHistory(classID);

            gvStudent.DataSource = ds.Tables[0];
            gvStudent.DataBind();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void chkClosedClasses_CheckedChanged(object sender, EventArgs e)
    {
        ClassIDLoad();
    }

    private void ClassIDLoad()
    {
        try
        {

            DataSet ds =  STD_ClassManager.GetDropDownListAllSTD_Class();
            ddlClassID.DataValueField = "ClassID";
            ddlClassID.DataTextField = "ClassName";
            ddlClassID.DataSource = ds.Tables[0];
            ddlClassID.DataBind();
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0"));


            ds = chkClosedClasses.Checked ? STD_ClassManager.GetDropDownListAllSTD_ClassWithHistory() : STD_ClassManager.GetDropDownListAllSTD_ClassStudent();
            ddlClassIDSearch.DataValueField = "ClassID";
            ddlClassIDSearch.DataTextField = "ClassName";
            ddlClassIDSearch.DataSource = ds.Tables[0];
            ddlClassIDSearch.DataBind();
            ddlClassIDSearch.Items.Insert(0, new ListItem("Select Class >>", "0"));


            ddlClassesToDisplay.DataValueField = "ClassID";
            ddlClassesToDisplay.DataTextField = "ClassName";
            ddlClassesToDisplay.DataSource = ds.Tables[0];
            ddlClassesToDisplay.DataBind();
            ddlClassesToDisplay.Items.Insert(0, new ListItem("Select Class >>", "0"));
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

            GridView gvStudents = (GridView)e.Row.FindControl("gvStudents");
            gvStudents.DataSource = STD_ClassStudentManager.GetSTD_ClassStudentByClassIDWithHistory(int.Parse(lblClassID.Text));
            gvStudents.DataBind();
        }

    }

    protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClassIDSearch.SelectedValue == "0")
            {
                //StudentIDLoadNotInthisClass();
                gvStudent.DataSource = new List<STD_Student>();
                gvStudent.DataBind();
            }
            else
                if (ddlClassIDSearch.SelectedIndex != 0)
                {
                    gvStudent.Visible = true;
                    StudentIDLoad(int.Parse(ddlClassIDSearch.SelectedValue));
                }
            if (ddlClassIDSearch.SelectedValue == ddlClassID.SelectedValue)
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
        panPager.Visible = true;    
        STD_ClassManager.LoadSTD_ClassStudentPageByClass(gvSTD_Class, rptPager, 1, ddlPageSize);
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_ClassManager.LoadSTD_ClassStudentPageByClass(gvSTD_Class, rptPager, 1, ddlPageSize);
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_ClassManager.LoadSTD_ClassStudentPageByClass(gvSTD_Class, rptPager, pageIndex, ddlPageSize);
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
        bool result = STD_ClassStudentManager.DeleteSTD_ClassStudent(Convert.ToInt32(linkButton.CommandArgument));
        //STD_ClassManager.LoadSTD_ClassPage(gvSTD_Class, rptPager, 1, ddlPageSize);
        loadGrid();
        ddlClassID_SelectedIndexChanged(this, e);
    }

    protected void ddlClassesToDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClassesToDisplay.SelectedIndex > 0)
            {
                List<STD_Class> classes = new List<STD_Class>();
                classes.Add(STD_ClassManager.GetSTD_ClassByClassID(Convert.ToInt32(ddlClassesToDisplay.SelectedValue)));
                gvSTD_Class.DataSource = classes;
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
        ddlClassID_SelectedIndexChanged(this, e);
    }

    #region

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            string[] ids = txtStudentIDs.Text.Split(',');
            List<STD_Student> students = new List<STD_Student>();
            foreach (string id in ids)
            {
                STD_Student student = STD_StudentManager.GetHR_StudnetByStudentCode(id.Trim());
                if (student != null)
                    students.Add(student);
            }

            gvStudents.DataSource = students;
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
                STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
                sTD_ClassStudent.ClassStudentName = "";
                sTD_ClassStudent.StudentID = ids;
                sTD_ClassStudent.ClassID = int.Parse(ddlClassID.SelectedValue);
                sTD_ClassStudent.AddedBy = Profile.card_id;
                sTD_ClassStudent.AddedDate = DateTime.Now;
                sTD_ClassStudent.UpdatedBy = Profile.card_id;
                sTD_ClassStudent.UpdateDate = DateTime.Now;
                int resutl = STD_ClassStudentManager.InsertSTD_ClassStudent_List_KeepStudentInMultipleClassActive(sTD_ClassStudent);

                string message = resutl + " New Entry Created";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + message + "');", true);

                txtStudentIDs.Text = "";
                Response.Redirect("ClassSubjectAddStudent.aspx?ID=" + ddlClassID.SelectedValue);
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