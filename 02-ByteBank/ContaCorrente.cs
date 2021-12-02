



public class ContaCorrente // criação da class
{

    public string titular;
    public int agencia;
    public int numero;
    public double saldo = 100;
    
    public bool Sacar(double valor) // função
    {
        if(this.saldo < valor) // This  = Olha o valor da instancia
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
