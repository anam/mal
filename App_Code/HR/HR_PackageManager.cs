using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_PackageManager
{
	public HR_PackageManager()
	{
	}

    public static DataSet  GetAllHR_Packages()
    {
       DataSet hR_Packages = new DataSet();
        SqlHR_PackageProvider sqlHR_PackageProvider = new SqlHR_PackageProvider();
        hR_Packages = sqlHR_PackageProvider.GetAllHR_Packages();
        return hR_Packages;
    }

	public static void hR_PackagesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_PackagePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_PackageProvider sqlHR_PackageProvider = new SqlHR_PackageProvider();
		DataSet ds =  sqlHR_PackageProvider.GetHR_PackagePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_PackagesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Package()
    {
       DataSet hR_Packages = new DataSet();
        SqlHR_PackageProvider sqlHR_PackageProvider = new SqlHR_PackageProvider();
        hR_Packages = sqlHR_PackageProvider.GetDropDownLisAllHR_Package();
        return hR_Packages;
    }


    public static HR_Package GetHR_PackageByPackageID(int PackageID)
    {
        HR_Package hR_Package = new HR_Package();
        SqlHR_PackageProvider sqlHR_PackageProvider = new SqlHR_PackageProvider();
        hR_Package = sqlHR_PackageProvider.GetHR_PackageByPackageID(PackageID);
        return hR_Package;
    }


    public static int InsertHR_Package(HR_Package hR_Package)
    {
        SqlHR_PackageProvider sqlHR_PackageProvider = new SqlHR_PackageProvider();
        return sqlHR_PackageProvider.InsertHR_Package(hR_Package);
    }


    public static bool UpdateHR_Package(HR_Package hR_Package)
    {
        SqlHR_PackageProvider sqlHR_PackageProvider = new SqlHR_PackageProvider();
        return sqlHR_PackageProvider.UpdateHR_Package(hR_Package);
    }

    public static bool DeleteHR_Package(int hR_PackageID)
    {
        SqlHR_PackageProvider sqlHR_PackageProvider = new SqlHR_PackageProvider();
        return sqlHR_PackageProvider.DeleteHR_Package(hR_PackageID);
    }
}

