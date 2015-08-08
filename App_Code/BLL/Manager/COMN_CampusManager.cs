using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_CampusManager
{
	public COMN_CampusManager()
	{
	}

    public static DataSet  GetAllCOMN_Campuss()
    {
       DataSet cOMN_Campuss = new DataSet();
        SqlCOMN_CampusProvider sqlCOMN_CampusProvider = new SqlCOMN_CampusProvider();
        cOMN_Campuss = sqlCOMN_CampusProvider.GetAllCOMN_Campuss();
        return cOMN_Campuss;
    }

	public static void cOMN_CampussPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_CampusPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_CampusProvider sqlCOMN_CampusProvider = new SqlCOMN_CampusProvider();
		DataSet ds =  sqlCOMN_CampusProvider.GetCOMN_CampusPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_CampussPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_Campus()
    {
       DataSet cOMN_Campuss = new DataSet();
        SqlCOMN_CampusProvider sqlCOMN_CampusProvider = new SqlCOMN_CampusProvider();
        cOMN_Campuss = sqlCOMN_CampusProvider.GetDropDownListAllCOMN_Campus();
        return cOMN_Campuss;
    }

    public static DataSet   GetAllCOMN_CampussWithRelation()
    {
       DataSet cOMN_Campuss = new DataSet();
        SqlCOMN_CampusProvider sqlCOMN_CampusProvider = new SqlCOMN_CampusProvider();
        cOMN_Campuss = sqlCOMN_CampusProvider.GetAllCOMN_Campuss();
        return cOMN_Campuss;
    }


    public static COMN_Campus GetCOMN_CityByCityID(int CityID)
    {
        COMN_Campus cOMN_Campus = new COMN_Campus();
        SqlCOMN_CampusProvider sqlCOMN_CampusProvider = new SqlCOMN_CampusProvider();
        cOMN_Campus = sqlCOMN_CampusProvider.GetCOMN_CampusByCityID(CityID);
        return cOMN_Campus;
    }


    public static COMN_Campus GetCOMN_CampusByCampusID(int CampusID)
    {
        COMN_Campus cOMN_Campus = new COMN_Campus();
        SqlCOMN_CampusProvider sqlCOMN_CampusProvider = new SqlCOMN_CampusProvider();
        cOMN_Campus = sqlCOMN_CampusProvider.GetCOMN_CampusByCampusID(CampusID);
        return cOMN_Campus;
    }


    public static int InsertCOMN_Campus(COMN_Campus cOMN_Campus)
    {
        SqlCOMN_CampusProvider sqlCOMN_CampusProvider = new SqlCOMN_CampusProvider();
        return sqlCOMN_CampusProvider.InsertCOMN_Campus(cOMN_Campus);
    }


    public static bool UpdateCOMN_Campus(COMN_Campus cOMN_Campus)
    {
        SqlCOMN_CampusProvider sqlCOMN_CampusProvider = new SqlCOMN_CampusProvider();
        return sqlCOMN_CampusProvider.UpdateCOMN_Campus(cOMN_Campus);
    }

    public static bool DeleteCOMN_Campus(int cOMN_CampusID)
    {
        SqlCOMN_CampusProvider sqlCOMN_CampusProvider = new SqlCOMN_CampusProvider();
        return sqlCOMN_CampusProvider.DeleteCOMN_Campus(cOMN_CampusID);
    }
}

