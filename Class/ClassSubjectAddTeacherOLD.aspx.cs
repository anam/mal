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
    #region ClassSubject

    protected void gvSubject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            gvSubject.Visible = true;

            HiddenField hfSubjectID = (HiddenField)e.Row.FindControl("hfSubjectID");
            HiddenField hfClassSubjectID = (HiddenField)e.Row.FindControl("hfClassSubjectID");

            DropDownList ddlTeacherID = (DropDownList)e.Row.FindControl("ddlTeacherID");
            foreach (ListItem li in ddlTeacher.Items)
            {
                ddlTeacherID.Items.Add(new ListItem(li.Text,li.Value));
            }

            ddlTeacherID.SelectedIndex = 0;
            
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
                                ddlTeacherID.SelectedValue = dr["EmployeeID"].ToString();
                                break;
                            }
                        }
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

            if (chkSelect.Checked && ddlTeacherID.SelectedValue != "0")
            {
                if (subjectIDs == "") subjectIDs = ddlTeacherID.SelectedValue + " " + hfClassSubjectID.Value;
                else subjectIDs += "," + ddlTeacherID.SelectedValue + " " + hfClassSubjectID.Value;
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
            DataSet ds = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassID(int.Parse(ddlClassID.SelectedValue),true);
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
            DataSet ds = STD_ClassManager.GetDropDownListAllSTD_Class();
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
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlTeacher.DataValueField = "EmployeeID";
            ddlTeacher.DataTextField = "EmployeeNameNo";
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

