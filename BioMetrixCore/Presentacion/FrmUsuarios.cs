using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioMetrixCore.Datos;

namespace BioMetrixCore.Presentacion
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }
        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;
        public bool estado;
        public int numeroDispositivo;
        private void Usuarios_Load(object sender, EventArgs e)
        {
            if(estado)
            {
                lblStatus.Text = "En linea";
                lblStatus.BackColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "Desconectado";
                lblStatus.BackColor = Color.Red;
            }
           
        }
        private void btnDatosDispositivo_Click(object sender, EventArgs e)
        {
            try
            {

                ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, numeroDispositivo);
                if (lstFingerPrintTemplates != null && lstFingerPrintTemplates.Count > 0)
                {
                    BindToGridView(lstFingerPrintTemplates);
                }
                else
                    DisplayListOutput("No se encontraron Datos.");
            }
            catch (Exception ex)
            {
                //DisplayListOutput(ex.Message);
                MessageBox.Show(ex.Message);
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

        private void btnListaLocal_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = FUsuario.GetAll();
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
