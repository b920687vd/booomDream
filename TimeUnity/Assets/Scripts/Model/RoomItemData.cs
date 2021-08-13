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
        public float timeWaiting = 0;
    }
}