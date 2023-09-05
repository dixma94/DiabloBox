using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvents 
{
    public event Action<EnemyType> onEnemyKilled;
    public void EnemyKilled(EnemyType enemyType)
    {
        if (onEnemyKilled != null)
        {
            onEnemyKilled(enemyType);
        }
    }
}
