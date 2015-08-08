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
 public partial class AdminACC_JournalInfoForDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_JournalInfoForDeleteData();
         		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_JournalInfoForDeleteData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_JournalInfoForDelete aCC_JournalInfoForDelete = new ACC_JournalInfoForDelete ();
//	aCC_JournalInfoForDelete.JournalID=  int.Parse(ddlJournalID.SelectedValue);
	aCC_JournalInfoForDelete.TableNameValue=  txtTableNameValue.Text;
	aCC_JournalInfoForDelete.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	aCC_JournalInfoForDelete.UpdateDate=  DateTime.Now;
	aCC_JournalInfoForDelete.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =ACC_JournalInfoForDeleteManager.InsertACC_JournalInfoForDelete(aCC_JournalInfoForDelete);
	Response.Redirect("AdminDisplayACC_JournalInfoForDelete.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_JournalInfoForDelete aCC_JournalInfoForDelete = new ACC_JournalInfoForDelete ();
	aCC_JournalInfoForDelete.JournalID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_JournalInfoForDelete.TableNameValue=  txtTableNameValue.Text;
	aCC_JournalInfoForDelete.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	aCC_JournalInfoForDelete.UpdateDate=  DateTime.Now;
	aCC_JournalInfoForDelete.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_JournalInfoForDeleteManager.UpdateACC_JournalInfoForDelete(aCC_JournalInfoForDelete);
	Response.Redirect("AdminDisplayACC_JournalInfoForDelete.aspx");
	}
	private void showACC_JournalInfoForDeleteData()
	{
	 	ACC_JournalInfoForDelete aCC_JournalInfoForDelete  = new ACC_JournalInfoForDelete ();
	 	aCC_JournalInfoForDelete = ACC_JournalInfoForDeleteManager.GetACC_JournalInfoForDeleteByJournalID(Int32.Parse(Request.QueryString["ID"]));
	 	txtTableNameValue.Text =aCC_JournalInfoForDelete.TableNameValue.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_JournalInfoForDelete.RowStatusID.ToString();
	}
	
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = ACC_RowStatusManager.GetDropDownListAllACC_RowStatus();
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

