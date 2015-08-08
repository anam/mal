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

       
    }

    protected void btnShowRoutine_Click(object sender, EventArgs e)
    {
        string studentID = String.Empty;

        if (txtStudent.Text != "")
            studentID = txtStudent.Text;//"eaf5750c-a4b2-4424-b9c2-8593e2bd9b8e";
        else
            studentID = null;


        GenerateRoutine(studentID);
    }

    #region GenerateRoutine
    private void GenerateRoutine(string studentID)
    {

        Hashtable htRoutineValues = new Hashtable();

        string crValue = string.Empty;

        DataRow newRow = null;
        DataSet dsRoutine = new DataSet();
        DataSet dsWeekDay = new DataSet();

        dsRoutine.Clear();
        STD_RoutineByValueManager STD_RoutineByValueManager = new STD_RoutineByValueManager();
        dsRoutine = STD_RoutineByValueManager.GetSTD_RoutineByStudentParam(studentID);
        dsWeekDay = STD_RoutineByValueManager.GetSTD_WeekDay();
        DataSet ds = GetTemplate();

        if (dsRoutine.Tables[0].Columns.Contains("subjectname"))
            dsRoutine.Tables[0].Columns.Remove("subjectname");

        if (dsRoutine.Tables[0].Columns.Contains("Order"))
            dsRoutine.Tables[0].Columns.Remove("Order");

        string[] columnNames = (from dc in dsRoutine.Tables[0].Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();
        string[] allColumnNames = (from dc in ds.Tables["tblRoutineTemplate"].Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

        string[] weekDayNames = dsWeekDay.Tables[0].AsEnumerable().Select(dr => dr["Name"].ToString()).ToArray();

        if (dsRoutine.Tables[0].Rows.Count > 0)
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
                                        crValue = rowValue + "," + htRoutineValues[columnName].ToString();

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
        if (Session["tblRoutineTemplate"] != null)
        {

            Response.Redirect("~/Class/Class_Display_Routine.aspx");
           // Session["tblRoutineTemplate"] = null;
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('No Record Found')");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);

        }

    }
}
