using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_AccountingCommonManager
{
    public ACC_AccountingCommonManager()
	{
	}

    public static DataSet GetACC_DailyAssetOpeningNClosingBalance(DateTime fromDate, DateTime toDate,string userID)
    {
        DataSet aCC_Accounts = new DataSet();
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        aCC_Accounts = sqlACC_AccountingCommonProvider.GetACC_DailyAssetOpeningNClosingBalance(fromDate,toDate,userID);
        return aCC_Accounts;
    }


    public static DataSet ExecSQL(string sql)
    {
        DataSet aCC_Accounts = new DataSet();
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        aCC_Accounts = sqlACC_AccountingCommonProvider.COMN_ExecSQL(sql);
        return aCC_Accounts;
    }


    public static bool ProcessACC_ProvidentFund(string userID,ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_ProvidentFund(userID,aCC_Jounal);
    }

    public static bool ProcessACC_JournalHistory(string userID, ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_JournalHistory(userID, aCC_Jounal);
    }

    public static bool ProcessACC_SecurityAmount(string userID, ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_SecurityAmount(userID, aCC_Jounal);
    }

    public static bool ProcessACC_AdvanceSalary(string userID, ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_AdvanceSalary(userID, aCC_Jounal);
    }

    public static bool ProcessACC_FullTimeSalary(string userID, ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_FullTimeSalary(userID, aCC_Jounal);
    }

    public static bool ProcessACC_CPF(string userID, ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_CPF(userID, aCC_Jounal);
    }

    public static bool ProcessACC_EPF(string userID, ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_EPF(userID, aCC_Jounal);
    }


    public static bool ProcessACC_AdvanceSalaryFromEPF(string userID, ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_AdvanceSalaryFromEPF(userID, aCC_Jounal);
    }

    public static bool ProcessACC_AdvanceSalaryFromCPF(string userID, ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_AdvanceSalaryFromCPF(userID, aCC_Jounal);
    }

    public static bool ProcessACC_RefundCPF(string userID, ACC_Journal aCC_Jounal)
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessACC_RefundCPF(userID, aCC_Jounal);
    }



    public static string ProcessDataBackup()
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        return sqlACC_AccountingCommonProvider.ProcessDataBackup();
    }

    public static void ProcessDataBackupAuto()
    {
        SqlACC_AccountingCommonProvider sqlACC_AccountingCommonProvider = new SqlACC_AccountingCommonProvider();
        sqlACC_AccountingCommonProvider.ProcessDataBackupAuto();
       return;
    }
}

