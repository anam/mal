using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Class_Class_Display_Routine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["tblRoutineTemplate"] != null)
            {
                Comm_Display_Routine dRoutine = new Comm_Display_Routine();
                dvAddRoutine.InnerHtml = dRoutine.ConvertDataTableToHTMLString(((DataSet)Session["tblRoutineTemplate"]).Tables["tblRoutineTemplate"], "2px", "1", true, true);
            }
        }
    }
}