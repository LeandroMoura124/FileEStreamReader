// See https://aka.ms/new-console-template for more information
using System.Text;
using LendoArquivos;

 internal class Program{
    private static void Main(string[] args){
        var enderecoDoArquivo  = "contas.txt";

        //using para tratar possiveis excecoes, como o arquivo ser nulo
        /*A syntax sugar existe em diversas linguagens. No C# nós temos o using,
        palavra reservada que garante a disposição correta de alguns objetos.
        se durante o processamento do arquivo uma exceção for lançada e o método Close()
        não for executado? Para nos assegurarmos que esse método é chamado, devemos usar a construção try/finally ou,
        melhor ainda, usar um bloco using - afinal, o Stream implementa a interface IDisposable*/
        using(var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open)){
            //StreamReader - é uma classe que permite que a gente leia por meio de seus metodos linhas/pedaços/bytes de um arquivo
            //Entao, essa classe agiliza e nao precisamos declacar uma variavel com fluxo de bytes e precisar decodificá-la
            var leitor = new StreamReader(fluxoDoArquivo);
            //Métodos que o StreamReader proporciona

            // ReadLine - Lê uma linha do arquivo
            // var linha = leitor.ReadLine();
            // System.Console.WriteLine(linha);

            //ReadToEnd - Lê o arquivo inteiro 
            // var texto = leitor.ReadToEnd();
            // System.Console.WriteLine(texto);

            //Read - traz o primeiro byte do arquivo
             //var numero = leitor.Read();
            // System.Console.WriteLine(numero);

                    //enquanto o leitor NAO (!) chegar ao fim do arquivo, do seu fluxo - EndOfStream
            while (!leitor.EndOfStream)
            {
                //vamos ler linha por linha
                var linha = leitor.ReadLine();
                System.Console.WriteLine(linha);
            }
            fluxoDoArquivo.Close();
        }

    }

    
}