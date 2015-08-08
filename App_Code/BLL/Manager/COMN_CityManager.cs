using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_CityManager
{
	public COMN_CityManager()
	{
	}

    public static DataSet  GetAllCOMN_Cities()
    {
       DataSet cOMN_Cities = new DataSet();
        SqlCOMN_CityProvider sqlCOMN_CityProvider = new SqlCOMN_CityProvider();
        cOMN_Cities = sqlCOMN_CityProvider.GetAllCOMN_Cities();
        return cOMN_Cities;
    }

	public static void cOMN_CitiesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_CityPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_CityProvider sqlCOMN_CityProvider = new SqlCOMN_CityProvider();
		DataSet ds =  sqlCOMN_CityProvider.GetCOMN_CityPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_CitiesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_City()
    {
       DataSet cOMN_Cities = new DataSet();
        SqlCOMN_CityProvider sqlCOMN_CityProvider = new SqlCOMN_CityProvider();
        cOMN_Cities = sqlCOMN_CityProvider.GetDropDownListAllCOMN_City();
        return cOMN_Cities;
    }

    public static DataSet   GetAllCOMN_CitiesWithRelation()
    {
       DataSet cOMN_Cities = new DataSet();
        SqlCOMN_CityProvider sqlCOMN_CityProvider = new SqlCOMN_CityProvider();
        cOMN_Cities = sqlCOMN_CityProvider.GetAllCOMN_Cities();
        return cOMN_Cities;
    }


    public static COMN_City GetCOMN_CountryByCountryID(int CountryID)
    {
        COMN_City cOMN_City = new COMN_City();
        SqlCOMN_CityProvider sqlCOMN_CityProvider = new SqlCOMN_CityProvider();
        cOMN_City = sqlCOMN_CityProvider.GetCOMN_CityByCountryID(CountryID);
        return cOMN_City;
    }


    public static COMN_City GetCOMN_CityByCityID(int CityID)
    {
        COMN_City cOMN_City = new COMN_City();
        SqlCOMN_CityProvider sqlCOMN_CityProvider = new SqlCOMN_CityProvider();
        cOMN_City = sqlCOMN_CityProvider.GetCOMN_CityByCityID(CityID);
        return cOMN_City;
    }


    public static int InsertCOMN_City(COMN_City cOMN_City)
    {
        SqlCOMN_CityProvider sqlCOMN_CityProvider = new SqlCOMN_CityProvider();
        return sqlCOMN_CityProvider.InsertCOMN_City(cOMN_City);
    }


    public static bool UpdateCOMN_City(COMN_City cOMN_City)
    {
        SqlCOMN_CityProvider sqlCOMN_CityProvider = new SqlCOMN_CityProvider();
        return sqlCOMN_CityProvider.UpdateCOMN_City(cOMN_City);
    }

    public static bool DeleteCOMN_City(int cOMN_CityID)
    {
        SqlCOMN_CityProvider sqlCOMN_CityProvider = new SqlCOMN_CityProvider();
        return sqlCOMN_CityProvider.DeleteCOMN_City(cOMN_CityID);
    }
}

