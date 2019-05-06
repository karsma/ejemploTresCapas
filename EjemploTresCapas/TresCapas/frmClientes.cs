using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda_Entidades;
using Tienda_LogicaNegocio;

namespace TresCapas
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private ECliente _cliente;
        private ETiposClientes _tp;
        private readonly TiposClientesBOL _TiposClientesBol = new TiposClientesBOL();
        private readonly ClienteBol _clientebol = new ClienteBol();

        private void Guardar()
        {
            try
            {
                if (_cliente == null)
                {
                    _cliente = new ECliente();
                    _cliente.id = Convert.ToInt32( txtId.Text );
                    _cliente.nombre = txtNombre.Text;
                    _cliente.direccion = txtDireccion.Text;
                    _cliente.telefono = txtTelefono.Text;
                    _cliente.idTipoCliente = Convert.ToInt32( cmbTipoCliente.SelectedValue );
                    _clientebol.Registrar(_cliente);

                    if (_clientebol.stringBuilder.Length != 0)
                    {
                        MessageBox.Show(_clientebol.stringBuilder.ToString(), "Para continuar:");
                    }else
                    {
                        MessageBox.Show("Producto registrado/actualizado con éxito");

                        TraerTodos();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void TraerTodos()
        {
            List<ECliente> TraerATodosLosCliente = _clientebol.Todos();

            if (TraerATodosLosCliente.Count > 0)
            {
                
                dgvDatos.DataSource = TraerATodosLosCliente;
               }
            else
                MessageBox.Show("No existen Cliente(s) Registrado(s)");
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDireccion.Text = txtNombre.Text;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarTiposClientes();
        }
        // prue

        private void CargarTiposClientes()
        {
            List<ETiposClientes> tc = _TiposClientesBol.Todos();

            if (tc.Count > 0)
            {
                // grdDatos.AutoGenerateColumns = false;

                cmbTipoCliente.DataSource = tc;
                cmbTipoCliente.ValueMember = "id";
                cmbTipoCliente.DisplayMember = "nombre";
            }
            else
                MessageBox.Show("No existen producto Registrado");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TraerTodos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
