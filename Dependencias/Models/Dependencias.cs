using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dependencias.Models
{
    [Table("DEPENDENCIASGENERALES")]
    public class DEPENDENCIASGENERALES
    {
        [Required(ErrorMessage = "Se requiere que ingreses una clave de Dependencia")]
        public int CLAVEDEPENDENCIA { get; set; }
        [Required]
        public int ANIOOPERACION { get; set; }
        [Key]
        [Required(ErrorMessage="Se requiere que ingreses una clave de Dependencia General")]
        public string CLAVEDEPENDENCIAGENERAL { get; set; }
        [Required(ErrorMessage = "Se requiere que ingreses un nombre de Dependencia General")]
        public string NOMBREDEPENDENCIAGENERAL { get; set; }
        [Required]
        public string USUARIOCAPTURA { get; set; }
        [Required]
        public DateTime FECHACAPTURA { get; set; }
        [Required(ErrorMessage = "Se requiere que ingreses el status de Dependencia General")]
        public string STATUSDEPENDENCIASGENERALES { get; set; }
    }

    [Table("DEPENDENCIASAUXILIARES")]
    public class DEPENDENCIASAUXILIARES
    {
        [Required]
        public int CLAVEDEPENDENCIA { get; set; }
        [Required]
        public int ANIOOPERACION { get; set; }
        [Key]
        [Required]
        public string CLAVEDEPENDENCIAAUXILIAR { get; set; }
        [Required]
        public string NOMBREDEPENDENCIAAUXILIAR { get; set; }
        [Required]
        public string USUARIOCAPTURA { get; set; }
        [Required]
        public DateTime FECHACAPTURA { get; set; }
        [Required]
        public string STATUSDEPENDENCIASGENERALES { get; set; }
    }

    [Table("DEPENDENCIASMUNICIPIOS")]
    public class DEPENDENCIASMUNICIPIOS
    {
        [Required]
        public int CLAVEDEPENDENCIA { get; set; }
        [Required]
        public int ANIOOPERACION { get; set; }
        [Key]
        [Required]
        public string CLAVEDEPENDENCIAGENERAL { get; set; }
        [Required]
        public string CLAVEDEPENDENCIAAUXILIAR { get; set; }
        [Required]
        public string USUARIOCAPTURA { get; set; }
        [Required]
        public DateTime FECHACAPTURA { get; set; }
        [Required]
        public string STATUSDEPENDENCIASGENERALES { get; set; }
    }

    public class DB2Conn : DbContext
    {
        public DbSet<DEPENDENCIASGENERALES> DepGral { get; set; }
        public DbSet<DEPENDENCIASAUXILIARES> DepAux { get; set; }
        public DbSet<DEPENDENCIASMUNICIPIOS> DepMun { get; set; }
    }
}