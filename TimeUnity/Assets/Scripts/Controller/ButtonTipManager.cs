using System.Collections.Generic;
using System;
using ButtonTipPopup = TimeUnity.View.ButtonTipPopup;
using RoomItemData = TimeUnity.Model.RoomItemData;
using UnityEngine;

namespace TimeUnity.Controller{
    public class ButtonTipManager{
        //...
        private static ButtonTipManager _instance;
        public static ButtonTipManager Instance{
            get{
                if(ButtonTipManager._instance == null){
                    ButtonTipManager._instance = new ButtonTipManager();
                }
                return ButtonTipManager._instance;
            }
        }

        public string lastDesc;

        public void SetTipByItem(string dataId){
            RoomItemData itemData = RoomItemManager.Instance.GetItemData(dataId);
        }

        public void SetTip(string key,string desc){
            if(lastDesc == key+desc)
                return;
            ClearTip();
            ButtonTipPopup.Ins.AddTip(key,desc);
            lastDesc = key+desc;
        }

        public void ClearTip(){
            ButtonTipPopup.Ins.ClearTip();
            lastDesc = "";
        }

        public void Init(){
            //..
        }
    }
}