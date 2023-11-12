using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "KillEnemy", menuName = "ScriptableObjects/QuestStepSO/ KillEnemy", order = 2)]
public class KillEnemyQuestStepSO : QuestStepSO
{
    public EnemyType enemyType;
    public int needToKill;
    private DataSaveLoadManager dataSaveLoadManager;

    public override void InitializeQuestStep(string questId, GameEventManager gameEventManager, DataSaveLoadManager dataSaveLoadManager)
    {
        base.InitializeQuestStep(questId, gameEventManager, dataSaveLoadManager);
        base.gameEventManager.enemyEvents.onEnemyKilled += EnemyKilled;
        this.dataSaveLoadManager = dataSaveLoadManager;
        if (dataSaveLoadManager.GetGameData().ratsKilled >= needToKill)
        {
            FinishedQuestStep();
        }
    }

    private void EnemyKilled(EnemyType enemyType)
    {
        if (enemyType == this.enemyType)
        {
            dataSaveLoadManager.GetGameData().ratsKilled++;
            if (dataSaveLoadManager.GetGameData().ratsKilled >= needToKill)
            {
                FinishedQuestStep();
            }
        }
    }
}

