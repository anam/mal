using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_Comprehension
{
    public Quiz_Comprehension()
    {
    }


    public Quiz_Comprehension
        (
int  comprehensionID,
int  courseID,
int  subjectID,
int  chapterID,
string  comprehension,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ComprehensionID = comprehensionID;
this.CourseID = courseID;
this.SubjectID = subjectID;
this.ChapterID = chapterID;
this.Comprehension = comprehension;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ComprehensionID
    {
        get ; 
        set  ;
    }

    public int  CourseID
    {
        get ; 
        set  ;
    }

    public int  SubjectID
    {
        get ; 
        set  ;
    }

    public int  ChapterID
    {
        get ; 
        set  ;
    }

    public string  Comprehension
    {
        get ; 
        set  ;
    }

    public string  AddedBy
    {
        get ; 
        set  ;
    }

    public DateTime  AddedDate
    {
        get ; 
        set  ;
    }

    public string  ModifiedBy
    {
        get ; 
        set  ;
    }

    public DateTime  ModifiedDate
    {
        get ; 
        set  ;
    }

}

