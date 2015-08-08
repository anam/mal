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
         		//RowStatusIDLoad();

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
        DateTime date = DateTime.Now;
        int year = 0;
        year = date.Year;

        DataSet batch = STD_BatchManager.GetAllSTD_BatchMaxIDByYearnID(year,int.Parse(txtBatchName.Text));
        if (batch.Tables[0].Rows.Count != 0)
        {
            lblMessage.Text = "Already in Database.";
        }
        else
        {
            STD_Batch sTD_Batch = new STD_Batch();

            sTD_Batch.BatchName = "Batch - "+txtBatchName.Text;

            sTD_Batch.BatchCode = year.ToString().Substring(2, 2) + int.Parse(txtBatchName.Text).ToString("000");
            sTD_Batch.ID = int.Parse(txtBatchName.Text);
            sTD_Batch.Year = year;

            sTD_Batch.ExtraField1 = " ";
            sTD_Batch.ExtraField2 = " ";
            sTD_Batch.ExtraField3 = " ";
            sTD_Batch.ExtraField4 = " ";
            sTD_Batch.ExtraField5 = " ";

            sTD_Batch.AddedBy = Profile.card_id;
            sTD_Batch.AddedDate = DateTime.Now;
            sTD_Batch.UpdatedBy = Profile.card_id;
            sTD_Batch.UpdateDate = DateTime.Now;

            sTD_Batch.RowStatusID = 1;
            int resutl = STD_BatchManager.InsertSTD_Batch(sTD_Batch);
            Response.Redirect("AdminDisplaySTD_Batch.aspx");
        }

        //STD_Batch batch = STD_BatchManager.GetSTD_BatchMaxIDByYear(year);
        //if (batch.MaxID != 0)
        //{

        //    STD_Batch sTD_Batch = new STD_Batch();

        //    sTD_Batch.BatchName = txtBatchName.Text;

        //    sTD_Batch.BatchCode = year.ToString().Substring(2, 2) + batch.MaxID.ToString("000");
        //    sTD_Batch.ID = batch.MaxID;
        //    sTD_Batch.Year = year;

        //    sTD_Batch.ExtraField1 = " ";
        //    sTD_Batch.ExtraField2 = " ";
        //    sTD_Batch.ExtraField3 = " ";
        //    sTD_Batch.ExtraField4 = " ";
        //    sTD_Batch.ExtraField5 = " ";

        //    sTD_Batch.AddedBy = Profile.card_id;
        //    sTD_Batch.AddedDate = DateTime.Now;
        //    sTD_Batch.UpdatedBy = Profile.card_id;
        //    sTD_Batch.UpdateDate = DateTime.Now;

        //    sTD_Batch.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
        //    int resutl = STD_BatchManager.InsertSTD_Batch(sTD_Batch);
        //    Response.Redirect("AdminDisplaySTD_Batch.aspx");
        //}
        //else
        //{
        //    STD_Batch sTD_Batch = new STD_Batch();
        //    //	sTD_Batch.BatchID=  int.Parse(ddlBatchID.SelectedValue);
        //    sTD_Batch.BatchName = txtBatchName.Text;
        //    sTD_Batch.BatchCode = year.ToString().Substring(2, 2) + "001";
        //    sTD_Batch.ID = 1;
        //    sTD_Batch.Year = year;

        //    sTD_Batch.ExtraField1 = " ";
        //    sTD_Batch.ExtraField2 = " ";
        //    sTD_Batch.ExtraField3 = " ";
        //    sTD_Batch.ExtraField4 = " ";
        //    sTD_Batch.ExtraField5 = " ";

        //    sTD_Batch.AddedBy = Profile.card_id;
        //    sTD_Batch.AddedDate = DateTime.Now;
        //    sTD_Batch.UpdatedBy = Profile.card_id;
        //    sTD_Batch.UpdateDate = DateTime.Now;
        //    sTD_Batch.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
        //    int resutl = STD_BatchManager.InsertSTD_Batch(sTD_Batch);
        //    Response.Redirect("AdminDisplaySTD_Batch.aspx");
        //}
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        STD_Batch sTD_Batch = STD_BatchManager.GetSTD_BatchByBatchID(int.Parse(Request.QueryString["ID"].ToString()));

        DataSet batch = STD_BatchManager.GetAllSTD_BatchMaxIDByYearnID(sTD_Batch.Year, int.Parse(txtBatchName.Text));
        if (batch.Tables[0].Rows.Count == 0 || (batch.Tables[0].Rows.Count == 1 && batch.Tables[0].Rows[0]["BatchID"].ToString() == Request.QueryString["ID"].ToString()))
        {
            sTD_Batch.BatchID = int.Parse(Request.QueryString["ID"].ToString());
            sTD_Batch.BatchName = "Batch - " + txtBatchName.Text;

            sTD_Batch.BatchCode = sTD_Batch.Year.ToString().Substring(2, 2) + int.Parse(txtBatchName.Text).ToString("000");
            sTD_Batch.ID = int.Parse(txtBatchName.Text);

            //sTD_Batch.BatchName = txtBatchName.Text;
            sTD_Batch.AddedBy = Profile.card_id;
            sTD_Batch.AddedDate = DateTime.Now;
            sTD_Batch.UpdatedBy = Profile.card_id;
            sTD_Batch.UpdateDate = DateTime.Now;
            sTD_Batch.RowStatusID = 1;
            bool resutl = STD_BatchManager.UpdateSTD_Batch(sTD_Batch);
            Response.Redirect("AdminDisplaySTD_Batch.aspx");
        }
        else
        {
            lblMessage.Text = "Already in Database.";
        }
    }
	private void showSTD_BatchData()
	{
	 	STD_Batch sTD_Batch  = new STD_Batch ();
	 	sTD_Batch = STD_BatchManager.GetSTD_BatchByBatchID(Int32.Parse(Request.QueryString["ID"]));
	 	txtBatchName.Text =sTD_Batch.ID.ToString();
	 	//ddlRowStatusID.SelectedValue  =sTD_Batch.RowStatusID.ToString();
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

