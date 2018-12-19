using invCruzRoja.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace invCruzRoja.Reportes
{
    public partial class frmReporteEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void generarReporte()
        {
            string rutaReporte = "~/Reportes/rptEmpleados.rdlc";
            string rutaServidor = Server.MapPath(rutaReporte);

            if (!File.Exists(rutaServidor))
            {
                this.lblResultado.Text = "El reporte seleccionado no existe";
            }
            else
            {
                rvEmpleados.LocalReport.ReportPath = rutaServidor;
                var infoFuenteDatos = this.rvEmpleados.LocalReport.GetDataSourceNames();

                rvEmpleados.LocalReport.DataSources.Clear();

                List<sp_ReporteEmpleados_Result> datosReporte = this.retornaDatosReporte(this.txtNombre.Text, this.txtApellido1.Text, this.txtApellido2.Text, this.txtUsuario.Text, this.txtCorreo.Text);

                ReportDataSource fuenteDatos = new ReportDataSource();
                fuenteDatos.Name = infoFuenteDatos[0];
                fuenteDatos.Value = datosReporte;

                this.rvEmpleados.LocalReport.DataSources.Add(fuenteDatos);
                this.rvEmpleados.LocalReport.Refresh();
            }
        }

        List<sp_ReporteEmpleados_Result> retornaDatosReporte(string nombre, string apellido1, string apellido2, string usuario, string correo)
        {
            return new CRUZROJACRINVEntities().sp_ReporteEmpleados(nombre, apellido1, apellido2, usuario, correo).ToList();
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            this.generarReporte();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.generarReporte();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("https://login.microsoftonline.com/common/oauth2/v2.0/logout?post_logout_redirect_uri=http%3A%2F%2Flocalhost%3A50635%2FHome%2FIndex&x-client-SKU=ID_NET451&x-client-ver=5.2.1.0");
        }
    }
}