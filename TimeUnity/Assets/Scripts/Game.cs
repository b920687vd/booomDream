using System.Collections.Generic;
using System;
using UnityEngine;
using TimeUnity.Controller;

namespace TimeUnity{
    public class Game:MonoBehaviour{
        //...
        void Awake(){
            LoadManager();
        }

        private void LoadManager(){
            GameManager.Instance.Init();
        }
    }
}