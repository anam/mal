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
 

public partial class AdminDisplaySTD_ClassSubject : System.Web.UI.Page
{
	

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_ClassSubjectData();
            ClassIDLoad();
            ddlClassID_SelectedIndexChanged(this,e);
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                //btnAdd.Visible = false;
                //btnUpdate.Visible = true;
                ddlClassID.SelectedValue = Request.QueryString["ID"];
                showSTD_ClassSubjectData();
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
            //STD_ClassSubjectManager.DeleteSTD_ClassSubjectByClassID(int.Parse(ddlClassID.SelectedValue));

            string ids = getSubjectID();

            foreach (GridViewRow gr in gvSubject.Rows)
            {
                CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");

                HiddenField hfSubjectID = (HiddenField)gr.FindControl("hfSubjectID");

                TextBox txtStartDate = (TextBox)gr.FindControl("txtStartDate");
                TextBox txtEndDate = (TextBox)gr.FindControl("txtEndDate");

                if (chkSelect.Checked)
                {
                    STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject();
                    //	sTD_ClassSubject.ClassSubjectID=  int.Parse(ddlClassSubjectID.SelectedValue);
                    sTD_ClassSubject.ClassSubjectName = "1";
                    sTD_ClassSubject.SubjectID = int.Parse(hfSubjectID.Value);
                    sTD_ClassSubject.ClassID = int.Parse(ddlClassID.SelectedValue);
                    sTD_ClassSubject.ExtraField1 = txtStartDate.Text;
                    sTD_ClassSubject.ExtraField2 = txtEndDate.Text;
                    sTD_ClassSubject.ExtraField3 = "";
                    sTD_ClassSubject.ExtraField4 = "";
                    sTD_ClassSubject.ExtraField5 = "";
                    sTD_ClassSubject.AddedBy = Profile.card_id;
                    sTD_ClassSubject.AddedDate = DateTime.Now;
                    sTD_ClassSubject.UpdatedBy = Profile.card_id;
                    sTD_ClassSubject.UpdateDate = DateTime.Now;
                    int resutl = STD_ClassSubjectManager.InsertSTD_ClassSubject(sTD_ClassSubject);
                }
                else
                {
                    if (bool.Parse(((HiddenField)gr.FindControl("hfPreviouslyChecked")).Value))
                    {
                        STD_ClassSubjectManager.DeleteSTD_ClassSubjectByClassIDnSubjectID(int.Parse(ddlClassID.SelectedValue), int.Parse(hfSubjectID.Value));
                    }
                }
            }


