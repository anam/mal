using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_ProvidentFundSetup
{
    public HR_ProvidentFundSetup()
    {
    }


    public HR_ProvidentFundSetup
        (
            int providentFundSetupID,
            int serviceLenStartYear,
            int serviceLenEndYear,
            int fundTypeID,
            double fundPercentForEmp,
            string extraField1,
            string extraField2,
            string extraField3,
            string extraField4,
            string extraField5,
            string addedBy,
            DateTime addedDate,
            string modifiedBy,
            DateTime modifiedDate
        )
    {
        this.ProvidentFundSetupID = providentFundSetupID;
        this.ServiceLenStartYear = serviceLenStartYear;
        this.ServiceLenEndYear = serviceLenEndYear;
        this.FundTypeID = fundTypeID;
        this.FundPercentForEmp = fundPercentForEmp;
        this.ExtraField1 = extraField1;
        this.ExtraField2 = extraField2;
        this.ExtraField3 = extraField3;
        this.ExtraField4 = extraField4;
        this.ExtraField5 = extraField5;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;

    }

    public int ProvidentFundSetupID
    {
        get;
        set;
    }

    public int ServiceLenStartYear
    {
        get;
        set;
    }

    public int ServiceLenEndYear
    {
        get;
        set;
    }

    public int FundTypeID
    {
        get;
        set;
    }

    public double FundPercentForEmp
    {
        get;
        set;
    }

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

