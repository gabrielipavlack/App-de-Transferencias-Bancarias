using System;
using System.Collections.Generic;

namespace AppTransferenciasBancarias
{
  // enum TIPO CONTA:
  public enum TipoConta
  {
    PessoaFisica = 1,
    PessoaJuridica = 2
  }
  // CLASSE CONTA
  public class Conta
  {
    // encapsulamento de dados:
    private TipoConta tipoConta { get; set; }  // tipo Enum
    private double Saldo { get; set; }
    private double Credito { get; set; }
    private string Nome { get; set; }

    // construtor:
    public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
    {
      this.tipoConta = tipoConta;
      this.Saldo = saldo;
      this.Credito = credito;
      this.Nome = nome;
    }

    // MÉTODO PARA SACAR:
    public bool Sacar(double valorSaque)
    {
      if (this.Saldo - valorSaque < (this.Credito * -1))
      {
        return false;
      }
      else
      {
        this.Saldo -= valorSaque;
        Console.WriteLine("Saldo atual da conta: {0}", this.Saldo);
        return true;

      }
    }
    // MÉTODO DEPOSITAR
    public void Depositar(double valorDeposito)
    {
      this.Saldo += valorDeposito;
      Console.WriteLine("Saldo atual da conta: {0}", this.Saldo);

    }
    // METODO TRANSFERIR
    public void Transferir(double ValorTransferencia, Conta contaDestino)
    {
      // vamos usar o método Sacar para verificar se é possível fazer a transferencia, pois nele ja validamos se há saldo/credito suficiente
      if (this.Sacar(ValorTransferencia))
      {
        // a conta destino vai receber:
        contaDestino.Depositar(ValorTransferencia);


      }
    }

    // MÉTODO TO STRING (necessário sobrescrever o método padrão que ja vem na main)
    public override string ToString()
    {
      string retorno = " ";
      retorno += "Tipo conta : " + this.tipoConta + " | ";
      retorno += "Nome: " + this.Nome + " | ";
      retorno += "Saldo: " + this.Saldo + " | ";
      retorno += "Crédito: " + this.Credito + " | ";
      return retorno;
    }


  }
  class Program
  {

    static List<Conta> listContas = new List<Conta>();

    static void Main(string[] args)
    {

      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
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

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();


      // usando o método ToString:
      // Console.WriteLine(minhaConta.ToString());







    }
    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Bank a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar contas");
      Console.WriteLine("2- Inserir nova conta");
      Console.WriteLine("3- Transferir");
      Console.WriteLine("4- Sacar");
      Console.WriteLine("5- Depositar");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }

    // MÉTODO INSERIR CONTA
    private static void InserirConta()
    {
      Console.WriteLine("INSERIR NOVA CONTA");

      Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
      Console.WriteLine("[1] Conta Física  | [2] Conta Jurídica");
      int entradaTipoConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o Nome do Cliente: ");
      string entradaNome = Console.ReadLine();

      Console.Write("Digite o saldo inicial: ");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.Write("Digite o crédito: ");
      double entradaCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                    saldo: entradaSaldo,
                    credito: entradaCredito,
                    nome: entradaNome);

      listContas.Add(novaConta);
    }

    // MÉTODO LISTAR CONTAS
    private static void ListarContas()
    {
      Console.WriteLine("Listar contas");

      if (listContas.Count == 0)
      {
        Console.WriteLine("Nenhuma conta cadastrada.");
        return;
      }

      for (int i = 0; i < listContas.Count; i++)
      {
        Conta conta = listContas[i]; // criando e populando um objeto
        Console.Write("#{0} - ", i);
        Console.WriteLine(conta);
      }
    }

    private static void Sacar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser sacado: ");
      double valorSaque = double.Parse(Console.ReadLine());

      listContas[indiceConta].Sacar(valorSaque);
    }
    private static void Depositar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser depositado: ");
      double valorDeposito = double.Parse(Console.ReadLine());

      listContas[indiceConta].Depositar(valorDeposito);
    }
    private static void Transferir()
    {
      Console.Write("Digite o número da conta de origem: ");
      int indiceContaOrigem = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta de destino: ");
      int indiceContaDestino = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
    }

  }

}
