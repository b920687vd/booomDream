using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

namespace TimeUnity.View{
    [System.Serializable]
    public struct FrameStatus{
        public string key;
        public float timePerFrame;
        public List<Sprite> images;
    }
    public class SpriteFrameAnimator:MonoBehaviour{
        public Image image;
        protected string curStatusKey;
        protected float curFrameCount;
        protected int curFrameIndex;
        public List<FrameStatus> statusList;
        protected Dictionary<string,FrameStatus> status;
        public FrameStatus curStatus{
            get{
                return this.status[this.curStatusKey];
            }
        }
        public void PlayStatus(string statusKey){
            if(!this.status.ContainsKey(statusKey))
                return;
            this.curStatusKey = statusKey;
        }

        void Start(){
            if(this.image == null){
                this.image = gameObject.GetComponent<Image>();
            }
            this.status = new Dictionary<string, FrameStatus>();
            this.statusList.ForEach((s)=>{
                this.status.Add(s.key,s);
            });
        }

        void Update(){
            this.curFrameCount+=Time.deltaTime;
            if(this.status == null||this.curStatusKey == null)
                return;
            if(this.curFrameCount >= this.curStatus.timePerFrame){
                this.curFrameIndex++;
                if(this.curFrameIndex >= this.curStatus.images.Count){
                    this.curFrameIndex = 0;
                }
            }
            this.image.sprite = this.curStatus.images[this.curFrameIndex];
        }
    }
}