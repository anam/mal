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

public partial class AdminSTD_ArchiveDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showSTD_ArchiveGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminSTD_ArchiveInsertUpdate.aspx?sTD_ArchiveID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminSTD_ArchiveInsertUpdate.aspx?sTD_ArchiveID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = STD_ArchiveManager.DeleteSTD_Archive(Convert.ToInt32(linkButton.CommandArgument));
        showSTD_ArchiveGrid();
    }

    private void showSTD_ArchiveGrid()
    {
        gvSTD_Archive.DataSource = STD_ArchiveManager.GetAllSTD_Archives();
        gvSTD_Archive.DataBind();
    }
}
