using System;
using Primary.Player;


namespace Primary
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Enemy.Enemy goblin = Enemy.Enemy.Factory.CreateGoblin();
            Boss boss = Boss.FactoryBoss.CreateBoss();
            Room startRoom = Room.RoomFactory.CreateHub();
            Room enemyRoom = Room.RoomFactory.CreateEnemyRoom();
            Room treasureRoom = Room.RoomFactory.CreateTreasureRoom();
            Player.Player player = new Player.Player("Pavel", 200, 10, true, startRoom, Weapons.Hand);
            Console.WriteLine("Welcome! In this game the objective is to kill the boss. There are 3 Rooms start room, treasure room and enemy room.");
            Console.WriteLine("If u attack an enemy there is 70% chance he dodges the attack. This goes both ways");
            Console.WriteLine("Your character: " + player);
            void Move()
                        {
                            Console.WriteLine("In what room would you like to go? \n");
                            Console.WriteLine("1. Start room \n2. Treasure room \n3. Enemy room");
                            int move = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                     
                            switch (move)
                                {
                                    case 1:
                                        player.Move(startRoom);
                                        break;
                                    case 2:
                                        player.Move(treasureRoom);
                                        //Console.WriteLine(Room.RoomFactory.CreateTreasureRoom());
                                        break;
                                    case 3:
                                        player.Move(enemyRoom);
                                        Fight();
                                        break;
                                    default:
                                        player.Move(startRoom);
                                        break;
                                }
                            
                                
                        }
            void Fight()
                        {
                            Console.WriteLine("In this room is a enemy do you want to fight him or leave? \n");
                            Console.WriteLine("1. Fight \n2. Leave");
                            int move = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            switch (move)
                            {
                                case 1:
                                    while (player.isLiving && goblin.isLiving)
                                    {
                                        goblin.Attack(player);
                                        player.Attack(goblin);
                                    }
                                    if (goblin.isLiving == false)
                                    {
                                        Upgrade();
                                        Move();
                                    }
                                    break;
                                case 2:
                                    player.Move(startRoom);
                                    break;
                                default:
                                    player.Move(startRoom);
                                    break;
                            }
                        }
            //boss.Attack(player);
            void Upgrade()
            {
                Console.WriteLine("Congratulations! U have gotten an upgrade.");
                Console.WriteLine("Select which type of upgrade you want: 1. Weapons \n2.Heal \n3.Strenght Potion");
                int upgrade = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                switch (upgrade)
                {
                    case 1:
                        Upgrades.Weapon(player);
                        break;
                    case 2:
                        Upgrades.Heal(player);
                        break;
                    case 3:
                        Upgrades.StrenghtUpgrade(player);
                        break;
                    default:
                        break;
                }
                
            }
            void Treasure()
            {
                Random rnd = new Random();
                Console.WriteLine("OMG! there is a chest do you want to open it?");
                Console.WriteLine("");
                int treasure = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                switch (treasure)
                {
                    case 1:
                        int rand = rnd.Next(1, 101);
                        if (rand <= 60)
                        {
                            Upgrade();
                        }
                        else
                        {
                            
                        }
                        break;
                    
                    default:
                        break;
                        
                }
            }
           
            Move();
            Console.ReadLine();
        } 
    }
}

