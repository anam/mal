using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_BenifitPackageManager
{
	public HR_BenifitPackageManager()
	{
	}

    public static DataSet  GetAllHR_BenifitPackages()
    {
       DataSet hR_BenifitPackages = new DataSet();
        SqlHR_BenifitPackageProvider sqlHR_BenifitPackageProvider = new SqlHR_BenifitPackageProvider();
        hR_BenifitPackages = sqlHR_BenifitPackageProvider.GetAllHR_BenifitPackages();
        return hR_BenifitPackages;
    }

	public static void hR_BenifitPackagesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_BenifitPackagePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_BenifitPackageProvider sqlHR_BenifitPackageProvider = new SqlHR_BenifitPackageProvider();
		DataSet ds =  sqlHR_BenifitPackageProvider.GetHR_BenifitPackagePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_BenifitPackagesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_BenifitPackage()
    {
       DataSet hR_BenifitPackages = new DataSet();
        SqlHR_BenifitPackageProvider sqlHR_BenifitPackageProvider = new SqlHR_BenifitPackageProvider();
        hR_BenifitPackages = sqlHR_BenifitPackageProvider.GetDropDownLisAllHR_BenifitPackage();
        return hR_BenifitPackages;
    }


    public static HR_BenifitPackage GetHR_BenifitPackageByBenifitPackageID(int BenifitPackageID)
    {
        HR_BenifitPackage hR_BenifitPackage = new HR_BenifitPackage();
        SqlHR_BenifitPackageProvider sqlHR_BenifitPackageProvider = new SqlHR_BenifitPackageProvider();
        hR_BenifitPackage = sqlHR_BenifitPackageProvider.GetHR_BenifitPackageByBenifitPackageID(BenifitPackageID);
        return hR_BenifitPackage;
    }


    public static int InsertHR_BenifitPackage(HR_BenifitPackage hR_BenifitPackage)
    {
        SqlHR_BenifitPackageProvider sqlHR_BenifitPackageProvider = new SqlHR_BenifitPackageProvider();
        return sqlHR_BenifitPackageProvider.InsertHR_BenifitPackage(hR_BenifitPackage);
    }


    public static bool UpdateHR_BenifitPackage(HR_BenifitPackage hR_BenifitPackage)
    {
        SqlHR_BenifitPackageProvider sqlHR_BenifitPackageProvider = new SqlHR_BenifitPackageProvider();
        return sqlHR_BenifitPackageProvider.UpdateHR_BenifitPackage(hR_BenifitPackage);
    }

    public static bool DeleteHR_BenifitPackage(int hR_BenifitPackageID)
    {
        SqlHR_BenifitPackageProvider sqlHR_BenifitPackageProvider = new SqlHR_BenifitPackageProvider();
        return sqlHR_BenifitPackageProvider.DeleteHR_BenifitPackage(hR_BenifitPackageID);
    }
}

