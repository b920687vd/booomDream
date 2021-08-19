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
        public float speed = 3f;
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
            curItem.onUse();
            if(curItem.needWaiting){
                this.isUsing = !this.isUsing;
                TimeLineManager.Instance.uiClock.SetUpdating(this.isUsing);
            }
            TimeLineManager.Instance.SwitchRegItem(curItem.id);
            ButtonTipManager.Instance.SetTipByItem(curItem.id);
        }

        public void OnCharSkill(){
            //...
        }
    }
}