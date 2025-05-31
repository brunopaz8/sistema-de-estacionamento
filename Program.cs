using Sistema_de_Estacionamento.models;

Estacionamento e = new Estacionamento();

Console.Clear();
Console.WriteLine("Bem vindo ao simulador de estácionamento!");
e.DefinirCapacidade();
e.DefinirTaxaInicial();
e.DefinirTaxaPorHora();

while (true)
{

    Console.WriteLine(@"
======= Selecione Uma Opção =======
[1] - Adiciona um carro.
[2] - Retira um carro.
[3] - Mostra todos os carros.
[4] - Verifica as taxas.
[5] - Altera as taxas.
[6] - Finaliza o progama.
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
            Console.WriteLine("Progama Finalizado!");
            Environment.Exit(0);
            break;
       
        default:
            Console.Clear();
            Console.WriteLine("Opção inválida!");
            break;
    }
}
