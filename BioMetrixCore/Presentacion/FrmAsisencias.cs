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
    }
}
