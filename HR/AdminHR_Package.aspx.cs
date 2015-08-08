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
public partial class AdminHR_Package : System.Web.UI.Page
{

    private static List<HR_PackageRules> ListPackageRules = new List<HR_PackageRules>();

    //HR_PackageRulesManager
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_PackageData();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_Package hR_Package = new HR_Package();
        //	hR_Package.PackageID=  int.Parse(ddlPackageID.SelectedValue);
        hR_Package.PackageName = txtPackageName.Text;
        hR_Package.PackageValue = 0;
        int PackageID = HR_PackageManager.InsertHR_Package(hR_Package);

        for (int i = 0; i < ListPackageRules.Count; i++)
        {
            HR_PackageRules hR_PackageRules = new HR_PackageRules();
            //	hR_PackageRules.PackageRulesID=  int.Parse(ddlPackageRulesID.SelectedValue);
            Label lblPackageRulesName = ((Label)gvHR_PackageRules.Rows[i].FindControl("lblPackageRulesName"));
            Label lblRulesValue = ((Label)gvHR_PackageRules.Rows[i].FindControl("lblRulesValue"));
            Label lblRulesOperator = ((Label)gvHR_PackageRules.Rows[i].FindControl("lblRulesOperator"));
            hR_PackageRules.PackageRulesName = lblPackageRulesName.Text;
            hR_PackageRules.PackageID = PackageID;
            hR_PackageRules.RulesValue = int.Parse(lblRulesValue.Text);
            hR_PackageRules.RulesOperator = lblRulesOperator.Text;
            string userID = Profile.card_id;
            hR_PackageRules.AddedBy = userID;
            hR_PackageRules.AddedDate = DateTime.Now;
            hR_PackageRules.UpdatedBy = userID;
            hR_PackageRules.UpdatedDate = DateTime.Now;
            int resutl = HR_PackageRulesManager.InsertHR_PackageRules(hR_PackageRules);
        }
        Response.Redirect("AdminDisplayHR_Package.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_Package hR_Package = new HR_Package();
        hR_Package.PackageID = int.Parse(Request.QueryString["ID"].ToString());
        hR_Package.PackageName = txtPackageName.Text;
        hR_Package.PackageValue = 0;
        bool resutlPackage = HR_PackageManager.UpdateHR_Package(hR_Package);
        for (int i = 0; i < ListPackageRules.Count; i++)
        {
            HR_PackageRules hR_PackageRules = new HR_PackageRules();
            //	hR_PackageRules.PackageRulesID=  int.Parse(ddlPackageRulesID.SelectedValue);
            Label lblPackageRulesID = (Label)gvHR_PackageRules.Rows[i].FindControl("lblPackageRulesID");
            Label lblPackageRulesName = ((Label)gvHR_PackageRules.Rows[i].FindControl("lblPackageRulesName"));
            Label lblRulesValue = ((Label)gvHR_PackageRules.Rows[i].FindControl("lblRulesValue"));
            Label lblRulesOperator = ((Label)gvHR_PackageRules.Rows[i].FindControl("lblRulesOperator"));

            hR_PackageRules.PackageRulesID = Convert.ToInt32(lblPackageRulesID.Text);
            hR_PackageRules.PackageRulesName = lblPackageRulesName.Text;
            hR_PackageRules.PackageID = hR_Package.PackageID;
            hR_PackageRules.RulesValue = int.Parse(lblRulesValue.Text);
            hR_PackageRules.RulesOperator = lblRulesOperator.Text;
            string userID = Profile.card_id;
            hR_PackageRules.AddedBy = userID;
            hR_PackageRules.AddedDate = DateTime.Now;
            hR_PackageRules.UpdatedBy = userID;
            hR_PackageRules.UpdatedDate = DateTime.Now;

            if (hR_PackageRules.PackageRulesID == 0)
            {
                int resutl = HR_PackageRulesManager.InsertHR_PackageRules(hR_PackageRules);
            }
            else if (hR_PackageRules.PackageRulesID > 0)
            {
                bool resutl = HR_PackageRulesManager.UpdateHR_PackageRules(hR_PackageRules);
            }
        }
        Response.Redirect("AdminDisplayHR_Package.aspx");
    }
    private void showHR_PackageData()
    {
        try
        {
            HR_Package hR_Package = new HR_Package();
            hR_Package = HR_PackageManager.GetHR_PackageByPackageID(Int32.Parse(Request.QueryString["ID"]));
            txtPackageName.Text = hR_Package.PackageName.ToString();
            //txtPackageName.ReadOnly = true;

            ListPackageRules.Clear();
            DataSet listPackageRulesDataSet = HR_PackageRulesManager.GetAllHR_PackageRulessByPackageID(hR_Package.PackageID);
            if (listPackageRulesDataSet.Tables[0] != null)
            {
                foreach (DataRow row in listPackageRulesDataSet.Tables[0].Rows)
                {
                    HR_PackageRules packageRule = new HR_PackageRules();
                    packageRule.PackageRulesID = Convert.ToInt32(row["PackageRulesID"]);
                    packageRule.PackageRulesName = Convert.ToString(row["PackageRulesName"]);
                    packageRule.RulesValue = Convert.ToInt32(row["RulesValue"]);
                    packageRule.RulesOperator = Convert.ToString(row["RulesOperator"]);
                    ListPackageRules.Add(packageRule);
                }
            }

            gvHR_PackageRules.DataSource = ListPackageRules;
            gvHR_PackageRules.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        //ListPackageRules
        HR_PackageRules packageRule = new HR_PackageRules();
        if (lblPackageRulesID.Text != string.Empty)
        {
            packageRule.PackageRulesID = Convert.ToInt32(lblPackageRulesID.Text.Trim());
        }
        else
        {
            packageRule.PackageRulesID = 0;
        }
        packageRule.PackageRulesName = txtPackageRulesName.Text;
        packageRule.RulesValue = Int32.Parse(txtRulesValue.Text);
        packageRule.RulesOperator = ddlRulesOperator.SelectedValue.ToString();
        ListPackageRules.Add(packageRule);
        gvHR_PackageRules.DataSource = ListPackageRules;
        gvHR_PackageRules.DataBind();
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);

        HR_PackageRules packageRule = new HR_PackageRules();
        packageRule = ListPackageRules.ElementAt(index);
        if (packageRule.PackageRulesID != 0)
        {
            bool result = HR_PackageRulesManager.DeleteHR_PackageRules(packageRule.PackageRulesID);
        }
        ListPackageRules.RemoveAt(index);
        gvHR_PackageRules.DataSource = ListPackageRules;
        gvHR_PackageRules.DataBind();
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);

        HR_PackageRules packageRule = new HR_PackageRules();
        packageRule = ListPackageRules.ElementAt(index);

        lblPackageRulesID.Text = packageRule.PackageRulesID.ToString();
        txtPackageRulesName.Text = packageRule.PackageRulesName;
        txtRulesValue.Text = packageRule.RulesValue.ToString();
        ddlRulesOperator.SelectedValue = packageRule.RulesOperator;

        ListPackageRules.RemoveAt(index);
        gvHR_PackageRules.DataSource = ListPackageRules;
        gvHR_PackageRules.DataBind();

    }
}

