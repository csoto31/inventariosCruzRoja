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
    public partial class frmReporteInventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void generarReporte()
        {
            string rutaReporte = "~/Reportes/rptInventario.rdlc";
            string rutaServidor = Server.MapPath(rutaReporte);

            if (!File.Exists(rutaServidor))
            {
                this.lblResultado.Text = "El reporte seleccionado no existe";
            }
            else
            {
                rvInventario.LocalReport.ReportPath = rutaServidor;
                var infoFuenteDatos = this.rvInventario.LocalReport.GetDataSourceNames();

                rvInventario.LocalReport.DataSources.Clear();

                List<sp_ReporteActivos_Result> datosReporte = this.retornaDatosReporte("","","", this.txtTipo.Text, this.txtMarca.Text);

                ReportDataSource fuenteDatos = new ReportDataSource();
                fuenteDatos.Name = infoFuenteDatos[0];
                fuenteDatos.Value = datosReporte;

                this.rvInventario.LocalReport.DataSources.Add(fuenteDatos);
                this.rvInventario.LocalReport.Refresh();
            } 
        }

        List<sp_ReporteActivos_Result> retornaDatosReporte(string nombre, string apellido1, string apellido2, string tipoActivo, string marca)
        {
            return new CRUZROJACRINVEntities().sp_ReporteActivos(nombre, apellido1, apellido2, tipoActivo, marca).ToList();
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
