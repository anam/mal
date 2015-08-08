using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Batch
{
    public STD_Batch()
    {
    }


    public STD_Batch
        (
            int  BatchID,
            string  BatchName,
            int year,
            int id,
            string batchCode,

            string extraField1,
            string extraField2,
            string extraField3,
            string extraField4,
            string extraField5,

            string  addedBy,
            DateTime  addedDate,
            string  updatedBy,
            DateTime  updateDate,
            int  rowStatusID
        )

    {
            this.BatchID = BatchID;
            this.BatchName = BatchName;
           
            this.Year = year;
            this.ID = id;
            this.BatchCode = batchCode;

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

    public STD_Batch
        (
            
            int maxID

        )
    {
        this.MaxID=maxID;
        
    }

    public int  BatchID
    {
        get ; 
        set  ;
    }

    public string  BatchName
    {
        get ; 
        set  ;
    }

   

    public int Year
    {
        get;
        set;
    }
    public int ID
    {
        get;
        set;
    }

    public string BatchCode
    {
        get;
        set;
    }

    public string ExtraField1
    {
        get;
        set;
    }

    public string ExtraField2
    {
        get;
        set;
    }

    public string ExtraField3
    {
        get;
        set;
    }

    public string ExtraField4
    {
        get;
        set;
    }

    public string ExtraField5
    {
        get;
        set;
    }

  

    public string AddedBy
    {
        get;
        set;
    }

    public DateTime AddedDate
    {
        get;
        set;
    }

    public string UpdatedBy
    {
        get;
        set;
    }

    public DateTime UpdateDate
    {
        get;
        set;
    }

    public int RowStatusID
    {
        get;
        set;
    }

    public int MaxID
    {
        get;
        set;
    }

    public string RowStatusName
    {
        get;
        set;
    }
}

