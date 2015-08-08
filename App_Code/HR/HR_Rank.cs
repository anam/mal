using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Rank
{
    public HR_Rank()
    {
    }


    public HR_Rank
        (
int  rankID,
string  rankName,
int  seniorityLevel,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.RankID = rankID;
this.RankName = rankName;
this.SeniorityLevel = seniorityLevel;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  RankID
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

}

