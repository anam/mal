using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_EmployerType
{
    public HR_EmployerType()
    {
    }


    public HR_EmployerType
        (
int  employerType,
string  employerTypeName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.EmployerType = employerType;
this.EmployerTypeName = employerTypeName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  EmployerType
    {
        get ; 
        set  ;
    }

    public string  EmployerTypeName
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

