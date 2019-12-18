using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMetrixCore.Datos
{
   public  class FEmpleado
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return SQLHelper.ExecuteDataSet("usp_Datos_FEmpleado_GetAll", dbParams);

        }
        public static int Insertar(string codigo, double codigoEmpleado, string nombreTexto, string apellidos, int departamentoId, string cargo, int asigFam, int onp, int afp, int rentaQta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Codigo", SqlDbType.Int, 0, codigo),
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Decimal, 0, codigoEmpleado),
                    SQLHelper.MakeParam("@NombreTexto", SqlDbType.VarChar, 0, nombreTexto),
                    SQLHelper.MakeParam("@Apellidos", SqlDbType.VarChar, 0, apellidos),
                    SQLHelper.MakeParam("@departamentoId", SqlDbType.Int, 0, departamentoId),
                    SQLHelper.MakeParam("@Cargo", SqlDbType.VarChar, 0, cargo),
                    SQLHelper.MakeParam("@AsigFam", SqlDbType.Int, 0, asigFam),
                    SQLHelper.MakeParam("@Onp", SqlDbType.Int, 0, onp),
                    SQLHelper.MakeParam("@Afp", SqlDbType.Int, 0, afp),
                    SQLHelper.MakeParam("@RentaQta", SqlDbType.Int, 0,rentaQta),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FEmpleado_Insertar", dbParams));
        }
        public static int Actualizar(int id,string codigo, double codigoEmpleado, string nombreTexto, string apellidos, int departamentoId, string cargo, int asigFam, int onp, int afp, int rentaQta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Id", SqlDbType.Int, 0, id),
                    SQLHelper.MakeParam("@Codigo", SqlDbType.Int, 0, codigo),
                    SQLHelper.MakeParam("@CodigoEmpleado", SqlDbType.Decimal, 0, codigoEmpleado),
                    SQLHelper.MakeParam("@NombreTexto", SqlDbType.VarChar, 0, nombreTexto),
                    SQLHelper.MakeParam("@Apellidos", SqlDbType.VarChar, 0, apellidos),
                    SQLHelper.MakeParam("@departamentoId", SqlDbType.Int, 0, departamentoId),
                    SQLHelper.MakeParam("@Cargo", SqlDbType.VarChar, 0, cargo),
                    SQLHelper.MakeParam("@AsigFam", SqlDbType.Int, 0, asigFam),
                    SQLHelper.MakeParam("@Onp", SqlDbType.Int, 0, onp),
                    SQLHelper.MakeParam("@Afp", SqlDbType.Int, 0, afp),
                    SQLHelper.MakeParam("@RentaQta", SqlDbType.Int, 0,rentaQta),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FEmpleado_Actualizar", dbParams));
        }
        public static int Eliminar(int id)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@Id", SqlDbType.Int, 0, id),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("usp_Datos_FEmpleado_Eliminar", dbParams));

        }
    }
}
