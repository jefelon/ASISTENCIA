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
    public class FUsuario
    {
        public static DataSet GetAll()
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {

                };
            return SQLiteHelper.ExecuteDataSet("select * from tblUsuario order by id; ", dbParams);

        }
        public static DataSet iniciarSesion(string sUsuario, string sContrasena)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                    SQLiteHelper.MakeParam("@NombreUsuario", DbType.String, 0, sUsuario),
                    SQLiteHelper.MakeParam("@Contrasena", DbType.String, 0, sContrasena),
                };
            return SQLiteHelper.ExecuteDataSet("select * from tblUsuario u INNER JOIN tblEmpresa e ON e.Id =u.EmpresaId  WHERE NombreUsuario=@NombreUsuario AND Contrasena=@Contrasena; ", dbParams);

        }
        public static int Insertar(Usuario usuario)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                     //SQLiteHelper.MakeParam("@NombreUsuario", DbType.String, 0, usuario.Nombre),
                };
            return Convert.ToInt32(SQLiteHelper.ExecuteScalar("insert into tblUsuario(Nombre) values(@Nombre); select last_insert_rowid();", dbParams));
        }

        public static int Actualizar(Usuario usuario)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                    //SQLiteHelper.MakeParam("@Id", DbType.Int32, 0, usuario.Id),
                    // SQLiteHelper.MakeParam("@Nombre", DbType.String, 0, usuario.Nombre),
                };
            return Convert.ToInt32(SQLiteHelper.ExecuteScalar("update tblUsuario set Nombre=@Nombre   WHERE Id=@Id", dbParams));

        }

        public static int Eliminar(Usuario usuario)
        {
            SQLiteParameter[] dbParams = new SQLiteParameter[]
                {
                    //SQLiteHelper.MakeParam("@Id", DbType.Int32, 0, usuario.Id),
                };
            return Convert.ToInt32(SQLiteHelper.ExecuteScalar("DELETE FROM tblUsuario WHERE Id= @Id", dbParams));

        }
    }
}
