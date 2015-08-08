using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_DepartmentManager
{
	public HR_DepartmentManager()
	{
	}

    public static DataSet  GetAllHR_Departments()
    {
       DataSet hR_Departments = new DataSet();
        SqlHR_DepartmentProvider sqlHR_DepartmentProvider = new SqlHR_DepartmentProvider();
        hR_Departments = sqlHR_DepartmentProvider.GetAllHR_Departments();
        return hR_Departments;
    }

	public static void hR_DepartmentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_DepartmentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_DepartmentProvider sqlHR_DepartmentProvider = new SqlHR_DepartmentProvider();
		DataSet ds =  sqlHR_DepartmentProvider.GetHR_DepartmentPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_DepartmentsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Department()
    {
       DataSet hR_Departments = new DataSet();
        SqlHR_DepartmentProvider sqlHR_DepartmentProvider = new SqlHR_DepartmentProvider();
        hR_Departments = sqlHR_DepartmentProvider.GetDropDownLisAllHR_Department();
        return hR_Departments;
    }


    public static HR_Department GetHR_DepartmentByDepartmentID(int DepartmentID)
    {
        HR_Department hR_Department = new HR_Department();
        SqlHR_DepartmentProvider sqlHR_DepartmentProvider = new SqlHR_DepartmentProvider();
        hR_Department = sqlHR_DepartmentProvider.GetHR_DepartmentByDepartmentID(DepartmentID);
        return hR_Department;
    }


    public static int InsertHR_Department(HR_Department hR_Department)
    {
        SqlHR_DepartmentProvider sqlHR_DepartmentProvider = new SqlHR_DepartmentProvider();
        return sqlHR_DepartmentProvider.InsertHR_Department(hR_Department);
    }


    public static bool UpdateHR_Department(HR_Department hR_Department)
    {
        SqlHR_DepartmentProvider sqlHR_DepartmentProvider = new SqlHR_DepartmentProvider();
        return sqlHR_DepartmentProvider.UpdateHR_Department(hR_Department);
    }

    public static bool DeleteHR_Department(int hR_DepartmentID)
    {
        SqlHR_DepartmentProvider sqlHR_DepartmentProvider = new SqlHR_DepartmentProvider();
        return sqlHR_DepartmentProvider.DeleteHR_Department(hR_DepartmentID);
    }
}

