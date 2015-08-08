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

public partial class AdminSTD_ArchiveInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["sTD_ArchiveID"] != null)
            {
                int sTD_ArchiveID = Int32.Parse(Request.QueryString["sTD_ArchiveID"]);
                if (sTD_ArchiveID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ArchiveData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        STD_Archive sTD_Archive = new STD_Archive();

        sTD_Archive.Archive = txtArchive.Text;
        sTD_Archive.AddedDate = DateTime.Now;
        int resutl = STD_ArchiveManager.InsertSTD_Archive(sTD_Archive);
        Response.Redirect("AdminSTD_ArchiveDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        STD_Archive sTD_Archive = new STD_Archive();
        sTD_Archive = STD_ArchiveManager.GetSTD_ArchiveByID(Int32.Parse(Request.QueryString["sTD_ArchiveID"]));
        STD_Archive tempSTD_Archive = new STD_Archive();
        tempSTD_Archive.STD_ArchiveID = sTD_Archive.STD_ArchiveID;

        tempSTD_Archive.Archive = txtArchive.Text;
        tempSTD_Archive.AddedDate = DateTime.Now;
        bool result = STD_ArchiveManager.UpdateSTD_Archive(tempSTD_Archive);
        Response.Redirect("AdminSTD_ArchiveDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtArchive.Text = "";
    }
    private void showSTD_ArchiveData()
    {
        STD_Archive sTD_Archive = new STD_Archive();
        sTD_Archive = STD_ArchiveManager.GetSTD_ArchiveByID(Int32.Parse(Request.QueryString["sTD_ArchiveID"]));

        txtArchive.Text = sTD_Archive.Archive;
    }
}
