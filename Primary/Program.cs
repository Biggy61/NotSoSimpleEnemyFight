using System;
using System.Runtime.CompilerServices;
using Primary.Player;


namespace Primary
{
    class Program : Functions
    {
        static void Main(string[] args)
        {
            Functions functions = new Functions();
            
         
            //--------------- START ---------------
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                               ");
            Console.WriteLine("            Welcome!           ");
            Console.WriteLine("                               ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("In this game the objective is to kill the boss. There are 3 Rooms start room, treasure room and enemy room.");
            Console.WriteLine("If u attack an enemy there is 70% chance he dodges the attack. This goes both ways");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Your character: " + player);
            functions.Move();
            Console.ReadLine();
        } 
    }
}

