using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using RoomItemManager = TimeUnity.Controller.RoomItemManager;
using RoomItemData = TimeUnity.Model.RoomItemData;

namespace TimeUnity.View{
    public class Room:MonoBehaviour{
        void Start(){
            RoomItem[] startItems = gameObject.GetComponentsInChildren<RoomItem>();
            this.items = new List<RoomItem>(startItems);
        }
        //...
        public List<RoomItem> items;
        public float LeftSide{
            get
            {
                return transform.localPosition.x - gameObject.GetComponent<RectTransform>().sizeDelta.x/2;
            }
        }
        public float RightSide{
            get
            {
                return transform.localPosition.x + gameObject.GetComponent<RectTransform>().sizeDelta.x/2;
            }
        }
        public float UpSide{
            get{
                return transform.localPosition.y + gameObject.GetComponent<RectTransform>().sizeDelta.y/2;
            }
        }
        public float DownSide{
            get{
                return transform.localPosition.y - gameObject.GetComponent<RectTransform>().sizeDelta.y/2;
            }
        }
        public bool IsInRoom(Vector3 p){
            return p.x < RightSide && p.x > LeftSide && p.y>DownSide && p.y<UpSide;
        }
        public RoomItemData CanUseItem(Vector3 p){
            for(int i=0;i<items.Count;i++){
                RoomItemData data = RoomItemManager.Instance.GetItemData(items[i].dataId);
                if(!data.canUse)
                    continue;
                if(items[i].IsBetweenItem(p-transform.localPosition)){
                    return RoomItemManager.Instance.GetItemData(items[i].dataId);
                }
            }
            return null;
        }
    }
}