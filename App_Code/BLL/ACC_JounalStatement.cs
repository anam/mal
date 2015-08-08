using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_JournalStatement
{
    public ACC_JournalStatement()
    {
        this.AccountID = 0;
        this.AccountName = "";
        this.Balance = 0;
        this.BalanceBasicAccount = 0;
        this.BalanceSubBasicAccount = 0;
        this.BasicAccountID = 0;
        this.BasicAccountName = "";
        this.SubBasicAccountID = 0;
        this.SubBasicAccountName = "";        
    }

    public string BasicAccountName
    {
        get;
        set;
    }

    public string SubBasicAccountName
    {
        get;
        set;
    }


    public string AccountName
    {
        get;
        set;
    }

    public decimal Balance
    {
        get;
        set;
    }

    public decimal BalanceSubBasicAccount
    {
        get;
        set;
    }

    public decimal BalanceBasicAccount
    {
        get;
        set;
    }

    public int AccountID
    {
        get;
        set;
    }




        
    public int BasicAccountID
    {
        get;
        set;
    }

    

    public int SubBasicAccountID
    {
        get;
        set;
    }

    public string htmlCode
    {
        get;
        set;
    }
}

