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
 public partial class AdminSTD_Routine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_RoutineData();
            CampuesLoad();
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_RoutineData();
                }
        }
    }

    private void CampuesLoad()
    {
        try
        {
            DataSet ds = STD_CampusManager.GetDropDownListAllSTD_Campus();
            ddlCampus.DataValueField = "CampusID";
            ddlCampus.DataTextField = "CampusName";
            ddlCampus.DataSource = ds.Tables[0];
            ddlCampus.DataBind();
            ddlCampus.Items.Insert(0, new ListItem("Select Campus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
            if(ddlCampus.SelectedIndex!=0){
	        STD_Routine sTD_Routine = new STD_Routine ();
        //	sTD_Routine.RoutineID=  int.Parse(ddlRoutineID.SelectedValue);
	        sTD_Routine.RoutineName=  ddlCampus.SelectedValue;
	        sTD_Routine.StartDate=   DateTime.Parse(txtStartDate.Text);
	        sTD_Routine.EndDate=   DateTime.Parse(txtEndDate.Text);
	        sTD_Routine.AddedBy=  Profile.card_id;
	        sTD_Routine.AddedDate=  DateTime.Now;
	        sTD_Routine.UpdatedBy=  Profile.card_id;
	        sTD_Routine.UpdateDate = DateTime.Now; 
	        int resutl =STD_RoutineManager.InsertSTD_Routine(sTD_Routine);
            }
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplaySTD_Routine.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
            if (ddlCampus.SelectedIndex != 0)
            {
                STD_Routine sTD_Routine = new STD_Routine();
                sTD_Routine.RoutineID = int.Parse(Request.QueryString["ID"].ToString());
                sTD_Routine.RoutineName = ddlCampus.SelectedValue;
                sTD_Routine.StartDate = DateTime.Parse(txtStartDate.Text);
                sTD_Routine.EndDate = DateTime.Parse(txtEndDate.Text);
                sTD_Routine.AddedBy = Profile.card_id;
                sTD_Routine.AddedDate = DateTime.Now;
                sTD_Routine.UpdatedBy = Profile.card_id;
                sTD_Routine.UpdateDate = DateTime.Now;
                bool resutl = STD_RoutineManager.UpdateSTD_Routine(sTD_Routine);
            }
        }
    catch (Exception ex) { } Response.Redirect("AdminDisplaySTD_Routine.aspx");
	}
	private void showSTD_RoutineData()
	{
	 	STD_Routine sTD_Routine  = new STD_Routine ();
	 	sTD_Routine = STD_RoutineManager.GetSTD_RoutineByRoutineID(Int32.Parse(Request.QueryString["ID"]));
        ddlCampus.SelectedValue = sTD_Routine.RoutineName.ToString();
	 	txtStartDate.Text =sTD_Routine.StartDate.ToString();
	 	txtEndDate.Text =sTD_Routine.EndDate.ToString();
	}
	
}

