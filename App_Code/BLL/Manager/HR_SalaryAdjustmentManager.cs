using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryAdjustmentManager
{
	public HR_SalaryAdjustmentManager()
	{
	}

    public static DataSet  GetAllHR_SalaryAdjustments()
    {
       DataSet hR_SalaryAdjustments = new DataSet();
        SqlHR_SalaryAdjustmentGroupProvider sqlHR_SalaryAdjustmentProvider = new SqlHR_SalaryAdjustmentGroupProvider();
        hR_SalaryAdjustments = sqlHR_SalaryAdjustmentProvider.GetAllHR_SalaryAdjustmentGroups();
        return hR_SalaryAdjustments;
    }

	public static void hR_SalaryAdjustmentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_SalaryAdjustmentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_SalaryAdjustmentGroupProvider sqlHR_SalaryAdjustmentProvider = new SqlHR_SalaryAdjustmentGroupProvider();
        DataSet ds = sqlHR_SalaryAdjustmentProvider.GetHR_SalaryAdjustmentGroupPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_SalaryAdjustmentsPaggination(rptPager,recordCount, pageIndex, PageSize); 
	}
    public static DataSet  GetDropDownListAllHR_SalaryAdjustment()
    {
       DataSet hR_SalaryAdjustments = new DataSet();
        SqlHR_SalaryAdjustmentGroupProvider sqlHR_SalaryAdjustmentProvider = new SqlHR_SalaryAdjustmentGroupProvider();
        hR_SalaryAdjustments = sqlHR_SalaryAdjustmentProvider.GetDropDownLisAllHR_SalaryAdjustmentGroup();
        return hR_SalaryAdjustments;
    }


    public static HR_SalaryAdjustmentGroup GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_SalaryAdjustmentGroup hR_SalaryAdjustment = new HR_SalaryAdjustmentGroup();
        SqlHR_SalaryAdjustmentGroupProvider sqlHR_SalaryAdjustmentProvider = new SqlHR_SalaryAdjustmentGroupProvider();
        hR_SalaryAdjustment = sqlHR_SalaryAdjustmentProvider.GetHR_SalaryAdjustmentGroupByEmployeeID(EmployeeID);
        return hR_SalaryAdjustment;
    }


    public static HR_SalaryAdjustmentGroup GetHR_SalaryAdjustmentBySalaryAdjustmentID(int SalaryAdjustmentID)
    {
        HR_SalaryAdjustmentGroup hR_SalaryAdjustment = new HR_SalaryAdjustmentGroup();
        SqlHR_SalaryAdjustmentGroupProvider sqlHR_SalaryAdjustmentProvider = new SqlHR_SalaryAdjustmentGroupProvider();
        hR_SalaryAdjustment = sqlHR_SalaryAdjustmentProvider.GetHR_SalaryAdjustmentGroupBySalaryAdjustmentGroupID(SalaryAdjustmentID);
        return hR_SalaryAdjustment;
    }


    public static int InsertHR_SalaryAdjustment(HR_SalaryAdjustmentGroup hR_SalaryAdjustment)
    {
        SqlHR_SalaryAdjustmentGroupProvider sqlHR_SalaryAdjustmentProvider = new SqlHR_SalaryAdjustmentGroupProvider();
        return sqlHR_SalaryAdjustmentProvider.InsertHR_SalaryAdjustmentGroup(hR_SalaryAdjustment);
    }


    public static bool UpdateHR_SalaryAdjustment(HR_SalaryAdjustmentGroup hR_SalaryAdjustment)
    {
        SqlHR_SalaryAdjustmentGroupProvider sqlHR_SalaryAdjustmentProvider = new SqlHR_SalaryAdjustmentGroupProvider();
        return sqlHR_SalaryAdjustmentProvider.UpdateHR_SalaryAdjustmentGroup(hR_SalaryAdjustment);
    }

    public static bool DeleteHR_SalaryAdjustment(int hR_SalaryAdjustmentID)
    {
        SqlHR_SalaryAdjustmentGroupProvider sqlHR_SalaryAdjustmentProvider = new SqlHR_SalaryAdjustmentGroupProvider();
        return sqlHR_SalaryAdjustmentProvider.DeleteHR_SalaryAdjustmentGroup(hR_SalaryAdjustmentID);
    }
}

