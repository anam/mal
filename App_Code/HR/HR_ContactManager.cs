using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_ContactManager
{
	public HR_ContactManager()
	{
	}

    public static DataSet  GetAllHR_Contacts()
    {
       DataSet hR_Contacts = new DataSet();
        SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
        hR_Contacts = sqlHR_ContactProvider.GetAllHR_Contacts();
        return hR_Contacts;
    }

	public static void hR_ContactsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_ContactPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
		DataSet ds =  sqlHR_ContactProvider.GetHR_ContactPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_ContactsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_Contact()
    {
       DataSet hR_Contacts = new DataSet();
        SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
        hR_Contacts = sqlHR_ContactProvider.GetDropDownLisAllHR_Contact();
        return hR_Contacts;
    }

    public static DataSet   GetAllHR_ContactsWithRelation()
    {
       DataSet hR_Contacts = new DataSet();
        SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
        hR_Contacts = sqlHR_ContactProvider.GetAllHR_Contacts();
        return hR_Contacts;
    }


    public static DataSet GetHR_ContactByEmployeeID(string EmployeeID)
    {
        DataSet hR_Contacts = new DataSet();
        SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
        hR_Contacts = sqlHR_ContactProvider.GetHR_ContactByEmployeeID(EmployeeID);
        return hR_Contacts;
    }


    public static HR_Contact GetHR_ContactByContactID(int ContactID)
    {
        HR_Contact hR_Contact = new HR_Contact();
        SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
        hR_Contact = sqlHR_ContactProvider.GetHR_ContactByContactID(ContactID);
        return hR_Contact;
    }

    public static HR_Contact GetHR_ContactObjectByEmployeeID(string EmployeeID)
    {
        HR_Contact hR_Contact = new HR_Contact();
        SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
        hR_Contact = sqlHR_ContactProvider.GetHR_ContactObjectByEmployeeID(EmployeeID);
        return hR_Contact;
    }


    public static int InsertHR_Contact(HR_Contact hR_Contact)
    {
        SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
        return sqlHR_ContactProvider.InsertHR_Contact(hR_Contact);
    }


    public static bool UpdateHR_Contact(HR_Contact hR_Contact)
    {
        SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
        return sqlHR_ContactProvider.UpdateHR_Contact(hR_Contact);
    }

    public static bool DeleteHR_Contact(int hR_ContactID)
    {
        SqlHR_ContactProvider sqlHR_ContactProvider = new SqlHR_ContactProvider();
        return sqlHR_ContactProvider.DeleteHR_Contact(hR_ContactID);
    }
}

