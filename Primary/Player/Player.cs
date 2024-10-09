
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
        public Weapons weapon;

        public Player(string name, int hp, int dmg, bool isLiving, Room currentRoom)
        {
            Name = name;
            Hp = hp;
            Dmg = dmg;
            this.isLiving = isLiving;
            CurrentRoom = currentRoom;
            if (Hp <= 0)
            {
                Hp = 0;
                this.isLiving = false;
            }
        }
        /*
        public Player(string name, int hp, int dmg, bool isLiving, Room currentRoom, Weapons weapon)
        {
            Name = name;
            Hp = hp;
            Dmg = dmg;
            IsLiving = isLiving;
            CurrentRoom = currentRoom;
            
            switch (weapon)
            {
                case Weapons.Dagger:
                    Dmg += 5;
                    break;
                case Weapons.Sword:
                    Dmg += 10;
                    break;
                case Weapons.Glock:
                    Dmg += 15;
                    break;
                default:
                    break;
            }
        }

*/
        public void Move(Room nextRoom)
        {
            CurrentRoom = nextRoom;
        }

        public void Attack(Enemy enemy)
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
                enemy.Hp -= Dmg;
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


        public void Heal(HealPotions potion)
        {
            if (!isLiving) return;

            switch (potion)
            {
                case HealPotions.Small: Hp += 5;
                    Console.WriteLine($"{Name} healed, remaining hp: {Hp}");
                    break;
                case HealPotions.Mid: Hp += 10;
                    Console.WriteLine($"{Name} healed, remaining hp: {Hp}");
                    break;
                case HealPotions.Large: Hp += 15;
                    Console.WriteLine($"{Name} healed, remaining hp: {Hp}");
                    break;

            }
        }

        public void GetStronger(StrenghtPotions potion)
        {
            if (!isLiving) return;

            switch (potion)
            {
                case StrenghtPotions.Redbull: Dmg += 2;
                    Console.WriteLine($"{Name} is stronger now, his damage: {Dmg}");
                    break;
                case StrenghtPotions.Creatine: Dmg += 5;
                    Console.WriteLine($"{Name} is stronger now, his damage: {Dmg}");
                    break;
                case StrenghtPotions.Steroids: Dmg += 10;
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
