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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id, empleadoId, mesId, anioId; double afpCom, afpPrimCom, basico;

                empleadoId= Convert.ToInt32(cmbEmpleado.SelectedValue.ToString());
                mesId = Convert.ToInt32(cmbAnio.SelectedValue.ToString());
                anioId = Convert.ToInt32(cmbAnio.SelectedValue.ToString());
                afpCom = Convert.ToDouble(txtAfpCom.Text);
                afpPrimCom = Convert.ToDouble(txtApfPrimCom.Text);
                basico = Convert.ToDouble(txtBasico.Text);

                if (txtId.Text == "")
                {

                    int returnId = FDatosMensuales.Insertar(empleadoId, mesId, anioId,afpCom, afpPrimCom, basico);
                    if (returnId > 0)
                    {
                        MessageBox.Show("Se registró correctamente.");

                        Close();

                    }
                }
                else
                {
                    id = Convert.ToInt32(txtId.Text);
                    if (FDatosMensuales.Actualizar(id, empleadoId, mesId, anioId, afpCom, afpPrimCom, basico) > 0)
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
