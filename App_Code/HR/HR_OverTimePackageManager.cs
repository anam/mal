using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_OverTimePackageManager
{
	public HR_OverTimePackageManager()
	{
	}

    public static DataSet  GetAllHR_OverTimePackages()
    {
       DataSet hR_OverTimePackages = new DataSet();
        SqlHR_OverTimePackageProvider sqlHR_OverTimePackageProvider = new SqlHR_OverTimePackageProvider();
        hR_OverTimePackages = sqlHR_OverTimePackageProvider.GetAllHR_OverTimePackages();
        return hR_OverTimePackages;
    }

	public static void hR_OverTimePackagesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_OverTimePackagePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_OverTimePackageProvider sqlHR_OverTimePackageProvider = new SqlHR_OverTimePackageProvider();
		DataSet ds =  sqlHR_OverTimePackageProvider.GetHR_OverTimePackagePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_OverTimePackagesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_OverTimePackage()
    {
       DataSet hR_OverTimePackages = new DataSet();
        SqlHR_OverTimePackageProvider sqlHR_OverTimePackageProvider = new SqlHR_OverTimePackageProvider();
        hR_OverTimePackages = sqlHR_OverTimePackageProvider.GetDropDownLisAllHR_OverTimePackage();
        return hR_OverTimePackages;
    }


    public static HR_OverTimePackage GetHR_OverTimePackageByOverTimePackageID(int OverTimePackageID)
    {
        HR_OverTimePackage hR_OverTimePackage = new HR_OverTimePackage();
        SqlHR_OverTimePackageProvider sqlHR_OverTimePackageProvider = new SqlHR_OverTimePackageProvider();
        hR_OverTimePackage = sqlHR_OverTimePackageProvider.GetHR_OverTimePackageByOverTimePackageID(OverTimePackageID);
        return hR_OverTimePackage;
    }


    public static int InsertHR_OverTimePackage(HR_OverTimePackage hR_OverTimePackage)
    {
        SqlHR_OverTimePackageProvider sqlHR_OverTimePackageProvider = new SqlHR_OverTimePackageProvider();
        return sqlHR_OverTimePackageProvider.InsertHR_OverTimePackage(hR_OverTimePackage);
    }


    public static bool UpdateHR_OverTimePackage(HR_OverTimePackage hR_OverTimePackage)
    {
        SqlHR_OverTimePackageProvider sqlHR_OverTimePackageProvider = new SqlHR_OverTimePackageProvider();
        return sqlHR_OverTimePackageProvider.UpdateHR_OverTimePackage(hR_OverTimePackage);
    }

    public static bool DeleteHR_OverTimePackage(int hR_OverTimePackageID)
    {
        SqlHR_OverTimePackageProvider sqlHR_OverTimePackageProvider = new SqlHR_OverTimePackageProvider();
        return sqlHR_OverTimePackageProvider.DeleteHR_OverTimePackage(hR_OverTimePackageID);
    }
}

