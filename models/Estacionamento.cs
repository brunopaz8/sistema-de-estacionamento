using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.models
{
    public class Estacionamento
    {
        public decimal TaxaInicial { get; set; }
        public decimal TaxaPorHora { get; set; }
        public List<string> Carros { get; set; } = new List<string>();

        /// <summary>
        /// Define qual vai ser a Taxa inicial do estácionamento.
        /// </summary>
        public void DefinirTaxaInicial()
        {
            string Valor;
            Console.WriteLine(@"
=============== Taxa Inicial ===============
Qual será o preço inicial do estacionamento?
============================================
Taxa inicial: ");
            while (true)
            {
                Valor = Console.ReadLine();
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
        /// Define qual vai ser a Taxa por hora do estácionamento.
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
        /// Adiciona um carro no estácionamento.
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

                if (!Carros.Contains(Placa))
                {
                    Console.Clear();
                    Carros.Add(Placa);
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
                else if (Placa == null)
                {
                    Console.Clear();
                    Console.WriteLine("É preciso digitar algo!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Como você chegou aqui?");
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
                Console.WriteLine("================================");
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
===================================
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
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
        /// <summary>
        /// Definindo o tempo que um carro passou no estácionamento
        /// </summary>
        /// <returns>O tempo em decimal</returns>
        public decimal InformandoTempo()
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
                MostraTodosCarro();
                Console.WriteLine(@"
========== Retirar Carro ==========
Digite a placa que deseja retirar:
===================================
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
ficou no estácionamento
======================================================
Tempo:");

                    decimal TotalPago = InformandoTempo() * TaxaPorHora + TaxaInicial;
                    Carros.Remove(Placa);
                    Console.Clear();
                    Console.WriteLine($@"
=============================== Carro Retirado ===============================
O carro de placa {Placa} foi retirado e pagou o valor total de R$ {TotalPago:F2} .
==============================================================================");
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
