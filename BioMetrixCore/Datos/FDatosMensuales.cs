using System;
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
        public static DataSet GetUltimoRegistro(int codigoEmpleado, string anio, int mes)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Int, 0, codigoEmpleado),
                    SQLHelper.MakeParam("@Anio", SqlDbType.VarChar, 0, anio),
                    SQLHelper.MakeParam("@Mes", SqlDbType.Int, 0, mes),
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FDatosMensuales_GetUltimoRegistro", dbParams);

        }
        
        public static DataSet GetFiltro( int codigoEmpleado, string anio, string mes)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Int, 0, codigoEmpleado),
                    SQLHelper.MakeParam("@Anio", SqlDbType.VarChar, 0, anio),
                    SQLHelper.MakeParam("@Mes", SqlDbType.VarChar, 0, mes),
                   
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FDatosMensuales_GetFiltro", dbParams);

        }
        public static int Insertar(int codigoEmpleado, int mesId, int anioId, double afpCom, double afpPrimCom, double basico)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Int, 0, codigoEmpleado),
                    SQLHelper.MakeParam("@MesId", SqlDbType.Int, 0, mesId),
                    SQLHelper.MakeParam("@AnioId", SqlDbType.Int, 0, anioId),
                    SQLHelper.MakeParam("@AfpCom", SqlDbType.Decimal, 0, afpCom),
                    SQLHelper.MakeParam("@AfpPrimCom", SqlDbType.Decimal, 0, afpPrimCom),
                    SQLHelper.MakeParam("@Basico", SqlDbType.Decimal, 0, basico),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FDatosMensuales_Insertar", dbParams));
        }
        public static int Actualizar(int id,int codigoEmpleado, int mesId, int anioId, double afpCom, double afpPrimCom, double basico)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Id", SqlDbType.Int, 0, id),
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Int, 0, codigoEmpleado),
                    SQLHelper.MakeParam("@MesId", SqlDbType.Int, 0, mesId),
                    SQLHelper.MakeParam("@AnioId", SqlDbType.Int, 0, anioId),
                    SQLHelper.MakeParam("@AfpCom", SqlDbType.Decimal, 0, afpCom),
                    SQLHelper.MakeParam("@AfpPrimCom", SqlDbType.Decimal, 0, afpPrimCom),
                    SQLHelper.MakeParam("@Basico", SqlDbType.Decimal, 0, basico),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FDatosMensuales_Actualizar", dbParams));
        }

    }
}
