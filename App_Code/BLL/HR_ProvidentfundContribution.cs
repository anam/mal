using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_ProvidentfundContribution
{
    public HR_ProvidentfundContribution()
    {
    }


    public HR_ProvidentfundContribution
        (
        int providentfundContributionID,
        string employeeID,
        int providentfundRulesID,
        decimal amount,
        string addedBy,
        DateTime addedDate,
        string modifiedBy,
        DateTime modifiedDate

        )
    {
        this.ProvidentfundContributionID = providentfundContributionID;
        this.EmployeeID = employeeID;
        this.ProvidentfundRulesID = providentfundRulesID;
        this.Amount = amount;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;

    }

    public int ProvidentfundContributionID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }


    public int ProvidentfundRulesID
    {
        get;
        set;
    }



    /// <summary>
    /// Security Money Amount
    /// </summary>
    public decimal Amount
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

