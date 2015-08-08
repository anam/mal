using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryIncrementManager
{
	public HR_SalaryIncrementManager()
	{
	}

    public static DataSet  GetAllHR_SalaryIncrements()
    {
       DataSet hR_SalaryIncrements = new DataSet();
        SqlHR_SalaryIncrementProvider sqlHR_SalaryIncrementProvider = new SqlHR_SalaryIncrementProvider();
        hR_SalaryIncrements = sqlHR_SalaryIncrementProvider.GetAllHR_SalaryIncrements();
        return hR_SalaryIncrements;
    }

	public static void hR_SalaryIncrementsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_SalaryIncrementPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_SalaryIncrementProvider sqlHR_SalaryIncrementProvider = new SqlHR_SalaryIncrementProvider();
		DataSet ds =  sqlHR_SalaryIncrementProvider.GetHR_SalaryIncrementPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_SalaryIncrementsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_SalaryIncrement()
    {
       DataSet hR_SalaryIncrements = new DataSet();
        SqlHR_SalaryIncrementProvider sqlHR_SalaryIncrementProvider = new SqlHR_SalaryIncrementProvider();
        hR_SalaryIncrements = sqlHR_SalaryIncrementProvider.GetDropDownListAllHR_SalaryIncrement();
        return hR_SalaryIncrements;
    }

    public static DataSet   GetAllHR_SalaryIncrementsWithRelation()
    {
       DataSet hR_SalaryIncrements = new DataSet();
        SqlHR_SalaryIncrementProvider sqlHR_SalaryIncrementProvider = new SqlHR_SalaryIncrementProvider();
        hR_SalaryIncrements = sqlHR_SalaryIncrementProvider.GetAllHR_SalaryIncrements();
        return hR_SalaryIncrements;
    }


    public static HR_SalaryIncrement GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_SalaryIncrement hR_SalaryIncrement = new HR_SalaryIncrement();
        SqlHR_SalaryIncrementProvider sqlHR_SalaryIncrementProvider = new SqlHR_SalaryIncrementProvider();
        hR_SalaryIncrement = sqlHR_SalaryIncrementProvider.GetHR_SalaryIncrementByEmployeeID(EmployeeID);
        return hR_SalaryIncrement;
    }


    public static HR_SalaryIncrement GetHR_SalaryIncrementBySalaryIncrementID(int SalaryIncrementID)
    {
        HR_SalaryIncrement hR_SalaryIncrement = new HR_SalaryIncrement();
        SqlHR_SalaryIncrementProvider sqlHR_SalaryIncrementProvider = new SqlHR_SalaryIncrementProvider();
        hR_SalaryIncrement = sqlHR_SalaryIncrementProvider.GetHR_SalaryIncrementBySalaryIncrementID(SalaryIncrementID);
        return hR_SalaryIncrement;
    }


    public static int InsertHR_SalaryIncrement(HR_SalaryIncrement hR_SalaryIncrement)
    {
        SqlHR_SalaryIncrementProvider sqlHR_SalaryIncrementProvider = new SqlHR_SalaryIncrementProvider();
        return sqlHR_SalaryIncrementProvider.InsertHR_SalaryIncrement(hR_SalaryIncrement);
    }


    public static bool UpdateHR_SalaryIncrement(HR_SalaryIncrement hR_SalaryIncrement)
    {
        SqlHR_SalaryIncrementProvider sqlHR_SalaryIncrementProvider = new SqlHR_SalaryIncrementProvider();
        return sqlHR_SalaryIncrementProvider.UpdateHR_SalaryIncrement(hR_SalaryIncrement);
    }

    public static bool DeleteHR_SalaryIncrement(int hR_SalaryIncrementID)
    {
        SqlHR_SalaryIncrementProvider sqlHR_SalaryIncrementProvider = new SqlHR_SalaryIncrementProvider();
        return sqlHR_SalaryIncrementProvider.DeleteHR_SalaryIncrement(hR_SalaryIncrementID);
    }
}

