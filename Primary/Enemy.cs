
using System;
using Primary.Player; 
namespace Primary;
    public class Enemy
    {
        public string Name;
        public int Hp;
        public int BaseDmg;
        public bool IsLiving;

        public Enemy(string name, int hp, int baseDmg, bool isLiving)
        {
            Name = name;
            Hp = hp;
            BaseDmg = baseDmg;
            IsLiving = isLiving;
            if (this.Hp <= 0)
            {
                IsLiving = false;
            }
        }

        public static class Factory
        {
            public static Enemy CreateOger()
            {
                return new Enemy("Oger", 50, 5, true);
            }

            public static Enemy CreateGoblin()
            {
                return new Enemy("Goblin", 50, 7, true);
            }
            
        }
        
        public void Attack(Player enemy)
        {
            Random rnd = new Random();
            if (IsLiving && this.IsLiving)
            {
                int rand = rnd.Next(1, 101);
                if (rand <= 70)
                {
                    enemy.Hp -= BaseDmg;
                    Console.WriteLine($"{Name} attacked {enemy.Name}, remaining hp: {enemy.Hp}");
                }
                else
                {
                    Console.WriteLine("Enemy dodged!");
                }
            }
            else
            {
                Console.WriteLine("He dead!");
            }
        }
    }
