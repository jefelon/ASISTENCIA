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
    public partial class FrmDatosAnualesRegistrar : Form
    {
        public FrmDatosAnualesRegistrar()
        {
            InitializeComponent();
        }

        private void FrmDatosAnualesRegistrar_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet dse = FDatosAnuales.GetAnio();
                DataTable dte = dse.Tables[0];
                cmbAnio.ValueMember = "Id";
                cmbAnio.DisplayMember = "Anio";
                cmbAnio.DataSource = dte;
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
                int id,anioId; double asigFam, remMin, essalud, onpDat, afpDat, uit;

                
                anioId = Convert.ToInt32(cmbAnio.SelectedValue.ToString());
                asigFam = Convert.ToDouble(txtAsigfam.Text);
                remMin = Convert.ToDouble(txtRemMin.Text);
                essalud = Convert.ToDouble(txtEssalud.Text);
                onpDat = Convert.ToDouble(txtSnp.Text);
                afpDat = Convert.ToDouble(txtAfp.Text);
                uit = Convert.ToDouble(txtUit.Text);
                if (txtId.Text == "")
                {
                   
                    int returnId = FDatosAnuales.Insertar(anioId,asigFam, remMin, essalud, onpDat, afpDat, uit);
                    if (returnId > 0)
                    {
                        MessageBox.Show("Se registró correctamente.");

                        Close();

                    }
                }
                else
                {
                    id = Convert.ToInt32(txtId.Text);
                    if (FDatosAnuales.Actualizar(id,anioId, asigFam, remMin, essalud, onpDat, afpDat, uit) >0)
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
