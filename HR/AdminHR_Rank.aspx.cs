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
public partial class AdminHR_Rank : System.Web.UI.Page
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
                showHR_RankData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_Rank hR_Rank = new HR_Rank();       
        hR_Rank.RankName = txtRankName.Text;
        hR_Rank.SeniorityLevel = int.Parse(txtSeniorityLevel.Text);
        string userID = Profile.card_id;
        hR_Rank.AddedBy = userID;
        hR_Rank.AddedDate = DateTime.Now;
        hR_Rank.UpdatedBy = userID;
        hR_Rank.UpdateDate = DateTime.Now;
        int resutl = HR_RankManager.InsertHR_Rank(hR_Rank);
        Response.Redirect("AdminDisplayHR_Rank.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_Rank hR_Rank = new HR_Rank();
        hR_Rank.RankID = int.Parse(Request.QueryString["ID"].ToString());
        hR_Rank.RankName = txtRankName.Text;
        hR_Rank.SeniorityLevel = int.Parse(txtSeniorityLevel.Text);
        string userID = Profile.card_id;
        hR_Rank.AddedBy = userID;
        hR_Rank.AddedDate = DateTime.Now;
        hR_Rank.UpdatedBy = userID;
        hR_Rank.UpdateDate = DateTime.Now;
        bool resutl = HR_RankManager.UpdateHR_Rank(hR_Rank);
        Response.Redirect("AdminDisplayHR_Rank.aspx");
    }

    private void showHR_RankData()
    {
        HR_Rank hR_Rank = new HR_Rank();
        hR_Rank = HR_RankManager.GetHR_RankByRankID(Int32.Parse(Request.QueryString["ID"]));
        txtRankName.Text = hR_Rank.RankName.ToString();
        txtSeniorityLevel.Text = hR_Rank.SeniorityLevel.ToString();

    }
}

