using UnityEngine;
using System;
using System.Collections.Generic;

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

        public float timeHour;
        public float timeMin;
        public void Init(){
            //...
        }
    }
}