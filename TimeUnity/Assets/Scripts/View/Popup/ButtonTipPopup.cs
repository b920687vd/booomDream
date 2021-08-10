using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace TimeUnity.View{
    public class ButtonTipPopup:MonoBehaviour{
        //...
        public static ButtonTipPopup Ins;
        public List<ButtonTip> tips;

        void Start(){
            ButtonTipPopup.Ins = this;
            tips = new List<ButtonTip>();
        }

        public void ClearTip(){
            for(int i = 0;i<tips.Count;i++){
                Destroy(tips[i].gameObject);
            }
            tips = new List<ButtonTip>();
        }

        public void AddTip(string key,string desc){
            GameObject tipObj = (GameObject)Instantiate(Resources.Load("Prefab/UI/ButtonTip"));
            ButtonTip tip = tipObj.GetComponent<ButtonTip>();
            tip.SetTip(key,desc);
            tipObj.transform.SetParent(transform);
            tipObj.transform.localPosition = new Vector3(-100f,-466f,0f);
            tipObj.transform.localScale = Vector3.one;
            this.tips.Add(tip);
        }
    }
}