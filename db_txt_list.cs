using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace ConsoleApp6 
{ 
    public class Banco 
    {        
        //construtor com parametros
        public Banco(string bancoName, int bancoId)  
        {        
            BancoName = bancoName;    
            BancoId = bancoId;    
        }       
        //nome dos usuarios
        public string BancoName { get; set; }     
        //senha dos usuarios
        public int BancoId { get; set; }      
        //faz o codigo não explodir
        public override bool Equals(object obj)    
        {         
            if (obj == null) return false;  
            Banco objAsPart = obj as Banco;  
            if (objAsPart == null) return false; 
            else return Equals(objAsPart);     
        }      
        //sla tbm
        public override int GetHashCode()   
        {           
            return BancoId;   
        }        //antibug??
        public bool Equals(Banco other)     
        {     
            if (other == null) return false;
            return BancoName.Equals(other.BancoName); 
        }        
        //formatação dos membros
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

            int menu = -1;     
            bool chave = false;
            string fileName = @"dados.txt";
            Console.ForegroundColor = ConsoleColor.White; 
            //banco de dados como lista
            List<Banco> bancoList = new List<Banco>();   
            using (StreamReader sr = File.OpenText(fileName))  
            {              
                string s; 
                while ((s = sr.ReadLine()) != null)   
                {                  
                    string stringBetweenTwoStrings = s.Substring(6, s.IndexOf("senha:") - 7);     
                    Console.WriteLine(stringBetweenTwoStrings);         
                    string stringBetweenStrings = s.Substring(s.IndexOf("a: ") + 3);  
                    int l = Convert.ToInt32(stringBetweenStrings);                 
                    Console.WriteLine(l);                  
                    bancoList.Add(new Banco(stringBetweenTwoStrings, l));  
                }         
            }       
            //travel pro menu
            inicio:;          
            Console.Clear();    
            Console.WriteLine(" * * Instabookiiter * *\n\n Inscreva-se gratis Aperte - 1\n Faça o login Aperte - 2\n Calculadora Aperte - 3\n Wordle game Aperte - 4\n Salvar e Sair Aperte - 6"); 
            try { menu = Convert.ToInt32(Console.ReadLine()); }     
            catch (Exception E) { goto inicio; }         
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
                    if (nomelogin == "admin") goto admin;  
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
                            Console.WriteLine("BEM VINDOOO\n\nVamos conferir o banco de dados\n");         
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
                    else 
                    { 
                        Console.WriteLine("Usuario não encontrado"); 
                        Console.ReadKey();
                        goto Login; 
                    }         
                case 3:       
                calculadora:;     
                    double x, y = 0, z, w, op;         
                    Console.Clear();      
                    Console.WriteLine("Calculadora");    
                    Console.WriteLine("Digite o primeiro número");  
                    x = Convert.ToDouble(Console.ReadLine());   
                    Console.WriteLine("Digite a operação\n1 - Adição  2 - Subtração  3 - Multiplicação  4 - Divisão  \n5 - Potenciação  6 - Raiz quadrada  7 - Média  8 - Log  9 - Sequencia");   
                    op = Convert.ToDouble(Console.ReadLine());            
                    if (op == 6) goto conta;       
                    Console.WriteLine("Digite o segundo número");      
                    y = Convert.ToDouble(Console.ReadLine());      
                conta:;    
                    switch (op)       
                    {               
                        case 1:       
                            z = x + y;    
                            Console.WriteLine("A soma entre " + x + " e " + y + " é igual a " + z);        
                            break;         
                        case 2:                   
                            z = x - y;               
                            Console.WriteLine("A subtração entre " + x + " e " + y + " é igual a " + z);         
                            break;          
                        case 3:            
                            z = x * y;        
                            Console.WriteLine("A multiplicação entre " + x + " e " + y + " é igual a " + z);            
                            break;       
                        case 4:           
                            z = x / y;                 
                            int r = (int)z;                
                            w = x % y;         
                            Console.WriteLine("A divisão entre " + x + " e " + y + " é igual a " + z + " o inteiro é " + r + " e resto é " + w);    
                            break;           
                        case 5:        
                            z = Math.Pow(x, y);         
                            Console.WriteLine("A potenciação entre " + x + " e " + y + " é igual a " + z);  
                            break;               
                        case 6:      
                            z = Math.Sqrt(x);            
                            Console.WriteLine("A raiz de " + x + " é igual a " + z);      
                            break;             
                        case 7:                      
                            z = (x + y) / 2;         
                            Console.WriteLine("A média entre " + x + " e " + y + " é igual a " + z);    
                            break;           
                        case 8:          
                            z = Math.Log(x, y);   
                            Console.WriteLine("O Log entre " + x + " e " + y + " é igual a " + z);      
                            break;                
                        case 9:                  
                            w = (y - x);     
                            if (w <= 0) z = y - w;           
                            else z = y + w;                    
                            Console.WriteLine("O próximo numero da sequencia de " + x + " e " + y + " é igual a " + z);     
                            break;            
                    }     
                    Console.WriteLine("Se deseja sair aperte 6");     
                    double g = 0;          
                    try { g = Convert.ToDouble(Console.ReadLine()); }  
                    catch (Exception e) { goto calculadora; }       
                    if (g == 6) goto endcal;   
                    else goto calculadora;       
                    endcal:;            
                    break;              
                case 6:
                    var file = File.Create(fileName);      
                    file.Close();                  
                    string alo = "";     
                    foreach (Banco i in bancoList)      
                    {                  
                        alo = alo + i + "\n";  
                    }             
                    File.WriteAllText(fileName, alo);          
                    break;           
                case 4:          
                    List<string> Palavras = new List<string>();      
                    Palavras.Add("leigo");          
                    Palavras.Add("peixe");       
                    Palavras.Add("optar");          
                    //Random Word Picker
                    Random numberGen = new Random();     
                    int random = 0;      
                iniciowordle:;                
                    Console.Clear();       
                    Console.WriteLine("WORDLE");   
                    for (int i = 0; i < 1; i++)             
                    {                 
                        random = numberGen.Next(0, Palavras.Count);        
                    }    
                    string aPalavra = (Palavras[random]);       
                    Console.WriteLine("qual o seu chute?");             
                    //Guessing
                    for (int i = 0; i < 6; i++)   
                    {               
                    adivinhar:;          
                        Console.ForegroundColor = ConsoleColor.White;      
                        string chute = "";        
                        try { chute = Convert.ToString(Console.ReadLine()).ToLower(); }   
                        catch (Exception ex) { Console.WriteLine("tente algo valido"); Console.ReadKey(); goto adivinhar; }    
                        if (chute.Length != 5)     
                        {           
                            Console.WriteLine("escreva uma palavra de 5 caracteres");
                            goto adivinhar;   
                        }                
                        char a = aPalavra[0];           
                        char b = aPalavra[1];       
                        char c = aPalavra[2];     
                        char d = aPalavra[3];     
                        char e = aPalavra[4];     
                        char chuteA = chute[0];    
                        char chuteB = chute[1];     
                        char chuteC = chute[2];      
                        char chuteD = chute[3];      
                        char chuteE = chute[4];      
                        //First Letter
                        if (a == chuteA)        
                        {           
                            Console.ForegroundColor = ConsoleColor.Green;                   
                            Console.Write(chuteA);        
                        }           
                        else if (b == chuteA || c == chuteA || d == chuteA || e == chuteA)  
                        {              
                            Console.ForegroundColor = ConsoleColor.Blue;          
                            Console.Write(chuteA);             
                        }              
                        else             
                        {                      
                            Console.ForegroundColor = ConsoleColor.Red;                
                            Console.Write(chuteA);       
                        }          
                        //Second Letter
                        if (b == chuteB)    
                        {                
                            Console.ForegroundColor = ConsoleColor.Green;        
                            Console.Write(chuteB);      
                        }       
                        else if (a == chuteB || c == chuteB || d == chuteB || e == chuteB)   
                        {                  
                            Console.ForegroundColor = ConsoleColor.Blue;      
                            Console.Write(chuteB);          
                        }    
                        else             
                        {            
                            Console.ForegroundColor = ConsoleColor.Red;        
                            Console.Write(chuteB);          
                        }        
                        //Third Letter
                        if (c == chuteC) 
                        {                   
                            Console.ForegroundColor = ConsoleColor.Green;   
                            Console.Write(chuteC);    
                        }            
                        else if (b == chuteC || a == chuteC || d == chuteC || e == chuteC)         
                        {                 
                            Console.ForegroundColor = ConsoleColor.Blue;       
                            Console.Write(chuteC);         
                        }                
                        else      
                        {          
                            Console.ForegroundColor = ConsoleColor.Red;          
                            Console.Write(chuteC);               
                        }              
                        //Fourth Letter
                        if (d == chuteD)      
                        {                      
                            Console.ForegroundColor = ConsoleColor.Green;     
                            Console.Write(chuteD);       
                        }            
                        else if (b == chuteD || c == chuteD || a == chuteD || e == chuteD)     
                        {                   
                            Console.ForegroundColor = ConsoleColor.Blue;       
                            Console.Write(chuteD);       
                        }            
                        else             
                        {       
                            Console.ForegroundColor = ConsoleColor.Red;       
                            Console.Write(chuteD);      
                        }             
                       //Fifth Letter
                       if (e == chuteE)   
                        {           
                            Console.ForegroundColor = ConsoleColor.Green;  
                            Console.WriteLine(chuteE);     
                        }                  
                        else if (b == chuteE || c == chuteE || d == chuteE || a == chuteE)    
                        {                       
                            Console.ForegroundColor = ConsoleColor.Blue;    
                            Console.WriteLine(chuteE);      
                        }               
                        else         
                        {               
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.WriteLine(chuteE);            
                        }             
                      //Win
                      if (chute == aPalavra)
                      {                
                            Console.ForegroundColor = ConsoleColor.Blue;    
                            Console.WriteLine("PARABENS VC ACERTOU A PALAVRA");     
                            i = 999;           
                        }              
                    }        
                    Console.ForegroundColor = ConsoleColor.White; 
                    Console.WriteLine("A palavra era: " + aPalavra);    
                    int exit;             
                    Console.WriteLine("Se quiser sair aperte 6");      
                    try { exit = Convert.ToInt32(Console.ReadLine()); }         
                    catch (Exception E) { goto iniciowordle; }       
                    if (exit != 6) goto iniciowordle;   
                    break;         
                default:         
                    goto inicio;      
            }      
            goto end;   
        admin:; 
            Console.WriteLine("Ola Admin\nColoque a chave de acesso"); 
            int senhaadm = Convert.ToInt32(Console.ReadLine()); 
            if (senhaadm == 1324)   
            {        
                Console.ForegroundColor = ConsoleColor.Green;    
                chave = true;  
                for (int i = 0; i < bancoList.Count; i++)    
                {       
                    Console.WriteLine(i + " " + bancoList[i]);   
                }  
                Console.WriteLine("Apagar qual registro?"); 
                goto inicio;    
            }        end:goto inicio;       
        }   
    }
}
