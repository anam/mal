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
public partial class AdminHR_SalaryAdjustmentList : System.Web.UI.Page
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
                showSalaryAdjustmentListData();
            }
            FillDropDownList();
        }
    }

    private void FillDropDownList()
    {
        ddlAdjustmentGroup.DataTextField = "GroupName";
        ddlAdjustmentGroup.DataValueField = "SalaryAdjustmentGroupID";
        ddlAdjustmentGroup.DataSource = HR_SalaryAdjustmentGroupManager.GetDropDownListAllHR_SalaryAdjustment();
        ddlAdjustmentGroup.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_SalaryAdjustmentList salaryAdjustmentList = new HR_SalaryAdjustmentList();
        salaryAdjustmentList.SalaryAdjustmentGroupID = int.Parse(ddlAdjustmentGroup.SelectedValue);
        salaryAdjustmentList.Name = txtName.Text;
        salaryAdjustmentList.Value = decimal.Parse(txtValue.Text);
        string userID = Profile.card_id;
        salaryAdjustmentList.AddedBy = userID;
        salaryAdjustmentList.AddedDate = DateTime.Now;
        salaryAdjustmentList.UpdatedBy = userID;
        salaryAdjustmentList.UpdatedDate = DateTime.Now;
        int resutl = HR_SalaryAdjustmentListManager.InsertSalaryAdjustmentList(salaryAdjustmentList);
        //Response.Redirect("AdminDisplayHR_SalaryAdjustmentList.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_SalaryAdjustmentList salaryAdjustmentList = new HR_SalaryAdjustmentList();
        salaryAdjustmentList.SalaryAdjustmentListID = int.Parse(Request.QueryString["ID"].ToString());
        salaryAdjustmentList.SalaryAdjustmentGroupID = int.Parse(ddlAdjustmentGroup.SelectedValue);
        salaryAdjustmentList.Name = txtName.Text;
        salaryAdjustmentList.Value = decimal.Parse(txtValue.Text);
        string userID = Profile.card_id;
        salaryAdjustmentList.AddedBy = userID;
        salaryAdjustmentList.AddedDate = DateTime.Now;
        salaryAdjustmentList.UpdatedBy = userID;
        salaryAdjustmentList.UpdatedDate = DateTime.Now;
        bool resutl = HR_SalaryAdjustmentListManager.UpdateSalaryAdjustmentList(salaryAdjustmentList);
        //Response.Redirect("AdminDisplayHR_SalaryAdjustmentList.aspx");
    }

    private void showSalaryAdjustmentListData()
    {
        HR_SalaryAdjustmentList salaryAdjustmentList = new HR_SalaryAdjustmentList();
        salaryAdjustmentList = HR_SalaryAdjustmentListManager.GetSalaryAdjustmentListBySalaryAdjustmentListID(Int32.Parse(Request.QueryString["ID"]));
        txtName.Text = salaryAdjustmentList.Name.ToString();
        txtValue.Text = salaryAdjustmentList.Value.ToString();
    }
    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        HR_SalaryAdjustmentGroup salaryAdjustmentGroup = new HR_SalaryAdjustmentGroup();
        salaryAdjustmentGroup.GroupName = txtAdjustmentGroupName.Text.Trim();
        string userID = Profile.card_id;
        salaryAdjustmentGroup.AddedBy = userID;
        salaryAdjustmentGroup.AddedDate = DateTime.Now;
        HR_SalaryAdjustmentGroupManager.InsertHR_SalaryAdjustment(salaryAdjustmentGroup);
        FillDropDownList();
    }
}

