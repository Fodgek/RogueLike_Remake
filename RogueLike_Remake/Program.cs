using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.StaticObject;
using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake;
using RogueLike_Remake.GameConfiguration;
using RogueLike_Remake.PrototypeFactory;
using RogueLike_Remake.GameScene.Map;
using RogueLike_Remake.Renderer;
using RogueLike_Remake.GameScene.RoomGenerator;
using RogueLike_Remake.GameController;
using RogueLike_Remake.GameObject;
using RogueLike_Remake.WeaponFactory;
using RogueLike_Remake.EventCatcher;
using RogueLike_Remake.GameLoop;

/*Console.Clear();
Console.SetCursorPosition(0, 0);
IStaticObject Object = new StaticObject("Плитка", "Плитка пола", "Plate", new Sprite(), new Position(10, 10), new Health(100));
Object.LowInfo();
Object.DrawMe();
Console.Clear();
IAliveObject aliveObject = new AliveObject("Игрок", "Ты", "Player", new Sprite('$'), new Position(12, 12), new Health(5));
aliveObject.LowInfo();
aliveObject.DrawMe();
aliveObject.Move(Direction.Down);
aliveObject.DrawMe();*/


/*IGameConfig gameConfig = new GameConfig();
IProtoFactory protoFactory = new ProtoFactory();
IWeaponFactory weaponFactory = new RogueLike_Remake.WeaponFactory.WeaponFactory();
IRoomGenerator roomGenerator = new RoomGenerator(gameConfig,protoFactory);
IRoom Room = roomGenerator.GenerateRoom();
IMap Map = new Map("Map1", 4);

IGameController controller = new GameController();
IAliveObject player = new AliveObject("Игрок", "Текущий игрок", false, new Sprite('&'), new Position(3, 3), new Health(10), weaponFactory.Create("Bow"));
Room.Add(player);
ICatcher catcher = new Catcher(Room, Map, roomGenerator);
IRenderer renderer = new Renderer(Map, Room, player.Id);
//renderer.RenderFrame();
bool work = true;
Console.WriteLine(7 % 2);
while (work) 
{
    renderer.RenderFrame();
    controller.Control(player);
    renderer.ClearFrame();
    player.LowInfo();
    //Room.FindByPos(new Position(3, 0), "StaticObject")?.LowInfo();
}*/

IGameLoop gameLoop = new GameLoop();
gameLoop.Start();

