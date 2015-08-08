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
public partial class AdminHR_BloodGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_BloodGroupData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_BloodGroup hR_BloodGroup = new HR_BloodGroup();
        //	hR_BloodGroup.BloodGroupID=  int.Parse(ddlBloodGroupID.SelectedValue);
        hR_BloodGroup.BloodGroupName = txtBloodGroupName.Text;
        string userID = Profile.card_id;
        hR_BloodGroup.AddedBy = userID;
        hR_BloodGroup.AddedDate = DateTime.Now;
        hR_BloodGroup.ModifiedBy = userID;
        hR_BloodGroup.ModifiedDate = DateTime.Now;
        int resutl = HR_BloodGroupManager.InsertHR_BloodGroup(hR_BloodGroup);
        Response.Redirect("AdminDisplayCOMN_BloodGroup.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_BloodGroup hR_BloodGroup = new HR_BloodGroup();
        hR_BloodGroup.BloodGroupID = int.Parse(Request.QueryString["ID"].ToString());
        hR_BloodGroup.BloodGroupName = txtBloodGroupName.Text;
        string userID = Profile.card_id;
        hR_BloodGroup.AddedBy = userID;
        hR_BloodGroup.AddedDate = DateTime.Now;
        hR_BloodGroup.ModifiedBy = userID;
        hR_BloodGroup.ModifiedDate = DateTime.Now;
        bool resutl = HR_BloodGroupManager.UpdateHR_BloodGroup(hR_BloodGroup);
        Response.Redirect("AdminDisplayCOMN_BloodGroup.aspx");
    }

    private void showHR_BloodGroupData()
    {
        HR_BloodGroup hR_BloodGroup = new HR_BloodGroup();
        hR_BloodGroup = HR_BloodGroupManager.GetHR_BloodGroupByBloodGroupID(Int32.Parse(Request.QueryString["ID"]));
        txtBloodGroupName.Text = hR_BloodGroup.BloodGroupName.ToString();
    }
}

