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
 public partial class AdminHR_Overtime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadHR_OvertimeData();
         		EmployeeIDLoad();
		    //RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showHR_OvertimeData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	HR_Overtime hR_Overtime = new HR_Overtime ();
//	hR_Overtime.OverTimeID=  int.Parse(ddlOverTimeID.SelectedValue);
	hR_Overtime.EmployeeID=  ddlEmployeeID.SelectedValue;
	hR_Overtime.Date=   DateTime.Parse(txtDate.Text);
	hR_Overtime.Hours=  decimal.Parse(txtHours.Text);
	hR_Overtime.ExtraField1=  txtExtraField1.Text;
	hR_Overtime.ExtraField2=  txtExtraField2.Text;
	hR_Overtime.ExtraField3=  txtExtraField3.Text;
	hR_Overtime.ExtraField4=  txtExtraField4.Text;
	hR_Overtime.ExtraField5=  txtExtraField5.Text;
	hR_Overtime.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	hR_Overtime.AddedDate=  DateTime.Now;
	hR_Overtime.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	hR_Overtime.UpdateDate=  DateTime.Now;
    hR_Overtime.RowStatusID = 1;// int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =HR_OvertimeManager.InsertHR_Overtime(hR_Overtime);
	Response.Redirect("AdminDisplayHR_Overtime.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_Overtime hR_Overtime = new HR_Overtime ();
	hR_Overtime.OverTimeID=  int.Parse(Request.QueryString["ID"].ToString());
	hR_Overtime.EmployeeID=  ddlEmployeeID.SelectedValue;
	hR_Overtime.Date=   DateTime.Parse(txtDate.Text);
	hR_Overtime.Hours=  decimal.Parse(txtHours.Text);
	hR_Overtime.ExtraField1=  txtExtraField1.Text;
	hR_Overtime.ExtraField2=  txtExtraField2.Text;
	hR_Overtime.ExtraField3=  txtExtraField3.Text;
	hR_Overtime.ExtraField4=  txtExtraField4.Text;
	hR_Overtime.ExtraField5=  txtExtraField5.Text;
	hR_Overtime.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	hR_Overtime.AddedDate=  DateTime.Now;
	hR_Overtime.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	hR_Overtime.UpdateDate=  DateTime.Now;
    hR_Overtime.RowStatusID = 1;//int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =HR_OvertimeManager.UpdateHR_Overtime(hR_Overtime);
	Response.Redirect("AdminDisplayHR_Overtime.aspx");
	}
	private void showHR_OvertimeData()
	{
	 	HR_Overtime hR_Overtime  = new HR_Overtime ();
	 	hR_Overtime = HR_OvertimeManager.GetHR_OvertimeByOverTimeID(Int32.Parse(Request.QueryString["ID"]));
	 	//ddlEmployeeID.SelectedValue  =hR_Overtime.EmployeeID.ToString();
	 	txtDate.Text =hR_Overtime.Date.ToString();
	 	txtHours.Text =hR_Overtime.Hours.ToString();
	 	txtExtraField1.Text =hR_Overtime.ExtraField1.ToString();
	 	txtExtraField2.Text =hR_Overtime.ExtraField2.ToString();
	 	txtExtraField3.Text =hR_Overtime.ExtraField3.ToString();
	 	txtExtraField4.Text =hR_Overtime.ExtraField4.ToString();
	 	txtExtraField5.Text =hR_Overtime.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =hR_Overtime.RowStatusID.ToString();
	}
	
	private void EmployeeIDLoad()
	{
		try {
		DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
		ddlEmployeeID.DataValueField = "EmployeeID";
		ddlEmployeeID.DataTextField = "EmployeeNameNo";
		ddlEmployeeID.DataSource = ds.Tables[0];
		ddlEmployeeID.DataBind();
		ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
		ddlRowStatusID.DataValueField = "RowStatusID";
		ddlRowStatusID.DataTextField = "RowStatusName";
		ddlRowStatusID.DataSource = ds.Tables[0];
		ddlRowStatusID.DataBind();
		ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

