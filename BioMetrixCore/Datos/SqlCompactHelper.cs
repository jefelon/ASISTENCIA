using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMetrixCore.Datos
{
    public class SqlCompactHelper
    {
        public static DataSet ExecuteDataSet(string sqlSpName, SqlCeParameter[] dbParams)
        {
            DataSet ds = null;
            //try
            //{
            ds = new DataSet();
            // SqlCeConnection cn = new SqlCeConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCeConnection cn = new SqlCeConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCeCommand cmd = new SqlCeCommand(sqlSpName, cn);
            cmd.CommandTimeout = 0;

            cmd.CommandType = CommandType.Text;
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

            if (dbParams != null)
            {
                //cn.Open();
                foreach (SqlCeParameter dbParam in dbParams)
                {
                    da.SelectCommand.Parameters.Add(dbParam);

                }
                //cn.Close();
            }
            da.Fill(ds);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return ds;

        }

        public static object ExecuteScalar(string sqlSpName, SqlCeParameter[] dbParams)
        {
            object retVal = null;
            //SqlCeConnection cn = new SqlCeConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCeConnection cn = new SqlCeConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCeCommand cmd = new SqlCeCommand(sqlSpName, cn);
            //cmd.CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings.Get("connectionCommandTimeout"));
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;

            if (dbParams != null)
            {
                foreach (SqlCeParameter dbParam in dbParams)
                {
                    cmd.Parameters.Add(dbParam);
                }
            }

            cn.Open();

            try
            {
                retVal = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (null != cn)
                    cn.Close();
            }

            return retVal;
        }

        public static SqlCeParameter MakeParam(string paramName, DbType dbType, int size, object objValue)
        {
            SqlCeParameter param;

            if (size > 0)
                param = new SqlCeParameter(paramName, dbType);
            else
                param = new SqlCeParameter(paramName, dbType);

            param.Value = objValue;

            return param;
        }
    }
}
