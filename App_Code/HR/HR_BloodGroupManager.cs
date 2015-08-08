using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_BloodGroupManager
{
	public HR_BloodGroupManager()
	{
	}

    public static DataSet  GetAllHR_BloodGroups()
    {
       DataSet hR_BloodGroups = new DataSet();
        SqlHR_BloodGroupProvider sqlHR_BloodGroupProvider = new SqlHR_BloodGroupProvider();
        hR_BloodGroups = sqlHR_BloodGroupProvider.GetAllHR_BloodGroups();
        return hR_BloodGroups;
    }

	public static void hR_BloodGroupsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_BloodGroupPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_BloodGroupProvider sqlHR_BloodGroupProvider = new SqlHR_BloodGroupProvider();
		DataSet ds =  sqlHR_BloodGroupProvider.GetHR_BloodGroupPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_BloodGroupsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_BloodGroup()
    {
       DataSet hR_BloodGroups = new DataSet();
        SqlHR_BloodGroupProvider sqlHR_BloodGroupProvider = new SqlHR_BloodGroupProvider();
        hR_BloodGroups = sqlHR_BloodGroupProvider.GetDropDownLisAllHR_BloodGroup();
        return hR_BloodGroups;
    }


    public static HR_BloodGroup GetHR_BloodGroupByBloodGroupID(int BloodGroupID)
    {
        HR_BloodGroup hR_BloodGroup = new HR_BloodGroup();
        SqlHR_BloodGroupProvider sqlHR_BloodGroupProvider = new SqlHR_BloodGroupProvider();
        hR_BloodGroup = sqlHR_BloodGroupProvider.GetHR_BloodGroupByBloodGroupID(BloodGroupID);
        return hR_BloodGroup;
    }


    public static int InsertHR_BloodGroup(HR_BloodGroup hR_BloodGroup)
    {
        SqlHR_BloodGroupProvider sqlHR_BloodGroupProvider = new SqlHR_BloodGroupProvider();
        return sqlHR_BloodGroupProvider.InsertHR_BloodGroup(hR_BloodGroup);
    }


    public static bool UpdateHR_BloodGroup(HR_BloodGroup hR_BloodGroup)
    {
        SqlHR_BloodGroupProvider sqlHR_BloodGroupProvider = new SqlHR_BloodGroupProvider();
        return sqlHR_BloodGroupProvider.UpdateHR_BloodGroup(hR_BloodGroup);
    }

    public static bool DeleteHR_BloodGroup(int hR_BloodGroupID)
    {
        SqlHR_BloodGroupProvider sqlHR_BloodGroupProvider = new SqlHR_BloodGroupProvider();
        return sqlHR_BloodGroupProvider.DeleteHR_BloodGroup(hR_BloodGroupID);
    }
}

