using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_Exam
{
    public Quiz_Exam()
    {
    }


    public Quiz_Exam
        (
int  examID,
string  examName,
int  courseID,
int  subjectID,
int  chapterID,
int  examTimeDuration,
DateTime  examStartTime,
bool  isRetake,
bool  isActive,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ExamID = examID;
this.ExamName = examName;
this.CourseID = courseID;
this.SubjectID = subjectID;
this.ChapterID = chapterID;
this.ExamTimeDuration = examTimeDuration;
this.ExamStartTime = examStartTime;
this.IsRetake = isRetake;
this.IsActive = isActive;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int ExamID
    {
        get;
        set;
    }

    public string ExamName
    {
        get;
        set;
    }

    public int CourseID
    {
        get;
        set;
    }

    public int SubjectID
    {
        get;
        set;
    }

    public int ChapterID
    {
        get;
        set;
    }

    public int ExamTimeDuration
    {
        get;
        set;
    }

    public DateTime ExamStartTime
    {
        get;
        set;
    }

    public bool IsRetake
    {
        get;
        set;
    }

    public bool IsActive
    {
        get;
        set;
    }

    public string AddedBy
    {
        get;
        set;
    }

    public DateTime AddedDate
    {
        get;
        set;
    }

    public string ModifiedBy
    {
        get;
        set;
    }

    public DateTime ModifiedDate
    {
        get;
        set;
    }

}

