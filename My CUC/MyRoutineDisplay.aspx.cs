using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Class_RoutineDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadRoutine();
        }
    }

    private void loadRoutine()
    {
        try
        {
            Response.Redirect("~/Class/RoutineDisplay.aspx?ClassID=0&SubjectID=0&EmployeeID=" + (Profile.IsStudent ? "" : Profile.card_id) + "&StudentID=" + (Profile.IsStudent ? Profile.card_id : ""));            
        }
        catch (Exception ex)
        { }
    }

    
}