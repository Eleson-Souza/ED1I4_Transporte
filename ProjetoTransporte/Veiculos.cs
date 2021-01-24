using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte
{
    class Veiculos
    {
        private List<Veiculo> veiculos;

        public List<Veiculo> ListaVeiculos { get => veiculos; }

        public Veiculos()
        {
            this.veiculos = new List<Veiculo>();
        }

        public void incluir(Veiculo veiculo)
        {
            if (ListaVeiculos.Where(x => x.Equals(veiculo)).Count() > 0)
            {
                Console.WriteLine("Veiculo já cadastrado");
                return;
            }

            this.veiculos.Add(veiculo);
        }

        internal Veiculo pesquisar(int idVeiculo)
        {

            return veiculos.Where(x => x.Id == idVeiculo).SingleOrDefault();
        }
    }
}
