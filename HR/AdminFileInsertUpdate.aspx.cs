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

public partial class AdminFileInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadRowStatus();
            if (Request.QueryString["fileID"] != null)
            {
                int fileID = Int32.Parse(Request.QueryString["fileID"]);
                if (fileID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showFileData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        File file = new File();

        file.FileContent = txtFileContent.Text;
        file.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        file.AddedDate = DateTime.Now;
        file.AddedBy = txtAddedBy.Text;
        int resutl = FileManager.InsertFile(file);
        Response.Redirect("AdminFileDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        File file = new File();
        file = FileManager.GetFileByID(Int32.Parse(Request.QueryString["fileID"]));
        File tempFile = new File();
        tempFile.FileID = file.FileID;

        tempFile.FileContent = txtFileContent.Text;
        tempFile.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        tempFile.AddedDate = DateTime.Now;
        tempFile.AddedBy = txtAddedBy.Text;
        bool result = FileManager.UpdateFile(tempFile);
        Response.Redirect("AdminFileDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtFileContent.Text = "";
        ddlRowStatus.SelectedIndex = 0;
        txtAddedBy.Text = "";
    }
    private void showFileData()
    {
        File file = new File();
        file = FileManager.GetFileByID(Int32.Parse(Request.QueryString["fileID"]));

        txtFileContent.Text = file.FileContent;
        ddlRowStatus.SelectedValue = file.RowStatusID.ToString();
        txtAddedBy.Text = file.AddedBy;
    }
    private void loadRowStatus()
    {
        ListItem li = new ListItem("Select RowStatus...", "0");
        ddlRowStatus.Items.Add(li);

        List<RowStatus> rowStatuss = new List<RowStatus>();
        rowStatuss = RowStatusManager.GetAllRowStatuss();
        foreach (RowStatus rowStatus in rowStatuss)
        {
            ListItem item = new ListItem(rowStatus.RowStatusName.ToString(), rowStatus.RowStatusID.ToString());
            ddlRowStatus.Items.Add(item);
        }
    }
}
