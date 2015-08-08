using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_BloodGroupManager
{
	public COMN_BloodGroupManager()
	{
	}

    public static DataSet  GetAllCOMN_BloodGroups()
    {
       DataSet cOMN_BloodGroups = new DataSet();
        SqlCOMN_BloodGroupProvider sqlCOMN_BloodGroupProvider = new SqlCOMN_BloodGroupProvider();
        cOMN_BloodGroups = sqlCOMN_BloodGroupProvider.GetAllCOMN_BloodGroups();
        return cOMN_BloodGroups;
    }

	public static void cOMN_BloodGroupsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_BloodGroupPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_BloodGroupProvider sqlCOMN_BloodGroupProvider = new SqlCOMN_BloodGroupProvider();
		DataSet ds =  sqlCOMN_BloodGroupProvider.GetCOMN_BloodGroupPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_BloodGroupsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_BloodGroup()
    {
       DataSet cOMN_BloodGroups = new DataSet();
        SqlCOMN_BloodGroupProvider sqlCOMN_BloodGroupProvider = new SqlCOMN_BloodGroupProvider();
        cOMN_BloodGroups = sqlCOMN_BloodGroupProvider.GetDropDownListAllCOMN_BloodGroup();
        return cOMN_BloodGroups;
    }


    public static COMN_BloodGroup GetCOMN_BloodGroupByBloodGroupID(int BloodGroupID)
    {
        COMN_BloodGroup cOMN_BloodGroup = new COMN_BloodGroup();
        SqlCOMN_BloodGroupProvider sqlCOMN_BloodGroupProvider = new SqlCOMN_BloodGroupProvider();
        cOMN_BloodGroup = sqlCOMN_BloodGroupProvider.GetCOMN_BloodGroupByBloodGroupID(BloodGroupID);
        return cOMN_BloodGroup;
    }

    public static DataSet GetDropDownListAllHR_BloodGroup()
    {
        DataSet hR_BloodGroups = new DataSet();
        SqlHR_BloodGroupProvider sqlHR_BloodGroupProvider = new SqlHR_BloodGroupProvider();
        hR_BloodGroups = sqlHR_BloodGroupProvider.GetDropDownLisAllHR_BloodGroup();
        return hR_BloodGroups;
    }
    public static int InsertCOMN_BloodGroup(COMN_BloodGroup cOMN_BloodGroup)
    {
        SqlCOMN_BloodGroupProvider sqlCOMN_BloodGroupProvider = new SqlCOMN_BloodGroupProvider();
        return sqlCOMN_BloodGroupProvider.InsertCOMN_BloodGroup(cOMN_BloodGroup);
    }


    public static bool UpdateCOMN_BloodGroup(COMN_BloodGroup cOMN_BloodGroup)
    {
        SqlCOMN_BloodGroupProvider sqlCOMN_BloodGroupProvider = new SqlCOMN_BloodGroupProvider();
        return sqlCOMN_BloodGroupProvider.UpdateCOMN_BloodGroup(cOMN_BloodGroup);
    }

    public static bool DeleteCOMN_BloodGroup(int cOMN_BloodGroupID)
    {
        SqlCOMN_BloodGroupProvider sqlCOMN_BloodGroupProvider = new SqlCOMN_BloodGroupProvider();
        return sqlCOMN_BloodGroupProvider.DeleteCOMN_BloodGroup(cOMN_BloodGroupID);
    }
}

