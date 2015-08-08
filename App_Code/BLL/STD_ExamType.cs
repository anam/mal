using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ExamType
{
    public STD_ExamType()
    {
    }


    public STD_ExamType
        (
int  examTypeID,
string  examTypeName,
string  extraField1,
string  extraField2,
string  extraField3,
string  extraField4,
string  extraField5,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.ExamTypeID = examTypeID;
this.ExamTypeName = examTypeName;
this.ExtraField1 = extraField1;
this.ExtraField2 = extraField2;
this.ExtraField3 = extraField3;
this.ExtraField4 = extraField4;
this.ExtraField5 = extraField5;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  ExamTypeID
    {
        get ; 
        set  ;
    }

    public string  ExamTypeName
    {
        get ; 
        set  ;
    }

    public string  ExtraField1
    {
        get ; 
        set  ;
    }

    public string  ExtraField2
    {
        get ; 
        set  ;
    }

    public string  ExtraField3
    {
        get ; 
        set  ;
    }

    public string  ExtraField4
    {
        get ; 
        set  ;
    }

    public string  ExtraField5
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

