namespace Primary
{
    public class Room
    {
        private Enemy.Enemy _enemy;
        private string Treasure;
        public int RoomID;
        public Room()
        {
            
        }
        public Room(Enemy.Enemy enemy)
        {
            _enemy = enemy;
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
                Enemy.Enemy goblin = Enemy.Enemy.Factory.CreateGoblin();
                return new Room(goblin);
            }

            public static Room CreateTreasureRoom()
            {
                string treasure = "Hey this is a treasure!";
                return new Room(treasure);
            }
            
        }
    }
}