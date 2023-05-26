using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

partial class Program{
    static void UsarStreamNaConsole(){
              //Definindo que os dados que serao lidos é na Console, 
              //com dados digitados pelo usuario
        using(var fluxoDeEntrada = Console.OpenStandardInput()){

            var buffer = new byte[1024]; //1Kb

            while (true)
            {
                var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);
                System.Console.WriteLine($"bytes lidos na console: {bytesLidos}");

            }

            

        }
    }

    static void MandandoConsoleNoArquivo(){
        var caminhoNovoArquivo = "consoleNoArquivo.txt";
        using(var fluxoDeEntrada = Console.OpenStandardInput()){
            using(var fs = new FileStream(caminhoNovoArquivo, FileMode.Create)){
            
             var buffer = new byte[1024]; //1BK  

             while (true)
             {
                var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);
                fs.Write(buffer,0, bytesLidos);
                fs.Flush();
                System.Console.WriteLine($"Bytes lidos na console: {bytesLidos}");

             }
        }
        }
    }
}