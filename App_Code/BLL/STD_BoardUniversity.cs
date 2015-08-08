using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_BoardUniversity
{
    public STD_BoardUniversity()
    {
    }


    public STD_BoardUniversity
        (
int  boardUniversityID,
string  boardUniversityName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.BoardUniversityID = boardUniversityID;
this.BoardUniversityName = boardUniversityName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  BoardUniversityID
    {
        get ; 
        set  ;
    }

    public string  BoardUniversityName
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

