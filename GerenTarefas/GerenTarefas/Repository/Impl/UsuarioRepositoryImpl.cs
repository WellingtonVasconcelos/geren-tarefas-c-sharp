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

        public bool ExisteUsuarioPeloEmail(string email)
        {
            return _contexto.Usuarios.Any(usuario => usuario.Email.ToLower() == email.ToLower());
        }

        public Usuarios GetById(int idUsuario)
        {
            return _contexto.Usuarios.FirstOrDefault(usuario => usuario.Id == idUsuario);
        }

        public Usuarios GetUsuarioByLoginSenha(string login, string senha)

        {
            return _contexto.Usuarios.FirstOrDefault(usuario => usuario.Email == login.ToLower() && usuario.Senha == senha);
        }

        public void Salvar(Usuarios usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }
    }
}
