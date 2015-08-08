using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_ChildrenInfo
{
    public HR_ChildrenInfo()
    {
    }


    public HR_ChildrenInfo
        (
int  childrenInfoID,
string  employeeID,
string  ChildrenInfoName,
string  childrenDateOfBirth,
string  sex,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ChildrenInfoID = childrenInfoID;
this.EmployeeID = employeeID;
this.ChildrenInfoName = ChildrenInfoName;
this.ChildrenDateOfBirth = childrenDateOfBirth;
this.Sex = sex;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ChildrenInfoID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public string  ChildrenInfoName
    {
        get ; 
        set  ;
    }

    public string  ChildrenDateOfBirth
    {
        get ; 
        set  ;
    }

    public string  Sex
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

