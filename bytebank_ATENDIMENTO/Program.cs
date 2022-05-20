using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Definição das funções de teste.
//Definição de váriaveis e arrays
ContaCorrente[] listaDeContas = null;

int[] idades = new int[5];
idades[0] = 80;
idades[1] = 28;
idades[2] = 35;
idades[3] = 50;
idades[4] = 51;
//TestaArrayInt();
//TestaMaiorValorArray();
//TestaBuscarPalavra();

//Array amostra = Array.CreateInstance(typeof(double), 5);
//amostra.SetValue(5.9, 0);
//amostra.SetValue(1.8, 1);
//amostra.SetValue(7.10, 2);
//amostra.SetValue(10.0, 3);
//amostra.SetValue(6.9, 4);

//TestaMediaMediana(amostra);

//TestaArrayDeContaCorrente();

//TestaListaDeContaCorrente();

void TestaMaiorValorArray()
{
    int i = 0;
    int maiorValor = 0;
    while (idades.Length > i)
    {
        if (idades[i] > maiorValor)
        {
            maiorValor = idades[i];
        }
        i++;
    }
    Console.WriteLine($"A maior idade informada é {maiorValor}");
}

void TestaArrayInt()
{
	Console.Clear();
	Console.WriteLine("===============================");
	Console.WriteLine("===   CADASTRO DE CONTAS    ===");
	Console.WriteLine("===============================");
	Console.WriteLine("\n");
	ContaCorrente conta = new ContaCorrente(1);
	Console.WriteLine("===  Informe dados da conta  ===");
	Console.WriteLine("Número da Conta: " + conta.Conta);
	Console.Write("Informe Saldo: ");
	conta.Saldo = double.Parse(Console.ReadLine());
	Console.Write("Informe Titular: ");
	conta.Titular.Nome = Console.ReadLine();
	Console.Write("Informe CPF do Titular: ");
	conta.Titular.Cpf = Console.ReadLine();
	Console.Write("Informe Profissão do Titular: ");
	conta.Titular.Profissao = Console.ReadLine();
	listaDeContas.Add(conta);
	Console.WriteLine("... Conta cadastrada com sucesso! ...");
	Console.ReadKey();
}
ContaCorrente ConsultaPorCPFTitular(string cpf)
{
      return listaDeContas.Where((ContaCorrente conta) => conta.Titular.Cpf == cpf).SingleOrDefault();
}
ContaCorrente ConsultaPorNumeroConta(string numeroConta){
	
	return listaDeContas.Where((ContaCorrente conta) => conta.Conta == numeroConta).SingleOrDefault();
}

void TestaBuscarPalavra()
{

    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª palavra:");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Thread.Sleep(1000);

    Console.Write("Digite palavra a ser encontrada:");
    var busca = Console.ReadLine();

    foreach (string str in arrayDePalavras)
    {
        if (str.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {str}");
        }
        else
        {
            Console.WriteLine($"Palavra {busca} não encontrada");
        }
    }


}

void TestaMediaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para cálculo da média e mediana está vazio.");
    }

    //média
    double media = 0.0;
    foreach (var item in array)
    {
        media = media + (double)item;
    }
    media /= array.Length;

    //Mediana
    //Faço uma cópia da amostra
    var numerosOrdenados = (double[])array.Clone();
    //Faço a ordenação
    Array.Sort(numerosOrdenados);

    //calcula a mediana
    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? (double)numerosOrdenados[meio] : ((double)numerosOrdenados[meio] + (double)numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com base na amostra a média = {media} e a mediana = {mediana}.");

}

void TestaArrayDeContaCorrente()
{
    listaDeContas = new ContaCorrente[]
        {
                    new ContaCorrente(874, "5679787-A"),
                    new ContaCorrente(874, "4456668-B"),
                    new ContaCorrente(874, "7781438-C")
        };



    for (int indice = 0; indice < listaDeContas.Length; indice++)
    {
        ContaCorrente contaAtual = listaDeContas[indice];
        Console.WriteLine($"Conta {indice} {contaAtual.Conta}");
    }
}

void TestaListaDeContaCorrente()
{
    ListaDeContaCorrente lista = new ListaDeContaCorrente();
    lista.Adicionar(new ContaCorrente(123, "74182-X"));
    lista.Adicionar(new ContaCorrente(951, "78529-X"));
    lista.Adicionar(new ContaCorrente(159, "96365-X"));
    lista.Adicionar(new ContaCorrente(159, "96365-X"));
    lista.Adicionar(new ContaCorrente(159, "96365-X"));
    lista.Adicionar(new ContaCorrente(159, "96365-X"));
    var contaAndre = new ContaCorrente(999, "99999-Y");
    lista.Adicionar(contaAndre);
    //lista.ExibeLista();
    //lista.Remover(contaAndre);
    //Console.WriteLine("Removendo conta.");
    //lista.ExibeLista();

    for (int i = 0; i < lista.Tamanho; i++)
    {
        ContaCorrente conta = lista[i];
        Console.WriteLine($"Indice[{i}] = {conta.Conta} / {conta.Numero_agencia}");
    }

}
#endregion

#region Testando métodos e Propriedades de List


//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//  new ContaCorrente(852, "5679787-A"),
//  new ContaCorrente(987, "4456668-B"),
//  new ContaCorrente(357, "7781438-C")
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//  new ContaCorrente(951, "5679787-E"),
//  new ContaCorrente(321, "4456668-F"),
//  new ContaCorrente(719, "7781438-G")
//};


//Adicionando uma lista a lista
//_listaDeContas2.AddRange(_listaDeContas3);
//for (int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

//Console.WriteLine(_listaDeContas2.Contains(_listaDeContas2[0]));

//void ExibeLista()
//{
//    for (int i = 0; i < _listaDeContas2.Count; i++)
//    {
//        Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//    }
//}

//ExibeLista();
//_listaDeContas2.Clear();
//Console.WriteLine("Limpar lista.");
//ExibeLista();

//var range = _listaDeContas2.GetRange(0, 1);
//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}


#endregion

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
