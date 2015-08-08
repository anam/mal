using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_SubjectStudent
{
    public STD_SubjectStudent()
    {
    }


    public STD_SubjectStudent
        (
int  subjectStudentID,
string  subjectStudentName,
string  studentID,
int  subjectID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.SubjectStudentID = subjectStudentID;
this.SubjectStudentName = subjectStudentName;
this.StudentID = studentID;
this.SubjectID = subjectID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  SubjectStudentID
    {
        get ; 
        set  ;
    }

    public string  SubjectStudentName
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

