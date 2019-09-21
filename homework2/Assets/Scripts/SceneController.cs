using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SceneController
{
    void load();                                                                  
    void reset();
    void moveTo(string name);
    int getPos(string name);                          
   
}
