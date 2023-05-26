using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

    partial class Program
    {

        //criando um arquivo csv - com bytes
        static void CriarArquivo(){
            // dando um nome pro arquivo
            var caminhoNovoArquivo = "contasExportadas.csv";

            //criando o fluxo de arquivo                caminho               create() - criando o arquivo
            using(var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)){
                
                var contaComoString = "456, 7845, 4552.42, Leandro Moura";

                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComoString); //guardando em bytes, ao contrario do q fizemos anteriormente

                fluxoDoArquivo.Write(bytes, 0, bytes.Length);

            }
        }

        //Criando arquivos e manipulando com mais facilidade com propiedades da classe
        static void criandoArquivoComWriter(){
            var caminhoNovoArquivo = "contasExportadas.csv";
                                                                        //Create e Create.New
                                                                        //se colocarmos FileMode.CreateNew
                                                                        //ele funciona caso nao exista nenhum outro arquivo com o mesmo nome criado
                                                                        //Agora o Create, podemos declarar o mesmo nome do arquivo e o conteudo é subtituido no anterior criado
            using(var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)){

                //StreamWriter - é uma classe que permite que a gente Escreva por meio de seus metodos linhas/pedaços/bytes de um arquivo
                using(var escritor = new StreamWriter(fluxoDoArquivo)){
                    escritor.Write("422, 4562, 4412.45, Leandro");
                }

            }
        }  

        //entendendo o método flush
        //vamos criar um método para avaliar quando de fato um dado é gravado no nosso arquivo
        static void testaEscrita(){
            var caminhoNovoArquivo = "testaEscrita.txt";

            using(var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)){
                using(var escritor = new StreamWriter(fluxoDoArquivo)){
                    for (int i = 0; i < 1000000; i++)
                    {
                        escritor.WriteLine($"Linha {i}");
                        escritor.Flush(); // despeja os dados automaticamente no arquivo
                        System.Console.WriteLine($"Linha {i} foi escrita no arquivo. Aperte enter...");
                        Console.ReadLine();
   
                    }
                    //Esse looping tá enviando dados para o buffer do StreamWriter
                    //os bytes do buffer só serão passados para o fileStream, ou seja, para o arquivo criado
                    //quando o looping tiver terminado
                    //Dessa forma, notamos q nao é viável trabalharmos desse jeito, justamente pela demora de gravar os dados

                    //A resolucao disso, é utilizarmos o métod flush()
                    //que basicamente, vai despejar os dados do buffer StreamWriter automaticamento no filestream  a cada dado passado
                }

            }
        }
    }
