using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Accounting_AccountVoucher : System.Web.UI.Page
{
    public static List<ACC_VoucherIteam> voucherItems = new List<ACC_VoucherIteam>();
    public static ACC_Voucher aCC_Voucher = new ACC_Voucher();
    static int index = 0;  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RowStatusIDLoad(ddlVouscherRowStatusID);
            RowStatusIDLoad(ddlVoucherItemRowStatus);

            HeadIDLoad();
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            #region  VoucherInfo


            aCC_Voucher.VoucherNo = txtVoucherNo.Text;
            aCC_Voucher.HeadID = ddlHeadID.Text != "" ? int.Parse(ddlHeadID.SelectedValue) : 0;
            aCC_Voucher.DebitOrCredit = txtDebitOrCredit.Text;
            aCC_Voucher.FromTo = txtFromTo.Text;
            aCC_Voucher.OnAccountOf = txtOnAccountOf.Text;
            aCC_Voucher.Amount = decimal.Parse(txtAmount.Text);
            aCC_Voucher.InWord = txtInWord.Text;
            aCC_Voucher.IsApproved = radIsApproved.Text != "" ? bool.Parse(radIsApproved.SelectedValue) : false;
            aCC_Voucher.ApprovalDate = DateTime.Parse(txtApprovalDate.Text);
            aCC_Voucher.VoucherDate = DateTime.Parse(txtVoucherDate.Text);
            aCC_Voucher.AddedBy = Profile.card_id;
            aCC_Voucher.AddedDate = DateTime.Now;
            aCC_Voucher.UpdatedBy = Profile.card_id;
            aCC_Voucher.UpdateDate = DateTime.Now;
            aCC_Voucher.RowStatusID = ddlVouscherRowStatusID.Text != "" ? int.Parse(ddlVouscherRowStatusID.SelectedValue) : 0;
            aCC_Voucher.Remarks = txtRemarks.Text;

            #endregion
        }
        catch (Exception ex)
        {
        }
        try
        {
            #region Voucher Item Info
            ACC_VoucherIteam aCC_VoucherIteam = new ACC_VoucherIteam();
            //	aCC_VoucherIteam.VoucherIteamID=  int.Parse(ddlVoucherIteamID.SelectedValue);
            aCC_VoucherIteam.VoucherIteamName = txtVoucherIteamName.Text;

            aCC_VoucherIteam.IteamCode = txtIteamCode.Text;
            aCC_VoucherIteam.Description = txtDescription.Text;
            aCC_VoucherIteam.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            aCC_VoucherIteam.Quantity = decimal.Parse(txtQuantity.Text);
            aCC_VoucherIteam.AddedBy = Profile.card_id;
            aCC_VoucherIteam.AddedDate = DateTime.Now;
            aCC_VoucherIteam.UpdatedBy = Profile.card_id;
            aCC_VoucherIteam.UpdateDate = DateTime.Now;
            aCC_VoucherIteam.RowStatus = ddlVoucherItemRowStatus.SelectedItem.Text;
            aCC_VoucherIteam.VoucherIteamID = index;


            if (voucherItems.Count > 0)
            {
                index = 0;
                List<ACC_VoucherIteam> items = new List<ACC_VoucherIteam>();
                foreach (ACC_VoucherIteam vitem in voucherItems)
                {

                    vitem.VoucherIteamID = index;
                    items.Add(vitem);
                    index++;

                }

                voucherItems.Clear();
                voucherItems = items;
            }

            voucherItems.Add(aCC_VoucherIteam);

            gvACC_VoucherIteam.DataSource = voucherItems;
            gvACC_VoucherIteam.DataBind();
         
            index++;
          
            #endregion
        }

        catch (Exception ex)
        {
        }
    }

    private void RowStatusIDLoad(DropDownList ddl)
    {
        try
        {
            DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
            ddl.DataValueField = "RowStatusID";
            ddl.DataTextField = "RowStatusName";
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void HeadIDLoad()
    {
        try
        {
            DataSet ds = ACC_HeadManager.GetDropDownListAllACC_Head();
            ddlHeadID.DataValueField = "HeadID";
            ddlHeadID.DataTextField = "HeadName";
            ddlHeadID.DataSource = ds.Tables[0];
            ddlHeadID.DataBind();
            ddlHeadID.Items.Insert(0, new ListItem("Select Head >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        //ACC_VoucherIteamManager.LoadACC_VoucherIteamPage(gvACC_VoucherIteam, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        //int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        //ACC_VoucherIteamManager.LoadACC_VoucherIteamPage(gvACC_VoucherIteam, rptPager, pageIndex, ddlPageSize);
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;

            index = Convert.ToInt32(linkButton.CommandArgument);

            ACC_VoucherIteam item = voucherItems.Find(x => x.VoucherIteamID == index);

            txtVoucherIteamName.Text = item.VoucherIteamName;

            txtIteamCode.Text = item.IteamCode;
            txtDescription.Text = item.Description;
            txtUnitPrice.Text = item.UnitPrice.ToString();
            txtQuantity.Text = item.Quantity.ToString();

            ddlVoucherItemRowStatus.SelectedItem.Text = item.RowStatus;

            item.VoucherIteamID = index;
        }

        catch (Exception ex)
        {
        }


    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {

        try
        {
            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;


            voucherItems.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));

            index = 0;
            List<ACC_VoucherIteam> items = new List<ACC_VoucherIteam>();
            foreach (ACC_VoucherIteam vitem in voucherItems)
            {

                vitem.VoucherIteamID = index;
                items.Add(vitem);
                index++;

            }
            voucherItems.Clear();
            voucherItems = items;
            gvACC_VoucherIteam.DataSource = voucherItems;
            gvACC_VoucherIteam.DataBind();
        }

        catch (Exception ex)
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int resutl = ACC_VoucherManager.InsertACC_Voucher(aCC_Voucher);

            if (resutl > 0)
            {
                ACC_VoucherIteam voucher = new ACC_VoucherIteam();

                foreach (ACC_VoucherIteam voucherItem in voucherItems)
                {
                   voucher.VoucherIteamName= voucherItem.VoucherIteamName;

                   voucher.IteamCode= voucherItem.IteamCode;
                   voucher.VoucherID= resutl;
                   voucher.Description= voucherItem.Description;
                   voucher.UnitPrice= voucherItem.UnitPrice;
                   voucher.Quantity= voucherItem.Quantity;
                   voucher.AddedBy= voucherItem.AddedBy;
                   voucher.AddedDate= voucherItem.AddedDate;
                   voucher.UpdatedBy= voucherItem.UpdatedBy;
                   voucher.UpdateDate= voucherItem.UpdateDate;
                   voucher.RowStatusID= voucherItem.RowStatusID;
                   int resutl1 = ACC_VoucherIteamManager.InsertACC_VoucherIteam(voucher);
                }
            }
        }

        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ACC_VoucherIteam item = voucherItems.Find(x => x.VoucherIteamID == index);

            item.VoucherIteamName = txtVoucherIteamName.Text;
            item.IteamCode = txtIteamCode.Text;
            item.Description = txtDescription.Text;
            item.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            item.Quantity = decimal.Parse(txtQuantity.Text);
            item.AddedBy = Profile.card_id;
            item.AddedDate = DateTime.Now;
            item.UpdatedBy = Profile.card_id;
            item.UpdateDate = DateTime.Now;
            item.RowStatus = ddlVoucherItemRowStatus.SelectedItem.Text;
            item.VoucherIteamID = index;

            index = 0;
            List<ACC_VoucherIteam> items = new List<ACC_VoucherIteam>();
            foreach (ACC_VoucherIteam vitem in voucherItems)
            {
                if (item.VoucherIteamID == index)
                {
                    items.Add(item);
                    index++;
                }
                else
                {

                    vitem.VoucherIteamID = index;
                    items.Add(vitem);
                    index++;
                }

            }
            voucherItems.Clear();
         
            voucherItems = items;

            //voucherItems.Add(item);
            gvACC_VoucherIteam.DataSource = voucherItems;
            gvACC_VoucherIteam.DataBind();
        }

        catch (Exception ex)
        {
        }
    }
}