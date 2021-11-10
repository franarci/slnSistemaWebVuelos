using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Models
{
    [Table(name: "Vuelo")]
    public class Vuelo
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="No debe superar los 50 caracteres")]
        public string Destino { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "No debe superar los 50 caracteres")]
        public string Origen { get; set; }
        [DisplayName("Matricula Avion")]
        [Range(100,1000, ErrorMessage ="La matricula debe ser un numero entre 100 y 1000")]
        public int Matricula { get; set; }
    }
}