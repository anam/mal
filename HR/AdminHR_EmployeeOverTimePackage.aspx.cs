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
public partial class AdminHR_EmployeeOverTimePackage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            OverTimePackIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_EmployeeOverTimePackageData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_EmployeeOverTimePackage hR_OverTime = new HR_EmployeeOverTimePackage();
        //	hR_OverTime.OverTimeID=  int.Parse(ddlOverTimeID.SelectedValue);
        hR_OverTime.EmployeeID = Profile.card_id;
        hR_OverTime.OverTimePackageID=  int.Parse(ddlOverTimePackID.SelectedValue);
        hR_OverTime.OverTimeTakaPerHour = decimal.Parse(txtOverTimeTakaPerHour.Text);
        hR_OverTime.OverTimeFlag = bool.Parse(radOverTimeFlag.SelectedValue);
        hR_OverTime.DayMonth = txtMonthlyTotalHour.Text;
        hR_OverTime.OverTimeDate = DateTime.Today;

        hR_OverTime.AddedBy = Profile.card_id;
        hR_OverTime.AddedDate = DateTime.Now;
        hR_OverTime.ModifiedBy = Profile.card_id;
        hR_OverTime.ModifiedDate = DateTime.Now;
        int resutl = HR_EmployeeOverTimePackageManager.InsertHR_EmployeeOverTimePackage(hR_OverTime);
        Response.Redirect("AdminDisplayHR_OverTime.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_EmployeeOverTimePackage hR_OverTime = new HR_EmployeeOverTimePackage();
        hR_OverTime.OverTimeID = int.Parse(Request.QueryString["ID"].ToString());
        hR_OverTime.EmployeeID = Profile.card_id;
        hR_OverTime.OverTimePackageID = int.Parse(ddlOverTimePackID.SelectedValue);
        hR_OverTime.OverTimeTakaPerHour = decimal.Parse(txtOverTimeTakaPerHour.Text);
        hR_OverTime.OverTimeFlag = bool.Parse(radOverTimeFlag.SelectedValue);
        hR_OverTime.DayMonth = txtMonthlyTotalHour.Text;
        hR_OverTime.OverTimeDate = DateTime.Today;
        hR_OverTime.AddedBy = Profile.card_id;
        hR_OverTime.AddedDate = DateTime.Now;
        hR_OverTime.ModifiedBy = Profile.card_id;
        hR_OverTime.ModifiedDate = DateTime.Now;
        bool resutl = HR_EmployeeOverTimePackageManager.UpdateHR_EmployeeOverTimePackage(hR_OverTime);
        Response.Redirect("AdminDisplayHR_OverTime.aspx");
    }

    private void showHR_EmployeeOverTimePackageData()
    {
        //HR_OverTimePackage hR_OverTime = new HR_OverTimePackage();
        //hR_OverTime = HR_OverTimePackageManager.GetAllHR_OverTimePackages();

        ////ddlOverTimePackID.SelectedValue  =hR_OverTime.OverTimePackID.ToString();
        //txtOverTimeTakaPerHour.Text = hR_OverTime.OverTimeTakaPerHour.ToString();
        //radOverTimeFlag.SelectedValue = hR_OverTime.OverTimeFlag.ToString();

    }

    private void OverTimePackIDLoad()
    {
        try
        {
            DataSet ds = HR_OverTimePackageManager.GetDropDownListAllHR_OverTimePackage();
            ddlOverTimePackID.DataValueField = "OverTimePackageID";
            ddlOverTimePackID.DataTextField = "OverTimePackageName";
            ddlOverTimePackID.DataSource = ds.Tables[0];
            ddlOverTimePackID.DataBind();
            ddlOverTimePackID.Items.Insert(0, new ListItem("Select OverTimePack >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

