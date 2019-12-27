using BioMetrixCore.Datos;
using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioMetrixCore.Presentacion
{
    public partial class FrmBoletaMensual : Form
    {
        public FrmBoletaMensual()
        {
            InitializeComponent();
        }

        private void FrmBoletaMensual_Load(object sender, EventArgs e)
        {
            DataSet dse = FEmpleado.GetAll();
            DataTable dte = dse.Tables[0];
            cmbPersona.ValueMember = "Id";
            cmbPersona.DisplayMember = "NombreTexto";
            cmbPersona.DataSource = dte;
        }

        private void btnBoleta_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpDesde.Value, fechaFin = dtpHasta.Value;
            string tipo = cmbTipo.Text;
            int anio = fechaInicio.Year;
            int mes = fechaInicio.Month;

            string nombreTexto = "", apellidos="",cargo="";
            double salario = 0, porhora = 0, dominical = 0, asigFam = 0, remMin = 0, desc = 0, essalud = 0, acctra = 0, onp = 0, salarioTotal = 0, afpApo = 0, afpPrimCom = 0, afpCom=0;

            int col = 3, fila = 7;
                int filas = 7;

                    double horas = 0;
                    double horacu = 0;
                    double horadom = 0;
                    int idEmpleado = Convert.ToInt32(cmbPersona.SelectedValue.ToString());

                    filas++;

                    for (var d = fechaInicio; d <= fechaFin; d = d.AddDays(1))
                    {
                        DataSet ds = FAsistencia.GetFechas(Convert.ToDateTime(d.ToShortDateString()), idEmpleado, tipo);
                        DataTable dt = ds.Tables[0];
                        col++;

                        if (d.DayOfWeek == DayOfWeek.Sunday)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                horadom = Convert.ToDouble(dt.Rows[0]["HorasAc"]);
                            }
                        }

                        else
                        {
                            if (dt.Rows.Count > 0)
                            {
                                horas = Convert.ToDouble(dt.Rows[0]["HorasAc"]);
                                horacu += horas;
                            }

                        }                   

                    }
                    // OTROS DATOS                          
                    DataSet ds2 = FAsistencia.GetAllDatos(anio, mes, idEmpleado);
                    DataTable dt2 = ds2.Tables[0];
                    if (dt2.Rows.Count > 0)
                    {        
                        nombreTexto = dt2.Rows[0]["NombreTexto"].ToString();
                        apellidos = dt2.Rows[0]["Apellidos"].ToString();
                        cargo = dt2.Rows[0]["Cargo"].ToString();
                        salario = Convert.ToDouble(dt2.Rows[0]["Salario"].ToString());
                        porhora = (salario / 30) / 8;
                        dominical = ((salario / 30) * horacu) / 48;
                        salarioTotal = (horacu * porhora) + dominical + asigFam - desc;

                        //======ASIGNACION FAMILIAR
                        remMin = Convert.ToDouble(dt2.Rows[0]["RemMin"].ToString());
                        double porAsigfam = Convert.ToDouble(dt2.Rows[0]["AsigFam"].ToString());
                        porAsigfam = porAsigfam / 100;
                        if (dt2.Rows[0]["AsigFam"].ToString() == "1")
                        {
                            asigFam = porAsigfam * remMin; // ES MAS SIMPLE
                            if (asigFam < 930)
                            {
                                asigFam = porAsigfam * salario;
                            }
                        }

                        //======SNP ONP
                        onp = Convert.ToDouble(dt2.Rows[0]["OnpDat"].ToString());
                        onp = onp / 100;
                        if (dt2.Rows[0]["Onp"].ToString() == "1")
                        {
                             onp= salarioTotal * onp;
                        }

                        //======AFP COM
                        afpCom = Convert.ToDouble(dt2.Rows[0]["AfpCom"].ToString());
                        afpCom = afpCom / 100;
                        if (dt2.Rows[0]["Afp"].ToString() == "1")
                        {
                            afpCom=salarioTotal + afpCom;
                        }
                        //======AFP PRIM COM
                        afpPrimCom = Convert.ToDouble(dt2.Rows[0]["AfpPrimCom"].ToString());
                        afpPrimCom = afpCom / 100;
                        if (dt2.Rows[0]["Afp"].ToString() == "1")
                        {
                            afpPrimCom = salarioTotal* afpPrimCom;
                        }
                        //======AFP APORTE
                        afpApo = Convert.ToDouble(dt2.Rows[0]["AfpDat"].ToString());
                        afpApo = afpApo / 100;
                        if (dt2.Rows[0]["Afp"].ToString() == "1")
                        {
                             afpApo= salarioTotal * afpApo;

                        }
                        //======RENTA 5                 
                        if (dt2.Rows[0]["RentaQta"].ToString() == "1")
                        {
                            //oSheet.Cells[fila, 18].Formula = 0;

                        }
                        //======TOTAL DESCUENTO    
                        double totDesc = 0;
                        if (dt2.Rows[0]["Afp"].ToString() == "1")
                        {
                           // oSheet.Cells[fila, 20].Formula = string.Format("=+Q" + fila + "+R" + fila + "+S" + fila + "");

                        }
                        else if (dt2.Rows[0]["Onp"].ToString() == "1")
                        {
                            //oSheet.Cells[fila, 20].Formula = string.Format("=+M" + fila + "+S" + fila);
                        }

                        //======NETO A PAGAR 
                        //oSheet.Cells[fila, 22].Formula = string.Format("=+K" + fila + "+T" + fila + "+U" + fila + "");

                        //======ESSALUD
                        essalud = Convert.ToDouble(dt2.Rows[0]["Essalud"].ToString());
                        essalud = essalud / 100;

                        essalud = ((horacu * porhora) + dominical + asigFam - desc) * essalud;

                        //======ACCIDENTE DE TRABAJO
                        
                        acctra = salarioTotal * 0.013;
                        //oSheet.Cells[fila, 27].Formula = accid;

                        //======TOTAL APORTAC                  
                        //oSheet.Cells[fila, 25].Formula = string.Format("=+W" + fila + "+X" + fila);

                        col = 3;
                        fila++;
                        horas = 0;
                        horacu = 0;
                    }

            //REPORTE

            string hula= ConfigurationManager.AppSettings.Get("connectionString");
            Report report = new Report();
            report.Load(@"Reportes/Boleta.frx");
            //report.Dictionary.Connections[0].ConnectionString = hula;
            report.SetParameterValue("Nombres", nombreTexto+ " "+apellidos);
            report.SetParameterValue("Cargo", cargo);
            report.SetParameterValue("Basico", salario);
            report.SetParameterValue("Dominical", dominical);
            report.SetParameterValue("AsigFam", asigFam);
            report.SetParameterValue("RegimenPs", essalud);
            report.SetParameterValue("AccTra", acctra);

            report.SetParameterValue("RegimenPensiones", onp);
            report.SetParameterValue("AporteAfp", afpApo);
            report.SetParameterValue("SeguroSobrevivencia", afpPrimCom);
            report.SetParameterValue("ComisionAfp", afpCom); 

            report.Show();





        }
    }
}
