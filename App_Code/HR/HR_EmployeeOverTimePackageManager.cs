using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_EmployeeOverTimePackageManager
{
	public HR_EmployeeOverTimePackageManager()
	{
	}

    public static DataSet  GetAllHR_EmployeeOverTimePackages()
    {
       DataSet hR_EmployeeOverTimePackages = new DataSet();
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        hR_EmployeeOverTimePackages = sqlHR_EmployeeOverTimePackageProvider.GetAllHR_EmployeeOverTimePackages();
        return hR_EmployeeOverTimePackages;
    }

	public static void hR_EmployeeOverTimePackagesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_EmployeeOverTimePackagePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
		DataSet ds =  sqlHR_EmployeeOverTimePackageProvider.GetHR_EmployeeOverTimePackagePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_EmployeeOverTimePackagesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_EmployeeOverTimePackage()
    {
       DataSet hR_EmployeeOverTimePackages = new DataSet();
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        hR_EmployeeOverTimePackages = sqlHR_EmployeeOverTimePackageProvider.GetDropDownLisAllHR_EmployeeOverTimePackage();
        return hR_EmployeeOverTimePackages;
    }

    public static DataSet   GetAllHR_EmployeeOverTimePackagesWithRelation()
    {
       DataSet hR_EmployeeOverTimePackages = new DataSet();
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        hR_EmployeeOverTimePackages = sqlHR_EmployeeOverTimePackageProvider.GetAllHR_EmployeeOverTimePackages();
        return hR_EmployeeOverTimePackages;
    }


    public static HR_EmployeeOverTimePackage GetHR_EmployeeOverTimePackageByEmployeeID(string EmployeeID)
    {
        HR_EmployeeOverTimePackage hR_EmployeeOverTimePackage = new HR_EmployeeOverTimePackage();
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        hR_EmployeeOverTimePackage = sqlHR_EmployeeOverTimePackageProvider.GetHR_EmployeeOverTimePackageByEmployeeID(EmployeeID);
        return hR_EmployeeOverTimePackage;
    }


    public static HR_EmployeeOverTimePackage GetHR_OverTimePackageByOverTimePackageID(int OverTimePackageID)
    {
        HR_EmployeeOverTimePackage hR_EmployeeOverTimePackage = new HR_EmployeeOverTimePackage();
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        hR_EmployeeOverTimePackage = sqlHR_EmployeeOverTimePackageProvider.GetHR_EmployeeOverTimePackageByOverTimePackageID(OverTimePackageID);
        return hR_EmployeeOverTimePackage;
    }


    public static HR_EmployeeOverTimePackage GetHR_EmployeeOverTimePackageByOverTimeID(int OverTimeID)
    {
        HR_EmployeeOverTimePackage hR_EmployeeOverTimePackage = new HR_EmployeeOverTimePackage();
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        hR_EmployeeOverTimePackage = sqlHR_EmployeeOverTimePackageProvider.GetHR_EmployeeOverTimePackageByOverTimeID(OverTimeID);
        return hR_EmployeeOverTimePackage;
    }

    public static bool IsEmployeeExist(string employeeID)
    {
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        return sqlHR_EmployeeOverTimePackageProvider.IsEmployeeExist(employeeID);
    }

    public static int InsertHR_EmployeeOverTimePackage(HR_EmployeeOverTimePackage hR_EmployeeOverTimePackage)
    {
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        return sqlHR_EmployeeOverTimePackageProvider.InsertHR_EmployeeOverTimePackage(hR_EmployeeOverTimePackage);
    }


    public static bool UpdateHR_EmployeeOverTimePackage(HR_EmployeeOverTimePackage hR_EmployeeOverTimePackage)
    {
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        return sqlHR_EmployeeOverTimePackageProvider.UpdateHR_EmployeeOverTimePackage(hR_EmployeeOverTimePackage);
    }

    public static bool DeleteHR_EmployeeOverTimePackage(int hR_EmployeeOverTimePackageID)
    {
        SqlHR_EmployeeOverTimePackageProvider sqlHR_EmployeeOverTimePackageProvider = new SqlHR_EmployeeOverTimePackageProvider();
        return sqlHR_EmployeeOverTimePackageProvider.DeleteHR_EmployeeOverTimePackage(hR_EmployeeOverTimePackageID);
    }
}

