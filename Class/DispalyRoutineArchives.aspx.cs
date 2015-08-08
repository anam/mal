using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

public partial class Class_Class_Display_RoutineTime_ByValues : System.Web.UI.Page
{
    string prevDayName = String.Empty, prevColName = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadArchiveDate();
        }
    }

    private void loadArchiveDate()
    {
        ListItem li = new ListItem("Select Date", "0");
        ddlArchivedDate.Items.Add(li);

        List<STD_Archive> archives = new List<STD_Archive>();
        archives = STD_ArchiveManager.GetAllSTD_Archives();
        foreach (STD_Archive archive in archives)
        {
            ListItem item = new ListItem(archive.AddedDate.ToString("dd MMM yyyy hh:mm tt"), archive.STD_ArchiveID.ToString());
            ddlArchivedDate.Items.Add(item);
        }   
    }
    
    protected void ddlArchivedDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblLinkToprint.Text = "<a target='_blank' href='ArchiveRoutineDisplay.aspx?ArchiveID=" + ddlArchivedDate.SelectedValue + "'>Print</a>";
    }
}
