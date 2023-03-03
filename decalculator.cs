using System;
namespace ConsoleApplication3
{
    class Program
    {
      
        static void Main(string[] args)
        {
            
            Console.WriteLine("Digite a conta");
            string conta = Console.ReadLine();
            char[] letra = new char[conta.Length];
            for (int i = 0; i < conta.Length; i++)
            {
                letra[i] = conta[i];
            }
            
            
            foreach(char '+' in conta)



            string[] index = conta.Split(" ");
            int w = Array.IndexOf(index,'+');
            if(w < -1)
            {
                
            }


            Console.ReadKey();
        }
    }
}
