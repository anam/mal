using System;
using System.Collections;
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

public partial class AdminFileDisplay : System.Web.UI.Page
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
        DataSet ds = CommonManager.SQLExec(@"SELECT [EmployeeID]
      ,[EmployeeNo]
      ,[EmployeeName]      
  FROM [HR_Employee]
  where RowStatusID=1 and EmployeeType =12
  order by EmployeeName");

        ListItem li = new ListItem("Select Employee...", "0");
        ddlTeacher.Items.Add(li);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (bool.Parse(dr["Flag"].ToString()) == true)
            {
                ListItem item = new ListItem(dr["EmployeeName"].ToString(), dr["EmployeeID"].ToString());
                ddlTeacher.Items.Add(item);
            }
        }

    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminFileInsertUpdate.aspx?fileID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminFileInsertUpdate.aspx?fileID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        //LinkButton linkButton = new LinkButton();
        //linkButton = (LinkButton)sender;
        //bool result = FileManager.DeleteFile(Convert.ToInt32(linkButton.CommandArgument));
        //showFileGrid();
    }

    private void showFileGrid()
    {

        string sql = @"select *  from  HR_TeacherInstallment 
            where AgreementID in (select AgreementID from HR_TeacherAgreement where TeacherID='"+ddlTeacher.SelectedValue+"')";
        
        gvFile.DataSource = CommonManager.SQLExec(sql).Tables[0];
        gvFile.DataBind();
    }

    protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        showFileGrid();
    }
}
