class Paciente
{
    public string CPF { get; set; }
    public string Nome { get; set; }
    public double Pressao { get; set; }
    public double Temperatura { get; set; }
    public double Oxigenacao { get; set; }
    public string Prioridade { get; set; }

    public Paciente(string cpf, string nome, double pressao, double temperatura, double oxigenacao)
    {
        CPF = cpf;
        Nome = nome;
        Pressao = pressao;
        Temperatura = temperatura;
        Oxigenacao = oxigenacao;
        Prioridade = CalcularPrioridade();
    }

    public string CalcularPrioridade()
    {
        if (Pressao > 18 || Temperatura > 39 || Oxigenacao < 90)
            return "Vermelha";
        if (Pressao > 14 || Temperatura > 37.5 || Oxigenacao < 95)
            return "Amarela";
        return "Verde";
    }

    public override string ToString()
    {
        return $"CPF: {CPF} | Nome: {Nome} | PA: {Pressao} | Temp: {Temperatura}°C | O₂: {Oxigenacao}% | Prioridade: {Prioridade}";
    }
}
