using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameObject.AliveObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_Remake.GameController
{
    internal interface IGameController
    {
        public ConsoleKey _Up { get; }
        public ConsoleKey _Down { get; }
        public ConsoleKey _Left { get; }
        public ConsoleKey _Right { get; }
        public ConsoleKey _Attack { get; }
        public void SetUp(ConsoleKey key);
        public void SetDown(ConsoleKey key);
        public void SetLeft(ConsoleKey key);
        public void SetRight(ConsoleKey key);
        public void SetAttack(ConsoleKey key);
        public void Control(IAliveObject obj);
    }
}
