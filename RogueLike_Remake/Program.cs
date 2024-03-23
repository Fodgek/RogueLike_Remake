using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.StaticObject;
using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake;
using RogueLike_Remake.RoomGenerator;
using RogueLike_Remake.GameConfiguration;
using RogueLike_Remake.PrototypeFactory;
using RogueLike_Remake.GameScene.Map;
using RogueLike_Remake.Renderer;

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

IGameConfig gameConfig = new GameConfig();
IProtoFactory protoFactory = new ProtoFactory();
IRoomGenerator roomGenerator = new RoomGenerator(gameConfig,protoFactory);
IRoom Room = roomGenerator.GenerateRoom();
IRenderer renderer = new Renderer(Room);
renderer.RenderFrame();
