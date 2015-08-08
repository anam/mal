using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ClassStudent
{
    public STD_ClassStudent()
    {
    }


    public STD_ClassStudent
        (
            int  classStudentID,
            string  classStudentName,
            string  studentID,
            int  classID,
            string  addedBy,
            DateTime  addedDate,
            string  updatedBy,
            DateTime  updateDate,
            int rowStatusID
        )

    {
        this.ClassStudentID = classStudentID;
        this.ClassStudentName = classStudentName;
        this.StudentID = studentID;
        this.ClassID = classID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdateDate = updateDate;
        this.RowStatusID = rowStatusID;
    }

    public int  ClassStudentID
    {
        get ; 
        set  ;
    }

    public string  ClassStudentName
    {
        get ; 
        set  ;
    }

    public string  StudentID
    {
        get ; 
        set  ;
    }

    public int  ClassID
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

    public int RowStatusID
    {
        get;
        set;
    }
}

