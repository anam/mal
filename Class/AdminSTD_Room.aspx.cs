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
 public partial class AdminSTD_Room : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_RoomData();
         		CampusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_RoomData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_Room sTD_Room = new STD_Room ();
//	sTD_Room.RoomID=  int.Parse(ddlRoomID.SelectedValue);
	sTD_Room.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	sTD_Room.RoomName=  txtRoomName.Text;
	sTD_Room.Description=  txtDescription.Text;
	sTD_Room.AddedBy=  Profile.card_id;
	sTD_Room.AddedDate=  DateTime.Now;
	sTD_Room.UpdatedBy=  Profile.card_id;
	sTD_Room.UpdateDate = DateTime.Now; 
	int resutl =STD_RoomManager.InsertSTD_Room(sTD_Room);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Room.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_Room sTD_Room = new STD_Room ();
	sTD_Room.RoomID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Room.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	sTD_Room.RoomName=  txtRoomName.Text;
	sTD_Room.Description=  txtDescription.Text;
	sTD_Room.AddedBy=  Profile.card_id;
	sTD_Room.AddedDate=  DateTime.Now;
	sTD_Room.UpdatedBy=  Profile.card_id;
	sTD_Room.UpdateDate = DateTime.Now; 
	bool  resutl =STD_RoomManager.UpdateSTD_Room(sTD_Room);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Room.aspx");
	}
	private void showSTD_RoomData()
	{
	 	STD_Room sTD_Room  = new STD_Room ();
	 	sTD_Room = STD_RoomManager.GetSTD_RoomByRoomID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlCampusID.SelectedValue  =sTD_Room.CampusID.ToString();
	 	txtRoomName.Text =sTD_Room.RoomName.ToString();
	 	txtDescription.Text =sTD_Room.Description.ToString();
	}
	
	private void CampusIDLoad()
	{
		try {
		DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
		ddlCampusID.DataValueField = "CampusID";
		ddlCampusID.DataTextField = "CampusName";
		ddlCampusID.DataSource = ds.Tables[0];
		ddlCampusID.DataBind();
		ddlCampusID.Items.Insert(0, new ListItem("Select Campus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

