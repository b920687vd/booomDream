using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TimeUnity.View{
    public class RoomLayer : MonoBehaviour
    {
        public List<Room> rooms;
        public MainCharacter mainCharacter;
        public static RoomLayer Ins;
        // Start is called before the first frame update
        void Start()
        {
            RoomLayer.Ins = this;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public Room GetCurRoom(){
            for(int i = 0;i<rooms.Count;i++){
                if(rooms[i].IsInRoom(mainCharacter.transform.localPosition))
                    return rooms[i];
            }
            return null;
        }
        public void SeePos(Vector3 pos,float duration = 0){
            transform.localPosition = pos * -1;
        }
    }
}
