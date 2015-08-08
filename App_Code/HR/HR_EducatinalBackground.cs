using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_EducatinalBackground
{
    public HR_EducatinalBackground()
    {
    }


    public HR_EducatinalBackground
        (
int  educationalBacgroundID,
string  employeeID,
int  yearID,
int  boardUniversityID,
int  educationGroupID,
string  major,
int  reaultSystemID,
string  degree,
string  result,
decimal  score,
int  outOf,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.EducationalBacgroundID = educationalBacgroundID;
this.EmployeeID = employeeID;
this.YearID = yearID;
this.BoardUniversityID = boardUniversityID;
this.EducationGroupID = educationGroupID;
this.Major = major;
this.ReaultSystemID = reaultSystemID;
this.Degree = degree;
this.Result = result;
this.Score = score;
this.OutOf = outOf;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  EducationalBacgroundID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public int  YearID
    {
        get ; 
        set  ;
    }

    public int  BoardUniversityID
    {
        get ; 
        set  ;
    }

    public int  EducationGroupID
    {
        get ; 
        set  ;
    }

    public string  Major
    {
        get ; 
        set  ;
    }

    public int  ReaultSystemID
    {
        get ; 
        set  ;
    }

    public string  Degree
    {
        get ; 
        set  ;
    }

    public string  Result
    {
        get ; 
        set  ;
    }

    public decimal  Score
    {
        get ; 
        set  ;
    }

    public int  OutOf
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

