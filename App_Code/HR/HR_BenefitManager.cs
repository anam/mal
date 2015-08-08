using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_BenefitManager
{
	public HR_BenefitManager()
	{
	}

    public static DataSet  GetAllHR_Benefits()
    {
       DataSet hR_Benefits = new DataSet();
        SqlHR_BenefitProvider sqlHR_BenefitProvider = new SqlHR_BenefitProvider();
        hR_Benefits = sqlHR_BenefitProvider.GetAllHR_Benefits();
        return hR_Benefits;
    }

	public static void hR_BenefitsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_BenefitPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_BenefitProvider sqlHR_BenefitProvider = new SqlHR_BenefitProvider();
		DataSet ds =  sqlHR_BenefitProvider.GetHR_BenefitPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_BenefitsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Benefit()
    {
       DataSet hR_Benefits = new DataSet();
        SqlHR_BenefitProvider sqlHR_BenefitProvider = new SqlHR_BenefitProvider();
        hR_Benefits = sqlHR_BenefitProvider.GetDropDownListAllHR_Benefit();
        return hR_Benefits;
    }

    public static DataSet   GetAllHR_BenefitsWithRelation()
    {
       DataSet hR_Benefits = new DataSet();
        SqlHR_BenefitProvider sqlHR_BenefitProvider = new SqlHR_BenefitProvider();
        hR_Benefits = sqlHR_BenefitProvider.GetAllHR_Benefits();
        return hR_Benefits;
    }


    public static HR_Benefit GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_Benefit hR_Benefit = new HR_Benefit();
        SqlHR_BenefitProvider sqlHR_BenefitProvider = new SqlHR_BenefitProvider();
        hR_Benefit = sqlHR_BenefitProvider.GetHR_BenefitByEmployeeID(EmployeeID);
        return hR_Benefit;
    }


    public static HR_Benefit GetHR_BenefitByBenefitPackageID(int BenefitPackageID)
    {
        HR_Benefit hR_Benefit = new HR_Benefit();
        SqlHR_BenefitProvider sqlHR_BenefitProvider = new SqlHR_BenefitProvider();
        hR_Benefit = sqlHR_BenefitProvider.GetHR_BenefitByBenefitPackageID(BenefitPackageID);
        return hR_Benefit;
    }


    public static int InsertHR_Benefit(HR_Benefit hR_Benefit)
    {
        SqlHR_BenefitProvider sqlHR_BenefitProvider = new SqlHR_BenefitProvider();
        return sqlHR_BenefitProvider.InsertHR_Benefit(hR_Benefit);
    }


    public static bool UpdateHR_Benefit(HR_Benefit hR_Benefit)
    {
        SqlHR_BenefitProvider sqlHR_BenefitProvider = new SqlHR_BenefitProvider();
        return sqlHR_BenefitProvider.UpdateHR_Benefit(hR_Benefit);
    }

    public static bool DeleteHR_Benefit(int hR_BenefitID)
    {
        SqlHR_BenefitProvider sqlHR_BenefitProvider = new SqlHR_BenefitProvider();
        return sqlHR_BenefitProvider.DeleteHR_Benefit(hR_BenefitID);
    }
}

