using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte
{
    class Viagens
    {
        private Queue<Viagem> viagens;

        public Queue<Viagem> FilaViagens { get => viagens; }

        public Viagens()
        {
            this.viagens = new Queue<Viagem>();
        }

        public void incluir(Viagem viagem)
        {
            this.viagens.Enqueue(viagem);
        }

        public string listarViagensEfetuadas()
        {
            StringBuilder listagem = new StringBuilder(String.Empty);
            List<Viagem> listaViagens = viagens.ToList<Viagem>();

            List<string> listaOrigens = listaViagens.Select(x => x.Origem.Local).Distinct().ToList();
            List<string> listaDestinos = listaViagens.Select(x => x.Destino.Local).Distinct().ToList();

            foreach (var origem in listaOrigens)
            {
                foreach (var destino in listaDestinos)
                {
                    int qtdViagens = listaViagens.Where(x => x.Origem.Local.Equals(origem) && x.Destino.Local.Equals(destino)).Count();

                    if (qtdViagens > 0)
                        listagem.Append($" Origem: {origem} | Destino: {destino} | Quantidade de viagens: {qtdViagens} \n");
                }
            }

            return listagem.ToString();

        }

        public string listarQuantidadeTransportada()
        {
            StringBuilder listagem = new StringBuilder(String.Empty);
            List<Viagem> listaViagens = viagens.ToList<Viagem>();

            List<string> listaOrigens = listaViagens.Select(x => x.Origem.Local).Distinct().ToList();
            List<string> listaDestinos = listaViagens.Select(x => x.Destino.Local).Distinct().ToList();

            foreach (var origem in listaOrigens)
            {
                foreach (var destino in listaDestinos)
                {
                    List<Viagem> viagens = listaViagens.Where(x => x.Origem.Local.Equals(origem) && x.Destino.Local.Equals(destino)).ToList();

                    if (viagens.Count > 0)
                    {
                        int qtdPassageiros = 0;

                        foreach(var viagem in viagens)
                        {
                            qtdPassageiros += viagem.Veiculo.Lotacao;    
                        }

                        listagem.Append($" Origem: {origem} | Destino: {destino} | Quantidade de passageiros transportados: {qtdPassageiros} \n");
                    }
                        
                }
            }

            return listagem.ToString();
        }

        public string listarQuantidadeViagens()
        {
            StringBuilder listagem = new StringBuilder(String.Empty);
            List<Viagem> listaViagens = viagens.ToList<Viagem>();

            List<string> listaOrigens = listaViagens.Select(x => x.Origem.Local).Distinct().ToList();
            List<string> listaDestinos = listaViagens.Select(x => x.Destino.Local).Distinct().ToList();

            foreach (var origem in listaOrigens)
            {
                foreach (var destino in listaDestinos)
                {
                    List<Viagem> qtdViagens = listaViagens.Where(x => x.Origem.Local.Equals(origem) && x.Destino.Local.Equals(destino)).ToList();

                    if (qtdViagens.Count > 0)
                    {                        
                        listagem.Append($" Origem: {origem} | Destino: {destino} | Quantidade de passageiros transportados: {qtdViagens} \n");
                    }

                }
            }

            return listagem.ToString();
        }

    }
}
