using System;

class SistemaClinico
{
    private readonly TabelaHash tabelaHash = new();

    public void Menu()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA CLÍNICO HASH ===");
                Console.WriteLine("1 - Cadastrar Paciente");
                Console.WriteLine("2 - Buscar Paciente");
                Console.WriteLine("3 - Atualizar Dados Clínicos");
                Console.WriteLine("4 - Remover Paciente");
                Console.WriteLine("5 - Exibir Tabela Hash");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1": CadastrarPaciente(); break;
                    case "2": BuscarPaciente(); break;
                    case "3": AtualizarPaciente(); break;
                    case "4": RemoverPaciente(); break;
                    case "5": tabelaHash.ExibirTabela(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }

    private void CadastrarPaciente()
    {
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();
        Console.Write("Nome completo: ");
        string nome = Console.ReadLine();

        double pressao = ConsoleHelper.LerDouble("Pressão arterial: ");
        double temp = ConsoleHelper.LerDouble("Temperatura corporal: ");
        double oxi = ConsoleHelper.LerDouble("Nível de oxigenação: ");

        Paciente paciente = new(cpf, nome, pressao, temp, oxi);
        tabelaHash.Inserir(paciente);
        Console.WriteLine("Paciente cadastrado com sucesso!");
        Console.ReadKey();
    }

    private void BuscarPaciente()
    {
        Console.Write("Digite o CPF: ");
        string cpf = Console.ReadLine();
        var paciente = tabelaHash.Buscar(cpf);

        if (paciente != null)
        {
            ConsoleHelper.ColorirPrioridade(paciente.Prioridade);
            Console.WriteLine(paciente);
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Paciente não encontrado.");
        }

        Console.ReadKey();
    }

    private void AtualizarPaciente()
    {
        Console.Write("Digite o CPF: ");
        string cpf = Console.ReadLine();

        double novaPA = ConsoleHelper.LerDouble("Nova Pressão arterial: ");
        double novaTemp = ConsoleHelper.LerDouble("Nova Temperatura corporal: ");
        double novaOx = ConsoleHelper.LerDouble("Nova Oxigenação: ");

        tabelaHash.Atualizar(cpf, novaPA, novaTemp, novaOx);
        Console.WriteLine("Paciente atualizado com sucesso!");
        Console.ReadKey();
    }

    private void RemoverPaciente()
    {
        Console.Write("Digite o CPF para remover: ");
        string cpf = Console.ReadLine();

        tabelaHash.Remover(cpf);
        Console.WriteLine("Remoção concluída.");
        Console.ReadKey();
    }
}
