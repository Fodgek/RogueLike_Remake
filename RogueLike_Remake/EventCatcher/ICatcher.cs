using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.GameScene.Map;
using RogueLike_Remake.GameObject.AddedObject.Bullet;

namespace RogueLike_Remake.EventCatcher
{
    internal interface ICatcher
    {
        public IMap _nowMap {  get; }
        public IRoom _nowRoom { get; }

        public void SubAllObj();
        public void UnsubAllObj();
        public void SubObj(IAliveObject obj);
        public void SubObj(IBullet obj);
        public void UnsubObj(IAliveObject obj);
        public void UnsubObj(IBullet obj);
    }
}
