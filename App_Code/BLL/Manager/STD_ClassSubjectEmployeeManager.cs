using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassSubjectEmployeeManager
{
	public STD_ClassSubjectEmployeeManager()
	{
	}

    public static DataSet  GetAllSTD_ClassSubjectEmployees()
    {
       DataSet sTD_ClassSubjectEmployees = new DataSet();
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        sTD_ClassSubjectEmployees = sqlSTD_ClassSubjectEmployeeProvider.GetAllSTD_ClassSubjectEmployees();
        return sTD_ClassSubjectEmployees;
    }

	public static void sTD_ClassSubjectEmployeesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassSubjectEmployeePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
		DataSet ds =  sqlSTD_ClassSubjectEmployeeProvider.GetSTD_ClassSubjectEmployeePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassSubjectEmployeesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassSubjectEmployee()
    {
       DataSet sTD_ClassSubjectEmployees = new DataSet();
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        sTD_ClassSubjectEmployees = sqlSTD_ClassSubjectEmployeeProvider.GetDropDownListAllSTD_ClassSubjectEmployee();
        return sTD_ClassSubjectEmployees;
    }


    public static STD_ClassSubjectEmployee GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee();
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        sTD_ClassSubjectEmployee = sqlSTD_ClassSubjectEmployeeProvider.GetSTD_ClassSubjectEmployeeByEmployeeID(EmployeeID);
        return sTD_ClassSubjectEmployee;
    }


    public static STD_ClassSubjectEmployee GetSTD_ClassSubjectByClassSubjectID(int ClassSubjectID)
    {
        STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee();
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        sTD_ClassSubjectEmployee = sqlSTD_ClassSubjectEmployeeProvider.GetSTD_ClassSubjectEmployeeByClassSubjectID(ClassSubjectID);
        return sTD_ClassSubjectEmployee;
    }


    public static DataSet GetSTD_ClassSubjectByClassSubjectID(int ClassSubjectID,bool isDataset)
    {
        DataSet sTD_ClassSubjectEmployee = new DataSet();
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        sTD_ClassSubjectEmployee = sqlSTD_ClassSubjectEmployeeProvider.GetSTD_ClassSubjectEmployeeByClassSubjectID(ClassSubjectID,isDataset);
        return sTD_ClassSubjectEmployee;
    }

    public static STD_ClassSubjectEmployee GetSTD_ClassSubjectEmployeeByClassSubjectEmployeeID(int ClassSubjectEmployeeID)
    {
        STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee();
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        sTD_ClassSubjectEmployee = sqlSTD_ClassSubjectEmployeeProvider.GetSTD_ClassSubjectEmployeeByClassSubjectEmployeeID(ClassSubjectEmployeeID);
        return sTD_ClassSubjectEmployee;
    }


    public static int InsertSTD_ClassSubjectEmployee(STD_ClassSubjectEmployee sTD_ClassSubjectEmployee)
    {
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        return sqlSTD_ClassSubjectEmployeeProvider.InsertSTD_ClassSubjectEmployee(sTD_ClassSubjectEmployee);
    }


    public static bool UpdateSTD_ClassSubjectEmployee(STD_ClassSubjectEmployee sTD_ClassSubjectEmployee)
    {
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        return sqlSTD_ClassSubjectEmployeeProvider.UpdateSTD_ClassSubjectEmployee(sTD_ClassSubjectEmployee);
    }

    public static bool DeleteSTD_ClassSubjectEmployee(int sTD_ClassSubjectEmployeeID)
    {
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        return sqlSTD_ClassSubjectEmployeeProvider.DeleteSTD_ClassSubjectEmployee(sTD_ClassSubjectEmployeeID);
    }

    public static bool DeleteSTD_ClassSubjectEmployeeByClassSubjectID(int ClassSubjectID)
    {
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        return sqlSTD_ClassSubjectEmployeeProvider.DeleteSTD_ClassSubjectEmployeeByClassSubjectID(ClassSubjectID);
    }

    public static bool DeleteSTD_ClassSubjectEmployeeByClassID(int ClassID)
    {
        SqlSTD_ClassSubjectEmployeeProvider sqlSTD_ClassSubjectEmployeeProvider = new SqlSTD_ClassSubjectEmployeeProvider();
        return sqlSTD_ClassSubjectEmployeeProvider.DeleteSTD_ClassSubjectEmployeeByClassID(ClassID);
    }
}

