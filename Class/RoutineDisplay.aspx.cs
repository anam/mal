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
            STD_RoutineTime routineTime = new STD_RoutineTime();
            routineTime.RoomID = Request.QueryString["RoomID"] == null ? 0 : int.Parse(Request.QueryString["RoomID"]);
            routineTime.RoutineID = Request.QueryString["RoutineID"] == null ? 0 : int.Parse(Request.QueryString["RoutineID"]);
            routineTime.ClassID = Request.QueryString["ClassID"] == null ? 0 : int.Parse(Request.QueryString["ClassID"]);
            routineTime.SubjectID = Request.QueryString["SubjectID"] == null ? 0 : int.Parse(Request.QueryString["SubjectID"]);
            routineTime.EmployeeID = Request.QueryString["EmployeeID"] == null ? "" : Request.QueryString["EmployeeID"];
            string StudentID = Request.QueryString["StudentID"] == null ? "" : Request.QueryString["StudentID"];
            lblRoutineDisplay.Text= STD_RoutineTimeManager.getRoutineTextDayTop(routineTime, StudentID);
            lblRoutineDisplay.Text = lblRoutineDisplay.Text.Replace("id='tblRoutineDisplay'", "border='1'");
            lblRoutineDisplay.Text = lblRoutineDisplay.Text.Replace("id='tblRoutineDisplayTeacher'", "border='1'");

            if (Request.QueryString["Archive"] != null)
            {
                STD_Archive sTD_Archive = new STD_Archive();

                sTD_Archive.Archive = lblRoutineDisplay.Text;
                sTD_Archive.AddedDate = DateTime.Now;
                int resutl = STD_ArchiveManager.InsertSTD_Archive(sTD_Archive);
            }
        }
        catch (Exception ex)
        { }
    }

    
}