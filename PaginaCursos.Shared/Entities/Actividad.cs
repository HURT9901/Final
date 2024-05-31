using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace PaginaCursos.Shared.Entities
{
    public class Actividad
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de actividad")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreActividad { get; set; }

        [Display(Name = "Descripcion de la actividad")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DescripcionActividad { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaAccion { get; set; }
        

        // Relaciones
        [JsonIgnore]
        public Curso Cursos { get; set; }
        public int CursoId { get; set; }

    }
}
