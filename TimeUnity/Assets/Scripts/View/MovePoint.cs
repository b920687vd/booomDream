using UnityEngine;
using UnityEngine.UI;
using TimeUnity.Model;
using TimeUnity.Controller;

namespace TimeUnity.View{
    public class MovePoint:RoomItem{
        public MovePoint moveAim;

        void Start()
        {
            this.dataId = RoomItemManager.Instance.RegItem(this);
            RoomItemData data = RoomItemManager.Instance.GetItemData(this.dataId);
            data.onUse = ()=>{
                CharacterManager.Instance.CharMoveTo(moveAim.transform.localPosition + moveAim.transform.parent.localPosition);
            };
            this.animator.PlayStatus("idle");
        }

        public override void SetStatus(RoomItemStatus status){
            this.status = status;
        }
    }
}