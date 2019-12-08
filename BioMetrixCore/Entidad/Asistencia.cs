using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMetrixCore.Entidad
{
    public class Asistencia
    {
        private int _id, _numeroEquipo, _modoAcceso, _tipoRegistro;
        private double _codigoEmpleado;
        private DateTime _fecha;

        public int Id { get => _id; set => _id = value; }
        public int NumeroEquipo { get => _numeroEquipo; set => _numeroEquipo = value; }
        public int ModoAcceso { get => _modoAcceso; set => _modoAcceso = value; }
        public int TipoRegistro { get => _tipoRegistro; set => _tipoRegistro = value; }
        public double CodigoEmpleado { get => _codigoEmpleado; set => _codigoEmpleado = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
       
    }
}
