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
    public partial class FrmDatosMensuales : Form
    {
        public FrmDatosMensuales()
        {
            InitializeComponent();
        }
        private static DataTable dt = new DataTable();
        private void FrmDatosMensuales_Load(object sender, EventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmDatosAnualesRegistrar form = new FrmDatosAnualesRegistrar();
            form.txtId.Text = "";
            form.ShowDialog();
            FrmDatosMensuales_Load(null, null);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                //Id, EmpleadoId, AfpCom, AfpPrimCom, Basico, MesId, AnioId
                FrmDatosAnualesRegistrar form = new FrmDatosAnualesRegistrar();
                form.txtId.Text = dgvDatos.CurrentRow.Cells["Id"].Value.ToString();
                form.cmbAnio.Text = dgvDatos.CurrentRow.Cells["Anio"].Value.ToString();
                form.txtAsigfam.Text = dgvDatos.CurrentRow.Cells["Asigfam"].Value.ToString();
                form.txtRemMin.Text = dgvDatos.CurrentRow.Cells["RemMin"].Value.ToString();
                form.txtEssalud.Text = dgvDatos.CurrentRow.Cells["Essalud"].Value.ToString();
                form.txtSnp.Text = dgvDatos.CurrentRow.Cells["Onpdat"].Value.ToString();
                form.txtAfp.Text = dgvDatos.CurrentRow.Cells["AfpDat"].Value.ToString();
                form.ShowDialog();
                FrmDatosMensuales_Load(null, null);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar el registro seleccionado? \n Si no agrega otros datos, el sistema puede dejar de funcionar.", "Eliminar Registro",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        if (FDatosAnuales.Eliminar(Convert.ToInt32(dgvDatos.CurrentRow.Cells["Id"].Value.ToString())) > 0)
                        {
                            FrmDatosMensuales_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar...", "No se puede eliminar");

                        }
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
                DataSet ds = FDatosMensuales.GetFiltro(Convert.ToInt32(cmbEmpleado.SelectedValue.ToString()), cmbAnio.Text, cmbMes.Text);
                dt = ds.Tables[0];
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = FDatosMensuales.GetFiltro(Convert.ToInt32(cmbEmpleado.SelectedValue.ToString()), cmbAnio.Text, cmbMes.Text);
                dt = ds.Tables[0];
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = FDatosMensuales.GetFiltro(Convert.ToInt32(cmbEmpleado.SelectedValue.ToString()), cmbAnio.Text, cmbMes.Text);
                dt = ds.Tables[0];
                dgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            FrmDatosMensuales_Load(null,null);
        }
    }
}
