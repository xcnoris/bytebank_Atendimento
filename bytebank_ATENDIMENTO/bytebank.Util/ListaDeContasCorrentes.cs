using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util;

public class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    private int _proximaposicao = 0;
    public ListaDeContasCorrentes(int tamanhoInicial=5)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }

    public void AdicionarConta(ContaCorrente item)
    {
        Console.WriteLine($"Adicionanddo itens na posição {_proximaposicao}");
        VerificarCapacidade(_proximaposicao + 1);
        _itens[_proximaposicao] = item;
        _proximaposicao++;
    }

    private void VerificarCapacidade(int tamanhoNecessario)
    {
        if (_itens.Length >= tamanhoNecessario)
        {
            return;
        }
        else
        {
            Console.WriteLine("Aumentando a capacidade da lista!");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];
            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[1];
            }
            _itens = novoArray;
        }
    }
}
