using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_SubjectEmployee
{
    public STD_SubjectEmployee()
    {
    }


    public STD_SubjectEmployee
        (
            int SubjectEmployeeID,
            string SubjectEmployeeName,
            string EmployeeID,
            int SubjectID,
            string addedBy,
            DateTime addedDate,
            string updatedBy,
            DateTime updateDate,
            int rowStatusID
        )
    {
        this.SubjectEmployeeID = SubjectEmployeeID;
        this.SubjectEmployeeName = SubjectEmployeeName;
        this.EmployeeID = EmployeeID;
        this.SubjectID = SubjectID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdateDate = updateDate;
        this.RowStatusID = rowStatusID;
    }

    public int SubjectEmployeeID
    {
        get;
        set;
    }

    public string SubjectEmployeeName
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }

    public int SubjectID
    {
        get;
        set;
    }

    public int CampusID
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

    public int RowStatusID
    {
        get;
        set;
    }
}

