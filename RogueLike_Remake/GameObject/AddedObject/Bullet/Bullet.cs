using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.Structs;
using System.Xml.Linq;

namespace RogueLike_Remake.GameObject.AddedObject.Bullet
{
    internal class Bullet : IBullet
    {
        public Guid Id { get; }
        public string _Name { get; } = "Bullet";
        public string _Description { get; } = "Пуля/стрела";
        public string _Tag { get; } = "Bullet";
        public bool _IsPasable { get; }
        public Sprite _Sprite { get; }
        public Position _Position { get; set; }
        public bool _OnDel { get; private set; }
        public int _Damage { get; }

        public event Action<Bullet>? DelBullet;
        public event Action<Bullet>? Moving;

        public Bullet(Position pos, int damage)
        {
            Id = Guid.NewGuid();
            _IsPasable = true;
            _Sprite = new Sprite('*');
            _Position = pos;
            _Damage = damage;
            _OnDel = false;
        }
        public Bullet(string name, string description, string tag, Sprite sprite, Position position, int damage)
        {
            Id = Guid.NewGuid();
            _Name = name;
            _Description = description;
            _Tag = tag;
            _IsPasable = true;
            _Sprite = sprite;
            _Position = position;
            _Damage = damage;
            _OnDel = false;
        }
        public void Info()
        {
            Console.WriteLine("ID: {0}, Name: {1}, Description: {2}, Tag: {3}, Sprite: {4}, Position: {5}:{6}", Id, _Name, _Description, _Tag, _Sprite._symbol, _Position._X, _Position._Y);
        }
        public void LowInfo()
        {
            Console.WriteLine("Name: {0}, Pos: {1}:{2}", _Name, _Position._X, _Position._Y);
        }
        public IGameObject ChPosClone(Position pos)
        {
            return new Bullet(_Name, _Description,_Tag, _Sprite, pos, _Damage);
        }
        public void SetPos(Position pos) => _Position = pos;
        public void Damaged(int value)
        {
            _OnDel = true;
        }
        public void DelMe() => _OnDel = true;

        private void  StartMoving()
        {
            Moving?.Invoke(this);
        }
        public void Destroy()
        {
            DelBullet?.Invoke(this);
        }
    }
}
