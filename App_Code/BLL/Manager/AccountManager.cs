using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class AccountManager
{
	public AccountManager()
	{
	}

    public static List<Account> GetAllAccounts()
    {
        List<Account> accounts = new List<Account>();
        SqlAccountProvider sqlAccountProvider = new SqlAccountProvider();
        accounts = sqlAccountProvider.GetAllAccounts();
        return accounts;
    }


    public static List<Account> CUCTEST_GetAmountByS_ID(string s_id)
    {
        List<Account> accounts = new List<Account>();
        SqlAccountProvider sqlAccountProvider = new SqlAccountProvider();
        accounts = sqlAccountProvider.CUCTEST_GetAmountByS_ID(s_id);
        return accounts;
    }

    public static Account GetAccountByID(int id)
    {
        Account account = new Account();
        SqlAccountProvider sqlAccountProvider = new SqlAccountProvider();
        account = sqlAccountProvider.GetAccountByID(id);
        return account;
    }


    public static int InsertAccount(Account account)
    {
        SqlAccountProvider sqlAccountProvider = new SqlAccountProvider();
        return sqlAccountProvider.InsertAccount(account);
    }


    public static bool UpdateAccount(Account account)
    {
        SqlAccountProvider sqlAccountProvider = new SqlAccountProvider();
        return sqlAccountProvider.UpdateAccount(account);
    }

    public static bool DeleteAccount(int accountID)
    {
        SqlAccountProvider sqlAccountProvider = new SqlAccountProvider();
        return sqlAccountProvider.DeleteAccount(accountID);
    }
}
