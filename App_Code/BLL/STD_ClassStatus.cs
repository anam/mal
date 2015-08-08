using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ClassStatus
{
    public STD_ClassStatus()
    {
    }


    public STD_ClassStatus
        (
int  classStatusID,
string  classStatusName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ClassStatusID = classStatusID;
this.ClassStatusName = classStatusName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  ClassStatusID
    {
        get ; 
        set  ;
    }

    public string  ClassStatusName
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

