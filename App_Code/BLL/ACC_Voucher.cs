using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_Voucher
{
    public ACC_Voucher()
    {
    }


    public ACC_Voucher
        (
int  voucherID,
string  voucherNo,
int  headID,
string  debitOrCredit,
string  fromTo,
        decimal amount,
string  onAccountOf,
string  inWord,
bool  isApproved,
DateTime  approvalDate,
DateTime  voucherDate,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID,
string  remarks

        )

    {
this.VoucherID = voucherID;
this.VoucherNo = voucherNo;
this.HeadID = headID;
this.DebitOrCredit = debitOrCredit;
this.FromTo = fromTo;
this.Amount = amount;
this.OnAccountOf = onAccountOf;
this.InWord = inWord;
this.IsApproved = isApproved;
this.ApprovalDate = approvalDate;
this.VoucherDate = voucherDate;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;
this.Remarks = remarks;

    }

    public int  VoucherID
    {
        get ; 
        set  ;
    }

    public string  VoucherNo
    {
        get ; 
        set  ;
    }

    public int  HeadID
    {
        get ; 
        set  ;
    }

    public string  DebitOrCredit
    {
        get ; 
        set  ;
    }

    public string  FromTo
    {
        get ; 
        set  ;
    }
    public decimal Amount
    {
        get;
        set;
    }
    public string  OnAccountOf
    {
        get ; 
        set  ;
    }

    public string  InWord
    {
        get ; 
        set  ;
    }

    public bool  IsApproved
    {
        get ; 
        set  ;
    }

    public DateTime  ApprovalDate
    {
        get ; 
        set  ;
    }

    public DateTime  VoucherDate
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

    public string  Remarks
    {
        get ; 
        set  ;
    }

}

