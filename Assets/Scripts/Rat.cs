using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : SelectableObject, IDamageble
{
    public ObjectBattleStats battleStats;

    public void TakeDamage(int damage)
    {
        battleStats.heath-=damage;
        if (battleStats.heath <= 0)
        {
            GameEventManager.instance.ratsEvents.RatKilled();
            Destroy(gameObject);
        }
    }
}
