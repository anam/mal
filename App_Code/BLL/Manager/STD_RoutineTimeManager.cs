using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_RoutineTimeManager
{
	public STD_RoutineTimeManager()
	{
	}

    public static DataSet  GetAllSTD_RoutineTimes()
    {
       DataSet sTD_RoutineTimes = new DataSet();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTimes = sqlSTD_RoutineTimeProvider.GetAllSTD_RoutineTimes();
        return sTD_RoutineTimes;
    }

    public static DataSet GetAllSTD_RoutineTimesByClassSubjectTeacher(int ClassID, int SubjectID, string teacherID)
    {
        DataSet sTD_RoutineTimes = new DataSet();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTimes = sqlSTD_RoutineTimeProvider.GetAllSTD_RoutineTimesByClassSubjectTeacher(ClassID, SubjectID, teacherID);
        return sTD_RoutineTimes;
    }

	public static void sTD_RoutineTimesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
		{
		double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
		int pageCount = (int)Math.Ceiling(dblPageCount);
		List<ListItem> pages = new List<ListItem>();
		if (pageCount > 0)
		{
 		pages.Add(new ListItem("First", "1", currentPage > 1));
		for (int i = 1; i <= pageCount; i++)
		{
		 pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
		}
		pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
		}
		rptPager.DataSource = pages;
		rptPager.DataBind();
		}
 	public static void LoadSTD_RoutineTimePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
		DataSet ds =  sqlSTD_RoutineTimeProvider.GetSTD_RoutineTimePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_RoutineTimesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_RoutineTime()
    {
       DataSet sTD_RoutineTimes = new DataSet();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTimes = sqlSTD_RoutineTimeProvider.GetDropDownLisAllSTD_RoutineTime();
        return sTD_RoutineTimes;
    }

    public static DataSet STD_SearchRoutineTime(STD_RoutineTime routineTime, string studentID)
    {
        DataSet sTD_RoutineTimes = new DataSet();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTimes = sqlSTD_RoutineTimeProvider.STD_SearchRoutineTime(routineTime,studentID);
        return sTD_RoutineTimes;
    }


    public static DataSet STD_SearchRoutineTimeForRoutineCheck(STD_RoutineTime routineTime, string studentID)
    {
        DataSet sTD_RoutineTimes = new DataSet();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTimes = sqlSTD_RoutineTimeProvider.STD_SearchRoutineTimeForRoutineCheck(routineTime, studentID);
        return sTD_RoutineTimes;
    }


    public static String getRoutineText(STD_RoutineTime routineTime, string StudentID)
    {       
    
        try
        {
            DataSet dsRoutineTime = STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);

            DataSet dsClassTime = STD_ClassTimeManager.GetAllSTD_ClassTimes();
            DataSet dsClassDay = STD_ClassDayManager.GetAllSTD_ClassDaies();
            int width = 200;
            int widthDay = 50;
            string routine = "<table border='1' style='width:" + ((dsClassTime.Tables[0].Rows.Count * width) + widthDay).ToString() + "px'>";

            for (int row = 0; row < dsClassDay.Tables[0].Rows.Count; row++)
            {
                if (row == 0)
                {
                    routine += "<tr ><td></td>";
                    for (int col = 0; col < dsClassTime.Tables[0].Rows.Count; col++)
                    {
                        routine += "<td>";
                        routine += dsClassTime.Tables[0].Rows[col]["ClassTimeName"].ToString();
                        routine += "</td>";

                    }
                    routine += "</tr>";
                }

                routine += "<tr>";
                for (int col = 0; col < dsClassTime.Tables[0].Rows.Count; col++)
                {
                    if (col == 0)
                    {
                        routine += "<td style='min-width:" + widthDay + "px'>";
                        routine += dsClassDay.Tables[0].Rows[row]["ClassDayName"].ToString();
                        routine += "</td>";
                    }

                    routine += "<td style='min-width:" + width + "px;'>";
                    routine += GetClassName(routineTime,dsRoutineTime, dsClassTime.Tables[0].Rows[col]["ClassTimeID"].ToString(), dsClassDay.Tables[0].Rows[row]["ClassDayID"].ToString());
                    routine += "</td>";
                }
                routine += "</tr>";
            }
            routine += "</table>";


            return routine;

        }
        catch (Exception ex)
        {
            return "";
        }
    }


    public static String getRoutineTextDayTop(STD_RoutineTime routineTime, string StudentID)
    {

        try
        {
            DataSet dsRoutineTime = STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);

            DataSet dsClassTime = STD_ClassTimeManager.GetAllSTD_ClassTimes();
            DataSet dsClassDay = STD_ClassDayManager.GetAllSTD_ClassDaies();
            int width = 120;
            int widthDay = 70;
            string routine = "";
            if (dsRoutineTime.Tables[1].Rows.Count > 0)
            {
                if (routineTime.RoutineID != 0)
                {
                    routine += "<br/><b>Campus :</b> " + dsRoutineTime.Tables[1].Rows[0]["CampusName"];
                }

                if (routineTime.RoomID != 0)
                {
                    routine += "<br/><b>Room :</b> " + dsRoutineTime.Tables[1].Rows[0]["RoomName"];
                }

                if (routineTime.ClassID != 0)
                {
                    routine += "<br/><b>Batch :</b> " + dsRoutineTime.Tables[1].Rows[0]["ClassName"];
                }

                if (routineTime.SubjectID != 0)
                {
                    routine += "<br/><b>Subject :</b> " + dsRoutineTime.Tables[1].Rows[0]["SubjectName"];
                }


                if (routineTime.EmployeeID != "")
                {
                    routine += "<br/><b>Teacher :</b> " + dsRoutineTime.Tables[1].Rows[0]["EmployeeName"];
                }
            }

            routine += "<table id='tblRoutineDisplay'  style='font-size:10px;'>";
            //string routine = "<table id='tblRoutineDisplay'  style='font-size:10px;width:" + ((dsClassTime.Tables[0].Rows.Count * width) + widthDay).ToString() + "px'>";
            string classTimeGroupID = dsClassTime.Tables[0].Rows[0]["ClassTimeGroupID"].ToString();
            bool lastSetEmpty = false;

            string daysNameRow = "";
            for (int row = 0; row < dsClassTime.Tables[0].Rows.Count; row++)
            {
                if (classTimeGroupID != dsClassTime.Tables[0].Rows[row]["ClassTimeGroupID"].ToString())
                {
                    if (!lastSetEmpty)
                    {
                        routine = routine.Replace("<tr><td style='color:white;' colspan='" + (dsClassDay.Tables[0].Rows.Count + 1) + "'>&nbsp;</br>" + classTimeGroupID + "</td></tr>", "");
                    }

                    routine += "<tr><td style='color:white;' colspan='" + (dsClassDay.Tables[0].Rows.Count + 1) + "'>&nbsp;</br>" + dsClassTime.Tables[0].Rows[row]["ClassTimeGroupID"].ToString() + "</td></tr>";
                    
                    //routine += "<tr><td colspan='" + (dsClassDay.Tables[0].Rows.Count + 1) + "'>&nbsp;</td></tr>";
                    classTimeGroupID = dsClassTime.Tables[0].Rows[row]["ClassTimeGroupID"].ToString();
                    lastSetEmpty = false;
                }

                if (row == 0)
                {
                    daysNameRow += "<tr><td></td>";
                    
                    for (int col = 0; col < dsClassDay.Tables[0].Rows.Count; col++)
                    {
                        daysNameRow += "<td>";
                        daysNameRow += dsClassDay.Tables[0].Rows[col]["ClassDayName"].ToString();
                        daysNameRow += "</td>";
                    }

                    daysNameRow += "</tr>";
                    routine += daysNameRow;                
                }
                string tmp = "";
                bool needtoAdd = false;

                tmp += "<tr>";
                for (int col = 0; col < dsClassDay.Tables[0].Rows.Count; col++)
                {
                    if (col == 0)
                    {
                        //routine += "<td valign='top' style='min-width:" + widthDay + "px'>";
                        tmp += "<td valign='top'>";
                        tmp += dsClassTime.Tables[0].Rows[row]["ClassTimeName"].ToString();
                        tmp += "</td>";
                    }

                    //routine += "<td valign='top' style='min-width:" + width + "px;'>";
                    tmp += "<td valign='top' >";
                    string tmp1 = GetClassName(routineTime, dsRoutineTime, dsClassTime.Tables[0].Rows[row]["ClassTimeID"].ToString(), dsClassDay.Tables[0].Rows[col]["ClassDayID"].ToString());

                    if (tmp1 != "")
                    {
                        tmp += tmp1;
                        needtoAdd = true;

                    }

                    tmp += "</td>";
                }
                tmp += "</tr>";

                if (needtoAdd)
                {
                    routine += tmp;
                    lastSetEmpty = true;
                }
            }

            if (!lastSetEmpty)
            {
                routine = routine.Replace("<tr><td style='color:white;' colspan='" + (dsClassDay.Tables[0].Rows.Count + 1) + "'>&nbsp;</br></br></br>" + classTimeGroupID + "</td></tr>", "");
            }
            routine += daysNameRow;
            routine += "</table>";


            routine += GetTeacherName(dsRoutineTime);
            return routine;

        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public static string GetClassName(STD_RoutineTime routineTime, DataSet dsRoutineTime, string ClassTimeID, string ClassDayID)
    {
        string className = "";
        foreach (DataRow dr in dsRoutineTime.Tables[0].Rows)
        {
            if (dr["ClassTimeID"].ToString() == ClassTimeID && dr["ClassDayID"].ToString() == ClassDayID)
            {
                //if (className != "") className += "</br>";

                //className += "Subject( " + dr["SubjectName"].ToString() + " ) Class( " + dr["ClassName"].ToString() + " ) Teacher( " + dr["EmployeeName"].ToString() + " )";
                className += "<div style='border:1px solid black;'>(" + dr["ClassName"].ToString() + ") (" + dr["SubjectName"].ToString() + ") (" + dr["EmployeeSortName"].ToString() + ")  (" + dr["RoomName"].ToString() + ")" ;
                className += "<a  href='Class_Display_RoutineTime_ByValues.aspx?IsDelete=1&CampusID=" + dr["CampusID"].ToString() + "&RoutineID=" + routineTime.RoutineID.ToString() + "&ClassID=" + routineTime.ClassID.ToString() + "&SubjectID=" + routineTime.SubjectID.ToString() + "&EmployeeID=" + routineTime.EmployeeID.ToString() + "&RoutineTimeID=" + dr["RoutineTimeID"].ToString() + "' style='display:none;'><img src='../App_Themes/CoffeyGreen/images/icon-delete.png' /></a></div>";
                //className +="<img src='../App_Themes/CoffeyGreen/images/icon-delete.png' />";
            }
        }
        return className;
    }

    public static string GetTeacherName(DataSet dsRoutineTime)
    {
        string employeeNo = "<hr/><span style='font-size:10px;'>Teacher Details:</span><hr/><table  id='tblRoutineDisplayTeacher'  style='font-size:10px;'>";

        bool isLeft = true;
        for (int r=0;r<dsRoutineTime.Tables[0].Rows.Count;)
        {

            if (employeeNo.Contains("<td>" + dsRoutineTime.Tables[0].Rows[r]["EmployeeSortName"].ToString() + "</td>"))
            {
                r++;
                continue;
            }

            if (isLeft)
            {
                
                employeeNo += "<tr"+(r==0?" style='border-top:1px solid Black;'":"")+"><td>";
                try
                {
                    employeeNo += dsRoutineTime.Tables[0].Rows[r]["EmployeeSortName"].ToString();
                }
                catch (Exception ex) { employeeNo += "&nbsp;"; }
                employeeNo += "</td>";

                employeeNo += "<td>";
                try
                {
                    employeeNo += dsRoutineTime.Tables[0].Rows[r++]["EmployeeNameDetails"].ToString();
                }
                catch (Exception ex) { employeeNo += "&nbsp;"; }
                employeeNo += "</td><td>&nbsp;</td>";
            }
            else
            {
                employeeNo += "<td>";
                try
                {
                    employeeNo += dsRoutineTime.Tables[0].Rows[r]["EmployeeSortName"].ToString();
                }
                catch (Exception ex) { employeeNo += "&nbsp;"; }
                employeeNo += "</td>";

                employeeNo += "<td>";
                try
                {
                    employeeNo += dsRoutineTime.Tables[0].Rows[r++]["EmployeeNameDetails"].ToString();
                }
                catch (Exception ex) { employeeNo += "&nbsp;"; }
                employeeNo += "</td></tr>";
            }

            isLeft = !isLeft;
        }

        if (!isLeft) 
        {
            employeeNo += "<td></td>&nbsp;<td>&nbsp;</td></tr>";
        }

        employeeNo += "</table><hr/><span style='font-size:10px;'>This is a computer generated class schedule. so no need to proceed for any signatory approval.</span><hr/>";

        return employeeNo ;
    }

    public static DataSet   GetAllSTD_RoutineTimesWithRelation()
    {
       DataSet sTD_RoutineTimes = new DataSet();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTimes = sqlSTD_RoutineTimeProvider.GetAllSTD_RoutineTimes();
        return sTD_RoutineTimes;
    }


    public static STD_RoutineTime GetSTD_RoomByRoomID(int RoomID)
    {
        STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTime = sqlSTD_RoutineTimeProvider.GetSTD_RoutineTimeByRoomID(RoomID);
        return sTD_RoutineTime;
    }


    public static STD_RoutineTime GetSTD_SubjectBySubjectID(int SubjectID)
    {
        STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTime = sqlSTD_RoutineTimeProvider.GetSTD_RoutineTimeBySubjectID(SubjectID);
        return sTD_RoutineTime;
    }


    public static STD_RoutineTime GetSTD_EmployeeByEmployeeID(string EmployeeID)
    {
        STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTime = sqlSTD_RoutineTimeProvider.GetSTD_RoutineTimeByEmployeeID(EmployeeID);
        return sTD_RoutineTime;
    }


    public static STD_RoutineTime GetSTD_ClassByClassID(int ClassID)
    {
        STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTime = sqlSTD_RoutineTimeProvider.GetSTD_RoutineTimeByClassID(ClassID);
        return sTD_RoutineTime;
    }


    public static STD_RoutineTime GetSTD_ClassDayByClassDayID(int ClassDayID)
    {
        STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTime = sqlSTD_RoutineTimeProvider.GetSTD_RoutineTimeByClassDayID(ClassDayID);
        return sTD_RoutineTime;
    }


    public static STD_RoutineTime GetSTD_ClassTimeByClassTimeID(int ClassTimeID)
    {
        STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTime = sqlSTD_RoutineTimeProvider.GetSTD_RoutineTimeByClassTimeID(ClassTimeID);
        return sTD_RoutineTime;
    }


    public static STD_RoutineTime GetSTD_RoutineByRoutineID(int RoutineID)
    {
        STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTime = sqlSTD_RoutineTimeProvider.GetSTD_RoutineTimeByRoutineID(RoutineID);
        return sTD_RoutineTime;
    }


    public static STD_RoutineTime GetSTD_RoutineTimeByRoutineTimeID(int RoutineTimeID)
    {
        STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        sTD_RoutineTime = sqlSTD_RoutineTimeProvider.GetSTD_RoutineTimeByRoutineTimeID(RoutineTimeID);
        return sTD_RoutineTime;
    }


    public static int InsertSTD_RoutineTime(STD_RoutineTime sTD_RoutineTime)
    {
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        return sqlSTD_RoutineTimeProvider.InsertSTD_RoutineTime(sTD_RoutineTime);
    }


    public static bool UpdateSTD_RoutineTime(STD_RoutineTime sTD_RoutineTime)
    {
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        return sqlSTD_RoutineTimeProvider.UpdateSTD_RoutineTime(sTD_RoutineTime);
    }

    public static bool DeleteSTD_RoutineTime(int sTD_RoutineTimeID)
    {
        SqlSTD_RoutineTimeProvider sqlSTD_RoutineTimeProvider = new SqlSTD_RoutineTimeProvider();
        return sqlSTD_RoutineTimeProvider.DeleteSTD_RoutineTime(sTD_RoutineTimeID);
    }
}

