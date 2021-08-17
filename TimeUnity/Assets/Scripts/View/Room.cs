using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using RoomItemManager = TimeUnity.Controller.RoomItemManager;
using RoomItemData = TimeUnity.Model.RoomItemData;

namespace TimeUnity.View{
    public class Room:MonoBehaviour{
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
        public bool IsInRoom(Vector3 p){
            return p.x < RightSide && p.x > LeftSide;
        }
        public RoomItemData CanUseItem(Vector3 p){
            for(int i=0;i<items.Count;i++){
                if(items[i].IsBetweenItem(p-transform.localPosition)){
                    return RoomItemManager.Instance.GetItemData(items[i].dataId);
                }
            }
            return null;
        }
    }
}