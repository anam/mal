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
            txtIssueDate.Text = DateTime.Today.ToString("dd MMM yyyy");
            txtValidDate.Text = DateTime.Today.AddMonths(6).ToString("dd MMM yyyy");
        }
    }
    

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string IDs = "";

        if (txtStudentIDs.Text != "")
        {
            IDs = txtStudentIDs.Text;
        }
        a_PrintID.HRef = "IDCard.aspx?IssueDate="+txtIssueDate.Text+"&ValidDate="+txtValidDate.Text+"&IDs=" + IDs ;
        
        lblIDCards.Text = "<iframe height='500px' width='400px' scrolling='yes' src='IDCard.aspx?IssueDate="+txtIssueDate.Text+"&ValidDate="+txtValidDate.Text+"&IDs=" + IDs + "'></iframe>";
    }
}