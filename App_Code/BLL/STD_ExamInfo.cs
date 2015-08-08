using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ExamInfo
{
    public STD_ExamInfo()
    {
    }


    public STD_ExamInfo
        (
int  examInfoID,
int  campusID,
int  batchID,
int  semesterID,
string  subjectTeacherID,
int  examTypeID,
string  examInfoName,
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
this.ExamInfoID = examInfoID;
this.CampusID = campusID;
this.BatchID = batchID;
this.SemesterID = semesterID;
this.SubjectTeacherID = subjectTeacherID;
this.ExamTypeID = examTypeID;
this.ExamInfoName = examInfoName;
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

    public int  ExamInfoID
    {
        get ; 
        set  ;
    }

    public int  CampusID
    {
        get ; 
        set  ;
    }

    public int  BatchID
    {
        get ; 
        set  ;
    }

    public int  SemesterID
    {
        get ; 
        set  ;
    }

    public string  SubjectTeacherID
    {
        get ; 
        set  ;
    }

    public int  ExamTypeID
    {
        get ; 
        set  ;
    }

    public string  ExamInfoName
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

