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
        private void FrmAsisencias_Load(object sender, EventArgs e)
        {

        }

        private void btnDatosDispositivo_Click(object sender, EventArgs e)
        {
            try
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
                if (1 >= 1)
                {

                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        Asistencia asistencia = new Asistencia();
                        asistencia.NumeroEquipo= Convert.ToInt32(row.Cells["NumeroEquipo"].Value.ToString());
                        asistencia.CodigoEmpleado= Convert.ToDouble(row.Cells["CodigoEmpleado"].Value.ToString());
                        asistencia.ModoAcceso= Convert.ToInt32(row.Cells["ModoAcceso"].Value.ToString());
                        asistencia.TipoRegistro= Convert.ToInt32(row.Cells["TipoRegistro"].Value.ToString());
                        asistencia.Fecha= Convert.ToDateTime(row.Cells["Fecha"].Value.ToString());

                        if (Convert.ToInt32(row.Cells["TipoRegistro"].Value.ToString())==0)//ingreso
                        {
                            int returnDetalleId = FAsistencia.InsertarIngreso(asistencia);
                        }
                        else if (Convert.ToInt32(row.Cells["TipoRegistro"].Value.ToString()) == 5)//salida
                        {
                            int returnDetalleId = FAsistencia.InsertarSalida(asistencia);
                        }
                        

                    }

                    MessageBox.Show("Se sincronizó correctamente.");
                }
                else
                {
                    //Productor productor = new Productor();
                    //productor.Id = Convert.ToInt32(txtCodigo.Text);

                    //int returnId = FProductor.Actualizar(productor);
                    //Close();
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
                DataSet ds = FAsistencia.GetAllFechas();
                DataTable dt = ds.Tables[0];
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
