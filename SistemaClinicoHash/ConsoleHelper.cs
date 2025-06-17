using System;

static class ConsoleHelper
{
    public static double LerDouble(string mensagem)
    {
        double valor;
        while (true)
        {
            Console.Write(mensagem);
            if (double.TryParse(Console.ReadLine(), out valor))
                return valor;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Entrada inválida! Digite um número.");
            Console.ResetColor();
        }
    }

    public static void ColorirPrioridade(string prioridade)
    {
        switch (prioridade.ToLower())
        {
            case "vermelha":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "amarela":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "verde":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            default:
                Console.ResetColor();
                break;
        }
    }
}
