using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_RoutineManager
{
	public STD_RoutineManager()
	{
	}

    public static DataSet  GetAllSTD_Routines()
    {
       DataSet sTD_Routines = new DataSet();
        SqlSTD_RoutineProvider sqlSTD_RoutineProvider = new SqlSTD_RoutineProvider();
        sTD_Routines = sqlSTD_RoutineProvider.GetAllSTD_Routines();
        return sTD_Routines;
    }

	public static void sTD_RoutinesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_RoutinePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_RoutineProvider sqlSTD_RoutineProvider = new SqlSTD_RoutineProvider();
		DataSet ds =  sqlSTD_RoutineProvider.GetSTD_RoutinePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_RoutinesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Routine()
    {
       DataSet sTD_Routines = new DataSet();
        SqlSTD_RoutineProvider sqlSTD_RoutineProvider = new SqlSTD_RoutineProvider();
        sTD_Routines = sqlSTD_RoutineProvider.GetDropDownListAllSTD_Routine();
        return sTD_Routines;
    }


    public static STD_Routine GetSTD_RoutineByRoutineID(int RoutineID)
    {
        STD_Routine sTD_Routine = new STD_Routine();
        SqlSTD_RoutineProvider sqlSTD_RoutineProvider = new SqlSTD_RoutineProvider();
        sTD_Routine = sqlSTD_RoutineProvider.GetSTD_RoutineByRoutineID(RoutineID);
        return sTD_Routine;
    }


    public static int InsertSTD_Routine(STD_Routine sTD_Routine)
    {
        SqlSTD_RoutineProvider sqlSTD_RoutineProvider = new SqlSTD_RoutineProvider();
        return sqlSTD_RoutineProvider.InsertSTD_Routine(sTD_Routine);
    }


    public static bool UpdateSTD_Routine(STD_Routine sTD_Routine)
    {
        SqlSTD_RoutineProvider sqlSTD_RoutineProvider = new SqlSTD_RoutineProvider();
        return sqlSTD_RoutineProvider.UpdateSTD_Routine(sTD_Routine);
    }

    public static bool DeleteSTD_Routine(int sTD_RoutineID)
    {
        SqlSTD_RoutineProvider sqlSTD_RoutineProvider = new SqlSTD_RoutineProvider();
        return sqlSTD_RoutineProvider.DeleteSTD_Routine(sTD_RoutineID);
    }
}

