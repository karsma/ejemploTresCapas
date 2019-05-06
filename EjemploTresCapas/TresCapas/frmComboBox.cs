using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda_LogicaNegocio;

namespace TresCapas
{
    public partial class frmComboBox : Form
    {
        private readonly ProductoBol producto = new ProductoBol();
        private readonly ClienteBol cliente = new ClienteBol();
        public frmComboBox()
        {
            InitializeComponent();
        }

        private void frmComboBox_Load(object sender, EventArgs e)
        {
           
           
            cmbProductos.DisplayMember = "descripcion";
            cmbProductos.ValueMember = "id";
            cmbProductos.SelectedValue = 0;
            cmbProductos.DataSource = producto.Todos();
           

            listProductos.DataSource = producto.Todos();
            listProductos.ValueMember = "id";
            listProductos.DisplayMember = "descripcion";

            cmbClientes.DisplayMember = "nombre";
            cmbClientes.ValueMember = "id";
            cmbClientes.DataSource = cliente.Todos();
        }

        private void cmbProductos_SelectedValueChanged(object sender, EventArgs e)
        {
          
            if (cmbProductos.SelectedIndex > -1) { 
                int filtro = (int)cmbProductos.SelectedValue;

                txtPrecio.Text = producto.TraerPorId(filtro).Precio.ToString();
            }
        }
    }
}
