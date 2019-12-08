using BioMetrixCore.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
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
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {

                };
            return SQLiteHelper.ExecuteDataSet("select * from tblAsistencia order by id; ", dbParams);

        }
        public static DataSet GetAllFechas()
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {

                };
            return SQLiteHelper.ExecuteDataSet("SELECT i.CodigoEmpleado,e.NombreTexto, strftime('%d-%m-%Y',  i.Fecha) as FechaIngreso,strftime('%H:%M:%S',  i.Fecha) as HoraIngreso, strftime('%d-%m-%Y',  S.Fecha) as FechaSalida,strftime('%H:%M:%S',  s.Fecha) as HoraSalida ," +
                " round(CAST((julianday(s.Fecha) - julianday(i.Fecha)) * 24 AS REAL), 2) AS HorasTrabajadas" +
                "  tblIngreso i" +
                " LEFT  JOIN tblSalida s ON i.CodigoEmpleado = s.CodigoEmpleado" +
                " INNER JOIN tblEmpleado e ON e.CodigoEmpleado = i.CodigoEmpleado" +
                " GROUP BY   i.CodigoEmpleado, strftime('%d-%m-%Y', i.Fecha)", dbParams);

        }
        public static int Insertar(Asistencia asistencia)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                    //NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha
                    SQLiteHelper.MakeParam("@NumeroEquipo", DbType.Int32, 0, asistencia.NumeroEquipo),
                    SQLiteHelper.MakeParam("@CodigoEmpleado", DbType.Double, 0, asistencia.CodigoEmpleado),
                    SQLiteHelper.MakeParam("@ModoAcceso", DbType.Int32, 0, asistencia.ModoAcceso),
                    SQLiteHelper.MakeParam("@TipoRegistro", DbType.Int32, 0, asistencia.TipoRegistro),
                    SQLiteHelper.MakeParam("@Fecha", DbType.DateTime, 0, asistencia.Fecha),
                };
            return Convert.ToInt32(SQLiteHelper.ExecuteScalar("insert into tblAsistencia(NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha) values(@NumeroEquipo, @CodigoEmpleado, @ModoAcceso,@TipoRegistro,@Fecha); select last_insert_rowid();", dbParams));
        }
        public static int InsertarIngreso(Asistencia asistencia)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                    //NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha
                    SQLiteHelper.MakeParam("@NumeroEquipo", DbType.Int32, 0, asistencia.NumeroEquipo),
                    SQLiteHelper.MakeParam("@CodigoEmpleado", DbType.Double, 0, asistencia.CodigoEmpleado),
                    SQLiteHelper.MakeParam("@ModoAcceso", DbType.Int32, 0, asistencia.ModoAcceso),
                    SQLiteHelper.MakeParam("@TipoRegistro", DbType.Int32, 0, asistencia.TipoRegistro),
                    SQLiteHelper.MakeParam("@Fecha", DbType.DateTime, 0, asistencia.Fecha),
                };
            return Convert.ToInt32(SQLiteHelper.ExecuteScalar("insert into tblIngreso(NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha) values(@NumeroEquipo, @CodigoEmpleado, @ModoAcceso,@TipoRegistro,@Fecha); select last_insert_rowid();", dbParams));
        }
        public static int InsertarSalida(Asistencia asistencia)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                    //NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha
                    SQLiteHelper.MakeParam("@NumeroEquipo", DbType.Int32, 0, asistencia.NumeroEquipo),
                    SQLiteHelper.MakeParam("@CodigoEmpleado", DbType.Double, 0, asistencia.CodigoEmpleado),
                    SQLiteHelper.MakeParam("@ModoAcceso", DbType.Int32, 0, asistencia.ModoAcceso),
                    SQLiteHelper.MakeParam("@TipoRegistro", DbType.Int32, 0, asistencia.TipoRegistro),
                    SQLiteHelper.MakeParam("@Fecha", DbType.DateTime, 0, asistencia.Fecha),
                };
            return Convert.ToInt32(SQLiteHelper.ExecuteScalar("insert into tblSalida(NumeroEquipo, CodigoEmpleado, ModoAcceso,TipoRegistro,Fecha) values(@NumeroEquipo, @CodigoEmpleado, @ModoAcceso,@TipoRegistro,@Fecha); select last_insert_rowid();", dbParams));
        }

        public static int Actualizar(Asistencia asistencia)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                    SQLiteHelper.MakeParam("@Id", DbType.Int32, 0, asistencia.Id),
                    SQLiteHelper.MakeParam("@NumeroEquipo", DbType.Int32, 0, asistencia.NumeroEquipo),
                    SQLiteHelper.MakeParam("@CodigoEmpleado", DbType.Double, 0, asistencia.CodigoEmpleado),
                    SQLiteHelper.MakeParam("@ModoAcceso", DbType.Int32, 0, asistencia.ModoAcceso),
                    SQLiteHelper.MakeParam("@TipoRegistro", DbType.Int32, 0, asistencia.TipoRegistro),
                    SQLiteHelper.MakeParam("@Fecha", DbType.DateTime, 0, asistencia.Fecha),
                };
            return Convert.ToInt32(SQLiteHelper.ExecuteScalar("update tblAsistencia set NumeroEquipo=@NumeroEquipo, CodigoEmpleado=@CodigoEmpleado,ModoAcceso=@ModoAcceso,TipoRegistro=@TipoRegistro,Fecha=@Fecha   WHERE Id=@Id", dbParams));

        }
        public static int Sincronizar(Asistencia asistencia)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                    SQLiteHelper.MakeParam("@Id", DbType.Int32, 0, asistencia.Id),
                    SQLiteHelper.MakeParam("@NumeroEquipo", DbType.Int32, 0, asistencia.NumeroEquipo),
                    SQLiteHelper.MakeParam("@CodigoEmpleado", DbType.Double, 0, asistencia.CodigoEmpleado),
                    SQLiteHelper.MakeParam("@ModoAcceso", DbType.Int32, 0, asistencia.ModoAcceso),
                    SQLiteHelper.MakeParam("@TipoRegistro", DbType.Int32, 0, asistencia.TipoRegistro),
                    SQLiteHelper.MakeParam("@Fecha", DbType.DateTime, 0, asistencia.Fecha),
                };
            return Convert.ToInt32(SQLiteHelper.ExecuteScalar("update tblAsistencia set NumeroEquipo=@NumeroEquipo, CodigoEmpleado=@CodigoEmpleado,ModoAcceso=@ModoAcceso,TipoRegistro=@TipoRegistro,Fecha=@Fecha   WHERE Id=@Id", dbParams));

        }

        public static int Eliminar(Asistencia asistencia)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                    SQLiteHelper.MakeParam("@Id", DbType.Int32, 0, asistencia.Id),
                };
            return Convert.ToInt32(SQLiteHelper.ExecuteScalar("DELETE FROM tblAsistencia WHERE Id= @Id", dbParams));

        }
    }
}
