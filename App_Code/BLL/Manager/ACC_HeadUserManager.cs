using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_HeadUserManager
{
	public ACC_HeadUserManager()
	{
	}

    public static DataSet  GetAllACC_HeadUsers()
    {
       DataSet aCC_HeadUsers = new DataSet();
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        aCC_HeadUsers = sqlACC_HeadUserProvider.GetAllACC_HeadUsers();
        return aCC_HeadUsers;
    }

	public static void aCC_HeadUsersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_HeadUserPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
		DataSet ds =  sqlACC_HeadUserProvider.GetACC_HeadUserPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_HeadUsersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_HeadUser()
    {
       DataSet aCC_HeadUsers = new DataSet();
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        aCC_HeadUsers = sqlACC_HeadUserProvider.GetDropDownLisAllACC_HeadUser();
        return aCC_HeadUsers;
    }

    public static DataSet   GetAllACC_HeadUsersWithRelation()
    {
       DataSet aCC_HeadUsers = new DataSet();
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        aCC_HeadUsers = sqlACC_HeadUserProvider.GetAllACC_HeadUsers();
        return aCC_HeadUsers;
    }


    public static ACC_HeadUser GetACC_HeadByHeadID(int HeadID)
    {
        ACC_HeadUser aCC_HeadUser = new ACC_HeadUser();
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        aCC_HeadUser = sqlACC_HeadUserProvider.GetACC_HeadUserByHeadID(HeadID);
        return aCC_HeadUser;
    }


    public static ACC_HeadUser GetACC_UserByUserID(string UserID)
    {
        ACC_HeadUser aCC_HeadUser = new ACC_HeadUser();
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        aCC_HeadUser = sqlACC_HeadUserProvider.GetACC_HeadUserByUserID(UserID);
        return aCC_HeadUser;
    }


    public static DataSet GetACC_UserByUserIDnUserTypeIDnAccountID(string UserID,int userTypeID,int accountID)
    {
        DataSet aCC_HeadUser = new DataSet();
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        aCC_HeadUser = sqlACC_HeadUserProvider.GetACC_HeadUserByUserIDnUserTypeIDnAccountID(UserID, userTypeID,accountID);
        return aCC_HeadUser;
    }


    public static ACC_HeadUser GetACC_UserTypeByUserTypeID(int UserTypeID)
    {
        ACC_HeadUser aCC_HeadUser = new ACC_HeadUser();
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        aCC_HeadUser = sqlACC_HeadUserProvider.GetACC_HeadUserByUserTypeID(UserTypeID);
        return aCC_HeadUser;
    }


    public static ACC_HeadUser GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_HeadUser aCC_HeadUser = new ACC_HeadUser();
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        aCC_HeadUser = sqlACC_HeadUserProvider.GetACC_HeadUserByRowStatusID(RowStatusID);
        return aCC_HeadUser;
    }


    public static ACC_HeadUser GetACC_HeadUserByHeadUserID(int HeadUserID)
    {
        ACC_HeadUser aCC_HeadUser = new ACC_HeadUser();
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        aCC_HeadUser = sqlACC_HeadUserProvider.GetACC_HeadUserByHeadUserID(HeadUserID);
        return aCC_HeadUser;
    }


    public static int InsertACC_HeadUser(ACC_HeadUser aCC_HeadUser)
    {
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        return sqlACC_HeadUserProvider.InsertACC_HeadUser(aCC_HeadUser);
    }


    public static bool UpdateACC_HeadUser(ACC_HeadUser aCC_HeadUser)
    {
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        return sqlACC_HeadUserProvider.UpdateACC_HeadUser(aCC_HeadUser);
    }

    public static bool DeleteACC_HeadUser(int aCC_HeadUserID)
    {
        SqlACC_HeadUserProvider sqlACC_HeadUserProvider = new SqlACC_HeadUserProvider();
        return sqlACC_HeadUserProvider.DeleteACC_HeadUser(aCC_HeadUserID);
    }
}

