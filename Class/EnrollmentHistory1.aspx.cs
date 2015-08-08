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
                showSTD_ClassSubjectData();
            }
            loadGrid();
        }
    }

    protected void btnVarify_OnClick(object sender, EventArgs e)
    {


        STD_Student student = new STD_Student();
        student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text);

        if (student == null)
        {
            lblMessage.Text = "<br/>There is no Student with this student Id";
            return;
        }
        else
        {
            lblMessage.Text = "!!! Valid ID  !!!";
            hfStudentID.Value = student.StudentID;
            StudentCodeVarification(student);
        }


    }

    private bool StudentCodeVarification(STD_Student students)
    {
        // = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text.Trim());
        if (students != null)
        {
            pnStudentDetails.Visible = true;
            lblName.Text = students.StudentName;
            lblContact.Text = students.Mobile;
            imgStudent.ImageUrl = students.PPSizePhoto;

            hfStudentID.Value = students.StudentID;
            lblMessage.Text = "<br/>Student Code is Exist. <a target='_blank' style='color:blue;' href='../Student/AdminDetailsSTD_Student.aspx?ID=" + students.StudentID + "'>Click here for Details</a>";
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is Exist')", true);
            return true;
        }
        else
        {
            lblMessage.Text = "S<br/>tudent Code is not Exist";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is not Exist')", true);
        }
        return false;
    }
    #region ClassSubject
    
    
    
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

    #endregion

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
}

