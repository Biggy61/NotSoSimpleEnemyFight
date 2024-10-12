using Primary.Player;

namespace Primary;

public class Functions
{
    public static Enemy.Enemy skeleton = Enemy.Enemy.Factory.CreateSkeleton();
    public static Boss boss = Boss.FactoryBoss.CreateBoss();
    public static Room startRoom = Room.RoomFactory.CreateHub();
    public static Room enemyRoom = Room.RoomFactory.CreateEnemyRoom();
    public static Enemy.Enemy goblin = Enemy.Enemy.Factory.CreateGoblin();
    public static Room treasureRoom = Room.RoomFactory.CreateTreasureRoom();
    public static Player.Player player = new Player.Player("Pavel", 200, 10, true, startRoom, Weapons.Hand);
    public static int count = 0;
    public void Move()
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("In what room would you like to go? \n");
                            Console.WriteLine("1. Start room \n2. Treasure room \n3. Enemy room");
                            Console.ForegroundColor = ConsoleColor.Black;
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
            public void Fight(Enemy.Enemy enemy)
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
            public void Upgrade()
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
            public void Treasure()
            {
                if (count == 0)
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
                else
                {
                    Console.WriteLine("You have already got the treasure.");
                }count++;
            }
}