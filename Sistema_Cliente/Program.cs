﻿
using System;
using System.Collections;
using System.IO;

namespace Sistema_Cliente
    {
    class Program
    {
        static string ficheiro = @"C:\Users\jessi_001\source\repos\Sistema_Cliente\Cliente.txt";//Endereço para o arquivo txt,onde ira simular o banco de dados
        static StreamWriter file;
        static ArrayList pessoas = new ArrayList();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White; //cor do fundo de tela
            CarregarArquivoCliente(); //traz o módulo responsável por carregar o arquivo criado pelo streamwriter para o método main
            Escolher(); //exibe o menu 
        }
        //-----------##--------*---------##-------------
        // CARREGAR AS LINHAS DO FICHEIRO
        //-----------##--------*---------##-------------
        static void CarregarArquivoCliente()
        {
            if (File.Exists(ficheiro))  // se o arquivo "ficheiro" existe, executará o comando abaixo
            {
                string[] linhas = File.ReadAllLines(ficheiro);// lê todo o conteudo do "ficheiro" e guarda no Array
                foreach (string linha in linhas) // lê todo o conteúdo do array recém-criado
                {
                    string[] partes = linha.Split('|'); //reparte o contido no array de acordo com o sinal escolhido e salva em um novo array(partes)
                    Pessoa pessoa = new Pessoa(); //cria novo objeto na classe "Pessoa"
                    pessoa.nome = partes[0]; // atribui o valor contido na posição 0 do array
                    int c = 0; // declara um contador

                        DadosPessoa dadosPessoa = new DadosPessoa(); //declara novo objeto
                        dadosPessoa.cpf = partes[1 + c]; //atribui o valor armazenado na posição de número equivalente às somas dos valores das variáveis 
                        dadosPessoa.dataNascimento = partes[2 + c];
                        dadosPessoa.cidade = partes[3 + c];  
                        dadosPessoa.email = partes[4 + c];  
                        dadosPessoa.celular = partes[5 + c];

                        pessoa.DadosPessoas.Add(dadosPessoa); // salva os dados da pessoa
                        c++; 

                    pessoas.Add(pessoa); // adiciona  a pessoa recém-criado ao arraylist
                }
            }
        }

        //-----------##--------*---------##-------------
        // MENU DO SISTEMA DE CLIENTE
        //-----------##--------*---------##-------------
        static void Escolher()
        {
            char opcao = ' '; 
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkMagenta; //cor margenta 
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|               MENU-SISTEMA DE CLIENTE              |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.ForegroundColor = ConsoleColor.Blue; //cor azul
                Console.WriteLine("|1- Cadastrar Cliente                                |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|2- Editar ou Deletar Cliente                        |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|3- Buscar Cliente                                   |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|4- Listar Clientes                                  |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|0- Sair                                             |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.Write("--Insira a Opção:");
                opcao = char.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case '1':
                        Cadastrar();
                        break; 
                    case '2':
                        EditarDeletar();
                        break;
                    case '3':
                        Buscar();
                        break;
                    case '4':
                        Listar();
                        break;
                    default: 
                        if (opcao != '0') 
                        {
                            Console.WriteLine("Opção Inválida!!");
                        }
                        break;
                }
            } while (opcao != '0');
        }
        //-----------##--------*---------##-------------
        // CADASTRAR CLIENTES
        //-----------##--------*---------##-------------
        static void Cadastrar() 
        {
            do 
            {
                Console.Clear();
                bool encontrado = false;

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|            <--#CADASTRO  DO CLIENTE#-->            |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Pessoa pessoa1 = new Pessoa();
                Console.WriteLine("|                                                    |");
                Console.Write("# Nome do Cliente:\t");
                pessoa1.nome = Console.ReadLine(); //atribui valor à variável "nome" do objeto recém-criado

                foreach (Pessoa pessoa in pessoas) //executa a leitura do arraylist "pessoa", que contém os dados da classe "Pessoa"
                {
                    if (pessoa.nome.ToLower().Contains(pessoa1.nome.ToLower())) // condiciona o programa para que, se a variável "pessoa.nome" contida no arraylist for igual a recém-criada "pessoa1.nome",
                                                                            // seja executada determinada função
                    {
                        encontrado = true; //caso o if seja cumprido, a variável bool "encontrado" receberá o valor true
                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|            <--#CADASTRO  DO CLIENTE#-->            |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("\n O Cliente{0} já foi adicionado.", pessoa.nome+ "|");
                        Console.WriteLine("\n\n-*-Escolha a opção-*-");
                        Console.WriteLine("\n| 1- Cadastrar outro Cliente\n| 2- Menu incial");
                        Console.Write("\n--Insira a Opção:");
                        string opcao = Console.ReadLine();
                        if (opcao == "1") 
                        {
                            Cadastrar();
                        }
                        else if (opcao == "2") 
                        {
                            Escolher();
                        }
                        else 
                        {
                            Console.WriteLine("Opção inválida!");
                        }
                    }
                }
                if (!encontrado) 
                {
                    string linha = pessoa1.nome + "|"; //inserirá na variável "linha" o contido na variável "pessoa1.nome"
                    
                        DadosPessoa dadosPessoa = new DadosPessoa(); 
                        Console.Write("\n# CPF do Cliente: \t");
                        dadosPessoa.cpf = Console.ReadLine(); 
                        Console.Write("\n# Data do Nascimento: \t");
                        dadosPessoa.dataNascimento = Console.ReadLine();
                        Console.Write("\n# Cidade: \t");
                        dadosPessoa.cidade = Console.ReadLine();
                        Console.Write("\n# Email: \t");
                        dadosPessoa.email = Console.ReadLine();
                        Console.Write("\n# Celular: \t");
                        dadosPessoa.celular = Console.ReadLine();
                        linha += dadosPessoa.cpf + "|" + dadosPessoa.dataNascimento + "|" + dadosPessoa.cidade + " | "
                             + dadosPessoa.email + " | " + dadosPessoa.celular + "|";
                        pessoa1.DadosPessoas.Add(dadosPessoa); // adiciona ao arraylist "pessoa1.dadosPessoas" o objeto "dadosPessoa"
                   
                    pessoas.Add(pessoa1); // adiciona "pessoa1" ao arraylist "pessoa"
                    //SALVANDO OS DADOS NO FICHEIRO
                    if (File.Exists(ficheiro)) //se o arquivo "ficheiro" existe
                    {
                        file = File.AppendText(ficheiro); // posiciona na última linha do arquivo o cursor
                    }
                    else
                    {
                        file = File.CreateText(ficheiro); // criar o arquivo "ficheiro"
                    }
                    file.WriteLine(linha); // escreve no arquivo o texto salvo na variável "linha"
                    file.Close(); // fecha e salva o arquivo
                    Console.Write("\n #Deseja continuar Cadastrando Clientes ? (s) p/ sim \n ou aperte qualquer tecla para negra: \t"); 
                }
            } while (Console.ReadLine().ToLower() == "s");
            Console.Clear(); 
            Escolher();
        }
        //-----------##--------*---------##-------------
        // EDITAR/DELETAR CLIENTES
        //-----------##--------*---------##-------------
        static void EditarDeletar()
        {
            Console.Clear(); // limpa o console

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|           <--#ECOLHA A OPÇÃO DESEJADA#-->          |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| 1- Editar\t\t\t\t\t     |\n| 2- Deletar\t\t\t\t\t     |\n| 3- Ir ao Menu inicial\t\t\t\t     |");
            Console.WriteLine("|                                                    |");
            Console.Write("--Insira a Opção:");

            string opcao = Console.ReadLine();
            if (opcao == "1") 
            {
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|               <--#EDITAR CLIENTE#-->               |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.Write(" #Informe o nome do Cliente que queira alterar: ");
                string nome = Console.ReadLine(); //declara a variável "nome" e define que ela receberá o valor digitado pelo usuário
                bool encontrado = false; // declara nova variável do tipo boolean com valor false 
                int count = 0; //contador
                int countAlterar = 0;//contador
                string linha; // declara uma variável que armazenará os dados inseridos pelo usuário
                Pessoa pessoa1 = new Pessoa();
                foreach (Pessoa pessoa in pessoas) // lê todo o arraylist "pessoa", passando por seu conteúdo um a um, executando os próximos comandos em cada um deles
                {
                    if (pessoa.nome.ToLower().Contains(nome.ToLower())) // compara o contido na variável "pessoa.nome", convertida em letras minúsculas, com o texto contido na variável "nome" 
                    {                                                                                            // caso o conteúdo exista dentro da variável, convertido em letras minúsculas, executará os comandos a seguir
                        countAlterar = count; //atribui o valor da variável "count" à "countAlterar"
                        encontrado = true; //atribui o valor true à variável booleana previamente criada

                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|               <--#EDITAR CLIENTE#-->               |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("\n O Cliente {0} foi encontrado(a).", pessoa.nome); 
                        Console.WriteLine("\n# Deseja alterar-lo? (s) p/ sim \n ou aperte qualquer tecla para negar"); 
                        if (Console.ReadLine().ToLower() == "s") 
                        {
                            Console.Clear();

                            Console.WriteLine("|----------------------------------------------------|");
                            Console.WriteLine("|                                                    |");
                            Console.WriteLine("|               <--#EDITAR CLIENTE#-->               |");
                            Console.WriteLine("|                                                    |");
                            Console.WriteLine("|----------------------------------------------------|");

                            Console.Write("# Nome do Cliente:\t");
                            pessoa1.nome = Console.ReadLine(); 
                            linha = pessoa1.nome + "|";
                                                                                                                 
                                    DadosPessoa dadosPessoa = new DadosPessoa(); 
                                    Console.Write("\n# CPF do Cliente: \t");
                                    dadosPessoa.cpf = Console.ReadLine(); 
                                    Console.Write("\n# Data do Nascimento: \t");
                                    dadosPessoa.dataNascimento = Console.ReadLine(); 
                                    Console.Write("\n# Cidade: \t");
                                    dadosPessoa.cidade = Console.ReadLine();
                                    Console.Write("\n# Email: \t");
                                    dadosPessoa.email = Console.ReadLine();
                                    Console.Write("\n# Celular: \t");
                                    dadosPessoa.celular = Console.ReadLine();
                                    linha += dadosPessoa.cpf + "|" + dadosPessoa.dataNascimento + "|" + dadosPessoa.cidade + " | "
                                         + dadosPessoa.email + " | " + dadosPessoa.celular + "|";
                                    pessoa1.DadosPessoas.Add(dadosPessoa); 
                            }
                        else 
                        {
                            EditarDeletar();
                        }
                    }
                    count++; 
                }
                if (!encontrado) 
                {
                    Console.Clear();

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|               <--#EDITAR CLIENTE#-->               |");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|----------------------------------------------------|");

                    Console.WriteLine("\n\n**Item {0} não existe!**", nome);
                    Console.WriteLine("\n\n-*-Escolha a opção-*-");
                    Console.WriteLine("\n| 1-Editar/Deletar \n| 2-Menu incial");  
                    Console.Write("\n--Insira a Opção:");
                    opcao = Console.ReadLine(); 
                    if (opcao == "1") 
                    {
                        EditarDeletar();
                    }
                    else if (opcao == "2") 
                    {
                        Escolher();
                    }
                }
                else
                {
                    pessoas[countAlterar] = pessoa1; //salva o contido no objeto "pessoa1" no arraylist "pessoas"
                }
                if (File.Exists(ficheiro))// se o arquivo "ficheiro" existe, então
                {
                    file = new StreamWriter(ficheiro); //escreverá no arquivo o listado a seguir
                    foreach (Pessoa pessoa in pessoas) // lê todo o arraylist "pessoa"
                    {
                        linha = pessoa.nome + "|"; //capturando cada elemento "pessoa" contido nele e atribuindo à variável "linha" somada a uma barra reta 
                        foreach (DadosPessoa dadosPessoa in pessoa.DadosPessoas) // lê todo o arraylist "dadosPessoas", que está contido na classe "pessoa"
                        {
                            linha += dadosPessoa.cpf + "|" + dadosPessoa.dataNascimento + "|" + dadosPessoa.cidade + " | "
                                         + dadosPessoa.email + " | " + dadosPessoa.celular + "|";
                        }
                        file.WriteLine(linha); // escreve o contido na variável "linha" no arquivo "ficheiro"
                    }
                    file.Close();
                }
                else
                {
                    file = File.CreateText(ficheiro); // cria o arquivo "ficheiro"
                }
                Console.Clear(); 

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|               <--#EDITAR CLIENTE#-->               |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("\n **Operação concluirda!**");
                Console.WriteLine("\n\n-*-Escolha a opção-*-");
                Console.WriteLine("\n| 1-Editar/Deletar \n| 2-Menu incial"); 
                Console.Write("\n--Insira a Opção:");
                opcao = Console.ReadLine();
                if (opcao == "1") 
                {
                    EditarDeletar();
                }
                else if (opcao == "2")
                {
                    Escolher();
                }
            }
            else if (opcao == "2")
            {
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|               <--#DELETAR CLIENTE#-->              |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("#Insira o nome do cliente que quer deletar:");
                string nome = Console.ReadLine(); // declara a variável "nome" e atribui a ela o valor digitado pelo usuário
                bool encontrado = false; //declara uma variável booleana e atribui a ela o valor "false"
                string linha; // declara a variável "linha"
                foreach (Pessoa pessoa in pessoas) // lê todo o contido no arraylist "pessoas"
                {
                    if (pessoa.nome.ToLower().Contains(nome.ToLower())) // se o valor na posição atual da leitura do arraylist, convertido para minúsculo, 
                                                                      //contiver o digitado pelo usuário, convertido para minúsculo, então
                    {
                        encontrado = true; // a variável booleana receberá o valor true

                        Console.Clear();

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|               <--#DELETAR CLIENTE#-->              |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");

                        Console.WriteLine(" O Cliente {0} existe e pode ser removido.", pessoa.nome);
                        Console.WriteLine("\n #Deseja remover o Cliente {0}? (s) p/ sim \n ou aperte qualquer tecla para negar", pessoa.nome);
                        if (Console.ReadLine().ToLower() == "s") 
                        {

                            pessoas.Remove(pessoa); // removerá o "pessoa" do arraylist "pessoas"
                            break; // encerra a execução do foreach
                        }
                    }

                }
                if (!encontrado)
                {
                    Console.Clear();

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|               <--#DELETAR CLIENTE#-->              |");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|----------------------------------------------------|");

                    Console.WriteLine("\n\n**Item {0} não existe!**", nome);
                    Console.WriteLine("\n\n -*-Escolha a opção-*-");
                    Console.WriteLine("\n| 1-Editar/Deletar \n| 2-Menu incial");
                    Console.Write("\n--Insira a Opção:");
                    opcao = Console.ReadLine();
                    if (opcao == "1") 
                    {
                        EditarDeletar(); 
                    }
                    else if (opcao == "2") 
                    {
                        Escolher();
                    }
                }
                if (File.Exists(ficheiro)) // se o arquivo ficheiro existe, então
                {
                    file = new StreamWriter(ficheiro);//escreverá no arquivo o listado a seguir
                    foreach (Pessoa pessoa in pessoas) // lê todo o arraylist "pessoas"
                    {
                        linha = pessoa.nome + "|";  //capturando cada elemento "pessoa" contido nele e atribuindo à variável linha somada a uma barra reta 
                        foreach (DadosPessoa dadosPessoa in pessoa.DadosPessoas) // lê todo o arraylist "DadosPessoas" que está contido na classe "pessoa"
                        {
                            linha += dadosPessoa.cpf + "|" + dadosPessoa.dataNascimento + "|" + dadosPessoa.cidade + " | "
                                         + dadosPessoa.email + " | " + dadosPessoa.celular + "|";
                        }
                        file.WriteLine(linha); // escreve o contido na variável "linha" no arquivo "ficheiro"
                    } 
                    file.Close();//encera a execução do arquivo "ficheiro"
                }
                else 
                {
                    file = File.CreateText(ficheiro); // cria o arquivo "ficheiro"
                }
                Console.Clear();

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|               <--#DELETAR CLIENTE#-->              |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("\n\n **Operação concluirda!**"); 
                Console.WriteLine("\n\n -*-Escolha a opção-*-");
                Console.WriteLine("\n| 1-Editar/Deletar \n| 2-Menu incial");
                Console.Write("\n--Insira a Opção:");
                opcao = Console.ReadLine(); 
                if (opcao == "1") 
                {
                    EditarDeletar(); 
                }
                else if (opcao == "2")
                {
                    Escolher();
                }
            }
            else if (opcao == "3")
            {
                Escolher(); 
            }

        }
        //-----------##--------*---------##-------------
        // BUSCAR CLIENTES 
        //-----------##--------*---------##-------------
        static void Buscar() 
        {
            Console.Clear();

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|               <--#BUSCAR CLIENTE#-->               |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");

            Console.WriteLine("| Insira o Cliente ou pessoa que deseja buscar:      |");
            string nome = Console.ReadLine(); // declara a variável "nome" e atribui o valor digitado pelo usuário a ela 
            bool encontrado = false; // declara uma variável e atribui a ela o valor false
            foreach (Pessoa pessoa in pessoas) // lê todo o contido no arraylist "pessoas"
            {
                if (pessoa.nome.ToLower().Contains(nome.ToLower()))  // se o valor na posição atual da leitura, convertido para minúsculo, 
                                                                   // contiver o digitado pelo usuário, convertido para minúsculo, então
                {
                    encontrado = true; // a variável booleana receberá true

                    Console.Clear();

                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|               <--#BUSCAR CLIENTE#-->               |");
                    Console.WriteLine("|                                                    |");
                    Console.WriteLine("|----------------------------------------------------|\n");
                    Console.WriteLine("  {0} foi encontrado no banco de dados.\n", pessoa.nome);
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("                  INFO--CLIENTE");
                    Console.WriteLine("|----------------------------------------------------|");

                    foreach (DadosPessoa dadosPessoa in pessoa.DadosPessoas) // lê todo o conteúdo no arraylist "DadosPessoas", contido na classe "Pessoa"
                    {
                        Console.WriteLine("\n\tCliente:\t{0}\n\n\tCPF:\t{1}\n\n\tData do Nascimento:\t{2}" +
                            "\n\n\tCidade:\t{3}\n\n\tEmail:\t{4}\n\n\tCelular:\t{5}",
                            pessoa.nome, dadosPessoa.cpf, dadosPessoa.dataNascimento,
                            dadosPessoa.cidade, dadosPessoa.email, dadosPessoa.celular);
                    }
                    Console.WriteLine(" ---------------------------------------------------- ");
                    Console.WriteLine("\n\n-*-Escolha a opção-*-");
                    Console.WriteLine(" \n  1-Buscar \n  2-Menu incial");
                    Console.Write(" \n--Insira a Opção:");
                    string opcao = Console.ReadLine();
                    if (opcao == "1") 
                    {
                        Buscar();
                    }
                    else if (opcao == "2")
                    {
                        Escolher(); 
                    }
                    Console.ReadKey();
                }
                foreach (DadosPessoa dadosPessoa in pessoa.DadosPessoas)
                {
                    if (dadosPessoa.cpf.ToLower().Contains(nome.ToLower()))
                                                                         
                    {
                        encontrado = true; // caso válida a comparação, a variável booleana receberá true como valor
                        Console.Clear(); 

                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|               <--#BUSCAR CLIENTE#-->               |");
                        Console.WriteLine("|                                                    |");
                        Console.WriteLine("|----------------------------------------------------|");
                        Console.WriteLine("**Cliente Encontrado.**");
                        Console.WriteLine("\n\tCliente:\t{0}\n\n\tCPF:\t{1}\n\n\tData do Nascimento:\t{2}" +
                            "\n\n\tCidade:\t{3}\n\n\tEmail:\t{4}\n\n\tCelular:\t{5}",
                            pessoa.nome, dadosPessoa.cpf, dadosPessoa.dataNascimento,
                            dadosPessoa.cidade, dadosPessoa.email, dadosPessoa.celular);

                        Console.WriteLine("\n\n-*-Escolha a opção-*-");
                        Console.WriteLine("\n| 1-Buscar \n| 2-Menu incial");
                        Console.Write("\n--Insira a Opção:");
                        string opcao = Console.ReadLine();
                        if (opcao == "1") 
                        {
                            Buscar(); 
                        }
                        else if (opcao == "2")
                        {
                            Escolher();
                        }
                    }
                }
            }
            if (!encontrado)
            {
                Console.Clear(); 

                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|               <--#BUSCAR CLIENTE#-->               |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|----------------------------------------------------|");

                Console.WriteLine("\n **{0} ERRO!,Valor não Encontrado.**", nome);
                Console.WriteLine("\n\n\n-*-Escolha a opção-*-");
                Console.WriteLine("\n| 1-Buscar \n| 2-Menu incial");
                Console.WriteLine("");
                Console.Write("--Insira a Opção:");
                string opcao = Console.ReadLine();
                if (opcao == "1") 
                {
                    Buscar();
                }
                else if (opcao == "2")
                {
                    Escolher();
                }
            }
        }
        
        //-----------##--------*---------##-------------
        // MOSTRAR A LISTA DOS CLIENTES
        //-----------##--------*---------##-------------
        static void Listar() 
        {
            Console.Clear(); 

            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|            <--#LISTA DE CLIENTES#-->               |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("                   CLIENTE/CPF");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|----------------------------------------------------|");

            //EXIBINDO OS DADOS CARREGADOS DO FICHEIRO
            foreach (Pessoa pessoa in pessoas) // lê todo o conteúdo no arraylist "pessoas"
            {
                foreach (DadosPessoa dadosPessoa in pessoa.DadosPessoas)  // lê todo o conteúdo no arraylist "DadosPessoas"
                {
                    Console.WriteLine("  #{0}: {1}", pessoa.nome, dadosPessoa.cpf);
                }
                Console.WriteLine("                                                      ");
                Console.WriteLine("|----------------------------------------------------|");
            }


            Console.WriteLine("-**-Aperte qualquer tecla para voltar ao menu inicial.-**-");
            
            Console.ReadKey();
        }
    }
}