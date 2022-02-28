using System;

namespace JogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opc;
            do
            {
                Console.Clear();
                opc = Menu();

                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        JogoDaVelha novoJogo = new JogoDaVelha();
                        novoJogo.Iniciar();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Até Breve...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Inválida!Escolha Novamente!");
                        Console.ReadKey();
                        break;

                }

            } while (opc != 2);
            
        }
        
        public static int Menu()
        {
            int opcMenu = 0;
            Console.WriteLine("=====MENU PRINCIPAL=====");
            Console.WriteLine("\n1-Jogar\n2-Sair");
            opcMenu = int.Parse(Console.ReadLine());

            return opcMenu;
        }

    }
}
