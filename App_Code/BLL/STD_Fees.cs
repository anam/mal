using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Fees
{
    public STD_Fees()
    {
    }


    public STD_Fees
        (
int  feesID,
string  feesName,
decimal  amount,
int  feesTypeID,
DateTime  submissionDate,
string  submitedDate,
string  studentID,
int  courseID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID,
string  remarks,
bool  isPaid

        )

    {
this.FeesID = feesID;
this.FeesName = feesName;
this.Amount = amount;
this.FeesTypeID = feesTypeID;
this.SubmissionDate = submissionDate;
this.SubmitedDate = submitedDate;
this.StudentID = studentID;
this.CourseID = courseID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;
this.Remarks = remarks;
this.IsPaid = isPaid;

    }

    public int  FeesID
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// FeesMasterID
    /// </summary>
    public string  FeesName
    {
        get ; 
        set  ;
    }


    public string PaymentStatus
    {
        get;
        set;
    }

    public decimal  Amount
    {
        get ; 
        set  ;
    }

    public int  FeesTypeID
    {
        get ; 
        set  ;
    }

    public DateTime  SubmissionDate
    {
        get ; 
        set  ;
    }

    public string  SubmitedDate
    {
        get ; 
        set  ;
    }

    public string  StudentID
    {
        get ; 
        set  ;
    }


    
    public int  CourseID
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

    /// <summary>
    /// Amount already paid
    /// </summary>
    public string  Remarks
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// Unpaid Amount
    /// </summary>
    public decimal UnpaidAmount
    {
        get;
        set;
    }

    public bool  IsPaid
    {
        get ; 
        set  ;
    }


    public bool IsEnabled
    {
        get;
        set;
    }

    public string StudentName
    {
        get;
        set;
    }

    public string StudentCode
    {
        get;
        set;
    }

    public string Mobile
    {
        get;
        set;
    }

    public string PresentAddress
    {
        get;
        set;
    }
}

