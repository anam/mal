using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ExamInfoDetail
{
    public STD_ExamInfoDetail()
    {
    }


    public STD_ExamInfoDetail
        (
int  examInfoDetailID,
int  examInfoID,
string  studentID,
int  subjectID,
string  examStartTime,
int  examDuration,
DateTime  examDate,
int  examMarks,
float  obtainMarks,
string  extraField1,
string  extraField2,
string  extraField3,
string  extraField4,
string  extraField5,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate,
int  rowStatusID

        )

    {
this.ExamInfoDetailID = examInfoDetailID;
this.ExamInfoID = examInfoID;
this.StudentID = studentID;
this.SubjectID = subjectID;
this.ExamStartTime = examStartTime;
this.ExamDuration = examDuration;
this.ExamDate = examDate;
this.ExamMarks = examMarks;
this.ObtainMarks = obtainMarks;
this.ExtraField1 = extraField1;
this.ExtraField2 = extraField2;
this.ExtraField3 = extraField3;
this.ExtraField4 = extraField4;
this.ExtraField5 = extraField5;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;
this.RowStatusID = rowStatusID;

    }

    public int  ExamInfoDetailID
    {
        get ; 
        set  ;
    }

    public int  ExamInfoID
    {
        get ; 
        set  ;
    }

    public string  StudentID
    {
        get ; 
        set  ;
    }

    public int  SubjectID
    {
        get ; 
        set  ;
    }

    public string  ExamStartTime
    {
        get ; 
        set  ;
    }

    public int  ExamDuration
    {
        get ; 
        set  ;
    }

    public DateTime  ExamDate
    {
        get ; 
        set  ;
    }

    public int  ExamMarks
    {
        get ; 
        set  ;
    }

    public float  ObtainMarks
    {
        get ; 
        set  ;
    }

    public string  ExtraField1
    {
        get ; 
        set  ;
    }

    public string  ExtraField2
    {
        get ; 
        set  ;
    }

    public string  ExtraField3
    {
        get ; 
        set  ;
    }

    public string  ExtraField4
    {
        get ; 
        set  ;
    }

    public string  ExtraField5
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

    public DateTime  UpdatedDate
    {
        get ; 
        set  ;
    }

    public int  RowStatusID
    {
        get ; 
        set  ;
    }

}

