using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_FeesType
{
    public STD_FeesType()
    {
    }


    public STD_FeesType
        (
int  feesTypeID,
string  feesTypeName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.FeesTypeID = feesTypeID;
this.FeesTypeName = feesTypeName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  FeesTypeID
    {
        get ; 
        set  ;
    }

    public string  FeesTypeName
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

    public int  RowStatusID
    {
        get ; 
        set  ;
    }

}

