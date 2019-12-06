using System;

namespace BioMetrixCore
{
    public class MachineInfo
    {
        public int NumeroEquipo { get; set; }
        public int CodigoEmpleado { get; set; }
        public int ModoAcceso { get; set; }
        public int TipoRegistro { get; set; }
        
        public string Fecha { get; set; }

        //public DateTime DateOnlyRecord
        //{
        //    get { return DateTime.Parse(DateTime.Parse(Fecha).ToString("yyyy-MM-dd")); }
        //}
        //public DateTime TimeOnlyRecord
        //{
        //    get { return DateTime.Parse(DateTime.Parse(Fecha).ToString("hh:mm:ss tt")); }
        //}

    }
}
