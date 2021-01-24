using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte
{
    class Viagem
    {
        private int id;
        private Garagem origem;
        private Garagem destino;
        private Veiculo veiculo;

        private int controleId = 0;

        public Garagem Origem { get => origem; }
        public Garagem Destino { get => destino; }
        public Veiculo Veiculo { get => veiculo; }

        public Viagem(Garagem origem, Garagem destino, Veiculo veiculo)
        {
            controleId++;

            this.id = controleId;
            this.origem = origem;
            this.destino = destino;
            this.veiculo = veiculo;
        }
    }
}
