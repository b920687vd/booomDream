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
        public string configId;
        [NonSerialized]
        public string dataId;
        public RoomItemStatus status;
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
            RoomItemData data = RoomItemManager.Instance.GetItemData(this.dataId);
            data.onUpdateStatus += this.SetStatus;
            if(this.animator == null)
                this.animator = gameObject.GetComponent<SpriteFrameAnimator>();
        }

        public virtual void SetStatus(RoomItemStatus status){
            this.status = status;
            this.animator.PlayStatus(this.status.ToString());
        }

        public virtual void UpdateStatus(){
            RoomItemData data = RoomItemManager.Instance.GetItemData(this.dataId);
            if(data!=null)
            this.SetStatus(data.status);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
