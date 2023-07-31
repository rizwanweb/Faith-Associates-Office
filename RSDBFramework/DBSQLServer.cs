using RSDBFramework.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSDBFramework
{   
    public class DBSQLServer
    {
        // ExecuteReader, ExecuteScalar and ExecuteNonQuery

        private string _connstring;

        public DBSQLServer(string connstring)
        {
            _connstring = connstring;
        }

        
        public object GetScalarValue(string storedProcedure)
        {
            object value = null;
            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    value = cmd.ExecuteScalar();
                }
            }
            return value;
        }

        // With single Parameter
        public object GetScalarValue(string storedProcedure, DBParameter parameter)
        {
            object value = null;
            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue(parameter.Parameter, parameter.Value);
                    value = cmd.ExecuteScalar();
                }
            }
            return value;
        }

        // With multiple Parameters
        public object GetScalarValue(string storedProcedure, DBParameter[] parameters)
        {
            object value = null;
            try
            {
                
                using (SqlConnection conn = new SqlConnection(_connstring))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        conn.Open();
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.AddWithValue(parameter.Parameter, parameter.Value);
                        }
                        value = cmd.ExecuteScalar();
                    }
                }
                
            }
            catch (Exception ex)
            {
                RSMessageBox.ShowErrorMessage(ex.Message);
            }
            return value;
        }
        

        public DataTable GetDataList(string storedProcedure)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }
        public DataTable GetDataList(string storedProcedure, DBParameter parameter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue(parameter.Parameter, parameter.Value);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }
        public DataTable GetDataList(string storedProcedure, DBParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Parameter, parameter.Value);
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }

        public DataTable GetDataList(string storedProcedure, object obj)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    // Parameters
                    Type type = obj.GetType();
                    BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                    PropertyInfo[] properties = type.GetProperties(flags);

                    foreach (var property in properties)
                    {
                        cmd.Parameters.AddWithValue("@" + property.Name, property.GetValue(obj, null));
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }

        public void InsertOrUpdateRecord(string storedProcedure, object obj)
        {
            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    //Parameters
                    Type type = obj.GetType();
                    BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                    PropertyInfo[] properties = type.GetProperties(flags);

                    foreach (var property in properties)
                    {
                        cmd.Parameters.AddWithValue("@" + property.Name, property.GetValue(obj, null));
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertOrUpdateRecord(string storeProcedure, DBParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storeProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    //Parameters
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Parameter, parameter.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRecord(string storedProcedure, DBParameter parameter)
        {
            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue(parameter.Parameter, parameter.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
