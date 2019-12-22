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
    public partial class FrmPersonalRegistrar : Form
    {
        public FrmPersonalRegistrar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id; string codigo; int codigoEmpleado; string nombreTexto, apellidos; int departamentoId; string cargo; int asigFam; int onp; int afp; int rentaQta; string tipo;

                codigo = txtCodigoNombre.Text;
                codigoEmpleado = Convert.ToInt32(txtCodigoEmpleado.Text);
                nombreTexto = txtNombreTexto.Text;
                apellidos = txtApellidos.Text;
                departamentoId = 1;
                cargo = txtCargo.Text;
                tipo = cmbTipo.Text;

                if (rbtAsigFamSi.Checked == true) asigFam = 1; else asigFam = 0;              
                if (rbtOnpSi.Checked == true) onp = 1; else onp = 0;
                if (rbtAfpSi.Checked == true) afp = 1; else afp = 0;
                if (rbtRentQuinSi.Checked == true) rentaQta = 1; else rentaQta = 0;

                if (txtId.Text == "")
                {

                    int returnId = FEmpleado.Insertar(codigo, codigoEmpleado, nombreTexto, apellidos,  departamentoId,  cargo,  asigFam,  onp, afp, rentaQta,tipo);
                    if (returnId > 0)
                    {
                        MessageBox.Show("Se registró correctamente.");

                        Close();

                    }
                }
                else
                {
                    id = Convert.ToInt32(txtId.Text);
                    if (FEmpleado.Actualizar(id, codigo, codigoEmpleado, nombreTexto, apellidos, departamentoId, cargo, asigFam, onp, afp, rentaQta,tipo) > 0)
                    {
                        MessageBox.Show("Se modificó correctamente.");

                        Close();
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
