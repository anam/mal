using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_AttendenceRulesManager
{
	public HR_AttendenceRulesManager()
	{
	}

    public static DataSet  GetAllHR_AttendenceRuless()
    {
       DataSet hR_AttendenceRuless = new DataSet();
        SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
        hR_AttendenceRuless = sqlHR_AttendenceRulesProvider.GetAllHR_AttendenceRuless();
        return hR_AttendenceRuless;
    }

	public static void hR_AttendenceRulessPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_AttendenceRulesPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
		DataSet ds =  sqlHR_AttendenceRulesProvider.GetHR_AttendenceRulesPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_AttendenceRulessPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_AttendenceRules()
    {
       DataSet hR_AttendenceRuless = new DataSet();
        SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
        hR_AttendenceRuless = sqlHR_AttendenceRulesProvider.GetDropDownLisAllHR_AttendenceRules();
        return hR_AttendenceRuless;
    }

    public static DataSet   GetAllHR_AttendenceRulessWithRelation()
    {
       DataSet hR_AttendenceRuless = new DataSet();
        SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
        hR_AttendenceRuless = sqlHR_AttendenceRulesProvider.GetAllHR_AttendenceRuless();
        return hR_AttendenceRuless;
    }

    public static HR_AttendenceRules GetHR_AttendenceRulesObjectByEmployeeID(string EmployeeID)
    {
        HR_AttendenceRules hR_AttendenceRules = new HR_AttendenceRules();
        SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
        hR_AttendenceRules = sqlHR_AttendenceRulesProvider.GetHR_AttendenceRulesObjectByEmployeeID(EmployeeID);
        return hR_AttendenceRules;
    }

    public static DataSet GetHR_AttendenceRulesByEmployeeID(string EmployeeID)
    {
        DataSet hR_AttendenceRuless = new DataSet();
        SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
        hR_AttendenceRuless = sqlHR_AttendenceRulesProvider.GetHR_AttendenceRulesByEmployeeID(EmployeeID);
        return hR_AttendenceRuless;
    }


    public static HR_AttendenceRules GetHR_AttendenceRulesByAttendenceRulesID(int AttendenceRulesID)
    {
        HR_AttendenceRules hR_AttendenceRules = new HR_AttendenceRules();
        SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
        hR_AttendenceRules = sqlHR_AttendenceRulesProvider.GetHR_AttendenceRulesByAttendenceRulesID(AttendenceRulesID);
        return hR_AttendenceRules;
    }


    public static int InsertHR_AttendenceRules(HR_AttendenceRules hR_AttendenceRules)
    {
        SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
        return sqlHR_AttendenceRulesProvider.InsertHR_AttendenceRules(hR_AttendenceRules);
    }


    public static bool UpdateHR_AttendenceRules(HR_AttendenceRules hR_AttendenceRules)
    {
        SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
        return sqlHR_AttendenceRulesProvider.UpdateHR_AttendenceRules(hR_AttendenceRules);
    }

    public static bool DeleteHR_AttendenceRules(int hR_AttendenceRulesID)
    {
        SqlHR_AttendenceRulesProvider sqlHR_AttendenceRulesProvider = new SqlHR_AttendenceRulesProvider();
        return sqlHR_AttendenceRulesProvider.DeleteHR_AttendenceRules(hR_AttendenceRulesID);
    }
}

