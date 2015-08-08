using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Chapter
{
    public STD_Chapter()
    {
    }


    public STD_Chapter
        (
int  chapterID,
int  subjectID,
string  chapterName,
string  description,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ChapterID = chapterID;
this.SubjectID = subjectID;
this.ChapterName = chapterName;
this.Description = description;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

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

    public string  ChapterName
    {
        get ; 
        set  ;
    }

    public string  Description
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

    public string  UpdatedBy
    {
        get ; 
        set  ;
    }

    public DateTime  UpdateDate
    {
        get ; 
        set  ;
    }

}

