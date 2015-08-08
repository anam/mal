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
 

public partial class AdminDisplaySTD_ClassSubjectStudent : System.Web.UI.Page
{
	

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_ClassSubjectData();
            ClassSubjectIDLoad();
            ddlClassSubjectID_SelectedIndexChanged(this,e);
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                //btnAdd.Visible = false;
                //btnUpdate.Visible = true;
                showSTD_ClassSubjectStudentData();
            }

            loadGrid();
        }
    }
    #region ClassSubject
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //delete all the rows for the
            //STD_ClassSubjectStudentManager.DeleteSTD_ClassSubjectStudentByClassSubjectID(int.Parse(ddlClassSubjectIDMain.SelectedValue));


            string ids=getSubjectID();
            if (ids != "")
            {
                string[] words = ids.Split(',');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                        //	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
                        sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                        sTD_ClassSubjectStudent.StudentID = word;
                        sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(ddlClassSubjectIDMain.SelectedValue);
                        sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                        sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                        sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                        sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                        sTD_ClassSubjectStudent.RowStatusID = 1;
                        int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
                    }
                }
            }

           
        }
        catch (Exception ex) { }
        
        loadGrid();
    }

    private string getSubjectID()
    {
        string StudentIDs = "";

        foreach (GridViewRow gr in gvSubject.Rows)
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
            //delete all the rows for the
            //STD_ClassSubjectStudentManager.DeleteSTD_ClassSubjectStudentByClassSubjectID(int.Parse(ddlClassSubjectIDMain.SelectedValue));

            string ids = getSubjectID();
            if (ids != "")
            {
                string[] words = ids.Split(',');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                        //	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
                        sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                        sTD_ClassSubjectStudent.StudentID = word;
                        sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(ddlClassSubjectIDMain.SelectedValue);
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
        loadGrid();
        btnUpdate.Visible = false;
    }
    private void showSTD_ClassSubjectStudentData()
    {
        ddlClassSubjectID.SelectedValue = Request.QueryString["ID"];
        ddlClassSubjectIDMain.SelectedValue = Request.QueryString["ID"];
        SubjectIDLoad(Int32.Parse(Request.QueryString["ID"]));
    }

    private void SubjectIDLoad(int classSubjectID)
    {
        try
        {
            //DataSet dsStudent = STD_StudentManager.GetAllSTD_Students();
            //dsStudent.Tables[0].Columns.Add("IsChecked", typeof(bool));
            DataSet dsClassSubjectStudent = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectByClassSubjectID(classSubjectID,true);
            if (dsClassSubjectStudent == null) return;

            //foreach (DataRow drStudent in dsStudent.Tables[0].Rows)
            //{
            //    drStudent["IsChecked"] = false;
            //    foreach (DataRow drClassSubjectStudent in dsClassSubjectStudent.Tables[0].Rows)
            //    {
            //        if (drClassSubjectStudent["StudentID"].ToString() == drStudent["StudentID"].ToString())
            //        {
            //            drStudent["IsChecked"] = true;
            //            break;
            //        }
            //    }
            //}

            //gvSubject.DataSource = dsStudent.Tables[0];
            gvSubject.DataSource = dsClassSubjectStudent.Tables[0];
            gvSubject.DataBind();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void ClassSubjectIDLoad()
    {
        try
        {
            DataSet ds = STD_ClassSubjectManager.GetDropDownListAllSTD_ClassSubject_NotFinished();
            
            ListItem li = new ListItem("Select Class >>", "0");
            ddlClassSubjectID.Items.Add(li);
            ddlClassSubjectIDMain.Items.Add(li);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["ClassName"].ToString() + " -> " + dr["SubjectName"].ToString(), dr["ClassSubjectID"].ToString());
                ddlClassSubjectID.Items.Add(item);
                ddlClassSubjectIDMain.Items.Add(item);
            }
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
            Label lblClassID=(Label)e.Row.FindControl("lblClassID");

            GridView gvSubjects = (GridView)e.Row.FindControl("gvSubjects");
            gvSubjects.DataSource = STD_ClassSubjectManager.GetSTD_ClassSubjectStudentByClassID(int.Parse(lblClassID.Text),true);
            gvSubjects.DataBind();
        }
    }

    protected void ddlClassSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassSubjectID.SelectedIndex == 0)
        {
            //load data according to the search student
            //gvSubject.Visible = false;
            gvSubject.Visible = false;
        }
        else if (ddlClassSubjectID.SelectedValue == ddlClassSubjectIDMain.SelectedValue) 
        {
            gvSubject.Visible = false;
        }
        else if (ddlClassSubjectID.SelectedIndex != 0)
        {
            gvSubject.Visible = true;
            if (ddlClassSubjectIDMain.SelectedIndex == 0)
            {
                ddlClassSubjectIDMain.SelectedValue = ddlClassSubjectID.SelectedValue;
            }
            SubjectIDLoad(int.Parse(ddlClassSubjectID.SelectedValue));
        }
    }
    #endregion

    #region Class
    private void loadGrid()
    {
        STD_ClassManager.LoadSTD_ClassPageByClassStudent(gvSTD_Class, rptPager, 1, ddlPageSize);
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_ClassManager.LoadSTD_ClassPageByClassStudent(gvSTD_Class, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_ClassManager.LoadSTD_ClassPageByClassStudent(gvSTD_Class, rptPager, pageIndex, ddlPageSize);
    }

    protected void lbSelectClass_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("ClassSubjectStudentAdd.aspx?ID=" + id);
    }
    protected void lbDeleteClass_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = STD_ClassSubjectStudentManager.DeleteSTD_ClassSubjectStudent(Convert.ToInt32(linkButton.CommandArgument));
        loadGrid();
        //STD_ClassManager.LoadSTD_ClassPage(gvSTD_Class, rptPager, 1, ddlPageSize);
    }
    #endregion
}

