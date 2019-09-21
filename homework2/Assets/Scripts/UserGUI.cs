using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour, IUserAction {

    private int state;

    public UserGUI()
    {
        state = -1;
    }

    public void setWin()
    {
        state = 1;

    }

    public void setLose()
    {
        state = 0;
       
    }

    public void display()
    {
        OnGUI();
    }

    void OnGUI()
    {      
        if (GUI.Button(new Rect(50, 10, 100, 50), "Reset"))
        {
            Director.GetInstance().scene.reset();
        }
        if (state == 0)
        {
            GUI.Label(new Rect(300, 30, 100, 50), "You Lose!");
        }
        if (state == 1)
        {
            GUI.Label(new Rect(300, 30, 100, 50), "You Win!");
        }
        //左一按钮
        if (GUI.Button(new Rect(50, 100, 30, 30), "On"))
        {
            for(int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().scene.getPos("Devil" + i)==0)
                {
                    Director.GetInstance().scene.moveTo("Devil" + i);
                    break;
                }
            }  
        }
        //左二按钮
        if (GUI.Button(new Rect(100, 100, 30, 30), "On"))
        {
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().scene.getPos("Priest" + i) == 0)
                {
                    Director.GetInstance().scene.moveTo("Priest" + i);
                    break;
                }
            }
        }
        //右一
        if (GUI.Button(new Rect(500, 100, 30, 30), "On"))
        {
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().scene.getPos("Priest" + i) == 1)
                {
                    Director.GetInstance().scene.moveTo("Priest" + i);
                    break;
                }
            }
            
        }
        //右二
        if (GUI.Button(new Rect(550, 100, 30, 30), "On"))
        {
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().scene.getPos("Devil" + i) == 1)
                {
                    Director.GetInstance().scene.moveTo("Devil" + i);
                    break;
                }
            }
        }
        //Go
        if (GUI.Button(new Rect(300, 60, 30, 30), "Go"))
        {
            int x = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().scene.getPos("Priest" + i) == 2)
                {
                    x++;
                }
                if (Director.GetInstance().scene.getPos("Devil" + i) == 2)
                {
                    x++;
                }
            }            
            if (x != 0)
            {
                Director.GetInstance().scene.moveTo("boat");
            }
        }

        //off
        if (GUI.Button(new Rect(300, 150, 30, 30), "Off"))
        {
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().scene.getPos("Priest" + i) == 2)
                {
                    Director.GetInstance().scene.moveTo("Priest" + i);
                    break;
                }
                if (Director.GetInstance().scene.getPos("Devil" + i) == 2)
                {
                    Director.GetInstance().scene.moveTo("Devil" + i);
                    break;
                }
            }
        }
    }
}
