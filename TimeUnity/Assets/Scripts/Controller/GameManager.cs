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
            ConfigManager.Instance.Init();
            RoomItemManager.Instance.Init();
            ButtonTipManager.Instance.Init();
            CharacterManager.Instance.Init();
            TimeLineManager.Instance.Init();
        }
    }
}