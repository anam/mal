using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_CampusManager
{
	public STD_CampusManager()
	{
	}

    public static DataSet  GetAllSTD_Campuss()
    {
       DataSet sTD_Campuss = new DataSet();
        SqlSTD_CampusProvider sqlSTD_CampusProvider = new SqlSTD_CampusProvider();
        sTD_Campuss = sqlSTD_CampusProvider.GetAllSTD_Campuss();
        return sTD_Campuss;
    }

	public static void sTD_CampussPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_CampusPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_CampusProvider sqlSTD_CampusProvider = new SqlSTD_CampusProvider();
		DataSet ds =  sqlSTD_CampusProvider.GetSTD_CampusPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_CampussPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Campus()
    {
       DataSet sTD_Campuss = new DataSet();
        SqlSTD_CampusProvider sqlSTD_CampusProvider = new SqlSTD_CampusProvider();
        sTD_Campuss = sqlSTD_CampusProvider.GetDropDownListAllSTD_Campus();
        return sTD_Campuss;
    }

    public static DataSet   GetAllSTD_CampussWithRelation()
    {
       DataSet sTD_Campuss = new DataSet();
        SqlSTD_CampusProvider sqlSTD_CampusProvider = new SqlSTD_CampusProvider();
        sTD_Campuss = sqlSTD_CampusProvider.GetAllSTD_Campuss();
        return sTD_Campuss;
    }


    public static STD_Campus GetSTD_CityByCityID(int CityID)
    {
        STD_Campus sTD_Campus = new STD_Campus();
        SqlSTD_CampusProvider sqlSTD_CampusProvider = new SqlSTD_CampusProvider();
        sTD_Campus = sqlSTD_CampusProvider.GetSTD_CampusByCityID(CityID);
        return sTD_Campus;
    }


    public static STD_Campus GetSTD_CampusByCampusID(int CampusID)
    {
        STD_Campus sTD_Campus = new STD_Campus();
        SqlSTD_CampusProvider sqlSTD_CampusProvider = new SqlSTD_CampusProvider();
        sTD_Campus = sqlSTD_CampusProvider.GetSTD_CampusByCampusID(CampusID);
        return sTD_Campus;
    }


    public static int InsertSTD_Campus(STD_Campus sTD_Campus)
    {
        SqlSTD_CampusProvider sqlSTD_CampusProvider = new SqlSTD_CampusProvider();
        return sqlSTD_CampusProvider.InsertSTD_Campus(sTD_Campus);
    }


    public static bool UpdateSTD_Campus(STD_Campus sTD_Campus)
    {
        SqlSTD_CampusProvider sqlSTD_CampusProvider = new SqlSTD_CampusProvider();
        return sqlSTD_CampusProvider.UpdateSTD_Campus(sTD_Campus);
    }

    public static bool DeleteSTD_Campus(int sTD_CampusID)
    {
        SqlSTD_CampusProvider sqlSTD_CampusProvider = new SqlSTD_CampusProvider();
        return sqlSTD_CampusProvider.DeleteSTD_Campus(sTD_CampusID);
    }
}

