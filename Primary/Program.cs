using System;
using Primary.Player;


namespace Primary
{
    class Program
    {
        static void Main(string[] args)
        {
            Enemy myOger = Enemy.Factory.CreateOger();
            Enemy goblin = Enemy.Factory.CreateGoblin();
            Room startRoom = Room.RoomFactory.CreateHub();
            Room enemyRoom = Room.RoomFactory.CreateEnemyRoom();
            Room treasureRoom = Room.RoomFactory.CreateTreasureRoom();
            Player.Player player = new Player.Player("Pavel", 200, 10, true, startRoom);
            Console.WriteLine(player);
            player.Move(treasureRoom);
            player.Move(enemyRoom);
            player.Heal(HealPotions.Large);
            player.GetStronger(StrenghtPotions.Creatine);
            player.Attack(goblin);
            goblin.Attack(player);
            Console.WriteLine(player);
            if (player.CurrentRoom == enemyRoom)
            {
                
            }
            
            /*
            void Question()
            {
                Console.WriteLine("In what room would you like to go?");
                string move = Convert.ToString(Console.ReadLine()).ToLower();
                if (player.currentRoom =! hub)
                {
                    switch (move)
                    {
                        case "hub":
                            player.Move(startRoom)
                    }
                }
                switch (move)
                {
                    
                }
                
            }
            
            Question();
            */
            Console.ReadLine();
            /*
            for (int i = 0; i < 10; i++)
            {
                Random rd = new Random();

                int number = rd.Next(2);

                if (number ==)
                {
                    
                }
            }*/
        } 
    }
}