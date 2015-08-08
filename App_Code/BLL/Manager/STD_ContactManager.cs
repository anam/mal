using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ContactManager
{
	public STD_ContactManager()
	{
	}

    public static DataSet  GetAllSTD_Contacts()
    {
       DataSet sTD_Contacts = new DataSet();
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        sTD_Contacts = sqlSTD_ContactProvider.GetAllSTD_Contacts();
        return sTD_Contacts;
    }

	public static void sTD_ContactsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ContactPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
		DataSet ds =  sqlSTD_ContactProvider.GetSTD_ContactPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ContactsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Contact()
    {
       DataSet sTD_Contacts = new DataSet();
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        sTD_Contacts = sqlSTD_ContactProvider.GetDropDownListAllSTD_Contact();
        return sTD_Contacts;
    }

    public static DataSet   GetAllSTD_ContactsWithRelation()
    {
       DataSet sTD_Contacts = new DataSet();
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        sTD_Contacts = sqlSTD_ContactProvider.GetAllSTD_Contacts();
        return sTD_Contacts;
    }


    public static STD_Contact GetSTDContactByStudentID(string StudentID)
    {
        STD_Contact sTD_Contact = new STD_Contact();
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        sTD_Contact = sqlSTD_ContactProvider.GetSTD_ContactByStudentID(StudentID);
        return sTD_Contact;
    }

    public static DataSet GetSTDContactByStudentID(string StudentID, bool isDataset)
    {
        DataSet sTD_Contact = new DataSet();
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        sTD_Contact = sqlSTD_ContactProvider.GetSTD_ContactByStudentID(StudentID, isDataset);
        return sTD_Contact;
    }

    public static STD_Contact GetSTD_ContactTypeByContactTypeID(int ContactTypeID)
    {
        STD_Contact sTD_Contact = new STD_Contact();
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        sTD_Contact = sqlSTD_ContactProvider.GetSTD_ContactByContactTypeID(ContactTypeID);
        return sTD_Contact;
    }


    public static STD_Contact GetSTD_ContactByContactID(int ContactID)
    {
        STD_Contact sTD_Contact = new STD_Contact();
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        sTD_Contact = sqlSTD_ContactProvider.GetSTD_ContactByContactID(ContactID);
        return sTD_Contact;
    }


    public static int InsertSTD_Contact(STD_Contact sTD_Contact)
    {
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        return sqlSTD_ContactProvider.InsertSTD_Contact(sTD_Contact);
    }


    public static bool UpdateSTD_Contact(STD_Contact sTD_Contact)
    {
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        return sqlSTD_ContactProvider.UpdateSTD_Contact(sTD_Contact);
    }

    public static bool DeleteSTD_Contact(int sTD_ContactID)
    {
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        return sqlSTD_ContactProvider.DeleteSTD_Contact(sTD_ContactID);
    }

    public static bool DeleteSTD_ContactByStudentID(string  studentID)
    {
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        return sqlSTD_ContactProvider.DeleteSTD_ContactByStudentID(studentID);
    }

    public static List<STD_Contact> GetSTD_ContactsByStudentID(string StudentID)
    {
        List<STD_Contact> sTD_Contact = new List<STD_Contact>();
        SqlSTD_ContactProvider sqlSTD_ContactProvider = new SqlSTD_ContactProvider();
        sTD_Contact = sqlSTD_ContactProvider.GetSTD_ContactsByStudentID(StudentID);
        return sTD_Contact;
    }
}

