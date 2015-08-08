using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_DesignationManager
{
	public HR_DesignationManager()
	{
	}

    public static DataSet  GetAllHR_Designations()
    {
       DataSet hR_Designations = new DataSet();
        SqlHR_DesignationProvider sqlHR_DesignationProvider = new SqlHR_DesignationProvider();
        hR_Designations = sqlHR_DesignationProvider.GetAllHR_Designations();
        return hR_Designations;
    }

	public static void hR_DesignationsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_DesignationPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_DesignationProvider sqlHR_DesignationProvider = new SqlHR_DesignationProvider();
		DataSet ds =  sqlHR_DesignationProvider.GetHR_DesignationPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_DesignationsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Designation()
    {
       DataSet hR_Designations = new DataSet();
        SqlHR_DesignationProvider sqlHR_DesignationProvider = new SqlHR_DesignationProvider();
        hR_Designations = sqlHR_DesignationProvider.GetDropDownLisAllHR_Designation();
        return hR_Designations;
    }

    public static DataSet   GetAllHR_DesignationsWithRelation()
    {
       DataSet hR_Designations = new DataSet();
        SqlHR_DesignationProvider sqlHR_DesignationProvider = new SqlHR_DesignationProvider();
        hR_Designations = sqlHR_DesignationProvider.GetAllHR_Designations();
        return hR_Designations;
    }


    public static DataSet GetHR_DesignationByDepartmentID(int DepartmentID)
    {
        DataSet hR_Designations = new DataSet();
        SqlHR_DesignationProvider sqlHR_DesignationProvider = new SqlHR_DesignationProvider();
        hR_Designations = sqlHR_DesignationProvider.GetHR_DesignationByDepartmentID(DepartmentID);
        return hR_Designations;
    }


    public static HR_Designation GetHR_DesignationByDesignationID(int DesignationID)
    {
        HR_Designation hR_Designation = new HR_Designation();
        SqlHR_DesignationProvider sqlHR_DesignationProvider = new SqlHR_DesignationProvider();
        hR_Designation = sqlHR_DesignationProvider.GetHR_DesignationByDesignationID(DesignationID);
        return hR_Designation;
    }


    public static int InsertHR_Designation(HR_Designation hR_Designation)
    {
        SqlHR_DesignationProvider sqlHR_DesignationProvider = new SqlHR_DesignationProvider();
        return sqlHR_DesignationProvider.InsertHR_Designation(hR_Designation);
    }


    public static bool UpdateHR_Designation(HR_Designation hR_Designation)
    {
        SqlHR_DesignationProvider sqlHR_DesignationProvider = new SqlHR_DesignationProvider();
        return sqlHR_DesignationProvider.UpdateHR_Designation(hR_Designation);
    }

    public static bool DeleteHR_Designation(int hR_DesignationID)
    {
        SqlHR_DesignationProvider sqlHR_DesignationProvider = new SqlHR_DesignationProvider();
        return sqlHR_DesignationProvider.DeleteHR_Designation(hR_DesignationID);
    }
}

