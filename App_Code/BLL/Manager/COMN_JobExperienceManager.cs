using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_JobExperienceManager
{
	public COMN_JobExperienceManager()
	{
	}

    public static DataSet  GetAllCOMN_JobExperiences()
    {
       DataSet cOMN_JobExperiences = new DataSet();
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        cOMN_JobExperiences = sqlCOMN_JobExperienceProvider.GetAllCOMN_JobExperiences();
        return cOMN_JobExperiences;
    }

	public static void cOMN_JobExperiencesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_JobExperiencePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
		DataSet ds =  sqlCOMN_JobExperienceProvider.GetCOMN_JobExperiencePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_JobExperiencesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_JobExperience()
    {
       DataSet cOMN_JobExperiences = new DataSet();
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        cOMN_JobExperiences = sqlCOMN_JobExperienceProvider.GetDropDownListAllCOMN_JobExperience();
        return cOMN_JobExperiences;
    }


    public static COMN_JobExperience GetCOMN_UserByUserID(string UserID)
    {
        COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience();
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        cOMN_JobExperience = sqlCOMN_JobExperienceProvider.GetCOMN_JobExperienceByUserID(UserID);
        return cOMN_JobExperience;
    }

    public static DataSet GetCOMN_UserByUserID(string UserID,bool isDataset)
    {
        DataSet cOMN_JobExperience = new DataSet();
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        cOMN_JobExperience = sqlCOMN_JobExperienceProvider.GetCOMN_JobExperienceByUserID(UserID,isDataset);
        return cOMN_JobExperience;
    }

   


    public static COMN_JobExperience GetCOMN_DesignationByDesignationID(int DesignationID)
    {
        COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience();
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        cOMN_JobExperience = sqlCOMN_JobExperienceProvider.GetCOMN_JobExperienceByDesignationID(DesignationID);
        return cOMN_JobExperience;
    }


    public static COMN_JobExperience GetCOMN_JobExperienceByJobExperienceID(int JobExperienceID)
    {
        COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience();
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        cOMN_JobExperience = sqlCOMN_JobExperienceProvider.GetCOMN_JobExperienceByJobExperienceID(JobExperienceID);
        return cOMN_JobExperience;
    }


    public static int InsertCOMN_JobExperience(COMN_JobExperience cOMN_JobExperience)
    {
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        return sqlCOMN_JobExperienceProvider.InsertCOMN_JobExperience(cOMN_JobExperience);
    }


    public static bool UpdateCOMN_JobExperience(COMN_JobExperience cOMN_JobExperience)
    {
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        return sqlCOMN_JobExperienceProvider.UpdateCOMN_JobExperience(cOMN_JobExperience);
    }

    public static bool DeleteCOMN_JobExperience(int cOMN_JobExperienceID)
    {
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        return sqlCOMN_JobExperienceProvider.DeleteCOMN_JobExperience(cOMN_JobExperienceID);
    }

    public static bool DeleteCOMN_JobExperienceByUserID(string userID)
    {
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        return sqlCOMN_JobExperienceProvider.DeleteCOMN_JobExperienceByUserID(userID);
    }

    public static List<COMN_JobExperience> GetCOMN_JobExperiencesByUserID(string UserID)
    {
        List<COMN_JobExperience> cOMN_JobExperience = new List<COMN_JobExperience>();
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        cOMN_JobExperience = sqlCOMN_JobExperienceProvider.GetCOMN_JobExperiencesByUserID(UserID);
        return cOMN_JobExperience;
    }

    public static List<COMN_JobExperience> GetCOMN_JobExperiencesByEmpUserID(string UserID)
    {
        List<COMN_JobExperience> cOMN_JobExperience = new List<COMN_JobExperience>();
        SqlCOMN_JobExperienceProvider sqlCOMN_JobExperienceProvider = new SqlCOMN_JobExperienceProvider();
        cOMN_JobExperience = sqlCOMN_JobExperienceProvider.GetCOMN_JobExperiencesByEmpUserID(UserID);
        return cOMN_JobExperience;
    }
}

