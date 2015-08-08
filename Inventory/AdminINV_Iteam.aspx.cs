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
public partial class AdminINV_Iteam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadINV_IteamData();
            CampusIDLoad();
            IteamCategoryIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showINV_IteamData();
            }
        }
    }

    private void IteamCategoryIDLoad()
    {
        try
        {
            DataSet ds = INV_IteamCategoryManager.GetDropDownListAllINV_IteamCategory();
            ddlIteamCategoryID.DataValueField = "IteamCategoryID";
            ddlIteamCategoryID.DataTextField = "IteamCategoryName";
            ddlIteamCategoryID.DataSource = ds.Tables[0];
            ddlIteamCategoryID.DataBind();
            ddlIteamCategoryID.Items.Insert(0, new ListItem("Select IteamCategory >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void IteamSubCategoryIDLoad(int CategoryID)
    {
        try
        {
            DataSet ds = INV_IteamSubCategoryManager.GetINV_IteamCategoryByIteamCategoryID(CategoryID, true);
            ddlIteamSubCategoryID.DataValueField = "IteamSubCategoryID";
            ddlIteamSubCategoryID.DataTextField = "IteamSubCategoryName";
            ddlIteamSubCategoryID.DataSource = ds.Tables[0];
            ddlIteamSubCategoryID.DataBind();
            ddlIteamSubCategoryID.Items.Insert(0, new ListItem("Select Item Sub Category >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            int SubCategory = 0;
            string categoryName = "";
            string SubCategoryName = "";


            if (txtCategory.Text != "")
            {
                INV_IteamCategory iNV_IteamCategory = new INV_IteamCategory();
                //	iNV_IteamCategory.IteamCategoryID=  int.Parse(ddlIteamCategoryID.SelectedValue);
                iNV_IteamCategory.IteamCategoryName = txtCategory.Text;
                iNV_IteamCategory.AddedBy = Profile.card_id;
                iNV_IteamCategory.AddedDate = DateTime.Now;
                iNV_IteamCategory.UpdatedBy = Profile.card_id;
                iNV_IteamCategory.UpdatedDate = DateTime.Now;
                int categoryID = INV_IteamCategoryManager.InsertINV_IteamCategory(iNV_IteamCategory);
                categoryName = txtCategory.Text;


                INV_IteamSubCategory iNV_IteamSubCategory = new INV_IteamSubCategory();
                //	iNV_IteamSubCategory.IteamSubCategoryID=  int.Parse(ddlIteamSubCategoryID.SelectedValue);
                iNV_IteamSubCategory.IteamSubCategoryName = txtSubCategory.Text;
                iNV_IteamSubCategory.IteamCategoryID = categoryID;
                iNV_IteamSubCategory.AddedBy = Profile.card_id;
                iNV_IteamSubCategory.AddedDate = DateTime.Now;
                iNV_IteamSubCategory.UpdatedBy = Profile.card_id;
                iNV_IteamSubCategory.UpdatedDate = DateTime.Now;
                SubCategory = INV_IteamSubCategoryManager.InsertINV_IteamSubCategory(iNV_IteamSubCategory);

                SubCategoryName = txtSubCategory.Text;
            }
            else if (txtSubCategory.Text != "")
            {
                INV_IteamSubCategory iNV_IteamSubCategory = new INV_IteamSubCategory();
                //	iNV_IteamSubCategory.IteamSubCategoryID=  int.Parse(ddlIteamSubCategoryID.SelectedValue);
                iNV_IteamSubCategory.IteamSubCategoryName = txtSubCategory.Text;
                iNV_IteamSubCategory.IteamCategoryID = int.Parse(ddlIteamCategoryID.SelectedValue);
                iNV_IteamSubCategory.AddedBy = Profile.card_id;
                iNV_IteamSubCategory.AddedDate = DateTime.Now;
                iNV_IteamSubCategory.UpdatedBy = Profile.card_id;
                iNV_IteamSubCategory.UpdatedDate = DateTime.Now;
                SubCategory = INV_IteamSubCategoryManager.InsertINV_IteamSubCategory(iNV_IteamSubCategory);
                
                categoryName = ddlIteamCategoryID.SelectedItem.Text;
                SubCategoryName = txtSubCategory.Text;
            }
            else
            {
                SubCategory = int.Parse(ddlIteamSubCategoryID.SelectedValue);
                categoryName = ddlIteamCategoryID.SelectedItem.Text;
                SubCategoryName = ddlIteamSubCategoryID.SelectedItem.Text;
            }

            string barcodes = categoryName + "  --->  " + SubCategoryName + "<br/><br/>" + "<table><tr>";
            int remaining = 5;
            for (int i = 0; i < int.Parse(txtNoOfItems.Text.Trim()); i++)
            {
                            
                INV_Iteam iNV_Iteam = new INV_Iteam();
                //	iNV_Iteam.IteamID=  int.Parse(ddlIteamID.SelectedValue);
                iNV_Iteam.CampusID =  int.Parse(ddlCampusID.SelectedValue);
                iNV_Iteam.IteamCode = txtIteamCode.Text;
                iNV_Iteam.Description = txtDescription.Text;
                iNV_Iteam.IteamSubCategoryID = SubCategory;
                iNV_Iteam.Price = decimal.Parse(txtPrice.Text);
                iNV_Iteam.Quantity = decimal.Parse(txtQuantity.Text);
                iNV_Iteam.Unit = txtUnit.Text;
                iNV_Iteam.AddedBy = Profile.card_id;
                iNV_Iteam.AddedDate = DateTime.Now;
                iNV_Iteam.UpdatedBy = Profile.card_id;
                iNV_Iteam.UpdatedDate = DateTime.Now;
                int resutl = INV_IteamManager.InsertINV_Iteam(iNV_Iteam);

                if (i % 5 == 0)
                {
                    barcodes += "</tr><tr>";
                    remaining = 4;
                }
                else
                {
                    remaining--;
                }

                barcodes += "<td><div style='overflow:hidden;margin-left:-12px;width:157px; height:30px;margin-top: 28px;'><img style='margin-top:-30px' src='http://www.bcgen.com/demo/linear-dbgs.aspx?D=";
                barcodes+=resutl.ToString()+"'/></div></td>";
            }

            for (int i = 0; i < remaining; i++)
            {
                barcodes += "<td></td>";
            }
            barcodes += "</tr></table>";

            lblBarCode.Text = barcodes;

            ItemBarcode itemBarcode = new ItemBarcode();

            itemBarcode.SubCategoryID = SubCategory;
            itemBarcode.NoOfItem = Int32.Parse(txtNoOfItems.Text);
            itemBarcode.BarcodeText = barcodes;
            itemBarcode.AddedDate = DateTime.Now;
            int result = ItemBarcodeManager.InsertItemBarcode(itemBarcode);
        }
        catch (Exception ex) { } 
        
        //Response.Redirect("AdminDisplayINV_Iteam.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            
            INV_Iteam iNV_Iteam = new INV_Iteam();
            iNV_Iteam.IteamID = int.Parse(Request.QueryString["ID"].ToString());
            iNV_Iteam.CampusID =int.Parse(ddlCampusID.SelectedValue);
            iNV_Iteam.IteamCode = txtIteamCode.Text;
            iNV_Iteam.Description = txtDescription.Text;
            iNV_Iteam.IteamSubCategoryID = int.Parse(ddlIteamSubCategoryID.SelectedValue);
            iNV_Iteam.Price = decimal.Parse(txtPrice.Text);
            iNV_Iteam.Quantity = decimal.Parse(txtQuantity.Text);
            iNV_Iteam.Unit = txtUnit.Text;
            iNV_Iteam.AddedBy = Profile.card_id;
            iNV_Iteam.AddedDate = DateTime.Now;
            iNV_Iteam.UpdatedBy = Profile.card_id;
            iNV_Iteam.UpdatedDate = DateTime.Now;
            bool resutl = INV_IteamManager.UpdateINV_Iteam(iNV_Iteam);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayINV_Iteam.aspx");
    }

    private void showINV_IteamData()
    {
        INV_Iteam iNV_Iteam = new INV_Iteam();
        iNV_Iteam = INV_IteamManager.GetINV_IteamByIteamID(Int32.Parse(Request.QueryString["ID"]));
        ddlCampusID.SelectedValue = iNV_Iteam.CampusID.ToString();
        txtIteamCode.Text = iNV_Iteam.IteamCode.ToString();
        txtDescription.Text = iNV_Iteam.Description.ToString();
        ddlIteamCategoryID.SelectedValue = iNV_Iteam.IteamCategoryID.ToString();
        ddlIteamCategoryID_SelectedIndexChanged(this, new EventArgs());
        ddlIteamSubCategoryID.SelectedValue = iNV_Iteam.IteamSubCategoryID.ToString();
        txtPrice.Text = iNV_Iteam.Price.ToString("N");
        txtQuantity.Text = iNV_Iteam.Quantity.ToString("N");
        txtUnit.Text = iNV_Iteam.Unit.ToString();
        string txtUpdatedBy_Text = iNV_Iteam.UpdatedBy.ToString();
        string txtUpdatedDate_Text = iNV_Iteam.UpdatedDate.ToString();
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
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void ddlIteamCategoryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIteamCategoryID.SelectedValue != "0")
        {
            IteamSubCategoryIDLoad(int.Parse(ddlIteamCategoryID.SelectedValue));
        }
    }
}

