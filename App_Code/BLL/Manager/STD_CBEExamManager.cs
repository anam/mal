using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for STD_CBEExamManager
/// </summary>
public class STD_CBEExamManager
{
	public STD_CBEExamManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<STD_CBEExam> GetAllCBEExams()
    {
        List<STD_CBEExam> cBEExams = new List<STD_CBEExam>();
        SqlCBEExamProvider sqlCBEExamProvider = new SqlCBEExamProvider();
        cBEExams = sqlCBEExamProvider.GetAllCBEExams();
        return cBEExams;
    }


    public static STD_CBEExam GetCBEExamByID(int id)
    {
        STD_CBEExam cBEExam = new STD_CBEExam();
        SqlCBEExamProvider sqlCBEExamProvider = new SqlCBEExamProvider();
        cBEExam = sqlCBEExamProvider.GetCBEExamByID(id);
        return cBEExam;
    }


    public static int InsertCBEExam(STD_CBEExam cBEExam)
    {
        SqlCBEExamProvider sqlCBEExamProvider = new SqlCBEExamProvider();
        return sqlCBEExamProvider.InsertCBEExam(cBEExam);
    }


    public static bool UpdateCBEExam(STD_CBEExam cBEExam)
    {
        SqlCBEExamProvider sqlCBEExamProvider = new SqlCBEExamProvider();
        return sqlCBEExamProvider.UpdateCBEExam(cBEExam);
    }

    public static bool DeleteCBEExam(int cBEExamID)
    {
        SqlCBEExamProvider sqlCBEExamProvider = new SqlCBEExamProvider();
        return sqlCBEExamProvider.DeleteCBEExam(cBEExamID);
    }

    public static List<STD_CBEExam> SearchAllCBEExams(string name, string subject, DateTime startDate, DateTime endDate)
    {
        List<STD_CBEExam> cBEExams = new List<STD_CBEExam>();
        SqlCBEExamProvider sqlCBEExamProvider = new SqlCBEExamProvider();
        cBEExams = sqlCBEExamProvider.SearchAllCBEExams(name, subject, startDate, endDate);
        return cBEExams;
    }
}