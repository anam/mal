using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_Chapter
{
    public Quiz_Chapter()
    {
    }


    public Quiz_Chapter
        (
int  chapterID,
int  subjectID,
int  courseID,
string  chapterName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ChapterID = chapterID;
this.SubjectID = subjectID;
this.CourseID = courseID;
this.ChapterName = chapterName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ChapterID
    {
        get ; 
        set  ;
    }

    public int  SubjectID
    {
        get ; 
        set  ;
    }

    public int  CourseID
    {
        get ; 
        set  ;
    }

    public string  ChapterName
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

