using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ProvidentFundSetupManager
{
	public HR_ProvidentFundSetupManager()
	{
	}

    public static DataSet  GetAllHR_ProvidentFundSetups()
    {
       DataSet hR_ProvidentFundSetups = new DataSet();
        SqlHR_ProvidentFundSetupProvider sqlHR_ProvidentFundSetupProvider = new SqlHR_ProvidentFundSetupProvider();
        hR_ProvidentFundSetups = sqlHR_ProvidentFundSetupProvider.GetAllHR_ProvidentFundSetups();
        return hR_ProvidentFundSetups;
    }

	public static void hR_ProvidentFundSetupsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_ProvidentFundSetupPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_ProvidentFundSetupProvider sqlHR_ProvidentFundSetupProvider = new SqlHR_ProvidentFundSetupProvider();
		DataSet ds =  sqlHR_ProvidentFundSetupProvider.GetHR_ProvidentFundSetupPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_ProvidentFundSetupsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_ProvidentFundSetup()
    {
       DataSet hR_ProvidentFundSetups = new DataSet();
        SqlHR_ProvidentFundSetupProvider sqlHR_ProvidentFundSetupProvider = new SqlHR_ProvidentFundSetupProvider();
        hR_ProvidentFundSetups = sqlHR_ProvidentFundSetupProvider.GetDropDownLisAllHR_ProvidentFundSetup();
        return hR_ProvidentFundSetups;
    }


    public static HR_ProvidentFundSetup GetHR_FundTypeByFundTypeID(int FundTypeID)
    {
        HR_ProvidentFundSetup hR_ProvidentFundSetup = new HR_ProvidentFundSetup();
        SqlHR_ProvidentFundSetupProvider sqlHR_ProvidentFundSetupProvider = new SqlHR_ProvidentFundSetupProvider();
        hR_ProvidentFundSetup = sqlHR_ProvidentFundSetupProvider.GetHR_ProvidentFundSetupByFundTypeID(FundTypeID);
        return hR_ProvidentFundSetup;
    }
    
    public static List<HR_ProvidentFundSetup> GetHR_ProvidentFundSetupColl()
    {
        List<HR_ProvidentFundSetup> hR_ProvidentFundSetup = new List<HR_ProvidentFundSetup>();
        SqlHR_ProvidentFundSetupProvider sqlHR_ProvidentFundSetupProvider = new SqlHR_ProvidentFundSetupProvider();
        hR_ProvidentFundSetup = sqlHR_ProvidentFundSetupProvider.GetHR_ProvidentFundSetupColl();
        return hR_ProvidentFundSetup;
    }

    public static HR_ProvidentFundSetup GetHR_ProvidentFundSetupByProvidentFundSetupID(int ProvidentFundSetupID)
    {
        HR_ProvidentFundSetup hR_ProvidentFundSetup = new HR_ProvidentFundSetup();
        SqlHR_ProvidentFundSetupProvider sqlHR_ProvidentFundSetupProvider = new SqlHR_ProvidentFundSetupProvider();
        hR_ProvidentFundSetup = sqlHR_ProvidentFundSetupProvider.GetHR_ProvidentFundSetupByProvidentFundSetupID(ProvidentFundSetupID);
        return hR_ProvidentFundSetup;
    }


    public static int InsertHR_ProvidentFundSetup(HR_ProvidentFundSetup hR_ProvidentFundSetup)
    {
        SqlHR_ProvidentFundSetupProvider sqlHR_ProvidentFundSetupProvider = new SqlHR_ProvidentFundSetupProvider();
        return sqlHR_ProvidentFundSetupProvider.InsertHR_ProvidentFundSetup(hR_ProvidentFundSetup);
    }


    public static bool UpdateHR_ProvidentFundSetup(HR_ProvidentFundSetup hR_ProvidentFundSetup)
    {
        SqlHR_ProvidentFundSetupProvider sqlHR_ProvidentFundSetupProvider = new SqlHR_ProvidentFundSetupProvider();
        return sqlHR_ProvidentFundSetupProvider.UpdateHR_ProvidentFundSetup(hR_ProvidentFundSetup);
    }

    public static bool DeleteHR_ProvidentFundSetup(int hR_ProvidentFundSetupID)
    {
        SqlHR_ProvidentFundSetupProvider sqlHR_ProvidentFundSetupProvider = new SqlHR_ProvidentFundSetupProvider();
        return sqlHR_ProvidentFundSetupProvider.DeleteHR_ProvidentFundSetup(hR_ProvidentFundSetupID);
    }
}

