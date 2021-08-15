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
        public float timeInSec{
            get{
                return timeDot / dotPerSec ;
            }
        }
        public float timeInMin{
            get{
                return timeInSec/ 60f;
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
        }

        public void TimePast(int dot){
            foreach(var item in timeItems)
            {
                if(item.status == RoomItemStatus.idle)
                    continue;
                item.timeActive += dot;
                item.UpdateStatus();
            };
        }
    }
}