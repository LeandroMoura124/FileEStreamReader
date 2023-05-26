// See https://aka.ms/new-console-template for more information
using System.Text;
using LendoArquivos;

 partial class Program{
    static void Main(string[] args){
        //Criando arquivo 
        // criandoArquivoComWriter();
        // testaEscrita();
        
        // escritaBinaria();
        // lerBinario();
        // UsarStreamNaConsole();
         MandandoConsoleNoArquivo();
         System.Console.WriteLine("Aplicação finalizada...");

        #region Metodos da Classe File - jeito mais simples de ler arquivos
        
        var linhas = File.ReadAllLines("contas.txt");
        System.Console.WriteLine(linhas.Length);

        foreach (var item in linhas)
        {
            System.Console.WriteLine(item);
        }

        var linhasLeBytes = File.ReadAllBytes("contas.txt");
        System.Console.WriteLine($"Arquivo contas.txt possui {linhasLeBytes.Length} bytes");

        //AllText Cria um arquivo no primeiro argumento - armazena o texto escrito no segundo argumento
        File.WriteAllText("escrevendoComAclasseFile.txt", "Testando File.WriteAllText");





        System.Console.WriteLine("====================\n\n\n\n\n\n");

        #endregion


        #region  Trabalhando com sobrecargas do StreamWrite
        //além de mandar escrever string
        // a Classe Stream contém sobrecargar ao declarar o argumento na propriedade Write da classe
        //entao, podemos passar valores strings como ja vimos, booleanos, int, char e longs
        var caminhoNovoArquivo = "TestaTiposDadosStreamWrite.csv";
                                                                        //Create e Create.New
                                                                        //se colocarmos FileMode.CreateNew
                                                                        //ele funciona caso nao exista nenhum outro arquivo com o mesmo nome criado
                                                                        //Agora o Create, podemos declarar o mesmo nome do arquivo e o conteudo é subtituido no anterior criado
        using(var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)){

            using(var escritor = new StreamWriter(fluxoDoArquivo)){
                //Trabalhando com a sobrecarga
                escritor.WriteLine(true);
                escritor.WriteLine(false);
                escritor.WriteLine(45454645);
            }

            // System.Console.WriteLine("Aplicação finalizada");

        }
        #endregion
        

        #region  Lendo arquivos txt
        //armazenando o endereco do arquivo
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
                var ContaCorrente =  ConverterStringParaContaCorrente(linha);
                var msg = $"Titular da Conta: {ContaCorrente.Titular.Nome}\nConta número: {ContaCorrente.Numero}\nAgência: {ContaCorrente.Agencia}\nSaldo: {ContaCorrente.Saldo} ";
                System.Console.WriteLine("================================");
                System.Console.WriteLine(msg);
            }
            fluxoDoArquivo.Close();
            #endregion
        
        
        }

    }



    //metodo do tipo classe ContaCorrente para pegar as strings do arquivo e converter/jogar na classe ContaCorrente
    static ContaCorrente ConverterStringParaContaCorrente(string linha){
        // 375 4644 2483.13 Jonatan
        var campos = linha.Split(','); //metodo split(' ') está trantando virgular como parametro de separador de dados

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2];
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numeroComInt = int.Parse(numero);
        //saldo tem que ser convertido em double quando o usuario digitar o valor informado
        var saldoComoDouble = Double.Parse(saldo.Replace('.', ','));

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
        resultado.Depositar(saldoComoDouble);
        resultado.Titular = titular;

        return resultado;
    }



    
}