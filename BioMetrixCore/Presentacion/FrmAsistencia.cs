using BioMetrixCore.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioMetrixCore.Presentacion
{
    public partial class FrmAsistencia : Form
    {
        public FrmAsistencia()
        {
            InitializeComponent();
        }

        private void FrmAsistencia_Load(object sender, EventArgs e)
        {
            DataSet dse = FEmpleado.GetAll();
            DataTable dte = dse.Tables[0];
            cmbEmpleado.ValueMember = "Id";
            cmbEmpleado.DisplayMember = "NombreTexto";
            cmbEmpleado.DataSource = dte;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpDesde.Value, fechaFin = dtpHasta.Value;
            string tipo = cmbTipo.Text;
            int anio = fechaInicio.Year;
            int mes = fechaInicio.Month;
            
            if (cmbTipo.Text=="TRABAJADOR")
            {
                int col = 3, fila = 6;
                int filas = 6;

                    Microsoft.Office.Interop.Excel.Application ExApp;
                    ExApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook oWBook;
                    Microsoft.Office.Interop.Excel._Worksheet oSheet;



                    oWBook = ExApp.Workbooks.Open(Application.StartupPath + "/planilla-trabajador.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWBook.ActiveSheet;
                    foreach (DataRowView item in cmbEmpleado.Items)
                    {
                        double horas = 0;
                        double horacu = 0;
                        double horadom = 0;
                        int idEmpleado = Convert.ToInt32(item.Row[0].ToString());

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
                            oSheet.Cells[fila, col] = horas;
                            //oSheet.Cells[fila, col].Interior.Color = Color.Green;

                        }
                        // OTROS DATOS                          
                        DataSet ds2 = FAsistencia.GetAllDatos(anio, mes, idEmpleado);
                        DataTable dt2 = ds2.Tables[0];
                        if (dt2.Rows.Count > 0)
                        {
                            var empleadoId = dt2.Rows[0]["EmpleadoId"].ToString();
                            var nombreTexto = dt2.Rows[0]["NombreTexto"].ToString();
                            var apellidos = dt2.Rows[0]["Apellidos"].ToString();
                            var cargo = dt2.Rows[0]["Cargo"].ToString();
                            double salario = Convert.ToDouble(dt2.Rows[0]["Salario"].ToString());
                            double porhora = (salario / 30) / 8;

                            oSheet.Cells[fila, 1] = empleadoId;//ID EMPLEADO
                            oSheet.Cells[fila, 2] = nombreTexto + " " + apellidos;//NOMBRES APELLIDOS
                            oSheet.Cells[fila, 3] = cargo; //CARGO
                            oSheet.Cells[fila, 12] = porhora; //POR HORA
                            oSheet.Cells[fila, 13] = porhora * horacu; //BASICO
                                                                       //======DESCUENTO DOMINICAL
                                                                       //double saldo = horadom - 2;
                                                                       //double doshoras = horadom - saldo;
                                                                       //doshoras = doshoras * 1.25;
                                                                       //saldo = saldo * 1.35;
                            double dominical = ((salario / 30) * horacu) / 48;

                            oSheet.Cells[fila, 14] = dominical; //DOMINICAL

                            //======ASIGNACION FAMILIAR
                            double asigfam = 0;
                            double remMin = Convert.ToDouble(dt2.Rows[0]["RemMin"].ToString());
                            double porAsigfam = Convert.ToDouble(dt2.Rows[0]["AsigFam"].ToString());
                            porAsigfam = porAsigfam / 100;
                            if (dt2.Rows[0]["AsigFam"].ToString() == "1")
                            {
                                asigfam = ((((porAsigfam * remMin) / 30) * 7) / 48) * horacu; // ES MAS SIMPLE
                            }
                            oSheet.Cells[fila, 15] = asigfam; //ASIGNACION FAMILIAR

                            //======SNP ONP
                            double onp = Convert.ToDouble(dt2.Rows[0]["OnpDat"].ToString());
                            onp = onp / 100;
                            if (dt2.Rows[0]["Onp"].ToString() == "1")
                            {
                                oSheet.Cells[fila, 18].Formula = string.Format("=+Q" + fila + "*" + onp);
                            }

                            //======AFP COM
                            double afpCom = Convert.ToDouble(dt2.Rows[0]["AfpCom"].ToString());
                            afpCom = afpCom / 100;
                            if (dt2.Rows[0]["Afp"].ToString() == "1")
                            {
                                oSheet.Cells[fila, 19].Formula = string.Format("=+Q" + fila + "*" + afpCom);
                            }
                            //======AFP PRIM COM
                            double afpPrimCom = Convert.ToDouble(dt2.Rows[0]["AfpPrimCom"].ToString());
                            afpPrimCom = afpCom / 100;
                            if (dt2.Rows[0]["Afp"].ToString() == "1")
                            {
                                oSheet.Cells[fila, 20].Formula = string.Format("=+Q" + fila + "*" + afpPrimCom);
                            }
                            //======AFP APORTE
                            double afpApo = Convert.ToDouble(dt2.Rows[0]["AfpDat"].ToString());
                            afpApo = afpApo / 100;
                            if (dt2.Rows[0]["Afp"].ToString() == "1")
                            {
                                oSheet.Cells[fila, 21].Formula = string.Format("=+Q" + fila + "*" + afpApo);

                                // SUM
                                oSheet.Cells[fila, 22].Formula = string.Format("=SUM(S"+fila+":U"+fila);
                            }
                            //======RENTA 5                 
                            if (dt2.Rows[0]["RentaQta"].ToString() == "1")
                            {
                                oSheet.Cells[fila, 24].Formula = 0;

                            }
                            //======TOTAL DESCUENTO    
                            double totDesc = 0;
                            if (dt2.Rows[0]["Afp"].ToString() == "1")
                            {
                                oSheet.Cells[fila, 25].Formula = string.Format("=+V" + fila);

                            }
                            else if (dt2.Rows[0]["Onp"].ToString() == "1")
                            {
                                oSheet.Cells[fila, 25].Formula = string.Format("=+R" + fila + "+W" + fila + "+X" + fila + "");
                            }

                            //======NETO A PAGAR 
                            oSheet.Cells[fila, 26].Formula = string.Format("=+Y" + fila);

                            //======ESSALUD
                            double essalud = Convert.ToDouble(dt2.Rows[0]["Essalud"].ToString());
                            essalud = essalud / 100;
                            oSheet.Cells[fila, 27].Formula = string.Format("=+Q" + fila + "*" + essalud);

                            //======ACCIDENTE DE TRABAJO
                            double basico = (porhora * horacu);
                            double accid = basico * 0.013;
                            oSheet.Cells[fila, 29].Formula = accid;

                            //======TOTAL APORTAC                  
                            //oSheet.Cells[fila, 30].Formula = string.Format("=SUMA(AA" + fila + ":AC" + fila);
                            oSheet.Cells[fila, 30].Formula = string.Format("=SUM(AA" + fila + ":AC" + fila);

                            col = 3;
                            fila++;
                            horas = 0;
                            horacu = 0;
                        }

                    }

                //APLICANDO TOTALES
                int filaTotal = filas + 1;         
                
                oSheet.Cells[filaTotal, 13].Formula = string.Format("=SUM(M6:M"+filas); //TOTAL BASICO               
                oSheet.Cells[filaTotal, 14].Formula = string.Format("=SUM(N6:N"+filas); //DOMINICAL
                oSheet.Cells[filaTotal, 15].Formula = string.Format("=SUM(N6:N" + filas); 
                oSheet.Cells[filaTotal, 16].Formula = string.Format("=SUM(O6:O" + filas); 
                oSheet.Cells[filaTotal, 17].Formula = string.Format("=SUM(P6:P" + filas); 
                oSheet.Cells[filaTotal, 18].Formula = string.Format("=SUM(Q6:Q" + filas); 
                oSheet.Cells[filaTotal, 19].Formula = string.Format("=SUM(R6:R" + filas); 
                oSheet.Cells[filaTotal, 20].Formula = string.Format("=SUM(S6:S" + filas); 
                oSheet.Cells[filaTotal, 21].Formula = string.Format("=SUM(T6:T" + filas); 
                oSheet.Cells[filaTotal, 22].Formula = string.Format("=SUM(U6:U" + filas); 
                oSheet.Cells[filaTotal, 23].Formula = string.Format("=SUM(V6:V" + filas); 
                oSheet.Cells[filaTotal, 24].Formula = string.Format("=SUM(W6:W" + filas); 
                oSheet.Cells[filaTotal, 25].Formula = string.Format("=SUM(X6:X" + filas); 
                oSheet.Cells[filaTotal, 26].Formula = string.Format("=SUM(Y6:Y" + filas); 
                oSheet.Cells[filaTotal, 27].Formula = string.Format("=SUM(Z6:Z" + filas); 
                oSheet.Cells[filaTotal, 28].Formula = string.Format("=SUM(AA6:AA" + filas); 
                oSheet.Cells[filaTotal, 29].Formula = string.Format("=SUM(AB6:AB" + filas); 
                oSheet.Cells[filaTotal, 30].Formula = string.Format("=SUM(AC6:AC" + filas);

                oSheet.get_Range("M" + filaTotal+":AD"+filaTotal, Type.Missing).Font.Bold = true;
                oSheet.get_Range("M" + filaTotal + ":AD" + filaTotal, Type.Missing).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                //========================SECCION EXCEL
                ExApp.Visible = false;
                    ExApp.UserControl = true;
                    ExApp.DisplayAlerts = false;

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);

                    oWBook.Save();
                    //ExApp.ActiveWorkbook.Close(true, Application.StartupPath+"/planilla-"+ DateTime.Now +".xlsx", Type.Missing);
                    oWBook.SaveAs(Application.StartupPath + "/planilla-trabajador(copy).xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    oWBook.Close(true);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);
                    ExApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(ExApp);
            
                    MessageBox.Show("ok");

            }
            else if (cmbTipo.Text == "EMPLEADO")
            {
                int col = 3, fila = 7;
                int filas = 7;

                Microsoft.Office.Interop.Excel.Application ExApp;
                ExApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook oWBook;
                Microsoft.Office.Interop.Excel._Worksheet oSheet;



                oWBook = ExApp.Workbooks.Open(Application.StartupPath + "/planilla-empleado.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWBook.ActiveSheet;
                foreach (DataRowView item in cmbEmpleado.Items)
                {
                    double horas = 0;
                    double horacu = 0;
                    double horadom = 0;
                    int idEmpleado = Convert.ToInt32(item.Row[0].ToString());

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
                        oSheet.Cells[fila, col] = horas;
                        //oSheet.Cells[fila, col].Interior.Color = Color.Green;

                    }
                    // OTROS DATOS                          
                    DataSet ds2 = FAsistencia.GetAllDatos(anio, mes, idEmpleado);
                    DataTable dt2 = ds2.Tables[0];
                    if (dt2.Rows.Count > 0)
                    {
                        var empleadoId = dt2.Rows[0]["EmpleadoId"].ToString();
                        var nombreTexto = dt2.Rows[0]["NombreTexto"].ToString();
                        var apellidos = dt2.Rows[0]["Apellidos"].ToString();
                        var cargo = dt2.Rows[0]["Cargo"].ToString();
                        double salario = Convert.ToDouble(dt2.Rows[0]["Salario"].ToString());
                        double porhora = (salario / 30) / 8;

                        oSheet.Cells[fila, 1] = empleadoId;//ID EMPLEADO
                        oSheet.Cells[fila, 2] = nombreTexto + " " + apellidos;//NOMBRES APELLIDOS
                        oSheet.Cells[fila, 3] = cargo; //CARGO
                        oSheet.Cells[fila, 6] = porhora; //POR HORA
                        oSheet.Cells[fila, 8] = salario; //BASICO
                                                                   
                       

                        //======ASIGNACION FAMILIAR
                        double asigfam = 0;
                        double remMin = Convert.ToDouble(dt2.Rows[0]["RemMin"].ToString());
                        double porAsigfam = Convert.ToDouble(dt2.Rows[0]["AsigFam"].ToString());
                        porAsigfam = porAsigfam / 100;
                        if (dt2.Rows[0]["AsigFam"].ToString() == "1")
                        {
                            asigfam = porAsigfam * remMin; // ES MAS SIMPLE
                            if (asigfam<930)
                            {
                                asigfam = porAsigfam* salario;
                            }
                        }
                        oSheet.Cells[fila, 9] = asigfam; //ASIGNACION FAMILIAR

                        oSheet.Cells[fila, 11].Formula = string.Format("=+H" + fila + "+I"+fila+"-J"+fila); //TOTAL

                        //======SNP ONP
                        double onp = Convert.ToDouble(dt2.Rows[0]["OnpDat"].ToString());
                        onp = onp / 100;
                        if (dt2.Rows[0]["Onp"].ToString() == "1")
                        {
                            oSheet.Cells[fila, 13].Formula = string.Format("=+K" + fila + "*" + onp);
                        }

                        //======AFP COM
                        double afpCom = Convert.ToDouble(dt2.Rows[0]["AfpCom"].ToString());
                        afpCom = afpCom / 100;
                        if (dt2.Rows[0]["Afp"].ToString() == "1")
                        {
                            oSheet.Cells[fila, 14].Formula = string.Format("=+K" + fila + "*" + afpCom);
                        }
                        //======AFP PRIM COM
                        double afpPrimCom = Convert.ToDouble(dt2.Rows[0]["AfpPrimCom"].ToString());
                        afpPrimCom = afpCom / 100;
                        if (dt2.Rows[0]["Afp"].ToString() == "1")
                        {
                            oSheet.Cells[fila, 15].Formula = string.Format("=+K" + fila + "*" + afpPrimCom);
                        }
                        //======AFP APORTE
                        double afpApo = Convert.ToDouble(dt2.Rows[0]["AfpDat"].ToString());
                        afpApo = afpApo / 100;
                        if (dt2.Rows[0]["Afp"].ToString() == "1")
                        {
                            oSheet.Cells[fila, 16].Formula = string.Format("=+K" + fila + "*" + afpApo);

                            // SUM
                            oSheet.Cells[fila, 17].Formula = string.Format("=SUM(N"+fila  +":P"+ fila);
                        }
                        //======RENTA 5                 
                        if (dt2.Rows[0]["RentaQta"].ToString() == "1")
                        {
                            oSheet.Cells[fila, 18].Formula = 0;

                        }
                        //======TOTAL DESCUENTO    
                        double totDesc = 0;
                        if (dt2.Rows[0]["Afp"].ToString() == "1")
                        {
                            oSheet.Cells[fila, 20].Formula = string.Format("=+Q" + fila + "+R" + fila + "+S" + fila + "");

                        }
                        else if (dt2.Rows[0]["Onp"].ToString() == "1")
                        {
                            oSheet.Cells[fila, 20].Formula = string.Format("=+M" + fila + "+S" + fila);
                        }

                        //======NETO A PAGAR 
                        oSheet.Cells[fila, 22].Formula = string.Format("=+K" + fila + "+T" + fila + "+U" + fila + "");

                        //======ESSALUD
                        double essalud = Convert.ToDouble(dt2.Rows[0]["Essalud"].ToString());
                        essalud = essalud / 100;
                        oSheet.Cells[fila, 23].Formula = string.Format("=+K" + fila + "*" + essalud);

                        //======ACCIDENTE DE TRABAJO
                        //double basico = (porhora * horacu);
                        //double accid = basico * 0.013;
                        //oSheet.Cells[fila, 27].Formula = accid;

                        //======TOTAL APORTAC                  
                        oSheet.Cells[fila, 25].Formula = string.Format("=+W" + fila + "+X" + fila);

                        col = 3;
                        fila++;
                        horas = 0;
                        horacu = 0;
                    }

                }

                //APLICANDO TOTALES
                int filaTotal = filas + 1;

                oSheet.Cells[filaTotal, 7].Formula = string.Format("=SUM(G7:G" + filas); //TOTAL BASICO               
                oSheet.Cells[filaTotal, 8].Formula = string.Format("=SUM(H7:H" + filas); 
                oSheet.Cells[filaTotal, 9].Formula = string.Format("=SUM(I7:I" + filas);
                oSheet.Cells[filaTotal, 10].Formula = string.Format("=SUM(J7:J" + filas);
                oSheet.Cells[filaTotal, 11].Formula = string.Format("=SUM(K7:K" + filas);

                oSheet.Cells[filaTotal, 13].Formula = string.Format("=SUM(M7:M" + filas);
                oSheet.Cells[filaTotal, 14].Formula = string.Format("=SUM(N7:N" + filas);
                oSheet.Cells[filaTotal, 15].Formula = string.Format("=SUM(O7:O" + filas);
                oSheet.Cells[filaTotal, 16].Formula = string.Format("=SUM(P7:P" + filas);
                oSheet.Cells[filaTotal, 17].Formula = string.Format("=SUM(Q7:Q" + filas);
                oSheet.Cells[filaTotal, 18].Formula = string.Format("=SUM(R7:R" + filas);
                oSheet.Cells[filaTotal, 19].Formula = string.Format("=SUM(S7:S" + filas);
                oSheet.Cells[filaTotal, 20].Formula = string.Format("=SUM(T7:T" + filas);
                oSheet.Cells[filaTotal, 21].Formula = string.Format("=SUM(U7:U" + filas);
                oSheet.Cells[filaTotal, 22].Formula = string.Format("=SUM(V7:V" + filas);
                oSheet.Cells[filaTotal, 23].Formula = string.Format("=SUM(W7:W" + filas);
                oSheet.Cells[filaTotal, 24].Formula = string.Format("=SUM(X7:X" + filas);
                oSheet.Cells[filaTotal, 25].Formula = string.Format("=SUM(Y7:Y" + filas);

                oSheet.get_Range("A" + filaTotal + ":Y" + filaTotal, Type.Missing).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                oSheet.get_Range("G" + filaTotal + ":Y" + filaTotal, Type.Missing).Font.Bold = true;
                oSheet.get_Range("G" + filaTotal + ":Y" + filaTotal, Type.Missing).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


                //========================SECCION EXCEL
                ExApp.Visible = false;
                ExApp.UserControl = true;
                ExApp.DisplayAlerts = false;

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);

                oWBook.Save();
                //ExApp.ActiveWorkbook.Close(true, Application.StartupPath+"/planilla-"+ DateTime.Now +".xlsx", Type.Missing);
                oWBook.SaveAs(Application.StartupPath + "/planilla-empleado(copy).xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                oWBook.Close(true);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);
                ExApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExApp);

                MessageBox.Show("ok");
            }
        }
    }
}
