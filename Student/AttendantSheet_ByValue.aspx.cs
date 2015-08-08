using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Student_AttendantSheet_ByValue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClassIDLoad();
            //SubjectIDLoad();
            //EmployeeIDLoad();          
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

   
    protected void ddlClassID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedValue != null)
        {
            int ClassID = int.Parse(ddlClassID.SelectedValue);
            SubjectIDLoad(ClassID);
           
        }
    }

    private void SubjectIDLoad()
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_Subject();
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void SubjectIDLoad(int ClassID)
    {
        try
        {
            ddlSubjectID.Items.Clear();

            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_SubjectByClassID(ClassID);

            ListItem li = new ListItem("Select Subject >>", "0");
            ddlSubjectID.Items.Add(li);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["SubjectName"].ToString() + " (" + dr["NoOfStudents"].ToString() + " Students)", dr["SubjectID"].ToString());
                ddlSubjectID.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

   
    private void EmployeeIDLoad()
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
            //ddlEmployeeID.Items.Insert(0, new ListItem("Mehdi Sir", "96b72550-3649-45c6-a1f5-0474a77f4fa5"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedValue != null)
        {
            int ClassID = int.Parse(ddlClassID.SelectedValue);
            int SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            EmployeeIDLoadByClassID(ClassID, SubjectID);
        }
    }

    private void EmployeeIDLoadByClassID(int ClassID, int SubjectID)
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_EmployeClassID(ClassID, SubjectID);
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
            //ddlEmployeeID.Items.Insert(0, new ListItem("Mehdi Sir", "96b72550-3649-45c6-a1f5-0474a77f4fa5"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnShowAttendant_Click(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedIndex != 0 && ddlSubjectID.SelectedIndex != 0 && ddlEmployeeID.SelectedIndex != 0)
        {
            Response.Redirect("AttendantSheet.aspx?classID=" + ddlClassID.SelectedValue + "&subjectID=" + ddlSubjectID.SelectedValue + "&employeeID=" + ddlEmployeeID.SelectedValue);
        }
    }
}