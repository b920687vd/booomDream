using System.Collections.Generic;
using System;

namespace TimeUnity.Controller{
    public class GameManager{
        //...
        private static GameManager _instance;
        public static GameManager Instance{
            get{
                if(GameManager._instance == null){
                    GameManager._instance = new GameManager();
                }
                return GameManager._instance;
            }
        }
        public void Init(){
            ButtonTipManager.Instance.Init();
        }
    }
}