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

            txtNumDispositivo.Text = numeroDispositivo.ToString();

            botones(false);
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
                    {
                        DisplayListOutput("No se encontraro registros.");
                    }

                    btnSincronizar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Conéctese al dispositivo de asistencia.");
                    btnSincronizar.Enabled = false;
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
                    "Se insertará solo los nuevos registros.", "Sincronizando...",
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

                            DataSet ds = FAsistencia.Comparar(asistencia.NumeroEquipo,asistencia.CodigoEmpleado,asistencia.Fecha);
                            DataTable dt2 = ds.Tables[0];
                            //dgvDatos.DataSource = dt;

                            if (dt2.Rows.Count>0)
                            {
                                //int returnDetalleId = FAsistencia.Actualizar(asistencia);
                            }

                            else
                            {
                                int returnDetalleId = FAsistencia.Insertar(asistencia);
                            }                          
                            

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

                dgvDatos.Columns["Id"].Visible = false;
                dgvDatos.Columns["NumeroEquipo"].Visible = false;

                botones(true);
                btnSincronizar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            
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
                ClearGrid();
                DataSet ds = FAsistencia.GetFiltro(Convert.ToInt32(cmbEmp.SelectedValue.ToString()), dtpDesde.Value, dtpHasta.Value,cmbTipo.Text);
                dt = ds.Tables[0];
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();
                DataSet ds = FAsistencia.GetFiltro(Convert.ToInt32(cmbEmp.SelectedValue.ToString()), dtpDesde.Value, dtpHasta.Value,cmbTipo.Text);
                dt = ds.Tables[0];
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {
            FrmAgregarAsistencia frm = new FrmAgregarAsistencia();
            frm.txtNumDispositivo.Text = txtNumDispositivo.Text;
            frm.ShowDialog();
            btnListaLocal.PerformClick();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de eliminar este registro de la base de datos? \n " +
                    "No se borrará del dispositivo de asistencia. Si sincroniza nuevamente, volverá a aparecer.", "Eliminar Asistencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Id"].Value.ToString());

                    Asistencia asistencia = new Asistencia();
                    asistencia.Id = id;
                    if (FAsistencia.Eliminar(asistencia) > 0)
                    {
                        btnListaLocal.PerformClick();
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

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHorasExtras_Click(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();
                DataSet ds = FAsistencia.GetHoraExtraFecha(dtpDesde.Value,dtpHasta.Value);
                dt = ds.Tables[0];
                dgvDatos.DataSource = dt;

                botones(false);
                dgvDatos.Columns["Horas"].Width = 50;
                dgvDatos.Columns["Minutos"].Width = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void botones(bool estado)
        {
            btnSincronizar.Enabled = estado;
            btnBorrar.Enabled = estado;
            btnAgregarRegistro.Enabled = estado;
            btnBorrar.Enabled = estado;
            cmbTipo.Enabled = estado;
            cmbEmp.Enabled = estado;
            btnFiltrar.Enabled = estado;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(dgvDatos);
        }
        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < grd.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

    }
}
