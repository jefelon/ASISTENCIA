using BioMetrixCore.Datos;
using BioMetrixCore.Entidad;
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
    public partial class FrmAsisencias : Form
    {
        public FrmAsisencias()
        {
            InitializeComponent();
        }

        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;
        public bool estado;
        public int numeroDispositivo;
        private static DataTable dt = new DataTable();
        private void FrmAsisencias_Load(object sender, EventArgs e)
        {
            DataSet dse = FEmpleado.GetAll();
            DataTable dte = dse.Tables[0];
            cmbEmpleado.ValueMember = "Id";
            cmbEmpleado.DisplayMember = "NombreTexto";
            cmbEmpleado.DataSource = dte;

            DataSet dse2 = FEmpleado.GetAll();
            DataTable dte2 = dse2.Tables[0];
            cmbEmp.ValueMember = "Id";
            cmbEmp.DisplayMember = "NombreTexto";
            cmbEmp.DataSource = dte2;

            if (estado)
            {
                lblStatus.Text = "Conectado.";
                lblStatus.BackColor = Color.Green;
            }
            else
            {
                lblStatus.BackColor = Color.Red;
                lblStatus.Text = "Desconectado.";
            }
        }

        private void btnDatosDispositivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado==true)
                {
                    ClearGrid();
                    ICollection<MachineInfo> lstMachineInfo = manipulator.GetLogData(objZkeeper, numeroDispositivo);

                    if (lstMachineInfo != null && lstMachineInfo.Count > 0)
                    {
                        BindToGridView(lstMachineInfo);
                        DisplayListOutput(lstMachineInfo.Count + " regristros encontrados!!");
                    }
                    else
                        DisplayListOutput("No se encontraro registros.");
                }
                else
                {
                    MessageBox.Show("Conéctese al dispositivo de asistencia.");
                }
            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }
        }
        private void BindToGridView(object list)
        {
            ClearGrid();
            dgvDatos.DataSource = list;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UniversalStatic.ChangeGridProperties(dgvDatos);
        }
        private void DisplayListOutput(string message)
        {
            if (dgvDatos.Controls.Count > 2)
            { dgvDatos.Controls.RemoveAt(2); }

        }
        private void ClearGrid()
        {
            if (dgvDatos.Controls.Count > 2)
            { dgvDatos.Controls.RemoveAt(2); }


            dgvDatos.DataSource = null;
            dgvDatos.Controls.Clear();
            dgvDatos.Rows.Clear();
            dgvDatos.Columns.Clear();
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado==true)
                {
                    if (MessageBox.Show("¿Está seguro de sincronizar el dispositivo con la base de datos.?  Esto es lo que pasará. \n " +
                    "Se eliminará todo y se insertará nuevamente todos los registros.", "Sincronizando...",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow row in dgvDatos.Rows)
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.NumeroEquipo = Convert.ToInt32(row.Cells["NumeroEquipo"].Value.ToString());
                            asistencia.CodigoEmpleado = Convert.ToDouble(row.Cells["CodigoEmpleado"].Value.ToString());
                            asistencia.ModoAcceso = Convert.ToInt32(row.Cells["ModoAcceso"].Value.ToString());
                            asistencia.TipoRegistro = Convert.ToInt32(row.Cells["TipoRegistro"].Value.ToString());
                            asistencia.Fecha = Convert.ToDateTime(row.Cells["Fecha"].Value.ToString());


                            int returnDetalleId = FAsistencia.InsertarIngreso(asistencia);
                            

                        }
                    }

                    MessageBox.Show("Se sincronizó correctamente.");
                }
                else
                {
                    MessageBox.Show("Conéctese al dispositivo de asistencia.");
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnListaLocal_Click(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();
                DataSet ds = FAsistencia.GetAll();
                dt = ds.Tables[0];
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();


                DateTime fechaInicio = dtpDesde.Value, fechaFin = dtpHasta.Value;
                int anio = fechaInicio.Year;
                int mes = fechaInicio.Month;
                int col = 3, fila = 6;
                int filas = 0;

                Microsoft.Office.Interop.Excel.Application ExApp;
                ExApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook oWBook;
                Microsoft.Office.Interop.Excel._Worksheet oSheet;



                oWBook = ExApp.Workbooks.Open(Application.StartupPath+"/planilla.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
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
                        DataSet ds = FAsistencia.GetFechas(Convert.ToDateTime(d.ToShortDateString()), idEmpleado);
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
                        oSheet.Cells[fila, col].Interior.Color = Color.Green;

                    }
                    // OTROS DATOS                          
                    DataSet ds2 = FAsistencia.GetAllDatos(anio, mes, idEmpleado);
                    DataTable dt2 = ds2.Tables[0];
                    if (dt2.Rows.Count > 0) { 
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
                            oSheet.Cells[fila, 22].Formula = string.Format("=SUMA(S10: U10");
                        }
                        //======RENTA 5                 
                        if (dt2.Rows[0]["Afp"].ToString() == "1")
                        {
                            // oSheet.Cells[fila, 24].Formula = string.Format("=Q" + fila + "*" + afpApo + "");

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
                        double accid= basico* 0.013;
                        oSheet.Cells[fila, 27].Formula = accid;

                        //======TOTAL APORTAC                  
                        oSheet.Cells[fila, 27].Formula = string.Format("=SUMA(AA8:AC8)");

                        col = 3;
                        fila++;
                        horas = 0;
                        horacu = 0;
                    }

                }

                //APLICANDO TOTALES
                //filas = filas + 1;
                //int i;
                //for (i = 13; i <= 30; i++)
                //{
                //    oSheet.Cells[filas, i].Formula = string.Format("=SUMA(L6:L14)");
                //}

                //========================SECCION EXCEL
                ExApp.Visible = false;
                ExApp.UserControl = true;
                ExApp.DisplayAlerts = false;

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);

                oWBook.Save();
                //ExApp.ActiveWorkbook.Close(true, Application.StartupPath+"/planilla-"+ DateTime.Now +".xlsx", Type.Missing);
                oWBook.SaveAs(Application.StartupPath + "/planilla(copy).xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                oWBook.Close(true);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);
                ExApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExApp);


                MessageBox.Show("ok");
                //====================FIN SECCION EXCEL

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBorrarBase_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de eliminar todos los registros de asistencia de la base de datos? \n Se eliminara todo, sin posibilidad de recuperar. \n " +
                    "No se borrará del dispositivo de asistrencia.", "Eliminar Asistencias",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    if (FAsistencia.EliminarTodo() > 0)
                    {
                        FrmAsisencias_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar...", "No se puede eliminar");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cmbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt.Copy()); //dt es la tabla que creamos al inicio de esta hoja
                dv.RowFilter = " NombreTexto Like '" + cmbEmp.Text + "%'";
                dgvDatos.DataSource = dv;
            }
            catch
            {

            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();
                DataSet ds = FAsistencia.GetFiltro(Convert.ToInt32(cmbEmp.SelectedValue.ToString()), dtpDesde.Value, dtpHasta.Value);
                dt = ds.Tables[0];
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();
                DataSet ds = FAsistencia.GetFiltro(Convert.ToInt32(cmbEmp.SelectedValue.ToString()), dtpDesde.Value, dtpHasta.Value);
                dt = ds.Tables[0];
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
