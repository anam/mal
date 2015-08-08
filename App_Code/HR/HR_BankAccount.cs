using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_BankAccount
{
    public HR_BankAccount()
    {
    }

    public HR_BankAccount
        (
        int bankAccountNoID,
        string employeeID,
        string accountName,
        string accountNo,
        string bankName,
        string contactPerson,
        string bankAddress,
        string addedBy,
        DateTime addedDate,
        string modifiedBy,
        DateTime modifiedDate
        )
    {
        this.BankAccountNoID = bankAccountNoID;
        this.EmployeeID = employeeID;
        this.AccountName = accountName;
        this.AccountNo = accountNo;
        this.BankName = bankName;
        this.ContactPerson = contactPerson;
        this.BankAddress = bankAddress;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }

    public int BankAccountNoID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }

    public string AccountName
    {
        get;
        set;
    }

    public string AccountNo
    {
        get;
        set;
    }


    public string BankName
    {
        get;
        set;
    }

    public string ContactPerson
    {
        get;
        set;
    }

    public string BankAddress
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

    public string ModifiedBy
    {
        get;
        set;
    }

    public DateTime ModifiedDate
    {
        get;
        set;
    }
}

