using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
//new ByteBankAtendimento().AtendimentoCliente();

void TestaArrayDeContasCorrentes()
{
    ContaCorrente[] listaDeContas = new ContaCorrente[]
    {

        new ContaCorrente(874, "8756876-A"),
        new ContaCorrente(875, "6592049-B"),
        new ContaCorrente(876,"0921481-C"),
        new ContaCorrente(877, "2347521-D")

    };

    for (int i = 0; i < listaDeContas.Length; i++)
    {
        Console.WriteLine($"{listaDeContas[i].Conta}");
    }

}
TestaArrayDeContasCorrentes();