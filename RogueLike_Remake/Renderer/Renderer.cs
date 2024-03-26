

using RogueLike_Remake.GameScene.Map;

namespace RogueLike_Remake.Renderer
{
    internal class Renderer : IRenderer
    {
        private readonly IRoom _Room;
        private char[,] currentBuffer;
        public Renderer(IRoom room)
        {
            _Room = room;
            currentBuffer = new char[_Room._width, _Room._height];
        }
        public void RenderFrame() 
        {
            foreach (var obj in _Room._gameObjects)
                currentBuffer[obj._Position._X, obj._Position._Y] = obj._Sprite._symbol;

            for (int Y = 0; Y < _Room._width; Y++)
            {
                for (int X = 0; X < _Room._height; X++)
                {
                    Console.Write("{0,2}", currentBuffer[X, Y]);
                }
                Console.WriteLine();
            }
            Console.CursorVisible = false;
        }
        public void ClearFrame() => Console.Clear();
    }
}
