using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ChildrenInfoManager
{
	public HR_ChildrenInfoManager()
	{
	}

    public static DataSet  GetAllHR_ChildrenInfos()
    {
       DataSet hR_ChildrenInfos = new DataSet();
        SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
        hR_ChildrenInfos = sqlHR_ChildrenInfoProvider.GetAllHR_ChildrenInfos();
        return hR_ChildrenInfos;
    }

	public static void hR_ChildrenInfosPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_ChildrenInfoPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
		DataSet ds =  sqlHR_ChildrenInfoProvider.GetHR_ChildrenInfoPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_ChildrenInfosPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_ChildrenInfo()
    {
       DataSet hR_ChildrenInfos = new DataSet();
        SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
        hR_ChildrenInfos = sqlHR_ChildrenInfoProvider.GetDropDownLisAllHR_ChildrenInfo();
        return hR_ChildrenInfos;
    }

    public static DataSet   GetAllHR_ChildrenInfosWithRelation()
    {
       DataSet hR_ChildrenInfos = new DataSet();
        SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
        hR_ChildrenInfos = sqlHR_ChildrenInfoProvider.GetAllHR_ChildrenInfos();
        return hR_ChildrenInfos;
    }


    public static HR_ChildrenInfo GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_ChildrenInfo hR_ChildrenInfo = new HR_ChildrenInfo();
        SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
        hR_ChildrenInfo = sqlHR_ChildrenInfoProvider.GetHR_ChildrenInfoByEmployeeID(EmployeeID);
        return hR_ChildrenInfo;
    }


    public static HR_ChildrenInfo GetHR_ChildrenInfoByChildrenInfoID(int ChildrenInfoID)
    {
        HR_ChildrenInfo hR_ChildrenInfo = new HR_ChildrenInfo();
        SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
        hR_ChildrenInfo = sqlHR_ChildrenInfoProvider.GetHR_ChildrenInfoByChildrenInfoID(ChildrenInfoID);
        return hR_ChildrenInfo;
    }


    public static int InsertHR_ChildrenInfo(HR_ChildrenInfo hR_ChildrenInfo)
    {
        SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
        return sqlHR_ChildrenInfoProvider.InsertHR_ChildrenInfo(hR_ChildrenInfo);
    }


    public static bool UpdateHR_ChildrenInfo(HR_ChildrenInfo hR_ChildrenInfo)
    {
        SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
        return sqlHR_ChildrenInfoProvider.UpdateHR_ChildrenInfo(hR_ChildrenInfo);
    }

    public static bool DeleteHR_ChildrenInfo(int hR_ChildrenInfoID)
    {
        SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
        return sqlHR_ChildrenInfoProvider.DeleteHR_ChildrenInfo(hR_ChildrenInfoID);
    }

    public static List<HR_ChildrenInfo> GetHR_ChildrenInfosByEmployeeID(string EmployeeID)
    {
        List<HR_ChildrenInfo> hR_ChildrenInfo = new List<HR_ChildrenInfo>();
        SqlHR_ChildrenInfoProvider sqlHR_ChildrenInfoProvider = new SqlHR_ChildrenInfoProvider();
        hR_ChildrenInfo = sqlHR_ChildrenInfoProvider.GetHR_ChildrenInfosByEmployeeID(EmployeeID);
        return hR_ChildrenInfo;
    }
}

