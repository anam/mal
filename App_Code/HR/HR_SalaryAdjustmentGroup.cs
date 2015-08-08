using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryAdjustmentGroup
{
    public HR_SalaryAdjustmentGroup()
    {
    }


    public HR_SalaryAdjustmentGroup
        (
        int salaryAdjustmentGroupID,
        string groupName,
        string addedBy,
        DateTime addedDate
        )
    {
        this.SalaryAdjustmentGroupID = salaryAdjustmentGroupID;
        this.GroupName = groupName;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
    }

    public HR_SalaryAdjustmentGroup
       (
       int salaryAdjustmentGroupID,
       string groupName,
       string addedBy,
       DateTime addedDate,
        string modifiedBy,
       DateTime modifiedDate
       )
    {
        this.SalaryAdjustmentGroupID = salaryAdjustmentGroupID;
        this.GroupName = groupName;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }

    public int  SalaryAdjustmentGroupID
    {
        get ; 
        set  ;
    }

    public string GroupName
    {
        get ; 
        set  ;
    }

   
    public string AddedBy
    {
        get ; 
        set  ;
    }

    public DateTime AddedDate
    {
        get;
        set;
    }

    public string ModifiedBy
    {
        get;
        set;
    }

    public DateTime ModifiedDate
    {
        get;
        set;
    }

}

