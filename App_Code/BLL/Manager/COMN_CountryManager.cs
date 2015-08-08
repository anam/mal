using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_CountryManager
{
	public COMN_CountryManager()
	{
	}

    public static DataSet  GetAllCOMN_Countries()
    {
       DataSet cOMN_Countries = new DataSet();
        SqlCOMN_CountryProvider sqlCOMN_CountryProvider = new SqlCOMN_CountryProvider();
        cOMN_Countries = sqlCOMN_CountryProvider.GetAllCOMN_Countries();
        return cOMN_Countries;
    }

	public static void cOMN_CountriesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_CountryPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_CountryProvider sqlCOMN_CountryProvider = new SqlCOMN_CountryProvider();
		DataSet ds =  sqlCOMN_CountryProvider.GetCOMN_CountryPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_CountriesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_Country()
    {
       DataSet cOMN_Countries = new DataSet();
        SqlCOMN_CountryProvider sqlCOMN_CountryProvider = new SqlCOMN_CountryProvider();
        cOMN_Countries = sqlCOMN_CountryProvider.GetDropDownListAllCOMN_Country();
        return cOMN_Countries;
    }


    public static COMN_Country GetCOMN_CountryByCountryID(int CountryID)
    {
        COMN_Country cOMN_Country = new COMN_Country();
        SqlCOMN_CountryProvider sqlCOMN_CountryProvider = new SqlCOMN_CountryProvider();
        cOMN_Country = sqlCOMN_CountryProvider.GetCOMN_CountryByCountryID(CountryID);
        return cOMN_Country;
    }


    public static int InsertCOMN_Country(COMN_Country cOMN_Country)
    {
        SqlCOMN_CountryProvider sqlCOMN_CountryProvider = new SqlCOMN_CountryProvider();
        return sqlCOMN_CountryProvider.InsertCOMN_Country(cOMN_Country);
    }


    public static bool UpdateCOMN_Country(COMN_Country cOMN_Country)
    {
        SqlCOMN_CountryProvider sqlCOMN_CountryProvider = new SqlCOMN_CountryProvider();
        return sqlCOMN_CountryProvider.UpdateCOMN_Country(cOMN_Country);
    }

    public static bool DeleteCOMN_Country(int cOMN_CountryID)
    {
        SqlCOMN_CountryProvider sqlCOMN_CountryProvider = new SqlCOMN_CountryProvider();
        return sqlCOMN_CountryProvider.DeleteCOMN_Country(cOMN_CountryID);
    }
}

