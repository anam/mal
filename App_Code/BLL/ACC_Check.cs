using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_Check
{
    public ACC_Check()
    {
    }


    public ACC_Check
        (
int  checkID,
string  checkNo,
string  bankAccountNo,
int  bankID,
string  branchNOtherDetails,
string  remarks,
bool  isCashCheck,
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
this.CheckID = checkID;
this.CheckNo = checkNo;
this.BankAccountNo = bankAccountNo;
this.BankID = bankID;
this.BranchNOtherDetails = branchNOtherDetails;
this.Remarks = remarks;
this.IsCashCheck = isCashCheck;
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

    public int  CheckID
    {
        get ; 
        set  ;
    }

    public string  CheckNo
    {
        get ; 
        set  ;
    }

    public string  BankAccountNo
    {
        get ; 
        set  ;
    }

    public int  BankID
    {
        get ; 
        set  ;
    }

    public string  BranchNOtherDetails
    {
        get ; 
        set  ;
    }
    /// <summary>
    /// Money
    /// </summary>
    public string  Remarks
    {
        get ; 
        set  ;
    }

    public bool  IsCashCheck
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// Bank id when Account payee check and when Cash pay then at the processing time we have to update the check for the bank ID
    /// </summary>
    public string  ExtraField1
    {
        get ; 
        set  ;
    }

    /// <summary>
    /// To Whom given
    /// HeadID 
    /// </summary>
    public string  ExtraField2
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// To Whom given
    /// JournalID
    /// </summary>
    public string  ExtraField3
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// Who gives
    /// HeadID
    /// </summary>
    public string  ExtraField4
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// Check Date
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

    public bool IsVisibleTransation
    {
        get;
        set;
    }

    public bool IsVisibleVouture
    {
        get;
        set;
    }
}

