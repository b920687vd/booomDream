using UnityEngine;
using MainCharacter = TimeUnity.View.MainCharacter;
using Room = TimeUnity.View.Room;
using RoomLayer = TimeUnity.View.RoomLayer;
using RoomItem = TimeUnity.View.RoomItem;
using RoomItemData = TimeUnity.Model.RoomItemData;

namespace TimeUnity.Controller{
    public class CharacterManager{
        //...
        private static CharacterManager _instance;
        public static CharacterManager Instance{
            get{
                if(CharacterManager._instance == null){
                    CharacterManager._instance = new CharacterManager();
                }
                return CharacterManager._instance;
            }
        }
        public Room curRoom{
            get{
                return RoomLayer.Ins.GetCurRoom();
            }
        }
        public float speed = 6f;
        public float pos;
        public bool isUsing;
        public RoomItemData curItem{
            get{
                return curRoom.CanUseItem(new Vector3(pos,0,0));
            }
        }
        public void Init(){
            //...
        }

        public void OnCharLeft(){
            //...
            if(this.isUsing)
                return;
            if(pos > curRoom.LeftSide + 100){
                pos -= speed;
                UpdatePos();
                
            }
        }

        public void OnCharRight(){
            //...
            if(this.isUsing)
                return;
            if(pos < curRoom.RightSide - 100){
                pos += speed;
                UpdatePos();
            }
        }

        public void UpdatePos(){
            MainCharacter.Ins.UpdatePos(pos);
            RoomItemData hasItem = curItem;
            if(hasItem != null){
                ButtonTipManager.Instance.SetTipByItem(hasItem.id);
            }else{
                ButtonTipManager.Instance.ClearTip();
            }
        }

        public void OnCharUse(){
            if(curItem==null)
                return;
            if(curItem.status == Model.RoomItemStatus.idle || curItem.status == Model.RoomItemStatus.timeWaiting){
                curItem.onUse();
                if(curItem.needWaiting){
                    SetUsing(!this.isUsing);
                }
                TimeLineManager.Instance.SwitchRegItem(curItem.id);
            }else if(curItem.status == Model.RoomItemStatus.timeOver){
                curItem.onComplete();
            }
            ButtonTipManager.Instance.SetTipByItem(curItem.id);
        }

        public void UsingTimePast(int min){
            TimeLineManager.Instance.TimePast(min);
            if(curItem.needWaiting && curItem.status == Model.RoomItemStatus.timeOver){
                SetUsing(!this.isUsing);
            }
            ButtonTipManager.Instance.SetTipByItem(curItem.id);
        }

        public void SetUsing(bool s){
            this.isUsing = s;
            TimeLineManager.Instance.SetUpdating(this.isUsing);
        }

        public void CharMoveTo(Vector3 pos){
            this.pos = pos.x;
            UpdatePos();
        }

        public void OnCharSkill(){
            //...
        }
    }
}