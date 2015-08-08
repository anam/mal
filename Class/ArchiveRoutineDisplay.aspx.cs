using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Class_ArchiveRoutineDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ArchiveID"] != null)
        {
            lblRoutine.Text = STD_ArchiveManager.GetSTD_ArchiveByID(int.Parse(Request.QueryString["ArchiveID"])).Archive;
        }
    }
}