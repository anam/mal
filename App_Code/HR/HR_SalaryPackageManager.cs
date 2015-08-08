using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryPackageManager
{
	public HR_SalaryPackageManager()
	{
	}

    public static DataSet  GetAllHR_SalaryPackages()
    {
       DataSet hR_SalaryPackages = new DataSet();
        SqlHR_SalaryPackageProvider sqlHR_SalaryPackageProvider = new SqlHR_SalaryPackageProvider();
        hR_SalaryPackages = sqlHR_SalaryPackageProvider.GetAllHR_SalaryPackages();
        return hR_SalaryPackages;
    }

	public static void hR_SalaryPackagesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_SalaryPackagePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_SalaryPackageProvider sqlHR_SalaryPackageProvider = new SqlHR_SalaryPackageProvider();
		DataSet ds =  sqlHR_SalaryPackageProvider.GetHR_SalaryPackagePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_SalaryPackagesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_SalaryPackage()
    {
       DataSet hR_SalaryPackages = new DataSet();
        SqlHR_SalaryPackageProvider sqlHR_SalaryPackageProvider = new SqlHR_SalaryPackageProvider();
        hR_SalaryPackages = sqlHR_SalaryPackageProvider.GetDropDownListAllHR_SalaryPackage();
        return hR_SalaryPackages;
    }

    public static DataSet   GetAllHR_SalaryPackagesWithRelation()
    {
       DataSet hR_SalaryPackages = new DataSet();
        SqlHR_SalaryPackageProvider sqlHR_SalaryPackageProvider = new SqlHR_SalaryPackageProvider();
        hR_SalaryPackages = sqlHR_SalaryPackageProvider.GetAllHR_SalaryPackages();
        return hR_SalaryPackages;
    }


    public static HR_SalaryPackage GetHR_DepartmentByDepartmentID(int DepartmentID)
    {
        HR_SalaryPackage hR_SalaryPackage = new HR_SalaryPackage();
        SqlHR_SalaryPackageProvider sqlHR_SalaryPackageProvider = new SqlHR_SalaryPackageProvider();
        hR_SalaryPackage = sqlHR_SalaryPackageProvider.GetHR_SalaryPackageByDepartmentID(DepartmentID);
        return hR_SalaryPackage;
    }


    public static HR_SalaryPackage GetHR_SalaryPackageBySalaryPackageID(int SalaryPackageID)
    {
        HR_SalaryPackage hR_SalaryPackage = new HR_SalaryPackage();
        SqlHR_SalaryPackageProvider sqlHR_SalaryPackageProvider = new SqlHR_SalaryPackageProvider();
        hR_SalaryPackage = sqlHR_SalaryPackageProvider.GetHR_SalaryPackageBySalaryPackageID(SalaryPackageID);
        return hR_SalaryPackage;
    }


    public static int InsertHR_SalaryPackage(HR_SalaryPackage hR_SalaryPackage)
    {
        SqlHR_SalaryPackageProvider sqlHR_SalaryPackageProvider = new SqlHR_SalaryPackageProvider();
        return sqlHR_SalaryPackageProvider.InsertHR_SalaryPackage(hR_SalaryPackage);
    }


    public static bool UpdateHR_SalaryPackage(HR_SalaryPackage hR_SalaryPackage)
    {
        SqlHR_SalaryPackageProvider sqlHR_SalaryPackageProvider = new SqlHR_SalaryPackageProvider();
        return sqlHR_SalaryPackageProvider.UpdateHR_SalaryPackage(hR_SalaryPackage);
    }

    public static bool DeleteHR_SalaryPackage(int hR_SalaryPackageID)
    {
        SqlHR_SalaryPackageProvider sqlHR_SalaryPackageProvider = new SqlHR_SalaryPackageProvider();
        return sqlHR_SalaryPackageProvider.DeleteHR_SalaryPackage(hR_SalaryPackageID);
    }
}

