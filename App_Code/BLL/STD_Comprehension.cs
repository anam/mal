using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Comprehension
{
    public STD_Comprehension()
    {
    }


    public STD_Comprehension
        (
int  comprehensionID,
string  comprehensionName,
string  description,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ComprehensionID = comprehensionID;
this.ComprehensionName = comprehensionName;
this.Description = description;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  ComprehensionID
    {
        get ; 
        set  ;
    }

    public string  ComprehensionName
    {
        get ; 
        set  ;
    }

    public string  Description
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

