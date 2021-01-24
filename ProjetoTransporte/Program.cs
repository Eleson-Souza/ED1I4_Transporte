using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valido = true;
            string opcao, nome, idInserido;
            int id, idAux;

            Garagens garagens = new Garagens();
            Veiculos veiculos = new Veiculos();
            Viagens viagens = new Viagens();

            do
            {
                Console.WriteLine();
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar Veiculo");
                Console.WriteLine("2. Cadastrar Garagem");
                Console.WriteLine("3. Iniciar Jornada");
                Console.WriteLine("4. Encerrar Jornada");
                Console.WriteLine("5. Liberar viagem de uma determinada origem para um determinado destino");
                Console.WriteLine("6. Listar veículos em determinada garagem");
                Console.WriteLine("7. Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino");
                Console.WriteLine("8. Listar viagens efetuadas de uma determinada origem para um determinado destino");
                Console.WriteLine("9. Informar qtde de passageiros transportados de uma determinada origem para um determinado destino");
                Console.WriteLine();
                Console.Write("Selecione uma opção: ");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":

                        try
                        {
                            if (valido)
                                Console.Clear();

                            if (!garagens.JornadaAtiva)
                            {
                                Console.Write("Indique o ID do veículo: ");
                                int idVeiculo = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Indique a placa do veículo: ");
                                string placa = Console.ReadLine();

                                Console.Write("Indique a lotação máxima do veículo: ");
                                int lotacao = Convert.ToInt32(Console.ReadLine());

                                veiculos.incluir(new Veiculo(idVeiculo, placa, lotacao));
                            }
                            else
                            {
                                Console.WriteLine("Operação inválida enquanto a jornada estiver ativa");
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.Clear();
                            Console.WriteLine();

                            if (ex.Message.Contains("já foi cadastrado".ToUpper()))
                            {
                                Console.WriteLine($" == {ex.Message} == ".ToUpper());
                            }
                            else
                            {
                                Console.WriteLine(" == O valor ID e Lotação Máxima aceitam apenas números. == ".ToUpper());
                            }

                        }

                        break;
                    case "2":

                        try
                        {
                            if (valido)
                                Console.Clear();

                            if (!garagens.JornadaAtiva)
                            {
                                Console.Write("Indique o ID da garagem: ");
                                int idGaragem = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Insira o local da garagem: ");
                                string local = Console.ReadLine();

                                garagens.incluir(new Garagem(idGaragem, local, new Stack<Veiculo>()));
                            }
                            else
                            {
                                Console.WriteLine("Operação inválida enquanto a jornada estiver ativa");
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.Clear();

                            if (ex.Message.Contains("já foi cadastrado".ToUpper()))
                            {
                                Console.WriteLine($" == {ex.Message} == ".ToUpper());
                            }
                            else
                            {
                                Console.WriteLine(" == O valor ID aceita apenas números. == ".ToUpper());
                            }
                            
                            Console.WriteLine();

                        }

                        break;
                    case "3":

                        try
                        {
                            if (valido)
                                Console.Clear();

                            if (!garagens.JornadaAtiva)
                            {
                                if(garagens.ListaGaragens.Count() > 1)
                                {
                                    DistribuirVeiculos(garagens, veiculos);

                                    garagens.iniciarJornada();

                                    Console.WriteLine("A jornada foi iniciada");
                                }
                                else
                                {
                                    Console.WriteLine("Não há garagens o suficiente para iniciar a jornada");
                                }
                            }
                            else
                            {
                                Console.WriteLine("A jornada já se encontra ativa");
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.Clear();

                            Console.WriteLine($" == {ex.Message} == ".ToUpper());
                            Console.WriteLine();

                        }

                        break;
                    case "4":

                        try
                        {
                            if (valido)
                                Console.Clear();

                            if (garagens.JornadaAtiva)
                            {
                                foreach (var transporte in garagens.encerrarJornada())
                                {
                                    Veiculo veiculo = transporte.Veiculo;

                                    Console.WriteLine($" Placa: {veiculo.Placa} | passageiros transportados: {veiculo.Lotacao}");
                                }

                                Console.WriteLine("\n A jornada foi inativada");
                            }
                            else
                            {
                                Console.WriteLine("A jornada já se encontra inativa");
                            }


                        }
                        catch (Exception ex)
                        {

                            Console.Clear();

                            if (ex.Message.Contains("01/01/2001".ToUpper()))
                            {
                                Console.WriteLine(String.Concat(" == ", ex.Message, " == ".ToUpper()));
                                Console.WriteLine();
                            }
                            else if (ex.Message.Contains(" Não há um medicamento registrado com o ID".ToUpper()))
                            {
                                Console.WriteLine(String.Concat(" == ", ex.Message, " == ".ToUpper()));
                                Console.WriteLine();
                            }
                            else if (ex.Message.Contains(" já foi cadastrado para este medicamento".ToUpper()))
                            {
                                Console.WriteLine(String.Concat(" == ", ex.Message, " == ".ToUpper()));
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine(" == O valor ID aceita apenas números. == ".ToUpper());
                                Console.WriteLine();
                            }
                        }

                        break;
                    case "5":

                        try
                        {
                            if (valido)
                                Console.Clear();

                            if (garagens.JornadaAtiva)
                            {
                                if (garagens.ListaGaragens.Count > 1)
                                {
                                    Console.Write("Insira o ID da garagem de origem: ");
                                    int idOrigem = Convert.ToInt32(Console.ReadLine());
                                    Garagem garagemOrigem = garagens.pesquisar(idOrigem);

                                    Console.Write("Insira o ID da garagem de destino: ");
                                    int idDestino = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Insira o ID do veículo utilizado na viagem: ");
                                    int idVeiculo = Convert.ToInt32(Console.ReadLine());


                                    Garagem garagemDestino = garagens.pesquisar(idDestino);
                                    Veiculo veiculoViagem = veiculos.pesquisar(idVeiculo);

                                    viagens.incluir(new Viagem(garagemOrigem, garagemDestino, veiculoViagem));
                                }
                                else
                                {
                                    Console.WriteLine("Há menos de duas garagens cadastradas. Não é possível inicializar uma viagem");
                                }
                            }
                            else
                            {
                                Console.WriteLine("A liberação de viagem não é possível pois a jornada não está ativa.");
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.Clear();

                            if (ex.Message.Contains("01/01/2001".ToUpper()))
                            {
                                Console.WriteLine(String.Concat(" == ", ex.Message, " == ".ToUpper()));
                                Console.WriteLine();
                            }
                            else if (ex.Message.Contains(" Não há um medicamento registrado com o ID".ToUpper()))
                            {
                                Console.WriteLine(String.Concat(" == ", ex.Message, " == ".ToUpper()));
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine(" == O valor ID aceita apenas números. == ".ToUpper());
                                Console.WriteLine();
                            }
                        }

                        break;
                    case "6":

                        try
                        {
                            if (valido)
                                Console.Clear();

                            Console.Write("Insira o ID da garagem a ser consultada: ");
                            int idGaragem = Convert.ToInt32(Console.ReadLine());

                            Garagem garagemConsultada = garagens.pesquisar(idGaragem);

                            if (garagemConsultada != null)
                            {
                                Console.Clear();
                                Console.WriteLine($"Quantidade de veículos: {garagemConsultada.qtdeDeVeiculos().ToString()} | Potencial de transporte: {garagemConsultada.potencialDeTransporte().ToString()}");
                            }
                            else
                            {
                                Console.WriteLine("Garagem não encontrada");
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.Clear();

                            Console.WriteLine(" == O valor ID aceita apenas números. == ".ToUpper());
                            Console.WriteLine();

                        }

                        break;
                    case "7":

                        try
                        {
                            if (valido)
                                Console.Clear();

                            Console.WriteLine(viagens.listarQuantidadeViagens());
                        }
                        catch (Exception ex)
                        {

                            Console.Clear();

                            Console.WriteLine(" == O valor ID aceita apenas números. == ".ToUpper());
                            Console.WriteLine();

                        }

                        break;
                    case "8":

                        try
                        {
                            if (valido)
                                Console.Clear();

                            if (viagens.FilaViagens.Count > 0)
                            {
                                Console.WriteLine(viagens.listarViagensEfetuadas());
                            }
                            else
                            {
                                Console.WriteLine("Não houveram viagens.");
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.Clear();

                            Console.WriteLine(" == O valor ID aceita apenas números. == ".ToUpper());
                            Console.WriteLine();

                        }

                        break;
                    case "9":

                        try
                        {
                            if (valido)
                                Console.Clear();

                            if (viagens.FilaViagens.Count > 0)
                            {
                                Console.WriteLine(viagens.listarQuantidadeTransportada());
                            }
                            else
                            {
                                Console.WriteLine("Não houveram viagens.");
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.Clear();

                            Console.WriteLine(" == O valor ID aceita apenas números. == ".ToUpper());
                            Console.WriteLine();

                        }

                break;

            }

                Console.WriteLine();
            Console.WriteLine("======== FIM OPERACAO ========");
            Console.WriteLine();

        } while (!opcao.Equals("0"));
        }

    private static void DistribuirVeiculos(Garagens garagens, Veiculos veiculos)
    {
        if (garagens.ListaGaragens.Count <= 0 || veiculos.ListaVeiculos.Count <= 0)
        {
            throw new Exception("Assegure-se de que garagens e veículos foram cadastrados. Não foi possível iniciar a jornada");
        }

        int indice = 0;
        int qtdGaragens = garagens.ListaGaragens.Count;

        foreach (var veiculo in veiculos.ListaVeiculos)
        {
            if (indice >= qtdGaragens)
                indice = 0;

            garagens.ListaGaragens[indice].Veiculos.Push(veiculo);

            indice++;
        }
    }
}
}
