using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_StudentContact
{
    public STD_StudentContact()
    {
    }


    public STD_StudentContact
        (
int  studentContactID,
string  sudentID,
int  contactID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.StudentContactID = studentContactID;
this.SudentID = sudentID;
this.ContactID = contactID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  StudentContactID
    {
        get ; 
        set  ;
    }

    public string  SudentID
    {
        get ; 
        set  ;
    }

    public int  ContactID
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

    public string  UpdatedBy
    {
        get ; 
        set  ;
    }

    public DateTime  UpdateDate
    {
        get ; 
        set  ;
    }

}

