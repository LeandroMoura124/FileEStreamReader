using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




partial class Program{
  /*Vamos trabalhar com escrita binaria no arquivo, para otimizá-lo
  por exemplo, um valor booleano ocupa mais bytes do q o necessario no nosso buffer
  Vamos otimizar isso*/

    static void escritaBinaria(){
      using (var fs = new FileStream("contaCorrente.txt", FileMode.Create)){
                            //BinaryWriter - iremos escrever no arquivo de forma binaria
        using(var escritor = new BinaryWriter(fs)){
            escritor.Write(456); //numero da agencia
            escritor.Write(454211); // num da conta
            escritor.Write(5521.21); // saldo da conta
            escritor.Write("Leandro Moura"); // titular da conta
        }
      }

    }

    //Agora vamos criar um metodo especializado em ler arquivo binário - BinaryReader()

    static void lerBinario(){
        using(var fs = new FileStream("contaCorrente.txt", FileMode.Open)){
            using(var leitor = new BinaryReader(fs)){
                var agencia = leitor.ReadInt32();
                var numero = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                System.Console.WriteLine($"{agencia}/{numero}, {titular}, {saldo}");
            }
        }
    }

}
