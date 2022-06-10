using bytebank_ATENDIMENTO.bytebank.Atendimento;


Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
Console.WriteLine("\n\n");
Console.Write("===> INFORME O NÚMERO DA AGÊNCIA: ");
try
{
   new ByteBankAtendimento(int.Parse(Console.ReadLine())).AtendimentoCliente();
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
    Console.ReadKey();
}
