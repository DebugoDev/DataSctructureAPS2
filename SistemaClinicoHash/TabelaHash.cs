using System;
using System.Collections.Generic;
using System.Linq;

class TabelaHash
{
    private readonly int tamanho = 10;
    private readonly LinkedList<Paciente>[] buckets;

    public TabelaHash()
    {
        buckets = new LinkedList<Paciente>[tamanho];
    }

    private int CalcularIndice(string cpf)
    {
        return Math.Abs(cpf.GetHashCode()) % tamanho;
    }

    public void Inserir(Paciente paciente)
    {
        int indice = CalcularIndice(paciente.CPF);

        if (buckets[indice] == null)
            buckets[indice] = new LinkedList<Paciente>();

        var existente = Buscar(paciente.CPF);
        if (existente != null)
        {
            Console.WriteLine("Paciente já cadastrado!");
            return;
        }

        buckets[indice].AddLast(paciente);
    }

    public Paciente Buscar(string cpf)
    {
        int indice = CalcularIndice(cpf);
        var lista = buckets[indice];
        return lista?.FirstOrDefault(p => p.CPF == cpf);
    }

    public void Atualizar(string cpf, double novaPA, double novaTemp, double novaOx)
    {
        var paciente = Buscar(cpf);
        if (paciente == null)
        {
            Console.WriteLine("Paciente não encontrado.");
            return;
        }

        paciente.Pressao = novaPA;
        paciente.Temperatura = novaTemp;
        paciente.Oxigenacao = novaOx;
        paciente.Prioridade = paciente.CalcularPrioridade();
    }

    public void Remover(string cpf)
    {
        int indice = CalcularIndice(cpf);
        var lista = buckets[indice];

        if (lista == null) return;

        var paciente = Buscar(cpf);
        if (paciente != null)
            lista.Remove(paciente);
    }

    public void ExibirTabela()
    {
        for (int i = 0; i < tamanho; i++)
        {
            Console.Write($"Bucket {i}: ");
            if (buckets[i] != null && buckets[i].Count > 0)
            {
                foreach (var p in buckets[i])
                {
                    ConsoleHelper.ColorirPrioridade(p.Prioridade);
                    Console.WriteLine($"  -> {p}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Vazio");
            }
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
