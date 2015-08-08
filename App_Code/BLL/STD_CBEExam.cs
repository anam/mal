using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for STD_CBEExam
/// </summary>
public class STD_CBEExam
{
	public STD_CBEExam()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public STD_CBEExam
        (
        int cBEExamID,
        string candidateName,
        DateTime dOB, 
        string gender, 
        string regiNo, 
        string instituteName, 
        string tel, 
        string mobile, 
        string email, 
        string feesDescription, 
        string addedBy, 
        DateTime addedDate, 
        string updatedBy, 
        DateTime updatedDate, 
        int rowStatusID
        )
    {
        this.CBEExamID = cBEExamID;
        this.CandidateName = candidateName;
        this.DOB = dOB;
        this.Gender = gender;
        this.RegiNo = regiNo;
        this.InstituteName = instituteName;
        this.Tel = tel;
        this.Mobile = mobile;
        this.Email = email;
        this.FeesDescription = feesDescription;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
        this.RowStatusID = rowStatusID;
    }


    private int _cBEExamID;
    public int CBEExamID
    {
        get { return _cBEExamID; }
        set { _cBEExamID = value; }
    }

    private string _candidateName;

    public string CandidateName
    {
        get { return _candidateName; }
        set { _candidateName = value; }
    }

    private DateTime _dOB;
    public DateTime DOB
    {
        get { return _dOB; }
        set { _dOB = value; }
    }

    private string _gender;
    public string Gender
    {
        get { return _gender; }
        set { _gender = value; }
    }

    private string _regiNo;
    public string RegiNo
    {
        get { return _regiNo; }
        set { _regiNo = value; }
    }

    private string _instituteName;
    public string InstituteName
    {
        get { return _instituteName; }
        set { _instituteName = value; }
    }

    private string _tel;
    public string Tel
    {
        get { return _tel; }
        set { _tel = value; }
    }

    private string _mobile;
    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    private string _feesDescription;
    public string FeesDescription
    {
        get { return _feesDescription; }
        set { _feesDescription = value; }
    }

    private string _addedBy;
    public string AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private string _updatedBy;
    public string UpdatedBy
    {
        get { return _updatedBy; }
        set { _updatedBy = value; }
    }

    private DateTime _updatedDate;
    public DateTime UpdatedDate
    {
        get { return _updatedDate; }
        set { _updatedDate = value; }
    }

    private int _rowStatusID;
    public int RowStatusID
    {
        get { return _rowStatusID; }
        set { _rowStatusID = value; }
    }

    public string SubjectTitle
    {
        get;
        set;
    }

    public Decimal Fees
    {
        get;
        set;
    }
}