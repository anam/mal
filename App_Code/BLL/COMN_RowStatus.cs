using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_RowStatus
{
    public COMN_RowStatus()
    {
    }


    public COMN_RowStatus
        (
int  rowStatusID,
string  rowStatusName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.RowStatusID = rowStatusID;
this.RowStatusName = rowStatusName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  RowStatusID
    {
        get ; 
        set  ;
    }

    public string  RowStatusName
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

