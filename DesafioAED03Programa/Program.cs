//Adição de Bibliotecas
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    static List<(string nome, string vencimento, double valor)> despesas = new List<(string, string, double)>();

    static void Main(string[] args)
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Adicionar despesa");
            Console.WriteLine("2 - Exibir despesa");
            Console.WriteLine("3 - Valor total das despesas");
            Console.WriteLine("4 - Remover despesa");
            Console.WriteLine("5 - Buscar despesa");
            Console.WriteLine("6 - Editar despesa");
            Console.WriteLine("7 - Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarDespesa();
                    break;
                case "2":
                    ExibirDespesa();
                    break;
                case "3":
                    ValorDespesas();
                    break;
                case "4":
                    RemoverDespesa();
                    break;
                case "5":
                    BuscarDespesa();
                    break;
                case "6":
                    EditarDespesa();
                    break;
                case "7":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente Novamente");
                    break;
            }
        }
    }

    static void AdicionarDespesa()
    {
        Console.WriteLine("Nome da despesa:");
        string nome = Console.ReadLine();

        Console.WriteLine("Data de vencimento:");
        string vencimento = Console.ReadLine();

        double valor;
        Console.WriteLine("Valor:");
        string entrada = Console.ReadLine();
        if (!double.TryParse(entrada, out valor))
        {
            Console.WriteLine("Valor inválido.");
            return;

        }

        despesas.Add((nome, vencimento, valor));
        Console.WriteLine("Despesa adicionada com sucesso.");
    }


    static void ExibirDespesa()
    {
        if (despesas.Count == 0)
        {
            Console.WriteLine("Nenhuma despesa registrada");
            return;
        }

        Console.WriteLine("Despesas:");
        foreach (var despesa in despesas)
        {
            Console.WriteLine($"Nome: {despesa.nome}, Data de vencimento: {despesa.vencimento}, Valor: {despesa.valor}");

        }
    }

    static void ValorDespesas()
    {

        double total = 0;

        foreach (var despesa in despesas)
        {
            total += despesa.valor;
        }
        Console.WriteLine($"Valor total das despesas: {total:F2}");
    }

    static void RemoverDespesa()
    {
        if (despesas.Count == 0)
        {
            Console.WriteLine("Nenhuma despesa registrada.");
            return;
        }

        Console.WriteLine("Digite o nome da despesa a remover:");
        string entrada = Console.ReadLine();
        var despesa = despesas.FirstOrDefault(c => c.nome == entrada);

        if (despesa != default)
        {
            despesas.Remove(despesa);
            Console.WriteLine("Despesa removida com sucesso.");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    static void BuscarDespesa()
    {
        Console.Write("Digite o nome ou data de vencimento da despesa a buscar:");
        string entrada = Console.ReadLine();
        var despesa = despesas.FirstOrDefault(c => c.nome == entrada || c.vencimento == entrada);

        if (despesa != default)
        {
            Console.WriteLine($"Nome: {despesa.nome}, Data de vencimento: {despesa.vencimento} Valor: {despesa.valor}");
        }
        else
        {
            Console.WriteLine("Despesa não encontrada.");
        }
    }

    static void EditarDespesa()
    {
        Console.Write("Digite o nome da despesa a editar:");
        string nome = Console.ReadLine();
        var index = despesas.FindIndex(c => c.nome == nome);

        if (index != -1)
        {
            Console.Write("Nova data de vencimento: ");
            string novoVencimento = Console.ReadLine();

            double novoValor;
            Console.Write("Novo Valor:");
            string entradaNovoValor = Console.ReadLine();
            if (!double.TryParse(entradaNovoValor, out novoValor))
            {
                Console.WriteLine("Valor inválido");
                return;
            }

            despesas[index] = (despesas[index].nome, novoVencimento, novoValor);
            Console.WriteLine("Despesa atualizada com sucesso.");
        }
        else
        {
            Console.WriteLine("Despesa não encontrada.");
        }
    }
}