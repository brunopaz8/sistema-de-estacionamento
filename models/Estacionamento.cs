using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sistema_de_Estacionamento.models
{
    public class Estacionamento
    {
        private decimal TaxaInicial { get; set; }
        private decimal TaxaPorHora { get; set; }
        private double Capacidade { get; set; }
        private List<string> Carros { get; set; } = new List<string>();

        public Estacionamento() { }

        public Estacionamento(decimal taxaInicial, decimal taxaPorHora, double capacidade, List<string> carros)
        {
            TaxaInicial = taxaInicial;
            TaxaPorHora = taxaPorHora;
            Capacidade = capacidade;
            Carros = carros;
        }
        
        /// <summary>
        /// Salva no banco de dados local os dados do estacionamento
        /// </summary>
        public void Salvando()
        {
            Console.Clear();
            Console.WriteLine(@"
============== Salvamento ==============
Deseja salvar os dados do estacionamento ?
[1] - Sim
[2] - Não
========================================
Sua escolha: ");
            string escolha = Console.ReadLine().ToLower();

            switch (escolha)
            {
                case "1":
                    Estacionamento e1 = new Estacionamento(TaxaInicial, TaxaPorHora, Capacidade, Carros);
                    string estacionamentoJson = JsonConvert.SerializeObject(e1, Formatting.Indented);
                    File.WriteAllText("LocalDB/estacionamento.json", estacionamentoJson);
                    break;
                case "2":
                    break;
            }

        }

        /// <summary>
        /// Define qual vai ser a capacidade do estácionamento.
        /// </summary>
        public void DefinirCapacidade()
        {
            while (true)
            {
                Console.WriteLine(@"
============== Capacidade ==============
Qual será a capacidade do estacionamento
========================================
Capacidade: ");
                string capacidade = Console.ReadLine();
                if (double.TryParse(capacidade, out double capacidadeInt) && capacidadeInt > 2)
                {
                    Console.Clear();
                    Capacidade = capacidadeInt;
                    Console.WriteLine(@$"
=============== Capacidade Definida ===============
A capacidade definida foi de: {Capacidade} carros.
===================================================");
                    break;
                }
                else if (capacidadeInt <= 2)
                {
                    Console.Clear();
                    Console.WriteLine($@"
XXXXXXXXXXXXX Valor Inválido XXXXXXXXXXXXX
O valor informado tem que ser maior que 2!
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Tente novamente!");
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número!");
                }
            }
        }

        /// <summary>
        /// Define qual vai ser a Taxa inicial do estacionamento.
        /// </summary>
        public void DefinirTaxaInicial()
        {
            Console.WriteLine(@"
=============== Taxa Inicial ===============
Qual será o preço inicial do estacionamento?
============================================
Taxa inicial: ");
            while (true)
            {
                string Valor = Console.ReadLine();
                if (decimal.TryParse(Valor, out decimal Numero))
                {
                    Console.Clear();
                    TaxaInicial = Numero;
                    Console.WriteLine($@"
===================== Valor Definido =====================
O valor definido da taxa inicial foi de: R$ {TaxaInicial:F2}
==========================================================");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Por favor, digite um número!");
                }
            }
        }

        /// <summary>
        /// Define qual vai ser a Taxa por hora do estacionamento.
        /// </summary>
        public void DefinirTaxaPorHora()
        {
            string Valor;
            Console.WriteLine(@"
=============== Taxa por Hora ===============
Qual será a taxa por hora do estacionamento?
=============================================
Taxa por hora: ");
            while (true)
            {
                Valor = Console.ReadLine();
                if (decimal.TryParse(Valor, out decimal Numero))
                {
                    Console.Clear();
                    TaxaPorHora = Numero;
                    Console.WriteLine($@"
===================== Valor Definido =====================
O Valor definido da taxa por hora foi de: R$ {TaxaPorHora:F2}
==========================================================");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                }
            }
        }

        /// <summary>
        /// Adiciona um carro no estacionamento.
        /// </summary>
        public void AdicionandoCarro()
        {
            while (true)
            {
                Console.WriteLine(@"
===== Adicionando Carro =====
Qual a placa do carro?
=============================
Sua escolha: ");
                string Placa = Console.ReadLine();

                if (!Carros.Contains(Placa) && Capacidade > 0)
                {
                    Console.Clear();
                    Carros.Add(Placa);
                    Capacidade -= 1;
                    Console.WriteLine($@"
============= Carro Adicionado =============
O carro com a placa: {Placa} foi adicionado.
============================================");
                    break;
                }
                else if (Carros.Contains(Placa))
                {
                    Console.Clear();
                    Console.WriteLine($@"
XXXXXXXXXXXXX Carro Não Adicionado XXXXXXXXXXXXX
O carro com a placa '{Placa}' já foi adicionado!
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Tente novamente!");
                }
                else if (Capacidade == 0)
                {
                    Console.Clear();
                    Console.WriteLine(@"
XXXXXXXXXXXXXXX Carro Não Adicionado XXXXXXXXXXXXXXXX
O estacionamento está lotado, retire um carro antes.
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Tente novamente!");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida, digite um placa válida!");
                }
            }
        }

        /// <summary>
        /// Mostra Todos os Carros que já foram cadastrados
        /// </summary>
        public void MostraTodosCarro()
        {
            if (Carros.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(@"
XXXXXX Sem Carros XXXXXXX
O estacionamento ainda não
possui carros registrados!
XXXXXXXXXXXXXXXXXXXXXXXXXX");
            }
            else
            {
                Console.WriteLine(@"
========= Todos os Carros =========
Carros que estão no estacionamento:");
                foreach (string Placa in Carros)
                {
                    int indice = Carros.IndexOf(Placa) + 1;
                    Console.WriteLine($"{indice} - {Placa}");
                }
                double porcentagem = Carros.Count / (Carros.Count + Capacidade) * 100;
                Console.WriteLine(@$"
Total da capacidade usada: {porcentagem:F2}%
===================================");
            }
        }

        /// <summary>
        /// Mostra os valores das taxas
        /// </summary>
        public void MostraTaxas()
        {
            Console.Clear();
            Console.WriteLine($@"
========= Valores das Taxas =========
Taxa inicial: R$ {TaxaInicial:F2} .
Taxa por hora: R$ {TaxaPorHora:F2} .
=====================================
");
        }

        /// <summary>
        /// Altera o valor das taxas
        /// </summary>
        public void AlterarTaxa()
        {
            Console.WriteLine(@"
===== Alterando as Taxas =====
[1] - Alterar a taxa Inicial.
[2] - Alterar a taxa por hora.
[3] - Voltar
==============================
Sua escolha: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Console.Clear();
                    DefinirTaxaInicial();
                    break;
                case "2":
                    Console.Clear();
                    DefinirTaxaPorHora();
                    break;
                case "3":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        /// <summary>
        /// Definindo o tempo que um carro passou no estacionamento
        /// </summary>
        /// <returns>O tempo em decimal</returns>
        private decimal InformandoTempo()
        {
            while (true)
            {
                string Tempo = Console.ReadLine();
                if (decimal.TryParse(Tempo, out decimal Numero))
                {
                    return Numero;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Por favor, digite um número!");
                }
            }
        }

        /// <summary>
        /// Retirando o carro
        /// </summary>
        public void RetirarCarro()
        {
            if (Carros.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(@"
XXXXXX Sem Carros XXXXXXX
O estacionamento ainda não
possui carros registrados!
XXXXXXXXXXXXXXXXXXXXXXXXXX");
            }
            else
            {
                Console.WriteLine("========== Retirando Carro ==========");
                MostraTodosCarro();
                Console.WriteLine(@"
Digite a placa do carro que deseja 
retirar ou digite [3] para voltar
=====================================
Placa:");
            while (true)
            {
                string Placa = Console.ReadLine();
                if (Carros.Contains(Placa))
                {
                    Console.Clear();
                    Console.WriteLine($@"
================== Definindo a Taxa ==================
Digite quanto tempo o carro de placa {Placa}, 
ficou no estacionamento
======================================================
Tempo:");

                    decimal TotalPago = InformandoTempo() * TaxaPorHora + TaxaInicial;
                    Carros.Remove(Placa);
                    Console.Clear();
                    Console.WriteLine($@"
=============================== Carro Retirado ===============================
O carro de placa {Placa} foi retirado e pagou o valor total de R$ {TotalPago:F2} .
==============================================================================");
                    Capacidade += 1;
                    break;
                } else if (Placa == "3"){
                        Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    MostraTodosCarro();
                    Console.WriteLine($@"
XXXXXXXXXXXXXXX Falha ao Retirar XXXXXXXXXXXXX
Carro com a placa {Placa}, não foi encontrado.
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Tente Novamente!");
                }
            }
    }
}

    }
}
