using BioMetrixCore.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMetrixCore.Datos
{
    public class FAsistencia
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FAsistencia_GetAll", dbParams);

        }
        public static DataSet GetFechas(DateTime fecha, int codEmpleado, string tipo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Fecha", SqlDbType.DateTime, 0, fecha),
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Int, 0, codEmpleado),
                    SQLHelper.MakeParam("@Tipo", SqlDbType.VarChar, 0, tipo),
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FAsistencia_GetFechas", dbParams);

        }
        public static DataSet GetHoraExtraFecha(DateTime desde, DateTime hasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Desde", SqlDbType.DateTime, 0, desde),
                    SQLHelper.MakeParam("@Hasta", SqlDbType.DateTime, 0, hasta),
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FAsistencia_GetHoraExtraFechas", dbParams);

        }
        
        public static DataSet GetAllDatos(int anio, int mes,int codEmpleado)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Anio", SqlDbType.Int, 0, anio),
                    SQLHelper.MakeParam("@Mes", SqlDbType.Int, 0, mes),
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Int, 0, codEmpleado),
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FAsistencia_GetAllDatos", dbParams);

        }
        public static DataSet GetFiltro(int codEmpleado, DateTime desde, DateTime hasta, string tipo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Int, 0, codEmpleado),
                    SQLHelper.MakeParam("@Desde", SqlDbType.Date, 0, desde),
                    SQLHelper.MakeParam("@Hasta", SqlDbType.Date, 0, hasta),
                    SQLHelper.MakeParam("@Tipo", SqlDbType.VarChar, 0, tipo),
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FAsistencia_GetFiltro", dbParams);

        }
        public static DataSet Comparar(int numEqu,double codEmp, DateTime fecha)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@NumeroEquipo", SqlDbType.Int, 0, numEqu),
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Int, 0, codEmp),
                    SQLHelper.MakeParam("@Fecha", SqlDbType.DateTime, 0, fecha)
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FDatos_FAsistencia_Comparar", dbParams);

        }
        public static int Insertar(Asistencia asistencia)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    //NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha
                    SQLHelper.MakeParam("@NumeroEquipo", SqlDbType.Int, 0, asistencia.NumeroEquipo),
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Decimal, 0, asistencia.CodigoEmpleado),
                    SQLHelper.MakeParam("@ModoAcceso", SqlDbType.Int, 0, asistencia.ModoAcceso),
                    SQLHelper.MakeParam("@TipoRegistro", SqlDbType.Int, 0, asistencia.TipoRegistro),
                    SQLHelper.MakeParam("@Fecha", SqlDbType.DateTime, 0, asistencia.Fecha),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FAsistencia_InsertarRegistro", dbParams));
        }

        public static int Actualizar(Asistencia asistencia)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Id", SqlDbType.Int, 0, asistencia.Id),
                    SQLHelper.MakeParam("@NumeroEquipo", SqlDbType.Int, 0, asistencia.NumeroEquipo),
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Decimal, 0, asistencia.CodigoEmpleado),
                    SQLHelper.MakeParam("@ModoAcceso", SqlDbType.Int, 0, asistencia.ModoAcceso),
                    SQLHelper.MakeParam("@TipoRegistro", SqlDbType.Int, 0, asistencia.TipoRegistro),
                    SQLHelper.MakeParam("@Fecha", SqlDbType.DateTime, 0, asistencia.Fecha),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("update tblAsistencia set NumeroEquipo=@NumeroEquipo, CodigoEmpleado=@CodigoEmpleado,ModoAcceso=@ModoAcceso,TipoRegistro=@TipoRegistro,Fecha=@Fecha   WHERE Id=@Id", dbParams));

        }

        public static int Eliminar(Asistencia asistencia)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Id", SqlDbType.Int, 0, asistencia.Id),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FAsistencia_Eliminar", dbParams));

        }
        public static int EliminarTodo()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FAsistencia_EliminarTodo", dbParams));

        }
    }
}
