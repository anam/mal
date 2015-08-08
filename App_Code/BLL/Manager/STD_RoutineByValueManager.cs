﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_RoutineByValueManager
{
    public STD_RoutineByValueManager()
    {
    }

    public static DataSet GetAllSTD_Routine()
    {
        DataSet sTD_RoutineTimes = new DataSet();
        SqlSTD_RoutineByValueProvider SqlSTD_RoutineByValueProvider = new SqlSTD_RoutineByValueProvider();
        sTD_RoutineTimes = SqlSTD_RoutineByValueProvider.GetAllSTD_RoutineTimes();
        return sTD_RoutineTimes;
    }

    //public static STD_RoutineTime GetSTD_RoomByRoomID(int RoomID)
    //{
    //    STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
    //    SqlSTD_RoutineByValueProvider SqlSTD_RoutineByValueProvider = new SqlSTD_RoutineByValueProvider();
    //    sTD_RoutineTime = SqlSTD_RoutineByValueProvider.GetSTD_RoutineTimeByRoomID(RoomID);
    //    return sTD_RoutineTime;
    //}


    public DataSet GetSTD_RoutineByParam(string SubjectID, string EmployeeID, string ClassID)
    {
        DataSet dsRoutineTime = new DataSet();
        SqlSTD_RoutineByValueProvider SqlSTD_RoutineByValueProvider = new SqlSTD_RoutineByValueProvider();
        dsRoutineTime = SqlSTD_RoutineByValueProvider.GetSTD_RoutineTimeByParams(SubjectID, EmployeeID, ClassID);
        return dsRoutineTime;
    }

    public DataSet GetSTD_RoutineByStudentParam(string StudentID)
    {
        DataSet dsRoutineTime = new DataSet();
        SqlSTD_RoutineByValueProvider SqlSTD_RoutineByValueProvider = new SqlSTD_RoutineByValueProvider();
        dsRoutineTime = SqlSTD_RoutineByValueProvider.GetSTD_RoutineTimeByStudentParams(StudentID);
        return dsRoutineTime;
    }


    //public static STD_RoutineTime GetSTD_EmployeeByEmployeeID(string EmployeeID)
    //{
    //    STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
    //    SqlSTD_RoutineByValueProvider SqlSTD_RoutineByValueProvider = new SqlSTD_RoutineByValueProvider();
    //    sTD_RoutineTime = SqlSTD_RoutineByValueProvider.GetSTD_RoutineTimeByEmployeeID(EmployeeID);
    //    return sTD_RoutineTime;
    //}


    //public static STD_RoutineTime GetSTD_ClassByClassID(int ClassID)
    //{
    //    STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
    //    SqlSTD_RoutineByValueProvider SqlSTD_RoutineByValueProvider = new SqlSTD_RoutineByValueProvider();
    //    sTD_RoutineTime = SqlSTD_RoutineByValueProvider.GetSTD_RoutineTimeByClassID(ClassID);
    //    return sTD_RoutineTime;
    //}


    //public static STD_RoutineTime GetSTD_ClassDayByClassDayID(int ClassDayID)
    //{
    //    STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
    //    SqlSTD_RoutineByValueProvider SqlSTD_RoutineByValueProvider = new SqlSTD_RoutineByValueProvider();
    //    sTD_RoutineTime = SqlSTD_RoutineByValueProvider.GetSTD_RoutineTimeByClassDayID(ClassDayID);
    //    return sTD_RoutineTime;
    //}


    public DataSet GetSTD_GetColumnNames()
    {
        DataSet dsRoutineTime = new DataSet();
        SqlSTD_RoutineByValueProvider SqlSTD_RoutineByValueProvider = new SqlSTD_RoutineByValueProvider();
        dsRoutineTime = SqlSTD_RoutineByValueProvider.GetSTD_ColumnNames();
        return dsRoutineTime;
    }



    public static DataSet GetSTD_WeekDay()
    {
        DataSet dsRoutineTime = new DataSet();
        SqlSTD_RoutineByValueProvider SqlSTD_RoutineByValueProvider = new SqlSTD_RoutineByValueProvider();
        dsRoutineTime = SqlSTD_RoutineByValueProvider.GetSTD_WeekDayName();
        return dsRoutineTime;
    }
}

