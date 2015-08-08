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
            
            loadEmployee();
            showAttendenceGrid();
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
        string date = "";
        if (txtDate.Text != date)
        {
            date = " (InOutTime >= '" + DateTime.Parse(txtDate.Text).ToString("yyyy-MM-dd") + " 00:00:00' and InOutTime <= '" + DateTime.Parse(txtDate.Text).ToString("yyyy-MM-dd") + " 23:59:00')";
        }

        attendences = AttendenceManager.GetAllAttendencesByUserIDnDate(ddlEmployee.SelectedValue == "0" ? "" : "'"+ddlEmployee.SelectedValue+"'", date);

        List<List<Attendence>> attendenceList = new List<List<Attendence>>();
        List<Attendence> attendenceListIeam = new List<Attendence>();
        string lastUesrID = "";
        int counter = 0;
        foreach (Attendence item in attendences)
        {
            if (lastUesrID == "") lastUesrID = item.UserID;

            if (lastUesrID == item.UserID)
            {
                attendenceListIeam.Add(item);
            }
            else
            {
                lastUesrID = item.UserID;
                attendenceList.Add(attendenceListIeam);
                attendenceListIeam = new List<Attendence>();
                attendenceListIeam.Add(item);
            }

            counter++;
            if (counter == attendences.Count)
            {
                attendenceList.Add(attendenceListIeam);
            }
        }

        List<Attendence> finalList = new List<Attendence>();

        //foreach (List<Attendence> item in attendenceList)
        {
            attendences = new List<Attendence>();
            foreach (List<Attendence> item in attendenceList)
            {
                attendencesTimeDuration = new List<Attendence>();
                attendences = new List<Attendence>();
                attendences = item;
            //attendences = attendenceList[1];

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
                newItem.DefaultTimeTextBoxVisible = false;
                newItem.DefaultTimeLabelVisible = true;
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
                                newItem.DefaultTimeTextBoxVisible = true;
                                newItem.DefaultTimeLabelVisible = false;
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


                if (newItem.OutTime < DateTime.Parse("21 Feb 2012"))
                {
                    newItem.OutTime = DateTime.Parse(newItem.InTime.ToShortDateString() + " 06:00:00 PM");
                    newItem.DefaultTimeTextBoxVisible = true;
                    newItem.DefaultTimeLabelVisible = false;
                }

                newItem.Duration = (newItem.OutTime.Subtract(newItem.InTime).Hours * 60 * 60) + (newItem.OutTime.Subtract(newItem.InTime).Minutes * 60) + newItem.OutTime.Subtract(newItem.InTime).Seconds;
                //newItem.DurationDisplay = (newItem.OutTime - newItem.InTime).Hours.ToString() + " hour(s) : " + (newItem.OutTime - newItem.InTime).Minutes.ToString() + " Min(s)";
                newItem.DurationDisplay = ((newItem.OutTime.Subtract(newItem.InTime).Days * 24) + (newItem.OutTime.Subtract(newItem.InTime).Hours)).ToString() + " : " + newItem.OutTime.Subtract(newItem.InTime).Minutes.ToString() ;
                attendencesTimeDuration.Add(newItem);
            }


            //gvAttendencePerEmployee.DataSource = attendences;
            //gvAttendencePerEmployee.DataBind();

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
                    attendencesTimeDuration[i].UserNameDisplay = attendencesTimeDuration[i].UserName;
                    attendencesTimeDuration[i].UserIDDisplay = attendencesTimeDuration[i].UserID;
                    attendencesTimeDuration[i].TotalDuratinDisplay =  (attendencesTimeDuration[i].Duration / (60 * 60)).ToString() + " : " + ((attendencesTimeDuration[i].Duration % (60 * 60)) / 60).ToString() ;
                }
            }

            foreach (Attendence itemChild in attendencesTimeDuration)
            {
                finalList.Add(itemChild);
            }
            }


            gvAttendenceDuration.DataSource = finalList;
            gvAttendenceDuration.DataBind();

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in gvAttendenceDuration.Rows)
        {
            TextBox txtOutTime = (TextBox)gr.FindControl("txtOutTime");
            if (txtOutTime.Visible && txtOutTime.Text != "")
            {
                Attendence attendence = new Attendence();

                attendence.UserID = ((HiddenField)gr.FindControl("hfUserID")).Value;
                attendence.InOutTime = DateTime.Parse( ((HiddenField)gr.FindControl("hfUserID")).Value + " " + txtOutTime.Text);
                AttendenceManager.InsertAttendence(attendence);

            }
        }
        btnViewReport_Click(this, new EventArgs());
    }
}

