using UnityEngine;
using MainCharacter = TimeUnity.View.MainCharacter;
using Room = TimeUnity.View.Room;
using RoomLayer = TimeUnity.View.RoomLayer;
using RoomItem = TimeUnity.View.RoomItem;

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
        public float speed = 1.5f;
        public float pos;
        public RoomItem curItem{
            get{
                return curRoom.CanUseItem(new Vector3(pos,0,0));
            }
        }
        public void Init(){
            //...
        }

        public void OnCharLeft(){
            //...
            if(pos > curRoom.LeftSide + 100){
                pos -= speed;
                UpdatePos();
                
            }
        }

        public void OnCharRight(){
            //...
            if(pos < curRoom.RightSide - 100){
                pos += speed;
                UpdatePos();
            }
        }

        public void UpdatePos(){
            MainCharacter.Ins.UpdatePos(pos);
            RoomItem hasItem = curItem;
            if(hasItem != null){
                ButtonTipManager.Instance.SetTip(hasItem.buttonKey,hasItem.buttonDesc);
            }else{
                ButtonTipManager.Instance.ClearTip();
            }
        }

        public void OnCharUse(){
            //...
        }

        public void OnCharSkill(){
            //...
        }
    }
}