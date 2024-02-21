using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Earmad_bandit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int bet = 0;
            int Current_Tokens = 10;
            Random rnd = new Random();


            Console.WriteLine("To play 'The one Armed Bandit,' you must first place a bet.\nPlace a bet with tokens below. You can only bet your maximum value of tokens, and you have to place a bet. \nYour currently have " + Current_Tokens + " tokens.");

            FuncBet();
            Console.WriteLine("You've placed a bet of " + bet + " tokens.");

            Console.WriteLine("Now it's time to pull the lever of the machine.\n Press 'P' to pull the lever...");
            FuncLever();
            FuncDelay();
            FuncResult();

            void FuncBet()
            {
                while (true)
                {
                    Console.WriteLine("Place a bet between 1 and " + Current_Tokens);
                    bet = Convert.ToInt32(Console.ReadLine());


                    if (bet > Current_Tokens)
                    {
                        Console.WriteLine("You can't bet that high...");
                    }

                    if (bet == 0)
                    {
                        Console.WriteLine("You have to place a bet of tokens...");
                    }

                    if (bet <= Current_Tokens && bet > 0)
                    {
                        Current_Tokens = Current_Tokens - bet;
                        break;
                    }
                }
            }

            void FuncLever()
            {
                ConsoleKey Pull = ConsoleKey.P;
                while (Console.ReadKey(true).Key != Pull)
                {
                    // Nothing happens unless they press "P"
                }
                Console.WriteLine();
                Console.WriteLine("Now wait for the machine to stop...");
                return;
            }

            void FuncDelay()
            {
                int sek = 5;

                for (int i = 0; i < sek; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(".");
                }


            }

            void FuncResult()
            {
                string[] slots = new string[3];


            }

        }

    }
}