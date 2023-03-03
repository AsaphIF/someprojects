using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApp8 
{
    public class Banco 
    {
        public string BancoName { get; set; }
        public int BancoId { get; set; }
        public Banco(string bancoName, int bancoId) 
        { 
            BancoName = bancoName;
            BancoId = bancoId;
        } 
        public override bool Equals(object obj)
        { 
            if (obj == null) return false;
            Banco objAsPart = obj as Banco;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode() 
        { 
            return BancoId;
        }
        public bool Equals(Banco other) 
        {
            if (other == null) return false;
            return (BancoId.Equals(other.BancoId));
        }
        public override string ToString() 
        { 
            return "nome: " + BancoName + " senha: " + BancoId; 
        } 
    }
    //classe principal
    public class Program    
    {        
        static void Main(string[] args)
        {
            //banco de dados como lista
            List<Banco> bancoList = new List<Banco>();
            //itens já atribuidos
            bancoList.Add(new Banco("rafa", 123));
            bancoList.Add(new Banco("rafaela", 133));
            bancoList.Add(new Banco("rafael", 223));            
            //travel pro menu
                                                                
        inicio:;            
            Console.Clear();            
            Console.WriteLine(" * * Instabookiiter * *\n\n Inscreva-se gratis Aperte - 1\n Faça o login Aperte - 2");
            int menu = Convert.ToInt32(Console.ReadLine());            
            switch (menu)           
            {                
                //travel pro cadastro
                case 1:  
                Cadastro:;
                    Console.Clear();
                    Console.WriteLine("Escolha um nome de usuario");
                    string usuario = Console.ReadLine();
                    for (int i = 0; i < bancoList.Count; i++)
                    {                        
                        if (bancoList[i].BancoName == usuario)
                        {                           
                            Console.WriteLine("Esse nome de usuario já existe");
                            Console.ReadKey();                            
                            goto Cadastro;                        
                        }                   
                    }                                       
                    Console.WriteLine("Escolha uma senha de 8 numeros");   
                    int senha = Convert.ToInt32(Console.ReadLine());       
                    Console.WriteLine("Repita a senha");                   
                    int senhacheck = Convert.ToInt32(Console.ReadLine()); 
                    //checka se a senha é a mesma
                    if (senhacheck == senha)                   
                    {                        
                        Console.WriteLine("Usuario cadastrado");
                        //se true então é adicionado
                        bancoList.Add(new Banco(usuario, senha));         
                        Console.ReadKey();                       
                        //não precisa de break pois vai até o menu
                        goto inicio;                   
                    }                   
                    // se false então poderá refazer ou sair
                    else                   
                    {                      
                        Console.WriteLine("senha incorreta"); 
                        Console.WriteLine("Aperte 1 para corrigir\nAperte 2 para sair");  
                        int incorreta = Convert.ToInt32(Console.ReadLine());   
                        switch (incorreta)                     
                        {                            
                            case 1:                  
                                goto Cadastro;       
                            case 2:                       
                                goto inicio;               
                            default:                  
                                break;                     
                        }                 
                    }                 
                    break;        
                case 2:      
                    //travel pro login
                    Login:;   
                    Console.Clear();  
                    //seta o index do banco de nulo
                    int index = -1;                 
                    Console.WriteLine("Coloque o nome do seu usuario");   
                    string nomelogin = Console.ReadLine();                 
                    // checka o nome no banco de dados
                    for (int i = 0; i < bancoList.Count; i++)   
                    {                       
                        if (bancoList[i].BancoName == nomelogin)  
                        {                           
                            // muda para o index correspondente
                            index = i;                     
                        }                   
                    }                  
                    //verifica se o usuario foi detectado
                    if (index >= 0)                  
                    {                      
                        //travel pra senha
                        
                        senhaLogin:;           
                        Console.Clear();                
                        Console.WriteLine("Ola usuario " + bancoList[index].BancoName);     
                        Console.WriteLine("Coloque a sua senha");  
                        int senhalogin = Convert.ToInt32(Console.ReadLine()); 
                        //checka o id do index correspondente ao usuario
                        if (senhalogin == bancoList[index].BancoId) 
                        {                           
                            Console.WriteLine("BEM VINDOOO\n\nVamos conferir o banco de dados");  
                            //lista todos os usuarios
                            for (int i = 0; i < bancoList.Count; i++)     
                            {                               
                                Console.WriteLine(bancoList[i]);     
                            }                            
                            Console.ReadKey();                   
                            goto inicio;                   
                        }                     
                        else                 
                        {                    
                            Console.WriteLine("Senha Incorreta");    
                            Console.ReadKey();                    
                            goto senhaLogin;                     
                        }                  
                    }                   
                    // volta ao login pois não encontrou usuarios correspondentes
                    else { Console.WriteLine("Usuario não encontrado");
                        Console.ReadKey(); 
                        goto Login;
                    }                
                case 3:                   
                    var x = File.Create("C:/Users/alunocmc/source/repos/ConsoleApp8/dados.txt"); 
                    x.Close();                   
                    string alo = "";                  
                    foreach(Banco i in bancoList)  
                    {                       
                        alo = alo + i + "\n";      
                    }                  
                    File.WriteAllText("C:/Users/alunocmc/source/repos/ConsoleApp8/dados.txt", alo);  
                    using (StreamReader sr = File.OpenText("C:/Users/alunocmc/source/repos/ConsoleApp8/dados.txt"))   
                    {                     
                        string s;                       
                        while ((s = sr.ReadLine()) != null)   
                        {                                              
                            string stringBetweenTwoStrings = s.Substring(6,s.IndexOf("-")-7); 
                            Console.WriteLine(stringBetweenTwoStrings);       
                            string stringBetweenStrings = s.Substring(s.IndexOf("a: ")+3);  
                            int l = Convert.ToInt32(stringBetweenStrings);       
                            Console.WriteLine(l);                 
                        }                                    
                    }                 
                    break;         
            }           
            Console.ReadKey();  
        }   
    }
}
