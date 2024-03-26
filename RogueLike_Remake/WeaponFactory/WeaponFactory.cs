using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.GameObject;
using RogueLike_Remake.Weapon;

namespace RogueLike_Remake.WeaponFactory
{
    internal class WeaponFactory : IWeaponFactory
    {
        private readonly Dictionary<string, IWeapon> prototypes = new Dictionary<string, IWeapon> { };

        public WeaponFactory()
        {
            InitProto();
        }
        private void InitProto()
        {
            prototypes["Arm"] = new RogueLike_Remake.Weapon.Weapon("Кулаки", "Обычные кулаки", WeaponType.Near, 1, 1);
            prototypes["Sword"] = new RogueLike_Remake.Weapon.Weapon("Меч","Ржавый мечь",WeaponType.Near,2, 1);
            prototypes["Bow"] = new RogueLike_Remake.Weapon.Weapon("Лук", "Потрепаный лук", WeaponType.Range,5, 1);
        }
        public IWeapon Create(string protoTag)
        {
            return (prototypes.TryGetValue(protoTag, out IWeapon? weapon) ? weapon.Clone() : throw new ArgumentException("Нет такого прототипа {0}", protoTag));
        }
    }
}
