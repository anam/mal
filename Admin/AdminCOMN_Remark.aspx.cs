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
 public partial class AdminCOMN_Remark : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
            //loadCOMN_RemarkData();
         	//RowStatusIDLoad();
            txtRemarkDate.Text = DateTime.Today.ToString("dd MMM yyyy");
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_RemarkData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_Remark cOMN_Remark = new COMN_Remark ();
//	cOMN_Remark.RemarkID=  int.Parse(ddlRemarkID.SelectedValue);
	cOMN_Remark.RemarkName=  txtRemarkName.Text;
	cOMN_Remark.Remark=  txtRemark.Text;
	cOMN_Remark.RemarkDate=   DateTime.Parse(txtRemarkDate.Text);
	cOMN_Remark.WhoReported=  txtWhoReported.Text;
    cOMN_Remark.WhoDid = processWhoDid();
	cOMN_Remark.ExtraField1=  txtExtraField1.Text;
	cOMN_Remark.ExtraField2=  txtExtraField2.Text;
	cOMN_Remark.ExtraField3=  txtExtraField3.Text;
	cOMN_Remark.ExtraField4=  txtExtraField4.Text;
	cOMN_Remark.ExtraField5=  txtExtraField5.Text;
	cOMN_Remark.AddedBy=  Profile.card_id;
	cOMN_Remark.AddedDate=  DateTime.Now;
	cOMN_Remark.UpdatedBy=  Profile.card_id;
	cOMN_Remark.UpdatedDate=  DateTime.Now;
	cOMN_Remark.RowStatusID= 1;// int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =COMN_RemarkManager.InsertCOMN_Remark(cOMN_Remark);
	Response.Redirect("AdminDisplayCOMN_Remark.aspx");
	}

    private string processWhoDid()
    {
        if (txtWhoDid.Text.Contains(','))
        {
            string[] words = txtWhoDid.Text.Split(',');
            string retunString = "";
            foreach (string  item in words)
            {
                try
                {
                    retunString += ", " + int.Parse(item).ToString() + " ";
                }
                catch (Exception ex)
                { continue; }
            }

            return retunString;
        }
        else
        {
            return " "+txtWhoDid.Text + " ";
        }
    }

	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_Remark cOMN_Remark = new COMN_Remark ();
	cOMN_Remark.RemarkID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_Remark.RemarkName=  txtRemarkName.Text;
	cOMN_Remark.Remark=  txtRemark.Text;
	cOMN_Remark.RemarkDate=   DateTime.Parse(txtRemarkDate.Text);
	cOMN_Remark.WhoReported=  txtWhoReported.Text;
    cOMN_Remark.WhoDid = processWhoDid();
	cOMN_Remark.ExtraField1=  txtExtraField1.Text;
	cOMN_Remark.ExtraField2=  txtExtraField2.Text;
	cOMN_Remark.ExtraField3=  txtExtraField3.Text;
	cOMN_Remark.ExtraField4=  txtExtraField4.Text;
	cOMN_Remark.ExtraField5=  txtExtraField5.Text;
	cOMN_Remark.AddedBy=  Profile.card_id;
	cOMN_Remark.AddedDate=  DateTime.Now;
	cOMN_Remark.UpdatedBy=  Profile.card_id;
	cOMN_Remark.UpdatedDate=  DateTime.Now;
    cOMN_Remark.RowStatusID = 1;// int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =COMN_RemarkManager.UpdateCOMN_Remark(cOMN_Remark);
	Response.Redirect("AdminDisplayCOMN_Remark.aspx");
	}
	private void showCOMN_RemarkData()
	{
	 	COMN_Remark cOMN_Remark  = new COMN_Remark ();
	 	cOMN_Remark = COMN_RemarkManager.GetCOMN_RemarkByRemarkID(Int32.Parse(Request.QueryString["ID"]));
	 	txtRemarkName.Text =cOMN_Remark.RemarkName.ToString();
	 	txtRemark.Text =cOMN_Remark.Remark.ToString();
	 	txtRemarkDate.Text =cOMN_Remark.RemarkDate.ToString();
	 	txtWhoReported.Text =cOMN_Remark.WhoReported.ToString();
	 	txtWhoDid.Text =cOMN_Remark.WhoDid.ToString();
	 	txtExtraField1.Text =cOMN_Remark.ExtraField1.ToString();
	 	txtExtraField2.Text =cOMN_Remark.ExtraField2.ToString();
	 	txtExtraField3.Text =cOMN_Remark.ExtraField3.ToString();
	 	txtExtraField4.Text =cOMN_Remark.ExtraField4.ToString();
	 	txtExtraField5.Text =cOMN_Remark.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =cOMN_Remark.RowStatusID.ToString();
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

