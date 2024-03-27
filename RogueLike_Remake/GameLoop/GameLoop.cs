using RogueLike_Remake.EventCatcher;
using RogueLike_Remake.GameConfiguration;
using RogueLike_Remake.GameController;
using RogueLike_Remake.GameInit;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.GameScene.Map;
using RogueLike_Remake.GameScene.RoomGenerator;
using RogueLike_Remake.MobAi;
using RogueLike_Remake.PrototypeFactory;
using RogueLike_Remake.Renderer;
using RogueLike_Remake.WeaponFactory;

namespace RogueLike_Remake.GameLoop
{
    internal class GameLoop : IGameLoop
    {
        public IGameConfig gameConfig { get; }
        public IProtoFactory protoFactory { get; }
        public IWeaponFactory weaponFactory { get; }
        public IRoomGenerator roomGenerator { get; }
        public IRoom Room { get; }
        public IMap Map { get; }
        public IGameController controller { get; }
        public IAliveObject player { get; }
        public ICatcher catcher { get; }
        public IRenderer renderer { get; }
        public bool work { get; } = true;

        public static event Action<bool>? Updated;

        public GameLoop()
        {
            gameConfig = new GameConfig();
            protoFactory = new ProtoFactory();
            weaponFactory = new WeaponFactory.WeaponFactory();
            roomGenerator = new RoomGenerator(gameConfig, protoFactory);
            Room = roomGenerator.GenerateRoom();
            Map = new Map("Map1", 4);
            controller = new GameController.GameController();
            player = new AliveObject("Игрок", "Текущий игрок", false, new Sprite('&'), new Position(3, 3), new Health(10), weaponFactory.Create("Bow"));
            Room.Add(player);
            catcher = new Catcher(Room, Map, roomGenerator);
            renderer = new Renderer.Renderer(Map, Room, player.Id);
        }
        public void Start() 
        {
            while (work)
            {
                renderer.RenderFrame();
                controller.Control(player);
                renderer.ClearFrame();
                Updated?.Invoke(true);
                player.LowInfo();
                //Room.FindByPos(new Position(3, 0), "StaticObject")?.LowInfo();
            }
        }
    }
}
