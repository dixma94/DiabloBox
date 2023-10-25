using UnityEngine;

public class QuestStepSO: ScriptableObject
{
    public string StepInfo;

    private bool IsFinished = false;
    protected string questId;
    protected GameEventManager gameEventManager;


    public virtual void InitializeQuestStep(string questId, GameEventManager gameEventManager)
    {


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
