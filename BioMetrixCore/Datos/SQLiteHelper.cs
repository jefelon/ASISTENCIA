// Version 1.2
// Date: 2014-03-27
// http://sh.codeplex.com
// Dedicated to Public Domain

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Data.SQLite;

namespace BioMetrixCore.Datos
{
    public class SQLiteHelper
    {
        public static DataSet ExecuteDataSet(string sqlSpName, SQLiteParameter[] dbParams)
        {
            DataSet ds = null;
            //try
            //{
            ds = new DataSet();
           // SQLiteConnection cn = new SQLiteConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SQLiteConnection cn = new SQLiteConnection("data source=data.db3");
            SQLiteCommand cmd = new SQLiteCommand(sqlSpName, cn);
            cmd.CommandTimeout = 600;

            cmd.CommandType = CommandType.Text;
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

            if (dbParams != null)
            {
                //cn.Open();
                foreach (SQLiteParameter dbParam in dbParams)
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

        public static object ExecuteScalar(string sqlSpName, SQLiteParameter[] dbParams)
        {
            object retVal = null;
            //SQLiteConnection cn = new SQLiteConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SQLiteConnection cn = new SQLiteConnection("data source=data.db3");
            SQLiteCommand cmd = new SQLiteCommand(sqlSpName, cn);
            //cmd.CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings.Get("connectionCommandTimeout"));
            cmd.CommandTimeout = 600;
            cmd.CommandType = CommandType.Text;

            if (dbParams != null)
            {
                foreach (SQLiteParameter dbParam in dbParams)
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

        public static SQLiteParameter MakeParam(string paramName, DbType dbType, int size, object objValue)
        {
            SQLiteParameter param;

            if (size > 0)
                param = new SQLiteParameter(paramName, dbType, size);
            else
                param = new SQLiteParameter(paramName, dbType);

            param.Value = objValue;

            return param;
        }


    }
}