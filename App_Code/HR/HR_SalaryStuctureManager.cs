using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryStuctureManager
{
	public HR_SalaryStuctureManager()
	{
	}

    public static DataSet  GetAllHR_SalaryStuctures()
    {
       DataSet hR_SalaryStuctures = new DataSet();
        SqlHR_SalaryStuctureProvider sqlHR_SalaryStuctureProvider = new SqlHR_SalaryStuctureProvider();
        hR_SalaryStuctures = sqlHR_SalaryStuctureProvider.GetAllHR_SalaryStuctures();
        return hR_SalaryStuctures;
    }

	public static void hR_SalaryStucturesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_SalaryStucturePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_SalaryStuctureProvider sqlHR_SalaryStuctureProvider = new SqlHR_SalaryStuctureProvider();
		DataSet ds =  sqlHR_SalaryStuctureProvider.GetHR_SalaryStucturePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_SalaryStucturesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_SalaryStucture()
    {
       DataSet hR_SalaryStuctures = new DataSet();
        SqlHR_SalaryStuctureProvider sqlHR_SalaryStuctureProvider = new SqlHR_SalaryStuctureProvider();
        hR_SalaryStuctures = sqlHR_SalaryStuctureProvider.GetDropDownListAllHR_SalaryStucture();
        return hR_SalaryStuctures;
    }

    public static DataSet   GetAllHR_SalaryStucturesWithRelation()
    {
       DataSet hR_SalaryStuctures = new DataSet();
        SqlHR_SalaryStuctureProvider sqlHR_SalaryStuctureProvider = new SqlHR_SalaryStuctureProvider();
        hR_SalaryStuctures = sqlHR_SalaryStuctureProvider.GetAllHR_SalaryStuctures();
        return hR_SalaryStuctures;
    }


    public static HR_SalaryStucture GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_SalaryStucture hR_SalaryStucture = new HR_SalaryStucture();
        SqlHR_SalaryStuctureProvider sqlHR_SalaryStuctureProvider = new SqlHR_SalaryStuctureProvider();
        hR_SalaryStucture = sqlHR_SalaryStuctureProvider.GetHR_SalaryStuctureByEmployeeID(EmployeeID);
        return hR_SalaryStucture;
    }


    public static HR_SalaryStucture GetHR_SalaryStuctureBySalaryStructureID(int SalaryStructureID)
    {
        HR_SalaryStucture hR_SalaryStucture = new HR_SalaryStucture();
        SqlHR_SalaryStuctureProvider sqlHR_SalaryStuctureProvider = new SqlHR_SalaryStuctureProvider();
        hR_SalaryStucture = sqlHR_SalaryStuctureProvider.GetHR_SalaryStuctureBySalaryStructureID(SalaryStructureID);
        return hR_SalaryStucture;
    }


    public static int InsertHR_SalaryStucture(HR_SalaryStucture hR_SalaryStucture)
    {
        SqlHR_SalaryStuctureProvider sqlHR_SalaryStuctureProvider = new SqlHR_SalaryStuctureProvider();
        return sqlHR_SalaryStuctureProvider.InsertHR_SalaryStucture(hR_SalaryStucture);
    }


    public static bool UpdateHR_SalaryStucture(HR_SalaryStucture hR_SalaryStucture)
    {
        SqlHR_SalaryStuctureProvider sqlHR_SalaryStuctureProvider = new SqlHR_SalaryStuctureProvider();
        return sqlHR_SalaryStuctureProvider.UpdateHR_SalaryStucture(hR_SalaryStucture);
    }

    public static bool DeleteHR_SalaryStucture(int hR_SalaryStuctureID)
    {
        SqlHR_SalaryStuctureProvider sqlHR_SalaryStuctureProvider = new SqlHR_SalaryStuctureProvider();
        return sqlHR_SalaryStuctureProvider.DeleteHR_SalaryStucture(hR_SalaryStuctureID);
    }
}

