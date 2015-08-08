using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryTaxPackageManager
{
	public HR_SalaryTaxPackageManager()
	{
	}

    public static DataSet  GetAllHR_SalaryTaxPackages()
    {
       DataSet hR_SalaryTaxPackages = new DataSet();
        SqlHR_SalaryTaxPackageProvider sqlHR_SalaryTaxPackageProvider = new SqlHR_SalaryTaxPackageProvider();
        hR_SalaryTaxPackages = sqlHR_SalaryTaxPackageProvider.GetAllHR_SalaryTaxPackages();
        return hR_SalaryTaxPackages;
    }

	public static void hR_SalaryTaxPackagesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_SalaryTaxPackagePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_SalaryTaxPackageProvider sqlHR_SalaryTaxPackageProvider = new SqlHR_SalaryTaxPackageProvider();
		DataSet ds =  sqlHR_SalaryTaxPackageProvider.GetHR_SalaryTaxPackagePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_SalaryTaxPackagesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_SalaryTaxPackage()
    {
       DataSet hR_SalaryTaxPackages = new DataSet();
        SqlHR_SalaryTaxPackageProvider sqlHR_SalaryTaxPackageProvider = new SqlHR_SalaryTaxPackageProvider();
        hR_SalaryTaxPackages = sqlHR_SalaryTaxPackageProvider.GetDropDownLisAllHR_SalaryTaxPackage();
        return hR_SalaryTaxPackages;
    }


    public static HR_SalaryTaxPackage GetHR_SalaryTaxPackageBySalaryTaxPackagePackageID(int SalaryTaxPackagePackageID)
    {
        HR_SalaryTaxPackage hR_SalaryTaxPackage = new HR_SalaryTaxPackage();
        SqlHR_SalaryTaxPackageProvider sqlHR_SalaryTaxPackageProvider = new SqlHR_SalaryTaxPackageProvider();
        hR_SalaryTaxPackage = sqlHR_SalaryTaxPackageProvider.GetHR_SalaryTaxPackageBySalaryTaxPackagePackageID(SalaryTaxPackagePackageID);
        return hR_SalaryTaxPackage;
    }


    public static int InsertHR_SalaryTaxPackage(HR_SalaryTaxPackage hR_SalaryTaxPackage)
    {
        SqlHR_SalaryTaxPackageProvider sqlHR_SalaryTaxPackageProvider = new SqlHR_SalaryTaxPackageProvider();
        return sqlHR_SalaryTaxPackageProvider.InsertHR_SalaryTaxPackage(hR_SalaryTaxPackage);
    }


    public static bool UpdateHR_SalaryTaxPackage(HR_SalaryTaxPackage hR_SalaryTaxPackage)
    {
        SqlHR_SalaryTaxPackageProvider sqlHR_SalaryTaxPackageProvider = new SqlHR_SalaryTaxPackageProvider();
        return sqlHR_SalaryTaxPackageProvider.UpdateHR_SalaryTaxPackage(hR_SalaryTaxPackage);
    }

    public static bool DeleteHR_SalaryTaxPackage(int hR_SalaryTaxPackageID)
    {
        SqlHR_SalaryTaxPackageProvider sqlHR_SalaryTaxPackageProvider = new SqlHR_SalaryTaxPackageProvider();
        return sqlHR_SalaryTaxPackageProvider.DeleteHR_SalaryTaxPackage(hR_SalaryTaxPackageID);
    }
}

