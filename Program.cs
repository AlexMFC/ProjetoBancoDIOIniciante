using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {//Banco de dados
        static List<conta> listContas = new List<conta>();
        //Banco de dados
        static void Main(string[] args)
        {
            string opcaoUsuario =  ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                       Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado pela utilização de nossos serviços");
            Console.ReadLine();
        }

    private static void Depositar()
    {
      Console.Write("Digite o número da conta:");
      int idConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor do deposito: ");
      double valorDeposito = double.Parse(Console.ReadLine());

      listContas[idConta].Depositar(valorDeposito);
    }

    private static void Sacar()
    {
      Console.Write("Digite o número da conta:");
      int idConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor do saque: ");
      double valorSaque = double.Parse(Console.ReadLine());

      listContas[idConta].Sacar(valorSaque);
    }

    private static void ListarContas()
    {
      Console.WriteLine("Listagem de contas");;

      if (listContas.Count==0){
          Console.WriteLine("Nenhuma conta existente no banco de dados");
          return;
      }
      for (int i =0; i <listContas.Count; i++){
          conta conta = listContas[i];
          Console.Write("#{0}-", i);
          Console.WriteLine(conta);
      }
    }

    private static void Transferir()
    {
      Console.WriteLine("Transferência");
      
       Console.WriteLine("Digite a conta de origem: ");
       int contaOrigem = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a conta de destino: ");
      int contaDestino = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a quantia que deseja transferir");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listContas[contaOrigem].Transferir(valorTransferencia, listContas[contaDestino]);
    }

    private static void InserirConta()
    {
      Console.WriteLine("Inserir nova conta");

      Console.Write("Digite 1 para Conta Fisica ou 2 para Conta Juridica");
      int entradaTipoConta = int.Parse(Console.ReadLine());
      if (entradaTipoConta == 1){
        Console.Write("Digite o nome do cliente: ");
    }
      if (entradaTipoConta == 2){
        Console.WriteLine("Digite o nome da entidade:");
    }
      string entradaNome = Console.ReadLine();
      
      Console.Write("Digite o saldo inicial: ");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.Write("Digite o crédito disponível: ");
      double entradaCredito = double.Parse(Console.ReadLine());

      conta novaConta = new conta(tipoconta:(Tipoconta)entradaTipoConta, 
                                                        Saldo: entradaSaldo, 
                                                        Credito: entradaCredito, 
                                                        Nome: entradaNome);
        listContas.Add(novaConta); //INSERE CONTA NO ''BANCO DE DADOS''
    }

    private static  string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("App Banco Digital");
            Console.WriteLine("Informe a ação desejada");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Saque");
            Console.WriteLine("5 - Depósito");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
