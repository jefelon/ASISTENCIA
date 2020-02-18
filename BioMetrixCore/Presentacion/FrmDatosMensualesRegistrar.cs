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

        public string anio;public string mes; public string empleado;
        private void FrmDatosMensualesRegistrar_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaActual = DateTime.Today;

                DataSet dsem = FEmpleado.GetAll();
                DataTable dtem = dsem.Tables[0];
                cmbEmpleado.ValueMember = "CodigoEmpleado";
                cmbEmpleado.DisplayMember = "NombreTexto";
                cmbEmpleado.DataSource = dtem;
                cmbEmpleado.Text = empleado;

                DataSet dse = FDatosAnuales.GetAnio();
                DataTable dte = dse.Tables[0];
                cmbAnio.ValueMember = "Id";
                cmbAnio.DisplayMember = "Anio";
                cmbAnio.DataSource = dte;
                cmbAnio.Text = anio;
                

                DataSet ds2 = FDatosMensuales.GetMes();
                DataTable dt2 = ds2.Tables[0];
                cmbMes.ValueMember = "Id";
                cmbMes.DisplayMember = "Mes";
                cmbMes.DataSource = dt2;
                cmbMes.Text = mes;
                if (txtId.Text=="")
                {
                    cmbAnio.Text = fechaActual.Year.ToString();
                    cmbMes.Text = fechaActual.ToString("MMMM");
                }
                
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
                int id, codigoEmpleado, mesId, anioId; double afpCom, afpPrimCom, basico;

                codigoEmpleado = Convert.ToInt32(cmbEmpleado.SelectedValue.ToString());
                mesId = Convert.ToInt32(cmbAnio.SelectedValue.ToString());
                anioId = Convert.ToInt32(cmbAnio.SelectedValue.ToString());
                afpCom = Convert.ToDouble(txtAfpCom.Text);
                afpPrimCom = Convert.ToDouble(txtApfPrimCom.Text);
                basico = Convert.ToDouble(txtBasico.Text);

                if (txtId.Text == "")
                {

                    int returnId = FDatosMensuales.Insertar(codigoEmpleado, mesId, anioId,afpCom, afpPrimCom, basico);
                    if (returnId > 0)
                    {
                        MessageBox.Show("Se registró correctamente.");

                        Close();

                    }
                }
                else
                {
                    id = Convert.ToInt32(txtId.Text);
                    if (FDatosMensuales.Actualizar(id, codigoEmpleado, mesId, anioId, afpCom, afpPrimCom, basico) > 0)
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

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (cmbEmpleado.Text=="")
            {
                MessageBox.Show("Debe seleccionar a un empleado.");
            }
            else
            {
                DataSet ds = FDatosMensuales.GetUltimoRegistro(Convert.ToInt32(cmbEmpleado.SelectedValue.ToString()), cmbAnio.Text, Convert.ToInt32(cmbMes.SelectedValue.ToString()));
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    txtAfpCom.Text = dt.Rows[0]["AfpCom"].ToString();
                    txtApfPrimCom.Text = dt.Rows[0]["AfpPrimCom"].ToString();
                    txtBasico.Text = dt.Rows[0]["Basico"].ToString();
                }
                else
                {
                    MessageBox.Show("No hay registro del mes anterior de este año para esta persona..., Ingrese manualmente.");
                }
            }
        }
    }
}
