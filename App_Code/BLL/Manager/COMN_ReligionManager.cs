using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_ReligionManager
{
	public COMN_ReligionManager()
	{
	}

    public static DataSet  GetAllCOMN_Religions()
    {
       DataSet cOMN_Religions = new DataSet();
        SqlCOMN_ReligionProvider sqlCOMN_ReligionProvider = new SqlCOMN_ReligionProvider();
        cOMN_Religions = sqlCOMN_ReligionProvider.GetAllCOMN_Religions();
        return cOMN_Religions;
    }

	public static void cOMN_ReligionsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static DataSet GetDropDownListAllHR_Religion()
    {
        DataSet hR_Religions = new DataSet();
        SqlCOMN_ReligionProvider sqlHR_ReligionProvider = new SqlCOMN_ReligionProvider();
        hR_Religions = sqlHR_ReligionProvider.GetAllCOMN_Religions();
        return hR_Religions;
    }

 	public static void LoadCOMN_ReligionPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_ReligionProvider sqlCOMN_ReligionProvider = new SqlCOMN_ReligionProvider();
		DataSet ds =  sqlCOMN_ReligionProvider.GetCOMN_ReligionPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_ReligionsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_Religion()
    {
       DataSet cOMN_Religions = new DataSet();
        SqlCOMN_ReligionProvider sqlCOMN_ReligionProvider = new SqlCOMN_ReligionProvider();
        cOMN_Religions = sqlCOMN_ReligionProvider.GetDropDownListAllCOMN_Religion();
        return cOMN_Religions;
    }


    public static COMN_Religion GetCOMN_ReligionByReligionID(int ReligionID)
    {
        COMN_Religion cOMN_Religion = new COMN_Religion();
        SqlCOMN_ReligionProvider sqlCOMN_ReligionProvider = new SqlCOMN_ReligionProvider();
        cOMN_Religion = sqlCOMN_ReligionProvider.GetCOMN_ReligionByReligionID(ReligionID);
        return cOMN_Religion;
    }


    public static int InsertCOMN_Religion(COMN_Religion cOMN_Religion)
    {
        SqlCOMN_ReligionProvider sqlCOMN_ReligionProvider = new SqlCOMN_ReligionProvider();
        return sqlCOMN_ReligionProvider.InsertCOMN_Religion(cOMN_Religion);
    }


    public static bool UpdateCOMN_Religion(COMN_Religion cOMN_Religion)
    {
        SqlCOMN_ReligionProvider sqlCOMN_ReligionProvider = new SqlCOMN_ReligionProvider();
        return sqlCOMN_ReligionProvider.UpdateCOMN_Religion(cOMN_Religion);
    }

    public static bool DeleteCOMN_Religion(int cOMN_ReligionID)
    {
        SqlCOMN_ReligionProvider sqlCOMN_ReligionProvider = new SqlCOMN_ReligionProvider();
        return sqlCOMN_ReligionProvider.DeleteCOMN_Religion(cOMN_ReligionID);
    }
}

