using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_PostingInformationManager
{
	public HR_PostingInformationManager()
	{
	}

    public static DataSet  GetAllHR_PostingInformations()
    {
       DataSet hR_PostingInformations = new DataSet();
        SqlHR_PostingInformationProvider sqlHR_PostingInformationProvider = new SqlHR_PostingInformationProvider();
        hR_PostingInformations = sqlHR_PostingInformationProvider.GetAllHR_PostingInformations();
        return hR_PostingInformations;
    }

	public static void hR_PostingInformationsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_PostingInformationPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_PostingInformationProvider sqlHR_PostingInformationProvider = new SqlHR_PostingInformationProvider();
		DataSet ds =  sqlHR_PostingInformationProvider.GetHR_PostingInformationPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_PostingInformationsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_PostingInformation()
    {
       DataSet hR_PostingInformations = new DataSet();
        SqlHR_PostingInformationProvider sqlHR_PostingInformationProvider = new SqlHR_PostingInformationProvider();
        hR_PostingInformations = sqlHR_PostingInformationProvider.GetDropDownListAllHR_PostingInformation();
        return hR_PostingInformations;
    }

    public static DataSet   GetAllHR_PostingInformationsWithRelation()
    {
       DataSet hR_PostingInformations = new DataSet();
        SqlHR_PostingInformationProvider sqlHR_PostingInformationProvider = new SqlHR_PostingInformationProvider();
        hR_PostingInformations = sqlHR_PostingInformationProvider.GetAllHR_PostingInformations();
        return hR_PostingInformations;
    }


    public static HR_PostingInformation GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_PostingInformation hR_PostingInformation = new HR_PostingInformation();
        SqlHR_PostingInformationProvider sqlHR_PostingInformationProvider = new SqlHR_PostingInformationProvider();
        hR_PostingInformation = sqlHR_PostingInformationProvider.GetHR_PostingInformationByEmployeeID(EmployeeID);
        return hR_PostingInformation;
    }


    public static HR_PostingInformation GetHR_PostingInformationByPostingInformationID(int PostingInformationID)
    {
        HR_PostingInformation hR_PostingInformation = new HR_PostingInformation();
        SqlHR_PostingInformationProvider sqlHR_PostingInformationProvider = new SqlHR_PostingInformationProvider();
        hR_PostingInformation = sqlHR_PostingInformationProvider.GetHR_PostingInformationByPostingInformationID(PostingInformationID);
        return hR_PostingInformation;
    }


    public static int InsertHR_PostingInformation(HR_PostingInformation hR_PostingInformation)
    {
        SqlHR_PostingInformationProvider sqlHR_PostingInformationProvider = new SqlHR_PostingInformationProvider();
        return sqlHR_PostingInformationProvider.InsertHR_PostingInformation(hR_PostingInformation);
    }


    public static bool UpdateHR_PostingInformation(HR_PostingInformation hR_PostingInformation)
    {
        SqlHR_PostingInformationProvider sqlHR_PostingInformationProvider = new SqlHR_PostingInformationProvider();
        return sqlHR_PostingInformationProvider.UpdateHR_PostingInformation(hR_PostingInformation);
    }

    public static bool DeleteHR_PostingInformation(int hR_PostingInformationID)
    {
        SqlHR_PostingInformationProvider sqlHR_PostingInformationProvider = new SqlHR_PostingInformationProvider();
        return sqlHR_PostingInformationProvider.DeleteHR_PostingInformation(hR_PostingInformationID);
    }
}

