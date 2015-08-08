using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryAdjustmentListRulesManager
{
    public HR_SalaryAdjustmentListRulesManager()
    {
    }

    public static DataSet GetAllSalaryAdjustmentListRuless()
    {
        DataSet salaryAdjustmentListRuless = new DataSet();
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        salaryAdjustmentListRuless = sqlSalaryAdjustmentListRulesProvider.GetAllSalaryAdjustmentListRuless();
        return salaryAdjustmentListRuless;
    }

    public static void salaryAdjustmentListRulessPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static void LoadSalaryAdjustmentListRulesPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        DataSet ds = sqlSalaryAdjustmentListRulesProvider.GetSalaryAdjustmentListRulesPageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        salaryAdjustmentListRulessPaggination(rptPager, recordCount, pageIndex, PageSize);
    }
    public static DataSet GetDropDownListAllSalaryAdjustmentListRules()
    {
        DataSet salaryAdjustmentListRuless = new DataSet();
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        salaryAdjustmentListRuless = sqlSalaryAdjustmentListRulesProvider.GetDropDownLisAllSalaryAdjustmentListRules();
        return salaryAdjustmentListRuless;
    }


    public static HR_SalaryAdjustmentListRules GetHR_SalaryAdjustmentListBySalaryAdjustmentGroupID(int SalaryAdjustmentGroupID)
    {
        HR_SalaryAdjustmentListRules salaryAdjustmentListRules = new HR_SalaryAdjustmentListRules();
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        salaryAdjustmentListRules = sqlSalaryAdjustmentListRulesProvider.GetSalaryAdjustmentListRulesBySalaryAdjustmentGruoupID(SalaryAdjustmentGroupID);
        return salaryAdjustmentListRules;
    }

    public static HR_SalaryAdjustmentListRules GetSalaryAdjustmentListRulesOnlyByEmployeeID(string employeeID)
    {
        HR_SalaryAdjustmentListRules salaryAdjustmentListRules = new HR_SalaryAdjustmentListRules();
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        salaryAdjustmentListRules = sqlSalaryAdjustmentListRulesProvider.GetSalaryAdjustmentListRulesOnlyByEmployeeID(employeeID);
        return salaryAdjustmentListRules;
    }
    public static HR_SalaryAdjustmentListRules GetHR_SalaryAdjustmentListByEmployeeID(string employeeID)
    {
        HR_SalaryAdjustmentListRules salaryAdjustmentListRules = new HR_SalaryAdjustmentListRules();
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        salaryAdjustmentListRules = sqlSalaryAdjustmentListRulesProvider.GetSalaryAdjustmentListRulesByEmployeeID(employeeID);
        return salaryAdjustmentListRules;
    }


    public static HR_SalaryAdjustmentListRules GetSalaryAdjustmentListRulesBySalaryAdjustmentListRulesID(int SalaryAdjustmentListRulesID)
    {
        HR_SalaryAdjustmentListRules salaryAdjustmentListRules = new HR_SalaryAdjustmentListRules();
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        salaryAdjustmentListRules = sqlSalaryAdjustmentListRulesProvider.GetSalaryAdjustmentListRulesBySalaryAdjustmentListRulesID(SalaryAdjustmentListRulesID);
        return salaryAdjustmentListRules;
    }

    public static bool IsEmployeeExist(string employeeID)
    {
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        return sqlSalaryAdjustmentListRulesProvider.IsEmployeeExist(employeeID);
    }

    public static int InsertSalaryAdjustmentListRules(HR_SalaryAdjustmentListRules salaryAdjustmentListRules)
    {
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        return sqlSalaryAdjustmentListRulesProvider.InsertSalaryAdjustmentListRules(salaryAdjustmentListRules);
    }


    public static bool UpdateSalaryAdjustmentListRules(HR_SalaryAdjustmentListRules salaryAdjustmentListRules)
    {
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        return sqlSalaryAdjustmentListRulesProvider.UpdateSalaryAdjustmentListRules(salaryAdjustmentListRules);
    }

    public static bool DeleteSalaryAdjustmentListRules(int salaryAdjustmentListRulesID)
    {
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        return sqlSalaryAdjustmentListRulesProvider.DeleteSalaryAdjustmentListRules(salaryAdjustmentListRulesID);
    }

    public static bool DeleteSalaryAdjustmentListRulesByEmployeeID(string employeeID)
    {
        SqlHR_SalaryAdjustmentListRulesProvider sqlSalaryAdjustmentListRulesProvider = new SqlHR_SalaryAdjustmentListRulesProvider();
        return sqlSalaryAdjustmentListRulesProvider.DeleteHR_SalaryAdjustmentListRulesByEmployeeID(employeeID);
    }
}

