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
    public partial class frmTipoClientes : Form
    {
        private ETiposClientes _tp;
        private readonly TiposClientesBOL _TiposClientesBol = new TiposClientesBOL();
        public frmTipoClientes()
        {
            InitializeComponent();
        }

        private void frmTipoClientes_Load(object sender, EventArgs e)
        {
            TraerTodos();
        }

        private void TraerTodos()
        {
            List<ETiposClientes> tc = _TiposClientesBol.Todos();

            if (tc.Count > 0)
            {
               // grdDatos.AutoGenerateColumns = false;
                grdDatos.DataSource = tc;
                //dgvDatos.Columns["columnId"].DataPropertyName = "Id";
                //dgvDatos.Columns["columnDescripcion"].DataPropertyName = "Descripcion";
                //dgvDatos.Columns["columnMarca"].DataPropertyName = "Marca";
                //dgvDatos.Columns["columnPrecio"].DataPropertyName = "Precio";
            }
            else
                MessageBox.Show("No existen producto Registrado");
        }
    }
}
