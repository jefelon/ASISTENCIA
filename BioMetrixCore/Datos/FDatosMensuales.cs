﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMetrixCore.Datos
{
    public class FDatosMensuales
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FDatosMensuales_GetAll", dbParams);

        }
        public static DataSet GetMes()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FDatosMensuales_GetMes", dbParams);

        }
        public static DataSet GetFiltro( int empleadoId, string anio, string mes)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@EmpleadoId", SqlDbType.Int, 0, empleadoId),
                    SQLHelper.MakeParam("@Anio", SqlDbType.VarChar, 0, anio),
                    SQLHelper.MakeParam("@Mes", SqlDbType.VarChar, 0, mes),
                   
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FDatosMensuales_GetFiltro", dbParams);

        }
        
    }
}