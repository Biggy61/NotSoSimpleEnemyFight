
using System;
namespace Primary.Enemy;
    public class Enemy
    {
        public string Name;
        public int Hp;
        public int BaseDmg;
        public bool isLiving;

        public Enemy(string name, int hp, int baseDmg, bool isLiving)
        {
            Name = name;
            Hp = hp;
            BaseDmg = baseDmg;
            this.isLiving = isLiving;
            if (Hp <= 0)
            {
                Hp = 0;
                this.isLiving = false;
            }
        }

        public static class Factory
        {
            public static Enemy CreateGoblin()
            {
                return new Enemy("Goblin", 100, 10, true);
            }

            public static Enemy CreateSkeleton()
            {
                return new Enemy("Skeleton", 50, 7, true);
            }

            public static Enemy CreateBoss()
            {
                return new Enemy("Wenceslas Rich", 150, 10, true);
            } 
        }
        
        public void Attack(Player.Player player)
        {
            if (this.Hp <= 0)
            {
                 isLiving = false;
                 return;
            }

            if (player.Hp <= 0)
            {
                player.isLiving = false;
                return;
            }
            Random rnd = new Random();
     
            if (isLiving == true && player.isLiving == true)
            {
                int rand = rnd.Next(1, 101);
                if (rand <= 70)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    player.Hp -= BaseDmg;
                    Console.WriteLine($"{Name} attacked {player.Name}, remaining hp: {player.Hp}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Player dodged!");
                }
            }
            else
            {
                Console.WriteLine("He dead!");
            }
                
            
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, hp: {Hp}, dmg: {BaseDmg}, Alive: {isLiving}";
        }
    }
