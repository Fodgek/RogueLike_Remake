using RogueLike_Remake.EventCatcher;
using RogueLike_Remake.GameConfiguration;
using RogueLike_Remake.GameController;
using RogueLike_Remake.GameInit;
using RogueLike_Remake.MobAi;
using RogueLike_Remake.Renderer;

namespace RogueLike_Remake.GameLoop
{
    internal class GameLoop : IGameLoop
    {
        private readonly IGameConfig _GameConfig;
        private readonly IGameInit _Initializer;
        private readonly IGameController _Controller;
        private readonly IMobAi _MobAi;
        private readonly IRenderer _Renderer;
        private readonly ICatcher _Catcher;

        /*public GameLoop(IGameConfig gameConfig)
        {
            _GameConfig = gameConfig;
            _Initializer = new GameInit.GameInit(gameConfig);
            _Controller = new GameController.GameController();
            _MobAi = new MobAi.MobAi();
            _Renderer = new Renderer.Renderer();
        }
        public void Start() 
        {
            _Initializer.Init();
        }*/
    }
}
