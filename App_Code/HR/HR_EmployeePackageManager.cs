using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_EmployeePackageManager
{
	public HR_EmployeePackageManager()
	{
	}

    public static DataSet  GetAllHR_EmployeePackages()
    {
       DataSet hR_EmployeePackages = new DataSet();
        SqlHR_EmployeePackageProvider sqlHR_EmployeePackageProvider = new SqlHR_EmployeePackageProvider();
        hR_EmployeePackages = sqlHR_EmployeePackageProvider.GetAllHR_EmployeePackages();
        return hR_EmployeePackages;
    }

	public static void hR_EmployeePackagesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_EmployeePackagePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_EmployeePackageProvider sqlHR_EmployeePackageProvider = new SqlHR_EmployeePackageProvider();
		DataSet ds =  sqlHR_EmployeePackageProvider.GetHR_EmployeePackagePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_EmployeePackagesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_EmployeePackage()
    {
       DataSet hR_EmployeePackages = new DataSet();
        SqlHR_EmployeePackageProvider sqlHR_EmployeePackageProvider = new SqlHR_EmployeePackageProvider();
        hR_EmployeePackages = sqlHR_EmployeePackageProvider.GetDropDownListAllHR_EmployeePackage();
        return hR_EmployeePackages;
    }


    public static HR_EmployeePackage GetHR_EmployeePackageByEmployeePackageID(int EmployeePackageID)
    {
        HR_EmployeePackage hR_EmployeePackage = new HR_EmployeePackage();
        SqlHR_EmployeePackageProvider sqlHR_EmployeePackageProvider = new SqlHR_EmployeePackageProvider();
        hR_EmployeePackage = sqlHR_EmployeePackageProvider.GetHR_EmployeePackageByEmployeePackageID(EmployeePackageID);
        return hR_EmployeePackage;
    }


    public static int InsertHR_EmployeePackage(HR_EmployeePackage hR_EmployeePackage)
    {
        SqlHR_EmployeePackageProvider sqlHR_EmployeePackageProvider = new SqlHR_EmployeePackageProvider();
        return sqlHR_EmployeePackageProvider.InsertHR_EmployeePackage(hR_EmployeePackage);
    }


    public static bool UpdateHR_EmployeePackage(HR_EmployeePackage hR_EmployeePackage)
    {
        SqlHR_EmployeePackageProvider sqlHR_EmployeePackageProvider = new SqlHR_EmployeePackageProvider();
        return sqlHR_EmployeePackageProvider.UpdateHR_EmployeePackage(hR_EmployeePackage);
    }

    public static bool DeleteHR_EmployeePackage(int hR_EmployeePackageID)
    {
        SqlHR_EmployeePackageProvider sqlHR_EmployeePackageProvider = new SqlHR_EmployeePackageProvider();
        return sqlHR_EmployeePackageProvider.DeleteHR_EmployeePackage(hR_EmployeePackageID);
    }
}

