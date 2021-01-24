using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte
{
    class Garagem
    {
        private int id;
        private string local;
        private Stack<Veiculo> veiculos;

        public int Id { get => id; }
        public string Local { get => local; }
        public Stack<Veiculo> Veiculos { get => veiculos; }

        public Garagem(int id, string local, Stack<Veiculo> veiculos)
        {
            this.id = id;
            this.local = local;
            this.veiculos = veiculos;
        }

        public int qtdeDeVeiculos()
        {
            return veiculos.Count();
        }

        public int potencialDeTransporte()
        {
            int potencialDeTransporte = 0;
            Stack<Veiculo> auxVeiculos = veiculos;

            while(auxVeiculos.Count > 0)
            {
                Veiculo veiculoDesempilhado = auxVeiculos.Pop();
                potencialDeTransporte += veiculoDesempilhado.Lotacao;
            }

            return potencialDeTransporte;
        }

        public override bool Equals(object obj)
        {
            var garagem = obj as Garagem;

            if (garagem.id == this.id)
            {
                throw new Exception("Este ID já foi cadastrado para outra garagem.".ToUpper());
            }

            return false;
        }
    }
}
