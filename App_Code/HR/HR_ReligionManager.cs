using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ReligionManager
{
	public HR_ReligionManager()
	{
	}

    public static DataSet  GetAllHR_Religions()
    {
       DataSet hR_Religions = new DataSet();
        SqlHR_ReligionProvider sqlHR_ReligionProvider = new SqlHR_ReligionProvider();
        hR_Religions = sqlHR_ReligionProvider.GetAllHR_Religions();
        return hR_Religions;
    }

	public static void hR_ReligionsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_ReligionPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_ReligionProvider sqlHR_ReligionProvider = new SqlHR_ReligionProvider();
		DataSet ds =  sqlHR_ReligionProvider.GetHR_ReligionPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_ReligionsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Religion()
    {
       DataSet hR_Religions = new DataSet();
        SqlHR_ReligionProvider sqlHR_ReligionProvider = new SqlHR_ReligionProvider();
        hR_Religions = sqlHR_ReligionProvider.GetDropDownListAllHR_Religion();
        return hR_Religions;
    }


    public static HR_Religion GetHR_ReligionByReligionID(int ReligionID)
    {
        HR_Religion hR_Religion = new HR_Religion();
        SqlHR_ReligionProvider sqlHR_ReligionProvider = new SqlHR_ReligionProvider();
        hR_Religion = sqlHR_ReligionProvider.GetHR_ReligionByReligionID(ReligionID);
        return hR_Religion;
    }


    public static int InsertHR_Religion(HR_Religion hR_Religion)
    {
        SqlHR_ReligionProvider sqlHR_ReligionProvider = new SqlHR_ReligionProvider();
        return sqlHR_ReligionProvider.InsertHR_Religion(hR_Religion);
    }


    public static bool UpdateHR_Religion(HR_Religion hR_Religion)
    {
        SqlHR_ReligionProvider sqlHR_ReligionProvider = new SqlHR_ReligionProvider();
        return sqlHR_ReligionProvider.UpdateHR_Religion(hR_Religion);
    }

    public static bool DeleteHR_Religion(int hR_ReligionID)
    {
        SqlHR_ReligionProvider sqlHR_ReligionProvider = new SqlHR_ReligionProvider();
        return sqlHR_ReligionProvider.DeleteHR_Religion(hR_ReligionID);
    }
}

