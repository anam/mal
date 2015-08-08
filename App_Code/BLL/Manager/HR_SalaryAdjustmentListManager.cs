using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_SalaryAdjustmentListManager
{
    public HR_SalaryAdjustmentListManager()
    {
    }

    public static DataSet GetAllSalaryAdjustmentLists()
    {
        DataSet salaryAdjustmentLists = new DataSet();
        SqlHR_SalaryAdjustmentListProvider sqlSalaryAdjustmentListProvider = new SqlHR_SalaryAdjustmentListProvider();
        salaryAdjustmentLists = sqlSalaryAdjustmentListProvider.GetAllSalaryAdjustmentLists();
        return salaryAdjustmentLists;
    }

    public static void salaryAdjustmentListsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static void LoadSalaryAdjustmentListPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlHR_SalaryAdjustmentListProvider sqlSalaryAdjustmentListProvider = new SqlHR_SalaryAdjustmentListProvider();
        DataSet ds = sqlSalaryAdjustmentListProvider.GetSalaryAdjustmentListPageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        salaryAdjustmentListsPaggination(rptPager, recordCount, pageIndex, PageSize);
    }
    public static DataSet GetDropDownListAllSalaryAdjustmentList()
    {
        DataSet salaryAdjustmentLists = new DataSet();
        SqlHR_SalaryAdjustmentListProvider sqlSalaryAdjustmentListProvider = new SqlHR_SalaryAdjustmentListProvider();
        salaryAdjustmentLists = sqlSalaryAdjustmentListProvider.GetDropDownLisAllSalaryAdjustmentList();
        return salaryAdjustmentLists;
    }


    public static DataSet GetSalaryAdjustmentListBySalaryAdjustmenGroupID(int salaryAdjustmenGroupID)
    {
        DataSet salaryAdjustmentLists = new DataSet();
        SqlHR_SalaryAdjustmentListProvider sqlSalaryAdjustmentListProvider = new SqlHR_SalaryAdjustmentListProvider();
        salaryAdjustmentLists = sqlSalaryAdjustmentListProvider.GetSalaryAdjustmentListBySalaryAdjustmentGroupID(salaryAdjustmenGroupID);
        return salaryAdjustmentLists;
    }


    public static HR_SalaryAdjustmentList GetSalaryAdjustmentListBySalaryAdjustmentListID(int SalaryAdjustmentListID)
    {
        HR_SalaryAdjustmentList salaryAdjustmentList = new HR_SalaryAdjustmentList();
        SqlHR_SalaryAdjustmentListProvider sqlSalaryAdjustmentListProvider = new SqlHR_SalaryAdjustmentListProvider();
        salaryAdjustmentList = sqlSalaryAdjustmentListProvider.GetSalaryAdjustmentListBySalaryAdjustmentListID(SalaryAdjustmentListID);
        return salaryAdjustmentList;
    }


    public static int InsertSalaryAdjustmentList(HR_SalaryAdjustmentList salaryAdjustmentList)
    {
        SqlHR_SalaryAdjustmentListProvider sqlSalaryAdjustmentListProvider = new SqlHR_SalaryAdjustmentListProvider();
        return sqlSalaryAdjustmentListProvider.InsertSalaryAdjustmentList(salaryAdjustmentList);
    }


    public static bool UpdateSalaryAdjustmentList(HR_SalaryAdjustmentList salaryAdjustmentList)
    {
        SqlHR_SalaryAdjustmentListProvider sqlSalaryAdjustmentListProvider = new SqlHR_SalaryAdjustmentListProvider();
        return sqlSalaryAdjustmentListProvider.UpdateSalaryAdjustmentList(salaryAdjustmentList);
    }

    public static bool DeleteSalaryAdjustmentList(int salaryAdjustmentListID)
    {
        SqlHR_SalaryAdjustmentListProvider sqlSalaryAdjustmentListProvider = new SqlHR_SalaryAdjustmentListProvider();
        return sqlSalaryAdjustmentListProvider.DeleteSalaryAdjustmentList(salaryAdjustmentListID);
    }
}

