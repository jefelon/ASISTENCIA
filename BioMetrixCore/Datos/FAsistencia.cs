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
            return SQLHelper.ExecuteDataSet("select * from tblAsistencia order by id; ", dbParams);

        }
        public static DataSet GetAllFechas(DateTime fecha, int empleadoId)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Fecha", SqlDbType.DateTime, 0, fecha),
                    SQLHelper.MakeParam("@EmpleadoId", SqlDbType.Int, 0, empleadoId),
                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FAsistencia_GetAll", dbParams);

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
            return Convert.ToInt32(SQLHelper.ExecuteScalar("insert into tblIngreso(NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha) values(@NumeroEquipo, @CodigoEmpleado, @ModoAcceso,@TipoRegistro,@Fecha); select last_insert_rowid();", dbParams));
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
    }
}
