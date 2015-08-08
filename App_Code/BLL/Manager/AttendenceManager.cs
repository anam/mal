using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class AttendenceManager
{
	public AttendenceManager()
	{
	}

    public static List<Attendence> GetAllAttendences()
    {
        List<Attendence> attendences = new List<Attendence>();
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        attendences = sqlAttendenceProvider.GetAllAttendences();
        return attendences;
    }


    public static List<Attendence> GetAllAttendencesByUserIDnDate(string UserID,string date)
    {
        List<Attendence> attendences = new List<Attendence>();
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        attendences = sqlAttendenceProvider.GetAllAttendencesByUserID(UserID,date);
        return attendences;
    }

    public static List<Attendence> GetAllAttendencesByDate(string date)
    {
        List<Attendence> attendences = new List<Attendence>();
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        attendences = sqlAttendenceProvider.GetAllAttendencesByDate(date);
        return attendences;
    }


    public static List<Attendence> GetAllAttendencesByDateForTeacher(string date)
    {
        List<Attendence> attendences = new List<Attendence>();
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        attendences = sqlAttendenceProvider.GetAllAttendencesByDateForTeacher(date);
        return attendences;
    }


    public static List<Attendence> GetAllAttendencesByDateForStudent(string date)
    {
        List<Attendence> attendences = new List<Attendence>();
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        attendences = sqlAttendenceProvider.GetAllAttendencesByDateForStudent(date);
        return attendences;
    }


    public static List<Attendence> GetAllAttendencesByDateJustPresent(string date)
    {
        List<Attendence> attendences = new List<Attendence>();
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        attendences = sqlAttendenceProvider.GetAllAttendencesByDateJustPresent(date);
        return attendences;
    }

    
    public static Attendence GetAttendenceByID(int id)
    {
        Attendence attendence = new Attendence();
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        attendence = sqlAttendenceProvider.GetAttendenceByID(id);
        return attendence;
    }


    public static int InsertAttendence(Attendence attendence)
    {
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        return sqlAttendenceProvider.InsertAttendence(attendence);
    }


    public static bool UpdateAttendence(Attendence attendence)
    {
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        return sqlAttendenceProvider.UpdateAttendence(attendence);
    }

    public static bool DeleteAttendence(int attendenceID)
    {
        SqlAttendenceProvider sqlAttendenceProvider = new SqlAttendenceProvider();
        return sqlAttendenceProvider.DeleteAttendence(attendenceID);
    }
}
