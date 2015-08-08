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
 public partial class AdminSTD_Batch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_BatchData();
         		IDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_BatchData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_Batch sTD_Batch = new STD_Batch ();
//	sTD_Batch.BatchID=  int.Parse(ddlBatchID.SelectedValue);
	sTD_Batch.BatchName=  txtBatchName.Text;
	sTD_Batch.Year=  int.Parse(txtYear.Text);
	sTD_Batch.ID=  int.Parse(ddlID.SelectedValue);
	sTD_Batch.BatchCode=  txtBatchCode.Text;
	sTD_Batch.ExtraField1=  txtExtraField1.Text;
	sTD_Batch.ExtraField2=  txtExtraField2.Text;
	sTD_Batch.ExtraField3=  txtExtraField3.Text;
	sTD_Batch.ExtraField4=  txtExtraField4.Text;
	sTD_Batch.ExtraField5=  txtExtraField5.Text;
	sTD_Batch.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Batch.AddedDate=  DateTime.Now;
	sTD_Batch.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Batch.UpdateDate=  DateTime.Now;
	sTD_Batch.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =STD_BatchManager.InsertSTD_Batch(sTD_Batch);
	Response.Redirect("AdminDisplaySTD_Batch.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_Batch sTD_Batch = new STD_Batch ();
	sTD_Batch.BatchID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Batch.BatchName=  txtBatchName.Text;
	sTD_Batch.Year=  int.Parse(txtYear.Text);
	sTD_Batch.ID=  int.Parse(ddlID.SelectedValue);
	sTD_Batch.BatchCode=  txtBatchCode.Text;
	sTD_Batch.ExtraField1=  txtExtraField1.Text;
	sTD_Batch.ExtraField2=  txtExtraField2.Text;
	sTD_Batch.ExtraField3=  txtExtraField3.Text;
	sTD_Batch.ExtraField4=  txtExtraField4.Text;
	sTD_Batch.ExtraField5=  txtExtraField5.Text;
	sTD_Batch.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Batch.AddedDate=  DateTime.Now;
	sTD_Batch.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Batch.UpdateDate=  DateTime.Now;
	sTD_Batch.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =STD_BatchManager.UpdateSTD_Batch(sTD_Batch);
	Response.Redirect("AdminDisplaySTD_Batch.aspx");
	}
	private void showSTD_BatchData()
	{
	 	STD_Batch sTD_Batch  = new STD_Batch ();
	 	sTD_Batch = STD_BatchManager.GetSTD_BatchByBatchID(Int32.Parse(Request.QueryString["ID"]));
	 	txtBatchName.Text =sTD_Batch.BatchName.ToString();
	 	txtYear.Text =sTD_Batch.Year.ToString();
	 	ddlID.SelectedValue  =sTD_Batch.ID.ToString();
	 	txtBatchCode.Text =sTD_Batch.BatchCode.ToString();
	 	txtExtraField1.Text =sTD_Batch.ExtraField1.ToString();
	 	txtExtraField2.Text =sTD_Batch.ExtraField2.ToString();
	 	txtExtraField3.Text =sTD_Batch.ExtraField3.ToString();
	 	txtExtraField4.Text =sTD_Batch.ExtraField4.ToString();
	 	txtExtraField5.Text =sTD_Batch.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =sTD_Batch.RowStatusID.ToString();
	}
	
	private void IDLoad()
	{
		try {
		DataSet ds = STD_Manager.GetDropDownListAllSTD_();
		ddlID.DataValueField = "ID";
		ddlID.DataTextField = "Name";
		ddlID.DataSource = ds.Tables[0];
		ddlID.DataBind();
		ddlID.Items.Insert(0, new ListItem("Select  >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = STD_RowStatusManager.GetDropDownListAllSTD_RowStatus();
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

