using RogueLike_Remake.GameObject.AliveObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_Remake.MobAi
{
    internal interface IMobAi
    {
        public void RandAct(IAliveObject obj);
    }
}
