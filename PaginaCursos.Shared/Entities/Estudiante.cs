using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaginaCursos.Shared.Entities
{
    
    public class Estudiante
    {
        public int Id { get; set; }
        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage ="No se permiten más de 20 caracteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Documento { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apellido { get; set; }

        [Display(Name = "Correo Electronico")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "Digite un Email válido")]
        public string CorreoElectronico { get; set;}

        public string Nombre_Completo => $"{Nombre} {Apellido}";


        // Relaciones
        [JsonIgnore]
        public ICollection<Inscripcion> Inscripciones {get; set;}
        [JsonIgnore]
        public ICollection<Sugerencia> Sugerencias { get; set; }
        [JsonIgnore]
        public ICollection<Grupo> Grupos { get; set; }

    }
}
