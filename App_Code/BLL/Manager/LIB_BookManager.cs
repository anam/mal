using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class LIB_BookManager
{
    public LIB_BookManager()
    {
    }

    public static DataSet GetAllLIB_Books()
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.GetAllLIB_Books();
        return lIB_Books;
    }

    public static DataSet GetLIB_BookBySearchString(string searchSQLString)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.GetLIB_BookBySearchString(searchSQLString);
        return lIB_Books;
    }

    public static void lIB_BooksPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static void LoadLIB_BookPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        DataSet ds = sqlLIB_BookProvider.GetLIB_BookPageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();

        lIB_BooksPaggination(rptPager, recordCount, pageIndex, PageSize);
    }
    //--LoadLIB_BookPageRpt
    public static DataSet LoadLIB_BookPageRpt(string storProcedure)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.LoadLIB_BookPageRpt(storProcedure);
        return lIB_Books;
    }
    //SearchAll_BooksByBookName
    public static DataSet SearchAll_BooksByBookName(string storProcedure, string Bookname, string BookID)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.SearchAll_BooksByBookName(storProcedure, Bookname, BookID);
        return lIB_Books;
    }
    //IssueBook_ByBarcod
    public static DataSet IssueBook_ByBarcod(string storProcedure, string BarCod)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.IssueBook_ByBarcod(storProcedure, BarCod);
        return lIB_Books;
    }
    //ReceiveBook_ByBarcod
    public static DataSet ReceiveBook_ByBarcod(string storProcedure, string BarCod)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.ReceiveBook_ByBarcod(storProcedure, BarCod);
        return lIB_Books;
    }
    //SearchAll_BooksCat_SubCategory
    public static DataSet SearchAll_BooksCat_SubCategory(string storProcedure, int category, int subcategory)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.SearchAll_BooksCat_SubCategory(storProcedure, category, subcategory);
        return lIB_Books;
    }
    public static DataSet LoadLIB_BookPageRpt(string storProcedure, string AuthorID)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.LoadLIB_BookPageRpt(storProcedure, AuthorID);
        return lIB_Books;
    }
    //LoadLIB_BookIssueRptDateWise
    public static DataSet LoadLIB_BookIssueRptDateWise(string storProcedure, string fromDate, string toDate)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.LoadLIB_BookIssueRptDateWise(storProcedure, fromDate, toDate);
        return lIB_Books;
    }
    public static DataSet SearchAll_IssueBooksByBookName(string storProcedure, string BookName, string BookID)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.SearchAll_IssueBooksByBookName(storProcedure, BookName, BookID);
        return lIB_Books;
    }
    //SearchAll_IssueBooksByBookName

    public static DataSet GetDropDownListAllLIB_Book()
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.GetDropDownListAllLIB_Book();
        return lIB_Books;
    }

    public static DataSet GetDropDownListAllLIB_BookByBookID(int BookId)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.GetDropDownListAllLIB_BookBookID(BookId);
        return lIB_Books;
    }
    //GetLIB_ISISSUED
    public static DataSet GetLIB_ISISSUED(int BookId)
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.GetLIB_ISISSUED(BookId);
        return lIB_Books;
    }

    public static DataSet GetAllLIB_BooksWithRelation()
    {
        DataSet lIB_Books = new DataSet();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Books = sqlLIB_BookProvider.GetAllLIB_Books();
        return lIB_Books;
    }


    public static LIB_Book GetSTD_SubjectBySubjectID(int SubjectID)
    {
        LIB_Book lIB_Book = new LIB_Book();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Book = sqlLIB_BookProvider.GetLIB_BookBySubjectID(SubjectID);
        return lIB_Book;
    }

    public static LIB_Book GetLIB_SubCategoryBySubCategoryID(int SubCategoryID)
    {
        LIB_Book lIB_Book = new LIB_Book();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Book = sqlLIB_BookProvider.GetLIB_BookBySubCategoryID(SubCategoryID);
        return lIB_Book;
    }


    public static LIB_Book GetLIB_PublisherByPublisherID(int PublisherID)
    {
        LIB_Book lIB_Book = new LIB_Book();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Book = sqlLIB_BookProvider.GetLIB_BookByPublisherID(PublisherID);
        return lIB_Book;
    }


    public static LIB_Book GetLIB_AuthorByAuthorID(int AuthorID)
    {
        LIB_Book lIB_Book = new LIB_Book();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Book = sqlLIB_BookProvider.GetLIB_BookByAuthorID(AuthorID);
        return lIB_Book;
    }


    public static LIB_Book GetLIB_BookByBookID(int BookID)
    {
        LIB_Book lIB_Book = new LIB_Book();
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        lIB_Book = sqlLIB_BookProvider.GetLIB_BookByBookID(BookID);
        return lIB_Book;
    }

    //public static DataSet GetLIB_BookByBookID(int BookID)
    //{
    //    DataSet lIB_Books = new DataSet();
    //    SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
    //    lIB_Books = sqlLIB_BookProvider.GetLIB_BookByBookID(BookID);
    //    return lIB_Books;
    //}


    public static int InsertLIB_Book(LIB_Book lIB_Book)
    {
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        return sqlLIB_BookProvider.InsertLIB_Book(lIB_Book);
    }


    public static bool UpdateLIB_Book(LIB_Book lIB_Book)
    {
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        return sqlLIB_BookProvider.UpdateLIB_Book(lIB_Book);
    }

    public static bool DeleteLIB_Book(int lIB_BookID)
    {
        SqlLIB_BookProvider sqlLIB_BookProvider = new SqlLIB_BookProvider();
        return sqlLIB_BookProvider.DeleteLIB_Book(lIB_BookID);
    }
}

