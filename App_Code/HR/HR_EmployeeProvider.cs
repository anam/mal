using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Web.UI.WebControls;

public class SqlHR_EmployeeProvider : DataAccessObject
{
    public SqlHR_EmployeeProvider()
    {
    }


    public DataSet GetAllHR_Employees()
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Employees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }

    public DataSet getAllEmployeeListDepartmentWise()
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("getAllEmployeeListDepartmentWise", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }


    public DataSet GetAllHR_EmployeesNotForThisSubject(int SubjectID)
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeesNotForThisSubject", connection);
            command.Parameters.Add("@SubjectID", SubjectID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }

    public DataSet GetAllHR_EmployeesByIDs(string IDs)
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeesByIDs", connection);
            command.Parameters.Add("@IDs", IDs);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }
    
    /// <summary>
    /// Get Active and Rowstatus =1 employees and who employees salary is not process for selected month. 
    /// </summary>
    /// <param name="salaryOfDate">Process Month</param>
    /// <returns>DataSet</returns>
    public DataSet GetAllHR_EmployeeMinuesPayrollSalaryEmp(string salaryOfDate)
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeMinuesPayrollSalaryEmp", connection);
            command.Parameters.Add("@SalaryOfDate", salaryOfDate);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }


    /// <summary>
    /// Get Active and Rowstatus =1 employees and who employees salary is not process for selected month. 
    /// </summary>
    /// <param name="salaryOfDate">Process Month</param>
    /// <returns>DataSet</returns>
    public DataSet GetAllHR_EmployeeMinuesPayrollSalaryEmpByEmployeeID(string employeeID)
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeMinuesPayrollSalaryEmpByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", employeeID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }
    public DataSet GetHR_EmployeeInfoByEmployeeID(string employeeID)
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeInfoByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", employeeID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }

    public DataSet GetHR_EmployeeInfoByEmployeeNo(string employeeNo)
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeInfoByEmployeeNo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeNo", employeeNo);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }


    //GetAllHR_EmpNoNameJoiningDate
    public DataSet GetAllHR_EmpNoNameJoiningDate()
    {
        DataSet EmpNoNameJoiningDate = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmpNoNameJoiningDate", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(EmpNoNameJoiningDate);
            myadapter.Dispose();
            connection.Close();

            return EmpNoNameJoiningDate;
        }
    }

    public DataSet GetHR_EmployeeStatisticDepartWise(int departmentID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("Select * from fn_DesignationWiseEmployeeByDpt(" + departmentID.ToString() + ")", connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetAllHR_EmployeesBySearch(string sqlSearchString)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetAllHR_EmployeesBySearch", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SearchString", SqlDbType.NVarChar).Value = sqlSearchString;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetAllHR_EmployeeIDInfoBySearch(string sqlSearchString)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetAllHR_EmployeeIDInfoBySearch", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SearchString", SqlDbType.NVarChar).Value = sqlSearchString;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public DataSet GetHR_EmployeePageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_EmployeePageWiseAllEmp", connection))
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

    public DataSet GetHR_EmployeePageWise(int pageIndex, int PageSize, out int recordCount, bool isActive)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_EmployeePageWiseActiveInactive", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
                command.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                command.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
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

    public HR_Employee GetHR_EmployeeByEmployeeNo(string employeeNo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeByEmployeeNo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeNo", SqlDbType.NVarChar).Value = employeeNo;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public HR_Employee GetHR_EmployeeByDesignationID(int designationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeByDesignationID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DesignationID", SqlDbType.NVarChar).Value = designationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public HR_Employee GetHR_EmployeeByBloodGroupID(string bloodGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeByBloodGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BloodGroupID", SqlDbType.NVarChar).Value = bloodGroupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public HR_Employee GetHR_EmployeeByGenderID(string genderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeByGenderID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GenderID", SqlDbType.NVarChar).Value = genderID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public HR_Employee GetHR_EmployeeByReligionID(int religionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeByReligionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReligionID", SqlDbType.NVarChar).Value = religionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public HR_Employee GetHR_EmployeeByMaritualStatusID(int maritualStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeByMaritualStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaritualStatusID", SqlDbType.NVarChar).Value = maritualStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public HR_Employee GetHR_EmployeeByNationalityID(int nationalityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeByNationalityID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@NationalityID", SqlDbType.NVarChar).Value = nationalityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetDropDownLisAllHR_Employee()
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Employee", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }


    public DataSet GetDropDownLisAllHR_EmployeeFromSubjectEmployee()
    {
        DataSet HR_Employees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_EmployeeFromSubjectEmployee", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Employees);
            myadapter.Dispose();
            connection.Close();

            return HR_Employees;
        }
    }

    public DataSet GetAllHR_EmployeesWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet GetDropDownLisAllHR_EmployeeByClassID(int classID, int subjectID)
    {

        DataSet STD_Subjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_EmployeeeByClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Subjects);
            myadapter.Dispose();
            connection.Close();

            return STD_Subjects;
        }

    }

    public List<HR_Employee> GetHR_EmployeesFromReader(IDataReader reader)
    {
        List<HR_Employee> hR_Employees = new List<HR_Employee>();

        while (reader.Read())
        {
            hR_Employees.Add(GetHR_EmployeeFromReader(reader));
        }
        return hR_Employees;
    }

    public HR_Employee GetHR_EmployeeFromReader(IDataReader reader)
    {
        try
        {
            HR_Employee hR_Employee = new HR_Employee
                (
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["EmployeeName"]),

                     DataAccessObject.IsNULL<string>(reader["EmployeeNo"]),
                     DataAccessObject.IsNULL<string>(reader["EmailAddress"]),

                     DataAccessObject.IsNULL<string>(reader["EmployeeType"]),
                     DataAccessObject.IsNULL<int>(reader["DesignationID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeRank"]),
                     DataAccessObject.IsNULL<string>(reader["FathersName"]),
                     DataAccessObject.IsNULL<string>(reader["MothersName"]),
                     DataAccessObject.IsNULL<string>(reader["SpouseName"]),
                     DataAccessObject.IsNULL<DateTime>(reader["DateOfBirth"]),
                     DataAccessObject.IsNULL<string>(reader["PlaceOfBirth"]),
                     DataAccessObject.IsNULL<int>(reader["BloodGroupID"]),
                     DataAccessObject.IsNULL<string>(reader["GenderID"]),
                     DataAccessObject.IsNULL<int>(reader["ReligionID"]),
                     DataAccessObject.IsNULL<int>(reader["MaritualStatusID"]),
                     DataAccessObject.IsNULL<int>(reader["NationalityID"]),
                     DataAccessObject.IsNULL<string>(reader["Photo"]),
                     DataAccessObject.IsNULL<string>(reader["Address"]),

                     DataAccessObject.IsNULL<DateTime>(reader["JoiningDate"]),
                     DataAccessObject.IsNULL<DateTime>(reader["ResignDate"]),
                     DataAccessObject.IsNULL<string>(reader["ResignDescription"]),

                     DataAccessObject.IsNULL<bool>(reader["Flag"]),

                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),

                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );

            try
            {
                hR_Employee.DepartmentID = DataAccessObject.IsNULL<int>(reader["DepartmentID"]);
            }
            catch (Exception ex)
            { }

            //hR_Employee.DepartmentName= DataAccessObject.IsNULL<string>(reader["DepartmentName"].ToString());
            return hR_Employee;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public string GetEmployeeNo()
    {
        string employeeNo = string.Empty;
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("GetMaxEmployeeNoFromHR_Employee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            object result = cmd.ExecuteScalar();
            if (result == DBNull.Value)
            {
                employeeNo = DateTime.Now.Date.Year.ToString();
                employeeNo = DateTime.Now.Date.Month.ToString() + employeeNo.Substring(2, 2) + "0001";
            }
            else
            {
                string maxEmployeeNo = Convert.ToString(result);
                maxEmployeeNo = maxEmployeeNo.Substring(4, 4);
                int newEmployeeNo = Convert.ToInt32(maxEmployeeNo);
                newEmployeeNo = newEmployeeNo + 1;

                employeeNo = DateTime.Now.Date.Year.ToString();
                if (DateTime.Now.Date.Month <= 9)
                {
                    employeeNo =  "0" + DateTime.Now.Date.Month.ToString()+employeeNo.Substring(2, 2) ;
                }
                else
                {
                    employeeNo =DateTime.Now.Date.Month.ToString() + employeeNo.Substring(2, 2) ;
                }
                for (int counterUpToFive = newEmployeeNo.ToString().Length; counterUpToFive < 4; counterUpToFive++)
                {
                    employeeNo += "0";
                }
                employeeNo += newEmployeeNo.ToString();
            }
        }

        return employeeNo;
    }

    public HR_Employee GetHR_EmployeeByEmployeeID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_EmployeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertHR_Employee(HR_Employee hR_Employee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Employee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Employee.EmployeeID;
            cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = hR_Employee.EmployeeName;

            cmd.Parameters.Add("@EmployeeNo", SqlDbType.NVarChar).Value = hR_Employee.EmployeeNo;

            cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = hR_Employee.EmailAddress;

            cmd.Parameters.Add("@EmployeeType", SqlDbType.NVarChar).Value = hR_Employee.EmployeeType;
            cmd.Parameters.Add("@DesignationID", SqlDbType.Int).Value = hR_Employee.DesignationID;
            cmd.Parameters.Add("@EmployeeRank", SqlDbType.NVarChar).Value = hR_Employee.EmployeeRank;
            cmd.Parameters.Add("@FathersName", SqlDbType.NVarChar).Value = hR_Employee.FathersName;
            cmd.Parameters.Add("@MothersName", SqlDbType.NVarChar).Value = hR_Employee.MothersName;
            cmd.Parameters.Add("@SpouseName", SqlDbType.NVarChar).Value = hR_Employee.SpouseName;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = hR_Employee.DateOfBirth;
            cmd.Parameters.Add("@PlaceOfBirth", SqlDbType.NVarChar).Value = hR_Employee.PlaceOfBirth;
            cmd.Parameters.Add("@BloodGroupID", SqlDbType.NVarChar).Value = hR_Employee.BloodGroupID;
            cmd.Parameters.Add("@GenderID", SqlDbType.NVarChar).Value = hR_Employee.GenderID;
            cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Value = hR_Employee.ReligionID;
            cmd.Parameters.Add("@MaritualStatusID", SqlDbType.NVarChar).Value = hR_Employee.MaritualStatusID;
            cmd.Parameters.Add("@NationalityID", SqlDbType.Int).Value = hR_Employee.NationalityID;
            cmd.Parameters.Add("@Photo", SqlDbType.NVarChar).Value = hR_Employee.Photo;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = hR_Employee.Address;
            cmd.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = hR_Employee.JoiningDate; // == DateTime.MinValue ? DBNull : hR_Employee.JoiningDate;
            cmd.Parameters.Add("@Flag", SqlDbType.Bit).Value = hR_Employee.Flag;

            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = hR_Employee.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = hR_Employee.ExtraField2;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Employee.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Employee.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Employee.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Employee.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }

    public bool UpdateHR_Employee(HR_Employee hR_Employee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Employee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Employee.EmployeeID;
            cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = hR_Employee.EmployeeName;

            cmd.Parameters.Add("@EmployeeNo", SqlDbType.NVarChar).Value = hR_Employee.EmployeeNo;
            cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = hR_Employee.EmailAddress;

            cmd.Parameters.Add("@EmployeeType", SqlDbType.NVarChar).Value = hR_Employee.EmployeeType;
            cmd.Parameters.Add("@DesignationID", SqlDbType.Int).Value = hR_Employee.DesignationID;
            cmd.Parameters.Add("@EmployeeRank", SqlDbType.NVarChar).Value = hR_Employee.EmployeeRank;
            cmd.Parameters.Add("@FathersName", SqlDbType.NVarChar).Value = hR_Employee.FathersName;
            cmd.Parameters.Add("@MothersName", SqlDbType.NVarChar).Value = hR_Employee.MothersName;
            cmd.Parameters.Add("@SpouseName", SqlDbType.NVarChar).Value = hR_Employee.SpouseName;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = hR_Employee.DateOfBirth;
            cmd.Parameters.Add("@PlaceOfBirth", SqlDbType.NVarChar).Value = hR_Employee.PlaceOfBirth;
            cmd.Parameters.Add("@BloodGroupID", SqlDbType.NVarChar).Value = hR_Employee.BloodGroupID;
            cmd.Parameters.Add("@GenderID", SqlDbType.NVarChar).Value = hR_Employee.GenderID;
            cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Value = hR_Employee.ReligionID;
            cmd.Parameters.Add("@MaritualStatusID", SqlDbType.NVarChar).Value = hR_Employee.MaritualStatusID;
            cmd.Parameters.Add("@NationalityID", SqlDbType.Int).Value = hR_Employee.NationalityID;
            cmd.Parameters.Add("@Photo", SqlDbType.NVarChar).Value = hR_Employee.Photo;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = hR_Employee.Address;
            cmd.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = hR_Employee.JoiningDate; // == DateTime.MinValue ? DBNull : hR_Employee.JoiningDate;
            cmd.Parameters.Add("@Flag", SqlDbType.Bit).Value = hR_Employee.Flag;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = hR_Employee.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = hR_Employee.ExtraField2;

            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Employee.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Employee.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool UpdateHR_EmployeeName(HR_Employee hR_Employee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EmployeeName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Employee.EmployeeID;
            
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = hR_Employee.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = hR_Employee.ExtraField2;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool UpdateHR_EmployeeResignInfo(HR_Employee hR_Employee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EmployeeResignInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_Employee.EmployeeID;
            cmd.Parameters.Add("@ResignDate", SqlDbType.DateTime).Value = hR_Employee.ResignDate;
            cmd.Parameters.Add("@ResignDescription", SqlDbType.NVarChar).Value = hR_Employee.ResignDescription;
            cmd.Parameters.Add("@Flag", SqlDbType.Bit).Value = hR_Employee.Flag;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Employee.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Employee.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Employee(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Employee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    
    public bool DeleteHR_EmployeePermanently(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployeePermanently", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public bool DeleteHR_EmployeeChnageRowStatusID(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployeeChnageRowStatusID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public HR_Employee ViewTeacherMoneyReceipt(string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_TeacherMoneyReceiptByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetHR_EmployeeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataTable GetEmployeeAdvanceSalaryInfo()
    {

        DataSet advanceSalary = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeAdvanceSalaryInfo", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(advanceSalary);
            myadapter.Dispose();
            connection.Close();

            return advanceSalary.Tables[0];
        }

    }

    public DataTable GetEmployeeSecurityAmountInfo()
    {

        DataSet advanceSalary = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeSecurityMoneyInfo", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(advanceSalary);
            myadapter.Dispose();
            connection.Close();

            return advanceSalary.Tables[0];
        }

    }
}

