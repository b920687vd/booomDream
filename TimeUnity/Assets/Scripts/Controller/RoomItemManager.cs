using UnityEngine;
using System;
using System.Collections.Generic;
using TimeUnity.Model;
using TimeUnity.View;

namespace TimeUnity.Controller{
    public class RoomItemManager{
        private static RoomItemManager _instance;
        public static RoomItemManager Instance{
            get{
                if(RoomItemManager._instance == null)
                    RoomItemManager._instance = new RoomItemManager();
                return RoomItemManager._instance;
            }
        }
        public List<RoomData> rooms;
        public Dictionary<string,RoomItemData> roomItems;
        public Dictionary<string,RoomItem> roomItemViews;
        public void Init(){
            this.rooms = new List<RoomData>();
            this.roomItems = new Dictionary<string, RoomItemData>();
            this.roomItemViews = new Dictionary<string, RoomItem>();
        }
        public string RegItem(RoomItem itemView){
            string id = System.Guid.NewGuid().ToString();
            RoomItemData data = new RoomItemData(){
                id = id,
                status = RoomItemStatus.idle,
                needWaiting = itemView.needWaiting,
                timeUsing = itemView.timeUsing,
                timeActive = itemView.timeActive,
                timeError = itemView.timeError
            };
            this.roomItems.Add(id,data);
            this.roomItemViews.Add(id,itemView);
            return id;
        }
        public RoomItemData GetItemData(string id){
            if(!this.roomItems.ContainsKey(id))
                return null;
            return this.roomItems[id];
        }
    }
}