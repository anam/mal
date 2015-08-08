using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ClassSubjectStudent
{
    public STD_ClassSubjectStudent()
    {
    }


    public STD_ClassSubjectStudent
        (
            int  classSubjectStudentID,
            string  classSubjectStudentName,
            string  studentID,
            int  classSubjectID,
            string  addedBy,
            DateTime  addedDate,
            string  updatedBy,
            DateTime  updateDate,
            int rowStatusID

        )

    {
        this.ClassSubjectStudentID = classSubjectStudentID;
        this.ClassSubjectStudentName = classSubjectStudentName;
        this.StudentID = studentID;
        this.ClassSubjectID = classSubjectID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdateDate = updateDate;
        this.RowStatusID = rowStatusID;

    }

    public int  ClassSubjectStudentID
    {
        get ; 
        set  ;
    }

    public string  ClassSubjectStudentName
    {
        get ; 
        set  ;
    }

    public string  StudentID
    {
        get ; 
        set  ;
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

    public int  ClassSubjectID
    {
        get ; 
        set  ;
    }

    public string ClassSubjectIDs
    {
        get;
        set;
    }


    public int ClassID
    {
        get;
        set;
    }

    public int SubjectID
    {
        get;
        set;
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

    public int RowStatusID
    {
        get;
        set;
    }

    public int ID
    {
        get;
        set;
    }
}

