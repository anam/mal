using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for STD_CBEExamSubjectManager
/// </summary>
public class STD_CBEExamSubjectManager
{
	public STD_CBEExamSubjectManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<STD_CBEExamSubject> GetAllCBEExamSubjects()
    {
        List<STD_CBEExamSubject> cBEExamSubjects = new List<STD_CBEExamSubject>();
        SqlCBEExamSubjectProvider sqlCBEExamSubjectProvider = new SqlCBEExamSubjectProvider();
        cBEExamSubjects = sqlCBEExamSubjectProvider.GetAllCBEExamSubjects();
        return cBEExamSubjects;
    }


    public static STD_CBEExamSubject GetCBEExamSubjectByID(int id)
    {
        STD_CBEExamSubject cBEExamSubject = new STD_CBEExamSubject();
        SqlCBEExamSubjectProvider sqlCBEExamSubjectProvider = new SqlCBEExamSubjectProvider();
        cBEExamSubject = sqlCBEExamSubjectProvider.GetCBEExamSubjectByID(id);
        return cBEExamSubject;
    }


    public static int InsertCBEExamSubject(STD_CBEExamSubject cBEExamSubject)
    {
        SqlCBEExamSubjectProvider sqlCBEExamSubjectProvider = new SqlCBEExamSubjectProvider();
        return sqlCBEExamSubjectProvider.InsertCBEExamSubject(cBEExamSubject);
    }


    public static bool UpdateCBEExamSubject(STD_CBEExamSubject cBEExamSubject)
    {
        SqlCBEExamSubjectProvider sqlCBEExamSubjectProvider = new SqlCBEExamSubjectProvider();
        return sqlCBEExamSubjectProvider.UpdateCBEExamSubject(cBEExamSubject);
    }

    public static bool DeleteCBEExamSubject(int cBEExamSubjectID)
    {
        SqlCBEExamSubjectProvider sqlCBEExamSubjectProvider = new SqlCBEExamSubjectProvider();
        return sqlCBEExamSubjectProvider.DeleteCBEExamSubject(cBEExamSubjectID);
    }

    public static List<STD_CBEExamSubject> GetSTD_CBEExamSubjectByCBEExamID(int cBEExamID)
    {
        List<STD_CBEExamSubject> cBEExamSubjects = new List<STD_CBEExamSubject>();
        SqlCBEExamSubjectProvider sqlCBEExamSubjectProvider = new SqlCBEExamSubjectProvider();
        cBEExamSubjects = sqlCBEExamSubjectProvider.GetSTD_CBEExamSubjectByCBEExamID(cBEExamID);
        return cBEExamSubjects;
    }
}