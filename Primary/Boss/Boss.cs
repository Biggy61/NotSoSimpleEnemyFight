namespace Primary;

public class Boss : Enemy.Enemy
{
    public Boss(string name, int hp, int baseDmg, bool isLiving) : base(name, hp, baseDmg, isLiving)
    {
    }
    public static class FactoryBoss
    {
        public static Boss CreateBoss()
        {
            return new Boss("Boss", 250, 15, true);
        }
        
            
    }
}