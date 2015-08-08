using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Attendence
{
    public STD_Attendence()
    {
    }


    public STD_Attendence
        (
string classTimeName,
DateTime Date,
        string dateClassTimeName
        )

    {
        this.ClassTimeName = classTimeName;
        this.Date = Date;
        this.DateClassTimeName = dateClassTimeName;
    }

    public string ClassTimeName
    {
        get ; 
        set  ;
    }


    public DateTime Date
    {
        get ; 
        set  ;
    }


    public string DateClassTimeName
    {
        get;
        set;
    }

}

