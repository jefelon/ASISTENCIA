using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMetrixCore.Datos
{
    public class FDatosAnuales
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FDatosAnuales_GetAll", dbParams);

        }
        public static DataSet GetAnio()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FDatosAnuales_GetAnio", dbParams);

        }
        public static int Insertar(int anioId, double asigFam, double remMin, double essalud, double onpDat, double afpDat, double uit)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@AnioId", SqlDbType.Int, 0, anioId),
                    SQLHelper.MakeParam("@AsigFam", SqlDbType.Decimal, 0, asigFam),
                    SQLHelper.MakeParam("@RemMin", SqlDbType.Decimal, 0, remMin),
                    SQLHelper.MakeParam("@Essalud", SqlDbType.Decimal, 0, essalud),
                    SQLHelper.MakeParam("@OnpDat", SqlDbType.Decimal, 0, onpDat),
                    SQLHelper.MakeParam("@AfpDat", SqlDbType.Decimal, 0, afpDat),
                    SQLHelper.MakeParam("@Uit", SqlDbType.Decimal, 0, uit),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FDatosAnuales_Insertar", dbParams));
        }
        public static int Actualizar(int id,int anioId, double asigFam, double remMin, double essalud, double onpDat, double afpDat, double uit)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Id", SqlDbType.Int, 0, id),
                    SQLHelper.MakeParam("@AnioId", SqlDbType.Int, 0, anioId),
                    SQLHelper.MakeParam("@AsigFam", SqlDbType.Decimal, 0, asigFam),
                    SQLHelper.MakeParam("@RemMin", SqlDbType.Decimal, 0, remMin),
                    SQLHelper.MakeParam("@Essalud", SqlDbType.Decimal, 0, essalud),
                    SQLHelper.MakeParam("@OnpDat", SqlDbType.Decimal, 0, onpDat),
                    SQLHelper.MakeParam("@AfpDat", SqlDbType.Decimal, 0, afpDat),
                    SQLHelper.MakeParam("@Uit", SqlDbType.Decimal, 0, uit),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FDatosAnuales_Actualizar", dbParams));

        }
        public static int Eliminar(int id)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Id", SqlDbType.Int, 0, id),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FDatosMensuales_Eliminar", dbParams));

        }
    }
}
