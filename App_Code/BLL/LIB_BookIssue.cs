using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class LIB_BookIssue
{
    public LIB_BookIssue()
    {
    }


    public LIB_BookIssue
        (
int  bookIssueID,
int  bookID,
string  issedToID,
bool  isStudent,
DateTime  issueDate,
DateTime  returnDate,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.BookIssueID = bookIssueID;
this.BookID = bookID;
this.IssedToID = issedToID;
this.IsStudent = isStudent;
this.IssueDate = issueDate;
this.ReturnDate = returnDate;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  BookIssueID
    {
        get ; 
        set  ;
    }

    public int  BookID
    {
        get ; 
        set  ;
    }

    public string  IssedToID
    {
        get ; 
        set  ;
    }

    public bool  IsStudent
    {
        get ; 
        set  ;
    }

    public DateTime  IssueDate
    {
        get ; 
        set  ;
    }

    public DateTime  ReturnDate
    {
        get ; 
        set  ;
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

