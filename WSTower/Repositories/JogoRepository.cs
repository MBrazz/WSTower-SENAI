using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTower.Repositories
{
    public class JogoRepository
    {


        //Lista todos os jogos
        public List<Jogo> ListarJogos()
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {

                return ctx.Jogo.Include(x => x.SelecaoCasaNavigation).Include(x => x.SelecaoVisitanteNavigation).ToList();



            }
            
        }

        public Jogo BuscarPorEstadio(string estadio)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Jogo.FirstOrDefault(x => x.Estadio == estadio);
            }
        }

        /*public string PlacarFinal()
        {
                string placarFinal;
                Jogo jogo = new Jogo();
                placarFinal = jogo.PlacarCasa + " x " + jogo.PlacarVisitante;
                return placarFinal;
            
        }/*/

        public Jogo BucarPorId(int id)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Jogo.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Cadastrar(Jogo jogoNovo)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                ctx.Jogo.Add(jogoNovo);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                Jogo jogoId = ctx.Jogo.Find(id);
                ctx.Jogo.Remove(jogoId);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Jogo jogo)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                Jogo jogoAtualizado = ctx.Jogo.FirstOrDefault(x => x.Id == jogo.Id);
                jogoAtualizado.Id = jogo.Id;
                ctx.Jogo.Update(jogoAtualizado);
                ctx.SaveChanges();

            }
        }

        public Jogo BuscarPorData(DateTime data)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Jogo.FirstOrDefault(x => x.Data == data);
            }
        }

        /*public Jogo BuscarPorSelecao(int selecaoid)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Jogo.FirstOrDefault(x => x.);
            }
        }/*/


    }
}
