

using RogueLike_Remake.GameScene.Map;

namespace RogueLike_Remake.Renderer
{
    internal class Renderer : IRenderer
    {
        private readonly IRoom _Room;
        public Renderer(IRoom room)
        {
            _Room = room;
        }
        public void RenderFrame() 
        {
            foreach (var obj in _Room._gameObjects) 
            {
                if (obj._Position._Y == _Room._height - 1)
                {
                    obj.DrawMe();
                    Console.WriteLine();
                }
                else obj.DrawMe();
            }
            Console.CursorVisible = false;
        }
        public void ClearFrame() => Console.Clear();
    }
}
