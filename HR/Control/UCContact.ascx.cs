using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_Control_UCContact : System.Web.UI.UserControl
{
    public DataSet DsContact
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (DsContact != null)
        {
            DataTable dtcontact = DsContact.Tables[0];
            if (dtcontact.Rows.Count > 0)
            {
                lblContactID.Text = dtcontact.Rows[0]["ContactID"].ToString();
                lblCurrentAddress.Text = dtcontact.Rows[0]["CurrentAddress"].ToString();

                lblPermanentAddress.Text = dtcontact.Rows[0]["PermanentAddress"].ToString();
                lblTelephone.Text = dtcontact.Rows[0]["Telephone"].ToString();
                lblMobile.Text = dtcontact.Rows[0]["Mobile"].ToString();
                lblEmail.Text = dtcontact.Rows[0]["Email"].ToString();
            }
            
        }
    }
    //protected void btnEditContact_Click(object sender, EventArgs e)
    //{
    //    //

    //    //AdminHR_Contact.aspx
    //    var contactid = lblContactID.Text;
    //    var eimployeeID = Request.QueryString["ID"];
    //    Response.Redirect("~/HR/AdminHR_Contact.aspx?ID=" + contactid + "&eid=" + eimployeeID);
    //}
}