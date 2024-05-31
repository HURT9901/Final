using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaginaCursos.Shared.Entities
{
    public class Curso
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del curso")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreCurso { get; set; }

        [Display(Name = "Descripcion del grupo")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DescripcionCurso { get; set; }

        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de Finalización")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaFinalizacion { get; set; }
        

        // Relaciones
        [JsonIgnore]
        public ICollection<Inscripcion> Inscripciones { get; set; }
        [JsonIgnore]
        public ICollection<Grupo> Grupos { get; set; }
        [JsonIgnore]
        public ICollection<Actividad> Actividades { get; set; }
        [JsonIgnore]
        public  ICollection<Material> Materiales { get; set; }
        [JsonIgnore]
        public  ICollection<Sugerencia> Sugerencias { get; set; }
        [JsonIgnore]
        public Profesor Profesores { get; set; }
        public int ProfesorId { get; set; }

    }
}
