using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryAdjustmentList
{
    public HR_SalaryAdjustmentList()
    {
    }


    public HR_SalaryAdjustmentList
        (
        int salaryAdjustmentListID,
        int salaryAdjustmentGroupID,
        string name,
        decimal value,
        string addedBy,
        DateTime addedDate,
        string updatedBy,
        DateTime updatedDate
        )
    {
        this.SalaryAdjustmentListID = salaryAdjustmentListID;
        this.SalaryAdjustmentGroupID = salaryAdjustmentGroupID;
        this.Name = name;
        this.Value = value;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;

    }

    public int SalaryAdjustmentListID
    {
        get;
        set;
    }

    public int SalaryAdjustmentGroupID
    {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    }

    public decimal Value
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

    public DateTime UpdatedDate
    {
        get;
        set;
    }
}

