using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_CountryManager
{
	public STD_CountryManager()
	{
	}

    public static DataSet  GetAllSTD_Countries()
    {
       DataSet sTD_Countries = new DataSet();
        SqlSTD_CountryProvider sqlSTD_CountryProvider = new SqlSTD_CountryProvider();
        sTD_Countries = sqlSTD_CountryProvider.GetAllSTD_Countries();
        return sTD_Countries;
    }

	public static void sTD_CountriesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_CountryPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_CountryProvider sqlSTD_CountryProvider = new SqlSTD_CountryProvider();
		DataSet ds =  sqlSTD_CountryProvider.GetSTD_CountryPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_CountriesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Country()
    {
       DataSet sTD_Countries = new DataSet();
        SqlSTD_CountryProvider sqlSTD_CountryProvider = new SqlSTD_CountryProvider();
        sTD_Countries = sqlSTD_CountryProvider.GetDropDownListAllSTD_Country();
        return sTD_Countries;
    }


    public static STD_Country GetSTD_CountryByCountryID(int CountryID)
    {
        STD_Country sTD_Country = new STD_Country();
        SqlSTD_CountryProvider sqlSTD_CountryProvider = new SqlSTD_CountryProvider();
        sTD_Country = sqlSTD_CountryProvider.GetSTD_CountryByCountryID(CountryID);
        return sTD_Country;
    }


    public static int InsertSTD_Country(STD_Country sTD_Country)
    {
        SqlSTD_CountryProvider sqlSTD_CountryProvider = new SqlSTD_CountryProvider();
        return sqlSTD_CountryProvider.InsertSTD_Country(sTD_Country);
    }


    public static bool UpdateSTD_Country(STD_Country sTD_Country)
    {
        SqlSTD_CountryProvider sqlSTD_CountryProvider = new SqlSTD_CountryProvider();
        return sqlSTD_CountryProvider.UpdateSTD_Country(sTD_Country);
    }

    public static bool DeleteSTD_Country(int sTD_CountryID)
    {
        SqlSTD_CountryProvider sqlSTD_CountryProvider = new SqlSTD_CountryProvider();
        return sqlSTD_CountryProvider.DeleteSTD_Country(sTD_CountryID);
    }
}

