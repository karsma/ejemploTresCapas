using Microsoft.Reporting.WinForms;
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
    public partial class frmReporte1 : Form
    {
        public frmReporte1()
        {
            InitializeComponent();
        }

        private void frmReporte1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private readonly ClienteBol cliente = new ClienteBol();

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDataSource reporte  = new ReportDataSource();

            reporte.Value = cliente.Todos();
            reporte.Name = "DataSet1";
            reportViewer1.LocalReport.ReportPath = "Reportes\rptCliente.rdlc";
            reportViewer1.Show();

    }
    }
}
