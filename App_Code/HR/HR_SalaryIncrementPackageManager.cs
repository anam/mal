using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryIncrementPackageManager
{
	public HR_SalaryIncrementPackageManager()
	{
	}

    public static DataSet  GetAllHR_SalaryIncrementPackages()
    {
       DataSet hR_SalaryIncrementPackages = new DataSet();
        SqlHR_SalaryIncrementPackageProvider sqlHR_SalaryIncrementPackageProvider = new SqlHR_SalaryIncrementPackageProvider();
        hR_SalaryIncrementPackages = sqlHR_SalaryIncrementPackageProvider.GetAllHR_SalaryIncrementPackages();
        return hR_SalaryIncrementPackages;
    }

	public static void hR_SalaryIncrementPackagesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_SalaryIncrementPackagePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_SalaryIncrementPackageProvider sqlHR_SalaryIncrementPackageProvider = new SqlHR_SalaryIncrementPackageProvider();
		DataSet ds =  sqlHR_SalaryIncrementPackageProvider.GetHR_SalaryIncrementPackagePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_SalaryIncrementPackagesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_SalaryIncrementPackage()
    {
       DataSet hR_SalaryIncrementPackages = new DataSet();
        SqlHR_SalaryIncrementPackageProvider sqlHR_SalaryIncrementPackageProvider = new SqlHR_SalaryIncrementPackageProvider();
        hR_SalaryIncrementPackages = sqlHR_SalaryIncrementPackageProvider.GetDropDownLisAllHR_SalaryIncrementPackage();
        return hR_SalaryIncrementPackages;
    }


    public static HR_SalaryIncrementPackage GetHR_SalaryIncrementPackageBySalaryIncrementPackageID(int SalaryIncrementPackageID)
    {
        HR_SalaryIncrementPackage hR_SalaryIncrementPackage = new HR_SalaryIncrementPackage();
        SqlHR_SalaryIncrementPackageProvider sqlHR_SalaryIncrementPackageProvider = new SqlHR_SalaryIncrementPackageProvider();
        hR_SalaryIncrementPackage = sqlHR_SalaryIncrementPackageProvider.GetHR_SalaryIncrementPackageBySalaryIncrementPackageID(SalaryIncrementPackageID);
        return hR_SalaryIncrementPackage;
    }


    public static int InsertHR_SalaryIncrementPackage(HR_SalaryIncrementPackage hR_SalaryIncrementPackage)
    {
        SqlHR_SalaryIncrementPackageProvider sqlHR_SalaryIncrementPackageProvider = new SqlHR_SalaryIncrementPackageProvider();
        return sqlHR_SalaryIncrementPackageProvider.InsertHR_SalaryIncrementPackage(hR_SalaryIncrementPackage);
    }


    public static bool UpdateHR_SalaryIncrementPackage(HR_SalaryIncrementPackage hR_SalaryIncrementPackage)
    {
        SqlHR_SalaryIncrementPackageProvider sqlHR_SalaryIncrementPackageProvider = new SqlHR_SalaryIncrementPackageProvider();
        return sqlHR_SalaryIncrementPackageProvider.UpdateHR_SalaryIncrementPackage(hR_SalaryIncrementPackage);
    }

    public static bool DeleteHR_SalaryIncrementPackage(int hR_SalaryIncrementPackageID)
    {
        SqlHR_SalaryIncrementPackageProvider sqlHR_SalaryIncrementPackageProvider = new SqlHR_SalaryIncrementPackageProvider();
        return sqlHR_SalaryIncrementPackageProvider.DeleteHR_SalaryIncrementPackage(hR_SalaryIncrementPackageID);
    }
}

