using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for STD_MockTestManager
/// </summary>
public class STD_MockTestManager
{
	public STD_MockTestManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<Quiz_Comprehension> GetMockTest_Comprehension(string studentID, int courseID, int subjectID, int chapterID, int count)
    {
        STD_MockTestProvider mockTestProvider = new STD_MockTestProvider();
        return mockTestProvider.GetMockTest_Comprehension(studentID, courseID, subjectID, chapterID, count);
    }

    public static int GetMockTest_Comprehension_Count(string studentID, int courseID, int subjectID, int chapterID)
    {
        STD_MockTestProvider mockTestProvider = new STD_MockTestProvider();
        return mockTestProvider.GetMockTest_Comprehension_Count(studentID, courseID, subjectID, chapterID);
    }

    public static List<Quiz_FillInTheBlanks> GetMockTest_FillInTheBlanks(string studentID, int courseID, int subjectID, int chapterID, int count)
    {
        STD_MockTestProvider mockTestProvider = new STD_MockTestProvider();
        return mockTestProvider.GetMockTest_FillInTheBlanks(studentID, courseID, subjectID, chapterID, count);
    }

    public static int GetMockTest_FillInTheBlanks_Count(string studentID, int courseID, int subjectID, int chapterID)
    {
        STD_MockTestProvider mockTestProvider = new STD_MockTestProvider();
        return mockTestProvider.GetMockTest_FillInTheBlanks_Count(studentID, courseID, subjectID, chapterID);
    }

    public static List<Quiz_MultipleQuestion> GetMockTest_MCQ(string studentID, int courseID, int subjectID, int chapterID, int count)
    {
        STD_MockTestProvider mockTestProvider = new STD_MockTestProvider();
        return mockTestProvider.GetMockTest_MCQ(studentID, courseID, subjectID, chapterID, count);
    }

    public static int GetMockTest_MCQ_Count(string studentID, int courseID, int subjectID, int chapterID)
    {
        STD_MockTestProvider mockTestProvider = new STD_MockTestProvider();
        return mockTestProvider.GetMockTest_MCQ_Count(studentID, courseID, subjectID, chapterID);
    }

    public static List<Quiz_TrueFalse> GetMockTest_TrueFalses(string studentID, int courseID, int subjectID, int chapterID, bool isDrCr, int count)
    {
        STD_MockTestProvider mockTestProvider = new STD_MockTestProvider();
        return mockTestProvider.GetMockTest_TrueFalses(studentID, courseID, subjectID,chapterID, isDrCr, count);
    }

    public static int GetMockTest_TrueFalses_Count(string studentID, int courseID, int subjectID, int chapterID, bool isDrCr)
    {
        STD_MockTestProvider mockTestProvider = new STD_MockTestProvider();
        return mockTestProvider.GetMockTest_TrueFalses_Count(studentID, courseID, subjectID, chapterID, isDrCr);
    }
}