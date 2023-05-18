using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LendoArquivos
{
    public class ContaCorrente
    {
        public Cliente Titular {get; set;}
        public int  Numero {get; set;}
        public int Agencia {get;set;}
        public double Saldo {get; private set;}

        public ContaCorrente(int agencia, int numero)
        {
            this.Agencia = agencia;
            this.Numero = numero;
            
        }
        public void Depositar(double valor){
            if (valor <= 0)
            {
                throw new ArgumentException("Valor de depósito deve ser maior que zero.", nameof(valor));
            }
            Saldo += valor;
        }
        
        public void Sacar(double valor){
            if (valor <=0)
            {
                throw new ArgumentException("Valor do saque deve ser maior que zero.");
            }
            if (valor > Saldo)
            {
                throw new InvalidOperationException("Valor insuficiente para saque.");
            }
            Saldo +=valor;
        }

    }
}