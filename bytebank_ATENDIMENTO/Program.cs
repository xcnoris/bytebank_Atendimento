using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;
Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
//new ByteBankAtendimento().AtendimentoCliente();

void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.AdicionarConta(new ContaCorrente(874, "8756876-A"));
    listaDeContas.AdicionarConta(new ContaCorrente(875, "6592049-B"));
    listaDeContas.AdicionarConta(new ContaCorrente(876, "0921481-C"));
    listaDeContas.AdicionarConta(new ContaCorrente(877, "2347521-D"));
    listaDeContas.AdicionarConta(new ContaCorrente(877, "2347521-E"));
    listaDeContas.AdicionarConta(new ContaCorrente(877, "2347521-F"));
}
TestaArrayDeContasCorrentes();