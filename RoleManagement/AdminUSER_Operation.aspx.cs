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
public partial class AdminUSER_Operation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadUSER_OperationData();
            RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showUSER_OperationData();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        USER_Operation uSER_Operation = new USER_Operation();
        //	uSER_Operation.OperationID=  int.Parse(ddlOperationID.SelectedValue);
        uSER_Operation.OperationName = txtOperationName.Text;
        uSER_Operation.Description = txtDescription.Text;
        uSER_Operation.AddedBy = "Admin";
        uSER_Operation.AddedDate = DateTime.Now;
        uSER_Operation.UpdatedBy = "Admin";
        uSER_Operation.UpdatedDate = DateTime.Now;
        uSER_Operation.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
        int resutl = USER_OperationManager.InsertUSER_Operation(uSER_Operation);
        Response.Redirect("AdminDisplayUSER_Operation.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        USER_Operation uSER_Operation = new USER_Operation();
        uSER_Operation.OperationID = int.Parse(Request.QueryString["ID"].ToString());
        uSER_Operation.OperationName = txtOperationName.Text;
        uSER_Operation.Description = txtDescription.Text;
        uSER_Operation.AddedBy = "Admin";
        uSER_Operation.AddedDate = DateTime.Now;
        uSER_Operation.UpdatedBy = "Admin";
        uSER_Operation.UpdatedDate = DateTime.Now;
        uSER_Operation.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
        bool resutl = USER_OperationManager.UpdateUSER_Operation(uSER_Operation);
        Response.Redirect("AdminDisplayUSER_Operation.aspx");
    }
    private void showUSER_OperationData()
    {
        USER_Operation uSER_Operation = new USER_Operation();
        uSER_Operation = USER_OperationManager.GetUSER_OperationByOperationID(Int32.Parse(Request.QueryString["ID"]));
        txtOperationName.Text = uSER_Operation.OperationName.ToString();
        txtDescription.Text = uSER_Operation.Description.ToString();
        ddlRowStatusID.SelectedValue = uSER_Operation.RowStatusID.ToString();
    }

    private void RowStatusIDLoad()
    {
        try
        {
            DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
            ddlRowStatusID.DataValueField = "RowStatusID";
            ddlRowStatusID.DataTextField = "RowStatusName";
            ddlRowStatusID.DataSource = ds.Tables[0];
            ddlRowStatusID.DataBind();
            ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

