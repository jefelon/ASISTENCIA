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
    public partial class FrmAgregarAsistencia : Form
    {
        public FrmAgregarAsistencia()
        {
            InitializeComponent();
        }

        private void FrmAgregarAsistencia_Load(object sender, EventArgs e)
        {
            DataSet dse2 = FEmpleado.GetAll();
            DataTable dte2 = dse2.Tables[0];
            cmbEmpleado.ValueMember = "Id";
            cmbEmpleado.DisplayMember = "NombreTexto";
            cmbEmpleado.DataSource = dte2;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Asistencia asistencia = new Asistencia();
                asistencia.NumeroEquipo = 1;
                asistencia.CodigoEmpleado = Convert.ToDouble(txtCodEmp.Text);
                asistencia.ModoAcceso = 1;
                if(cmbTipo.Text=="INGRESO")
                {
                    asistencia.TipoRegistro = 0;
                }
                else
                {
                    asistencia.TipoRegistro = 5;
                }
                
                asistencia.Fecha = dtpFecha.Value;

                int returnDetalleId = FAsistencia.Insertar(asistencia);

                if (returnDetalleId > 0)
                {
                    MessageBox.Show("Se insertó corréctamente.");
                    Close();
                }

            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbEmpleado.Text !="")
            {
                try
                {
                    DataSet ds = FEmpleado.Get(Convert.ToInt32(cmbEmpleado.SelectedValue.ToString()));
                    DataTable dt = ds.Tables[0];
                    txtCodEmp.Text= dt.Rows[0]["CodigoEmpleado"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }
    }
}
