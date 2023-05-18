// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace LendoArquivos{
// //partial - permite trabalharmos na class program só que em diferentes arquivos
//     partial class Program {
//             static void Main(string[] args){
//             #region Armazenando o endereço do arquivo e lendo com fluxo de bytes
//                 var enderecoDoArquivo = "contas.txt";

//                 //tratando uma possível exceção - USING() - Pois o arquivo pode ser nullo, no entanto, esse metodo trata a excecao automaticamente
//                 using(var fluxoDoArquivo = new  FileStream(enderecoDoArquivo, FileMode.Open))
//                 {
//                 var numeroDeBytesLidos = -1;
//                 //FileStrem - Fluxo de arquivo       arquivo que vamos trabalhar(conta.txt) e qual funcao iremos manusear ele,
//                 //no caso é a FileMode.open - vamos abrir esse arquivo
//                 //Essa é a estrura dos parametros da codificao do fluxo de arquivos
//                 // var fluxoDoArquivo = new  FileStream(enderecoDoArquivo, FileMode.Open);

//                 //Antes de abrir, a gente precisa fazer o metodo Read() para recuperar os bytes do arquivo

//                 /*O método Read() retorna um int indicando quantos bytes foram guardados no buffer. Este número
//                 está sempre no intervalo de 0 até o número de bytes que pedimos para o stream ler (1024 nesta chamada).
//                 Ao atingir o final do arquivo, o retorno do método será 0.*/

//                 //Estrutura - public override int Read(byte[] array, int offset, int count)
//                                                         //buffer-
//                                         //Trata-se de um array onde a gente guardará informações temporárias
//                 //temos um array no parametro, o int offset indica a partir de qual indice esse array começara a
//                 //ser lido, e o int count conta até quanto o array será lido

//                 var buffer = new byte[1024]; // 1024 posições de bytes nem array = 1KB 

//                 while(numeroDeBytesLidos != 0 ){
//                     numeroDeBytesLidos =  fluxoDoArquivo.Read(buffer, 0, 1024);
//                     System.Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
//                     escreverBuffer(buffer, numeroDeBytesLidos);
//                                 //byte     até quanto ele irá ler sem repetir as informações -- Assim o 
//                                 // buffer nao decodifica de 0 até 1024, mas sim até baseado nos numeroDeBytesLidos - conforme o parâmetro
//                 // fluxoDoArquivo.Read(buffer, 0, 1024); // no array byffer, será lido desde a posicao 0 até a posição 1024
            
//                 //fechando o arquivo para nao ser corrompido após aberto na nossa aplicação c#
//                 }
//                 // System.Console.WriteLine(fluxoDoArquivo.GetType());
//                 fluxoDoArquivo.Close();





                    /*Ficou evidente, então, que quando trabalhamos com buffers é necessário bastante cuidado
                   com os intervalos utilizados. Ao invés de lidar diretamente com o FileStream e bytes de Stream, 
                   podemos usar uma classe que encapsula esta lógica, o StreamReader:*/

//             }
            
//             #endregion

//         }


//         //metodos especializado para decodificar um arquivo lido em bytes
//         static void escreverBuffer(byte[] buffer, int bytesLidos){
//             //encoding - traduzindo os bytes buffer para texto da Língua Portuguesa
//             /*Para realizar a decodificação e a codificação no .NET, temos a classe Encoding.
//             Vamos alterar o método EscreverBuffer() para utilizar o encoding UTF-8:*/
//             var utf8 = new UTF8Encoding();

//             // var encoding = Encoding.UTF8; EXEMPLO

//             //GetString - metodo para obter uma string a partir do UTF8
//             //public virtual string getString(byte[] bytes, int index, int count)
//             var texto = utf8.GetString(buffer, 0, bytesLidos);

//             Console.WriteLine(texto);
//         /*
//             foreach (var meuByte in buffer)
//             {
//                 System.Console.Write(meuByte);
//                 System.Console.Write(" ");
//             }
//         */
//         }
//     }
// }
