using GerenTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenTarefas.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly GerenTarefasContext _contexto;
        public UsuarioRepositoryImpl(GerenTarefasContext contexto)
        {
            _contexto = contexto;
        }
        public void Salvar(Usuarios usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }
    }
}
