﻿
using UnityEngine;

public class BattleComponent : MonoBehaviour 
{
    [SerializeField] private ObjectBattleStats battleStats;

    public void AttackObject(IDamageble damageble)
    {
        damageble.TakeDamage(battleStats.damage);
    }
}

