namespace Primary
{
    public class Room
    {
        public Enemy.Enemy Enemy;
        public static string Treasure;

        public Room()
        {
            
        }
        public Room(Enemy.Enemy enemy)
        {
            Enemy = enemy;
        }
        public Room(string treasure)
        {
            Treasure = treasure;
        }

        public static class RoomFactory
        {
            public static Room CreateHub()
            {
                return new Room();
            }
            public static Room CreateEnemyRoom()
            {
                return new Room();
            }

            public static Room CreateTreasureRoom()
            {
                
                return new Room();
            }

            public static Room CreateBossRoom()
            {
                return new Room();
            }
            
        }
    }
}