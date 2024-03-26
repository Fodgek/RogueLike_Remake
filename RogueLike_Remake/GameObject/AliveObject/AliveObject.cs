using RogueLike_Remake.GameObject.AddedObject.Bullet;
using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.Weapon;

namespace RogueLike_Remake.GameObject.AliveObject
{
    internal class AliveObject : IAliveObject
    {
        public Guid Id { get; }
        public string _Name { get; } = "AliveObject";
        public string _Description { get; } = "Живой Объект. Двигается заначит живой";
        public string _Tag { get; } = "AliveObject";
        public bool _IsPasable { get; }
        public Sprite _Sprite { get; }
        public Position _Position { get; private set; }
        public Health _Health { get; }
        public IWeapon _Weapon { get; }
        public bool _IsAlive { get; private set; }
        public bool _OnDel { get; private set; }

        public event Action<IAliveObject, Direction>? Moved;
        public event Action<IAliveObject, WeaponType, int, int>? Attacked;
        public event Action<IAliveObject>? Dead;

        public AliveObject(string name, string description, bool ispasable, Sprite sprite, Position position, Health health, IWeapon weapon)
        {
            Id = Guid.NewGuid();
            _Name = name;
            _Description = description;
            _IsPasable = ispasable;
            _Sprite = sprite;
            _Position = position;
            _Health = health;
            _Weapon = weapon;
            _IsAlive = health._value > 0;
            _OnDel = !_IsAlive;
        }

        public void Move(Direction direction) 
        {
            if (!_IsAlive) return;
            Moved?.Invoke(this, direction);
        }
        public void SetPos(Position pos) => _Position = pos;
        public void Attack() 
        {
            if (!_IsAlive) return;
            Attacked?.Invoke(this, _Weapon._Type, _Weapon._MaxDistance, _Weapon._Damage);
        }
        public void Damaged(int value)
        {
            if (!_IsAlive) return;
            _Health.DegHealth(value);
            if (_Health._value <= 0)
            {
                _IsAlive = false;
                Dead?.Invoke(this);
            }
        }
        public void Info()
        {
            Console.WriteLine("ID: {0}, Name: {1}, Description: {2}, Tag: {3}, Sprite: {4}, Position: {5}:{6}, Health: {7}, Alive: {8}", Id, _Name, _Description, _Tag, _Sprite._symbol, _Position._X, _Position._Y, _Health._value, _IsAlive);
        }
        public void LowInfo()
        {
            Console.WriteLine("Name: {0}, Pos: {1}:{2}, HP: {3}, Alive: {4}", _Name, _Position._X, _Position._Y, _Health._value, _IsAlive);
        }
        public IGameObject ChPosClone(Position pos)
        {
            return new AliveObject(_Name, _Description, _IsPasable, _Sprite, pos, _Health, _Weapon);
        }
        public void DelMe() => _OnDel = true;
    }
}
