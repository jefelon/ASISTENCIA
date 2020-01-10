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
    public partial class FrmPersonales : Form
    {
        public FrmPersonales()
        {
            InitializeComponent();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            try
            {               
                DataSet ds = FEmpleado.GetAll();
                DataTable dt = ds.Tables[0];
                dgvDatos.DataSource = dt;

                dgvDatos.Columns["Id"].Visible = false;
                dgvDatos.Columns["DepartamentoId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmPersonalRegistrar form = new FrmPersonalRegistrar();
            form.txtId.Text = "";
            form.ShowDialog();
            FrmEmpleados_Load(null, null);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                FrmPersonalRegistrar form = new FrmPersonalRegistrar();
                form.txtId.Text = dgvDatos.CurrentRow.Cells["Id"].Value.ToString();
                form.txtCodigoEmpleado.Text = dgvDatos.CurrentRow.Cells["CodigoEmpleado"].Value.ToString();
                form.txtNombreTexto.Text = dgvDatos.CurrentRow.Cells["NombreTexto"].Value.ToString();
                form.txtApellidos.Text = dgvDatos.CurrentRow.Cells["Apellidos"].Value.ToString();
                form.txtCargo.Text = dgvDatos.CurrentRow.Cells["Cargo"].Value.ToString();
                form.cmbTipo.Text = dgvDatos.CurrentRow.Cells["Tipo"].Value.ToString();

                if (dgvDatos.CurrentRow.Cells["Afp"].Value.ToString() == "1")
                {
                    form.rbtAfpSi.Checked = true;
                    form.rbtAfpNo.Checked = false;
                }
                else
                {
                    form.rbtAfpSi.Checked = false;
                    form.rbtAfpNo.Checked = true;
                }

                if (dgvDatos.CurrentRow.Cells["Onp"].Value.ToString() == "1")
                {
                    form.rbtOnpSi.Checked = true;
                    form.rbtOnpNo.Checked = false;
                }
                else {
                    form.rbtOnpSi.Checked = false;
                    form.rbtOnpNo.Checked = true;
                }

                if (dgvDatos.CurrentRow.Cells["AsigFam"].Value.ToString() == "1")
                {
                    form.rbtAsigFamSi.Checked = true;
                    form.rbtAsigFamNo.Checked = false;
                }

                else
                {
                    form.rbtAsigFamSi.Checked = false;
                    form.rbtAsigFamNo.Checked = true;
                }

                if (dgvDatos.CurrentRow.Cells["rentaQta"].Value.ToString() == "1")
                {
                    form.rbtRentQuinSi.Checked = true;
                    form.rbtRentQuinNo.Checked = false;
                }
                else
                {
                    form.rbtRentQuinSi.Checked = false;
                    form.rbtRentQuinNo.Checked = true;
                }
                form.ShowDialog();
                FrmEmpleados_Load(null, null);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?.", "Eliminar Registro",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        if (FEmpleado.Eliminar(Convert.ToInt32(dgvDatos.CurrentRow.Cells["Id"].Value.ToString())) > 0)
                        {
                            MessageBox.Show("Se iliminó el registro", "Eliminado.");
                            FrmEmpleados_Load(null, null);
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
    }
}
