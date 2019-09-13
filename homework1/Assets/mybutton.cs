using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mybutton : MonoBehaviour
{  
    private string[] button = new string[9];
    private string result = "";
    private int[] button_state = new int[9];//0-空，1-X按下，2-O按下
    private int turn = 0;//1-X的回合，0-O的回合
    void Start()
    {
        init();
    }
    void init(){
        turn = 0;//o先走
        for (int i = 0; i < 9; i++){
            button[i] = "";
            button_state[i] = 0;
        }
    }
    void Update()
    {

    }
    void OnGUI()
    {
        GUI.Button(new Rect(20, 320, 100, 40), result);
        if (GUI.Button(new Rect(160, 320, 100, 40), "重新开始"))
        {
            init();//调用初始化函数，将棋盘清空
            result = "";
        }

        //若游戏结束则重新创建棋盘
        int a, b;
        if (ifIsEnd()){
            a = 20;
            b = 20;
            for (int j = 0; j < 3; j++){
                for (int k = 0; k < 3; k++){
                    GUI.Button(new Rect(a, b, 80, 80), button[3 * j + k]);
                    a += 80;
                }
                b += 80;
                a = 20;
            }

            if (GUI.Button(new Rect(160, 320, 100, 40), "重新开始"))
            {
                init();
                result = "";
            }
            return;
        }

        //检测玩家操作
        a = 20;
        b = 20;
        for (int j = 0; j < 3; j++){
            for (int k = 0; k < 3; k++){
                if (GUI.Button(new Rect(a, b, 80, 80), button[3 * j + k])){
                    if (button_state[3 * j + k] == 0 && turn == 0){
                        button[3 * j + k] = "O";
                        button_state[3 * j + k] = 2;
                    }
                    else if (button_state[3 * j + k] == 0 && turn == 1){
                        button[3 * j + k] = "X";
                        button_state[3 * j + k] = 1;
                    }
                    turn = (turn + 1) % 2;
                }
                a += 80;
            }
            b += 80;
            a = 20;
        }

    }

    //检查游戏是否结束,需要分别检查横竖对角线，结果有X赢、O赢和平局
    bool ifIsEnd()
    {

        //检查横排，012、345、678
        for (int j = 0; j < 7; j = j + 3){
            if (button_state[j] == button_state[j + 1] && button_state[j + 1] == button_state[j + 2]){
                if (button_state[j] == 1){
                    result = "X赢!";
                    return true;
                }
                else if (button_state[j] == 2){
                    result = "O赢!";
                    return true;
                }
            }
        }

        //检查竖排，036、147、258
        for (int j = 0; j < 3; j++){
            if (button_state[j] == button_state[j + 3] && button_state[j + 3] == button_state[j + 6]){
                if (button_state[j] == 1){
                    result = "X赢！";
                    return true;
                }
                else if (button_state[j] == 2){
                    result = "O赢！";
                    return true;
                }
            }
        }

        //检查对角线048、246
        if (button_state[0] == button_state[4] && button_state[4] == button_state[8]){
            if (button_state[0] == 1){
                result = "X赢！";
                return true;
            }
            else if (button_state[0] == 2){
                result = "O赢！";
                return true;
            }
        }
        if (button_state[2] == button_state[4] && button_state[4] == button_state[6]){
            if (button_state[2] == 1){
                result = "X赢！";
                return true;
            }
            else if (button_state[2] == 2){
                result = "O赢！";
                return true;
            }
        }

        //检查是否平局
        int m = 0;
        for (int j = 0; j < 9; j++){
            if (button_state[j] == 0){
                m = 1;
                break;
            }
        }
        if (m == 0){
            result = "平局";
            return true;
        }
        return false;
    }
}
