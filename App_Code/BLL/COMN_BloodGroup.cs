using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_BloodGroup
{
    public COMN_BloodGroup()
    {
    }


    public COMN_BloodGroup
        (
int  bloodGroupID,
string  bloodGroupName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.BloodGroupID = bloodGroupID;
this.BloodGroupName = bloodGroupName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  BloodGroupID
    {
        get ; 
        set  ;
    }

    public string  BloodGroupName
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

