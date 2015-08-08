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
public partial class AdminHR_SalaryAdjustmentListRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployeeIDLoad();
            SalaryAdjustmentListIDLoad();
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showSalaryAdjustmentListRulesData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_SalaryAdjustmentListRules salaryAdjustmentListRules = new HR_SalaryAdjustmentListRules();
        //	salaryAdjustmentListRules.SalaryAdjustmentListRulesID=  int.Parse(ddlSalaryAdjustmentListRulesID.SelectedValue);
        salaryAdjustmentListRules.EmployeeID = ddlEmployeeID.SelectedValue;
        salaryAdjustmentListRules.SalaryAdjustmentGroupID = int.Parse(ddlSalaryAdjustmentListID.SelectedValue);
        string userID = Profile.card_id;
        salaryAdjustmentListRules.AddedBy = userID;
        salaryAdjustmentListRules.AddedDate = DateTime.Now;
        salaryAdjustmentListRules.UpdatedBy = userID;
        salaryAdjustmentListRules.UpdatedDate = DateTime.Now;
        int resutl = HR_SalaryAdjustmentListRulesManager.InsertSalaryAdjustmentListRules(salaryAdjustmentListRules);
        Response.Redirect("AdminDisplaySalaryAdjustmentListRules.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_SalaryAdjustmentListRules salaryAdjustmentListRules = new HR_SalaryAdjustmentListRules();
        salaryAdjustmentListRules.SalaryAdjustmentListRulesID = int.Parse(Request.QueryString["ID"].ToString());
        salaryAdjustmentListRules.EmployeeID = ddlEmployeeID.SelectedValue;
        salaryAdjustmentListRules.SalaryAdjustmentGroupID = int.Parse(ddlSalaryAdjustmentListID.SelectedValue);
        string userID = Profile.card_id;
        salaryAdjustmentListRules.AddedBy = userID;
        salaryAdjustmentListRules.AddedDate = DateTime.Now;
        salaryAdjustmentListRules.UpdatedBy = userID;
        salaryAdjustmentListRules.UpdatedDate = DateTime.Now;
        bool resutl = HR_SalaryAdjustmentListRulesManager.UpdateSalaryAdjustmentListRules(salaryAdjustmentListRules);
        Response.Redirect("AdminDisplaySalaryAdjustmentListRules.aspx");
    }

    private void showSalaryAdjustmentListRulesData()
    {
        HR_SalaryAdjustmentListRules salaryAdjustmentListRules = new HR_SalaryAdjustmentListRules();
        salaryAdjustmentListRules = HR_SalaryAdjustmentListRulesManager.GetSalaryAdjustmentListRulesBySalaryAdjustmentListRulesID(Int32.Parse(Request.QueryString["ID"]));
        ddlEmployeeID.SelectedValue = salaryAdjustmentListRules.EmployeeID.ToString();
        ddlSalaryAdjustmentListID.SelectedValue = salaryAdjustmentListRules.SalaryAdjustmentGroupID.ToString();
    }

    private void EmployeeIDLoad()
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void SalaryAdjustmentListIDLoad()
    {
        //try
        //{
        //    DataSet ds = HR_SalaryAdjustmentListManager.GetDropDownListAllHR_SalaryAdjustmentList();
        //    ddlSalaryAdjustmentListID.DataValueField = "SalaryAdjustmentListID";
        //    ddlSalaryAdjustmentListID.DataTextField = "SalaryAdjustmentListName";
        //    ddlSalaryAdjustmentListID.DataSource = ds.Tables[0];
        //    ddlSalaryAdjustmentListID.DataBind();
        //    ddlSalaryAdjustmentListID.Items.Insert(0, new ListItem("Select SalaryAdjustmentList >>", "0"));
        //}
        //catch (Exception ex)
        //{
        //    ex.Message.ToString();
        //}
    }
}

