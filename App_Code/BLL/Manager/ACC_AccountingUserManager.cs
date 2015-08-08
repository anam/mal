using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_AccountingUserManager
{
	public ACC_AccountingUserManager()
	{
	}

    public static DataSet  GetAllACC_AccountingUsers()
    {
       DataSet aCC_AccountingUsers = new DataSet();
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        aCC_AccountingUsers = sqlACC_AccountingUserProvider.GetAllACC_AccountingUsers();
        return aCC_AccountingUsers;
    }

    public static DataSet GetAllACC_AccountingUsersOnlyBank()
    {
        DataSet aCC_AccountingUsers = new DataSet();
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        aCC_AccountingUsers = sqlACC_AccountingUserProvider.GetAllACC_AccountingUsersOnlyBank();
        return aCC_AccountingUsers;
    }

	public static void aCC_AccountingUsersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
		{
		double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
		int pageCount = (int)Math.Ceiling(dblPageCount);
		List<ListItem> pages = new List<ListItem>();
		if (pageCount > 0)
		{
 		pages.Add(new ListItem("First", "1", currentPage > 1));
		for (int i = 1; i <= pageCount; i++)
		{
		 pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
		}
		pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
		}
		rptPager.DataSource = pages;
		rptPager.DataBind();
		}
 	public static void LoadACC_AccountingUserPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
		DataSet ds =  sqlACC_AccountingUserProvider.GetACC_AccountingUserPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_AccountingUsersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_AccountingUser()
    {
       DataSet aCC_AccountingUsers = new DataSet();
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        aCC_AccountingUsers = sqlACC_AccountingUserProvider.GetDropDownLisAllACC_AccountingUser();
        return aCC_AccountingUsers;
    }


    public static ACC_AccountingUser GetACC_UserTypeByUserTypeID(int UserTypeID)
    {
        ACC_AccountingUser aCC_AccountingUser = new ACC_AccountingUser();
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        aCC_AccountingUser = sqlACC_AccountingUserProvider.GetACC_AccountingUserByUserTypeID(UserTypeID);
        return aCC_AccountingUser;
    }

    public static DataSet GetACC_UserTypeByUserTypeID(int UserTypeID,bool isdataset)
    {
        DataSet aCC_AccountingUser = new DataSet();
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        aCC_AccountingUser = sqlACC_AccountingUserProvider.GetACC_AccountingUserByUserTypeID(UserTypeID,isdataset);
        return aCC_AccountingUser;
    }

    public static ACC_AccountingUser GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_AccountingUser aCC_AccountingUser = new ACC_AccountingUser();
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        aCC_AccountingUser = sqlACC_AccountingUserProvider.GetACC_AccountingUserByRowStatusID(RowStatusID);
        return aCC_AccountingUser;
    }


    public static ACC_AccountingUser GetACC_AccountingUserByAccountingUserID(int AccountingUserID)
    {
        ACC_AccountingUser aCC_AccountingUser = new ACC_AccountingUser();
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        aCC_AccountingUser = sqlACC_AccountingUserProvider.GetACC_AccountingUserByAccountingUserID(AccountingUserID);
        return aCC_AccountingUser;
    }


    public static int InsertACC_AccountingUser(ACC_AccountingUser aCC_AccountingUser)
    {
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        return sqlACC_AccountingUserProvider.InsertACC_AccountingUser(aCC_AccountingUser);
    }


    public static bool UpdateACC_AccountingUser(ACC_AccountingUser aCC_AccountingUser)
    {
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        return sqlACC_AccountingUserProvider.UpdateACC_AccountingUser(aCC_AccountingUser);
    }

    public static bool DeleteACC_AccountingUser(int aCC_AccountingUserID)
    {
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        return sqlACC_AccountingUserProvider.DeleteACC_AccountingUser(aCC_AccountingUserID);
    }

    public static DataSet GetACC_BankForChecks()
    {
        DataSet aCC_AccountingUsers = new DataSet();
        SqlACC_AccountingUserProvider sqlACC_AccountingUserProvider = new SqlACC_AccountingUserProvider();
        aCC_AccountingUsers = sqlACC_AccountingUserProvider.GetACC_BankForChecks();
        return aCC_AccountingUsers;
    }
}

