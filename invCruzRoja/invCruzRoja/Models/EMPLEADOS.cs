//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace invCruzRoja.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLEADOS
    {
        public int IDEmpleado { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; }
        public Nullable<int> IDPersona { get; set; }
        public string Correo { get; set; }
    
        public virtual PERSONAS PERSONAS { get; set; }
    }
}