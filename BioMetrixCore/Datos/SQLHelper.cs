﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BioMetrixCore.Datos
{
    public class SQLHelper
    {
        public SQLHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataSet ExecuteDataSet(string sqlSpName, SqlParameter[] dbParams)
        {
            DataSet ds = null;
            //try
            //{
            ds = new DataSet();

            string dfgfdg = ConfigurationManager.AppSettings.Get("connectionString");
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand cmd = new SqlCommand(sqlSpName, cn);
            cmd.CommandTimeout = 600;

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
                {
                    da.SelectCommand.Parameters.Add(dbParam);
                }
            }
            da.Fill(ds);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return ds;
        }

        public static bool ExecuteXml(string sqlSpName, SqlParameter[] dbParams, System.Xml.XmlDocument dXml)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand cmd = new SqlCommand(sqlSpName, cn);
            cmd.CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings.Get("connectionCommandTimeout"));
            cmd.CommandType = CommandType.StoredProcedure;

            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
                {
                    cmd.Parameters.Add(dbParam);
                }
            }
            cn.Open();
            bool bReturn;
            try
            {
                //dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        System.Data.SqlTypes.SqlXml oXml = dr.GetSqlXml(dr.GetOrdinal("Xml"));
                        dXml.LoadXml(oXml.Value);
                        bReturn = true;
                    }
                    else
                    {
                        bReturn = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return bReturn;
        }
        public static SqlDataReader ExecuteDataReader(string sqlSpName, SqlParameter[] dbParams)
        {
            SqlDataReader dr;

            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand cmd = new SqlCommand(sqlSpName, cn);
            cmd.CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings.Get("connectionCommandTimeout"));
            cmd.CommandType = CommandType.StoredProcedure;

            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
                {
                    cmd.Parameters.Add(dbParam);
                }
            }
            cn.Open();

            try
            {
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
            return dr;
        }

        public static void ExecuteNonQuery(string sqlSpName, SqlParameter[] dbParams)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand cmd = new SqlCommand(sqlSpName, cn);
            cmd.CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings.Get("connectionCommandTimeout"));
            cmd.CommandType = CommandType.StoredProcedure;

            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
                {
                    cmd.Parameters.Add(dbParam);
                }
            }

            cn.Open();

            try
            {
                cmd.ExecuteNonQuery();
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
        }

        public static object ExecuteScalar(string sqlSpName, SqlParameter[] dbParams)
        {
            object retVal = null;
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand cmd = new SqlCommand(sqlSpName, cn);
            cmd.CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings.Get("connectionCommandTimeout"));
            cmd.CommandType = CommandType.StoredProcedure;

            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
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

        public static SqlParameter MakeParam(string paramName, SqlDbType dbType, int size, object objValue)
        {
            SqlParameter param;

            if (size > 0)
                param = new SqlParameter(paramName, dbType, size);
            else
                param = new SqlParameter(paramName, dbType);

            param.Value = objValue;

            return param;
        }

        public static SqlParameter MakeParamOutput(string paramName, SqlDbType dbType, int size)
        {
            SqlParameter param;

            if (size > 0)
                param = new SqlParameter(paramName, dbType, size);
            else
                param = new SqlParameter(paramName, dbType);

            param.Direction = ParameterDirection.Output;

            return param;
        }

        public static int ExecuteNonQueryOutput(string sqlSpName, SqlParameter[] dbParams, string paramName, SqlDbType dbType, int size)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand cmd = new SqlCommand(sqlSpName, cn);
            cmd.CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings.Get("connectionCommandTimeout"));
            cmd.CommandType = CommandType.StoredProcedure;

            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
                    cmd.Parameters.Add(dbParam);
            }
            SqlParameter OutParam = MakeParamOutput(paramName, dbType, size);
            cmd.Parameters.Add(OutParam);

            cn.Open();

            try
            {
                cmd.ExecuteNonQuery();

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
            if (OutParam.Value == null) return 0;
            else return System.Convert.ToInt16(OutParam.Value);
        }

        /////*******************Modificacion***************************
        //Agregado por Donal chacca kana PAis: Peru Web: http://a-zetasoft.com
        //Los creditos correspondientes a Leandro Tuttini web:http://ltuttini.blogspot.com/
        //El artículo fue tomado de su bog, nosotros solo adaptamos a la logica de nuestro paradigma de trabajo

        //        public static bool Autenticar(string sqlSpName, SqlParameter[] dbParams)
        //        {
        //            string sql = @"SELECT COUNT(*)
        //            FROM tblUsuario
        //            WHERE Usuario = @nombre AND Password = @password";

        //            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
        //            {
        //                conn.Open();
        //                SqlCommand command = new SqlCommand(sql, conn);
        //                command.Parameters.AddWithValue("@nombre", usuario);
        //                string hash = Helper.EncodePassword(string.Concat(usuario, password));
        //                command.Parameters.AddWithValue("@password", hash);
        //                int count = Convert.ToInt32(command.ExecuteScalar());
        //                if (count == 0)
        //                    return false;
        //                else
        //                    return true;
        //            }
        //        }

        //        internal class Helper
        //        {
        //            public static string EncodePassword(string originalPassword)
        //            {
        //                SHA1 sha1 = new SHA1CryptoServiceProvider();

        //                byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
        //                byte[] hash = sha1.ComputeHash(inputBytes);

        //                return Convert.ToBase64String(hash);
        //            }
        //        }

        //************************** fin modificacion ********************************************//



        #region Example
        //public static DataSet Get(CGasto gasto)
        //{
        //    SqlParameter[] dbParams = new SqlParameter[]
        //        {
        //            DBHelper.MakeParam("@Id", SqlDbType.Int, 0, gasto.Id),
        //        };
        //    return DBHelper.ExecuteDataSet("usp_CListGasto_Get", dbParams);

        //} 
        #endregion

    }
}
