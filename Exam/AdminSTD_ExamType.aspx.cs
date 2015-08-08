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
 public partial class AdminSTD_ExamType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ExamTypeData();
         		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ExamTypeData();
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_ExamType sTD_ExamType = new STD_ExamType();
            //	sTD_ExamType.ExamTypeID=  int.Parse(ddlExamTypeID.SelectedValue);
            sTD_ExamType.ExamTypeName = txtExamTypeName.Text;
            sTD_ExamType.ExtraField1 = "";
            sTD_ExamType.ExtraField2 = "";
            sTD_ExamType.ExtraField3 = "";
            sTD_ExamType.ExtraField4 = "";
            sTD_ExamType.ExtraField5 = "";
            sTD_ExamType.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_ExamType.AddedDate = DateTime.Now;
            sTD_ExamType.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_ExamType.UpdateDate = DateTime.Now;
            sTD_ExamType.RowStatusID = 1;
            int resutl = STD_ExamTypeManager.InsertSTD_ExamType(sTD_ExamType);
            Response.Redirect("AdminDisplaySTD_ExamType.aspx");
        }

        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_ExamType sTD_ExamType = new STD_ExamType();
            sTD_ExamType.ExamTypeID = int.Parse(Request.QueryString["ID"].ToString());
            sTD_ExamType.ExamTypeName = txtExamTypeName.Text;
            sTD_ExamType.ExtraField1 = "";
            sTD_ExamType.ExtraField2 = "";
            sTD_ExamType.ExtraField3 = "";
            sTD_ExamType.ExtraField4 = "";
            sTD_ExamType.ExtraField5 = "";
            sTD_ExamType.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_ExamType.AddedDate = DateTime.Now;
            sTD_ExamType.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_ExamType.UpdateDate = DateTime.Now;
            sTD_ExamType.RowStatusID = 1;
            bool resutl = STD_ExamTypeManager.UpdateSTD_ExamType(sTD_ExamType);
            Response.Redirect("AdminDisplaySTD_ExamType.aspx");
        }

        catch (Exception ex)
        {
        }
    }
	private void showSTD_ExamTypeData()
	{
	 	STD_ExamType sTD_ExamType  = new STD_ExamType ();
	 	sTD_ExamType = STD_ExamTypeManager.GetSTD_ExamTypeByExamTypeID(Int32.Parse(Request.QueryString["ID"]));
	 	txtExamTypeName.Text =sTD_ExamType.ExamTypeName.ToString();
	 	
	}
	
	private void RowStatusIDLoad()
	{
        //try {
        //DataSet ds = STD_RowStatusManager.GetDropDownListAllSTD_RowStatus();
        //ddlRowStatusID.DataValueField = "RowStatusID";
        //ddlRowStatusID.DataTextField = "RowStatusName";
        //ddlRowStatusID.DataSource = ds.Tables[0];
        //ddlRowStatusID.DataBind();
        //ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
        //}
        //catch (Exception ex) {
        //ex.Message.ToString();
        //}
	 }
}

