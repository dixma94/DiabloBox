using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsEvents 
{
    public event Action onRatKilled;
    public void RatKilled()
    {
        if (onRatKilled != null)
        {
            onRatKilled();
        }
    }
}
