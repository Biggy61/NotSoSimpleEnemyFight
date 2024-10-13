
using System;

namespace Primary.Player
{
    public class Player
    {
        public string Name;
        public int Hp;
        public int Dmg;
        public bool isLiving;
        public Room CurrentRoom;
        public Weapons Weapon;
        
        public Player(string name, int hp, int dmg, bool isLiving, Room currentRoom, Weapons weapon)
        {
            Name = name;
            Hp = hp;
            Dmg = dmg;
            this.isLiving = isLiving;
            CurrentRoom = currentRoom;
            Weapon = weapon;
            if (Hp <= 0)
            {
                Hp = 0;
                this.isLiving = false;
            }
        }

        public void SetWeapon(Weapons weapon)
        {
            Weapon = weapon;
        }
        public void Move(Room nextRoom)
        {
            CurrentRoom = nextRoom;
        }

        public void Attack(Enemy.Enemy enemy)
        {
            if (this.Hp <= 0)
            {
                isLiving = false;
                return;
            }

            if (enemy.Hp <= 0)
            {
                enemy.isLiving = false;
                return;
            }
            Random rnd = new Random();
            if (isLiving == true && enemy.isLiving == true)
            {
            int rand = rnd.Next(1, 101);
            if (rand <= 70)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                enemy.Hp -= Dmg + (int) Weapon;
                if (enemy.Hp < 0)
                {
                    enemy.Hp = 0;
                }
                Console.WriteLine($"{Name} attacked {enemy.Name}, remaining hp: {enemy.Hp}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("Enemy dodged!");
            }
            }
           
        }


        public void Heal(HealPotions potion)
        {
            if (!isLiving) return;

            switch (potion)
            {
                case HealPotions.Small: Hp += 10;
                    Console.WriteLine($"{Name} healed, remaining hp: {Hp}");
                    break;
                case HealPotions.Mid: Hp += 20;
                    Console.WriteLine($"{Name} healed, remaining hp: {Hp}");
                    break;
                case HealPotions.Large: Hp += 30;
                    Console.WriteLine($"{Name} healed, remaining hp: {Hp}");
                    break;

            }
        }

        public void GetStronger(StrenghtPotions potion)
        {
            if (!isLiving) return;

            switch (potion)
            {
                case StrenghtPotions.Redbull: Dmg += 5;
                    Console.WriteLine($"{Name} is stronger now, his damage: {Dmg}");
                    break;
                case StrenghtPotions.Creatine: Dmg += 10;
                    Console.WriteLine($"{Name} is stronger now, his damage: {Dmg}");
                    break;
                case StrenghtPotions.Steroids: Dmg += 20;
                    Console.WriteLine($"{Name} is stronger now, his damage: {Dmg}");
                    break;
            }
        }
        
        public override string ToString()
        {
            return $"Name: {this.Name}, hp: {Hp}, dmg: {Dmg}, Alive: {isLiving}";
        }
    }
}
