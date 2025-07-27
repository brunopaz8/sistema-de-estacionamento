using Newtonsoft.Json;
using Sistema_de_Estacionamento.models;

Console.Clear();
Console.WriteLine("Bem vindo ao simulador de estacionamento!");

Estacionamento e = null;
bool escolhendo = true;

while (escolhendo)
{
    Console.WriteLine(@"
========== Selecione Uma Opção ==========
[1] - Recuperar dados do estacionamento
[2] - Criar um novo estacionamento
=========================================
Sua escolha:");
    string selecao = Console.ReadLine();
    
    switch (selecao)
    {
        case "1":
            Console.Clear();
            string estacionamentoJson = null;
            try
            {
                estacionamentoJson = File.ReadAllText("LocalDB/estacionamento.json");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Configuração do estacionamento não encontrada!");
                break;
            }
            e = JsonConvert.DeserializeObject<Estacionamento>(estacionamentoJson);
            escolhendo = false;
            break;

        case "2":
            Console.Clear();
            e = new Estacionamento();
            e.DefinirCapacidade();
            e.DefinirTaxaInicial();
            e.DefinirTaxaPorHora();
            escolhendo = false;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opção inválida!");
            break;
    }
}

while (true)
{
    Console.WriteLine(@"
======= Selecione Uma Opção =======
[1] - Adiciona um carro.
[2] - Retira um carro.
[3] - Mostra todos os carros.
[4] - Verifica as taxas.
[5] - Altera as taxas.
[6] - Finaliza o programa.
===================================
Sua escolha: ");
    string escolha = Console.ReadLine();

    switch (escolha)
    {
        case "1":
            Console.Clear();
            e.AdicionandoCarro();
            break;

        case "2":
            Console.Clear();
            e.RetirarCarro();
            break;

        case "3":
            Console.Clear();
            e.MostraTodosCarro();
            break;
       
        case "4":
            Console.Clear();
            e.MostraTaxas();
            break;
       
        case "5":
            Console.Clear();
            e.AlterarTaxa();
            break;

        case "6":
            Console.Clear();
            e.Salvando();
            Console.WriteLine("Programa Finalizado!");
            Environment.Exit(0);
            break;
       
        default:
            Console.Clear();
            Console.WriteLine("Opção inválida!");
            break;
    }
}
