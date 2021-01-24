using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte
{
    class Transporte
    {
        private Veiculo veiculo;
        private int qtdeTransportada;

        public Veiculo Veiculo { get => veiculo; }
        public int QtdeTransportada { get => qtdeTransportada; }

        public Transporte(Veiculo veiculo, int qtdeTransportada)
        {
            this.veiculo = veiculo;
            this.qtdeTransportada = qtdeTransportada;
        }
    }
}
