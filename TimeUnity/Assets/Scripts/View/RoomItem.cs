using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using RoomItemStatus = TimeUnity.Model.RoomItemStatus;
using RoomItemManager = TimeUnity.Controller.RoomItemManager;
using RoomItemData = TimeUnity.Model.RoomItemData;

namespace TimeUnity.View{
    public class RoomItem : MonoBehaviour
    {
        // Start is called before the first frame update
        public SpriteFrameAnimator animator;
        public string dataId;
        public bool canUse = false;
        public bool hasTip = false;
        public string tipKey = "C";
        //是否需要角色同步等待
        public bool needWaiting = false;
        public bool isSwitch = false;
        public float timeUsing = -1;
        public float timeError = -1;
        public float timeActive = 0;
        public RoomItemStatus status;
        public string buttonKey = "C";
        public string buttonDesc;
        public string buttonDescClose;
        public string buttonDescComplete;
        public Action onUse;
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
        public bool IsBetweenItem(Vector3 p){
            return p.x < RightSide && p.x > LeftSide;
        }
        void Start()
        {
            this.dataId = RoomItemManager.Instance.RegItem(this);
            this.onUse = ()=>{
                RoomItemData data = RoomItemManager.Instance.GetItemData(this.dataId);
                if(data.status == RoomItemStatus.idle)
                    data.status = RoomItemStatus.timeWaiting;
                else if(data.status == RoomItemStatus.timeWaiting)
                    data.status = RoomItemStatus.idle;
                this.SetStatus(data.status);
            };
        }

        public void SetTime(float time){
            this.timeActive = time;
        }

        public void SetStatus(RoomItemStatus status){
            this.status = status;
            this.animator.PlayStatus(this.status.ToString());
        }

        public void UpdateStatus(){
            RoomItemData data = RoomItemManager.Instance.GetItemData(this.dataId);
            if(data!=null)
            this.SetStatus(data.UpdateStatus());
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
