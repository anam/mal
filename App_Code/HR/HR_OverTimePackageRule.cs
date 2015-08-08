using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_OverTimePackageRule
{
    public HR_OverTimePackageRule()
    {
    }


    public HR_OverTimePackageRule
        (
int  overTimeRuleID,
int  overTimePackageID,
string  overTimeRuleName,
int  overTimeRuleValue,
string  overTimeRuleOperator

        )

    {
this.OverTimeRuleID = overTimeRuleID;
this.OverTimePackageID = overTimePackageID;
this.OverTimeRuleName = overTimeRuleName;
this.OverTimeRuleValue = overTimeRuleValue;
this.OverTimeRuleOperator = overTimeRuleOperator;

    }

    public int  OverTimeRuleID
    {
        get ; 
        set  ;
    }

    public int  OverTimePackageID
    {
        get ; 
        set  ;
    }

    public string  OverTimeRuleName
    {
        get ; 
        set  ;
    }

    public int  OverTimeRuleValue
    {
        get ; 
        set  ;
    }

    public string  OverTimeRuleOperator
    {
        get ; 
        set  ;
    }

}

