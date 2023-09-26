using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Rat : SelectableObject, IDamageble
{
    private GameEventManager gameEventManager;

    [Inject]
    public void Construct(GameEventManager gameEventManager)
    {
        this.gameEventManager = gameEventManager;
    }
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
            gameEventManager.enemyEvents.EnemyKilled(EnemyType.Rat);
            Diselect();
            Destroy(gameObject);
        }
    }
    public override void ShowInfo()
    {
        tipUI.ShowInfoAboutEnemy(info, battleStats.health,battleStats.maxHealth);
    }

    public override void Interact(PlayerController player)
    {

    }


}
