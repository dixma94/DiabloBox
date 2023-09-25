using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "KillEnemy", menuName = "ScriptableObjects/QuestStepSO/ KillEnemy", order = 2)]
public class KillEnemyQuestStepSO : QuestStepSO
{
    public EnemyType enemyType;
    public int count;

    private void OnValidate()
    {
        questStep = new KillEnemyQuestStep();
    }
}

public class KillEnemyQuestStep : QuestStep
{
    private int killedCount;
    private int needToKill;
    private EnemyType enemyType;





    public override void InitializeQuestStep(QuestStepSO infoSO, string questId, GameEventManager gameEventManager)
    {
        base.questId = questId;
        base.gameEventManager = gameEventManager;
        KillEnemyQuestStepSO so = infoSO as KillEnemyQuestStepSO;

        needToKill = so.count;
        enemyType = so.enemyType;

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
