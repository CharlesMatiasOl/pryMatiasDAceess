using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace pryMatiasDAceess
{
    public partial class frmPrincipal : Form
    {
        //OleDbConnection conexionBaseDatos;
        //string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;" +ryMatiasDAceess.git
            //"Data Source=\\\\servidor\\Co\\VIDEOCLUB.accdb";
        //OleDbCommand queQuieroTraerDeBD;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                conexionBaseDatos = new OleDbConnection(cadenaConexion);

                conexionBaseDatos.Open();

                lblInformacion.Text = "Todo ok, CONECTADO - " +
                    conexionBaseDatos.DataSource.ToString() + "\n";
            }
            catch (Exception mensajito)
            {
                lblInformacion.Text = mensajito.ToString() + "\n";
                //  throw;
            }
        }

        private void btnAbrirTabla_Click(object sender, EventArgs e)
        {
            try
            {
                queQuieroTraerDeBD = new OleDbCommand();

                queQuieroTraerDeBD.Connection = conexionBaseDatos;
                queQuieroTraerDeBD.CommandType = CommandType.TableDirect;
                queQuieroTraerDeBD.CommandText = "Clientes";

                lblInformacion.Text = "Todo ok, tabla " + queQuieroTraerDeBD.CommandText;

                OleDbDataReader objetoLectura = queQuieroTraerDeBD.ExecuteReader();

                while (objetoLectura.Read())
                {
                    lblInformacion.Text = lblInformacion.Text + Convert.ToString(objetoLectura["Nombre"]) + "\n";
                }

                objetoLectura.Close();
            }

            catch (Exception mensajito)
            {
                lblInformacion.Text = mensajito.ToString() + "\n";
                //throw;
            }
        }
    }
}
