using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_EmployerTypeManager
{
	public HR_EmployerTypeManager()
	{
	}

    public static DataSet  GetAllHR_EmployerTypes()
    {
       DataSet hR_EmployerTypes = new DataSet();
        SqlHR_EmployerTypeProvider sqlHR_EmployerTypeProvider = new SqlHR_EmployerTypeProvider();
        hR_EmployerTypes = sqlHR_EmployerTypeProvider.GetAllHR_EmployerTypes();
        return hR_EmployerTypes;
    }

	public static void hR_EmployerTypesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_EmployerTypePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_EmployerTypeProvider sqlHR_EmployerTypeProvider = new SqlHR_EmployerTypeProvider();
		DataSet ds =  sqlHR_EmployerTypeProvider.GetHR_EmployerTypePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_EmployerTypesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_EmployerType()
    {
       DataSet hR_EmployerTypes = new DataSet();
        SqlHR_EmployerTypeProvider sqlHR_EmployerTypeProvider = new SqlHR_EmployerTypeProvider();
        hR_EmployerTypes = sqlHR_EmployerTypeProvider.GetDropDownLisAllHR_EmployerType();
        return hR_EmployerTypes;
    }


    public static HR_EmployerType GetHR_EmployerTypeByEmployerType(int EmployerType)
    {
        HR_EmployerType hR_EmployerType = new HR_EmployerType();
        SqlHR_EmployerTypeProvider sqlHR_EmployerTypeProvider = new SqlHR_EmployerTypeProvider();
        hR_EmployerType = sqlHR_EmployerTypeProvider.GetHR_EmployerTypeByEmployerType(EmployerType);
        return hR_EmployerType;
    }


    public static int InsertHR_EmployerType(HR_EmployerType hR_EmployerType)
    {
        SqlHR_EmployerTypeProvider sqlHR_EmployerTypeProvider = new SqlHR_EmployerTypeProvider();
        return sqlHR_EmployerTypeProvider.InsertHR_EmployerType(hR_EmployerType);
    }


    public static bool UpdateHR_EmployerType(HR_EmployerType hR_EmployerType)
    {
        SqlHR_EmployerTypeProvider sqlHR_EmployerTypeProvider = new SqlHR_EmployerTypeProvider();
        return sqlHR_EmployerTypeProvider.UpdateHR_EmployerType(hR_EmployerType);
    }

    public static bool DeleteHR_EmployerType(int hR_EmployerTypeID)
    {
        SqlHR_EmployerTypeProvider sqlHR_EmployerTypeProvider = new SqlHR_EmployerTypeProvider();
        return sqlHR_EmployerTypeProvider.DeleteHR_EmployerType(hR_EmployerTypeID);
    }
}

