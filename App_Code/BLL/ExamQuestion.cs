using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExamQuestion
/// </summary>
public class ExamQuestion
{
	public ExamQuestion()
	{
        this.IsAnswered = false;
        this.ObtainedMark = 0;
        this.OutOfMark = 1;
	}

    public ExamQuestion(int questionType,int comprehensionID, int questionNo)
    {
        this.QuestionType = questionType;
        this.ComprehensionID = comprehensionID;
        this.QuestionNo = questionNo;
    }

    public int QuestionType { get; set; }

    public int ComprehensionID { get; set; }

    public int QuestionNo { get; set; }

    public bool IsAnswered { get; set; }

    public int ObtainedMark { get; set; }

    public int OutOfMark { get; set; }

    public string Answer { get; set; }
}