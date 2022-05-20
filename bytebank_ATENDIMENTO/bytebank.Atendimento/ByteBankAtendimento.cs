using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
    internal class ByteBankAtendimento
    {
        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>();
        private int numeroConta;

        public ByteBankAtendimento(int _numeroConta)
        {
            this.numeroConta = _numeroConta;
        }
        public void AtendimentoCliente()
        {
            try
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
                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {

                        throw new ByteBankException(excecao.Message);
                    }

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
            catch (ByteBankException excecao)
            {

                Console.WriteLine($"{excecao.Message}"); ;
            }

        }
   
        void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia == null)
            {
                Console.WriteLine(" ... A consulta não retornou dados ...");
            }
            else
            {
                foreach (var item in contasPorAgencia)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
        {
            var consulta = (from conta in _listaDeContas
                            where conta.Numero_agencia == numeroAgencia
                            select conta).ToList();

            return consulta;
        }

        ContaCorrente ConsultaPorCPFTitular(string? cpf)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //return conta;
            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
        }

        ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Conta.Equals(numeroConta))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //return conta;

            return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
        }

        void OrdenarConta()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de Contas ordenadas ...");
            Console.ReadKey();
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
            ContaCorrente conta = null;
            foreach (ContaCorrente item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
            }
            else
            {
                Console.WriteLine(" ... Conta para remoção não encontrada ...");
            }

            Console.ReadKey();
        }

        void ListarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     LISTA DE CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }
            foreach (ContaCorrente item in _listaDeContas)
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

        void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   CADASTRO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            ContaCorrente conta = new ContaCorrente(this.numeroConta);

            Console.WriteLine("===  Informe dados da conta  ===");
            //Console.Write("Número da Conta: ");
            //string? numeroConta = Console.ReadLine();
            //Console.Write("Número da Agência: ");
            //int numeroAgencia = int.Parse(Console.ReadLine());
            //ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);
            Console.WriteLine($"[Nova] Número da Conta: {conta.Conta}");
            Console.Write("Informe Saldo: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Informe Titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("Informe CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Informe Profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);

            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }

        void PesquisarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    PESQUISAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2)CPF TITULAR ou (3) N° AGÊNCIA ? ");
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
                case 3:
                    {
                        Console.Write("Informe o N° da Agência: ");
                        int _numeroAgencia = int.Parse(Console.ReadLine());
                        var _contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                        ExibirListaDeContas(_contasPorAgencia);
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }
        }

        void EncerrarAplicacao()
        {
            Console.WriteLine("... Encerrando a aplicação, pressione qualquer tecla para sair! ...");
            Console.ReadKey();
        }
    }


}
