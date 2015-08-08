using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLIB_BookProvider : DataAccessObject
{
    public SqlLIB_BookProvider()
    {
    }


    public DataSet GetAllLIB_Books()
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_Books", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }

    public DataSet GetLIB_BookPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetLIB_BookPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
                command.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                command.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                recordCount = Convert.ToInt32(command.Parameters["@RecordCount"].Value);
                return ds;
            }
        }
    }

    
    public DataSet GetLIB_BookBySearchString(string searchSQLString)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetLIB_BookBySearchString", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@searchSQLString", SqlDbType.NVarChar).Value = searchSQLString;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public LIB_Book GetLIB_BookBySubjectID(int subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_BookBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetLIB_BookFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public LIB_Book GetLIB_BookBySubCategoryID(int subCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_BookBySubCategoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubCategoryID", SqlDbType.NVarChar).Value = subCategoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetLIB_BookFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public LIB_Book GetLIB_BookByPublisherID(int publisherID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_BookByPublisherID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PublisherID", SqlDbType.NVarChar).Value = publisherID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetLIB_BookFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public LIB_Book GetLIB_BookByAuthorID(int authorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_BookByAuthorID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AuthorID", SqlDbType.NVarChar).Value = authorID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetLIB_BookFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }
    //----LoadLIB_BookPageRpt(string storProcedure,string AuthorID)

    public DataSet LoadLIB_BookPageRpt(string storProcedure)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(storProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }


    public DataSet LoadLIB_BookPageRpt(string storProcedure, string AuthorID)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(storProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AuthorID", SqlDbType.Int).Value = Convert.ToInt32(AuthorID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }
    //SearchAll_BooksByBookName
    public DataSet SearchAll_BooksByBookName(string storProcedure, string BookName, string BookID)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(storProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = BookName;
            command.Parameters.Add("@BookID", SqlDbType.Int).Value = Convert.ToInt32(BookID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }
    //IssueBook_ByBarcod
    public DataSet IssueBook_ByBarcod(string storProcedure, string Barcod)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(storProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Barcod", SqlDbType.Int).Value = Convert.ToInt32(Barcod);
            //command.Parameters.Add("@BookID", SqlDbType.Int).Value = Convert.ToInt32(BookID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }
    //ReceiveBook_ByBarcod
    public DataSet ReceiveBook_ByBarcod(string storProcedure, string Barcod)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(storProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Barcod", SqlDbType.Int).Value = Convert.ToInt32(Barcod);
            //command.Parameters.Add("@BookID", SqlDbType.Int).Value = Convert.ToInt32(BookID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }
    //SearchAll_BooksCat_SubCategory
    public DataSet SearchAll_BooksCat_SubCategory(string storProcedure, int category, int subcategory)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(storProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Category", SqlDbType.Int).Value = category;
            command.Parameters.Add("@Subcategory", SqlDbType.Int).Value = subcategory;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }
    //LoadLIB_BookIssueRptDateWise
    public DataSet LoadLIB_BookIssueRptDateWise(string storProcedure, string fromDate, string toDate)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(storProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(fromDate);
            command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(toDate);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }
    //SearchAll_IssueBooksByBookName
    public DataSet SearchAll_IssueBooksByBookName(string storProcedure, string BookName, string BookID)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(storProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = BookName;
            command.Parameters.Add("@BookID", SqlDbType.Int).Value = Convert.ToInt32(BookID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();
            return LIB_Books;
        }
    }

    public DataSet GetDropDownListAllLIB_Book()
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllLIB_Books", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }

    public DataSet GetDropDownListAllLIB_BookBookID(int BookId)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllLIB_BooksByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.Int).Value = Convert.ToInt32(BookId);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }

    //GetLIB_ISISSUED
    public DataSet GetLIB_ISISSUED(int BookId)
    {
        DataSet LIB_Books = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_IsIssuedBooksByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.Int).Value = Convert.ToInt32(BookId);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Books);
            myadapter.Dispose();
            connection.Close();

            return LIB_Books;
        }
    }
    public DataSet GetAllLIB_BooksWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_BooksWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<LIB_Book> GetLIB_BooksFromReader(IDataReader reader)
    {
        List<LIB_Book> lIB_Books = new List<LIB_Book>();

        while (reader.Read())
        {
            lIB_Books.Add(GetLIB_BookFromReader(reader));
        }
        return lIB_Books;
    }

    public LIB_Book GetLIB_BookFromReader(IDataReader reader)
    {
        try
        {
            LIB_Book lIB_Book = new LIB_Book
                (

                     DataAccessObject.IsNULL<int>(reader["BookID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["SubCategoryID"]),
                     DataAccessObject.IsNULL<int>(reader["PublisherID"]),
                     DataAccessObject.IsNULL<int>(reader["AuthorID"]),
                     DataAccessObject.IsNULL<string>(reader["BookName"]),
                     DataAccessObject.IsNULL<string>(reader["BookISBN"]),
                     DataAccessObject.IsNULL<int>(reader["PublishedYear"]),
                     DataAccessObject.IsNULL<int>(reader["BookNo"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
            lIB_Book.CategoryID = DataAccessObject.IsNULL<int>(reader["CategoryID"]);
            return lIB_Book;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public LIB_Book GetLIB_BookByBookID(int bookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_BookByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.Int).Value = bookID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetLIB_BookFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }
    public DataSet GetLIB_BooksByBookID(int bookID)
    {

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_BookByBookID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.Int).Value = bookID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }

    public int InsertLIB_Book(LIB_Book lIB_Book)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLIB_Book", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = lIB_Book.SubjectID;
            cmd.Parameters.Add("@SubCategoryID", SqlDbType.Int).Value = lIB_Book.SubCategoryID;
            cmd.Parameters.Add("@PublisherID", SqlDbType.Int).Value = lIB_Book.PublisherID;
            cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Value = lIB_Book.AuthorID;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = lIB_Book.BookName;
            cmd.Parameters.Add("@BookISBN", SqlDbType.NVarChar).Value = lIB_Book.BookISBN;
            cmd.Parameters.Add("@PublishedYear", SqlDbType.Int).Value = lIB_Book.PublishedYear;
            cmd.Parameters.Add("@BookNo", SqlDbType.Int).Value = lIB_Book.BookNo;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = lIB_Book.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = lIB_Book.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_Book.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_Book.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BookID"].Value;
        }
    }

    public bool UpdateLIB_Book(LIB_Book lIB_Book)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLIB_Book", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = lIB_Book.BookID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = lIB_Book.SubjectID;
            cmd.Parameters.Add("@SubCategoryID", SqlDbType.Int).Value = lIB_Book.SubCategoryID;
            cmd.Parameters.Add("@PublisherID", SqlDbType.Int).Value = lIB_Book.PublisherID;
            cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Value = lIB_Book.AuthorID;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = lIB_Book.BookName;
            cmd.Parameters.Add("@BookISBN", SqlDbType.NVarChar).Value = lIB_Book.BookISBN;
            cmd.Parameters.Add("@PublishedYear", SqlDbType.Int).Value = lIB_Book.PublishedYear;
            cmd.Parameters.Add("@BookNo", SqlDbType.Int).Value = lIB_Book.BookNo;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_Book.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_Book.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteLIB_Book(int bookID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLIB_Book", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = bookID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

