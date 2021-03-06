using GerenTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenTarefas.Repository
{
    public interface IUsuarioRepository
    {
        public void Salvar(Usuarios usuario);
        bool ExisteUsuarioPeloEmail(string email);
        Usuarios GetUsuarioByLoginSenha(string login, string senha);
        Usuarios GetById(int idUsuario);
    }
}
