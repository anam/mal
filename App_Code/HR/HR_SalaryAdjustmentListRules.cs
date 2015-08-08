
using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryAdjustmentListRules
{
    public HR_SalaryAdjustmentListRules()
    {

    }

    public HR_SalaryAdjustmentListRules
        (
            int salaryAdjustmentListRulesID,
            string employeeID,
            int salaryAdjustmentGroupID,
            string addedBy,
            DateTime addedDate,
            string updatedBy,
            DateTime updatedDate
        )
    {
        this.SalaryAdjustmentListRulesID = salaryAdjustmentListRulesID;
        this.EmployeeID = employeeID;
        this.SalaryAdjustmentGroupID = salaryAdjustmentGroupID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
    }

    public int SalaryAdjustmentListRulesID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }

    public int SalaryAdjustmentGroupID
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

