using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_QuestionTypeManager
{
	public STD_QuestionTypeManager()
	{
	}

    public static DataSet  GetAllSTD_QuestionTypes()
    {
       DataSet sTD_QuestionTypes = new DataSet();
        SqlSTD_QuestionTypeProvider sqlSTD_QuestionTypeProvider = new SqlSTD_QuestionTypeProvider();
        sTD_QuestionTypes = sqlSTD_QuestionTypeProvider.GetAllSTD_QuestionTypes();
        return sTD_QuestionTypes;
    }

	public static void sTD_QuestionTypesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_QuestionTypePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_QuestionTypeProvider sqlSTD_QuestionTypeProvider = new SqlSTD_QuestionTypeProvider();
		DataSet ds =  sqlSTD_QuestionTypeProvider.GetSTD_QuestionTypePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_QuestionTypesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_QuestionType()
    {
       DataSet sTD_QuestionTypes = new DataSet();
        SqlSTD_QuestionTypeProvider sqlSTD_QuestionTypeProvider = new SqlSTD_QuestionTypeProvider();
        sTD_QuestionTypes = sqlSTD_QuestionTypeProvider.GetDropDownListAllSTD_QuestionType();
        return sTD_QuestionTypes;
    }


    public static STD_QuestionType GetSTD_QuestionTypeByQuestionTypeID(int QuestionTypeID)
    {
        STD_QuestionType sTD_QuestionType = new STD_QuestionType();
        SqlSTD_QuestionTypeProvider sqlSTD_QuestionTypeProvider = new SqlSTD_QuestionTypeProvider();
        sTD_QuestionType = sqlSTD_QuestionTypeProvider.GetSTD_QuestionTypeByQuestionTypeID(QuestionTypeID);
        return sTD_QuestionType;
    }


    public static int InsertSTD_QuestionType(STD_QuestionType sTD_QuestionType)
    {
        SqlSTD_QuestionTypeProvider sqlSTD_QuestionTypeProvider = new SqlSTD_QuestionTypeProvider();
        return sqlSTD_QuestionTypeProvider.InsertSTD_QuestionType(sTD_QuestionType);
    }


    public static bool UpdateSTD_QuestionType(STD_QuestionType sTD_QuestionType)
    {
        SqlSTD_QuestionTypeProvider sqlSTD_QuestionTypeProvider = new SqlSTD_QuestionTypeProvider();
        return sqlSTD_QuestionTypeProvider.UpdateSTD_QuestionType(sTD_QuestionType);
    }

    public static bool DeleteSTD_QuestionType(int sTD_QuestionTypeID)
    {
        SqlSTD_QuestionTypeProvider sqlSTD_QuestionTypeProvider = new SqlSTD_QuestionTypeProvider();
        return sqlSTD_QuestionTypeProvider.DeleteSTD_QuestionType(sTD_QuestionTypeID);
    }
}

