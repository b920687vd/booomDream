using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace TimeUnity.View{
    public class UIClock:MonoBehaviour{
        public ClockBit[] hourBit;
        public ClockBit[] minBit;
        public Image centerPoint;
        public Image bgClock;
        public Image bgBlockPause;
        public bool isUpdating;
        public int testMin = 0;
        void Start(){
            this.SetTimeInMin(0);
            this.SetUpdating(false);
        }
        public void TestTime(){
            //...
            this.testMin += 4;
            this.SetTimeInMin(this.testMin);
        }
        public void SetUpdating(bool isActive){
            this.isUpdating = isActive;
            bgClock.sprite = Resources.Load<Sprite>("Image/UI/bgClock"+(isActive?"":"_grey"));
            bgBlockPause.gameObject.SetActive(!isActive);
            if(!isActive){
                centerPoint.gameObject.SetActive(true);
            }
        }
        public void SetTimeInMin(int min){
            int hour = min/60;
            int dMin = min%60;
            int tenHour = hour/10;
            int tenMin = dMin/10;
            int pHour = hour%10;
            int pMin = dMin%10;
            this.hourBit[0].SetBitByNum(tenHour);
            this.hourBit[1].SetBitByNum(pHour);
            this.minBit[0].SetBitByNum(tenMin);
            this.minBit[1].SetBitByNum(pMin);
        }
        float timeCount;
        void Update(){
            if(this.isUpdating){
                timeCount += Time.deltaTime;
                if(timeCount>=1f){
                    timeCount -= 1f;
                    this.centerPoint.gameObject.SetActive(!this.centerPoint.gameObject.activeSelf);
                }
            }
        }
    }
}