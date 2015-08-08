using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class INV_Issue
{
    public INV_Issue()
    {
    }

    public INV_Issue
        (
            int issueID,
            int campusID,
            int issueMasterID,
            int storeID,
            string productionCode,
            decimal quantity,
            DateTime issueDate,
            string issueNo,
            string tagID,
            int itemID,
            string addedBy,
            DateTime addedDate,
            string updatedBy,
            DateTime updatedDate
        )
    {
        this.IssueID = issueID;
        this.CampusID = campusID;
        this.IssueMasterID = issueMasterID;
        this.StoreID = storeID;
        this.ProductionCode = productionCode;
        this.Quantity = quantity;
        this.IssueDate = issueDate;
        this.IssueNo = issueNo;
        this.TagID = tagID;
        this.ItemID = itemID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;

    }

    public int IssueID
    {
        get;
        set;
    }

    public int CampusID
    {
        get;
        set;
    }

    public int IssueMasterID
    {
        get;
        set;
    }

    public int StoreID
    {
        get;
        set;
    }

    public string ProductionCode
    {
        get;
        set;
    }

    public decimal Quantity
    {
        get;
        set;
    }

    public DateTime IssueDate
    {
        get;
        set;
    }

    public string IssueNo
    {
        get;
        set;
    }

    public string TagID
    {
        get;
        set;
    }

    public int ItemID
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

    public DateTime UpdatedDate
    {
        get;
        set;
    }
}

