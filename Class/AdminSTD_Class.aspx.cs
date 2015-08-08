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
 public partial class AdminSTD_Class : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassData();
         		ClassTypeIDLoad();
		ClassStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_Class sTD_Class = new STD_Class ();
//	sTD_Class.ClassID=  int.Parse(ddlClassID.SelectedValue);
	sTD_Class.ClassName=  txtClassName.Text;
	sTD_Class.ClassTypeID=  int.Parse(ddlClassTypeID.SelectedValue);
	sTD_Class.ClassStatusID=  int.Parse(ddlClassStatusID.SelectedValue);
	sTD_Class.AddedBy=  Profile.card_id;
	sTD_Class.AddedDate=  DateTime.Now;
	sTD_Class.UpdatedBy=  Profile.card_id;
	sTD_Class.UpdateDate = DateTime.Now; 
	int resutl =STD_ClassManager.InsertSTD_Class(sTD_Class);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Class.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_Class sTD_Class = new STD_Class ();
	sTD_Class.ClassID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Class.ClassName=  txtClassName.Text;
	sTD_Class.ClassTypeID=  int.Parse(ddlClassTypeID.SelectedValue);
	sTD_Class.ClassStatusID=  int.Parse(ddlClassStatusID.SelectedValue);
	sTD_Class.AddedBy=  Profile.card_id;
	sTD_Class.AddedDate=  DateTime.Now;
	sTD_Class.UpdatedBy=  Profile.card_id;
	sTD_Class.UpdateDate = DateTime.Now; 
	bool  resutl =STD_ClassManager.UpdateSTD_Class(sTD_Class);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Class.aspx");
	}
	private void showSTD_ClassData()
	{
	 	STD_Class sTD_Class  = new STD_Class ();
	 	sTD_Class = STD_ClassManager.GetSTD_ClassByClassID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassName.Text =sTD_Class.ClassName.ToString();
	 	ddlClassTypeID.SelectedValue  =sTD_Class.ClassTypeID.ToString();
	 	ddlClassStatusID.SelectedValue  =sTD_Class.ClassStatusID.ToString();
	}
	
	private void ClassTypeIDLoad()
	{
		try {
		DataSet ds = STD_ClassTypeManager.GetDropDownListAllSTD_ClassType();
		ddlClassTypeID.DataValueField = "ClassTypeID";
		ddlClassTypeID.DataTextField = "ClassTypeName";
		ddlClassTypeID.DataSource = ds.Tables[0];
		ddlClassTypeID.DataBind();
		ddlClassTypeID.Items.Insert(0, new ListItem("Select ClassType >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void ClassStatusIDLoad()
	{
		try {
		DataSet ds = STD_ClassStatusManager.GetDropDownListAllSTD_ClassStatus();
		ddlClassStatusID.DataValueField = "ClassStatusID";
		ddlClassStatusID.DataTextField = "ClassStatusName";
		ddlClassStatusID.DataSource = ds.Tables[0];
		ddlClassStatusID.DataBind();
		ddlClassStatusID.Items.Insert(0, new ListItem("Select ClassStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

