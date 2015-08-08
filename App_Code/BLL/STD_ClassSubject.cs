using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ClassSubject
{
    public STD_ClassSubject()
    {
    }


    public STD_ClassSubject
        (
int  classSubjectID,
string  classSubjectName,
int  subjectID,
int  classID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ClassSubjectID = classSubjectID;
this.ClassSubjectName = classSubjectName;
this.SubjectID = subjectID;
this.ClassID = classID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  ClassSubjectID
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// RowStatusID
    /// </summary>
    public string  ClassSubjectName
    {
        get ; 
        set  ;
    }

    public int  SubjectID
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

    public string SubjectName
    {
        get;
        set;
    }


    /// <summary>
    /// Start Date of the class
    /// </summary>
    public string ExtraField1
    {
        get;
        set;
    }


    /// <summary>
    /// End Date of the class
    /// </summary>
    public string ExtraField2
    {
        get;
        set;
    }

    public string ExtraField3
    {
        get;
        set;
    }

    public string ExtraField4
    {
        get;
        set;
    }

    public string ExtraField5
    {
        get;
        set;
    }

    public int RowStatusID
    {
        get;
        set;
    }


}

