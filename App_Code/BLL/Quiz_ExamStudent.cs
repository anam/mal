using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_ExamStudent
{
    public Quiz_ExamStudent()
    {
    }


    public Quiz_ExamStudent
        (
int  examStudentID,
string  examStudentName,
string  studentID,
int  classSubjectID,
int  sTDExamDetailsID,
int  quizExamID,
string  extraField1,
string  extraField2,
string  extraField3,
string  extraField4,
string  extraField5,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.ExamStudentID = examStudentID;
this.ExamStudentName = examStudentName;
this.StudentID = studentID;
this.ClassSubjectID = classSubjectID;
this.STDExamDetailsID = sTDExamDetailsID;
this.QuizExamID = quizExamID;
this.ExtraField1 = extraField1;
this.ExtraField2 = extraField2;
this.ExtraField3 = extraField3;
this.ExtraField4 = extraField4;
this.ExtraField5 = extraField5;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  ExamStudentID
    {
        get ; 
        set  ;
    }

    public string  ExamStudentName
    {
        get ; 
        set  ;
    }

    public string  StudentID
    {
        get ; 
        set  ;
    }

    public int  ClassSubjectID
    {
        get ; 
        set  ;
    }

    public int  STDExamDetailsID
    {
        get ; 
        set  ;
    }

    public int  QuizExamID
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

    public DateTime  UpdateDate
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

