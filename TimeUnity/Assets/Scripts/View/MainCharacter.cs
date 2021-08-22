using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeUnity.Controller;

namespace TimeUnity.View{
    public class MainCharacter : MonoBehaviour
    {
        public static MainCharacter Ins;
        void Start()
        {
            MainCharacter.Ins = this;
        }

        // Update is called once per frame
        protected float timeCount;
        void Update()
        {
            if(CharacterManager.Instance.isUsing){
                this.timeCount += Time.deltaTime;
                if(this.timeCount>0.2f){
                    CharacterManager.Instance.UsingTimePast(1);
                    this.timeCount-=0.2f;
                }
            }else{
                this.timeCount = 0;
            }
        }

        public void UpdatePos(float pos,float roomY){
            Vector3 pVec = new Vector3(transform.localPosition.x,roomY -380,transform.localPosition.z);
            Vector3 viewP = new Vector3(pos,roomY,0);
            pVec.x = pos;
            transform.localPosition = pVec;
            RoomLayer.Ins.SeePos(viewP);
        }
    }
}
