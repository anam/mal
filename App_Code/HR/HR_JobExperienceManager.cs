using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_JobExperienceManager
{
	public HR_JobExperienceManager()
	{
	}

    public static DataSet  GetAllHR_JobExperiences()
    {
       DataSet hR_JobExperiences = new DataSet();
        SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
        hR_JobExperiences = sqlHR_JobExperienceProvider.GetAllHR_JobExperiences();
        return hR_JobExperiences;
    }

	public static void hR_JobExperiencesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_JobExperiencePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
		DataSet ds =  sqlHR_JobExperienceProvider.GetHR_JobExperiencePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_JobExperiencesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_JobExperience()
    {
       DataSet hR_JobExperiences = new DataSet();
        SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
        hR_JobExperiences = sqlHR_JobExperienceProvider.GetDropDownLisAllHR_JobExperience();
        return hR_JobExperiences;
    }

    public static DataSet   GetAllHR_JobExperiencesWithRelation()
    {
       DataSet hR_JobExperiences = new DataSet();
        SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
        hR_JobExperiences = sqlHR_JobExperienceProvider.GetAllHR_JobExperiences();
        return hR_JobExperiences;
    }
   
    //


    public static DataSet GetHR_JobExperienceByEmployeeID(string employerID)
    {
        DataSet hR_JobExperiences = new DataSet();
        SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
        hR_JobExperiences = sqlHR_JobExperienceProvider.GetHR_JobExperienceByEmployeeID(employerID);
        return hR_JobExperiences;
    }

    //public static HR_JobExperience GetHR_EmployeeByEmployeeID(string EmployeeID)
    //{
    //    HR_JobExperience hR_JobExperience = new HR_JobExperience();
    //    SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
    //    hR_JobExperience = sqlHR_JobExperienceProvider.GetHR_JobExperienceByEmployeeID(EmployeeID);
    //    return hR_JobExperience;
    //}


    public static HR_JobExperience GetHR_JobExperienceByJobExperienceID(int JobExperienceID)
    {
        HR_JobExperience hR_JobExperience = new HR_JobExperience();
        SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
        hR_JobExperience = sqlHR_JobExperienceProvider.GetHR_JobExperienceByJobExperienceID(JobExperienceID);
        return hR_JobExperience;
    }


    public static int InsertHR_JobExperience(HR_JobExperience hR_JobExperience)
    {
        SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
        return sqlHR_JobExperienceProvider.InsertHR_JobExperience(hR_JobExperience);
    }


    public static bool UpdateHR_JobExperience(HR_JobExperience hR_JobExperience)
    {
        SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
        return sqlHR_JobExperienceProvider.UpdateHR_JobExperience(hR_JobExperience);
    }

    public static bool DeleteHR_JobExperience(int hR_JobExperienceID)
    {
        SqlHR_JobExperienceProvider sqlHR_JobExperienceProvider = new SqlHR_JobExperienceProvider();
        return sqlHR_JobExperienceProvider.DeleteHR_JobExperience(hR_JobExperienceID);
    }
}

