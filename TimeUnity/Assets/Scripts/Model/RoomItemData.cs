using UnityEngine;

namespace TimeUnity.Model{
    public enum RoomItemStatus{
        idle,
        timeWaiting,
        timeOver,
        error,
    }
    public class RoomItemData{
        public string id;
        public RoomItemStatus status = RoomItemStatus.idle;
        //是否需要角色同步等待
        public bool needWaiting = false;
        public float timeUsing = 0;
        public float timeActive = 0;
        public float timeError = 0;
        public RoomItemStatus UpdateStatus(){
            if(this.status == RoomItemStatus.idle||this.status == RoomItemStatus.error)
                return this.status;
            if(this.timeActive > this.timeError && this.timeError>0){
                this.status = RoomItemStatus.error;
            }else if(this.timeActive > this.timeUsing && this.timeUsing > 0){
                this.status = RoomItemStatus.timeOver;
            }
            return this.status;
        }
    }
}