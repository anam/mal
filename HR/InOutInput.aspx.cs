using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_InOutInput : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadEmployee();

            

        }
    }

    private void loadEmployee()
    {
        DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();

        ListItem li = new ListItem("Select Employee...", "0");
        ddlAccountingUser.Items.Add(li);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (bool.Parse(dr["Flag"].ToString()) == true)
            {
                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeID"].ToString());
                ddlAccountingUser.Items.Add(item);
            }
        }

        ddlAccountingUser.SelectedValue = Profile.card_id;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Attendence attendence = new Attendence();

        attendence.UserID = ddlAccountingUser.SelectedValue;
        attendence.InOutTime = DateTime.Parse(txtInOutTime.Text);
        attendence.ExtraField1 = "";
        attendence.ExtraFileld2 = "";
        int resutl = AttendenceManager.InsertAttendence(attendence);
    }
}