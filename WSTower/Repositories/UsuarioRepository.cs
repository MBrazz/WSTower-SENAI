using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WSTower.Contexts;
using WSTower.Domains;
using WSTower.ViewModels;

namespace WSTower.Repositories
{
    public class UsuarioRepository
    {
        WSTowerContext ctx = new WSTowerContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            usuarioBuscado.Nome = usuarioAtualizado.Nome;

            usuarioBuscado.Email = usuarioAtualizado.Email;

            usuarioBuscado.Apelido = usuarioAtualizado.Apelido;

            usuarioBuscado.Senha = usuarioAtualizado.Senha;

            ctx.Usuario.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(u => u.Id == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuario.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }

        public Usuario Login(string usuario, string senha)
        {
            return ctx.Usuario.FirstOrDefault(u => u.Email == usuario && u.Senha == senha || u.Apelido == usuario && u.Senha == senha);

        }
    }
}
