using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class LIB_SubCategory
{
    public LIB_SubCategory()
    {
    }


    public LIB_SubCategory
        (
int  subCategoryID,
string  subCategoryName,
int  categoryID,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.SubCategoryID = subCategoryID;
this.SubCategoryName = subCategoryName;
this.CategoryID = categoryID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  SubCategoryID
    {
        get ; 
        set  ;
    }

    public string  SubCategoryName
    {
        get ; 
        set  ;
    }

    public int  CategoryID
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

