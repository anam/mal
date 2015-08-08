using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Employee
{
    public HR_Employee()
    {
    }


    public HR_Employee
        (
string employeeID,
string employeeName,
        string employeeNo,
        string emailAddress,
        string employeeType,
        int designationID,
        string employeeRank,
        string fathersName,
        string mothersName,
        string spouseName,
        DateTime dateOfBirth,
        string placeOfBirth,
        int bloodGroupID,
        string genderID,
        int religionID,
        int maritualStatusID,
        int nationalityID,
        string photo,
        string address,
        DateTime joiningDate,
        DateTime resignDate,
        string resignDescription,
        bool flag,
        string extraField1,
        string extraField2,
        string addedBy,
        DateTime addedDate,
        string modifiedBy,
        DateTime modifiedDate

        )
    {
        this.EmployeeID = employeeID;
        this.EmployeeName = employeeName;
        this.EmployeeNo = employeeNo;
        this.EmailAddress = emailAddress;
        this.EmployeeType = employeeType;
        this.DesignationID = designationID;
        this.EmployeeRank = employeeRank;
        this.FathersName = fathersName;
        this.MothersName = mothersName;
        this.SpouseName = spouseName;
        this.DateOfBirth = dateOfBirth;
        this.PlaceOfBirth = placeOfBirth;
        this.BloodGroupID = bloodGroupID;
        this.GenderID = genderID;
        this.ReligionID = religionID;
        this.MaritualStatusID = maritualStatusID;
        this.NationalityID = nationalityID;
        this.Photo = photo;
        this.Address = address;
        this.JoiningDate = joiningDate;
        this.ResignDate = resignDate;
        this.ResignDescription = resignDescription;

        this.Flag = flag;
        this.ExtraField1 = extraField1;
        this.ExtraField2 = extraField2;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;

    }

    public string EmployeeID
    {
        get;
        set;
    }

    public string EmployeeName
    {
        get;
        set;
    }


    /// <summary>
    /// 1st 2 digit = Year 
    /// 2nd 2 digit = month
    /// 3rd 5degit = employee #
    /// </summary>
    public string EmployeeNo
    {
        get;
        set;
    }

    public string EmailAddress
    {
        get;
        set;
    }

    public string EmployeeType
    {
        get;
        set;
    }

    public int DesignationID
    {
        get;
        set;
    }

    public int DepartmentID
    {
        get;
        set;
    }

    public string EmployeeRank
    {
        get;
        set;
    }

    public string FathersName
    {
        get;
        set;
    }

    public string MothersName
    {
        get;
        set;
    }

    public string SpouseName
    {
        get;
        set;
    }

    public DateTime DateOfBirth
    {
        get;
        set;
    }

    public string PlaceOfBirth
    {
        get;
        set;
    }

    public int BloodGroupID
    {
        get;
        set;
    }

    public string GenderID
    {
        get;
        set;
    }

    public int ReligionID
    {
        get;
        set;
    }

    public int MaritualStatusID
    {
        get;
        set;
    }

    public int NationalityID
    {
        get;
        set;
    }

    public string Photo
    {
        get;
        set;
    }

    public string Address
    {
        get;
        set;
    }

    public DateTime JoiningDate
    {
        get;
        set;
    }

    public DateTime ResignDate
    {
        get;
        set;
    }

    public string ResignDescription
    {
        get;
        set;
    }

    public bool Flag
    {
        get;
        set;
    }
    /// <summary>
    /// Nick name for Routine
    /// </summary>
    public string ExtraField1
    {
        get;
        set;
    }

    /// <summary>
    /// Nick name details for Routine
    /// </summary
    public string ExtraField2
    {
        get;
        set;
    }

    public string ExtraField3
    {
        get;
        set;
    }

    public string ExtraField4
    {
        get;
        set;
    }

    public string ExtraField5
    {
        get;
        set;
    }

    public string ExtraField6
    {
        get;
        set;
    }

    public string ExtraField7
    {
        get;
        set;
    }

    public string ExtraField8
    {
        get;
        set;
    }

    public string ExtraField9
    {
        get;
        set;
    }

    public string ExtraField10
    {
        get;
        set;
    }
    //ExtraField1
    public string AddedBy
    {
        get;
        set;
    }

    public DateTime AddedDate
    {
        get;
        set;
    }

    public string ModifiedBy
    {
        get;
        set;
    }

    public DateTime ModifiedDate
    {
        get;
        set;
    }

    public string DepartmentName
    {
        get;
        set;
    }

    public string Amount
    {
        get;
        set;
    }
}

