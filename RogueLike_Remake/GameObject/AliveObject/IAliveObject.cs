using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_Remake.GameObject.DinamicObject
{
    internal interface IAliveObject : IGameObject, IDrawable
    {
        bool IsAlive { get; }
        public void Move(Direction direction);
        public void Attack(IGameObject gameObject);
        public void Damaged(int value);
    }
}
