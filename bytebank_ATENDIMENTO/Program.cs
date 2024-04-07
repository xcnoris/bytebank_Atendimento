using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;
Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
new ByteBankAtendimento().AtendimentoCliente();


// Hello world do passado :>) 
// Finalizado em 07/04/2024
#region Exemplos Arrays em Csharp   
ContaCorrente conta1 = new ContaCorrente(777, "7654321-A");


ContaCorrente conta2 = new ContaCorrente(777, "7654321-C");
conta2.Depositar(10400);

ContaCorrente conta3 = new ContaCorrente(777, "7654321-G");
conta3.Depositar(120000);

ContaCorrente conta4 = new ContaCorrente(777, "7654321-H");
conta4.Depositar(13000);

ContaCorrente conta5 = new ContaCorrente(777, "7654321-L");
conta5.Depositar(5000);


void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.AdicionarConta(new ContaCorrente(874, "8756876-A"));
    listaDeContas.AdicionarConta(new ContaCorrente(875, "6592049-B"));
    listaDeContas.AdicionarConta(new ContaCorrente(876, "0921481-C"));
    listaDeContas.AdicionarConta(new ContaCorrente(877, "2347521-D"));
    listaDeContas.AdicionarConta(new ContaCorrente(877, "2347521-E"));
    listaDeContas.AdicionarConta(new ContaCorrente(877, "2347521-F"));
    listaDeContas.AdicionarConta(conta1);
    listaDeContas.AdicionarConta(conta2);
    listaDeContas.AdicionarConta(conta3);
    listaDeContas.AdicionarConta(conta4);
    listaDeContas.AdicionarConta(conta5);
    //listaDeContas.ExibirLista();
    //Console.WriteLine("============================================");
    //listaDeContas.Remover(conta1);
    //listaDeContas.ExibirLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }



}
//  TestaArrayDeContasCorrentes();
#endregion 