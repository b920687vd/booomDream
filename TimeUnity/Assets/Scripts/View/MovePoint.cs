using UnityEngine;
using UnityEngine.UI;
using TimeUnity.Model;

namespace TimeUnity.View{
    public class MovePoint:RoomItem{
        public MovePoint moveAim;

        public override void SetStatus(RoomItemStatus status){
            this.status = status;
        }
    }
}