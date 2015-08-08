using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Class
{
    public STD_Class()
    {
    }


    public STD_Class
        (
int classID,
string className,
int courseID,
int classTypeID,
int classStatusID,
string addedBy,
DateTime addedDate,
string updatedBy,
DateTime updateDate

        )
    {
        this.ClassID = classID;
        this.ClassName = className;
        this.CourseID = courseID;
        this.ClassTypeID = classTypeID;
        this.ClassStatusID = classStatusID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdateDate = updateDate;

    }


    public STD_Class
       (

        string className,
        string  courseName,

        string subjectName,
        string employeeName

       )
    {
        this.ClassName = className;
        this.CourseName = courseName;
        this.SubjectName = subjectName;
        this.EmployeeName = employeeName;

    }

    public int ClassID
    {
        get;
        set;
    }

    public string ClassName
    {
        get;
        set;
    }

    public int CourseID
    {
        get;
        set;
    }

    public int ClassTypeID
    {
        get;
        set;
    }

    public int ClassStatusID
    {
        get;
        set;
    }

    public string AddedBy
    {
        get;
        set;
    }

    public DateTime AddedDate
    {
        get;
        set;
    }

    public string UpdatedBy
    {
        get;
        set;
    }

    public DateTime UpdateDate
    {
        get;
        set;
    }

    public string CourseName
    {
        get;
        set;
    }
    public string ClassTypeName
    {
        get;
        set;
    }

    public string ClassStatusName
    {
        get;
        set;
    }

    public string SubjectName
    {
        get;
        set;
    }
    public string EmployeeName
    {
        get;
        set;
    }

    public int SubjectID
    {
        get;
        set;
    }
    public string EmployeeID
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

