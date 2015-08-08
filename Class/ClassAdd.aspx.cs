using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Class_ClassAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loadSTD_ClassData();
            CourseIDLoad();
            ClassTypeIDLoad();
            ClassStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showSTD_ClassData();

                if (ddlClassStatusID.SelectedValue == "2")
                    pnClassStatus.Visible = true;
                else
                    pnClassStatus.Visible = false;
            }
            loadGrid();
        }
    }

    private void loadGrid()
    {
        STD_ClassManager.LoadSTD_ClassPageSearch(gvSTD_Class, rptPager, 1, ddlPageSize,txtClassForSearch.Text);
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_ClassManager.LoadSTD_ClassPageSearch(gvSTD_Class, rptPager, 1, ddlPageSize, txtClassForSearch.Text);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_ClassManager.LoadSTD_ClassPageSearch(gvSTD_Class, rptPager, pageIndex, ddlPageSize,txtClassForSearch.Text);
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("ClassAdd.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = STD_ClassManager.DeleteSTD_Class(Convert.ToInt32(linkButton.CommandArgument));
        STD_ClassManager.LoadSTD_ClassPageSearch(gvSTD_Class, rptPager, 1, ddlPageSize, txtClassForSearch.Text);
    }

    protected void lbClose_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = STD_ClassManager.HistorySTD_Class(Convert.ToInt32(linkButton.CommandArgument),Profile.card_id);
        STD_ClassManager.LoadSTD_ClassPageSearch(gvSTD_Class, rptPager, 1, ddlPageSize,  txtClassForSearch.Text);
    }

    protected void lbUndoClose_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = STD_ClassManager.UndoCloseSTD_Class(Convert.ToInt32(linkButton.CommandArgument), Profile.card_id);
        STD_ClassManager.LoadSTD_ClassPageSearch(gvSTD_Class, rptPager, 1, ddlPageSize, txtClassForSearch.Text);
    }

    private void CourseIDLoad()
    {
        try
        {
            DataSet ds = STD_CourseManager.GetDropDownListAllSTD_Course();
            ddlCourseID.DataValueField = "CourseID";
            ddlCourseID.DataTextField = "CourseName";
            ddlCourseID.DataSource = ds.Tables[0];
            ddlCourseID.DataBind();
            ddlCourseID.Items.Insert(0, new ListItem("Select Course >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int resutl = 0;
        try
        {
            STD_Class sTD_Class = new STD_Class();
            //	sTD_Class.ClassID=  int.Parse(ddlClassID.SelectedValue);
            sTD_Class.ClassName = txtClassName.Text;
            sTD_Class.CourseID = int.Parse(ddlCourseID.SelectedValue);
            sTD_Class.ClassTypeID = int.Parse(ddlClassTypeID.SelectedValue);
            sTD_Class.ClassStatusID = int.Parse(ddlClassStatusID.SelectedValue);
            sTD_Class.AddedBy = Profile.card_id;

            if (txtStartDate.Text != "")
                sTD_Class.AddedDate = DateTime.Parse(txtStartDate.Text);
            else
                sTD_Class.AddedDate = DateTime.Now;

            sTD_Class.UpdatedBy = Profile.card_id;
            sTD_Class.UpdateDate = DateTime.Now;
            resutl = STD_ClassManager.InsertSTD_Class(sTD_Class);
        }
        catch (Exception ex) { }
        Response.Redirect("ClassSubjectAdd.aspx?ID=" + resutl.ToString()); //loadGrid();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_Class sTD_Class = new STD_Class();
            sTD_Class.ClassID = int.Parse(Request.QueryString["ID"].ToString());
            sTD_Class.CourseID = int.Parse(ddlCourseID.SelectedValue);
            sTD_Class.ClassName = txtClassName.Text;
            sTD_Class.ClassTypeID = int.Parse(ddlClassTypeID.SelectedValue);
            sTD_Class.ClassStatusID = int.Parse(ddlClassStatusID.SelectedValue);
            sTD_Class.AddedBy = Profile.card_id;

            if (txtStartDate.Text != "")
                sTD_Class.AddedDate = DateTime.Parse(txtStartDate.Text);
            else
                sTD_Class.AddedDate = DateTime.Now;

            sTD_Class.UpdatedBy = Profile.card_id;
            sTD_Class.UpdateDate = DateTime.Now;
            bool resutl = STD_ClassManager.UpdateSTD_Class(sTD_Class);
        }
        catch (Exception ex) { }
        Response.Redirect("ClassSubjectAdd.aspx?ID=" + Request.QueryString["ID"].ToString()); //loadGrid();
    }
    private void showSTD_ClassData()
    {
        STD_Class sTD_Class = new STD_Class();
        sTD_Class = STD_ClassManager.GetSTD_ClassByClassID(Int32.Parse(Request.QueryString["ID"]));
        txtClassName.Text = sTD_Class.ClassName.ToString();
        ddlCourseID.SelectedValue = sTD_Class.CourseID.ToString();
        ddlClassTypeID.SelectedValue = sTD_Class.ClassTypeID.ToString();
        ddlClassStatusID.SelectedValue = sTD_Class.ClassStatusID.ToString();

        if (ddlClassStatusID.SelectedValue == "2")
            txtStartDate.Text = sTD_Class.AddedDate.ToString("dd MMM, yyyy");        

    }

    private void ClassTypeIDLoad()
    {
        try
        {
            DataSet ds = STD_ClassTypeManager.GetDropDownListAllSTD_ClassType();
            ddlClassTypeID.DataValueField = "ClassTypeID";
            ddlClassTypeID.DataTextField = "ClassTypeName";
            ddlClassTypeID.DataSource = ds.Tables[0];
            ddlClassTypeID.DataBind();
            ddlClassTypeID.Items.Insert(0, new ListItem("Select ClassType >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void ClassStatusIDLoad()
    {
        try
        {
            DataSet ds = STD_ClassStatusManager.GetDropDownListAllSTD_ClassStatus();
            ddlClassStatusID.DataValueField = "ClassStatusID";
            ddlClassStatusID.DataTextField = "ClassStatusName";
            ddlClassStatusID.DataSource = ds.Tables[0];
            ddlClassStatusID.DataBind();
            ddlClassStatusID.Items.Insert(0, new ListItem("Select ClassStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void ddlClassStatusID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassStatusID.SelectedValue == "2")
            pnClassStatus.Visible = true;
        else
            pnClassStatus.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadGrid();
    }
}