using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ExamStudent
{
    public STD_ExamStudent()
    {
    }


    public STD_ExamStudent
        (
int  examStudentID,
string  examStudent,
int  examID,
string  studentID,
decimal  obtainedMark,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ExamStudentID = examStudentID;
this.ExamStudent = examStudent;
this.ExamID = examID;
this.StudentID = studentID;
this.ObtainedMark = obtainedMark;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  ExamStudentID
    {
        get ; 
        set  ;
    }

    public string  ExamStudent
    {
        get ; 
        set  ;
    }

    public int  ExamID
    {
        get ; 
        set  ;
    }

    public string  StudentID
    {
        get ; 
        set  ;
    }

    public decimal  ObtainedMark
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

