



public class ContaCorrente // criação da class
{

    public string titular;
    public int agencia;
    public int numero;
    public double saldo = 100.00;

    public bool Sacar(double valor)
    {
        if (this.saldo < valor)
        {
            return false;
        }
        else
        {
            this.saldo -= valor;
            return true;
        }
    }

    public bool Depositar(double valor)
    {
        if (this.saldo > 0)
        {
            this.saldo += valor;
            return true;
        }
        else
            return false;

    }

    public bool Transferencia(double valor)
    {
        if(this.saldo < valor)
        {
            return false;
        }
        else
        {
            this.saldo -= valor;
            return true;
        }
    }



}
