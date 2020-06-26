using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTower.Repositories
{
    public class SelecaoRepository
    {
        public List<Selecao> Listar()
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                
                return ctx.Selecao
                    .Include(x => x.JogoSelecaoCasaNavigation).Include(x => x.JogoSelecaoVisitanteNavigation)
                    .ToList();
            }
        }

        public void Cadastrar(Selecao selecao)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                ctx.Selecao.Add(selecao);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                Selecao selecaoid = ctx.Selecao.Find(id);
                ctx.Selecao.Remove(selecaoid);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Selecao selecao)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                Selecao selecaoAtualizada = ctx.Selecao.FirstOrDefault(x => x.Id == selecao.Id);
                selecaoAtualizada.Id = selecao.Id;
                ctx.Selecao.Update(selecaoAtualizada);
                ctx.SaveChanges();
            }
        }

        public Selecao BuscarPorNome(string nome)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Selecao.FirstOrDefault(x => x.Nome == nome);
            }
        }

        public Selecao BuscarPorId(int id)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Selecao.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
