﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface SSActionManager:CCMoveToAction,CCSequenceAction
{
    void reset();
    int getPos(string name);
}