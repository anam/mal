using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_EmployeeRank
{
    public HR_EmployeeRank()
    {
    }


    public HR_EmployeeRank
        (
int  employeeRankID,
string  rankName,
int  seniorityLevel,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.EmployeeRankID = employeeRankID;
this.RankName = rankName;
this.SeniorityLevel = seniorityLevel;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  EmployeeRankID
    {
        get ; 
        set  ;
    }

    public string  RankName
    {
        get ; 
        set  ;
    }

    public int  SeniorityLevel
    {
        get ; 
        set  ;
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

    public string  ModifiedBy
    {
        get ; 
        set  ;
    }

    public DateTime  ModifiedDate
    {
        get ; 
        set  ;
    }

}

