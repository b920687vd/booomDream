using UnityEngine;
using System;
using TimeUnity.Controller;

namespace TimeUnity.Model
{
    public enum RoomItemStatus
    {
        idle,
        timeWaiting,
        timeOver,
        error,
    }
    public class RoomItemData
    {
        public string id;
        public bool canUse = false;
        protected RoomItemStatus _curStatus = RoomItemStatus.idle;
        public RoomItemStatus status{
            get{
                return _curStatus;
            }set{
                if(_curStatus!=value){
                    _curStatus = value;
                    if(this.canUse)
                    onUpdateStatus(value);
                }
            }
        }
        //是否需要角色同步等待
        public bool needWaiting = false;
        public bool isSwitch = false;
        public float timeUsing = 0;
        public float timeActive = 0;
        public float timeError = 0;
        public string keyUse = "C";
        public string descUse;
        public string descClose;
        public string descComplete;

        public RoomItemData cloneConfig()
        {
            return new RoomItemData()
            {
                canUse = this.canUse,
                status = RoomItemStatus.idle,
                needWaiting = this.needWaiting,
                isSwitch = this.isSwitch,
                timeUsing = this.timeUsing,
                timeActive = 0,
                timeError = this.timeError,
                keyUse = this.keyUse,
                descUse = this.descUse,
                descClose = this.descClose,
                descComplete = this.descComplete,
            };
        }

        public Action onUse;
        public Action onPause;
        public Action onComplete;
        public Action<RoomItemStatus> onUpdateStatus;
        public void UpdateStatus()
        {
            if (this.timeActive >= this.timeError && this.timeError > 0)
            {
                this.status = RoomItemStatus.error;
            }
            else if (this.timeActive >= this.timeUsing && this.timeUsing > 0)
            {
                this.status = RoomItemStatus.timeOver;
            }
        }

        public void initAfter()
        {
            if (this.onUse == null)
            {
                this.onUse = () =>
                {
                    if (this.status == RoomItemStatus.idle)
                        this.status = RoomItemStatus.timeWaiting;
                    else if (this.status == RoomItemStatus.timeWaiting)
                        this.status = RoomItemStatus.idle;
                };
            }
            if(this.onComplete == null){
                this.onComplete = ()=>{
                    //...
                };
            }
        }
    }

    public class RoomItemScoreData{
        public string id;
        public string scoreMod;
        public float scoreNotUse;
        public float scoreUsing;
        public float scoreComplete;
    }
}