using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_NationalityManager
{
	public COMN_NationalityManager()
	{
	}

    public static DataSet  GetAllCOMN_Nationalities()
    {
       DataSet cOMN_Nationalities = new DataSet();
        SqlCOMN_NationalityProvider sqlCOMN_NationalityProvider = new SqlCOMN_NationalityProvider();
        cOMN_Nationalities = sqlCOMN_NationalityProvider.GetAllCOMN_Nationalities();
        return cOMN_Nationalities;
    }

	public static void cOMN_NationalitiesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static DataSet GetDropDownListAllHR_Nationality()
    {
        DataSet hR_Nationalities = new DataSet();
        SqlCOMN_NationalityProvider sqlHR_NationalityProvider = new SqlCOMN_NationalityProvider();
        hR_Nationalities = sqlHR_NationalityProvider.GetAllCOMN_Nationalities();
        return hR_Nationalities;
    }

 	public static void LoadCOMN_NationalityPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_NationalityProvider sqlCOMN_NationalityProvider = new SqlCOMN_NationalityProvider();
		DataSet ds =  sqlCOMN_NationalityProvider.GetCOMN_NationalityPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_NationalitiesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_Nationality()
    {
       DataSet cOMN_Nationalities = new DataSet();
        SqlCOMN_NationalityProvider sqlCOMN_NationalityProvider = new SqlCOMN_NationalityProvider();
        cOMN_Nationalities = sqlCOMN_NationalityProvider.GetDropDownListAllCOMN_Nationality();
        return cOMN_Nationalities;
    }


    public static COMN_Nationality GetCOMN_NationalityByNationalityID(int NationalityID)
    {
        COMN_Nationality cOMN_Nationality = new COMN_Nationality();
        SqlCOMN_NationalityProvider sqlCOMN_NationalityProvider = new SqlCOMN_NationalityProvider();
        cOMN_Nationality = sqlCOMN_NationalityProvider.GetCOMN_NationalityByNationalityID(NationalityID);
        return cOMN_Nationality;
    }


    public static int InsertCOMN_Nationality(COMN_Nationality cOMN_Nationality)
    {
        SqlCOMN_NationalityProvider sqlCOMN_NationalityProvider = new SqlCOMN_NationalityProvider();
        return sqlCOMN_NationalityProvider.InsertCOMN_Nationality(cOMN_Nationality);
    }


    public static bool UpdateCOMN_Nationality(COMN_Nationality cOMN_Nationality)
    {
        SqlCOMN_NationalityProvider sqlCOMN_NationalityProvider = new SqlCOMN_NationalityProvider();
        return sqlCOMN_NationalityProvider.UpdateCOMN_Nationality(cOMN_Nationality);
    }

    public static bool DeleteCOMN_Nationality(int cOMN_NationalityID)
    {
        SqlCOMN_NationalityProvider sqlCOMN_NationalityProvider = new SqlCOMN_NationalityProvider();
        return sqlCOMN_NationalityProvider.DeleteCOMN_Nationality(cOMN_NationalityID);
    }
}

