using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
Console.WriteLine("\n\n");
Console.Write("===> INFORME O NÚMERO DA AGÊNCIA: ");
try
{
   new ByteBankAtendimento(int.Parse(Console.ReadLine())).AtendimentoCliente();
}
catch (ByteBankException exception)
{
    Console.WriteLine(exception.Message);
    
}
