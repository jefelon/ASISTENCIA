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
        public static DataSet GetFechas(DateTime fecha, int empleadoId,string tipo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Fecha", SqlDbType.DateTime, 0, fecha),
                    SQLHelper.MakeParam("@EmpleadoId", SqlDbType.Int, 0, empleadoId),
                    SQLHelper.MakeParam("@Tipo", SqlDbType.Int, 0, tipo),
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FAsistencia_GetFechas", dbParams);

        }
        public static DataSet GetAllDatos(int anio, int mes,int empleadoId)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Anio", SqlDbType.Int, 0, anio),
                    SQLHelper.MakeParam("@Mes", SqlDbType.Int, 0, mes),
                    SQLHelper.MakeParam("@EmpleadoId", SqlDbType.Int, 0, empleadoId),
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FAsistencia_GetAllDatos", dbParams);

        }
        public static DataSet GetFiltro(int empleadoId, DateTime desde, DateTime hasta, string tipo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@EmpleadoId", SqlDbType.Int, 0, empleadoId),
                    SQLHelper.MakeParam("@Desde", SqlDbType.Date, 0, desde),
                    SQLHelper.MakeParam("@Hasta", SqlDbType.Date, 0, hasta),
                    SQLHelper.MakeParam("@Tipo", SqlDbType.VarChar, 0, tipo),
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FAsistencia_GetFiltro", dbParams);

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
            return Convert.ToInt32(SQLHelper.ExecuteScalar("insert into tblAsistencia(NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha) values(@NumeroEquipo, @CodigoEmpleado, @ModoAcceso,@TipoRegistro,@Fecha); select last_insert_rowid();", dbParams));
        }
        public static int InsertarIngreso(Asistencia asistencia)
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
        public static int InsertarSalida(Asistencia asistencia)
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
            return Convert.ToInt32(SQLHelper.ExecuteScalar("insert into tblSalida(NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha) values(@NumeroEquipo, @CodigoEmpleado, @ModoAcceso,@TipoRegistro,@Fecha); select last_insert_rowid();", dbParams));
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
        public static int Sincronizar(Asistencia asistencia)
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
            return Convert.ToInt32(SQLHelper.ExecuteScalar("DELETE FROM tblAsistencia WHERE Id= @Id", dbParams));

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
