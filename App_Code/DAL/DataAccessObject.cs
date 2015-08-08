using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class DataAccessObject
{
    public DataAccessObject()
    {
    }

    private string _connectionString = ConfigurationManager.ConnectionStrings["CUCDBConnectionString"].ConnectionString;
    public string ConnectionString
    {
        get { return _connectionString; }
        set { _connectionString = value; }
    }


    private string _cucconnectionString = ConfigurationManager.ConnectionStrings["CUC_ORGDBConnectionString"].ConnectionString;
    public string CUCConnectionString
    {
        get { return _cucconnectionString; }
        set { _cucconnectionString = value; }
    }



    public static T IsNULL<T>(object x)
    {
        if (x != System.DBNull.Value)
        {
            return (T)(object)x;
        }
        else
        {
            if (typeof(T).Equals(typeof(System.Int32)))
            {
                return (T)(object)(int)0;
            }
            else if (typeof(T).Equals(typeof(System.String)))
            {
                return (T)(object)"";
            }
            else if (typeof(T).Equals(typeof(System.Decimal)))
            {
                return (T)(object)(decimal)0;
            }
            else if (typeof(T).Equals(typeof(System.Double)))
            {
                return (T)(object)(double)0;
            }
            else if ((typeof(T).Equals(typeof(System.DateTime))))
            {
                return (T)(object)System.DateTime.MinValue;
            }
            else if ((typeof(T).Equals(typeof(System.Boolean))))
            {
                return (T)(object)false;
            }
            else if ((typeof(T).Equals(typeof(System.Byte))))
            {
                return (T)(object)(byte)0;
            }
            else if ((typeof(T).Equals(typeof(System.Int16))))

                return (T)(object)(short)0;
        }
        return (T)(object)"";
    }
}

