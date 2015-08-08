using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_PaymentStatus
{
    public COMN_PaymentStatus()
    {
    }


    public COMN_PaymentStatus
        (
int  paymentStatusID,
string  paymentStatusName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.PaymentStatusID = paymentStatusID;
this.PaymentStatusName = paymentStatusName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  PaymentStatusID
    {
        get ; 
        set  ;
    }

    public string  PaymentStatusName
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

