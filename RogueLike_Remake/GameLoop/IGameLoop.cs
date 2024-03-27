using RogueLike_Remake.EventCatcher;
using RogueLike_Remake.GameConfiguration;
using RogueLike_Remake.GameController;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameScene.Map;
using RogueLike_Remake.GameScene.RoomGenerator;
using RogueLike_Remake.PrototypeFactory;
using RogueLike_Remake.Renderer;
using RogueLike_Remake.WeaponFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_Remake.GameLoop
{
    internal interface IGameLoop
    {
        public IGameConfig gameConfig {  get; }
        public IProtoFactory protoFactory {  get; }
        public IWeaponFactory weaponFactory { get; }
        public IRoomGenerator roomGenerator { get; }
        public IRoom Room { get; }
        public IMap Map { get; }
        public IGameController controller { get; }
        public IAliveObject player { get; }
        public ICatcher catcher { get; }
        public IRenderer renderer { get; }

        public static event Action<bool>? Updated;
        public void Start();
    }
}
