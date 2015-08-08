using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ExamDetails
{
    public STD_ExamDetails()
    {
    }


    public STD_ExamDetails
        (
int  examDetailsID,
int  examID,
int  examTypeID,
string  examDetailsName,
string  extraField1,
string  extraField2,
string  extraField3,
string  extraField4,
string  extraField5,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate,
int  rowStatusID,
decimal  totalMarks

        )

    {
this.ExamDetailsID = examDetailsID;
this.ExamID = examID;
this.ExamTypeID = examTypeID;
this.ExamDetailsName = examDetailsName;
this.ExtraField1 = extraField1;
this.ExtraField2 = extraField2;
this.ExtraField3 = extraField3;
this.ExtraField4 = extraField4;
this.ExtraField5 = extraField5;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;
this.RowStatusID = rowStatusID;
this.TotalMarks = totalMarks;

    }

    public int  ExamDetailsID
    {
        get ; 
        set  ;
    }

    public int  ExamID
    {
        get ; 
        set  ;
    }

    public int  ExamTypeID
    {
        get ; 
        set  ;
    }

    public string  ExamDetailsName
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

    public DateTime  UpdatedDate
    {
        get ; 
        set  ;
    }

    public int  RowStatusID
    {
        get ; 
        set  ;
    }

    public decimal  TotalMarks
    {
        get ; 
        set  ;
    }

    public string ExamName
    {
        get;
        set;
    }
}

