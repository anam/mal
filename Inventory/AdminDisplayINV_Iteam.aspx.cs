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


public partial class AdminDisplayINV_Iteam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CampusIDLoad();
            IteamSubCategoryIDLoad();
            processInitialGrid();

            string totalItem = gvINV_Iteam.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblTotalItem.Text = "Total Item : " + totalItems[0];
            //lblTotalCost.Visible = false;
            //lblTotalSalePrice.Visible = false;
        }
    }

    private void IteamSubCategoryIDLoad()
    {
        try
        {
            DataSet ds = INV_IteamSubCategoryManager.GetDropDownListAllINV_IteamSubCategory();
            ddlItemSubCategory.DataValueField = "IteamSubCategoryID";
            ddlItemSubCategory.DataTextField = "IteamSubCategoryName";
            ddlItemSubCategory.DataSource = ds.Tables[0];
            ddlItemSubCategory.DataBind();
            ddlItemSubCategory.Items.Insert(0, new ListItem("Select Item Sub Category >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnIssueSearch_Click(object sender, EventArgs e)
    {
        lblTotalCost.Visible = true;
        lblTotalSalePrice.Visible = true;

         showPageDiv.Visible = true;
        string searchSQLString = "Where";
        if (txtDescription.Text.Trim() != string.Empty)
        {
            searchSQLString += " INV_Iteam.IteamID in (" + txtDescription.Text.Trim() + ") ";
        }

        if (txtUser.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND INV_Iteam.Unit= '" + txtUser.Text.Trim() + "' ";
        }

        if (ddlPlace.SelectedValue.Equals("0") != true)
        {
            searchSQLString += " AND INV_Iteam.CampusID = " + ddlPlace.SelectedValue.Trim()+"";
        }

        if (ddlItemCode.SelectedValue.Equals("0") != true)
        {
            searchSQLString += " AND INV_Iteam.IteamCode = '" + ddlItemCode.SelectedValue.Trim() + "'";
        }

        if (ddlItemSubCategory.SelectedValue.Equals("0") != true)
        {
            searchSQLString += " AND INV_Iteam.IteamSubCategoryID = " + ddlItemSubCategory.SelectedValue.ToString();
        }

        if (searchSQLString.StartsWith("Where AND"))
        {
            searchSQLString = searchSQLString.Replace("Where AND", "Where ");
        }

        if (searchSQLString.Equals("Where") != true)
        {
            lblTotalCost.Text = "0";
            lblTotalSalePrice.Text = "0";

            DataSet ds = INV_IteamManager.GetINV_IteamBySearchSQLString(searchSQLString);
            gvINV_Iteam.DataSource = ds.Tables[0];
            gvINV_Iteam.DataBind();
            string totalItem = gvINV_Iteam.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblTotalItem.Text = "Total Item : " + totalItems[0];
            showPageDiv.Visible = false;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lblTotalCost.Text = (decimal.Parse(dr["Price"].ToString()) + decimal.Parse(lblTotalCost.Text)).ToString("0");
                lblTotalSalePrice.Text = (decimal.Parse(dr["Quantity"].ToString()) + decimal.Parse(lblTotalSalePrice.Text)).ToString("0");
            }

        }
        else
        {
            INV_IteamManager.LoadINV_IteamPage(gvINV_Iteam, rptPager, 1, ddlPageSize);
            string totalItem = gvINV_Iteam.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblTotalItem.Text = "Total Item : " + totalItems[0];

            foreach (GridViewRow gv in gvINV_Iteam.Rows)
            {
                lblTotalCost.Text = (decimal.Parse(((Label)gv.FindControl("lblPrice")).Text) + decimal.Parse(lblTotalCost.Text)).ToString("0");
                lblTotalSalePrice.Text = (decimal.Parse(((TextBox)gv.FindControl("txtQuantity")).Text) + decimal.Parse(lblTotalSalePrice.Text)).ToString("0");
            }

        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        INV_IteamManager.LoadINV_IteamPage(gvINV_Iteam, rptPager, 1, ddlPageSize);
        string totalItem = gvINV_Iteam.Rows.Count.ToString("N");
        string[] totalItems = totalItem.Split('.');
        lblTotalItem.Text = "Total Item : " + totalItems[0];

        foreach (GridViewRow gv in gvINV_Iteam.Rows)
        {
            lblTotalCost.Text = (decimal.Parse(((Label)gv.FindControl("lblPrice")).Text) + decimal.Parse(lblTotalCost.Text)).ToString("0");
            lblTotalSalePrice.Text = (decimal.Parse(((TextBox)gv.FindControl("txtQuantity")).Text) + decimal.Parse(lblTotalSalePrice.Text)).ToString("0");
        }

    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        INV_IteamManager.LoadINV_IteamPage(gvINV_Iteam, rptPager, pageIndex, ddlPageSize);
        string totalItem = gvINV_Iteam.Rows.Count.ToString("N");
        string[] totalItems = totalItem.Split('.');
        lblTotalItem.Text = "Total Item : " + totalItems[0];

        foreach (GridViewRow gv in gvINV_Iteam.Rows)
        {
            lblTotalCost.Text = (decimal.Parse(((Label)gv.FindControl("lblPrice")).Text) + decimal.Parse(lblTotalCost.Text)).ToString("0");
            lblTotalSalePrice.Text = (decimal.Parse(((TextBox)gv.FindControl("txtQuantity")).Text) + decimal.Parse(lblTotalSalePrice.Text)).ToString("0");
        }

        
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminINV_Iteam.aspx?ID=0");
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminINV_Iteam.aspx?ID=" + id);
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = INV_IteamManager.DeleteINV_Iteam(Convert.ToInt32(linkButton.CommandArgument));
        processInitialGrid();
    }

    private void processInitialGrid()
    {
        INV_IteamManager.LoadINV_IteamPage(gvINV_Iteam, rptPager, 1, ddlPageSize);

        foreach (GridViewRow gv in gvINV_Iteam.Rows)
        {
            lblTotalCost.Text = (decimal.Parse(((Label)gv.FindControl("lblPrice")).Text) + decimal.Parse(lblTotalCost.Text)).ToString("0");
            lblTotalSalePrice.Text = (decimal.Parse(((TextBox)gv.FindControl("txtQuantity")).Text) + decimal.Parse(lblTotalSalePrice.Text)).ToString("0");
        }

    }

    protected void btnAction_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in gvINV_Iteam.Rows)
        {
            CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");
            HiddenField hfIteamID = (HiddenField)gr.FindControl("hfIteamID");
            TextBox txtQuantity = (TextBox)gr.FindControl("txtQuantity");
            if (chkSelect.Checked)
            {
                INV_Iteam iNV_Iteam = INV_IteamManager.GetINV_IteamByIteamID(Int32.Parse(hfIteamID.Value));
                iNV_Iteam.UpdatedBy = Profile.card_id;
                iNV_Iteam.UpdatedDate = DateTime.Now;

                if (ddlAction.SelectedItem.Text == "Return to Store")
                {
                    iNV_Iteam.IteamCode = ddlAction.SelectedValue;
                }
                else if (ddlAction.SelectedItem.Text == "Return to Library")
                {
                    //iNV_Iteam.CampusID = int.Parse(ddlCampusID.SelectedValue);
                    iNV_Iteam.IteamCode = ddlAction.SelectedValue;
                }
                else if (ddlAction.SelectedItem.Text.Contains("-->"))
                {
                    iNV_Iteam.CampusID = int.Parse(ddlCampusID.SelectedValue);
                    iNV_Iteam.IteamCode = ddlAction.SelectedValue;
                }
                else if (ddlAction.SelectedItem.Text == "Sale")
                {
                    iNV_Iteam.IteamCode = ddlAction.SelectedValue;
                    iNV_Iteam.Quantity = decimal.Parse(txtQuantity.Text);
                    iNV_Iteam.Unit = txtActionTo.Text;
                }
                else if (ddlAction.SelectedItem.Text == "Free")
                {
                    iNV_Iteam.IteamCode = ddlAction.SelectedValue;
                    iNV_Iteam.Quantity = 0;
                    iNV_Iteam.Unit = txtActionTo.Text;
                }
                else if (ddlAction.SelectedItem.Text == "Issue")
                {
                    iNV_Iteam.IteamCode = ddlAction.SelectedValue;
                    iNV_Iteam.Unit = txtActionTo.Text;
                }
                else if (ddlAction.SelectedItem.Text == "Reject")
                {
                    iNV_Iteam.IteamCode = ddlAction.SelectedValue;
                    iNV_Iteam.Unit = txtActionTo.Text;
                }
                else if (ddlAction.SelectedItem.Text == "Prize Book")
                {
                    iNV_Iteam.IteamCode = ddlAction.SelectedValue;
                    iNV_Iteam.Quantity = 0;
                    iNV_Iteam.Unit = txtActionTo.Text;
                }
                else if (ddlAction.SelectedItem.Text == "Teacher copy")
                {
                    iNV_Iteam.IteamCode = ddlAction.SelectedValue;
                    iNV_Iteam.Quantity = 0;
                    iNV_Iteam.Unit = txtActionTo.Text;
                }

                bool resutl = INV_IteamManager.UpdateINV_Iteam(iNV_Iteam);
            }
        }

        btnIssueSearch_Click(this, new EventArgs());
    }

    private void CampusIDLoad()
    {
        try
        {
            DataSet ds = INV_StoreManager.GetDropDownListAllINV_Store();
            ddlCampusID.DataValueField = "StoreID";
            ddlCampusID.DataTextField = "StoreName";
            ddlCampusID.DataSource = ds.Tables[0];
            ddlCampusID.DataBind();
            ddlCampusID.Items.Insert(0, new ListItem("Select Store >>", "0"));

            ddlPlace.DataValueField = "StoreID";
            ddlPlace.DataTextField = "StoreName";
            ddlPlace.DataSource = ds.Tables[0];
            ddlPlace.DataBind();
            ddlPlace.Items.Insert(0, new ListItem("Any", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

