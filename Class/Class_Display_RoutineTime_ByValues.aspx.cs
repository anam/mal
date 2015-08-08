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
            ClassIDLoad();
            SubjectIDLoad();
            EmployeeIDLoad();
            CampuesLoad();

            if (Request.QueryString["IsDelete"] != null)
            {
                if (Request.QueryString["IsDelete"] == "1" && Request.QueryString["RoutineTimeID"] != null) { STD_RoutineTimeManager.DeleteSTD_RoutineTime(int.Parse(Request.QueryString["RoutineTimeID"])); }
                if (Request.QueryString["CampusID"] != null) { ddlCampus.SelectedValue = Request.QueryString["CampusID"]; ddlCampus_SelectedIndexChanged(this, new EventArgs()); }
                if (Request.QueryString["RoutineID"] != null) { ddlRoutineID.SelectedValue = Request.QueryString["RoutineID"]; }
                if (Request.QueryString["ClassID"] != null) { ddlClassID.SelectedValue = Request.QueryString["ClassID"]; ddlClassID_OnSelectedIndexChanged(this, new EventArgs()); }
                if (Request.QueryString["SubjectID"] != null) { ddlSubjectID.SelectedValue = Request.QueryString["SubjectID"]; ddlSubjectID_SelectedIndexChanged(this, new EventArgs()); }
                if (Request.QueryString["EmployeeID"] != null) { ddlEmployeeID.SelectedValue = Request.QueryString["EmployeeID"]; }
                loadRoutine();
            }
        }

    }
    private void CampuesLoad()
    {
        try
        {
            DataSet ds = STD_CampusManager.GetDropDownListAllSTD_Campus();
            ddlCampus.DataValueField = "CampusID";
            ddlCampus.DataTextField = "CampusName";
            ddlCampus.DataSource = ds.Tables[0];
            ddlCampus.DataBind();
            ddlCampus.Items.Insert(0, new ListItem("Select Campus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCampus.SelectedValue != null)
        {
            RoutineIDLoad(ddlCampus.SelectedValue);
        }
    }
    private void RoutineIDLoad(string campusID)
    {
        try
        {
            DataSet ds = STD_RoutineManager.GetDropDownListAllSTD_Routine();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["RoutineName"].ToString() != campusID)
                    dr.Delete();
            }

            ddlRoutineID.DataValueField = "RoutineID";
            ddlRoutineID.DataTextField = "RoutineName";
            ddlRoutineID.DataSource = ds.Tables[0];
            ddlRoutineID.DataBind();
            //ddlRoutineID.Items.Insert(0, new ListItem("Select Routine >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void loadRoutine()
    {
        STD_RoutineTime routineTime = new STD_RoutineTime();
        routineTime.RoomID = 0;
        routineTime.RoutineID = ddlCampus.SelectedValue=="0"?0: int.Parse(ddlRoutineID.SelectedValue);
        routineTime.ClassID = int.Parse(ddlClassID.SelectedValue);
        routineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
        routineTime.EmployeeID = ddlEmployeeID.SelectedValue == "0" ? "" : ddlEmployeeID.SelectedValue;
        string StudentID = "";
        lblRoutineDisplay.Text = STD_RoutineTimeManager.getRoutineTextDayTop(routineTime, StudentID).Replace(" style='display:none;'", "");  
    }
   
    private void ClassIDLoad()
    {
        try
        {
            DataSet ds = STD_ClassManager.GetDropDownListAllSTD_Class();
            ddlClassID.DataValueField = "ClassID";
            ddlClassID.DataTextField = "ClassName";
            ddlClassID.DataSource = ds.Tables[0];
            ddlClassID.DataBind();
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    protected void ddlClassID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedValue != null)
        {
            int ClassID = int.Parse(ddlClassID.SelectedValue);
            SubjectIDLoad(ClassID);

        }
    }

    private void SubjectIDLoad()
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_Subject();
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void SubjectIDLoad(int ClassID)
    {
        try
        {
            ddlSubjectID.Items.Clear();

            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_SubjectByClassID(ClassID);

            ListItem li = new ListItem("Select Subject >>", "0");
            ddlSubjectID.Items.Add(li);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["SubjectName"].ToString() + " (" + dr["NoOfStudents"].ToString() + " Students)", dr["SubjectID"].ToString());
                ddlSubjectID.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    private void EmployeeIDLoad()
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
            //ddlEmployeeID.Items.Insert(0, new ListItem("Mehdi Sir", "96b72550-3649-45c6-a1f5-0474a77f4fa5"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedValue != null)
        {
            int ClassID = int.Parse(ddlClassID.SelectedValue);
            int SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            EmployeeIDLoadByClassID(ClassID, SubjectID);
        }
    }

    private void EmployeeIDLoadByClassID(int ClassID, int SubjectID)
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_EmployeClassID(ClassID, SubjectID);
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
            //ddlEmployeeID.Items.Insert(0, new ListItem("Mehdi Sir", "96b72550-3649-45c6-a1f5-0474a77f4fa5"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    protected void btnShowRoutine_Click(object sender, EventArgs e)
    {
        loadRoutine();
        //string subjectID = String.Empty, classID = String.Empty, employeeID = String.Empty;

        //if (ddlSubject.SelectedValue != "0")
        //    subjectID = ddlSubject.SelectedValue;
        //else
        //    subjectID = null;

        //if (ddlClassID.SelectedValue != "0")
        //    classID = ddlClassID.SelectedValue;
        //else
        //    classID = null;

        //if (ddlEmployeeID.SelectedValue != "0")
        //    employeeID = ddlEmployeeID.SelectedValue;
        //else
        //    employeeID = null;


        //GenerateRoutine(classID, employeeID, subjectID);
    }

    #region GenerateRoutine
    private void GenerateRoutine(string classID, string employeeID, string subjectID)
    {

        Hashtable htRoutineValues = new Hashtable();

        string crValue = string.Empty;

        DataRow newRow = null;
        DataSet dsRoutine = new DataSet();
        DataSet dsWeekDay = new DataSet();

        dsRoutine.Clear();
        STD_RoutineByValueManager STD_RoutineByValueManager = new STD_RoutineByValueManager();
        dsRoutine = STD_RoutineByValueManager.GetSTD_RoutineByParam(subjectID, employeeID, classID);
        dsWeekDay = STD_RoutineByValueManager.GetSTD_WeekDay();
        //string[] weekDayNames1= dsWeekDay.Tables[0].AsEnumerable().Select(dr => dr["Name"].ToString()).ToArray();

        DataSet ds = GetTemplate();

        if (dsRoutine.Tables[0].Columns.Contains("subjectname"))
            dsRoutine.Tables[0].Columns.Remove("subjectname");

        if (dsRoutine.Tables[0].Columns.Contains("Order"))
            dsRoutine.Tables[0].Columns.Remove("Order");

        string[] columnNames = (from dc in dsRoutine.Tables[0].Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();
        string[] allColumnNames = (from dc in ds.Tables["tblRoutineTemplate"].Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

        //string[] weekDayNames = { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thrusday", "Friday", "", "Days" };
        //string[] weekDayNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
        string[] weekDayNames = dsWeekDay.Tables[0].AsEnumerable().Select(dr => dr["Name"].ToString()).ToArray();
        
        if(dsRoutine.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsRoutine.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < columnNames.Count(); j++)
                {
                    string rowValue = String.Empty, columnName = String.Empty, currDay = String.Empty;
                    rowValue = dsRoutine.Tables[0].Rows[i][j].ToString();
                    currDay = dsRoutine.Tables[0].Rows[i][0].ToString();
                    columnName = columnNames[j].ToString();

                    if (prevDayName == currDay)
                    {
                        string parameter = "Days = '" + prevDayName + "'";

                        if (!weekDayNames.Contains(columnName))
                        {
                            if (htRoutineValues[columnName] == null)
                            {
                                htRoutineValues.Add(columnName, rowValue);
                                crValue = htRoutineValues[columnName].ToString();
                                rowValue = crValue;
                            }
                            else
                            {
                                if ((rowValue != htRoutineValues[columnName].ToString()) && rowValue != "")
                                {
                                    if (htRoutineValues[columnName].ToString() == "" || rowValue == "")
                                        crValue = rowValue;
                                    else
                                        crValue = rowValue + ", " + htRoutineValues[columnName].ToString();

                                    htRoutineValues[columnName] = crValue;
                                    rowValue = crValue;
                                }
                            }
                        }


                        DataRow[] rows = ds.Tables["tblRoutineTemplate"].Select(parameter);
                        string rowname = columnName;
                        if (allColumnNames.Contains(columnName))
                        {
                            if (rowValue != String.Empty)
                            {
                                rows[0][rowname] = rowValue;
                                rows[0].AcceptChanges();
                                rows[0].SetModified();
                            }
                        }
                    }
                    else
                    {
                        htRoutineValues.Clear();
                        if (!weekDayNames.Contains(columnName))
                        {
                            htRoutineValues.Add(columnName, rowValue);
                        }
                        newRow = ds.Tables["tblRoutineTemplate"].NewRow();
                        string rowname = columnName;
                        if (allColumnNames.Contains(columnName))
                        {
                            newRow[rowname] = rowValue;
                            ds.Tables["tblRoutineTemplate"].Rows.Add(newRow);
                        }
                    }
                    prevDayName = dsRoutine.Tables[0].Rows[i][0].ToString();
                    rowValue = String.Empty;
                    prevColName = columnName;
                }
            }
            Session["tblRoutineTemplate"] = ds;
            Comm_Display_Routine dRoutine = new Comm_Display_Routine();
            dvAddRoutine.InnerHtml = dRoutine.ConvertDataTableToHTMLString(ds.Tables["tblRoutineTemplate"], "2px", "1", true, true);
        }
        else
        {
            ds.Clear();
            Session["tblRoutineTemplate"] = null;
            dvAddRoutine.InnerHtml = "No Record Found";
        }
    }
    #endregion

    #region GetTemplate
    private DataSet GetTemplate()
    {
        DataSet ds = new DataSet();
        try
        {
            STD_RoutineByValueManager STD_RoutineByValueManager = new STD_RoutineByValueManager();
            ds = STD_RoutineByValueManager.GetSTD_GetColumnNames();
            DataTable table = new DataTable("tblRoutineTemplate");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string columnName = ds.Tables[0].Rows[i][0].ToString();
                table.Columns.Add(columnName, typeof(string));
            }

            ds.Tables.Add(table);
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

        return ds;
    }
    #endregion

    protected void btnPrint_Click(object sender, EventArgs e)
    {

        STD_RoutineTime routineTime = new STD_RoutineTime();
        routineTime.RoomID = 0;
        routineTime.RoutineID = ddlCampus.SelectedValue == "0" ? 0 : int.Parse(ddlRoutineID.SelectedValue);
        routineTime.ClassID = int.Parse(ddlClassID.SelectedValue);
        routineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
        routineTime.EmployeeID = ddlEmployeeID.SelectedValue == "0" ? "" : ddlEmployeeID.SelectedValue;
        //string StudentID = "";

        Response.Redirect("~/Class/RoutineDisplay.aspx?RoutineID=" + routineTime.RoutineID.ToString() + "&ClassID=" + routineTime.ClassID.ToString() + "&SubjectID=" + routineTime.SubjectID.ToString() + "&EmployeeID=" + routineTime.EmployeeID);
        //if (Session["tblRoutineTemplate"] != null)
        //{

        //    Response.Redirect("~/Class/Class_Display_Routine.aspx");
        //    Session["tblRoutineTemplate"] = null;
        //}
        //else
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("alert('No Record Found')");
        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);

        //}

    }
    protected void btnPrintnArchive_Click(object sender, EventArgs e)
    {
        STD_RoutineTime routineTime = new STD_RoutineTime();
        routineTime.RoomID = 0;
        routineTime.RoutineID = ddlCampus.SelectedValue == "0" ? 0 : int.Parse(ddlRoutineID.SelectedValue);
        routineTime.ClassID = int.Parse(ddlClassID.SelectedValue);
        routineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
        routineTime.EmployeeID = ddlEmployeeID.SelectedValue == "0" ? "" : ddlEmployeeID.SelectedValue;
        //string StudentID = "";

        Response.Redirect("~/Class/RoutineDisplay.aspx?Archive=1&RoutineID=" + routineTime.RoutineID.ToString() + "&ClassID=" + routineTime.ClassID.ToString() + "&SubjectID=" + routineTime.SubjectID.ToString() + "&EmployeeID=" + routineTime.EmployeeID);
        
    }
}
