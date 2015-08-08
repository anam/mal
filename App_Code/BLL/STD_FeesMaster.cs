using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_FeesMaster
{
    public STD_FeesMaster()
    {
    }


    public STD_FeesMaster
        (
int  feesMasterID,
string  feesMasterName,
decimal  totalPayment,
decimal  discount,
decimal  totalPaymentNeedtoPay,
int  feesTypeID,
DateTime  submissionDate,
string  submitedDate,
string  studentID,
int  courseID,
string  remarks,
bool  isPaid,
int  paymentStatusID,
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
this.FeesMasterID = feesMasterID;
this.FeesMasterName = feesMasterName;
this.TotalPayment = totalPayment;
this.Discount = discount;
this.TotalPaymentNeedtoPay = totalPaymentNeedtoPay;
this.FeesTypeID = feesTypeID;
this.SubmissionDate = submissionDate;
this.SubmitedDate = submitedDate;
this.StudentID = studentID;
this.CourseID = courseID;
this.Remarks = remarks;
this.IsPaid = isPaid;
this.PaymentStatusID = paymentStatusID;
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

    public int  FeesMasterID
    {
        get ; 
        set  ;
    }

    public string  FeesMasterName
    {
        get ; 
        set  ;
    }

    public decimal  TotalPayment
    {
        get ; 
        set  ;
    }

    public decimal  Discount
    {
        get ; 
        set  ;
    }

    public decimal  TotalPaymentNeedtoPay
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

    public string  Remarks
    {
        get ; 
        set  ;
    }

    public bool  IsPaid
    {
        get ; 
        set  ;
    }

    public int  PaymentStatusID
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// Total Paid Amount
    /// </summary>
    public string  ExtraField1
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// Total UnPaid Amount
    /// </summary>
    public string  ExtraField2
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// Message to pint in the money receipt
    /// </summary>
    public string  ExtraField3
    {
        get ; 
        set  ;
    }
   
    /// <summary>
    /// JournalID 
    /// </summary>
    public string  ExtraField4
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// For semester fee the latest fee amount
    /// </summary>
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

