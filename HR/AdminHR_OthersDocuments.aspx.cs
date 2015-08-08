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
using System.IO;
 public partial class AdminHR_OthersDocuments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showHR_OthersDocumentsData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	HR_OthersDocuments hR_OthersDocuments = new HR_OthersDocuments ();
//	hR_OthersDocuments.OthersDocumentsID=  int.Parse(ddlOthersDocumentsID.SelectedValue);
    hR_OthersDocuments.EmployeeID = Profile.card_id;
    hR_OthersDocuments.DocumentsType = ddlDocumentType.SelectedValue;
	//hR_OthersDocuments.DocumentName=  txtDocumentName.Text;
    if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
    {
        //try
        //{
            string dirUrl = "../HR/upload/employeer";
            string dirPath = Server.MapPath(dirUrl);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
            string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
            string filePath = Server.MapPath(fileUrl);
            uplFile.PostedFile.SaveAs(filePath);

            hR_OthersDocuments.DocumentName = dirUrl + "/" + fileName;
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message.ToString();
        //    lblMessage.Text = lblMessage.Text + "<br />Please rename your file. ";
        //}
    }
    else
    {
        hR_OthersDocuments.DocumentName = "../HR/upload/employeer/test.txt";
    }
	hR_OthersDocuments.AddedBy=  Profile.card_id;
	hR_OthersDocuments.AddedDate=  DateTime.Now;
	hR_OthersDocuments.ModifiedBy=  Profile.card_id;
	hR_OthersDocuments.ModifiedDate=  DateTime.Now;
	int resutl =HR_OthersDocumentsManager.InsertHR_OthersDocuments(hR_OthersDocuments);
	Response.Redirect("AdminDisplayHR_OthersDocuments.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_OthersDocuments hR_OthersDocuments = new HR_OthersDocuments ();
	hR_OthersDocuments.OthersDocumentsID=  int.Parse(Request.QueryString["ID"].ToString());
    hR_OthersDocuments.EmployeeID = Profile.card_id;
    hR_OthersDocuments.DocumentsType = ddlDocumentType.SelectedValue;
	//hR_OthersDocuments.DocumentName=  txtDocumentName.Text;
    if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
    {
        //try
        //{
            string dirUrl = "../HR/upload/employeer";
            string dirPath = Server.MapPath(dirUrl);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
            string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
            string filePath = Server.MapPath(fileUrl);
            uplFile.PostedFile.SaveAs(filePath);

            hR_OthersDocuments.DocumentName = dirUrl + "/" + fileName;
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message.ToString();
        //    lblMessage.Text = lblMessage.Text + "<br />Please rename your file. ";
        //}
    }
    else
    {
        hR_OthersDocuments.DocumentName = hR_OthersDocuments.DocumentName;
    }
	hR_OthersDocuments.AddedBy=  Profile.card_id;
	hR_OthersDocuments.AddedDate=  DateTime.Now;
	hR_OthersDocuments.ModifiedBy=  Profile.card_id;
	hR_OthersDocuments.ModifiedDate=  DateTime.Now;
	bool  resutl =HR_OthersDocumentsManager.UpdateHR_OthersDocuments(hR_OthersDocuments);
	Response.Redirect("AdminDisplayHR_OthersDocuments.aspx");
	}
	private void showHR_OthersDocumentsData()
	{
	 	HR_OthersDocuments hR_OthersDocuments  = new HR_OthersDocuments ();
	 	hR_OthersDocuments = HR_OthersDocumentsManager.GetHR_OthersDocumentsByOthersDocumentsID(Int32.Parse(Request.QueryString["ID"]));
	 
	 	 
	 	//txtDocumentName.Text =hR_OthersDocuments.DocumentName.ToString();
	}
	
	 
}

