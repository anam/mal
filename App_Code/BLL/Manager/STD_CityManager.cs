using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_CityManager
{
	public STD_CityManager()
	{
	}

    public static DataSet  GetAllSTD_Cities()
    {
       DataSet sTD_Cities = new DataSet();
        SqlSTD_CityProvider sqlSTD_CityProvider = new SqlSTD_CityProvider();
        sTD_Cities = sqlSTD_CityProvider.GetAllSTD_Cities();
        return sTD_Cities;
    }

	public static void sTD_CitiesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_CityPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_CityProvider sqlSTD_CityProvider = new SqlSTD_CityProvider();
		DataSet ds =  sqlSTD_CityProvider.GetSTD_CityPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_CitiesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_City()
    {
       DataSet sTD_Cities = new DataSet();
        SqlSTD_CityProvider sqlSTD_CityProvider = new SqlSTD_CityProvider();
        sTD_Cities = sqlSTD_CityProvider.GetDropDownListAllSTD_City();
        return sTD_Cities;
    }

    public static DataSet   GetAllSTD_CitiesWithRelation()
    {
       DataSet sTD_Cities = new DataSet();
        SqlSTD_CityProvider sqlSTD_CityProvider = new SqlSTD_CityProvider();
        sTD_Cities = sqlSTD_CityProvider.GetAllSTD_Cities();
        return sTD_Cities;
    }


    public static STD_City GetSTD_CountryByCountryID(int CountryID)
    {
        STD_City sTD_City = new STD_City();
        SqlSTD_CityProvider sqlSTD_CityProvider = new SqlSTD_CityProvider();
        sTD_City = sqlSTD_CityProvider.GetSTD_CityByCountryID(CountryID);
        return sTD_City;
    }


    public static STD_City GetSTD_CityByCityID(int CityID)
    {
        STD_City sTD_City = new STD_City();
        SqlSTD_CityProvider sqlSTD_CityProvider = new SqlSTD_CityProvider();
        sTD_City = sqlSTD_CityProvider.GetSTD_CityByCityID(CityID);
        return sTD_City;
    }


    public static int InsertSTD_City(STD_City sTD_City)
    {
        SqlSTD_CityProvider sqlSTD_CityProvider = new SqlSTD_CityProvider();
        return sqlSTD_CityProvider.InsertSTD_City(sTD_City);
    }


    public static bool UpdateSTD_City(STD_City sTD_City)
    {
        SqlSTD_CityProvider sqlSTD_CityProvider = new SqlSTD_CityProvider();
        return sqlSTD_CityProvider.UpdateSTD_City(sTD_City);
    }

    public static bool DeleteSTD_City(int sTD_CityID)
    {
        SqlSTD_CityProvider sqlSTD_CityProvider = new SqlSTD_CityProvider();
        return sqlSTD_CityProvider.DeleteSTD_City(sTD_CityID);
    }
}

