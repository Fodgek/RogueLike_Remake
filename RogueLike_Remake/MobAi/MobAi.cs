using RogueLike_Remake.GameObject.AliveObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_Remake.MobAi
{
    internal class MobAi : IMobAi
    {
        private Random random = new Random();
        private int rand;
        public void RandAct(IAliveObject obj) 
        {
            rand = random.Next(4);
            switch (rand)
            {
                case 0: obj.Move(Direction.Up); break;
                case 1: obj.Move(Direction.Down); break;
                case 2: obj.Move(Direction.Left); break;
                case 3: obj.Move(Direction.Right); break;
                case 4: obj.Attack(); break;
            }
        }
    }
}
