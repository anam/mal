using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class LIB_Category
{
    public LIB_Category()
    {
    }


    public LIB_Category
        (
int  categoryID,
string  categoryName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.CategoryID = categoryID;
this.CategoryName = categoryName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  CategoryID
    {
        get ; 
        set  ;
    }

    public string  CategoryName
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

