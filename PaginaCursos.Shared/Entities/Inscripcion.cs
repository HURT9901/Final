using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaginaCursos.Shared.Entities
{
    public class Inscripcion
    {     

        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaInscripcion { get; set; }

        [Display(Name = "Estado: ")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string EstadoInscripcion { get; set; }

        // Relaciones
        [JsonIgnore]
        public  Estudiante Estudiantes { get; set; }
        public int EstudianteId { get; set; }
        [JsonIgnore]
        public Curso Cursos { get; set; }
        public int CursoId { get; set; }
        

    }
}
