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
 public partial class AdminHR_Documents : System.Web.UI.Page
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
                    showHR_DocumentsData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	HR_Documents hR_Documents = new HR_Documents ();
//	hR_Documents.DocumentsID=  int.Parse(ddlDocumentsID.SelectedValue);
    hR_Documents.EmployeeID = Profile.card_id;
	//hR_Documents.CvDocs=  txtCvDocs.Text;
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

        hR_Documents.CvDocs = dirUrl + "/" + fileName;
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message.ToString();
        //    lblMessage.Text = lblMessage.Text + "<br />Please rename your file. ";
        //}
    }
    else
    {
        hR_Documents.CvDocs = "../HR/upload/employeer/test.txt";
    }
	hR_Documents.JobAgreement=  txtJobAgreement.Text;
	hR_Documents.AddedBy=  Profile.card_id;
	hR_Documents.AddedDate=  DateTime.Now;
	hR_Documents.ModifiedBy=  Profile.card_id;
	hR_Documents.ModifiedDate=  DateTime.Now;
	int resutl =HR_DocumentsManager.InsertHR_Documents(hR_Documents);
	Response.Redirect("AdminDisplayHR_Documents.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_Documents hR_Documents = new HR_Documents ();
	hR_Documents.DocumentsID=  int.Parse(Request.QueryString["ID"].ToString());
    hR_Documents.EmployeeID = Profile.card_id;
	//hR_Documents.CvDocs=  txtCvDocs.Text;
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

        hR_Documents.CvDocs = dirUrl + "/" + fileName;
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message.ToString();
        //    lblMessage.Text = lblMessage.Text + "<br />Please rename your file. ";
        //}
    }
    else
    {
        hR_Documents.CvDocs = hR_Documents.CvDocs;
    }
	hR_Documents.JobAgreement=  txtJobAgreement.Text;
	hR_Documents.AddedBy=  Profile.card_id;
	hR_Documents.AddedDate=  DateTime.Now;
	hR_Documents.ModifiedBy=  Profile.card_id;
	hR_Documents.ModifiedDate=  DateTime.Now;
	bool  resutl =HR_DocumentsManager.UpdateHR_Documents(hR_Documents);
	Response.Redirect("AdminDisplayHR_Documents.aspx");
	}
	private void showHR_DocumentsData()
	{
	 	HR_Documents hR_Documents  = new HR_Documents ();
	 	hR_Documents = HR_DocumentsManager.GetHR_DocumentsByDocumentsID(Int32.Parse(Request.QueryString["ID"]));
	 	 
	 	//txtCvDocs.Text =hR_Documents.CvDocs.ToString();
	 	txtJobAgreement.Text =hR_Documents.JobAgreement.ToString();
	}
	
 
}

