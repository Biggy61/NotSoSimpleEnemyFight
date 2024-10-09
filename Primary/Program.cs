using System;
using Primary.Player;


namespace Primary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Enemy myOger = Enemy.Factory.CreateOger();
            Enemy goblin = Enemy.Factory.CreateGoblin();
            Boss boss = Boss.FactoryBoss.CreateBoss();
            Room startRoom = Room.RoomFactory.CreateHub();
            Room enemyRoom = Room.RoomFactory.CreateEnemyRoom();
            Room treasureRoom = Room.RoomFactory.CreateTreasureRoom();
            Player.Player player = new Player.Player("Pavel", 200, 10, true, startRoom);
                
            
            Console.WriteLine(player);
            //player.Heal(HealPotions.Large);
            //player.GetStronger(StrenghtPotions.Creatine);
            void Question()
                        {
                            Console.WriteLine("In what room would you like to go?");
                            Console.WriteLine("1. Start room \n2. Treasure room \n3. Enemy room");
                            int move = int.Parse(Console.ReadLine());
                                switch (move)
                                {
                                    case 1:
                                        player.Move(startRoom);
                                        break;
                                    case 2:
                                        player.Move(treasureRoom);
                                        break;
                                    case 3:
                                        player.Move(enemyRoom);
                                        break;
                                    default:
                                        player.Move(startRoom);
                                        break;
                                }
                            
                                
                        }
            Question();
            //boss.Attack(player);
            if (player.CurrentRoom == enemyRoom)
            {
                while (player.isLiving && goblin.isLiving)
                {
                     goblin.Attack(player);
                     player.Attack(goblin);
                }
               
            }
            
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