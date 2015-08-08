using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_StudentContactManager
{
	public STD_StudentContactManager()
	{
	}

    public static DataSet  GetAllSTD_StudentContacts()
    {
       DataSet sTD_StudentContacts = new DataSet();
        SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
        sTD_StudentContacts = sqlSTD_StudentContactProvider.GetAllSTD_StudentContacts();
        return sTD_StudentContacts;
    }

	public static void sTD_StudentContactsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_StudentContactPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
		DataSet ds =  sqlSTD_StudentContactProvider.GetSTD_StudentContactPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_StudentContactsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_StudentContact()
    {
       DataSet sTD_StudentContacts = new DataSet();
        SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
        sTD_StudentContacts = sqlSTD_StudentContactProvider.GetDropDownListAllSTD_StudentContact();
        return sTD_StudentContacts;
    }

    public static DataSet   GetAllSTD_StudentContactsWithRelation()
    {
       DataSet sTD_StudentContacts = new DataSet();
        SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
        sTD_StudentContacts = sqlSTD_StudentContactProvider.GetAllSTD_StudentContacts();
        return sTD_StudentContacts;
    }


    public static STD_StudentContact GetSTD_SudentBySudentID(string SudentID)
    {
        STD_StudentContact sTD_StudentContact = new STD_StudentContact();
        SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
        sTD_StudentContact = sqlSTD_StudentContactProvider.GetSTD_StudentContactBySudentID(SudentID);
        return sTD_StudentContact;
    }


    public static STD_StudentContact GetSTD_ContactByContactID(int ContactID)
    {
        STD_StudentContact sTD_StudentContact = new STD_StudentContact();
        SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
        sTD_StudentContact = sqlSTD_StudentContactProvider.GetSTD_StudentContactByContactID(ContactID);
        return sTD_StudentContact;
    }


    public static STD_StudentContact GetSTD_StudentContactByStudentContactID(int StudentContactID)
    {
        STD_StudentContact sTD_StudentContact = new STD_StudentContact();
        SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
        sTD_StudentContact = sqlSTD_StudentContactProvider.GetSTD_StudentContactByStudentContactID(StudentContactID);
        return sTD_StudentContact;
    }


    public static int InsertSTD_StudentContact(STD_StudentContact sTD_StudentContact)
    {
        SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
        return sqlSTD_StudentContactProvider.InsertSTD_StudentContact(sTD_StudentContact);
    }


    public static bool UpdateSTD_StudentContact(STD_StudentContact sTD_StudentContact)
    {
        SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
        return sqlSTD_StudentContactProvider.UpdateSTD_StudentContact(sTD_StudentContact);
    }

    public static bool DeleteSTD_StudentContact(int sTD_StudentContactID)
    {
        SqlSTD_StudentContactProvider sqlSTD_StudentContactProvider = new SqlSTD_StudentContactProvider();
        return sqlSTD_StudentContactProvider.DeleteSTD_StudentContact(sTD_StudentContactID);
    }
}

