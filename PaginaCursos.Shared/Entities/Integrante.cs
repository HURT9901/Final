using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaginaCursos.Shared.Entities
{
    public class Integrante
    {
        public int Id { get; set; }

        [JsonIgnore] 
        public Grupo Grupos { get; set; } 
        public int GrupoId { get; set; }

        [JsonIgnore]
        public Estudiante Estudiantes { get; set; }
        public int EstudianteId { get; set; }

       
    }
}
