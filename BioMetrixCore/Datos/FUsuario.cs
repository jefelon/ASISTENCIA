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
    public class FUsuario
    {
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return SQLHelper.ExecuteDataSet("select * from tblUsuario order by id; ", dbParams);

        }
        public static DataSet iniciarSesion(string sUsuario, string sContrasena)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    SQLHelper.MakeParam("@NombreUsuario", SqlDbType.VarChar, 0, sUsuario),
                    SQLHelper.MakeParam("@Contrasena", SqlDbType.VarChar, 0, sContrasena),
                };
            return SQLHelper.ExecuteDataSet("select * from tblUsuario u INNER JOIN tblEmpresa e ON e.Id =u.EmpresaId  WHERE NombreUsuario=@NombreUsuario AND Contrasena=@Contrasena; ", dbParams);

        }
        public static int Insertar(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                     //SQLHelper.MakeParam("@NombreUsuario", DbType.String, 0, usuario.Nombre),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("insert into tblUsuario(Nombre) values(@Nombre); select last_insert_rowid();", dbParams));
        }

        public static int Actualizar(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    //SQLHelper.MakeParam("@Id", DbType.Int32, 0, usuario.Id),
                    // SQLHelper.MakeParam("@Nombre", DbType.String, 0, usuario.Nombre),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("update tblUsuario set Nombre=@Nombre   WHERE Id=@Id", dbParams));

        }

        public static int Eliminar(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    //SQLHelper.MakeParam("@Id", DbType.Int32, 0, usuario.Id),
                };
            return Convert.ToInt32(SQLHelper.ExecuteScalar("DELETE FROM tblUsuario WHERE Id= @Id", dbParams));

        }
    }
}
