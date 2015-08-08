using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_JobPostingManager
{
	public HR_JobPostingManager()
	{
	}

    public static DataSet  GetAllHR_JobPostings()
    {
       DataSet hR_JobPostings = new DataSet();
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        hR_JobPostings = sqlHR_JobPostingProvider.GetAllHR_JobPostings();
        return hR_JobPostings;
    }
    public static DataSet GetHR_JobPostingByEmployeeID(string EmployeeID)
    {
        DataSet hR_JobPostings = new DataSet();
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        hR_JobPostings = sqlHR_JobPostingProvider.GetHR_JobPostingByEmployeeID(EmployeeID);
        return hR_JobPostings;
    }

    //

	public static void hR_JobPostingsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_JobPostingPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
		DataSet ds =  sqlHR_JobPostingProvider.GetHR_JobPostingPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_JobPostingsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_JobPosting()
    {
       DataSet hR_JobPostings = new DataSet();
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        hR_JobPostings = sqlHR_JobPostingProvider.GetDropDownLisAllHR_JobPosting();
        return hR_JobPostings;
    }

    public static DataSet   GetAllHR_JobPostingsWithRelation()
    {
       DataSet hR_JobPostings = new DataSet();
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        hR_JobPostings = sqlHR_JobPostingProvider.GetAllHR_JobPostings();
        return hR_JobPostings;
    }

 

    public static HR_JobPosting GetHR_DepartmentByDepartmentID(int DepartmentID)
    {
        HR_JobPosting hR_JobPosting = new HR_JobPosting();
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        hR_JobPosting = sqlHR_JobPostingProvider.GetHR_JobPostingByDepartmentID(DepartmentID);
        return hR_JobPosting;
    }


    public static HR_JobPosting GetHR_DesignationByDesignationID(int DesignationID)
    {
        HR_JobPosting hR_JobPosting = new HR_JobPosting();
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        hR_JobPosting = sqlHR_JobPostingProvider.GetHR_JobPostingByDesignationID(DesignationID);
        return hR_JobPosting;
    }


    public static HR_JobPosting GetHR_SupervisorBySupervisorID(string SupervisorID)
    {
        HR_JobPosting hR_JobPosting = new HR_JobPosting();
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        hR_JobPosting = sqlHR_JobPostingProvider.GetHR_JobPostingBySupervisorID(SupervisorID);
        return hR_JobPosting;
    }


    public static HR_JobPosting GetHR_JobPostingByJobPostingID(int JobPostingID)
    {
        HR_JobPosting hR_JobPosting = new HR_JobPosting();
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        hR_JobPosting = sqlHR_JobPostingProvider.GetHR_JobPostingByJobPostingID(JobPostingID);
        return hR_JobPosting;
    }


    public static int InsertHR_JobPosting(HR_JobPosting hR_JobPosting)
    {
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        return sqlHR_JobPostingProvider.InsertHR_JobPosting(hR_JobPosting);
    }


    public static bool UpdateHR_JobPosting(HR_JobPosting hR_JobPosting)
    {
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        return sqlHR_JobPostingProvider.UpdateHR_JobPosting(hR_JobPosting);
    }

    public static bool DeleteHR_JobPosting(int hR_JobPostingID)
    {
        SqlHR_JobPostingProvider sqlHR_JobPostingProvider = new SqlHR_JobPostingProvider();
        return sqlHR_JobPostingProvider.DeleteHR_JobPosting(hR_JobPostingID);
    }
}

