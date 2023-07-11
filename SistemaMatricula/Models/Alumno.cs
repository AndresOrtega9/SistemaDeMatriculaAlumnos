//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaMatricula.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            this.Matricula = new HashSet<Matricula>();
        }
    
        public int IIDALUMNO { get; set; }
        public string NOMBRE { get; set; }
        public string APPATERNO { get; set; }
        public string APMATERNO { get; set; }
        public Nullable<System.DateTime> FECHANACIMIENTO { get; set; }
        public Nullable<int> IIDSEXO { get; set; }
        public string TELEFONOPADRE { get; set; }
        public string TELEFONOMADRE { get; set; }
        public Nullable<int> NUMEROHERMANOS { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
        public string IIDTIPOUSUARIO { get; set; }
        public Nullable<int> bTieneUsuario { get; set; }
    
        public virtual Sexo Sexo { get; set; }
        public virtual TIPOUSUARIO TIPOUSUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}