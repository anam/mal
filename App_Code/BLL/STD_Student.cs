using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Student
{
    public STD_Student()
    {
    }


    public STD_Student
        (
            string studentID,
            string studentName,
            string pPSizePhoto,
            string studentCode,
            string presentAddress,
            string permanentAddress,
            string telephone,
            string mobile,
            string email,
            DateTime dateofBirth,
            string passportNo,
            string gender,
            int MaritualStatusID,
            int religionID,
            string spouseQualification,
            string englishQualification,
            bool isRegisterWithACCA,
            DateTime registrationDate,
            string registrationNo,
            string addedBy,
            DateTime addedDate,
            string modifiedBy,
            DateTime modifiedDate,
            string bloodGroup,
            decimal iELTS,
            decimal tOFEL,
            int year,
            int batchNo,
            int id,
            int rowStatusID
        )
    {
        this.StudentID = studentID;
        this.StudentName = studentName;
        this.PPSizePhoto = pPSizePhoto;
        this.StudentCode = studentCode;
        this.PresentAddress = presentAddress;
        this.PermanentAddress = permanentAddress;
        this.Telephone = telephone;
        this.Mobile = mobile;
        this.Email = email;
        this.DateofBirth = dateofBirth;
        this.PassportNo = passportNo;
        this.Gender = gender;
        this.MaritualStatusID = MaritualStatusID;
        this.ReligionID = religionID;
        this.SpouseQualification = spouseQualification;
        this.EnglishQualification = englishQualification;
        this.IsRegisterWithACCA = isRegisterWithACCA;
        this.RegistrationDate = registrationDate;
        this.RegistrationNo = registrationNo;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.BloodGroup = bloodGroup;
        this.IELTS = iELTS;
        this.TOFEL = tOFEL;
        this.Year = year;
        this.BatchNo = batchNo;
        this.ID = id;
        this.RowStatusID = rowStatusID;  

    }

    public STD_Student
        (
        int maxID,
        int year
        )
    {
        this.MaxID = maxID;
        this.Year = year;
    }
    public string StudentID
    {
        get;
        set;
    }


    
    public string StudentName
    {
        get;
        set;
    }

    public string PPSizePhoto
    {
        get;
        set;
    }

    /// <summary>
    /// 1st 2 digit = year
    /// 2nd 3 degit = bath ID of the STD_Batch
    /// 3rd 3 degit = student serial of that bath
    /// </summary>
    public string StudentCode
    {
        get;
        set;
    }

    public string PresentAddress
    {
        get;
        set;
    }

    public string PermanentAddress
    {
        get;
        set;
    }

    public string Telephone
    {
        get;
        set;
    }

    public string Mobile
    {
        get;
        set;
    }

    public string Email
    {
        get;
        set;
    }

    public DateTime DateofBirth
    {
        get;
        set;
    }

    public string PassportNo
    {
        get;
        set;
    }

    public string Gender
    {
        get;
        set;
    }

    public int MaritualStatusID
    {
        get;
        set;
    }

    public int ReligionID
    {
        get;
        set;
    }


    /// <summary>
    /// ProgramID which is used for the fees
    /// </summary>
    public string SpouseQualification
    {
        get;
        set;
    }

    public string EnglishQualification
    {
        get;
        set;
    }

    public bool IsRegisterWithACCA
    {
        get;
        set;
    }

    public DateTime RegistrationDate
    {
        get;
        set;
    }

    public string RegistrationNo
    {
        get;
        set;
    }

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

    public string BloodGroup
    {
        get;
        set;
    }

    public decimal IELTS
    {
        get;
        set;
    }

    public decimal TOFEL
    {
        get;
        set;
    }

    public int Year
    {
        get;
        set;
    }

    public int BatchNo
    {
        get;
        set;
    }

    public int ID
    {
        get;
        set;
    }
    public int RowStatusID
    {
        get;
        set;
    }
    public int MaxID
    {
        get;
        set;
    }

    public string ReligionName
    {
        get
        {
            if (ReligionID > 0)
                return COMN_ReligionManager.GetCOMN_ReligionByReligionID(ReligionID).ReligionName;
            return string.Empty;
        }
    }

    public string MeritalStatus
    {
        get
        {
            if (MaritualStatusID > 0)
                return COMN_MaritualStatusManager.GetCOMN_MaritualStatusByMaritualStatusID(MaritualStatusID).MaritualStatusName;
            return string.Empty;
        }
    }
    
    public decimal ObtainedMark
    {
        get;
        set;
    }

    public int ExamDetailsStudentID
    {
        get;
        set;
    }

    public int ClassSubjectEmployeeID
    {
        get;
        set;
    }

    public string ClassName
    {
        get;
        set;
    }

    public string EmployeeName
    {
        get;
        set;
    }

    public string SubjectName
    {
        get;
        set;
    }

    public int NoOfClass
    {
        get;
        set;
    }

    public int NoOfPresent
    {
        get;
        set;
    }
    public int ClassSubjectID
    {
        get;
        set;
    }

    public bool IsActive
    { get; set; }

    public bool IsHistory
    { get; set; }
}

