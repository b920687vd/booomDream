using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeUnity.View{
    public class MainCharacter : MonoBehaviour
    {
        public static MainCharacter Ins;
        void Start()
        {
            MainCharacter.Ins = this;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void UpdatePos(float pos){
            Vector3 pVec = new Vector3(transform.localPosition.x,transform.localPosition.y,transform.localPosition.z);
            Vector3 viewP = new Vector3(pos,0,0);
            pVec.x = pos;
            transform.localPosition = pVec;
            RoomLayer.Ins.SeePos(viewP);
        }
    }
}
