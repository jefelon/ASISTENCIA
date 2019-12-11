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
    public partial class FrmDatosMensualesRegistrar : Form
    {
        public FrmDatosMensualesRegistrar()
        {
            InitializeComponent();
        }

        private void FrmDatosMensualesRegistrar_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet dsem = FEmpleado.GetAll();
                DataTable dtem = dsem.Tables[0];
                cmbEmpleado.ValueMember = "Id";
                cmbEmpleado.DisplayMember = "NombreTexto";
                cmbEmpleado.DataSource = dtem;

                DataSet dse = FDatosAnuales.GetAnio();
                DataTable dte = dse.Tables[0];
                cmbAnio.ValueMember = "Id";
                cmbAnio.DisplayMember = "Anio";
                cmbAnio.DataSource = dte;

                DataSet ds2 = FDatosMensuales.GetMes();
                DataTable dt2 = ds2.Tables[0];
                cmbMes.ValueMember = "Id";
                cmbMes.DisplayMember = "Mes";
                cmbMes.DataSource = dt2;


                DataSet ds = FDatosMensuales.GetAll();
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
