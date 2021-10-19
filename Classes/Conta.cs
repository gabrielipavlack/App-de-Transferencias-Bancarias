namespace AppTransferenciasBancarias
{
  public class Conta
  {

    //private TipoConta tipoConta { get; set; }  // tipo Enum
    private double Saldo { get; set; }
    private double Credito { get; set; }
    private string Nome { get; set; }

    // construtor:
    public Conta( double saldo, double credito, string nome)
    {
      //this.tipoConta = tipoConta;
      this.Saldo = saldo;
      this.Credito = credito;
      this.Nome = nome;
    }




  }
}


