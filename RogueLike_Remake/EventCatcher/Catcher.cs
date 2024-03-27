using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameScene.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.AddedObject.Bullet;
using RogueLike_Remake.GameObject.AddedObject.RoomTriger;
using RogueLike_Remake.GameScene.RoomGenerator;
using RogueLike_Remake.GameLoop;

namespace RogueLike_Remake.EventCatcher
{
    internal class Catcher : ICatcher
    {
        public IMap _nowMap {  get; }
        public IRoom _nowRoom { get; private set; }

        private IRoomGenerator _roomGenerator;

        public Catcher(IRoom nowRoom, IMap nowMap, IRoomGenerator generator) 
        {
            _nowRoom = nowRoom;
            _nowMap = nowMap;
            nowMap.Add(_nowRoom);
            _roomGenerator = generator;
            SubAllObj();
        }
        public void SubAllObj() 
        {
            foreach (var obj in _nowRoom._gameObjects) 
            {
                if (obj is IAliveObject)
                {
                    ((IAliveObject)obj).Moved += Move;
                    ((IAliveObject)obj).Attacked += Attack;
                    ((IAliveObject)obj).Dead += DeadObj;
                }
            }
        }
        public void UnsubAllObj() 
        {
            foreach (var obj in _nowRoom._gameObjects)
            {
                ((IAliveObject)obj).Moved -= Move;
                ((IAliveObject)obj).Attacked -= Attack; 
                ((IAliveObject)obj).Dead -= DeadObj;
            }
        }
        public void SubObj(IAliveObject obj)
        {
            ((IAliveObject)obj).Moved -= Move;
            ((IAliveObject)obj).Attacked -= Attack;
            ((IAliveObject)obj).Dead -= DeadObj;
        }
        public void SubObj(IBullet obj)
        {
            obj.Moving += Shooting;
            obj.DelBullet += DelBullet;
        }
        public void UnsubObj(IBullet obj)
        {
            obj.Moving -= Shooting;
            obj.DelBullet -= DelBullet;
        }
        public void UnsubObj(IAliveObject obj)
        {
            obj.Moved -= Move;
            obj.Attacked -= Attack;
            obj.Dead -= DeadObj;
        }
        private void DelBullet(IBullet obj)
        {
            _nowRoom._gameObjects.Remove(obj);
            UnsubObj(obj);
        }
        private void DeadObj(IAliveObject obj)
        {
            _nowRoom._gameObjects.Remove(obj);
            UnsubObj(obj);
        }
        private void Move(IAliveObject obj, Direction direction) 
        {
            Position NextPos = obj._Position.ChangePos(direction);
            IGameObject? staticobj = _nowRoom.FindByPos(NextPos, "StaticObject");
            IGameObject? aliveobj = _nowRoom.FindByPos(NextPos, "AliveObject");
            IGameObject? trigerobj = _nowRoom.FindByPos(NextPos, "Triger");
            if (staticobj != null && aliveobj != null && trigerobj != null)
                if (staticobj._IsPasable && aliveobj._IsPasable && trigerobj._IsPasable)
                    obj.SetPos(NextPos); 
                else
                    return;
            else
                if (staticobj != null && staticobj._IsPasable)
                    obj.SetPos(NextPos);
                else if (aliveobj != null && aliveobj._IsPasable)
                    obj.SetPos(NextPos);
                else if (trigerobj != null && trigerobj._IsPasable)
                {
                    ChRoom((IRoomTriger)trigerobj);
                    obj.SetPos(GetReversBorder(NextPos));
                    _nowRoom.Add(obj);
                    _nowRoom.Info();
                }
        }
        private void ChRoom(IRoomTriger triger) 
        {
            IRoom? temproom = _nowMap.FindById(triger._NextRoomId);
            if (temproom != null)
            {
                _nowRoom = temproom;
            }
            else
            {
                IRoom newRoom = _roomGenerator.GenerateRoom();
                triger.SetNextRoomId(newRoom.Id);
                IRoomTriger? newtriger = (IRoomTriger?)newRoom.FindByPos(GetReversBorder(triger._Position), "Triger");
                newtriger?.SetNextRoomId(_nowRoom.Id);
                _nowMap.Add(newRoom);
                _nowRoom = newRoom;
            }
        }
        private Position GetReversBorder(Position pos) 
        {
            Position revPos;
            if (pos._X == 0)
                revPos = new Position(_nowRoom._width - 1, pos._Y);
            else if (pos._X == _nowRoom._width - 1)
                revPos = new Position(0, pos._Y);
            else if (pos._Y == 0 )
                revPos = new Position(pos._X, _nowRoom._height - 1);
            else if (pos._Y == _nowRoom._height - 1)
                revPos = new Position(pos._X, 0);
            else
                revPos = pos;
            return revPos;
        }
        private void Attack(IAliveObject attaker, WeaponType type, int maxdistance, int damage) 
        {
            if (type == WeaponType.Near)
            {
                Position[] NextPos = attaker._Position.GetPosArrFromDirect(attaker._Position._Direction, maxdistance);
                foreach (Position pos in NextPos)
                    ((IAliveObject?)_nowRoom.FindByPos(pos, "AliveObject"))?.Damaged(damage);
            }
            else if (type == WeaponType.Range)
            {
                Position NextPos = attaker._Position.ChangePos(attaker._Position._Direction);
                IBullet bullet = new Bullet(NextPos, damage);
                _nowRoom.Add(bullet);
                SubObj(bullet);
            }
        }
        private void Shooting(IBullet bullet) 
        {
            Position NextPos = bullet._Position.ChangePos(bullet._Position._Direction);
            IGameObject? staticobj = _nowRoom.FindByPos(NextPos, "StaticObject");
            IGameObject? aliveobj = _nowRoom.FindByPos(NextPos, "AliveObject");
            IGameObject? trigerobj = _nowRoom.FindByPos(NextPos, "Triger");
            if (staticobj != null && aliveobj != null && trigerobj != null)
                if (staticobj._IsPasable && aliveobj._IsPasable && trigerobj._IsPasable)
                    bullet.SetPos(NextPos);
                else 
                {
                    ((IAliveObject)aliveobj).Damaged(bullet._Damage);
                    bullet.Destroy();
                }
            else
                if (aliveobj != null)
                {
                    ((IAliveObject)aliveobj).Damaged(bullet._Damage);
                    _nowRoom.DelById(bullet.Id);
                }
                else if (staticobj != null && staticobj._IsPasable)
                    bullet.SetPos(NextPos);
                else if (staticobj != null && !staticobj._IsPasable)
                    _nowRoom.DelById(bullet.Id);
                else if (trigerobj != null && trigerobj._IsPasable)
                {
                    _nowRoom.DelById(bullet.Id);
                }
        }
    }
}
