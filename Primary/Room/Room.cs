namespace Primary
{
    public class Room
    {
        public Enemy.Enemy EnemyEntity
        {
            get;
            private set;
        }

        public string Treasure
        {
            get;
            private set;
        }
        
        public Room() 
        {
            
        }
        
        public Room(Enemy.Enemy enemy)
        {
            EnemyEntity = enemy;
        }

        public static class RoomFactory
        {
            public static Room CreateHub()
            {
                return new Room();
            }
            public static Room CreateEnemyRoom()
            {
                Enemy.Enemy enemy = Enemy.Enemy.Factory.CreateGoblin();
                return new Room(enemy);
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