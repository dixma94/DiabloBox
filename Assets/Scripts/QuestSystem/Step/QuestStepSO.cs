using UnityEngine;

public class QuestStepSO: ScriptableObject
{
    public string StepInfo;

    private bool IsFinished = false;
    private string questId;
    protected GameEventManager gameEventManager;


    public virtual void InitializeQuestStep(string questId, GameEventManager gameEventManager, DataSaveLoadManager dataSaveLoadManager)
    {
        this.questId = questId;
        this.IsFinished = false;
        this.gameEventManager = gameEventManager;

    }
    [ContextMenu("FinishedQuestStep")]
    public void FinishedQuestStep()
    {
        if (!IsFinished)
        {
            IsFinished = true;
            gameEventManager.questEvents.AdvanceQuest(questId);

        }
    }
}
