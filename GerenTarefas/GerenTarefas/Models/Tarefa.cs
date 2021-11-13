using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GerenTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime DataPrevistaConclusao { get; set; }
        public DateTime? DataConclusao { get; set; }

        //JsonIgnore para evitar a dependência ciclica
        [JsonIgnore]
        [ForeignKey("IdUsuario")]
        public virtual Usuarios usuario { get; private set; }
    }
}
