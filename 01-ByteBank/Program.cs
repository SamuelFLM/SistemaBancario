using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _SistemaBancario
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaCorrente contaUsuario = new ContaCorrente();

            Console.Write("Infome o nome do titular: ");
            contaUsuario.titular = Console.ReadLine();

            contaUsuario.agencia = RecebeInteiro("Informe número da agência:");
            contaUsuario.numero = RecebeInteiro("Informe número da conta:");

            Console.WriteLine($"Bem vindo(a) {contaUsuario.titular}");
            Console.WriteLine($"Agência: {contaUsuario.agencia}");
            Console.WriteLine($"Número: {contaUsuario.numero}");
            Console.WriteLine($"Saldo : {contaUsuario.saldo:F2}");

            int op;

            do
            {
                Console.WriteLine("\n\nOPÇÔES");
                Console.WriteLine("[1] - Depositar");
                Console.WriteLine("[2] - Sacar");
                Console.WriteLine("[3] - Transferir");
                Console.WriteLine("[4] - Sair");
                Console.Write("Digite: ");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("*********************");
                        Console.WriteLine("Deposito");
                        Console.Write("Infome o valor R$: ");
                        contaUsuario.Depositar(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
                        Console.WriteLine("Valor depositado com sucesso.");

                        Console.WriteLine($"Saldo atual: {contaUsuario.saldo:F2}");
                        Console.WriteLine("\n*********************");
                        break;
                    case 2:
                        Console.WriteLine("*********************");
                        Console.WriteLine("Sacar");
                        Console.Write("Infome o valor R$: ");
                        contaUsuario.Sacar(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
                        Console.WriteLine("Saque efetuado com sucesso.");
                        Console.WriteLine($"Saldo atual: {Convert.ToDouble(contaUsuario.saldo)}");
                        Console.WriteLine("\n*********************");
                        break;
                    case 3:

                        ContaCorrente contaTransferencia = new ContaCorrente();

                        Console.WriteLine("*********************");
                        Console.WriteLine("Transferencia");
                        Console.Write("Informe o nome: ");
                        contaTransferencia.titular = Console.ReadLine();


                        contaTransferencia.agencia = RecebeInteiro("Informe o número agência: ");
                        contaTransferencia.numero = RecebeInteiro("Informe o número da conta: ");

                        // metodo transferir
                        while (true)
                        {
                            Console.Write("Infome o valor que quer transferir: ");
                            string numero = Console.ReadLine();
                            double valor;
                            bool verificador = double.TryParse(numero, out valor);
                            if (verificador)
                            {
                                bool verif = contaUsuario.Sacar(valor);
                                if (verif)
                                {
                                    Console.WriteLine("****Transferencia**** ");
                                    Console.WriteLine($"De: {contaUsuario.titular}");
                                    Console.WriteLine($"Para: {contaTransferencia.titular}");
                                    Console.WriteLine($"Conta {contaUsuario.titular} AG:{contaUsuario.agencia}-NUM:{contaUsuario.numero}");
                                    Console.WriteLine($"Conta {contaTransferencia.titular} AG:{contaTransferencia.agencia}-NUM:{contaTransferencia.numero}");
                                    Console.WriteLine($"Saldo Transferido: R${valor}");
                                    Console.WriteLine($"Saldo Atual: R${contaUsuario.saldo}");
                                    Console.WriteLine("\n*********************");

                                    Console.WriteLine("Transferencia Efetuada com Sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Transferencia invalida, saldo insuficiente");
                                }
                                break;
                            }
                            Console.WriteLine("Parametro invalido, digite novamente!");
                        }

                        break;
                    case 4:
                        break;

                    default:
                        Console.WriteLine("Erro, Informe os numeros de 1 - 4");
                        break;
                }

            } while (op != 4);

            Console.WriteLine("\nFinalizando . . .");

            Console.ReadLine();
        }
        private static int RecebeInteiro(string message)
        {
            int retorno;

            while (true)
            {
                Console.Write(message);
                string numero = Console.ReadLine();
                int valor;
                bool verificador = int.TryParse(numero, out valor);
                if (verificador)
                {
                    retorno = valor;
                    break;
                }
                Console.WriteLine("Parametro invalido, digite novamente!");
            }
            return retorno;
        }

    }
}
