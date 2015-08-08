using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_StudentProvider : DataAccessObject
{
    public SqlSTD_StudentProvider()
    {
    }


    public DataSet GetAllSTD_Students()
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Students", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }

    public DataSet GetSTD_StudentClassSummery(string studentCode, DateTime fromDate, DateTime toDate)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentByStudentAndDateRangeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentCode", SqlDbType.NVarChar).Value = studentCode;
            command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
            command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }


    public DataSet GetSTD_StudentByIDs(string IDs)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentByIDs", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IDs", SqlDbType.NVarChar).Value = IDs;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }

    public DataSet GetSTD_StudentPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_StudentPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
                command.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                command.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                recordCount = Convert.ToInt32(command.Parameters["@RecordCount"].Value);
                return ds;
            }
        }
    }


    public STD_Student GetSTD_StudentByMaritualStatusID(int MaritualStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentByMaritualStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaritualStatusID", SqlDbType.NVarChar).Value = MaritualStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_StudentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public STD_Student GetSTD_StudentByReligionID(int religionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentByReligionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReligionID", SqlDbType.NVarChar).Value = religionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_StudentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public STD_Student GetSTD_StudentByStudentCode(string studentCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentByReligionCode", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentCode", SqlDbType.NVarChar).Value = studentCode;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_StudentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public STD_Student GetSTD_StudentByStudentCodeRefund(string studentCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentByStudentCodeRefund", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentCode", SqlDbType.NVarChar).Value = studentCode;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_StudentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetDropDownListAllSTD_Student()
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Students", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }

    public DataSet GetAllSTD_StudentsWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_StudentsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Student> GetSTD_StudentsFromReader(IDataReader reader)
    {
        List<STD_Student> sTD_Students = new List<STD_Student>();

        while (reader.Read())
        {
            sTD_Students.Add(GetSTD_StudentFromReader(reader));
        }
        return sTD_Students;
    }

    public STD_Student GetSTD_StudentFromReader(IDataReader reader)
    {
        try
        {
            STD_Student sTD_Student = new STD_Student
                (

                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["StudentName"]),
                     DataAccessObject.IsNULL<string>(reader["PPSizePhoto"]),
                     DataAccessObject.IsNULL<string>(reader["StudentCode"]),
                     DataAccessObject.IsNULL<string>(reader["PresentAddress"]),
                     DataAccessObject.IsNULL<string>(reader["PermanentAddress"]),
                     DataAccessObject.IsNULL<string>(reader["Telephone"]),
                     DataAccessObject.IsNULL<string>(reader["Mobile"]),
                     DataAccessObject.IsNULL<string>(reader["Email"]),
                     DataAccessObject.IsNULL<DateTime>(reader["DateofBirth"]),
                     DataAccessObject.IsNULL<string>(reader["PassportNo"]),
                     DataAccessObject.IsNULL<string>(reader["Gender"]),
                     DataAccessObject.IsNULL<int>(reader["MaritalStatusID"]),
                     DataAccessObject.IsNULL<int>(reader["ReligionID"]),
                     DataAccessObject.IsNULL<string>(reader["SpouseQualification"]),
                     DataAccessObject.IsNULL<string>(reader["EnglishQualification"]),
                     DataAccessObject.IsNULL<bool>(reader["IsRegisterWithACCA"]),
                     DataAccessObject.IsNULL<DateTime>(reader["RegistrationDate"]),
                     DataAccessObject.IsNULL<string>(reader["RegistrationNo"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"]),
                     DataAccessObject.IsNULL<string>(reader["BloodGroup"]),
                     DataAccessObject.IsNULL<decimal>(reader["IELTS"]),
                     DataAccessObject.IsNULL<decimal>(reader["TOFEL"]),
                     DataAccessObject.IsNULL<int>(reader["Year"]),
                     DataAccessObject.IsNULL<int>(reader["BatchNo"]),
                     DataAccessObject.IsNULL<int>(reader["ID"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
            try
            {
                sTD_Student.ClassName = DataAccessObject.IsNULL<string>(reader["ClassName"]);
            }
            catch (Exception ex)
            {

            }
            return sTD_Student;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public STD_Student GetSTD_StudentByStudentID(string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_StudentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet InsertSTD_Student(STD_Student sTD_Student)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("InsertSTD_Student", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_Student.StudentID;
                //cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = sTD_Student.StudentName;
                cmd.Parameters.Add("@PPSizePhoto", SqlDbType.NVarChar).Value = sTD_Student.PPSizePhoto;
                cmd.Parameters.Add("@StudentCode", SqlDbType.NVarChar).Value = sTD_Student.StudentCode;
                cmd.Parameters.Add("@PresentAddress", SqlDbType.NVarChar).Value = sTD_Student.PresentAddress;
                cmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar).Value = sTD_Student.PermanentAddress;
                cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = sTD_Student.Telephone;
                cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = sTD_Student.Mobile;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = sTD_Student.Email;
                cmd.Parameters.Add("@DateofBirth", SqlDbType.DateTime).Value = sTD_Student.DateofBirth;
                cmd.Parameters.Add("@PassportNo", SqlDbType.NVarChar).Value = sTD_Student.PassportNo;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = sTD_Student.Gender;
                cmd.Parameters.Add("@MaritalStatusID", SqlDbType.Int).Value = sTD_Student.MaritualStatusID;
                cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Value = sTD_Student.ReligionID;
                cmd.Parameters.Add("@SpouseQualification", SqlDbType.NVarChar).Value = sTD_Student.SpouseQualification;
                cmd.Parameters.Add("@EnglishQualification", SqlDbType.NVarChar).Value = sTD_Student.EnglishQualification;
                cmd.Parameters.Add("@IsRegisterWithACCA", SqlDbType.Bit).Value = sTD_Student.IsRegisterWithACCA;
                cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime).Value = sTD_Student.RegistrationDate;
                cmd.Parameters.Add("@RegistrationNo", SqlDbType.NVarChar).Value = sTD_Student.RegistrationNo;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Student.AddedBy;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Student.AddedDate;
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_Student.ModifiedBy;
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_Student.ModifiedDate;
                cmd.Parameters.Add("@BloodGroup", SqlDbType.NChar).Value = sTD_Student.BloodGroup;
                cmd.Parameters.Add("@IELTS", SqlDbType.Decimal).Value = sTD_Student.IELTS;
                cmd.Parameters.Add("@TOFEL", SqlDbType.Decimal).Value = sTD_Student.TOFEL;
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = sTD_Student.Year;
                cmd.Parameters.Add("@BatchNo", SqlDbType.Int).Value = sTD_Student.BatchNo;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = sTD_Student.ID;
                cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Student.RowStatusID;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }

        //using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        //{
        //    SqlCommand cmd = new SqlCommand("InsertSTD_Student", connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value =sTD_Student.StudentID;
        //    //cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = sTD_Student.StudentName;
        //    cmd.Parameters.Add("@PPSizePhoto", SqlDbType.NVarChar).Value = sTD_Student.PPSizePhoto;
        //    cmd.Parameters.Add("@StudentCode", SqlDbType.NVarChar).Value = sTD_Student.StudentCode;
        //    cmd.Parameters.Add("@PresentAddress", SqlDbType.NVarChar).Value = sTD_Student.PresentAddress;
        //    cmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar).Value = sTD_Student.PermanentAddress;
        //    cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = sTD_Student.Telephone;
        //    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = sTD_Student.Mobile;
        //    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = sTD_Student.Email;
        //    cmd.Parameters.Add("@DateofBirth", SqlDbType.DateTime).Value = sTD_Student.DateofBirth;
        //    cmd.Parameters.Add("@PassportNo", SqlDbType.NVarChar).Value = sTD_Student.PassportNo;
        //    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = sTD_Student.Gender;
        //    cmd.Parameters.Add("@MaritualStatusID", SqlDbType.Int).Value = sTD_Student.MaritualStatusID;
        //    cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Value = sTD_Student.ReligionID;
        //    cmd.Parameters.Add("@SpouseQualification", SqlDbType.NVarChar).Value = sTD_Student.SpouseQualification;
        //    cmd.Parameters.Add("@EnglishQualification", SqlDbType.NVarChar).Value = sTD_Student.EnglishQualification;
        //    cmd.Parameters.Add("@IsRegisterWithACCA", SqlDbType.Bit).Value = sTD_Student.IsRegisterWithACCA;
        //    cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime).Value = sTD_Student.RegistrationDate;
        //    cmd.Parameters.Add("@RegistrationNo", SqlDbType.NVarChar).Value = sTD_Student.RegistrationNo;
        //    cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Student.AddedBy;
        //    cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Student.AddedDate;
        //    cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_Student.ModifiedBy;
        //    cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_Student.ModifiedDate;
        //    cmd.Parameters.Add("@BloodGroup", SqlDbType.NChar).Value = sTD_Student.BloodGroup;
        //    cmd.Parameters.Add("@IELTS", SqlDbType.Decimal).Value = sTD_Student.IELTS;
        //    cmd.Parameters.Add("@TOFEL", SqlDbType.Decimal).Value = sTD_Student.TOFEL;
        //    connection.Open();

        //    int result = cmd.ExecuteNonQuery();
        //    return cmd.Parameters["@StudentID"].Value.ToString();
        //}
    }

    public bool UpdateSTD_Student(STD_Student sTD_Student)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Student", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_Student.StudentID;
            //cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = sTD_Student.StudentName;
            cmd.Parameters.Add("@PPSizePhoto", SqlDbType.NVarChar).Value = sTD_Student.PPSizePhoto;
            cmd.Parameters.Add("@StudentCode", SqlDbType.NVarChar).Value = sTD_Student.StudentCode;
            cmd.Parameters.Add("@PresentAddress", SqlDbType.NVarChar).Value = sTD_Student.PresentAddress;
            cmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar).Value = sTD_Student.PermanentAddress;
            cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = sTD_Student.Telephone;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = sTD_Student.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = sTD_Student.Email;
            cmd.Parameters.Add("@DateofBirth", SqlDbType.DateTime).Value = sTD_Student.DateofBirth;
            cmd.Parameters.Add("@PassportNo", SqlDbType.NVarChar).Value = sTD_Student.PassportNo;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = sTD_Student.Gender;
            cmd.Parameters.Add("@MaritalStatusID", SqlDbType.Int).Value = sTD_Student.MaritualStatusID;
            cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Value = sTD_Student.ReligionID;
            cmd.Parameters.Add("@SpouseQualification", SqlDbType.NVarChar).Value = sTD_Student.SpouseQualification;
            cmd.Parameters.Add("@EnglishQualification", SqlDbType.NVarChar).Value = sTD_Student.EnglishQualification;
            cmd.Parameters.Add("@IsRegisterWithACCA", SqlDbType.Bit).Value = sTD_Student.IsRegisterWithACCA;
            cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime).Value = sTD_Student.RegistrationDate;
            cmd.Parameters.Add("@RegistrationNo", SqlDbType.NVarChar).Value = sTD_Student.RegistrationNo;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Student.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Student.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_Student.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_Student.ModifiedDate;
            cmd.Parameters.Add("@BloodGroup", SqlDbType.NChar).Value = sTD_Student.BloodGroup;
            cmd.Parameters.Add("@IELTS", SqlDbType.Decimal).Value = sTD_Student.IELTS;
            cmd.Parameters.Add("@TOFEL", SqlDbType.Decimal).Value = sTD_Student.TOFEL;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = sTD_Student.Year;
            cmd.Parameters.Add("@BatchNo", SqlDbType.Int).Value = sTD_Student.BatchNo;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = sTD_Student.ID;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Student.RowStatusID;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    
    public bool DeleteSTD_Student(string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Student", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public bool DeleteSTD_StudentAccordingToRowStatusID(string studentID, int rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_StudentAccordingToRowStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public List<STD_Student> GetSTD_StudentsFromReader1(IDataReader reader)
    {
        List<STD_Student> sTD_Students = new List<STD_Student>();

        while (reader.Read())
        {
            sTD_Students.Add(GetSTD_StudentFromReader1(reader));
        }
        return sTD_Students;
    }

    public STD_Student GetSTD_StudentFromReader1(IDataReader reader)
    {
        try
        {
            STD_Student sTD_Student = new STD_Student
                (

                      DataAccessObject.IsNULL<int>(reader["MaxID"]),
                     DataAccessObject.IsNULL<int>(reader["Year"])

                );


            return sTD_Student;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public STD_Student GetAllSTD_StudentsByBatchNo(int batchNo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentByBatchNo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BatchNo", SqlDbType.Int).Value = batchNo;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_StudentFromReader1(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public List<STD_Student> SearchAllSTD_Students(string studentName, string studentCode, int batchNo, string phone, DateTime startDate, DateTime endDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SearchAllSTD_Students", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = studentName;
            command.Parameters.Add("@StudentCode", SqlDbType.NVarChar).Value = studentCode;
            command.Parameters.Add("@BatchNo", SqlDbType.Int).Value = batchNo;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return GetSTD_StudentsFromReader(reader);

        }
    }

    public STD_Student GetSTD_StudentMoneyReceitByStudentID(string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_StudentMoneyReceiptByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_StudentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetSTD_StudentsAttentdant(int classID, int subjectID, string employeeID)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentsAttentdant", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }

    public DataSet GetSTD_StudentsAttentdantAlreadyAttended(int classID, int subjectID, string employeeID, string time)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentsAttentdantAlreadyAttended", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            command.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = time;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }

    public DataSet DeleteSTD_StudentsAttentdantAlreadyAttended(int classID, int subjectID, string employeeID, string time)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("DeleteSTD_StudentsAttentdantAlreadyAttended", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            command.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = time;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }


    public DataSet GetSTD_ClassStudentsAttentdant(string employeeID, DateTime date)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }

    public DataSet GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDForRepeating(string ClassSubjectEmployeeID, DateTime date)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDForRepeating", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectEmployeeID", SqlDbType.Int).Value = int.Parse(ClassSubjectEmployeeID);
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }


    public DataSet GetSTD_ExamStudentsByExamDetailsID(int examDetailsID)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamStudentsByExamDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamDetailsID", SqlDbType.Int).Value = examDetailsID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }

    public DataSet GetSTD_ExamDetailsStudentsByExamDetailsStudentID(int examDetailsStudentID)
    {
        DataSet STD_ExamDetailsStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsStudentsByExamDetailsStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamDetailsStudentID", SqlDbType.Int).Value = examDetailsStudentID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailsStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailsStudents;
        }
    }

    public DataSet GetSTD_ExamDetailsStudentsByExamDetailsID(int examDetailsID)
    {
        DataSet STD_ExamDetailsStudents = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsStudentsByExamDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamDetailsID", SqlDbType.Int).Value = examDetailsID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailsStudents);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailsStudents;
        }
    }

    public DataSet GetSTD_StudentsByExamID(int examID)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentsByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }

    public DataSet GetSTD_StudentsByExamIDnStudentID(int examID,string studentID)
    {
        DataSet STD_Students = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_StudentsByExamIDnStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Students);
            myadapter.Dispose();
            connection.Close();

            return STD_Students;
        }
    }
}

