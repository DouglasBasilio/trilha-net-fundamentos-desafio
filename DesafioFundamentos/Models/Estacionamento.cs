using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!string.IsNullOrEmpty(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo com a placa {placa} foi estacionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void Menu()
        {
            int escolha;
            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Cadastrar veículo");
                Console.WriteLine("2. Remover veículo");
                Console.WriteLine("3. Listar veículos");
                Console.WriteLine("4. Encerrar");
                Console.Write("Escolha uma opção: ");
                if (int.TryParse(Console.ReadLine(), out escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            AdicionarVeiculo();
                            break;
                        case 2:
                            RemoverVeiculo();
                            break;
                        case 3:
                            ListarVeiculos();
                            break;
                        case 4:
                            Console.WriteLine("Encerrando o programa.");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            } while (escolha != 4);
        }
    }
}
