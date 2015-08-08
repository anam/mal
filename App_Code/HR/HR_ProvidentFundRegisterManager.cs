using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ProvidentFundRegisterManager
{
	public HR_ProvidentFundRegisterManager()
	{
	}

    public static DataSet  GetAllHR_ProvidentFundRegisters()
    {
       DataSet hR_ProvidentFundRegisters = new DataSet();
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        hR_ProvidentFundRegisters = sqlHR_ProvidentFundRegisterProvider.GetAllHR_ProvidentFundRegisters();
        return hR_ProvidentFundRegisters;
    }

	public static void hR_ProvidentFundRegistersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_ProvidentFundRegisterPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
		DataSet ds =  sqlHR_ProvidentFundRegisterProvider.GetHR_ProvidentFundRegisterPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_ProvidentFundRegistersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_ProvidentFundRegister()
    {
       DataSet hR_ProvidentFundRegisters = new DataSet();
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        hR_ProvidentFundRegisters = sqlHR_ProvidentFundRegisterProvider.GetDropDownLisAllHR_ProvidentFundRegister();
        return hR_ProvidentFundRegisters;
    }


    public static HR_ProvidentFundRegister GetHR_ProvidentFundRegisterByEmployeeID(string EmployeeID)
    {
        HR_ProvidentFundRegister hR_ProvidentFundRegister = new HR_ProvidentFundRegister();
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        hR_ProvidentFundRegister = sqlHR_ProvidentFundRegisterProvider.GetHR_ProvidentFundRegisterByEmployeeID(EmployeeID);
        return hR_ProvidentFundRegister;
    }

    public static DataSet GetHR_PFRegisterByEmpIDTotalFund(string EmployeeID)
    {
        DataSet hR_ProvidentFundRegisterTotalFund = new DataSet();
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        hR_ProvidentFundRegisterTotalFund = sqlHR_ProvidentFundRegisterProvider.GetHR_PFRegisterByEmpIDTotalFund(EmployeeID);
        return hR_ProvidentFundRegisterTotalFund;
    }

    public static HR_ProvidentFundRegister GetHR_RowStatusByRowStatusID(int RowStatusID)
    {
        HR_ProvidentFundRegister hR_ProvidentFundRegister = new HR_ProvidentFundRegister();
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        hR_ProvidentFundRegister = sqlHR_ProvidentFundRegisterProvider.GetHR_ProvidentFundRegisterByRowStatusID(RowStatusID);
        return hR_ProvidentFundRegister;
    }


    public static HR_ProvidentFundRegister GetHR_ProvidentFundRegisterByProvidentFundRegisterID(int ProvidentFundRegisterID)
    {
        HR_ProvidentFundRegister hR_ProvidentFundRegister = new HR_ProvidentFundRegister();
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        hR_ProvidentFundRegister = sqlHR_ProvidentFundRegisterProvider.GetHR_ProvidentFundRegisterByProvidentFundRegisterID(ProvidentFundRegisterID);
        return hR_ProvidentFundRegister;
    }


    public static int InsertHR_ProvidentFundRegister(HR_ProvidentFundRegister hR_ProvidentFundRegister)
    {
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        return sqlHR_ProvidentFundRegisterProvider.InsertHR_ProvidentFundRegister(hR_ProvidentFundRegister);
    }

    public static int InsertHR_ProvidentFundRegisterWithdrawAmount(HR_ProvidentFundRegister hR_ProvidentFundRegister)
    {
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        return sqlHR_ProvidentFundRegisterProvider.InsertHR_ProvidentFundRegisterWithdrawAmount(hR_ProvidentFundRegister);
    }

    public static bool InsertHR_ProvidentFundRegister(List<HR_ProvidentFundRegister> providentFundRegisterColl)
    {
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        return sqlHR_ProvidentFundRegisterProvider.InsertHR_ProvidentFundRegister(providentFundRegisterColl);
    }

    public static bool UpdateHR_ProvidentFundRegister(HR_ProvidentFundRegister hR_ProvidentFundRegister)
    {
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        return sqlHR_ProvidentFundRegisterProvider.UpdateHR_ProvidentFundRegister(hR_ProvidentFundRegister);
    }

    public static bool DeleteHR_ProvidentFundRegister(int hR_ProvidentFundRegisterID)
    {
        SqlHR_ProvidentFundRegisterProvider sqlHR_ProvidentFundRegisterProvider = new SqlHR_ProvidentFundRegisterProvider();
        return sqlHR_ProvidentFundRegisterProvider.DeleteHR_ProvidentFundRegister(hR_ProvidentFundRegisterID);
    }
}

