namespace Primary.Player;

public class Upgrades
{
    public static void Weapon(Player player)
    {
        Random rnd  = new Random();
        int rand = rnd.Next(1, 100);
        if (rand <= 33)
        {
            player.SetWeapon(Weapons.Dagger);
        }
        
        if (rand is < 33 and <= 66)
        {
            player.SetWeapon(Weapons.Sword);
        }
        
        if (rand is < 66 and <= 100)
        {
            player.SetWeapon(Weapons.Glock);
        }
        
        
    }

    public static void Heal(Player player)
    {
        Random rnd  = new Random();
        int rand = rnd.Next(1, 100);
        if (rand <= 33)
        {
            player.Heal(HealPotions.Small);
        }
        if (rand is < 33 and <= 66)
        {
            player.Heal(HealPotions.Mid);
        }

        if (rand is < 66 and <= 100)
        {
            player.Heal(HealPotions.Large);
        }
    }

    public static void StrenghtUpgrade(Player player)
    {
        Random rnd  = new Random();
        int rand = rnd.Next(1, 100);
        if (rand <= 33)
        {
            player.GetStronger(StrenghtPotions.Redbull);
        }
        if (rand is < 33 and <= 66)
        {
            player.GetStronger(StrenghtPotions.Creatine);
        }

        if (rand is < 66 and <= 100)
        {
            player.GetStronger(StrenghtPotions.Steroids);
        }
    }
}