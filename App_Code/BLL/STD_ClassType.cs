using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ClassType
{
    public STD_ClassType()
    {
    }


    public STD_ClassType
        (
int  classTypeID,
string  classTypeName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ClassTypeID = classTypeID;
this.ClassTypeName = classTypeName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  ClassTypeID
    {
        get ; 
        set  ;
    }

    public string  ClassTypeName
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

