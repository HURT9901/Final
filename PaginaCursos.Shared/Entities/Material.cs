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
    public class Material
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del material")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreMaterial { get; set; }

        [Display(Name = "Descripcion del material")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DescripcionMaterial { get; set; }

        [Display(Name = "Tipo de material")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TipoMaterial { get; set; }

        // Relaciones
        [JsonIgnore]
        public Curso Cursos { get; set; }
        public int CursoId { get; set; }
    }
}
