using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ProvidentfundAmountManager
{
    public HR_ProvidentfundAmountManager()
    {
    }

    public static DataSet GetAllHR_ProvidentfundAmounts()
    {
        DataSet hR_ProvidentfundAmounts = new DataSet();
        SqlHR_ProvidentfundAmountProvider sqlHR_ProvidentfundAmountProvider = new SqlHR_ProvidentfundAmountProvider();
        hR_ProvidentfundAmounts = sqlHR_ProvidentfundAmountProvider.GetAllHR_ProvidentfundAmounts();
        return hR_ProvidentfundAmounts;
    }

    public static void hR_ProvidentfundAmountsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static void LoadHR_ProvidentfundAmountPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlHR_ProvidentfundAmountProvider sqlHR_ProvidentfundAmountProvider = new SqlHR_ProvidentfundAmountProvider();
        DataSet ds = sqlHR_ProvidentfundAmountProvider.GetHR_ProvidentfundAmountPageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        hR_ProvidentfundAmountsPaggination(rptPager, recordCount, pageIndex, PageSize);
    }
    public static DataSet GetDropDownListAllHR_ProvidentfundAmount()
    {
        DataSet hR_ProvidentfundAmounts = new DataSet();
        SqlHR_ProvidentfundAmountProvider sqlHR_ProvidentfundAmountProvider = new SqlHR_ProvidentfundAmountProvider();
        hR_ProvidentfundAmounts = sqlHR_ProvidentfundAmountProvider.GetDropDownLisAllHR_ProvidentfundAmount();
        return hR_ProvidentfundAmounts;
    }


    public static HR_ProvidentfundAmount GetHR_ProvidentfundAmountByByEmployeeID(string EmployeeID)
    {
        HR_ProvidentfundAmount hR_ProvidentfundAmount = new HR_ProvidentfundAmount();
        SqlHR_ProvidentfundAmountProvider sqlHR_ProvidentfundAmountProvider = new SqlHR_ProvidentfundAmountProvider();
        hR_ProvidentfundAmount = sqlHR_ProvidentfundAmountProvider.GetHR_ProvidentfundAmountByEmployeeID(EmployeeID);
        return hR_ProvidentfundAmount;
    }


    public static HR_ProvidentfundAmount GetHR_ProvidentfundAmountByProvidentfundAmountID(int ProvidentfundAmountID)
    {
        HR_ProvidentfundAmount hR_ProvidentfundAmount = new HR_ProvidentfundAmount();
        SqlHR_ProvidentfundAmountProvider sqlHR_ProvidentfundAmountProvider = new SqlHR_ProvidentfundAmountProvider();
        hR_ProvidentfundAmount = sqlHR_ProvidentfundAmountProvider.GetHR_ProvidentfundAmountByProvidentfundAmountID(ProvidentfundAmountID);
        return hR_ProvidentfundAmount;
    }


    public static int InsertHR_ProvidentfundAmount(HR_ProvidentfundAmount hR_ProvidentfundAmount)
    {
        SqlHR_ProvidentfundAmountProvider sqlHR_ProvidentfundAmountProvider = new SqlHR_ProvidentfundAmountProvider();
        return sqlHR_ProvidentfundAmountProvider.InsertHR_ProvidentfundAmount(hR_ProvidentfundAmount);
    }


    public static bool UpdateHR_ProvidentfundAmount(HR_ProvidentfundAmount hR_ProvidentfundAmount)
    {
        SqlHR_ProvidentfundAmountProvider sqlHR_ProvidentfundAmountProvider = new SqlHR_ProvidentfundAmountProvider();
        return sqlHR_ProvidentfundAmountProvider.UpdateHR_ProvidentfundAmount(hR_ProvidentfundAmount);
    }

    public static bool DeleteHR_ProvidentfundAmount(int hR_ProvidentfundAmountID)
    {
        SqlHR_ProvidentfundAmountProvider sqlHR_ProvidentfundAmountProvider = new SqlHR_ProvidentfundAmountProvider();
        return sqlHR_ProvidentfundAmountProvider.DeleteHR_ProvidentfundAmount(hR_ProvidentfundAmountID);
    }
}

