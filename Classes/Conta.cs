using System;

namespace DIO.Bank
{
	public class Conta
	{
		// Atributos
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }
		private double Cripto{ get; set; }
		private double Investimento{ get; set; }
		// Métodos
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome, double cripto, double investimento)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
			this.Cripto = cripto;
			this.Investimento = investimento;
		}

		public bool Sacar(double valorSaque)
		{
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

		public bool ComprarCriptos(int unidadeCripto)
		{
			double valorCripto = 25 * unidadeCripto;
			if (this.Saldo - valorCripto < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
			this.Saldo -= valorCripto;
			this.Cripto += unidadeCripto;
			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
			Console.WriteLine("Você comprou o valor de {0} em cripto moedas e possui {1} unidades de criptos.", valorCripto, this.Cripto);

			return true;
		}
		public bool Investir(double valorInvestimento)
		{
			if (this.Saldo - valorInvestimento < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
			this.Saldo -= valorInvestimento;
			this.Investimento += valorInvestimento;

			Console.WriteLine("Valor investido é de {0} ", this.Investimento);
			Console.WriteLine("Valor do saldo da conta é de {0} ", this.Saldo);

			return true;
		}
        public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
			retorno += "Cripto Moedas " + this.Cripto + " | ";
			retorno += "Investimentos " + this.Investimento + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}
	}
}