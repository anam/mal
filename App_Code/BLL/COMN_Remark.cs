using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_Remark
{
    public COMN_Remark()
    {
    }


    public COMN_Remark
        (
int  remarkID,
string  remarkName,
string  remark,
DateTime  remarkDate,
string  whoReported,
string  whoDid,
string  extraField1,
string  extraField2,
string  extraField3,
string  extraField4,
string  extraField5,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate,
int  rowStatusID

        )

    {
this.RemarkID = remarkID;
this.RemarkName = remarkName;
this.Remark = remark;
this.RemarkDate = remarkDate;
this.WhoReported = whoReported;
this.WhoDid = whoDid;
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

    }

    public int  RemarkID
    {
        get ; 
        set  ;
    }

    public string  RemarkName
    {
        get ; 
        set  ;
    }

    public string  Remark
    {
        get ; 
        set  ;
    }

    public DateTime  RemarkDate
    {
        get ; 
        set  ;
    }

    public string  WhoReported
    {
        get ; 
        set  ;
    }

    public string  WhoDid
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

}

