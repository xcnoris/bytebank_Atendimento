using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

// Array de contas
ContaCorrente[] listaDeContas = new ContaCorrente[10];

void TestaListaDeContaCorrente()
{
    //ListaDeContaCorrente lista = new ListaDeContaCorrente();
    ListaDeContaCorrente lista = new ListaDeContaCorrente();

    ContaCorrente contaRicardo = new ContaCorrente(123, "12345-X");

    ContaCorrente[] contas = new ContaCorrente[]
    {
                contaRicardo,
                new ContaCorrente(369, "789123-A"),
                new ContaCorrente(258, "987321-B")
    };

    lista.AdicionarVarios(contas);

    lista.AdicionarVarios(
        contaRicardo,
         new ContaCorrente(369, "789123-A"),
         new ContaCorrente(258, "987321-B"),
         new ContaCorrente(258, "987321-C"),
         new ContaCorrente(258, "987321-D"),
         new ContaCorrente(258, "987321-E"),
         new ContaCorrente(258, "987321-F"),
         new ContaCorrente(258, "987321-G")
    );

    for (int i = 0; i < lista.Tamanho; i++)
    {
        ContaCorrente itemAtual = lista[i];
        Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero_agencia}/{itemAtual.Numero_agencia}");
    }
}

void TestaArrayDeContaCorrente()
{
    ContaCorrente[] contas = new ContaCorrente[]
        {
                    new ContaCorrente(874, "5679787-A"),
                    new ContaCorrente(874, "4456668-B"),
                    new ContaCorrente(874, "7781438-C")
        };

    for (int indice = 0; indice < contas.Length; indice++)
    {
        ContaCorrente contaAtual = contas[indice];
        Console.WriteLine($"Conta {indice} {contaAtual.Conta}");
    }
}

void TestaArrayInt()
{
    // ARRAY de inteiros, com 5 posições!
    int[] idades = null;
    idades = new int[3];

    idades[0] = 15;
    idades[1] = 28;
    idades[2] = 35;
    //idades[3] = 50;
    //idades[4] = 28;
    //idades[5] = 60;

    Console.WriteLine(idades.Length);

    int acumulador = 0;
    for (int indice = 0; indice < idades.Length; indice++)
    {
        int idade = idades[indice];

        Console.WriteLine($"Acessando o array idades no índice {indice}");
        Console.WriteLine($"Valor de idades[{indice}] = {idade}");

        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}