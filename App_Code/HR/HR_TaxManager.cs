using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_TaxManager
{
	public HR_TaxManager()
	{
	}

    public static DataSet  GetAllHR_Taxs()
    {
       DataSet hR_Taxs = new DataSet();
        SqlHR_TaxProvider sqlHR_TaxProvider = new SqlHR_TaxProvider();
        hR_Taxs = sqlHR_TaxProvider.GetAllHR_Taxs();
        return hR_Taxs;
    }

	public static void hR_TaxsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_TaxPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_TaxProvider sqlHR_TaxProvider = new SqlHR_TaxProvider();
		DataSet ds =  sqlHR_TaxProvider.GetHR_TaxPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_TaxsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Tax()
    {
       DataSet hR_Taxs = new DataSet();
        SqlHR_TaxProvider sqlHR_TaxProvider = new SqlHR_TaxProvider();
        hR_Taxs = sqlHR_TaxProvider.GetDropDownListAllHR_Tax();
        return hR_Taxs;
    }

    public static DataSet   GetAllHR_TaxsWithRelation()
    {
       DataSet hR_Taxs = new DataSet();
        SqlHR_TaxProvider sqlHR_TaxProvider = new SqlHR_TaxProvider();
        hR_Taxs = sqlHR_TaxProvider.GetAllHR_Taxs();
        return hR_Taxs;
    }


    public static HR_Tax GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_Tax hR_Tax = new HR_Tax();
        SqlHR_TaxProvider sqlHR_TaxProvider = new SqlHR_TaxProvider();
        hR_Tax = sqlHR_TaxProvider.GetHR_TaxByEmployeeID(EmployeeID);
        return hR_Tax;
    }


    public static HR_Tax GetHR_TaxByTaxID(int TaxID)
    {
        HR_Tax hR_Tax = new HR_Tax();
        SqlHR_TaxProvider sqlHR_TaxProvider = new SqlHR_TaxProvider();
        hR_Tax = sqlHR_TaxProvider.GetHR_TaxByTaxID(TaxID);
        return hR_Tax;
    }


    public static int InsertHR_Tax(HR_Tax hR_Tax)
    {
        SqlHR_TaxProvider sqlHR_TaxProvider = new SqlHR_TaxProvider();
        return sqlHR_TaxProvider.InsertHR_Tax(hR_Tax);
    }


    public static bool UpdateHR_Tax(HR_Tax hR_Tax)
    {
        SqlHR_TaxProvider sqlHR_TaxProvider = new SqlHR_TaxProvider();
        return sqlHR_TaxProvider.UpdateHR_Tax(hR_Tax);
    }

    public static bool DeleteHR_Tax(int hR_TaxID)
    {
        SqlHR_TaxProvider sqlHR_TaxProvider = new SqlHR_TaxProvider();
        return sqlHR_TaxProvider.DeleteHR_Tax(hR_TaxID);
    }
}

