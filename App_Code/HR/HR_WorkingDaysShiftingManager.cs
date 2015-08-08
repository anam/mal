using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_WorkingDaysShiftingManager
{
	public HR_WorkingDaysShiftingManager()
	{
	}

    public static DataSet  GetAllHR_WorkingDaysShiftings()
    {
       DataSet hR_WorkingDaysShiftings = new DataSet();
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        hR_WorkingDaysShiftings = sqlHR_WorkingDaysShiftingProvider.GetAllHR_WorkingDaysShiftings();
        return hR_WorkingDaysShiftings;
    }

	public static void hR_WorkingDaysShiftingsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_WorkingDaysShiftingPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
		DataSet ds =  sqlHR_WorkingDaysShiftingProvider.GetHR_WorkingDaysShiftingPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_WorkingDaysShiftingsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_WorkingDaysShifting()
    {
       DataSet hR_WorkingDaysShiftings = new DataSet();
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        hR_WorkingDaysShiftings = sqlHR_WorkingDaysShiftingProvider.GetDropDownLisAllHR_WorkingDaysShifting();
        return hR_WorkingDaysShiftings;
    }

    public static DataSet   GetAllHR_WorkingDaysShiftingsWithRelation()
    {
       DataSet hR_WorkingDaysShiftings = new DataSet();
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        hR_WorkingDaysShiftings = sqlHR_WorkingDaysShiftingProvider.GetAllHR_WorkingDaysShiftings();
        return hR_WorkingDaysShiftings;
    }

    public static HR_WorkingDaysShifting GetHR_WorkingDaysShiftingObjectByEmployeeID(string EmployeeID)
    {
        HR_WorkingDaysShifting hR_WorkingDaysShifting = new HR_WorkingDaysShifting();
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        hR_WorkingDaysShifting = sqlHR_WorkingDaysShiftingProvider.GetHR_WorkingDaysShiftingObjectByEmployeeID(EmployeeID);
        return hR_WorkingDaysShifting;
    }

    /// <summary>
    /// ////////////////
    /// </summary>
    /// <param name="EmployeeID"></param>
    /// <returns></returns>
    public static DataTable GetHR_WorkingDaysShiftingTableByEmployeeID(string EmployeeID)
    {
        HR_WorkingDaysShifting hR_WorkingDayShift = new HR_WorkingDaysShifting();
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        hR_WorkingDayShift = sqlHR_WorkingDaysShiftingProvider.GetHR_WorkingDaysShiftingObjectByEmployeeID(EmployeeID);


        //HR_WorkingDaysShifting hR_WorkingDayShift = HR_WorkingDaysShiftingManager.GetHR_WorkingDaysShiftingObjectByEmployeeID("96b72550-3649-45c6-a1f5-0474a77f4fa6");
        DataTable workDayShift = new DataTable();
        workDayShift.Columns.Add("Days", Type.GetType("System.String"));
        workDayShift.Columns.Add("StartTime", Type.GetType("System.String"));
        workDayShift.Columns.Add("EndTime", Type.GetType("System.String"));


        string startTimeHour = hR_WorkingDayShift.ShiftStartTime.Hour.ToString();
        string startAMPM = "AM";
        if (int.Parse(startTimeHour) > 12)
        {
            startTimeHour = (int.Parse(startTimeHour) - 12).ToString();
            startAMPM = "PM";
        }
        else if (int.Parse(startTimeHour) == 12)
        {
            startAMPM = "PM";
        }

        

        string startTimeMinute = hR_WorkingDayShift.ShiftStartTime.Minute.ToString();
        string startHourMinute = startTimeHour.Length == 1 ? "0" + startTimeHour : startTimeHour;
        startHourMinute += " : ";
        startHourMinute += startTimeMinute.Length == 1 ? "0" + startTimeMinute : startTimeMinute;
        startHourMinute += " "+startAMPM;

        string endTimeHour = hR_WorkingDayShift.ShiftEndTime.Hour.ToString();
        string endAMPM = "AM";
        if (int.Parse(endTimeHour) > 12)
        {
            endTimeHour = (int.Parse(endTimeHour) - 12).ToString();
            endAMPM = "PM";
        }
        else if (int.Parse(endTimeHour) == 12)
        {
            endAMPM = "PM";
        }
        string endTimeMinute = hR_WorkingDayShift.ShiftEndTime.Minute.ToString();
        string endHourMinute = endTimeHour.Length == 1 ? "0" + endTimeHour : endTimeHour;
        endHourMinute += " : ";
        endHourMinute += endTimeMinute.Length == 1 ? "0" + endTimeMinute : endTimeMinute;
        endHourMinute += " " + endAMPM;

        if (hR_WorkingDayShift.Saturday)
        {
            DataRow row = workDayShift.NewRow();
            row["Days"] = "Saturday";
            row["StartTime"] = startHourMinute;
            row["EndTime"] = endHourMinute;
            workDayShift.Rows.Add(row);
        }
        if (hR_WorkingDayShift.Sunday)
        {
            DataRow row = workDayShift.NewRow();
            row["Days"] = "Sunday";
            row["StartTime"] = startHourMinute;
            row["EndTime"] = endHourMinute;
            workDayShift.Rows.Add(row);
        }
        if (hR_WorkingDayShift.Monday)
        {
            DataRow row = workDayShift.NewRow();
            row["Days"] = "Monday";
            row["StartTime"] = startHourMinute;
            row["EndTime"] = endHourMinute;
            workDayShift.Rows.Add(row);
        }
        if (hR_WorkingDayShift.Tuesday)
        {
            DataRow row = workDayShift.NewRow();
            row["Days"] = "Tuesday";
            row["StartTime"] = startHourMinute;
            row["EndTime"] = endHourMinute;
            workDayShift.Rows.Add(row);
        }
        if (hR_WorkingDayShift.Wednesday)
        {
            DataRow row = workDayShift.NewRow();
            row["Days"] = "Wednesday";
            row["StartTime"] = startHourMinute;
            row["EndTime"] = endHourMinute;
            workDayShift.Rows.Add(row);
        }
        if (hR_WorkingDayShift.Thrusday)
        {
            DataRow row = workDayShift.NewRow();
            row["Days"] = "Thrusday";
            row["StartTime"] = startHourMinute;
            row["EndTime"] = endHourMinute;
            workDayShift.Rows.Add(row);
        }
        if (hR_WorkingDayShift.Friday)
        {
            DataRow row = workDayShift.NewRow();
            row["Days"] = "Friday";
            row["StartTime"] = startHourMinute;
            row["EndTime"] = endHourMinute;
            workDayShift.Rows.Add(row);
        }

        return workDayShift;
    }
    
    public static DataSet GetHR_WorkingDaysShiftingEmployeeID(string EmployeeID)
    {
        DataSet hR_WorkingDaysShiftings = new DataSet();
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        hR_WorkingDaysShiftings = sqlHR_WorkingDaysShiftingProvider.GetHR_WorkingDaysShiftingByEmployeeID(EmployeeID);
        return hR_WorkingDaysShiftings;
    }


    public static HR_WorkingDaysShifting GetHR_WorkingDaysShiftingByWorkingDaysID(int WorkingDaysID)
    {
        HR_WorkingDaysShifting hR_WorkingDaysShifting = new HR_WorkingDaysShifting();
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        hR_WorkingDaysShifting = sqlHR_WorkingDaysShiftingProvider.GetHR_WorkingDaysShiftingByWorkingDaysID(WorkingDaysID);
        return hR_WorkingDaysShifting;
    }


    public static int InsertHR_WorkingDaysShifting(HR_WorkingDaysShifting hR_WorkingDaysShifting)
    {
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        return sqlHR_WorkingDaysShiftingProvider.InsertHR_WorkingDaysShifting(hR_WorkingDaysShifting);
    }


    public static bool UpdateHR_WorkingDaysShifting(HR_WorkingDaysShifting hR_WorkingDaysShifting)
    {
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        return sqlHR_WorkingDaysShiftingProvider.UpdateHR_WorkingDaysShifting(hR_WorkingDaysShifting);
    }

    public static bool DeleteHR_WorkingDaysShifting(int hR_WorkingDaysShiftingID)
    {
        SqlHR_WorkingDaysShiftingProvider sqlHR_WorkingDaysShiftingProvider = new SqlHR_WorkingDaysShiftingProvider();
        return sqlHR_WorkingDaysShiftingProvider.DeleteHR_WorkingDaysShifting(hR_WorkingDaysShiftingID);
    }
}

