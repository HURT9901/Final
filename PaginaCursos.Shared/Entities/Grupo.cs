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
    public class Grupo
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del grupo")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreGrupo { get; set; }

        [Display(Name = "Descripcion del grupo")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DescripcionGrupo { get; set; }

        // Relaciones
        [JsonIgnore]
        public  Curso Cursos { get; set; }
        public int CursoId { get; set; }

      
    }
}
