using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte
{
    class Garagens
    {
        private List<Garagem> garagens;
        private bool jornadaAtiva;

        public List<Garagem> ListaGaragens { get => this.garagens; }
        public bool JornadaAtiva { get => this.jornadaAtiva; }

        public Garagens()
        {
            this.garagens = new List<Garagem>();
            this.jornadaAtiva = false;
        }

        public void incluir(Garagem garagem)
        {
            if (garagens.Where(x => x.Equals(garagem)).Count() > 0)
            {
                Console.WriteLine("Garagem já cadastrada");
                return;
            }

            this.garagens.Add(garagem);
        }

        public void iniciarJornada()
        {
            if(garagens.Count > 0)
            {
                this.jornadaAtiva = true;
            }
            else
            {
                Console.WriteLine("Não há garagens ´cadastradas. A jornada não pôde seriniciada");
            }
        }

        public List<Transporte> encerrarJornada()
        {
            List<Transporte> relatorioTransporte = new List<Transporte>();

            foreach(var garagem in garagens)
            {
                while(garagem.Veiculos.Count > 0)
                {
                    Veiculo veiculo = garagem.Veiculos.Pop();

                    relatorioTransporte.Add(new Transporte(veiculo,veiculo.Lotacao));
                }
            }

            this.jornadaAtiva = false;

            return relatorioTransporte;
        }

        public Garagem pesquisar(int garagemId)
        {
            return garagens.Where(x => x.Id == garagemId).SingleOrDefault();
        }
    }
}
