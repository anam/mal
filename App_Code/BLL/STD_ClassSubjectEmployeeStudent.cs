using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ClassSubjectEmployeeStudent
{
    public STD_ClassSubjectEmployeeStudent()
    {
    }


    public STD_ClassSubjectEmployeeStudent
        (
int  classSubjectEmployeeStudentID,
int  classSubjectEmployeeID,
string  studentID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID,
        string ExtraField1,
        string ExtraField2
        )

    {
this.ClassSubjectEmployeeStudentID = classSubjectEmployeeStudentID;
this.ClassSubjectEmployeeID = classSubjectEmployeeID;
this.StudentID = studentID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;
this.ExtraField1 = ExtraField1;
this.ExtraField2 = ExtraField2;
    }

    public int  ClassSubjectEmployeeStudentID
    {
        get ; 
        set  ;
    }

    public int  ClassSubjectEmployeeID
    {
        get ; 
        set  ;
    }

    public string  StudentID
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
    public int NoOfStudent
    {
        get;
        set;
    }

    public string StudentName
    {
        get;
        set;
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


    /// <summary>
    /// for Date time Start and End
    /// </summary>
    public string ExtraField1
    {
        get;
        set;
    }
    /// <summary>
    /// For Storing the EmployeeID
    /// </summary>
    public string ExtraField2
    {
        get;
        set;
    }

    

    /// <summary>
    /// Exam Recovery
    /// </summary>
    public string ExtraField3
    {
        get;
        set;
    }


   /// <summary>
   /// Today Remark
   /// </summary>
    public string TodayRemark
    {
        get;
        set;
    }


    
    public bool IsExam
    {
        get;
        set;
    }

    public bool IsAbsence
    {
        get;
        set;
    }
   
    public DateTime StartTime
    {
        get;
        set;
    }

    public DateTime EndTime
    {
        get;
        set;
    }
}

