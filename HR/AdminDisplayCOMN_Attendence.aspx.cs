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


public partial class AdminDisplayHR_Employee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEmployeeType();
            LoadDepartment();
            DesignationIDLoad();
            //string[] totalItems = totalItem.Split('.');
            //lblGrandTotalEmployee.Text = "Total : " + totalItems[0];

            loadEmployee();
            showAttendenceGrid();
        }
    }

    private void LoadEmployeeType()
    {
        DataSet ds = HR_EmployerTypeManager.GetDropDownListAllHR_EmployerType();
        ddlEmployeeTypeSer.DataValueField = "EmployerType";
        ddlEmployeeTypeSer.DataTextField = "EmployerTypeName";
        ddlEmployeeTypeSer.DataSource = ds.Tables[0];
        ddlEmployeeTypeSer.DataBind();
        ddlEmployeeTypeSer.Items.Insert(0, new ListItem("All Type >>", "0"));
    }

    private void LoadDepartment()
    {
        DataSet allDepartment = HR_DepartmentManager.GetDropDownListAllHR_Department();
        ddlDepartment.DataValueField = "DepartmentID";
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataSource = allDepartment.Tables[0];
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, new ListItem("All Department >>", "0"));
    }

    private void DesignationIDLoad()
    {
        try
        {
            DataSet ds = HR_DesignationManager.GetDropDownListAllHR_Designation();
            ddlDesignationNameSer.DataValueField = "DesignationID";
            ddlDesignationNameSer.DataTextField = "DesignationName";
            ddlDesignationNameSer.DataSource = ds.Tables[0];
            ddlDesignationNameSer.DataBind();
            ddlDesignationNameSer.Items.Insert(0, new ListItem("All Designation >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void DesignationIDLoad(int departmentNo)
    {
        try
        {
            DataSet ds = HR_DesignationManager.GetHR_DesignationByDepartmentID(departmentNo);
            ddlDesignationNameSer.DataValueField = "DesignationID";
            ddlDesignationNameSer.DataTextField = "DesignationName";
            ddlDesignationNameSer.DataSource = ds.Tables[0];
            ddlDesignationNameSer.DataBind();
            ddlDesignationNameSer.Items.Insert(0, new ListItem("All Designation >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void ddlDepartment_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlDepartment.SelectedValue) > 0)
        {
            DesignationIDLoad(Convert.ToInt32(ddlDepartment.SelectedValue));
        }
        else
        {
            DesignationIDLoad();
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHR_Employee.aspx?ID=0");
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        string id;
        id = linkButton.CommandArgument;
        Response.Redirect("AdminHR_Employee.aspx?ID=" + id);
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        
    }

    protected void gvHR_Employee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblimagename = (Label)e.Row.FindControl("lblPhoto");

            Image imgphoto = (Image)e.Row.FindControl("imgPhoto");

            if (lblimagename.Text.Trim() == string.Empty)
            {
                imgphoto.ImageUrl = String.Format("~/App_Themes/CoffeyGreen/images/NoImage.jpg");
            }
            else
            {
                imgphoto.ImageUrl = "~/HR/upload/employeer/" + lblimagename.Text;
            }
            
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            if (lblStatus.Text.Trim() != string.Empty)
            {
                if (lblStatus.Text.Trim().Equals("True"))
                {
                    lblStatus.Text = "Active";
                }
                else
                {
                    lblStatus.Text = "Left";
                }
            }

            //string str = Server.MapPath(imgphoto.ImageUrl);
        }
    }

    protected void chkAllEmployee_OnCheckedChanged(object sender, EventArgs e)
    {
        
    }

    protected void btnStatistic_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlDepartment.SelectedValue) > 0)
        {
            HR_Department department = HR_DepartmentManager.GetHR_DepartmentByDepartmentID(Convert.ToInt32(ddlDepartment.SelectedValue));
            if (department != null)
            {
                lblDepartmentName.Text = "Department Name : " + department.DepartmentName;
                departmentID.Value = department.DepartmentID.ToString();
            }
        }
        else
        {
            lblDepartmentName.Text = "All Department Information";
            departmentID.Value = "0";
        }

        DataSet empStatisticDataSet = HR_EmployeeManager.GetHR_EmployeeStatisticDepartWise(Convert.ToInt32(ddlDepartment.SelectedValue));
        int totalEmp = 0;
        foreach (DataRow row in empStatisticDataSet.Tables[0].Rows)
        {
            totalEmp += Convert.ToInt32(row["TotalEmployee"]);
        }
        lblTotalDesignation.Text = "Total Designation : " + empStatisticDataSet.Tables[0].Rows.Count.ToString();
        lblTotalEmployee.Text = "Total Employee : " + totalEmp.ToString();
        gvStatisticOfEmp.DataSource = empStatisticDataSet.Tables[0];
        gvStatisticOfEmp.DataBind();

        divStatistic.Visible = true;
    }

    protected void btnHideStatistic_Click(object sender, EventArgs e)
    {
        divStatistic.Visible = false;
    }

    protected void btnEmpIDCard_Click(object sender, EventArgs e)
    {
        //
        Response.Redirect("~/idCardPage.aspx?DepartID=" + departmentID.Value);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchOption();
        ////updatePanel.Update();
    }

    private void SearchOption()
    {
    }

    private void loadEmployee()
    {
        DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();

        ListItem li = new ListItem("Select Employee...", "0");
        ddlAccountingUser.Items.Add(li);
        ddlEmployee.Items.Add(li);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (bool.Parse(dr["Flag"].ToString()) == true)
            {
                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeNo"].ToString());
                ddlAccountingUser.Items.Add(item);
            }
        }

        ddlAccountingUser.SelectedValue = Profile.card_id;

        
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (bool.Parse(dr["Flag"].ToString()) == true)
            {
                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeNo"].ToString());
                ddlEmployee.Items.Add(item);
            }
        }

        ddlAccountingUser.SelectedValue = Profile.card_id;
        ddlEmployee.SelectedValue = Profile.card_id;


        txtInOutTime.Text= DateTime.Now.ToString();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Attendence attendence = new Attendence();

        attendence.UserID = ddlAccountingUser.SelectedValue;
        attendence.InOutTime = DateTime.Parse(txtInOutTime.Text);
        int resutl = AttendenceManager.InsertAttendence(attendence);

        showAttendenceGrid();
        btnViewReport_Click(this, new EventArgs());
    }

    private void showAttendenceGrid()
    {
        //gvAttendence.DataSource = AttendenceManager.GetAllAttendences();
        //gvAttendence.DataBind();
    }

    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        List<Attendence> attendences = new List<Attendence>();

        
        List<Attendence> attendencesTimeDuration = new List<Attendence>();
        attendences = AttendenceManager.GetAllAttendencesByUserID(ddlEmployee.SelectedValue);

        for (int i = 1; i < attendences.Count; i++)
        {
            if (((attendences[i].InOutTime.Subtract(attendences[i - 1].InOutTime).Days * 24 * 60) + (attendences[i].InOutTime.Subtract(attendences[i - 1].InOutTime).Hours * 60) + attendences[i].InOutTime.Subtract(attendences[i - 1].InOutTime).Minutes) < 1)
            {
                attendences.RemoveAt(i);
                i--;
            }
        }


        for (int i = 0; i < attendences.Count; i++)
        {
            Attendence newItem = new Attendence();
            newItem = attendences[i];
            newItem.InTime = attendences[i].InOutTime;
            while (true)
            {
                if (attendences.Count > ++i)
                {
                    if (((attendences[i].InOutTime.Subtract(newItem.InTime).Days * 24 * 60) + (attendences[i].InOutTime.Subtract(newItem.InTime).Hours * 60) + attendences[i].InOutTime.Subtract(newItem.InTime).Minutes) > 1)
                    {
                        if (newItem.InTime.Date == attendences[i].InOutTime.Date)
                        {
                            newItem.OutTime = attendences[i].InOutTime;
                        }
                        else
                        {
                            newItem.OutTime = DateTime.Parse(newItem.InTime.ToShortDateString() + " 06:00:00 PM");
                            i--;
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            if (newItem.OutTime < DateTime.Parse("21 Feb 2012")) newItem.OutTime = DateTime.Parse(newItem.InTime.ToShortDateString() + " 06:00:00 PM");
            newItem.Duration = (newItem.OutTime.Subtract(newItem.InTime).Hours * 60 * 60) + (newItem.OutTime.Subtract(newItem.InTime).Minutes * 60) +newItem.OutTime.Subtract(newItem.InTime).Seconds;
            //newItem.DurationDisplay = (newItem.OutTime - newItem.InTime).Hours.ToString() + " hour(s) : " + (newItem.OutTime - newItem.InTime).Minutes.ToString() + " Min(s)";
            newItem.DurationDisplay = ((newItem.OutTime.Subtract(newItem.InTime).Days * 24 ) + (newItem.OutTime.Subtract(newItem.InTime).Hours)).ToString() +" hour(s)  " + newItem.OutTime.Subtract(newItem.InTime).Minutes.ToString() + " Min";
            attendencesTimeDuration.Add(newItem);
        }

        
        gvAttendencePerEmployee.DataSource = attendences;
        gvAttendencePerEmployee.DataBind();

        int lastLateDuration = attendencesTimeDuration[0].Duration;
        int lastIndex = 0;
        attendencesTimeDuration[0].DateDisplay = attendencesTimeDuration[0].InTime.ToString("dd MMM yyyy");

        

        for (int i = 1; i < attendencesTimeDuration.Count; i++)
        {
            if (attendencesTimeDuration[i - 1].InTime.ToShortDateString() != attendencesTimeDuration[i].InTime.ToShortDateString())
            {
                lastIndex = i;
                attendencesTimeDuration[i].DateDisplay = attendencesTimeDuration[i].InTime.ToString("dd MMM yyyy");
                lastIndex = i;
            }
            else
            {
                attendencesTimeDuration[lastIndex].Duration += attendencesTimeDuration[i].Duration;
                attendencesTimeDuration[i].DateDisplay = "";
            }
        }

        for (int i = 0; i < attendencesTimeDuration.Count; i++)
        {
            if (attendencesTimeDuration[i].DateDisplay != "")
            {
                attendencesTimeDuration[i].DateDisplay += "-- [" + (attendencesTimeDuration[i].Duration / (60 * 60)).ToString() + " Hour(s)  " + ((attendencesTimeDuration[i].Duration % (60 * 60)) / 60).ToString() + " Min(s)]";
            }
        }


        gvAttendenceDuration.DataSource = attendencesTimeDuration;
        gvAttendenceDuration.DataBind();


    }
}

