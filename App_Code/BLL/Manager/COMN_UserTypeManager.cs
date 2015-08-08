using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_UserTypeManager
{
	public COMN_UserTypeManager()
	{
	}

    public static DataSet  GetAllCOMN_UserTypes()
    {
       DataSet cOMN_UserTypes = new DataSet();
        SqlCOMN_UserTypeProvider sqlCOMN_UserTypeProvider = new SqlCOMN_UserTypeProvider();
        cOMN_UserTypes = sqlCOMN_UserTypeProvider.GetAllCOMN_UserTypes();
        return cOMN_UserTypes;
    }

	public static void cOMN_UserTypesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_UserTypePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_UserTypeProvider sqlCOMN_UserTypeProvider = new SqlCOMN_UserTypeProvider();
		DataSet ds =  sqlCOMN_UserTypeProvider.GetCOMN_UserTypePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_UserTypesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_UserType()
    {
       DataSet cOMN_UserTypes = new DataSet();
        SqlCOMN_UserTypeProvider sqlCOMN_UserTypeProvider = new SqlCOMN_UserTypeProvider();
        cOMN_UserTypes = sqlCOMN_UserTypeProvider.GetDropDownLisAllCOMN_UserType();
        return cOMN_UserTypes;
    }


    public static COMN_UserType GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        COMN_UserType cOMN_UserType = new COMN_UserType();
        SqlCOMN_UserTypeProvider sqlCOMN_UserTypeProvider = new SqlCOMN_UserTypeProvider();
        cOMN_UserType = sqlCOMN_UserTypeProvider.GetCOMN_UserTypeByRowStatusID(RowStatusID);
        return cOMN_UserType;
    }


    public static COMN_UserType GetCOMN_UserTypeByUserTypeID(int UserTypeID)
    {
        COMN_UserType cOMN_UserType = new COMN_UserType();
        SqlCOMN_UserTypeProvider sqlCOMN_UserTypeProvider = new SqlCOMN_UserTypeProvider();
        cOMN_UserType = sqlCOMN_UserTypeProvider.GetCOMN_UserTypeByUserTypeID(UserTypeID);
        return cOMN_UserType;
    }


    public static int InsertCOMN_UserType(COMN_UserType cOMN_UserType)
    {
        SqlCOMN_UserTypeProvider sqlCOMN_UserTypeProvider = new SqlCOMN_UserTypeProvider();
        return sqlCOMN_UserTypeProvider.InsertCOMN_UserType(cOMN_UserType);
    }


    public static bool UpdateCOMN_UserType(COMN_UserType cOMN_UserType)
    {
        SqlCOMN_UserTypeProvider sqlCOMN_UserTypeProvider = new SqlCOMN_UserTypeProvider();
        return sqlCOMN_UserTypeProvider.UpdateCOMN_UserType(cOMN_UserType);
    }

    public static bool DeleteCOMN_UserType(int cOMN_UserTypeID)
    {
        SqlCOMN_UserTypeProvider sqlCOMN_UserTypeProvider = new SqlCOMN_UserTypeProvider();
        return sqlCOMN_UserTypeProvider.DeleteCOMN_UserType(cOMN_UserTypeID);
    }
}

