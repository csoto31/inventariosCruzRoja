using invCruzRoja.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace invCruzRoja.Reportes
{
    public partial class frmReporteActivosPorEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void generarReporte()
        {
            string rutaReporte = "~/Reportes/rptEmpleadosActivos.rdlc";
            string rutaServidor = Server.MapPath(rutaReporte);

            if (!File.Exists(rutaServidor))
            {
                this.lblResultado.Text = "El reporte seleccionado no existe";
            }
            else
            {
                rvActivosEmpleados.LocalReport.ReportPath = rutaServidor;
                var infoFuenteDatos = this.rvActivosEmpleados.LocalReport.GetDataSourceNames();

                rvActivosEmpleados.LocalReport.DataSources.Clear();

                List<sp_ReporteActivosPorEmpleados_Result> datosReporte = this.retornaDatosReporte(this.txtNombre.Text, this.txtApellido1.Text, this.txtApellido2.Text, this.txtTipo.Text);

                ReportDataSource fuenteDatos = new ReportDataSource();
                fuenteDatos.Name = infoFuenteDatos[0];
                fuenteDatos.Value = datosReporte;

                this.rvActivosEmpleados.LocalReport.DataSources.Add(fuenteDatos);
                this.rvActivosEmpleados.LocalReport.Refresh();
            }
        }

        List<sp_ReporteActivosPorEmpleados_Result> retornaDatosReporte(string nombre, string apellido1, string apellido2, string tipoActivo)
        {
            return new CRUZROJACRINVEntities().sp_ReporteActivosPorEmpleados(nombre, apellido1, apellido2, tipoActivo).ToList();
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            this.generarReporte();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.generarReporte();
        }
    }
}