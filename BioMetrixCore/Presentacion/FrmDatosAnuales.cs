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
    public partial class FrmDatosAnuales : Form
    {
        public FrmDatosAnuales()
        {
            InitializeComponent();
        }

        private void FrmDatosAnuales_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet dse = FDatosAnuales.GetAnio();
                DataTable dte = dse.Tables[0];
                cmbAnio.ValueMember = "Id";
                cmbAnio.DisplayMember = "Anio";
                cmbAnio.DataSource = dte;


                DataSet ds = FDatosAnuales.GetAll();
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
            FrmDatosAnuales_Load(null,null);
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
                            FrmDatosAnuales_Load(null, null);
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                //Id, AnioId, AsigFam, RemMin, Essalud, OnpDat, AfpDat, Uit;
                FrmDatosAnualesRegistrar form = new FrmDatosAnualesRegistrar();
                form.txtId.Text = dgvDatos.CurrentRow.Cells["Id"].Value.ToString();
                form.cmbAnio.Text = dgvDatos.CurrentRow.Cells["Anio"].Value.ToString();
                form.txtAsigfam.Text = dgvDatos.CurrentRow.Cells["Asigfam"].Value.ToString();
                form.txtRemMin.Text = dgvDatos.CurrentRow.Cells["RemMin"].Value.ToString();
                form.txtEssalud.Text = dgvDatos.CurrentRow.Cells["Essalud"].Value.ToString();
                form.txtSnp.Text = dgvDatos.CurrentRow.Cells["Onpdat"].Value.ToString();
                form.txtAfp.Text = dgvDatos.CurrentRow.Cells["AfpDat"].Value.ToString();
                form.txtUit.Text = dgvDatos.CurrentRow.Cells["Uit"].Value.ToString();
                form.ShowDialog();
                FrmDatosAnuales_Load(null, null);
            }
        }
    }
}
