using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameObject.AliveObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_Remake.GameController
{
    internal class GameController : IGameController
    {
        public ConsoleKey _Up { get; private set;  }
        public ConsoleKey _Down { get; private set; }
        public ConsoleKey _Left { get; private set; }
        public ConsoleKey _Right { get; private set; }
        public ConsoleKey _Attack { get; private set; }
        public void SetUp(ConsoleKey key) => _Up = key;
        public void SetDown(ConsoleKey key) => _Down = key;
        public void SetLeft(ConsoleKey key) => _Left = key;
        public void SetRight(ConsoleKey key) => _Right = key;
        public void SetAttack(ConsoleKey key) => _Attack = key;

        public GameController()
        {
            _Up = ConsoleKey.UpArrow;
            _Down = ConsoleKey.DownArrow;
            _Left = ConsoleKey.LeftArrow;
            _Right = ConsoleKey.RightArrow;
            _Attack = ConsoleKey.Z;
        }
        public GameController(ConsoleKey up,
                              ConsoleKey down,
                              ConsoleKey left,
                              ConsoleKey right,
                              ConsoleKey attack)
        {
            _Up = up;
            _Down = down;
            _Left = left;
            _Right = right;
            _Attack = attack;
        }
        public void Control(IAliveObject obj)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == _Up) obj.Move(Direction.Up);
            else if (keyInfo.Key == _Down) obj.Move(Direction.Down);
            else if (keyInfo.Key == _Left) obj.Move(Direction.Left);
            else if (keyInfo.Key == _Right) obj.Move(Direction.Right);
            else if (keyInfo.Key == _Attack) obj.Attack();
        }
    }
}
