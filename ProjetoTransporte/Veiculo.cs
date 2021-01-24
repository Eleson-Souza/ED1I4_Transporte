using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte
{
    class Veiculo
    {
        private int id;
        private string placa;
        private int lotacao;

        public int Id { get => id; }
        public int Lotacao { get => lotacao; }
        public string Placa { get => placa;}

        public Veiculo(int id, string placa, int lotacao)
        {
            this.id = id;
            this.placa = placa;
            this.lotacao = lotacao;
        }

        public override bool Equals(object obj)
        {
            var veiculo = obj as Veiculo;

            if (veiculo.id == this.id)
            {
                throw new Exception("Este ID já foi cadastrado para outro carro.".ToUpper());
            }

            return false;
        }
    }
}
