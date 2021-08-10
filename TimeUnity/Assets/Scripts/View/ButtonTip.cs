using UnityEngine;
using UnityEngine.UI;

namespace TimeUnity.View{
    public class ButtonTip:MonoBehaviour{
        //...
        public Text buttonKey;
        public Text buttonDesc;

        public void SetTip(string key,string desc){
            buttonKey.text = key;
            buttonDesc.text = desc;
        }
    }
}