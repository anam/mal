using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class LIB_Book
{
    public LIB_Book()
    {
    }


    public LIB_Book
        (
int  bookID,
int  subjectID,
int SubCategoryID,
int  publisherID,
int  authorID,
string  bookName,
string  bookISBN,
int  publishedYear,
int bookNo,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.BookID = bookID;
this.SubjectID = subjectID;

this.SubCategoryID = SubCategoryID;
this.PublisherID = publisherID;
this.AuthorID = authorID;
this.BookName = bookName;
this.BookISBN = bookISBN;
this.PublishedYear = publishedYear;
this.BookNo = bookNo;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  BookID
    {
        get ; 
        set  ;
    }

    public int  SubjectID
    {
        get ; 
        set  ;
    }

     public int SubCategoryID
    {
        get ; 
        set  ;
    }

     public int CategoryID
     {
         get;
         set;
     }
    public int  PublisherID
    {
        get ; 
        set  ;
    }

    public int  AuthorID
    {
        get ; 
        set  ;
    }

    public string  BookName
    {
        get ; 
        set  ;
    }

    public string  BookISBN
    {
        get ; 
        set  ;
    }

    public int  PublishedYear
    {
        get ; 
        set  ;
    }
    public int BookNo
    {
        get;
        set;
    }

    public string  AddedBy
    {
        get ; 
        set  ;
    }

    public DateTime  AddedDate
    {
        get ; 
        set  ;
    }

    public string  ModifiedBy
    {
        get ; 
        set  ;
    }

    public DateTime  ModifiedDate
    {
        get ; 
        set  ;
    }

}

