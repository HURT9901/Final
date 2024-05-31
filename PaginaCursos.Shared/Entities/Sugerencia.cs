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
    public class Sugerencia
    {
        public int Id { get; set; }

        [Display(Name = "Ingrese su sugerencia")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TextoSugerencia { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        [JsonIgnore]
        public Estudiante Estudiantes { get; set; }
        public int EstudianteId { get; set; }

        [JsonIgnore]
        public Curso Cursos { get; set; }
        public int CursoId { get; set; }

    }
}
