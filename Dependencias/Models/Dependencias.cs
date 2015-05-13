using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dependencias.Models
{
    public class DEPENDENCIASGENERALES
    {
        [Column(Order = 0)][Required(ErrorMessage = "Se requiere que ingreses una clave de Dependencia")]
        public int CLAVEDEPENDENCIA { get; set; }
        [Column(Order = 1)][Required]
        public int ANIOOPERACION { get; set; }
        [Key][Column(Order = 2)][Required(ErrorMessage="Se requiere que ingreses una clave de Dependencia General")]
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

    public class DEPENDENCIASAUXILIARES
    {
        [Required]
        public int CLAVEDEPENDENCIA { get; set; }
        [Required(ErrorMessage="Es necesario este campo")]
        public int ANIOOPERACION { get; set; }
        [Key][Column(Order = 2)][Required(ErrorMessage = "Se necesita una Clave de Dependencia")]
        public string CLAVEDEPENDENCIAAUXILIAR { get; set; }
        [Required(ErrorMessage = "Se requiere que ingreses un nombre de Dependencia Auxiliar")]
        public string NOMBREDEPENDENCIAAUXILIAR { get; set; }
        [Required(ErrorMessage="Es necesario este campo")]
        public string USUARIOCAPTURA { get; set; }
        [Required(ErrorMessage="Se requiere una fecha valida")]
        public DateTime FECHACAPTURA { get; set; }
        [Required(ErrorMessage="Se necesita el status de dependencia")]
        public string STATUSDEPENDENCIASGENERALES { get; set; }
    }

    public class DEPENDENCIASMUNICIPIOS
    {
        [Required(ErrorMessage="Se requiere una Clave de Dependencia")]
        public int CLAVEDEPENDENCIA { get; set; }
        [Required(ErrorMessage = "Se necesita un año de operación")]
        public int ANIOOPERACION { get; set; }
        [Key][Column(Order = 2)][Required(ErrorMessage = "Se necesita una clave de dependencia general")]
        public string CLAVEDEPENDENCIAGENERAL { get; set; }
        [Key][Column(Order = 3)][Required(ErrorMessage = "Se necesita una Clave de Dependencia Auxiliar")]
        public string CLAVEDEPENDENCIAAUXILIAR { get; set; }
        [Required(ErrorMessage="Es necesario este campo")]
        public string USUARIOCAPTURA { get; set; }
        [Required(ErrorMessage="se requiere una fecha valida")]
        public DateTime FECHACAPTURA { get; set; }
        [Required(ErrorMessage="Se necesita el status de dependencia")]
        public string STATUSDEPENDENCIASGENERALES { get; set; }
    }

    public class DB2Conn : DbContext
    {
        public DbSet<DEPENDENCIASGENERALES> DepGral { get; set; }
        public DbSet<DEPENDENCIASAUXILIARES> DepAux { get; set; }
        public DbSet<DEPENDENCIASMUNICIPIOS> DepMun { get; set; }
    }
}