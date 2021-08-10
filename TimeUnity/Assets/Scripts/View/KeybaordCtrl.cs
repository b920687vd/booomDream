using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KeyConfigData = TimeUnity.Model.KeyConfigData;
using CharacterManager = TimeUnity.Controller.CharacterManager;

namespace TimeUnity.View{
    public class KeybaordCtrl:MonoBehaviour{
        //...
        void Update(){
            CheckKeyDown();
        }

        private KeyConfigData GetKeyConfig(){
            KeyConfigData c = new KeyConfigData(){
                KeyLeft = KeyCode.LeftArrow,
                KeyRight = KeyCode.RightArrow,
                KeyUse = KeyCode.C,
                KeySkill = KeyCode.Z
            };
            return c;
        }

        private bool isLeft = false;
        private bool isRight = false;

        private void CheckKeyDown(){
            if(Input.GetKeyDown(GetKeyConfig().KeyLeft)){
                isLeft =true;
            }else if(Input.GetKeyUp(GetKeyConfig().KeyLeft)){
                isLeft = false;
            }
            if(Input.GetKeyDown(GetKeyConfig().KeyRight)){
                isRight = true;
            }else if(Input.GetKeyUp(GetKeyConfig().KeyRight)){
                isRight = false;
            }
            if(Input.GetKeyDown(GetKeyConfig().KeyUse)){
                OnUse();
            }
            if(Input.GetKeyDown(GetKeyConfig().KeySkill)){
                OnSkill();
            }
            if(isLeft){
                OnLeft();
            }
            if(isRight){
                OnRight();
            }
        }

        private void OnLeft(){
            //...
            CharacterManager.Instance.OnCharLeft();
        }

        private void OnRight(){
            //...
            CharacterManager.Instance.OnCharRight();
        }

        private void OnUse(){
            //...
            CharacterManager.Instance.OnCharUse();
        }

        private void OnSkill(){
            //...
            CharacterManager.Instance.OnCharSkill();
        }
    }
}