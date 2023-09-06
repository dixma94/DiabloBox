using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : SelectableObject, IDamageble
{
    public ObjectBattleStats battleStats;

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void TakeDamage(int damage)
    {
        battleStats.health-=damage;
        ShowInfo();
        if (battleStats.health <= 0)
        {
            GameEventManager.instance.enemyEvents.EnemyKilled(EnemyType.Rat);
            Diselect();
            Destroy(gameObject);
        }
    }
    public override void ShowInfo()
    {
        tipUI.ShowInfoAboutEnemy(info, battleStats.health,battleStats.maxHealth);
    }
}
