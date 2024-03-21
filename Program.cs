using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneArmed_Bandit
{
    internal class Program
    {

        static void Main(string[] args)
        {

            int bet = 0;
            
            int Current_Tokens = 10;
            
            
            while (Current_Tokens > 0)
            {
                

                Console.WriteLine("To play 'The one Armed Bandit,' you must first place a bet.\nPlace a bet with tokens below. You can only bet your maximum value of tokens, and you have to place a bet. \nYour currently have " + Current_Tokens + " tokens.");

                bet = FuncBet(Current_Tokens, bet);

                Console.WriteLine("You've placed a bet of " + bet + " tokens.");

                Console.WriteLine("Now it's time to pull the lever of the machine.\n Press 'P' to pull the lever...");
                FuncLever();
                FuncDelay();
                Current_Tokens = FuncSlotRoll(bet, Current_Tokens);                
                FuncGameOptions(Current_Tokens);
                


                void FuncLever()
                {
                    ConsoleKey Pull = ConsoleKey.P;
                    while (Console.ReadKey(true).Key != Pull)
                    {
                        // Nothing happens unless they press "P"
                    }
                    Console.WriteLine();
                    Console.WriteLine("Now wait for the machine to stop...");

                }

                void FuncDelay()
                {
                    int sec = 4;

                    for (int i = 0; i < sec; i++)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine(".");
                    }
                }
               
            }

            Console.WriteLine("You're out of tokens! No more Bandit for you!");
            
            int sek = 5;

            for (int i = 0; i < sek; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");

            }
            Environment.Exit(0);

        }

        static int FuncBet(int wallet, int betting)
            {
                    int funkis = 0;

                    while (wallet > 0)
                    {
                        Console.WriteLine("Place a bet between 1 and " + wallet);
                        betting = Convert.ToInt32(Console.ReadLine());


                        if (betting > wallet)
                        {
                            Console.WriteLine("You can't bet that high...");
                            continue;

                        }
                        else if (betting <= 0)
                        {
                            Console.WriteLine("You have to place a bet of tokens...");
                            continue;
                        }
                        else
                        {      
                            funkis = betting;
                            break;
                        }
                    }
                    return funkis;
            }

        static int FuncSlotRoll(int stake, int oldWallet)
        {
            int newWallet = 0;
            Random rnd = new Random();
            
            int[,] slot_cylinder = new int[3, 3];
            



                    /*string[] slot_cylinder = new string[9];
                    slot_cylinder[0] = "X";
                    slot_cylinder[1] = "Y";
                    slot_cylinder[2] = "Z";

                    slot_cylinder[0] = "X";
                    slot_cylinder[1] = "Y";
                    slot_cylinder[2] = "Z";*/

            string [] slot_result = new string[9];
                    int index;

                    //Loop for randomly rolling slots
                    for (int i = 0; i < slot_cylinder.Length; i++)
                    {
                        index = rnd.Next(slot_cylinder.Length);
                        slot_result[i] = slot_cylinder[index];
                        Console.Write(slot_result[i] + " ");
                        
                        
                    }

                    if ((slot_result[0] == slot_result[1]) && (slot_result[2] == slot_result[0]))
                    {

                        if (stake >= 5)
                        {
                            newWallet = oldWallet + (stake * 2);
                            Console.WriteLine("You're a real winner! You're balance is now " + newWallet);


                        }

                        else if (stake < 5)
                        {
                            newWallet = oldWallet + stake + 5;
                            Console.WriteLine("You've won! You're balance is now " + newWallet);


                        }
                    }
                    else
                    {
                        newWallet = oldWallet - stake;
                        Console.WriteLine("You've lost! Your balance is now " + newWallet);
                    }
                    
            return newWallet;
        }

        static int FuncGameOptions(int _tokens)
        {
                    string answer;
                                                       
                    while (_tokens > 0)
                    {
                        
                        Console.WriteLine("Do you want to play again? 'Y' for yes and 'N' for no...");
                        answer = Console.ReadLine().Trim().ToLower();

                            //Wrong input
                            if (answer != "y" && answer != "n")
                            {
                                Console.WriteLine("Only press the assigned keys, please..");
                                continue;

                            }

                         //Input No
                         if (answer == "n")
                         {
                            int sek = 3;

                           for(int i = 0; i < sek; i++)
                           {
                                Thread.Sleep(1000);
                                Console.Write(".");
                           }

                             Console.WriteLine("Too bad, thank you for playing!");
                             Environment.Exit(0);
                             break;
                         }

                           //Input Yes
                           if (answer == "y")
                           {


                                Console.WriteLine("Great! Await further instructions");

                                int sek = 5;

                                for (int i = 0; i < sek; i++)
                                {
                                    Thread.Sleep(1000);
                                    Console.Write(".");

                                }

                                break;
                           }
                    }
                    
                             return _tokens;
        }

    }
}

