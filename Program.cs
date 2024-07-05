using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практ9._6_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadNumber readNumber = new ReadNumber();
            readNumber.NumberEnteredEvent += Sorted;
            while (true)
            {
                try
                {
                    readNumber.Read();

                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение");
                    Console.ReadKey();

                }
            }
        }
        public static void Sorted(int number)
        {
            List<string> surnames = new List<string> { "Отчисленный", "Выселенный", "А", "Несдавший", "Бесстепендийный" };
            
                switch (number)
                {
                    case 1:
                        surnames.Sort();
                        Console.WriteLine("Прямая сортировка");
                        foreach (var sor in surnames)
                        {
                            Console.WriteLine(sor);
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        surnames.Sort();
                        surnames.Reverse();
                        Console.WriteLine("Обратная сортировка");
                        foreach (var sor in surnames)
                        {
                            Console.WriteLine(sor);
                        }
                        Console.ReadKey();
                        break;

                }
        }

    }
    public class ReadNumber 
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        
        public void Read() 
        {
            Console.WriteLine("Введите: 1 - для сортировки от А до Я, 2 - для сортировки от Я до А");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2) throw new FormatException();
            NumberEntered(number);

        }

       
        

        protected virtual void NumberEntered(int number) 
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }
   
}
