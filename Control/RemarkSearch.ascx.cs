using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

public partial class Control_RemarkSearch : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DataSet ds = USER_MembershipManager.GetUSER_MembershipByID(Request.QueryString["ID"]);
                txtID.Text = ds.Tables[0].Rows[0]["UserName"].ToString() ;
                btnSearch_Click(this, new EventArgs());
                divSearch.Visible = false;
            }
            catch (Exception ex)
            { }

            //COMN_RemarkManager.LoadCOMN_RemarkPageByID(gvCOMN_Remark, rptPager, 1, ddlPageSize, txtID.Text);
        }
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        COMN_RemarkManager.LoadCOMN_RemarkPageByID(gvCOMN_Remark, rptPager, 1, ddlPageSize, txtID.Text);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        COMN_RemarkManager.LoadCOMN_RemarkPageByID(gvCOMN_Remark, rptPager, pageIndex, ddlPageSize, txtID.Text);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminCOMN_Remark.aspx?ID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminCOMN_Remark.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = COMN_RemarkManager.DeleteCOMN_Remark(Convert.ToInt32(linkButton.CommandArgument));
        COMN_RemarkManager.LoadCOMN_RemarkPageByID(gvCOMN_Remark, rptPager, 1, ddlPageSize, txtID.Text);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        COMN_RemarkManager.LoadCOMN_RemarkPageByID(gvCOMN_Remark, rptPager, 1, ddlPageSize, txtID.Text);
    }
}