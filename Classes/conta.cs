using System;

namespace DIO.Bank
{
    public class conta
    {
        //INICIO ATRIBUTOS
        private Tipoconta Tipoconta {get; set;}
        private string Nome {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        
        public conta(Tipoconta tipoconta, double Saldo, double Credito, string Nome)
        {
            this.Tipoconta = tipoconta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }
        //FIM ATRIBUTOS

        //INICIO METODOS
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito*-1)){
                Console.WriteLine ("Saldo Insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine ("saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }
        public void Depositar (double valorDeposito){
            this.Saldo += valorDeposito;
            Console.WriteLine ("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir (double valorTransferencia, conta contaDestino){
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
            {
                string retorno = "";
                retorno += "Tipoconta"+ this.Tipoconta+"|";
                retorno += "Nome"+ this.Nome+"|";
                retorno += "Saldo" + this.Saldo+"|";
                retorno += "Credito"+this.Credito+"|";
                return retorno;
            }
        //FIM METODOS
    }
}