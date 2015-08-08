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

public partial class AdminAttendenceInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadUser();
            if (Request.QueryString["attendenceID"] != null)
            {
                int attendenceID = Int32.Parse(Request.QueryString["attendenceID"]);
                if (attendenceID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showAttendenceData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Attendence attendence = new Attendence();

        attendence.UserID = Int32.Parse(ddlUser.SelectedValue);
        attendence.InOutTime = txtInOutTime.Text;
        attendence.ExtraField1 = txtExtraField1.Text;
        attendence.ExtraFileld2 = txtExtraFileld2.Text;
        int resutl = AttendenceManager.InsertAttendence(attendence);
        Response.Redirect("AdminAttendenceDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Attendence attendence = new Attendence();
        attendence = AttendenceManager.GetAttendenceByID(Int32.Parse(Request.QueryString["attendenceID"]));
        Attendence tempAttendence = new Attendence();
        tempAttendence.AttendenceID = attendence.AttendenceID;

        tempAttendence.UserID = Int32.Parse(ddlUser.SelectedValue);
        tempAttendence.InOutTime = txtInOutTime.Text;
        tempAttendence.ExtraField1 = txtExtraField1.Text;
        tempAttendence.ExtraFileld2 = txtExtraFileld2.Text;
        bool result = AttendenceManager.UpdateAttendence(tempAttendence);
        Response.Redirect("AdminAttendenceDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlUser.SelectedIndex = 0;
        txtInOutTime.Text = "";
        txtExtraField1.Text = "";
        txtExtraFileld2.Text = "";
    }
    private void showAttendenceData()
    {
        Attendence attendence = new Attendence();
        attendence = AttendenceManager.GetAttendenceByID(Int32.Parse(Request.QueryString["attendenceID"]));

        ddlUser.SelectedValue = attendence.UserID.ToString();
        txtInOutTime.Text = attendence.InOutTime;
        txtExtraField1.Text = attendence.ExtraField1;
        txtExtraFileld2.Text = attendence.ExtraFileld2;
    }
    private void loadUser()
    {
        ListItem li = new ListItem("Select User...", "0");
        ddlUser.Items.Add(li);

        List<User> users = new List<User>();
        users = UserManager.GetAllUsers();
        foreach (User user in users)
        {
            ListItem item = new ListItem(user.UserName.ToString(), user.UserID.ToString());
            ddlUser.Items.Add(item);
        }
    }
}
