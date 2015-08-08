using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ContactInformationManager
{
	public HR_ContactInformationManager()
	{
	}

    public static DataSet  GetAllHR_ContactInformations()
    {
       DataSet hR_ContactInformations = new DataSet();
        SqlHR_ContactInformationProvider sqlHR_ContactInformationProvider = new SqlHR_ContactInformationProvider();
        hR_ContactInformations = sqlHR_ContactInformationProvider.GetAllHR_ContactInformations();
        return hR_ContactInformations;
    }

	public static void hR_ContactInformationsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_ContactInformationPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_ContactInformationProvider sqlHR_ContactInformationProvider = new SqlHR_ContactInformationProvider();
		DataSet ds =  sqlHR_ContactInformationProvider.GetHR_ContactInformationPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_ContactInformationsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_ContactInformation()
    {
       DataSet hR_ContactInformations = new DataSet();
        SqlHR_ContactInformationProvider sqlHR_ContactInformationProvider = new SqlHR_ContactInformationProvider();
        hR_ContactInformations = sqlHR_ContactInformationProvider.GetDropDownListAllHR_ContactInformation();
        return hR_ContactInformations;
    }

    public static DataSet   GetAllHR_ContactInformationsWithRelation()
    {
       DataSet hR_ContactInformations = new DataSet();
        SqlHR_ContactInformationProvider sqlHR_ContactInformationProvider = new SqlHR_ContactInformationProvider();
        hR_ContactInformations = sqlHR_ContactInformationProvider.GetAllHR_ContactInformations();
        return hR_ContactInformations;
    }


    public static HR_ContactInformation GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_ContactInformation hR_ContactInformation = new HR_ContactInformation();
        SqlHR_ContactInformationProvider sqlHR_ContactInformationProvider = new SqlHR_ContactInformationProvider();
        hR_ContactInformation = sqlHR_ContactInformationProvider.GetHR_ContactInformationByEmployeeID(EmployeeID);
        return hR_ContactInformation;
    }


    public static HR_ContactInformation GetHR_ContactInformationByContactInformationID(int ContactInformationID)
    {
        HR_ContactInformation hR_ContactInformation = new HR_ContactInformation();
        SqlHR_ContactInformationProvider sqlHR_ContactInformationProvider = new SqlHR_ContactInformationProvider();
        hR_ContactInformation = sqlHR_ContactInformationProvider.GetHR_ContactInformationByContactInformationID(ContactInformationID);
        return hR_ContactInformation;
    }


    public static int InsertHR_ContactInformation(HR_ContactInformation hR_ContactInformation)
    {
        SqlHR_ContactInformationProvider sqlHR_ContactInformationProvider = new SqlHR_ContactInformationProvider();
        return sqlHR_ContactInformationProvider.InsertHR_ContactInformation(hR_ContactInformation);
    }


    public static bool UpdateHR_ContactInformation(HR_ContactInformation hR_ContactInformation)
    {
        SqlHR_ContactInformationProvider sqlHR_ContactInformationProvider = new SqlHR_ContactInformationProvider();
        return sqlHR_ContactInformationProvider.UpdateHR_ContactInformation(hR_ContactInformation);
    }

    public static bool DeleteHR_ContactInformation(int hR_ContactInformationID)
    {
        SqlHR_ContactInformationProvider sqlHR_ContactInformationProvider = new SqlHR_ContactInformationProvider();
        return sqlHR_ContactInformationProvider.DeleteHR_ContactInformation(hR_ContactInformationID);
    }
}

