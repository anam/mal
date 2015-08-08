using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Exam
{
    public STD_Exam()
    {
    }


    public STD_Exam
        (
int  examID,
string  examName,
string  description,
int  classSubjectID,
int  examTypeID,
Decimal  totalMarks,
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
this.ExamID = examID;
this.ExamName = examName;
this.Description = description;
this.ClassSubjectID = classSubjectID;
this.ExamTypeID = examTypeID;
this.TotalMarks = totalMarks;
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

    public int  ExamID
    {
        get ; 
        set  ;
    }

    public string  ExamName
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    public int  ClassSubjectID
    {
        get ; 
        set  ;
    }

    public int  ExamTypeID
    {
        get ; 
        set  ;
    }

    public Decimal TotalMarks
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

    public string ClassName
    {
        get;
        set;
    }
    public string SubjectName
    {
        get;
        set;
    }

    public string ExamTypeName
    {
        get;
        set;
    }
}

