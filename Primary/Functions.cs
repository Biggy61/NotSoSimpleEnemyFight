using System.Threading.Channels;
using Primary.Player;

namespace Primary;

public class Functions
{
    private static string _charName = Console.ReadLine() ?? throw new InvalidOperationException(); 
    public static Enemy.Enemy Boss = Enemy.Enemy.Factory.CreateBoss();
    public static Room startRoom = Room.RoomFactory.CreateHub();
    public static Room enemyRoom = Room.RoomFactory.CreateEnemyRoom();
    public static Room treasureRoom = Room.RoomFactory.CreateTreasureRoom();
    public static Room bossRoom = Room.RoomFactory.CreateBossRoom();
    public static Enemy.Enemy goblin = enemyRoom.EnemyEntity;
    public static Enemy.Enemy skeleton = Enemy.Enemy.Factory.CreateSkeleton();
    public static Player.Player player = new Player.Player(_charName, 200, 10, true, startRoom, Weapons.Hand);
    public bool TreasureCount = true;
    
    
    public void Move()
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("In what room would you like to go?");
                            Console.WriteLine("1. Start room \n2. Treasure room \n3. Enemy room \n4. Final boss");
                            Console.ForegroundColor = ConsoleColor.White;
                            int move = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                     
                            switch (move)
                                {
                                    case 1:
                                        player.Move(startRoom);
                                        Move();
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
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("You have to get through the enemy first ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Move();
                                        }
                                        break;
                                    case 3:
                                        player.Move(enemyRoom);
                                        if (goblin.isLiving == true)
                                        {
                                            Fight(goblin);
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have already killed the enemy");
                                            Move();
                                        }
                                        
                                        break;
                                    case 4:
                                        if (goblin.isLiving == false && TreasureCount == false)
                                        {
                                        player.Move(bossRoom);
                                        Fight(Boss);
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("You have to kill the enemy and collect the treasure first.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Move();
                                        }
                                        break;
                                    default:
                                        player.Move(startRoom);
                                        break;
                                }
                            
                                
                        }
            //--------------- FIGHT ---------------
            public void Fight(Enemy.Enemy enemy)
            {
                
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"There is an enemy!!\n{enemy} Do you want to fight him or leave? ");
                            Console.WriteLine("1. Fight \n2. Leave");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            int move = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            Console.ForegroundColor = ConsoleColor.White;
                            switch (move)
                            {
                                case 1:
                                    while (player.isLiving && enemy.isLiving)
                                    {
                                        enemy.Attack(player);
                                        player.Attack(enemy);
                                    }
                                    if (player.CurrentRoom == enemyRoom)
                                    {
                                        if (enemy.isLiving == false && player.isLiving == true)
                                        {
                                            Upgrade();
                                            Move();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You lost :(");
                                        }
                                    }
                                    if (player.CurrentRoom == bossRoom)
                                    {
                                        if (enemy == Boss)
                                        {
                                            if (Boss.isLiving == false && player.isLiving == true)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("You have won!!!");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine("...............   .......... . ..... . ........................................ \n ............... . ..........   .....   ........................................ \n ...............   ...............   ..   ....................   ............... \n ................................. . .. . .................... . ............... \n .................................   .    ....................   ............... \n .....   ................   ...... .   .. ...................................... \n ..... . ................ . ......  .     .....   ........................   ... \n .....   ...........        ...... .  ......... . ........................ . ... \n ..........   ...                    ..........   ........................   ... \n ...   .... . ... .  @  =                ....................................... \n ... . ....          @@@@@@@@@@@@@%        ............   ...................... \n ...   .......      @@@@%@++@@@@@@@@@@:       ......... . ..   ................. \n ..........      @@@@@@@@@@@@@+*@@@@@@@@@@##    .......   .. . ................. \n .........    #@@@@@@#@@@@@@@@@@@@+-=*  @@@@@   ............   ............   .. \n .......      @@@-#+#=@@@@%@@@@@@@@@@@#@@: .@   ........................... . .. \n .......    @@@#@@#@@@@@@@@@*#@@@@@@@@@@#@@@@@  ...........................      \n .....     @@@@@@@@*        .#@@- @@@-@@-@@+@@  ............................. .  \n ..... .  %@#@%@@                          *@#+  ............................    \n .....    @@@@@@+ :.:...                    =*@  ............................... \n .....    @@%*@%  =::.:.     ..              =@  ............................... \n .....    @@@@@::.#+:.   ....                 @+ ............................... \n .......  %@*@# :.-:::-.:...                  %+ ............................... \n .......  @@@#%*:--=                          @: ....   ........................ \n .......  @@@@@@*--=                          @  .... . ........................ \n ........ :@@%@@@-.  @@@@@@@@%@     @@@@@@@@  @  ....   ........................ \n .......  #@@#+@   @@@@** :--+*            %@ @                     .   ........ \n ......    @@@=@@@@@   -@+%#%@@*    %@@@@@= @#                        . .......  \n ......  @@.@@@@   @ @@  @  *: @@@@@  =@  @  @%@-      =@@@@@@%.        ...   .  \n   ....  @:   @@   @ ::..+@**  @   @         : @  -@@@@@@@@@@@@@@@@-    ... . .  \n .    .  +* @.:  : @          @    @          @ -%@@@@@@@@@@@@@@@@@@+   ...   .. \n    . ..  @:@  # =  @@@:    +@@     @        @  *@@@@@@#@@%#=+@@@@@:    ........ \n -... ..   +  @@ *.     :-+.@         :@@@@      @@@-    =*    .@@@@:   ........ \n .         +    =:=:.. :    =@@@@@%@          .*@@@@        ::   @@%.        ... \n   @@%   :@@@@@ * +-.         =       ..    .   +@@@@%-     :=.                  \n @@@@%@@@@@@*@@@= :=:+.                .   ..       +-    .....    %@@*-=#%-::.  \n #  @@*.%@@@+*@@ @   =. . %@@*@%@%@@@. .. ..       -@*:.::.     @@@*:   -*   ..  \n@@@+ .@+ =*-=#@@ @*. ..     +   *    * .          :+@@@@-           :..*@@*  .:- \n :@@@#.@@*:*@%@@ :@#.:-. .. +@+   -       @@         -@=    ..             :=+   \n-: + @# @#:+=*@@: =@@=-=  -.-@@@@%.:..   %#@+@@@@@=         ...   ..        -@@= \n @@.-*%--@@:+-@@=..-@@#=:              @@-.= @@+:* -@@*       ............       \n @-@   =@-@:=+:@%  :-%@@@@.           @@@ .+ @@  % +@##+@@:      ..........      \n :+*@@   *#@=+ @@:  :=*%@@@@#=:  .:% @:@- @: @% :@ -#=#  @@::     ............ : \n # :-@@#   %@*:=@@.  -=+=:+@@@@@@@.  @@@. @ @@  @@  @-+  @@. @@*        ......   \n %=   %@@=  +@@-:@# . ---++.        %@@  @: @-  @@  @*:  @@= @-@   ...    ....   \n +%%+   @@@   @@@:@--. :*%@@@@-:    @@  @  @%  @@*  +@= :@%: =*@ %          ..   \n -@@@%   +@@@  .+@@@   .          %@@  @@  @: .@@ : ==  +@%-  @* @@ :++=::.    . \n %% @@@%. #@@@@=   @@@-+:        @@@   :@% @  =@#.: *@+=@@-. #@  @@+     .  .. . \n  *%@@@#    @@ -#@         .-+:%@@#     @@ @ :=@#*=.:+ =@@+: @+- @*#        .  . \n   @  %*=    @   @@@:          @@     :@@@ @ %=*@+ :=#-#@== @@=.=@+=@ =-         \n    @   ...   :   @ @@@@  -@=@  @  @@@@@@@ - =+++#-: #.@@%  @=-.:=-*@: #-  ::    \n    #=   :        @     @@@  +:+:%-++.:**@  --=:+.%*:=%%#*  @ + :*.+@# %:#     . \n     @  ..-:.     %          .= .: .=@+. @@ %=%#++.-=+*@*@ @@+. -#=@@: #++-+@.   \n  -  .%   . .     :    .      @.%*  #.*  @#.+-..=-#+++#%.- @*==+@*#@++ = .   @@  \n      :+   .-.    .    :-#*=*=@*-*  *#+  @% *::=.*= *+#**+ @-+%%**@#:..:.=% +@*: \n .%%-+:*     :#@@-@@+@#@@@%:@ @+ # .@-+ :.@ *@-:# ::%@@*:. @.**.%@+=-#@@@.**@#=* \n #@@@@@#@  .*@@@@ .*#*      - @--* .-   %-@ @-::# *+#*=*-. @=*#@+=%*++  #+@%.  + \n @@+   :%*:@@@@+*  #          @*.:+ :+.@@++ ##:.+..+*=.+= -@-=#+*@:- .@#@=:.:@@@ \n #+                .                                      :%.==  -        : ");
                                            }  
                                        }
                                    }
                                    
                                    
                                    
                                    break;
                                case 2:
                                    player.Move(startRoom);
                                    Move();
                                    break;
                                default:
                                    player.Move(startRoom);
                                    break;
                            }
                        }
            //--------------- UPGRADE ---------------
            public void Upgrade()
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Congratulations! U have gotten an upgrade.");
                Console.WriteLine("Select which type of upgrade you want: \n1.Weapons \n2.Heal \n3.Strenght Potion");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                int upgrade = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.ForegroundColor = ConsoleColor.White;
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
                if (TreasureCount == true)
                {
                   Random rnd = new Random();
                                   Console.ForegroundColor = ConsoleColor.White;
                                   Console.WriteLine("OMG! there is a chest do you want to open it?");
                                   Console.ForegroundColor = ConsoleColor.Green;
                                   Console.WriteLine("1. YES!!!");
                                   Console.ForegroundColor = ConsoleColor.Red;
                                   Console.WriteLine("2. No, leave");
                                   Console.ForegroundColor = ConsoleColor.White;
                                   int treasure = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                                   switch (treasure)
                                   {
                                       case 1:
                                           int rand = rnd.Next(1, 101);
                                           
                                           if (rand <= 60)
                                           {
                                               Upgrade();
                                               TreasureCount = false;
                                           }
                                           else
                                           {
                                               Console.WriteLine("Oh no it was a trap");
                                               Fight(skeleton);
                                               TreasureCount = false;
                                           }
                                           break;
                                       case 2:
                                           player.Move(startRoom);
                                           TreasureCount = true;
                                           break;
                                       default:
                                           break;
                                   }
                                   
                                   
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have already opened the chest.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
}