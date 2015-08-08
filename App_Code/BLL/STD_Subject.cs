using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Subject
{
    public STD_Subject()
    {
    }


    public STD_Subject
        (
            int subjectID,
            int courseID,
            string subjectName,
            string description,
            string extraField1,
            string extraField2,
            string extraField3,
            string extraField4,
            string extraField5,
            string addedBy,
            DateTime addedDate,
            string updatedBy,
            DateTime updateDate

        )
    {
        this.SubjectID = subjectID;
        this.CourseID = courseID;
        this.SubjectName = subjectName;
        this.Description = description;
        this.ExtraField1 = extraField1;
        this.ExtraField2 = extraField2;
        this.ExtraField3 = extraField3;
        this.ExtraField4 = extraField4;
        this.ExtraField5 = extraField5;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdateDate = updateDate;

    }

    public int  SubjectID
    {
        get ; 
        set  ;
    }

    public int  CourseID
    {
        get ; 
        set  ;
    }

    public string  SubjectName
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// Indicate Pass or fail by this field
    /// Insert % mark into this Extra field
    /// within 100 marks for pass or fail   
    /// </summary>
    
    
     public string ExtraField1
    {
        get;
        set;
    }
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

    public string CourseName
    {
        get;
        set;
    }
}

