using UnityEngine;
using System;
using System.Collections.Generic;
using TimeUnity.Model;

namespace TimeUnity.Controller{
    public class TimeLineManager{
        private static TimeLineManager _instance;
        public static TimeLineManager Instance{
            get{
                if(TimeLineManager._instance == null)
                    TimeLineManager._instance = new TimeLineManager();
                return TimeLineManager._instance;
            }
        }
        public readonly int dotPerSec;
        public List<RoomItemData> timeItems;
        public Dictionary<string,RoomItemData> timeItemDict;
        public Action<int> actionTimeUpdate;

        public float timeInSec{
            get{
                return timeDot / dotPerSec ;
            }
        }
        public int timeInMin{
            get{
                return Mathf.FloorToInt(timeDot);
            }
        }
        public float timeInHour{
            get{
                return timeInMin/60f;
            }
        }
        public float timeDot;
        public void Init(){
            //...
            this.timeItems = new List<RoomItemData>();
            this.timeItemDict = new Dictionary<string, RoomItemData>();
        }

        public void SwitchRegItem(string dataId){
            if(this.timeItemDict.ContainsKey(dataId)){
                this.RemoveActiveItem(dataId);
            }else{
                this.RegActiveItem(dataId);
            }
            Debug.Log(this.timeItems.Count);
        }

        public void RegActiveItem(string dataId){
            RoomItemData itemData = RoomItemManager.Instance.GetItemData(dataId);
            if(itemData == null)
                return;
            this.timeItems.Add(itemData);
            if(!this.timeItemDict.ContainsKey(dataId)){
                this.timeItemDict.Add(dataId,itemData);
            }
        }

        public void RemoveActiveItem(string dataId){
            if(!this.timeItemDict.ContainsKey(dataId))
                return;
            RoomItemData itemData = this.timeItemDict[dataId];
            this.timeItems.Remove(itemData);
        }

        public void TimePast(int dot){
            this.timeDot+=dot;
            foreach(var item in timeItems)
            {
                // if(item.status == RoomItemStatus.idle)
                //     continue;
                item.timeActive += dot;
                item.UpdateStatus();
            };
            RoomItemManager.Instance.UpdateView();
            this.actionTimeUpdate(this.timeInMin);
        }

        public void Update(float delta){
            //...
        }
    }
}