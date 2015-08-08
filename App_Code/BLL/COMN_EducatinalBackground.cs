using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class COMN_EducatinalBackground
{
    public COMN_EducatinalBackground()
    {
    }


    public COMN_EducatinalBackground
        (
int  educationalBacgroundID,
string  userID,
string  year,
string  boardUniversity,
string  educationGroup,
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
this.UserID = userID;
this.Year = year;
this.BoardUniversity = boardUniversity;
this.EducationGroup = educationGroup;
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

    public string  UserID
    {
        get ; 
        set  ;
    }

    public string  Year
    {
        get ; 
        set  ;
    }

    public string  BoardUniversity
    {
        get ; 
        set  ;
    }

    public string  EducationGroup
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
    public string ReaultSystemName
    {
        get;
        set;
    }
    public string StudentName
    {
        get;
        set;
    }
}

