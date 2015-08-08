using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_DefaultHR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadEmployee();
        }
    }
    private void loadEmployee()
    {
        DataSet ds = HR_EmployeeManager.getAllEmployeeListDepartmentWise();

        gvEmpoyeeList.DataSource = ds.Tables[0];
        gvEmpoyeeList.DataBind();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string IDs = "";

        if (txtEmployeeIDs.Text != "")
        {
            IDs = txtEmployeeIDs.Text;
        }
        else
        {
            foreach (GridViewRow gr in gvEmpoyeeList.Rows)
            {
                if (((CheckBox)gr.FindControl("chkSelect")).Checked)
                {
                    IDs += "," + ((HiddenField)gr.FindControl("hfID")).Value;
                }
            }
        }
        a_PrintID.HRef = "IDCard.aspx?&IDs=" + IDs;
        lblIDCards.Text = "<iframe height='500px;' scrolling='yes' src='IDCard.aspx?&IDs=" + IDs + "'></iframe>";
    }
}