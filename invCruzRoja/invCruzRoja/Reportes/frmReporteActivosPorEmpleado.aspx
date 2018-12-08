<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReporteActivosPorEmpleado.aspx.cs" Inherits="invCruzRoja.Reportes.frmReporteActivosPorEmpleado" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>Reporte de Activos por Territorios</title>
</head>
<body style="background-image:url(../fonts/logoCRw2.png); background-repeat: no-repeat; background-attachment: fixed; background-position:center;">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <nav class="navbar navbar-inverse navbar-fixed-top">
                <div class="container-fluid">             
                    <ul class="nav navbar-nav">
                        <li><a href="../Home">Inicio</a></li>
                        <li><a href="../Home/About">Acerca de</a></li>
                        <li><a href="../Home/Contact">Contacto</a></li>
                        <li><a href="../Empleados">Empleados</a></li>
                        <li><a href="../Inventarios">Inventarios</a></li>
                        <li><a href="../Territorios">Territorios</a></li>
                        <li><a href="../Personas">Personas</a></li>
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown">Reportes <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="/Reportes/frmReporteEmpleados.aspx">Reporte de Empleados</a></li>
                                <li><a href="/Reportes/frmReporteInventario.aspx">Reporte de Activos por Empleado</a></li>
                                <li><a href="/Reportes/frmReporteActivosPorTerritorio.aspx">Reporte de Activos por Territorios</a></li>
                                <li><a href="/Reportes/frmReporteActivosPorEmpleado.aspx">Reporte de Activos por Empleado</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="container" style="margin-top: 5%">
            <div class="row>">
                <div class="col-md-12">
                <h1 class="text-center">Reporte de Activos por Empleado</h1>
                <br /><br />
                    <h4>Buscar registro por:</h4>
                    <div class="col-md-2">
                        <asp:Label ID="lblnombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox class="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lblapellido1" runat="server" Text="Primer Apellido"></asp:Label>
                        <asp:TextBox class="form-control" ID="txtApellido1" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lblapellido2" runat="server" Text="Segundo Apellido"></asp:Label>
                        <asp:TextBox class="form-control" ID="txtApellido2" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo de Activo"></asp:Label>
                        <asp:TextBox class="form-control" ID="txtTipo" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <br/>
                        <asp:Button class="btn btn-primary btn-md" ID="btnFiltrar" runat="server" Text="Filtrar registros" OnClick="btnFiltrar_Click" />
                    </div>
                    <br /><br /><br />
                <asp:ScriptManager ID="scmEmpleadosAct" runat="server">
                </asp:ScriptManager>
                <hr />
                <asp:Button class="btn btn-info btn-lg" ID="btnGenerarReporte" runat="server" Text="Mostrar Reporte General" OnClick="btnGenerarReporte_Click" />
                <hr />
                <asp:Label ID="lblResultado" runat="server" ></asp:Label>            
                <rsweb:ReportViewer ID="rvActivosEmpleados" runat="server" Width="100%" Height="577px"></rsweb:ReportViewer>
            </div>
            </div>
        </div>
    </form>
</body>
</html>
