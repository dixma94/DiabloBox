using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "KillEnemy", menuName = "ScriptableObjects/QuestStepSO/ KillEnemy", order = 2)]
public class KillEnemyQuestStepSO : QuestStepSO
{
    public EnemyType enemyType;
    public int needToKill;

    private int killedCount;

    public override void InitializeQuestStep(string questId, GameEventManager gameEventManager)
    {
        base.questId = questId;
        base.gameEventManager = gameEventManager;
        base.gameEventManager.enemyEvents.onEnemyKilled += EnemyKilled;
    }

    private void EnemyKilled(EnemyType enemyType)
    {
        if (enemyType == this.enemyType)
        {
            killedCount++;
            if (killedCount >= needToKill)
            {
                FinishedQuestStep();
            }
        }
    }
}

