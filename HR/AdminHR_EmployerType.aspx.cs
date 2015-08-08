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
public partial class AdminHR_EmployerType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadHR_EmployerTypeData();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_EmployerTypeData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_EmployerType hR_EmployerType = new HR_EmployerType();
        //	hR_EmployerType.EmployerType=  int.Parse(txtEmployerType.Text);
        hR_EmployerType.EmployerTypeName = txtEmployerTypeName.Text;
        string userID = Profile.card_id;
        hR_EmployerType.AddedBy = userID;
        hR_EmployerType.AddedDate = DateTime.Now;
        hR_EmployerType.UpdatedBy = userID;
        hR_EmployerType.UpdateDate = DateTime.Now;
        int resutl = HR_EmployerTypeManager.InsertHR_EmployerType(hR_EmployerType);
        Response.Redirect("AdminDisplayHR_EmployerType.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_EmployerType hR_EmployerType = new HR_EmployerType();
        hR_EmployerType.EmployerType = int.Parse(Request.QueryString["ID"].ToString());
        hR_EmployerType.EmployerTypeName = txtEmployerTypeName.Text;
        string userID = Profile.card_id;
        hR_EmployerType.AddedBy = userID;
        hR_EmployerType.AddedDate = DateTime.Now;
        hR_EmployerType.UpdatedBy = userID;
        hR_EmployerType.UpdateDate = DateTime.Now;
        bool resutl = HR_EmployerTypeManager.UpdateHR_EmployerType(hR_EmployerType);
        Response.Redirect("AdminDisplayHR_EmployerType.aspx");
    }

    private void showHR_EmployerTypeData()
    {
        HR_EmployerType hR_EmployerType = new HR_EmployerType();
        hR_EmployerType = HR_EmployerTypeManager.GetHR_EmployerTypeByEmployerType(Int32.Parse(Request.QueryString["ID"]));
        txtEmployerTypeName.Text = hR_EmployerType.EmployerTypeName.ToString();
    }
}

