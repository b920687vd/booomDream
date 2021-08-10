using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeUnity.View{
    public class RoomItem : MonoBehaviour
    {
        // Start is called before the first frame update
        public bool canUse;
        public string buttonKey;
        public string buttonDesc;
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
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
