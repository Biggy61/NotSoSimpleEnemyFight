using System;
using Primary.Player;


namespace Primary
{
    class Program : Room
    {
        static void Main(string[] args)
        {
            
            
            Enemy.Enemy skeleton = Enemy.Enemy.Factory.CreateSkeleton();
            Boss boss = Boss.FactoryBoss.CreateBoss();
            Room startRoom = Room.RoomFactory.CreateHub();
            Room enemyRoom = Room.RoomFactory.CreateEnemyRoom();
            Room treasureRoom = Room.RoomFactory.CreateTreasureRoom();
            Player.Player player = new Player.Player("Pavel", 200, 10, true, startRoom, Weapons.Hand);
            //--------------- START ---------------
            Console.WriteLine("Welcome! In this game the objective is to kill the boss. There are 3 Rooms start room, treasure room and enemy room.");
            Console.WriteLine("If u attack an enemy there is 70% chance he dodges the attack. This goes both ways");
            Console.WriteLine("Your character: " + player);
            
            //--------------- MOVE ---------------
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
                                        if (goblin.isLiving == false)
                                        {
                                            player.Move(treasureRoom);
                                            Treasure();
                                            Move();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have to get through the enemy first ");
                                            Move();
                                        }
                                        break;
                                    case 3:
                                        player.Move(enemyRoom);
                                        Fight(goblin);
                                        break;
                                    default:
                                        player.Move(startRoom);
                                        break;
                                }
                            
                                
                        }
            //--------------- FIGHT ---------------
            void Fight(Enemy.Enemy enemy)
            {
                            Console.WriteLine($"There is an enemy!!\n {enemy} Do you want to fight him or leave? ");
                            Console.WriteLine("1. Fight \n2. Leave");
                            int move = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            switch (move)
                            {
                                case 1:
                                    while (player.isLiving && enemy.isLiving)
                                    {
                                        enemy.Attack(player);
                                        player.Attack(enemy);
                                    }
                                    if (enemy.isLiving == false)
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
            //--------------- UPGRADE ---------------
            void Upgrade()
            {
                Console.WriteLine("Congratulations! U have gotten an upgrade.");
                Console.WriteLine("Select which type of upgrade you want: \n1.Weapons \n2.Heal \n3.Strenght Potion");
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
            //--------------- TREASURE ---------------
            void Treasure()
            {
                Random rnd = new Random();
                Console.WriteLine("OMG! there is a chest do you want to open it?");
                Console.WriteLine("1. YES!!! 2. No, leave");
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
                            Fight(skeleton);
                        }
                        break;
                    case 2:
                        player.Move(startRoom);
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

