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
 

public partial class AdminDisplaySTD_ClassSubjectTeacher : System.Web.UI.Page
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
                showSTD_ClassSubjectTeacherData();
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
            STD_ClassSubjectEmployeeManager.DeleteSTD_ClassSubjectEmployeeByClassSubjectID(int.Parse(ddlClassSubjectID.SelectedValue));

            string ids=getSubjectID();
            if (ids != "")
            {
                string[] words = ids.Split(',');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee();
                        //	sTD_ClassSubjectEmployee.ClassSubjectEmployeeID=  int.Parse(ddlClassSubjectEmployeeID.SelectedValue);
                        sTD_ClassSubjectEmployee.ClassSubjectEmployeeName = "Need to fix later";
                        sTD_ClassSubjectEmployee.EmployeeID = word;
                        sTD_ClassSubjectEmployee.ClassSubjectID = int.Parse(ddlClassSubjectID.SelectedValue);
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
        
        loadGrid();
    }

    private string getSubjectID()
    {
        string employeeIDs = "";

        foreach (GridViewRow gr in gvSubject.Rows)
        {
            CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");

            HiddenField hfEmployeeID = (HiddenField)gr.FindControl("hfEmployeeID");
            HiddenField hfClassSubjectID = (HiddenField)gr.FindControl("hfClassSubjectID");

            if (chkSelect.Checked)
            {
                if (employeeIDs == "") employeeIDs = hfEmployeeID.Value + " " + hfClassSubjectID.Value;
                else employeeIDs += "," + hfEmployeeID.Value + " " + hfClassSubjectID.Value;
            }
        }

        return employeeIDs;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //delete all the rows for the
            STD_ClassSubjectEmployeeManager.DeleteSTD_ClassSubjectEmployeeByClassSubjectID(int.Parse(ddlClassSubjectID.SelectedValue));

            string ids = getSubjectID();
            if (ids != "")
            {
                string[] words = ids.Split(',');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee();
                        //	sTD_ClassSubjectEmployee.ClassSubjectEmployeeID=  int.Parse(ddlClassSubjectEmployeeID.SelectedValue);
                        sTD_ClassSubjectEmployee.ClassSubjectEmployeeName = "Need to fix later";
                        sTD_ClassSubjectEmployee.EmployeeID = word;
                        sTD_ClassSubjectEmployee.ClassSubjectID = int.Parse(ddlClassSubjectID.SelectedValue);
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
        loadGrid();
        btnUpdate.Visible = false;
    }
    private void showSTD_ClassSubjectTeacherData()
    {
        ddlClassSubjectID.SelectedValue = Request.QueryString["ID"];
        SubjectIDLoad(Int32.Parse(Request.QueryString["ID"]));
    }

    private void SubjectIDLoad(int classSubjectID)
    {
        try
        {
            DataSet dsEmployee = HR_EmployeeManager.GetAllHR_Employees();
            dsEmployee.Tables[0].Columns.Add("IsChecked", typeof(bool));
            DataSet dsClassSubjectTeacher = STD_ClassSubjectEmployeeManager.GetSTD_ClassSubjectByClassSubjectID(classSubjectID,true);
            if (dsEmployee == null) return;

            foreach (DataRow drEmployee in dsEmployee.Tables[0].Rows)
            {
                drEmployee["IsChecked"] = false;
                foreach (DataRow drClassSubjectTeacher in dsClassSubjectTeacher.Tables[0].Rows)
                {
                    if (drClassSubjectTeacher["EmployeeID"].ToString() == drEmployee["EmployeeID"].ToString())
                    {
                        drEmployee["IsChecked"] = true;
                        break;
                    }
                }
            }

            gvSubject.DataSource = dsEmployee.Tables[0];
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

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["ClassName"].ToString() + " -> " + dr["SubjectName"].ToString(), dr["ClassSubjectID"].ToString());
                ddlClassSubjectID.Items.Add(item);
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
            gvSubjects.DataSource = STD_ClassSubjectManager.GetSTD_ClassSubjectEmployeeByClassID(int.Parse(lblClassID.Text),true);
            gvSubjects.DataBind();
        }
    }

    protected void ddlClassSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassSubjectID.SelectedIndex != 0)
        {
            SubjectIDLoad(int.Parse(ddlClassSubjectID.SelectedValue));
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
        Response.Redirect("ClassSubjectTeacherAdd.aspx?ID=" + id);
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

