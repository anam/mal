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
 public partial class AdminCOMN_EducatinalBackground : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_EducatinalBackgroundData();
         		UserIDLoad();
		ReaultSystemIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_EducatinalBackgroundData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground ();
//	cOMN_EducatinalBackground.EducationalBacgroundID=  int.Parse(ddlEducationalBacgroundID.SelectedValue);
	cOMN_EducatinalBackground.UserID=  ddlUserID.SelectedValue;
	cOMN_EducatinalBackground.Year=  txtYear.Text;
	cOMN_EducatinalBackground.BoardUniversity=  txtBoardUniversity.Text;
	cOMN_EducatinalBackground.EducationGroup=  txtEducationGroup.Text;
	cOMN_EducatinalBackground.Major=  txtMajor.Text;
	cOMN_EducatinalBackground.ReaultSystemID=  int.Parse(ddlReaultSystemID.SelectedValue);
	cOMN_EducatinalBackground.Degree=  txtDegree.Text;
	cOMN_EducatinalBackground.Result=  txtResult.Text;
	cOMN_EducatinalBackground.Score=  decimal.Parse(txtScore.Text);
	cOMN_EducatinalBackground.OutOf=  int.Parse(txtOutOf.Text);
	cOMN_EducatinalBackground.AddedBy=  Profile.card_id;
	cOMN_EducatinalBackground.AddedDate=  DateTime.Now;
	cOMN_EducatinalBackground.ModifiedBy=  Profile.card_id;
	cOMN_EducatinalBackground.ModifiedDate=  DateTime.Now;
	int resutl =COMN_EducatinalBackgroundManager.InsertCOMN_EducatinalBackground(cOMN_EducatinalBackground);
	Response.Redirect("AdminCOMN_EducatinalBackgroundDisplay.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground ();
	cOMN_EducatinalBackground.EducationalBacgroundID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_EducatinalBackground.UserID=  ddlUserID.SelectedValue;
	cOMN_EducatinalBackground.Year=  txtYear.Text;
	cOMN_EducatinalBackground.BoardUniversity=  txtBoardUniversity.Text;
	cOMN_EducatinalBackground.EducationGroup=  txtEducationGroup.Text;
	cOMN_EducatinalBackground.Major=  txtMajor.Text;
	cOMN_EducatinalBackground.ReaultSystemID=  int.Parse(ddlReaultSystemID.SelectedValue);
	cOMN_EducatinalBackground.Degree=  txtDegree.Text;
	cOMN_EducatinalBackground.Result=  txtResult.Text;
	cOMN_EducatinalBackground.Score=  decimal.Parse(txtScore.Text);
	cOMN_EducatinalBackground.OutOf=  int.Parse(txtOutOf.Text);
	cOMN_EducatinalBackground.AddedBy=  Profile.card_id;
	cOMN_EducatinalBackground.AddedDate=  DateTime.Now;
	cOMN_EducatinalBackground.ModifiedBy=  Profile.card_id;
	cOMN_EducatinalBackground.ModifiedDate=  DateTime.Now;
	bool  resutl =COMN_EducatinalBackgroundManager.UpdateCOMN_EducatinalBackground(cOMN_EducatinalBackground);
	Response.Redirect("AdminDisplayCOMN_EducatinalBackground.aspx");
	}
	private void showCOMN_EducatinalBackgroundData()
	{
	 	COMN_EducatinalBackground cOMN_EducatinalBackground  = new COMN_EducatinalBackground ();
	 	cOMN_EducatinalBackground = COMN_EducatinalBackgroundManager.GetCOMN_EducatinalBackgroundByEducationalBacgroundID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlUserID.SelectedValue  =cOMN_EducatinalBackground.UserID.ToString();
	 	txtYear.Text =cOMN_EducatinalBackground.Year.ToString();
	 	txtBoardUniversity.Text =cOMN_EducatinalBackground.BoardUniversity.ToString();
	 	txtEducationGroup.Text =cOMN_EducatinalBackground.EducationGroup.ToString();
	 	txtMajor.Text =cOMN_EducatinalBackground.Major.ToString();
	 	ddlReaultSystemID.SelectedValue  =cOMN_EducatinalBackground.ReaultSystemID.ToString();
	 	txtDegree.Text =cOMN_EducatinalBackground.Degree.ToString();
	 	txtResult.Text =cOMN_EducatinalBackground.Result.ToString();
	 	txtScore.Text =cOMN_EducatinalBackground.Score.ToString();
	 	txtOutOf.Text =cOMN_EducatinalBackground.OutOf.ToString();
	}
	
	private void UserIDLoad()
	{
		try {
            //DataSet ds = COMN_UserManager.GetDropDownListAllCOMN_User();
            //ddlUserID.DataValueField = "UserID";
            //ddlUserID.DataTextField = "UserName";
            //ddlUserID.DataSource = ds.Tables[0];
            //ddlUserID.DataBind();
            //ddlUserID.Items.Insert(0, new ListItem("Select User >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void ReaultSystemIDLoad()
	{
		try {
		DataSet ds = COMN_ReaultSystemManager.GetDropDownListAllCOMN_ReaultSystem();
		ddlReaultSystemID.DataValueField = "ReaultSystemID";
		ddlReaultSystemID.DataTextField = "ReaultSystemName";
		ddlReaultSystemID.DataSource = ds.Tables[0];
		ddlReaultSystemID.DataBind();
		ddlReaultSystemID.Items.Insert(0, new ListItem("Select ReaultSystem >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

