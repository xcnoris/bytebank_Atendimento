using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

List<ContaCorrente> listaDeContas = new List<ContaCorrente>();
try
{
	AtendimentoCliente();
}
catch (Exception exception)
{
	Console.WriteLine(exception.StackTrace);
	Console.WriteLine(new ByteBankException(exception.Message, exception).Message);
}
void AtendimentoCliente()
{
	char opcao = '0';
	while (opcao != '6')
	{
		Console.Clear();
		Console.WriteLine("===============================");
		Console.WriteLine("===        ATENDIMENTO      ===");
		Console.WriteLine("=== 1 - Cadastrar Contas    ===");
		Console.WriteLine("=== 2 - Listar Contas       ===");
		Console.WriteLine("=== 3 - Remover Contas      ===");
		Console.WriteLine("=== 4 - Ordenar Contas      ===");
		Console.WriteLine("=== 5 - Pesquisar Contas    ===");
		Console.WriteLine("=== 6 - Sair do sistema     ===");
		Console.WriteLine("===============================");
		Console.WriteLine("\n");
		Console.Write("Digite a Opção desejada: ");
		opcao = Console.ReadLine()[0];
		switch (opcao)
		{
			case '1':
				CadastrarConta();
				break;
			case '2':
				ListarConta();
				break;
			case '3':
				RemoverConta();
				break;
			case '4':
				OrdenarConta();
				break;
			case '5':
				PesquisarConta();
				break;
			case '6':
				EncerrarAplicacao();
				break;
			default:
				Console.WriteLine("Opção não implementada.");
				break;
		}
	}
}
void CadastrarConta()
{
	Console.Clear();
	Console.WriteLine("===============================");
	Console.WriteLine("===   CADASTRO DE CONTAS    ===");
	Console.WriteLine("===============================");
	Console.WriteLine("\n");
	ContaCorrente conta2 = new ContaCorrente(1);
	Console.WriteLine("===  Informe dados da conta  ===");
	Console.WriteLine("Número da Conta: " + conta2.Conta);
	Console.Write("Informe Saldo: ");
	conta2.Saldo = double.Parse(Console.ReadLine());
	Console.Write("Informe Titular: ");
	conta2.Titular.Nome = Console.ReadLine();
	Console.Write("Informe CPF do Titular: ");
	conta2.Titular.Cpf = Console.ReadLine();
	Console.Write("Informe Profissão do Titular: ");
	conta2.Titular.Profissao = Console.ReadLine();
	listaDeContas.Add(conta2);
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
static void EncerrarAplicacao()
{
	Console.WriteLine("... Encerrando a aplicação, pressione qualquer tecla para sair! ...");
	Console.ReadKey();
}
void ListarConta()
{
	Console.Clear();
	Console.WriteLine("===============================");
	Console.WriteLine("===     LISTA DE CONTAS     ===");
	Console.WriteLine("===============================");
	Console.WriteLine("\n");
	if (listaDeContas.Count <= 0)
	{
		Console.WriteLine("... Não há contas cadastradas! ...");
		Console.ReadKey();
		return;
	}
	foreach (ContaCorrente item in listaDeContas)
	{
		Console.WriteLine("===  Dados da Conta  ===");
		Console.WriteLine("Número da Conta : " + item.Conta);
		Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
		Console.WriteLine("CPF do Titular  : " + item.Titular.Cpf);
		Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
		Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
		Console.ReadKey();
	}
}
void OrdenarConta()
{
	listaDeContas.Sort();
	Console.WriteLine("... Lista de Contas ordenadas ...");
	Console.ReadKey();
}
void PesquisarConta()
{
	Console.Clear();
	Console.WriteLine("===============================");
	Console.WriteLine("===    PESQUISAR CONTAS     ===");
	Console.WriteLine("===============================");
	Console.WriteLine("\n");
	Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2)CPF TITULAR ? ");
	switch (int.Parse(Console.ReadLine()))
	{
		case 1:
			{
				Console.Write("Informe o número da Conta: ");
				string _numeroConta = Console.ReadLine();
				ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
				Console.WriteLine(consultaConta.ToString());
				Console.ReadKey();
				break;
			}
		case 2:
			{
				Console.Write("Informe o CPF do Titular: ");
				string _cpf = Console.ReadLine();
				ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
				Console.WriteLine(consultaCpf.ToString());
				Console.ReadKey();
				break;
			}
		default:
			Console.WriteLine("Opção não implementada.");
			break;
	}
}
void RemoverConta()
{
	Console.Clear();
	Console.WriteLine("===============================");
	Console.WriteLine("===      REMOVER CONTAS     ===");
	Console.WriteLine("===============================");
	Console.WriteLine("\n");
	Console.Write("Informe o número da conta: ");
	string numeroConta = Console.ReadLine();
	ContaCorrente conta = new ContaCorrente(1);
	foreach (ContaCorrente item2 in listaDeContas)
	{
		if (item2.Conta.Equals(numeroConta))
		{
			conta = item2;
		}
	}
	listaDeContas.Remove(conta);
	Console.WriteLine("... Conta removida da lista! ...");
	Console.ReadKey();
}