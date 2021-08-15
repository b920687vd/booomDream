using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace TimeUnity.View{
    public class ClockBit:MonoBehaviour{
        public int[,] viewMatrix = new int[,]{
            {0,1,0},
            {1,0,1},
            {0,0,0},
            {1,0,1},
            {0,1,0}
        };

        public Image[] bitImgs;
        public void SetBitByNum(int num){
            switch(num){
                case 0:
                    SetBitByMatrix(new int[,]{
                        {0,1,0},
                        {1,0,1},
                        {0,0,0},
                        {1,0,1},
                        {0,1,0}
                    });
                    break;
                case 1:
                    SetBitByMatrix(new int[,]{
                        {0,0,0},
                        {0,0,1},
                        {0,0,0},
                        {0,0,1},
                        {0,0,0}
                    });
                    break;
                case 2:
                    SetBitByMatrix(new int[,]{
                        {0,1,0},
                        {0,0,1},
                        {0,1,0},
                        {1,0,0},
                        {0,1,0}
                    });
                    break;
                case 3:
                    SetBitByMatrix(new int[,]{
                        {0,1,0},
                        {0,0,1},
                        {0,1,0},
                        {0,0,1},
                        {0,1,0}
                    });
                    break;
                case 4:
                    SetBitByMatrix(new int[,]{
                        {0,0,0},
                        {1,0,1},
                        {0,1,0},
                        {0,0,1},
                        {0,0,0}
                    });
                    break;
                case 5:
                    SetBitByMatrix(new int[,]{
                        {0,1,0},
                        {1,0,0},
                        {0,1,0},
                        {0,0,1},
                        {0,1,0}
                    });
                    break;
                case 6:
                    SetBitByMatrix(new int[,]{
                        {0,1,0},
                        {1,0,0},
                        {0,1,0},
                        {1,0,1},
                        {0,1,0}
                    });
                    break;
                case 7:
                    SetBitByMatrix(new int[,]{
                        {0,1,0},
                        {0,0,1},
                        {0,0,0},
                        {0,0,1},
                        {0,0,0}
                    });
                    break;
                case 8:
                    SetBitByMatrix(new int[,]{
                        {0,1,0},
                        {1,0,1},
                        {0,1,0},
                        {1,0,1},
                        {0,1,0}
                    });
                    break;
                case 9:
                    SetBitByMatrix(new int[,]{
                        {0,1,0},
                        {1,0,1},
                        {0,0,0},
                        {0,0,1},
                        {0,1,0}
                    });
                    break;
                default:
                    SetBitByMatrix(new int[,]{
                        {0,0,0},
                        {0,0,0},
                        {0,0,0},
                        {0,0,0},
                        {0,0,0}
                    });
                    break;
            }
        }
        public void SetBitByMatrix(int[,] matrix){
            this.viewMatrix = matrix;
            bitImgs[0].gameObject.SetActive(matrix[0,1]==1);
            bitImgs[1].gameObject.SetActive(matrix[1,0]==1);
            bitImgs[2].gameObject.SetActive(matrix[1,2]==1);
            bitImgs[3].gameObject.SetActive(matrix[2,1]==1);
            bitImgs[4].gameObject.SetActive(matrix[3,0]==1);
            bitImgs[5].gameObject.SetActive(matrix[3,2]==1);
            bitImgs[6].gameObject.SetActive(matrix[4,1]==1);
        }
    }
}