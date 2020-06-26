using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTower.Repositories
{
    public class JogadorRepository
    {
        public List<Jogador> Listar()
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Jogador.ToList();
            }
        }

        public List<Jogador> ListarComSelecao()
        {
            using(WSTowerContext ctx = new WSTowerContext())
            {

                return ctx.Jogador.Include(x => x.Selecao).ToList();
            }
        }

        public void Cadastar(Jogador novoJogador)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                ctx.Jogador.Add(novoJogador);
                ctx.SaveChanges();
            }
        }

        public Jogador BuscarPorId (int id)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Jogador.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Deletar(int id)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                Jogador jogadorId = ctx.Jogador.Find(id);
                ctx.Jogador.Remove(jogadorId);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Jogador jogador)
        {
            using (WSTowerContext  ctx = new WSTowerContext())
            {
                Jogador jogadorAtualizado = ctx.Jogador.FirstOrDefault(x => x.Id == jogador.Id);
                jogadorAtualizado.Id = jogador.Id;
                ctx.Jogador.Update(jogadorAtualizado);
                ctx.SaveChanges();
            }
        }

        public Jogador BuscarPorNome(string nome)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Jogador.FirstOrDefault(x => x.Nome == nome);
            }
        }

        public Jogador BuscarPorSelecao(int selecao)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Jogador.FirstOrDefault(x => x.SelecaoId == selecao);
            }
        }
    }
}
