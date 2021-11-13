using GerenTarefas.Enums;
using GerenTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenTarefas.Repository
{
    public interface ITarefaRepository
    {
        void AdicionarTarefa(Tarefa tarefa);
        Tarefa GetById(int idTarefa);
        void RemoverTarefa(Tarefa tarefa);
        void AtualizarTarefa(Tarefa tarefa);
        List<Tarefa> BuscarTarefas(int id, DateTime? periodoDe, DateTime? periodoAte, StatusTarefaEnum status);
    }
}
