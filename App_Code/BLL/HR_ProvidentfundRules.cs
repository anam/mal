using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_ProvidentfundRules
{
    public HR_ProvidentfundRules()
    {
    }


    public HR_ProvidentfundRules
        (
        int providentfundRulesID,
        decimal value,
        bool isGrossPortion,
        string addedBy,
        DateTime addedDate,
        string modifiedBy,
        DateTime modifiedDate
        )
    {
        this.ProvidentfundRulesID = providentfundRulesID;
        this.Value = value;
        this.IsGrossPortion = isGrossPortion;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }

    public int ProvidentfundRulesID
    {
        get;
        set;
    }

    public decimal Value
    {
        get;
        set;
    }

    public bool IsGrossPortion
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