            //string ids=getSubjectID();
            //if (ids != "")
            //{
            //    string[] words = ids.Split(',');
            //    foreach (string word in words)
            //    {
            //        if (word != "")
            //        {
            //            STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject();
            //            //	sTD_ClassSubject.ClassSubjectID=  int.Parse(ddlClassSubjectID.SelectedValue);
            //            sTD_ClassSubject.ClassSubjectName = "1";
            //            sTD_ClassSubject.SubjectID = int.Parse(word);
            //            sTD_ClassSubject.ClassID = int.Parse(ddlClassID.SelectedValue);
            //            sTD_ClassSubject.ExtraField1 = "";
            //            sTD_ClassSubject.ExtraField2 = "";
            //            sTD_ClassSubject.ExtraField3 = "";
            //            sTD_ClassSubject.ExtraField4 = "";
            //            sTD_ClassSubject.ExtraField5 = "";
            //            sTD_ClassSubject.AddedBy = Profile.card_id;
            //            sTD_ClassSubject.AddedDate = DateTime.Now;
            //            sTD_ClassSubject.UpdatedBy = Profile.card_id;
            //            sTD_ClassSubject.UpdateDate = DateTime.Now;
            //            int resutl = STD_ClassSubjectManager.InsertSTD_ClassSubject(sTD_ClassSubject);
            //        }
            //    }
            //}

           
        }
        catch (Exception ex) { }

        Response.Redirect("ClassSubjectAddTeacher.aspx?ID=" + ddlClassID.SelectedValue); //loadGrid();
    }

    private string getSubjectID()
    {
        string subjectIDs = "";

        foreach (GridViewRow gr in gvSubject.Rows)
        {
            CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");

            HiddenField hfSubjectID = (HiddenField)gr.FindControl("hfSubjectID");

            if (chkSelect.Checked)
            {
                if (subjectIDs == "") subjectIDs = hfSubjectID.Value;
                else subjectIDs += "," + hfSubjectID.Value;
            }
        }

        return subjectIDs;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //delete all the rows for the
            STD_ClassSubjectManager.DeleteSTD_ClassSubjectByClassID(int.Parse(ddlClassID.SelectedValue));

            string ids = getSubjectID();
            if (ids != "")
            {
                string[] words = ids.Split(',');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject();
                        sTD_ClassSubject.ClassSubjectName = ddlClassID.SelectedItem.Text ;
                        sTD_ClassSubject.SubjectID = int.Parse(word);
                        sTD_ClassSubject.ClassID = int.Parse(ddlClassID.SelectedValue);
                        sTD_ClassSubject.AddedBy = Profile.card_id;
                        sTD_ClassSubject.AddedDate = DateTime.Now;
                        sTD_ClassSubject.UpdatedBy = Profile.card_id;
                        sTD_ClassSubject.UpdateDate = DateTime.Now;
                        int resutl = STD_ClassSubjectManager.InsertSTD_ClassSubject(sTD_ClassSubject);
                    }
                }
            }
        }
        catch (Exception ex) { }
        Response.Redirect("ClassSubjectAddTeacher.aspx?ID=" + ddlClassID.SelectedValue); //loadGrid();
        btnUpdate.Visible = false;
    }
    private void showSTD_ClassSubjectData()
    {
        ddlClassID.SelectedValue = Request.QueryString["ID"];

        //STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject();
        //sTD_ClassSubject = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassSubjectID(Int32.Parse(Request.QueryString["ID"]));
        ////ddlSubjectID.SelectedValue = sTD_ClassSubject.SubjectID.ToString();
        //ddlClassID.SelectedValue = sTD_ClassSubject.ClassID.ToString();
        SubjectIDLoad(STD_ClassManager.GetSTD_ClassByClassID(int.Parse(ddlClassID.SelectedItem.Value)).CourseID);
    }

    private void SubjectIDLoad(int courseID)
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_SubjectEnrollment(courseID);
            ds.Tables[0].Columns.Add("IsChecked", typeof(bool));
            ds.Tables[0].Columns.Add("ExtraField1", typeof(String));
            ds.Tables[0].Columns.Add("ExtraField2", typeof(String));
            ds.Tables[0].Columns.Add("ClassSubjectID", typeof(int));
            ds.Tables[0].Columns.Add("IsHistory", typeof(bool));
            ds.Tables[0].Columns.Add("IsNotHistory", typeof(bool));

            if(ds==null)return;

            if (ds.Tables[0].Rows.Count == 0)
            {
                a_AddSubjectToAddCourse.Visible = true;
                a_AddSubjectToAddCourse.HRef += hfCourseID.Value;
                gvSubject.Visible = false;
                return;
            }

            List<STD_ClassSubject> sTD_ClassSubject = new List<STD_ClassSubject>();

            sTD_ClassSubject = STD_ClassSubjectManager.GetSTD_ClassByClassID(int.Parse(ddlClassID.SelectedItem.Value));
            
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                gvSubject.Visible = true;
                dr["IsChecked"] = false;
                dr["ClassSubjectID"] = 0;
                dr["IsHistory"] = false;
                dr["IsNotHistory"] = true;
                foreach(STD_ClassSubject classSubuject in sTD_ClassSubject)
                {
                    if (classSubuject.SubjectID.ToString() == dr["SubjectID"].ToString())
                    {
                        if (classSubuject.RowStatusID == 1)
                        {
                            dr["IsChecked"] = true;
                        }
                        else
                        {
                            dr["IsChecked"] = false;
                            dr["IsHistory"] = true;
                            dr["IsNotHistory"] = false;
                        }
                        
                        dr["ClassSubjectID"] = classSubuject.ClassSubjectID;
                        dr["ExtraField1"] = classSubuject.ExtraField1;
                        dr["ExtraField2"] = classSubuject.ExtraField2;
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
    

    protected void productsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblClassID=(Label)e.Row.FindControl("lblClassID");

            GridView gvSubjects = (GridView)e.Row.FindControl("gvSubjects");
            gvSubjects.DataSource = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassID(int.Parse(lblClassID.Text), true);
            gvSubjects.DataBind();
        }
    }

    protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedIndex != 0)
        {
            gvSubject.Visible = true;
            STD_Class stdClass = STD_ClassManager.GetSTD_ClassByClassID(int.Parse(ddlClassID.SelectedItem.Value));
            hfCourseID.Value = stdClass.CourseID.ToString();
            if (stdClass.RowStatusID != 1)
            {
                btnAdd.Enabled = false;
                btnAdd.Text = "This Class is Completed, you can not save";
            }
            else
            {
                btnAdd.Enabled = true;
                btnAdd.Text = "Save";
            }
            SubjectIDLoad(int.Parse(hfCourseID.Value));
        }
        else
        {
            gvSubject.Visible = false;
        }
    }
    #endregion

    protected void btnCloseSubject_Click(object sender, EventArgs e)
    {
        Button btnClose = new Button();
        btnClose = (Button)sender;
        int classSubjectID;
        classSubjectID = Convert.ToInt32(btnClose.CommandArgument);

        STD_ClassSubjectManager.CloseSTD_ClassSubject(classSubjectID,Profile.card_id);

        ddlClassID_SelectedIndexChanged(this,new EventArgs());
    }

    protected void btnUndoClose_Click(object sender, EventArgs e)
    {
        Button btnClose = new Button();
        btnClose = (Button)sender;
        int classSubjectID;
        classSubjectID = Convert.ToInt32(btnClose.CommandArgument);

        STD_ClassSubjectManager.UndoCloseSTD_ClassSubject(classSubjectID, Profile.card_id);

        ddlClassID_SelectedIndexChanged(this, new EventArgs());
    }

    #region Class
    private void loadGrid()
    {
        STD_ClassManager.LoadSTD_ClassPageByClass(gvSTD_Class, rptPager, 1, ddlPageSize);
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_ClassManager.LoadSTD_ClassPageByClass(gvSTD_Class, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_ClassManager.LoadSTD_ClassPageByClass(gvSTD_Class, rptPager, pageIndex, ddlPageSize);
    }

    protected void lbSelectClass_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("ClassSubjectAdd.aspx?ID=" + id);
    }
    protected void lbDeleteClass_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = STD_ClassManager.DeleteSTD_Class(Convert.ToInt32(linkButton.CommandArgument));
        //STD_ClassManager.LoadSTD_ClassPage(gvSTD_Class, rptPager, 1, ddlPageSize);
    }
    #endregion
    protected void chkClosedClasses_CheckedChanged(object sender, EventArgs e)
    {
        ClassIDLoad();
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
}

