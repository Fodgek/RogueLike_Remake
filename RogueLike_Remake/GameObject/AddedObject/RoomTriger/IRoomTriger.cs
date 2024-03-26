using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_Remake.GameObject.AddedObject.RoomTriger
{
    internal interface IRoomTriger : IGameObject
    {
        public Guid _PrevRoomId { get; }
        public Guid _NextRoomId { get; }

        public void SetPrevRoomId(Guid id);
        public void SetNextRoomId(Guid id);
    }
}
